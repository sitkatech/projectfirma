using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web.Hosting;
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

            var projectUpdateConfigurations = HttpRequestStorage.DatabaseEntities.AllProjectUpdateConfigurations;

            var allProjects = HttpRequestStorage.DatabaseEntities.AllProjects;

            foreach (var projectUpdateConfiguration in projectUpdateConfigurations)
            {
                if (projectUpdateConfiguration.EnableProjectUpdateReminders)
                {
                    var projectUpdateKickOffDate = projectUpdateConfiguration.ProjectUpdateKickOffDate;
                    if (DateTime.Today == projectUpdateKickOffDate.GetValueOrDefault().Date)
                    {
                        var projectUpdateKickOffIntroContent = projectUpdateConfiguration.ProjectUpdateKickOffIntroContent;
                        
                        var updatableProjectsThatHaveNotBeenSubmitted = allProjects.GetUpdatableProjectsThatHaveNotBeenSubmitted();
                        var primaryContactPeople = updatableProjectsThatHaveNotBeenSubmitted.GetPrimaryContactPeople();
                        // create a notification entry per primary contact reminder
                        string reminderSubject = string.Empty; // TODO
                        var notifications = primaryContactPeople.SelectMany(primaryContactPerson => SendProjectUpdateReminderMessage(primaryContactPerson, reminderSubject)).ToList();
                        HttpRequestStorage.DatabaseEntities.AllNotifications.AddRange(notifications);
                        //todo: ???
                        //HttpRequestStorage.DetectChangesAndSave();
                        var message = $"Reminder emails sent to {primaryContactPeople.Count} primary contacts for {updatableProjectsThatHaveNotBeenSubmitted.Count} projects requiring an update.";

                        Logger.Info(message);
                    }
                }

                if (projectUpdateConfiguration.SendPeriodicReminders)
                {
                    // todo: periodic notifications
                }

                if (projectUpdateConfiguration.SendCloseOutNotification)
                {
                    // todo: close-out notification
                }
            }

            //var resultMessage = ReminderMessageType.SendReminderEmails();
            //Logger.Info(resultMessage);
        }

        // todo: below here, probably refactor into a helper class for better delegation

        public static Person GetAnnualReportingContactPerson()
        {
            // todo: probably needs to be tenant-specific
            return HttpRequestStorage.DatabaseEntities.People.GetPerson(FirmaWebConfiguration.AnnualReportingContactPersonID);
        }

        public List<Notification> SendProjectUpdateReminderMessage(Person primaryContactPerson, string reminderSubject)
        {
            // todo: I'm not happy with pCP.GPCP(pCP) and I'm not happy with all the AsQueryable()
            var updatableProjectsThatHaveNotBeenSubmitted = primaryContactPerson.GetPrimaryContactProjects(primaryContactPerson).AsQueryable().GetUpdatableProjectsThatHaveNotBeenSubmitted();

            var mailMessage = GenerateReminderForPerson(primaryContactPerson, reminderSubject);

            List<Notification> sendProjectUpdateReminderMessage = new List<Notification>() ;
            //sendProjectUpdateReminderMessage = NotificationProject.SendMessageAndLogNotification(mailMessage,
            //    new List<string> { primaryContactPerson.Email },
            //    new List<string> { GetAnnualReportingContactPerson().Email },
            //    new List<string>(),
            //    new List<Person> { primaryContactPerson },
            //    DateTime.Now,
            //    updatableProjectsThatHaveNotBeenSubmitted,
            //    NotificationType.ProjectUpdateReminder);
            return sendProjectUpdateReminderMessage;
        }

        public MailMessage GenerateReminderForPerson(Person primaryContactPerson, string reminderSubject)
        {
            var projectListAsHtmlStrings = GenerateProjectListAsHtmlStrings(primaryContactPerson.GetPrimaryContactProjects(primaryContactPerson).AsQueryable().GetUpdatableProjectsThatHaveNotBeenSubmitted());

            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var projectsRequiringAnUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.MyProjectsRequiringAnUpdate());
            // todo: ??
            //var projectFeatureUrl = SitkaRoute<ProjectCreateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(null));

            // todo: build body better 
            var body = string.Empty;
            //var body = String.Format(GetReminderMessageTemplate(),
            //    primaryContactPerson.FullNameFirstLast,
            //    reportingYear,
            //    String.Join("\r\n", projectListAsHtmlStrings),
            //    projectsRequiringAnUpdateUrl,
            //    //projectFeatureUrl,
            //    string.Empty,
            //    reportingYear + 1);
            var signature = String.Format(ReminderMessageSignatureTemplate, GetAnnualReportingContactPerson().Email);

            // todo ?? 
            LinkedResource logo = null;
            //logo = new LinkedResource(Path.GetFullPath(HostingEnvironment.MapPath(@"~/Content/img/eip-logo-factsheet.png"))) { ContentId = "eip-logo" };
            var htmlView = AlternateView.CreateAlternateViewFromString($"{body}\r\n{signature}", null, "text/html");
            htmlView.LinkedResources.Add(logo);

            var mailMessage = new MailMessage { Subject = reminderSubject, IsBodyHtml = true };
            mailMessage.AlternateViews.Add(htmlView);
            return mailMessage;
        }

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
Lake Tahoe EIP Project Tracker team<br/><br/><img src=""cid:eip-logo"" width=""160"" />
<p>
P.S. - You received this email because you are listed as the Primary Contact for these projects. If you feel that you should not be the Primary Contact for one or more of these projects, please <a href=""mailto:{0}"">contact support</a>.
</p>";
    }
}
