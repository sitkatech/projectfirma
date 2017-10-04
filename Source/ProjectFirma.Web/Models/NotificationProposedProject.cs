using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class NotificationProposedProject
    {
        public static void SendSubmittedMessage(ProposedProject proposedProject)
        {
            var submitterPerson = proposedProject.ProposingPerson;
            var subject = $"A Project Proposal was submitted by {submitterPerson.FullNameFirstLastAndOrg}";
            var instructionsUrl = SitkaRoute<ProposedProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(proposedProject.ProposedProjectID));
            var message = $@"
<p>A proposal was submitted for a new Project, “{proposedProject.DisplayName}”.</p>
<p>The proposal was submitted on {proposedProject.ProposingDate.ToStringDate()} by {
                    submitterPerson.FullNameFirstLastAndOrg
                }.<br />
<p>Please review and Approve or Return it at your earliest convenience.</p>
<a href=""{instructionsUrl}"">View this proposal</a></p>
<p>You received this email because you are assigned to receive support notifications within the ProjectFirma tool.</p>
";
            var mailMessage = new MailMessage {Subject = subject, Body = message, IsBodyHtml = true};
            var emailsToSendTo = GetProjectStewardPeople(proposedProject).Select(x => x.Email).Distinct().ToList();
            var emailsToReplyTo = new List<string> { submitterPerson.Email };
            var primaryContactPerson = proposedProject.PrimaryContactPerson;
            if (primaryContactPerson != null && !string.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToReplyTo.Add(primaryContactPerson.Email);
            }
            var emailsToCc = new List<string>();
            SendMessageAndLogNotification(proposedProject, mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc, NotificationType.ProposedProjectSubmitted);
        }

        public static void SendApprovalMessage(ProposedProject proposedProject)
        {
            Check.Require(proposedProject.ProposedProjectState == ProposedProjectState.Approved, "Need to be in Approved state to send the Approved email!");
            var submitterPerson = proposedProject.ProposingPerson;
            var subject = $"Your Project Proposal \"{proposedProject.DisplayName.ToEllipsifiedString(80)}\" was approved!";
            var detailUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Detail(proposedProject.Project));
            var projectListUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Index());
            var message = $@"
<p>Dear {submitterPerson.FullNameFirstLastAndOrg},</p>
<p>The {MultiTenantHelpers.GetToolDisplayName()} Proposal submitted on {proposedProject.SubmissionDate.ToStringDate()} was approved by {proposedProject.ReviewedByPerson.FullNameFirstLastAndOrg}.</p>
<p>This project is now on the <a href=""{projectListUrl}"">{MultiTenantHelpers.GetToolDisplayName()} Project List</a> and is visible to the public via the project detail page.</p>
<p><a href=""{detailUrl}"">View this project</a></p>
<p>Thank you for using the {MultiTenantHelpers.GetToolDisplayName()}!</p>
<p>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}</p>
";
            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var emailsToSendTo = new List<string> { submitterPerson.Email };
            var emailsToReplyTo = new List<string> { proposedProject.ReviewedByPerson.Email };
            var primaryContactPerson = proposedProject.Project.GetPrimaryContact();
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
            }

            SendMessageAndLogNotification(proposedProject,
                mailMessage,
                emailsToSendTo,
                emailsToReplyTo,
                GetProjectStewardPeople(proposedProject).Select(x => x.Email).ToList(),
                NotificationType.ProjectUpdateApproved);
        }

        public static void SendReturnedMessage(ProposedProject proposedProject)
        {
            var submitterPerson = proposedProject.ProposingPerson;
            var subject = $@"Your Project Proposal ""{proposedProject.DisplayName.ToEllipsifiedString(80)}"" was not approved";
            var instructionsUrl = SitkaRoute<ProposedProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(proposedProject.ProposedProjectID));
            var message = $@"
<p>Dear {submitterPerson.FullNameFirstLast},</p>
<p>The {MultiTenantHelpers.GetToolDisplayName()} Proposal submitted on {proposedProject.SubmissionDate.ToStringDate()} has been returned for further review.</p>
<p>The proposal was returned by {proposedProject.ReviewedByPerson.FullNameFirstLastAndOrg}. {proposedProject.ReviewedByPerson.FirstName} will contact you for additional information before this proposal can move forward.</p>
<a href=""{instructionsUrl}"">View this project</a></p>
<p>Thank you for using the {MultiTenantHelpers.GetToolDisplayName()}</p>
<p>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}</p>
";

            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var emailsToSendTo = new List<string> { submitterPerson.Email };
            var primaryContactPerson = proposedProject.PrimaryContactPerson;
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
            }
            var emailsToReplyTo = new List<string> { proposedProject.ReviewedByPerson.Email };
            var emailsToCc = GetProjectStewardPeople(proposedProject).Select(x => x.Email).ToList();
            SendMessageAndLogNotification(proposedProject, mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc, NotificationType.ProposedProjectReturned);
        }

        private static List<Notification> SendMessageAndLogNotification(ProposedProject proposedProject,
            MailMessage mailMessage,
            List<string> emailsToSendTo,
            List<string> emailsToReplyTo,
            List<string> emailsToCc,
            NotificationType notificationType)
        {
            var submitterPerson = proposedProject.ProposingPerson;
            var primaryContactPerson = proposedProject.PrimaryContactPerson;

            var notificationPeople = new List<Person> { submitterPerson };
            if (primaryContactPerson != null && submitterPerson.PersonID != primaryContactPerson.PersonID)
            {
                notificationPeople.Add(primaryContactPerson);
            }

            Notification.SendMessage(mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc);
            var notifications = new List<Notification>();
            foreach (var notificationPerson in notificationPeople)
            {
                var notification = new Notification(notificationType, notificationPerson, DateTime.Now);
                notification.NotificationProposedProjects = new List<ProposedProject> { proposedProject }.Select(p => new NotificationProposedProject(notification, p)).ToList();
                notifications.Add(notification);
            }
            return notifications;
        }

        private static List<Person> GetProjectStewardPeople(ProposedProject proposedProject)
        {
            return HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications().Union(proposedProject.GetProjectStewards()).Distinct().OrderBy(ht => ht.FullNameLastFirst).ToList();
        }
    }
}