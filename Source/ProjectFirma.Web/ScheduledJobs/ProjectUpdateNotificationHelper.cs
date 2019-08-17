using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ScheduledJobs
{
    public class ProjectUpdateNotificationHelper
    {
        public string ToolName { get; set; }
        public string IntroContent { get; set; }
        public FileResource ToolLogo { get; set; }
        public string ReminderEmailSubject { get; set; }
        public string ContactSupportEmail { get; set; }

        private const string ReminderMessageTemplate = @"Hello {0},<br/><br/>
{1}
<div style=""font-weight:bold"">Your <a href=""{2}"">projects that require an update</a> are:</div>
<div style=""margin-left: 15px"">
    {3}
</div>";


        public ProjectUpdateNotificationHelper(string contactSupportEmail, string introContent, string reminderSubject,
            FileResource toolLogo, string toolDisplayName)
        {
            ContactSupportEmail = contactSupportEmail;
            IntroContent = introContent;
            ReminderEmailSubject = reminderSubject;
            ToolLogo = toolLogo;
            ToolName = toolDisplayName;
        }

        public List<Notification> SendProjectUpdateReminderMessage(
            IGrouping<Person, Project> primaryContactProjectsGrouping)
        {
            var primaryContactPerson = primaryContactProjectsGrouping.Key;
            var projects = primaryContactProjectsGrouping.ToList();

            if (projects.Count <= 0) return new List<Notification>();

            var mailMessage = GenerateReminderForPerson(primaryContactPerson, projects);
            var sendProjectUpdateReminderMessage = NotificationModelExtensions.SendMessageAndLogNotification(mailMessage,
                new List<string> {primaryContactPerson.Email},
                new List<string>(),
                new List<string>(),
                new List<Person> {primaryContactPerson},
                DateTime.Now, projects,
                NotificationType.ProjectUpdateReminder);
            return sendProjectUpdateReminderMessage;
        }

        private MailMessage GenerateReminderForPerson(Person person, List<Project> projects)
        {
            var projectListAsHtmlStrings =
                GenerateProjectListAsHtmlStrings(
                    projects);
            var projectsRequiringAnUpdateUrl =
                SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x =>
                    x.MyProjectsRequiringAnUpdate());

            var emailContent = GetEmailContentWithGeneratedSignature(projectsRequiringAnUpdateUrl,
                person.GetFullNameFirstLast(), String.Join("<br/>", projectListAsHtmlStrings));

            var htmlView = AlternateView.CreateAlternateViewFromString(emailContent, null, "text/html");
            htmlView.LinkedResources.Add(
                new LinkedResource(new MemoryStream(ToolLogo.FileResourceData), "img/jpeg") {ContentId = "tool-logo"});
            var mailMessage = new MailMessage {Subject = ReminderEmailSubject, IsBodyHtml = true};
            mailMessage.AlternateViews.Add(htmlView);

            return mailMessage;
        }

        private string GetEmailContent(
            string projectsRequiringAnUpdateUrl, string fullNameFirstLast, string projectListConcatenated,
            string signature)
        {
            var body = string.Format(ReminderMessageTemplate,
                fullNameFirstLast,
                IntroContent,
                projectsRequiringAnUpdateUrl,
                projectListConcatenated);
            var emailContent = $"{body}<br/>{signature}";
            return emailContent;
        }

        private string GetEmailContentWithGeneratedSignature(
            string projectsRequiringAnUpdateUrl, string fullNameFirstLast, string projectListConcatenated
        )
        {
            return GetEmailContent(projectsRequiringAnUpdateUrl, fullNameFirstLast,
                projectListConcatenated, GetReminderMessageSignature(false));
        }

        public string GetEmailContentPreview()
        {
            var signature = GetReminderMessageSignature(true);

            return GetEmailContent(
                SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate()),
                $"<em>Organization {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}</em>",
                "<p><em>A list of the recipient’s projects that require an update and do not have an update submitted yet will appear here.&nbsp;</em></p>",
                signature
            );
        }

        private static IEnumerable<string> GenerateProjectListAsHtmlStrings(
            IReadOnlyCollection<Project> projects)
        {
            var projectsRemaining = projects;
            var projectListAsHtmlStrings = projectsRemaining.OrderBy(project => project.GetDisplayName()).Select(project =>
            {
                var projectUrl =
                    SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(controller =>
                        controller.Detail(project));
                return $@"<div style=""font-size:smaller""><a href=""{projectUrl}"">{project.ProjectName}</a></div>";
            }).ToList();

            return projectListAsHtmlStrings;
        }

        private string GetReminderMessageSignature(bool isPreview)
        {
            var logoUrl = isPreview ? ToolLogo.GetFileResourceUrl() : "cid:tool-logo";

            return $@"
Thank you,<br />
{ToolName} team<br/><br/><img src=""{logoUrl}"" width=""160"" />
<p>
P.S. - You received this email because you are listed as the {FieldDefinitionEnum.ProjectPrimaryContact.ToType().GetFieldDefinitionLabel()} for these projects. If you feel that you should not be the {FieldDefinitionEnum.ProjectPrimaryContact.ToType().GetFieldDefinitionLabel()} for one or more of these projects, please <a href=""mailto:{ContactSupportEmail}"">contact support</a>.
</p>";
        }
    }
}