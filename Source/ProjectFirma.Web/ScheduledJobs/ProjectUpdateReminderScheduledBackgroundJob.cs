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
        //public readonly ReminderMessageType ReminderMessageType;

        //protected ProjectUpdateReminderScheduledBackgroundJobBase(ReminderMessageType reminderMessageType)
        //    : base($"Project Update - {reminderMessageType.ReminderMessageTypeDisplayName}")
        //{
        //    ReminderMessageType = reminderMessageType;
        //}


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
                HttpRequestStorage.SetTenantForHangfire(tenant); // we're intentionally overriding the HRS tenant here because Hangfire doesn't live in tenant-world
                // now that HRS.Tenant is set to the one we want, this is just that tenant's projects.
                var projects = DbContext.Projects;

                if (projectUpdateConfiguration.EnableProjectUpdateReminders)
                {
                    var projectUpdateKickOffDate = projectUpdateConfiguration.ProjectUpdateKickOffDate;
                    if (DateTime.Today == projectUpdateKickOffDate.GetValueOrDefault().Date)
                    {
                        var projectUpdateKickOffIntroContent = projectUpdateConfiguration.ProjectUpdateKickOffIntroContent;
                        notifications.AddRange(RunNotifications(projects, reminderSubject,
                            projectUpdateKickOffIntroContent, tenant));
                    }
                }

                if (projectUpdateConfiguration.SendPeriodicReminders)
                {
                    if (TodayIsReminderDayForProjectUpdateConfiguration(projectUpdateConfiguration))
                    {
                        var projectUpdateReminderIntroContent = projectUpdateConfiguration.ProjectUpdateReminderIntroContent;
                        notifications.AddRange(RunNotifications(projects, reminderSubject, projectUpdateReminderIntroContent, tenant));
                    }
                }

                if (projectUpdateConfiguration.SendCloseOutNotification)
                {
                    var projectUpdateCloseOutDate = projectUpdateConfiguration.ProjectUpdateCloseOutDate;
                    if (DateTime.Today == projectUpdateCloseOutDate.GetValueOrDefault().Date)
                    {
                        var projectUpdateCloseOutIntroContent = projectUpdateConfiguration.ProjectUpdateCloseOutIntroContent;
                        notifications.AddRange(RunNotifications(projects, reminderSubject, projectUpdateCloseOutIntroContent, tenant));
                    }
                }

                DbContext.AllNotifications.AddRange(notifications);
                DbContext.SaveChangesOverridingTenantBounds();
            }
        }

        private static bool TodayIsReminderDayForProjectUpdateConfiguration(ProjectUpdateConfiguration projectUpdateConfiguration)
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
        private List<Notification> RunNotifications(IQueryable<Project> allProjects, string reminderSubject, string introContent, Tenant tenant)
        {
            // Constrain to tenant boundaries.
            var tenantProjects = allProjects.Where(x => x.TenantID == tenant.TenantID).ToList();
            var tenantAttribute = DbContext.AllTenantAttributes.Single(a => a.TenantID == tenant.TenantID);
            var toolDisplayName = tenantAttribute.ToolDisplayName;

            var updatableProjectsThatHaveNotBeenSubmitted =
                tenantProjects.AsQueryable().GetUpdatableProjectsThatHaveNotBeenSubmitted();
            var primaryContactPeople = updatableProjectsThatHaveNotBeenSubmitted.GetPrimaryContactPeople();

            // create a notification entry per primary contact reminder
            var notifications = primaryContactPeople.SelectMany(primaryContactPerson =>
                SendProjectUpdateReminderMessage(primaryContactPerson, reminderSubject, toolDisplayName,
                    introContent, tenantAttribute.TenantSquareLogoFileResource)).ToList();

            var message =
                $"Reminder emails sent to {primaryContactPeople.Count} primary contacts for {updatableProjectsThatHaveNotBeenSubmitted.Count} projects requiring an update.";
            Logger.Info(message);

            return notifications;
        }

        public List<Notification> SendProjectUpdateReminderMessage(Person primaryContactPerson, string reminderSubject,
            string toolName, string introContent, FileResource logo)
        {
            var updatableProjectsThatHaveNotBeenSubmitted = GetUpdatableProjectsThatHaveNotBeenSubmittedForPerson(primaryContactPerson);
            if (updatableProjectsThatHaveNotBeenSubmitted.Count > 0)
            {

                var mailMessage = GenerateReminderForPerson(primaryContactPerson, reminderSubject, toolName, introContent, logo);

                var sendProjectUpdateReminderMessage = Notification.SendMessageAndLogNotification(mailMessage,
                    new List<string> { primaryContactPerson.Email },
                    new List<string>(),
                    new List<string>(),
                    new List<Person> { primaryContactPerson },
                    DateTime.Now, updatableProjectsThatHaveNotBeenSubmitted,
                    NotificationType.ProjectUpdateReminder);
                return sendProjectUpdateReminderMessage;
            }
            else return new List<Notification>();
        }

        private List<Project> GetUpdatableProjectsThatHaveNotBeenSubmittedForPerson(Person primaryContactPerson)
        {
            return primaryContactPerson
                .GetPrimaryContactProjects(primaryContactPerson).AsQueryable()
                .GetUpdatableProjectsThatHaveNotBeenSubmitted();
        }

        public MailMessage GenerateReminderForPerson(Person primaryContactPerson, string reminderSubject,
            string toolName, string introContent, FileResource logo)
        {
            var projectListAsHtmlStrings = GenerateProjectListAsHtmlStrings(GetUpdatableProjectsThatHaveNotBeenSubmittedForPerson(primaryContactPerson));
            var projectsRequiringAnUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.MyProjectsRequiringAnUpdate());
            
            var body = String.Format(ReminderMessageTemplate,
                primaryContactPerson.FullNameFirstLast,
                introContent,
                projectsRequiringAnUpdateUrl,
                String.Join("\r\n", projectListAsHtmlStrings));
            var signature = String.Format(ReminderMessageSignatureTemplate, toolName, "");

            var htmlView = AlternateView.CreateAlternateViewFromString($"{body}\r\n{signature}", null, "text/html");
            htmlView.LinkedResources.Add(new LinkedResource(new MemoryStream(logo.FileResourceData),"img/jpeg"){ContentId = "tool-logo"});
            var mailMessage = new MailMessage { Subject = reminderSubject, IsBodyHtml = true };
            mailMessage.AlternateViews.Add(htmlView);

            return mailMessage;
        }

        private const string ReminderMessageTemplate = @"Hello, {0},
{1}
<div style=""font-weight:bold"">Your <a href=""{2}"">projects that require an update</a> are:</div>
<div style=""margin-left: 15px"">
    {3}
</div><br />";

        private static List<string> GenerateProjectListAsHtmlStrings(List<Project> updatableProjectsThatHaveNotBeenSubmitted)
        {
            var projectsRemaining = updatableProjectsThatHaveNotBeenSubmitted;
            var projectListAsHtmlStrings = projectsRemaining.OrderBy(project=>project.DisplayName).Select(project =>
                {
                    var projectUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(controller => controller.Detail(project));
                    return $@"<div style=""font-size:smaller""><a href=""{projectUrl}"">{project.ProjectName}</a></div>";
                }).ToList();

            return projectListAsHtmlStrings;
        }

        private const string ReminderMessageSignatureTemplate = @"
Thank you,<br />
{0} team<br/><br/><img src=""cid:eip-logo"" width=""160"" />
<p>
P.S. - You received this email because you are listed as the Primary Contact for these projects. If you feel that you should not be the Primary Contact for one or more of these projects, please <a href=""mailto:{1}"">contact support</a>.
</p>";
    }
}
