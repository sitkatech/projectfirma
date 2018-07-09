using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateReminderScheduledBackgroundJob : ScheduledBackgroundJobBase
    {
        public static ProjectUpdateReminderScheduledBackgroundJob Instance { get; set; }

        static ProjectUpdateReminderScheduledBackgroundJob()
        {
            Instance = new ProjectUpdateReminderScheduledBackgroundJob("Project Update Reminder");
        }

        protected ProjectUpdateReminderScheduledBackgroundJob(string jobName) : base(jobName)
        {
        }

        public override List<FirmaEnvironmentType> RunEnvironments => new List<FirmaEnvironmentType>
        {
            FirmaEnvironmentType.Local,
            FirmaEnvironmentType.Prod,
            FirmaEnvironmentType.Qa
        };

        protected override void RunJobImplementation()
        {
            ProcessRemindersImpl();
        }

        protected virtual void ProcessRemindersImpl()
        {
            Logger.Info($"Processing '{JobName}' notifications.");

            // we're "tenant-agnostic" right now
            var projectUpdateConfigurations = DbContext.AllProjectUpdateConfigurations.ToList();
            var reminderSubject = "Time to update your Projects";

            foreach (var projectUpdateConfiguration in projectUpdateConfigurations)
            {
                List<Notification> notifications = new List<Notification>();
                var tenant = projectUpdateConfiguration.Tenant;
                HttpRequestStorage
                    .SetTenantForHangfire(
                        tenant); // we're intentionally overriding the HRS tenant here because Hangfire doesn't live in tenant-world
                // now that HRS.Tenant is set to the one we want, this is just that tenant's projects.
                var projects = DbContext.Projects;

                if (projectUpdateConfiguration.EnableProjectUpdateReminders)
                {
                    var projectUpdateKickOffDate = projectUpdateConfiguration.ProjectUpdateKickOffDate;
                    if (DateTime.Today == projectUpdateKickOffDate.GetValueOrDefault().Date)
                    {
                        var projectUpdateKickOffIntroContent =
                            projectUpdateConfiguration.ProjectUpdateKickOffIntroContent;
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                            projectUpdateKickOffIntroContent, tenant, true));
                    }
                }

                if (projectUpdateConfiguration.SendPeriodicReminders)
                {
                    if (TodayIsReminderDayForProjectUpdateConfiguration(projectUpdateConfiguration))
                    {
                        var projectUpdateReminderIntroContent =
                            projectUpdateConfiguration.ProjectUpdateReminderIntroContent;
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                            projectUpdateReminderIntroContent, tenant, false));
                        // note that we only send periodic reminders for projects whose updates haven't been submitted yet.
                    }
                }

                if (projectUpdateConfiguration.SendCloseOutNotification)
                {
                    var projectUpdateCloseOutDate = projectUpdateConfiguration.ProjectUpdateCloseOutDate;
                    if (DateTime.Today == projectUpdateCloseOutDate.GetValueOrDefault().Date)
                    {
                        var projectUpdateCloseOutIntroContent =
                            projectUpdateConfiguration.ProjectUpdateCloseOutIntroContent;
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                            projectUpdateCloseOutIntroContent, tenant, true));
                    }
                }

                DbContext.AllNotifications.AddRange(notifications);
                DbContext.SaveChangesOverridingTenantBounds();
            }
        }

        private static bool TodayIsReminderDayForProjectUpdateConfiguration(
            ProjectUpdateConfiguration projectUpdateConfiguration)
        {
            return (DateTime.Today - projectUpdateConfiguration.ProjectUpdateKickOffDate.GetValueOrDefault().Date)
                   .Days % projectUpdateConfiguration.ProjectUpdateReminderInterval == 0;
        }

        /// <summary>
        /// Sends a notification to all the primary contacts for the given tenant's projects.
        /// </summary>
        /// <param name="allProjects"></param>
        /// <param name="reminderSubject"></param>
        /// <param name="introContent"></param>
        /// <param name="tenant"></param>
        /// <param name="notifyOnAll"></param>
        private List<Notification> RunNotifications(IQueryable<Project> allProjects, string reminderSubject,
            string introContent, Tenant tenant, bool notifyOnAll)
        {
            // Constrain to tenant boundaries.
            var tenantProjects = allProjects.Where(x => x.TenantID == tenant.TenantID).ToList();
            var tenantAttribute = DbContext.AllTenantAttributes.Single(a => a.TenantID == tenant.TenantID);
            var toolDisplayName = tenantAttribute.ToolDisplayName;

            var projectsToNotifyOn = notifyOnAll
                ? tenantProjects.AsQueryable().GetUpdatableProjects()
                : tenantProjects.AsQueryable().GetUpdatableProjectsThatHaveNotBeenSubmitted();
            var primaryContactPeople = projectsToNotifyOn.GetPrimaryContactPeople();

            var groupBy = projectsToNotifyOn.ToList().GroupBy(x => x.GetPrimaryContact());



            var notifications = groupBy.SelectMany(x => SendProjectUpdateReminderMessage(x.Key, x.ToList(),
                reminderSubject, toolDisplayName, introContent, tenantAttribute.TenantSquareLogoFileResource,
                tenantAttribute.PrimaryContactPerson.Email)).ToList();

            var message =
                $"Reminder emails sent to {primaryContactPeople.Count} primary contacts for {projectsToNotifyOn.Count} projects requiring an update.";
            Logger.Info(message);

            return notifications;
        }

        public List<Notification> SendProjectUpdateReminderMessage(Person primaryContactPerson, List<Project> projects,
            string reminderSubject,
            string toolName, string introContent, FileResource logo, string contactSupportEmail)
        {
            if (projects.Count > 0)
            {
                var mailMessage = GenerateReminderForPerson(primaryContactPerson, projects, reminderSubject, toolName, introContent, logo, contactSupportEmail);

                var sendProjectUpdateReminderMessage = Notification.SendMessageAndLogNotification(mailMessage,
                    new List<string> {primaryContactPerson.Email},
                    new List<string>(),
                    new List<string>(),
                    new List<Person> {primaryContactPerson},
                    DateTime.Now, projects,
                    NotificationType.ProjectUpdateReminder);
                return sendProjectUpdateReminderMessage;
            }

            return new List<Notification>();
        }

        public MailMessage GenerateReminderForPerson(Person person, List<Project> projects, string reminderSubject,
            string toolName, string introContent, FileResource logo, string contactSupportEmail)
        {
            var projectListAsHtmlStrings =
                GenerateProjectListAsHtmlStrings(
                    projects);
            var projectsRequiringAnUpdateUrl =
                SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x =>
                    x.MyProjectsRequiringAnUpdate());

            var emailContent = GetEmailContentWithGeneratedSignature(toolName, introContent, projectsRequiringAnUpdateUrl, person.FullNameFirstLast, String.Join("<br/>", projectListAsHtmlStrings), contactSupportEmail);

            var htmlView = AlternateView.CreateAlternateViewFromString(emailContent, null, "text/html");
            htmlView.LinkedResources.Add(
                new LinkedResource(new MemoryStream(logo.FileResourceData), "img/jpeg") {ContentId = "tool-logo"});
            var mailMessage = new MailMessage {Subject = reminderSubject, IsBodyHtml = true};
            mailMessage.AlternateViews.Add(htmlView);

            return mailMessage;
        }

        public static string GetEmailContentWithGeneratedSignature(string toolName, string introContent,
            string projectsRequiringAnUpdateUrl, string fullNameFirstLast, string projectListConcatenated,
            string contactSupportEmail)
        {
            return GetEmailContent(toolName, introContent, projectsRequiringAnUpdateUrl, fullNameFirstLast,
                projectListConcatenated, GetReminderMessageSignature(toolName, "cid:tool-logo", contactSupportEmail));
        }

        public static string GetEmailContent(string toolName, string introContent,
            string projectsRequiringAnUpdateUrl, string fullNameFirstLast, string projectListConcatenated, string signature)
        {
            var body = String.Format(ReminderMessageTemplate,
                fullNameFirstLast,
                introContent,
                projectsRequiringAnUpdateUrl,
                projectListConcatenated);
            var emailContent = $"{body}<br/>{signature}";
            return emailContent;
        }

        private const string ReminderMessageTemplate = @"Hello, {0},<br/><br/>
{1}
<div style=""font-weight:bold"">Your <a href=""{2}"">projects that require an update</a> are:</div>
<div style=""margin-left: 15px"">
    {3}
</div>";

        public static List<string> GenerateProjectListAsHtmlStrings(
            List<Project> updatableProjectsThatHaveNotBeenSubmitted)
        {
            var projectsRemaining = updatableProjectsThatHaveNotBeenSubmitted;
            var projectListAsHtmlStrings = projectsRemaining.OrderBy(project => project.DisplayName).Select(project =>
            {
                var projectUrl =
                    SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(controller =>
                        controller.Detail(project));
                return $@"<div style=""font-size:smaller""><a href=""{projectUrl}"">{project.ProjectName}</a></div>";
            }).ToList();

            return projectListAsHtmlStrings;
        }

        public static string GetReminderMessageSignature(string toolName, string logoUrl, string contactSupportEmail) =>
            $@"
Thank you,<br />
{toolName} team<br/><br/><img src=""{logoUrl}"" width=""160"" />
<p>
P.S. - You received this email because you are listed as the Primary Contact for these projects. If you feel that you should not be the Primary Contact for one or more of these projects, please <a href=""mailto:{contactSupportEmail}"">contact support</a>.
</p>";
    }
}
