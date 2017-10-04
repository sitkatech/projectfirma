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
    public partial class NotificationProject
    {
        private static void AddProjectStewardToPeopleToNotify(List<Person> peopleToNotify, Project project)
        {
            var approveProjectsOrganization = project.GetCanApproveProjectsOrganization();
            if (approveProjectsOrganization != null)
            {
                peopleToNotify.AddRange(project.GetProjectStewards());
            }
        }

        private static void SendMessageAndLogNotificationForProjectUpdateTransition(ProjectUpdateBatch projectUpdateBatch,
            MailMessage mailMessage,
            List<string> emailsToSendTo,
            List<string> emailsToReplyTo,
            List<string> emailsToCc, NotificationType notificationType)
        {
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var primaryContactPerson = projectUpdateBatch.Project.GetPrimaryContact();

            var notificationPeople = new List<Person> { submitterPerson };
            if (primaryContactPerson != null && submitterPerson.PersonID != primaryContactPerson.PersonID)
            {
                notificationPeople.Add(primaryContactPerson);
            }

            Notification.SendMessageAndLogNotification(mailMessage,
                emailsToSendTo,
                emailsToReplyTo,
                emailsToCc,
                notificationPeople,
                DateTime.Now,
                new List<Project> {projectUpdateBatch.Project},
                notificationType);
        }

        public static void SendSubmittedMessage(List<Person> peopleToNotify, ProjectUpdateBatch projectUpdateBatch)
        {
            Check.Require(projectUpdateBatch.ProjectUpdateState == ProjectUpdateState.Submitted, "Need to be in Submitted state to send the Submitted email!");
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var submitterEmails = new List<string> { submitterPerson.Email };
            var primaryContactPerson = projectUpdateBatch.Project.GetPrimaryContact();
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                submitterEmails.Add(primaryContactPerson.Email);
            }

            var emailsToSendTo = peopleToNotify.Select(x => x.Email).ToList();
            var subject = $"The update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName} was submitted";
            var instructionsUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(projectUpdateBatch.Project));
            var message = $@"
<p>The update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName} on {
                    latestProjectUpdateHistorySubmitted.TransitionDate.ToStringDate()
                } was just submitted by {submitterPerson.FullNameFirstLastAndOrg}.</p>
<p>Please review and Approve or Return it at your earliest convenience.<br />
<a href=""{instructionsUrl}"">View this {FieldDefinition.Project.GetFieldDefinitionLabel()} update</a></p>
<p>You received this email because you are assigned to receive support notifications within the ProjectFirma tool.</p>
";

            var mailMessage1 = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var mailMessage = mailMessage1;

            SendMessageAndLogNotificationForProjectUpdateTransition(projectUpdateBatch, mailMessage, emailsToSendTo, submitterEmails, new List<string>(), NotificationType.ProjectUpdateSubmitted);
        }

        public static void SendApprovalMessage(List<Person> peopleToCc, ProjectUpdateBatch projectUpdateBatch)
        {
            Check.Require(projectUpdateBatch.ProjectUpdateState == ProjectUpdateState.Approved, "Need to be in Approved state to send the Approved email!");
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var emailsToSendTo = new List<string> { submitterPerson.Email };

            var personNames = submitterPerson.FullNameFirstLast;
            var primaryContactPerson = projectUpdateBatch.Project.GetPrimaryContact();
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
                personNames += $" and {primaryContactPerson.FullNameFirstLast}";
            }

            var approverPerson = projectUpdateBatch.LastUpdatePerson;
            var detailUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Detail(projectUpdateBatch.Project));
            var message = $@"
Dear {personNames},
<p>
    The update submitted for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName} on {
                    latestProjectUpdateHistorySubmitted.TransitionDate.ToStringDate()
                } was approved by {approverPerson.FullNameFirstLastAndOrg}.
</p>
<p>
    There is no action for you to take - this is simply a notification email. The updates for this {FieldDefinition.Project.GetFieldDefinitionLabel()} are now visible to the general public on this {FieldDefinition.Project.GetFieldDefinitionLabel()}'s detail page:
</p>
<p>
    <a href=""{detailUrl}"">View this {FieldDefinition.Project.GetFieldDefinitionLabel()}</a>
</p>
Thank you for keeping your {FieldDefinition.Project.GetFieldDefinitionLabel()} information and accomplishments up to date!<br />
{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}
";

            var subject = $"The update for {FieldDefinition.Project.GetFieldDefinitionLabel()} {projectUpdateBatch.Project.DisplayName} was approved";
            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };

            SendMessageAndLogNotificationForProjectUpdateTransition(projectUpdateBatch,
                mailMessage,
                emailsToSendTo,
                new List<string> {approverPerson.Email},
                peopleToCc.Select(x => x.Email).ToList(),
                NotificationType.ProjectUpdateApproved);
        }

        public static void SendReturnedMessage(List<Person> peopleToCc, ProjectUpdateBatch projectUpdateBatch)
        {
            Check.Require(projectUpdateBatch.ProjectUpdateState == ProjectUpdateState.Returned, "Need to be in Returned state to send the Returned email!");
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var emailsToSendTo = new List<string> { submitterPerson.Email };

            var personNames = submitterPerson.FullNameFirstLast;
            var primaryContactPerson = projectUpdateBatch.Project.GetPrimaryContact();
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
                personNames += $" and {primaryContactPerson.FullNameFirstLast}";
            }

            var returnerPerson = projectUpdateBatch.LatestProjectUpdateHistoryReturned.UpdatePerson;
            var instructionsUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(projectUpdateBatch.Project));
            var message = $@"
Dear {personNames},
<p>
    The update submitted for {FieldDefinition.Project.GetFieldDefinitionLabel()} {
                    projectUpdateBatch.Project.DisplayName
                } on {latestProjectUpdateHistorySubmitted.TransitionDate.ToStringDate()} has been returned by {
                    returnerPerson.FullNameFirstLastAndOrg
                }.
</p>
<p>
    <a href=""{instructionsUrl}"">View this {FieldDefinition.Project.GetFieldDefinitionLabel()} update</a>
</p>
<p>
    Please review this update and address the comments that {
                    returnerPerson.FirstName
                } left for you. If you have questions, please email: {returnerPerson.Email}
</p>
Thank you,<br />
{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}
";

            var subject =
                $"The update for project {projectUpdateBatch.Project.DisplayName} has been returned - please review and re-submit";
            var mailMessage1 = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var mailMessage = mailMessage1;

            SendMessageAndLogNotificationForProjectUpdateTransition(projectUpdateBatch,
                mailMessage,
                emailsToSendTo,
                new List<string> { returnerPerson.Email },
                peopleToCc.Select(x => x.Email).ToList(),
                NotificationType.ProjectUpdateReturned);
        }
    }
}