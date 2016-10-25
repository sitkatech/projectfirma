using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web.Hosting;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ReminderMessageType
    {
        protected abstract string GetReminderMessageTemplate();

        private const string ReminderMessageSignatureTemplate = @"
Thank you,<br />
Lake Tahoe EIP Project Tracker team<br/><br/><img src=""cid:eip-logo"" width=""160"" />
<p>
P.S. - You received this email because you are listed as the Primary Contact for these projects. If you feel that you should not be the Primary Contact for one or more of these projects, please <a href=""mailto:{0}"">contact support</a>.
</p>";

        public MailMessage GenerateReminderForPerson(Person primaryContactPerson)
        {
            var projectListAsHtmlStrings = GenerateProjectListAsHtmlStrings(primaryContactPerson.GetPrimaryContactProjects().GetUpdatableProjectsThatHaveNotBeenSubmitted());

            var reportingYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var projectsRequiringAnUpdateUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.MyProjectsRequiringAnUpdate(), LtInfoWebConfiguration.CanonicalHostName);
            var body = String.Format(GetReminderMessageTemplate(),
                primaryContactPerson.FullNameFirstLast,
                reportingYear,
                String.Join("\r\n", projectListAsHtmlStrings),
                projectsRequiringAnUpdateUrl);
            var signature = String.Format(ReminderMessageSignatureTemplate, GetAnnualReportingContactPerson().Email);

            var logo = new LinkedResource(Path.GetFullPath(HostingEnvironment.MapPath(@"~/Content/img/eip-logo-factsheet.png"))) { ContentId = "eip-logo" };
            var htmlView = AlternateView.CreateAlternateViewFromString(String.Format("{0}\r\n{1}", body, signature), null, "text/html");
            htmlView.LinkedResources.Add(logo);

            var mailMessage = new MailMessage { Subject = ReminderMessageTypeSubject, IsBodyHtml = true };
            mailMessage.AlternateViews.Add(htmlView);
            return mailMessage;
        }

        private static List<string> GenerateProjectListAsHtmlStrings(List<Project> updatableProjectsThatHaveNotBeenSubmitted)
        {
            var projectListAsHtmlStrings = new List<string>();
            var projectsRemaining = updatableProjectsThatHaveNotBeenSubmitted;
            foreach (var projectsGroupedByFocusArea in projectsRemaining.GroupBy(x => x.ActionPriority.Program.FocusArea).OrderBy(x => x.Key.FocusAreaNumber))
            {
                projectListAsHtmlStrings.Add(String.Format(@"<div style=""margin-top: 10px; font-weight:bold"">{0}</div>", projectsGroupedByFocusArea.Key.FocusAreaName));
                var projects = projectsGroupedByFocusArea.OrderBy(x => x.ProjectNumberString).Select(project =>
                {
                    var projectUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Summary(project.ProjectNumberString), LtInfoWebConfiguration.CanonicalHostName);
                    return String.Format(@"<div style=""font-size:smaller""><a href=""{0}"">{1} &mdash; {2}</a></div>", projectUrl, project.ProjectNumberString, project.ProjectName);
                });
                projectListAsHtmlStrings.AddRange(projects);
            }
            return projectListAsHtmlStrings;
        }

        public string GetBodyContent(Person person)
        {
            var stream = GenerateReminderForPerson(person).AlternateViews[0].ContentStream;
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public string SendReminderEmails()
        {
            var updatableProjectsThatHaveNotBeenSubmitted = HttpRequestStorage.DatabaseEntities.Projects.GetUpdatableProjectsThatHaveNotBeenSubmitted();
            var primaryContactPeople = updatableProjectsThatHaveNotBeenSubmitted.GetPrimaryContactPeople();
            // create a notification entry per primary contact reminder
            var notifications = primaryContactPeople.SelectMany(SendProjectUpdateReminderMessage).ToList();
            HttpRequestStorage.DatabaseEntities.Notifications.AddRange(notifications);
            HttpRequestStorage.DetectChangesAndSave();
            var message = String.Format("Reminder emails sent to {0} primary contacts for {1} projects requiring an update.", primaryContactPeople.Count, updatableProjectsThatHaveNotBeenSubmitted.Count);
            return message;
        }

        public static Person GetAnnualReportingContactPerson()
        {
            return HttpRequestStorage.DatabaseEntities.People.GetPerson(FirmaWebConfiguration.AnnualReportingContactPersonID);
        }

        public List<Notification> SendProjectUpdateReminderMessage(Person primaryContactPerson)
        {
            var updatableProjectsThatHaveNotBeenSubmitted = primaryContactPerson.GetPrimaryContactProjects().GetUpdatableProjectsThatHaveNotBeenSubmitted();

            var mailMessage = GenerateReminderForPerson(primaryContactPerson);

            return Notification.SendMessageAndLogNotification(mailMessage,
                new List<string> { primaryContactPerson.Email },
                new List<string> { GetAnnualReportingContactPerson().Email },
                new List<string>(),
                new List<Person> { primaryContactPerson },
                DateTime.Now,
                updatableProjectsThatHaveNotBeenSubmitted,
                NotificationType.ProjectUpdateReminder);
        }
    }

    public partial class ReminderMessageTypeKickoffReminder
    {
        protected override string GetReminderMessageTemplate()
        {
            return @"
Hello {0},
<p>
It's that time of year again &mdash; time to take a few minutes to update your EIP project information to include {1} accomplishments and expenditures. 
Please also update your project's location and upload any ""before,"" ""after,"" or ""during"" photos. Remember, photos are important for telling the story as well as great looking Project Fact Sheets!
</p>
<div style=""font-weight:bold"">Your projects that require an update are:</div>
<div style=""margin-left: 15px"">
    {2}
</div>
<p>
You can also see this <a href=""{3}"">full list in the EIP Project Tracker</a>.
</p>
<p>
While the absolute deadline for updates is <span style=""font-weight:bold"">January 15, 2016</span> we would love to start receiving project updates now. You will continue to receive these periodic reminder emails until you submit updates for all the projects listed above. 
</p>
<p>
As administrator of the EIP, TRPA greatly appreciates you taking time out of your busy day to provide the Region with this important information – this reporting exercise provides the transparency required by stakeholders and EIP funders, and lets us continue our good work to protect Lake Tahoe.
</p>";
        }
    }

    public partial class ReminderMessageTypeSecondReminder
    {
        protected override string GetReminderMessageTemplate()
        {
            return @"
Hello {0},
<p>
Please take a few minutes to update your EIP project information to include {1} accomplishments and expenditures. Please also update your project’s location and upload any ""before,"" ""after,"" or ""during"" photos.
</p>
<div style=""font-weight:bold"">Your projects that require an update are:</div>
<div style=""margin-left: 15px"">
    {2}
</div>
<p>
You can also see this <a href=""{3}"">full list in the EIP Project Tracker</a>.
</p>
<p>
The deadline for updates is <span style=""font-weight:bold"">January 15, 2016</span>. You will continue to receive these periodic reminder emails until you submit updates to all the projects listed above.
</p>
<p>
As administrator of the EIP, TRPA greatly appreciates you taking time out of your busy day to provide the Region with this important information – this reporting exercise provides the transparency required by stakeholders and EIP funders, and lets us continue our good work to protect Lake Tahoe.
</p>";
        }
    }

    public partial class ReminderMessageTypeThirdReminder
    {
        protected override string GetReminderMessageTemplate()
        {
            return @"
Hello {0},
<p>
Please update your EIP project information to include {1} accomplishments and expenditures. Please also update your project’s location and upload any ""before,"" ""after,"" or ""during"" photos.
</p>
<div style=""font-weight:bold"">Your projects that require an update are:</div>
<div style=""margin-left: 15px"">
    {2}
</div>
<p>
You can also see this <a href=""{3}"">full list in the EIP Project Tracker</a>.
</p>
<p>
The deadline for updates is a little more than a week away: <span style=""font-weight:bold; color:red"">January 15, 2016</span>. You will continue to receive these periodic reminder emails until you submit updates to all the projects listed above. 
</p>
<p>
As administrator of the EIP, TRPA greatly appreciates you taking time out of your busy day to provide the Region with this important information – this reporting exercise provides the transparency required by stakeholders and EIP funders, and lets us continue our good work to protect Lake Tahoe.
</p>";
        }
    }

    public partial class ReminderMessageTypeNearingDeadlineReminder
    {
        protected override string GetReminderMessageTemplate()
        {
            return @"
Hello {0},
<p>
PLEASE update your EIP project information to include {1} accomplishments and expenditures. <span style=""font-weight:bold; color:red"">Friday January 15 is the deadline for all updates</span>.  It is important that your projects are reflected accurately. Any information not provided by the deadline will not be included in the 2015 EIP summary presented at the annual Lake Tahoe Summit.
</p>
<div style=""font-weight:bold"">Your projects that require an update are:</div>
<div style=""margin-left: 15px"">
    {2}
</div>
<p>
You can also see this <a href=""{3}"">full list in the EIP Project Tracker</a>.
</p>
<p>
As administrator of the EIP, TRPA greatly appreciates you taking time out of your busy day to provide the Region with this important information – this reporting exercise provides the transparency required by stakeholders and EIP funders, and lets us continue our good work to protect Lake Tahoe.
</p>";
        }
    }

    public partial class ReminderMessageTypeAtDeadlineReminder
    {
        protected override string GetReminderMessageTemplate()
        {
            return @"
Hello {0},
<p>
PLEASE update your EIP project information to include {1} accomplishments and expenditures. <span style=""font-weight:bold; color:red"">The deadline is TODAY</span>. Any information not provided by the deadline will not be included in the 2015 EIP summary presented at the annual Lake Tahoe Summit.
</p>
<div style=""font-weight:bold"">Your projects that require an update are:</div>
<div style=""margin-left: 15px"">
    {2}
</div>
<p>
You can also see this <a href=""{3}"">full list in the EIP Project Tracker</a>.
</p>
<p>
As administrator of the EIP, TRPA greatly appreciates you taking time out of your busy day to provide the Region with this important information – this reporting exercise provides the transparency required by stakeholders and EIP funders, and lets us continue our good work to protect Lake Tahoe.
</p>";
        }
    }

    public partial class ReminderMessageTypePastDeadlineReminder
    {
        protected override string GetReminderMessageTemplate()
        {
            return @"
Hello {0},
<p>
PLEASE update your EIP project information to include {1} accomplishments and expenditures. <span style=""color:red"">While the deadline for providing this information has passed, we still need your updates.</span>
</p>
<div style=""font-weight:bold"">Your projects that require an update are:</div>
<div style=""margin-left: 15px"">
    {2}
</div>
<p>
You can also see this <a href=""{3}"">full list in the EIP Project Tracker</a>.
</p>
<p>
This reporting exercise provides the transparency required by stakeholders and EIP funders, and lets us continue our good work to protect Lake Tahoe. 
</p>";
        }
    }
}