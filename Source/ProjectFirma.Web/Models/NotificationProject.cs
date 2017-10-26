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


        // Methods for Projects, carried over from NotificationProposedProject
        public static void SendSubmittedMessage(Project project)
        {
            var submitterPerson = project.ProposingPerson;
            var subject = $"A Project Proposal was submitted by {submitterPerson.FullNameFirstLastAndOrg}";
            var instructionsUrl = SitkaRoute<ProposedProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(project.ProjectID));
            var message = $@"
<p>A proposal was submitted for a new Project, “{project.DisplayName}”.</p>
<p>The proposal was submitted on {project.ProposingDate.ToStringDate()} by {
                    submitterPerson.FullNameFirstLastAndOrg
                }.<br />
<p>Please review and Approve or Return it at your earliest convenience.</p>
<a href=""{instructionsUrl}"">View this proposal</a></p>
<p>You received this email because you are assigned to receive support notifications within the ProjectFirma tool.</p>
";
            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var emailsToSendTo = GetProjectStewardPeople(project).Select(x => x.Email).Distinct().ToList();
            var emailsToReplyTo = new List<string> { submitterPerson.Email };
            var primaryContactPerson = project.PrimaryContactPerson;
            if (primaryContactPerson != null && !string.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToReplyTo.Add(primaryContactPerson.Email);
            }
            var emailsToCc = new List<string>();
            SendMessageAndLogNotification(project, mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc, NotificationType.ProjectSubmitted);
        }

        public static void SendApprovalMessage(Project project)
        {
            Check.Require(project.ProposedProjectState == ProposedProjectState.Approved, "Need to be in Approved state to send the Approved email!");
            var submitterPerson = project.ProposingPerson;
            var subject = $"Your Project Proposal \"{project.DisplayName.ToEllipsifiedString(80)}\" was approved!";
            var detailUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Detail(project.ProjectID));
            var projectListUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Index());
            var message = $@"
<p>Dear {submitterPerson.FullNameFirstLastAndOrg},</p>
<p>The {MultiTenantHelpers.GetToolDisplayName()} Proposal submitted on {project.SubmissionDate.ToStringDate()} was approved by {project.ReviewedByPerson.FullNameFirstLastAndOrg}.</p>
<p>This project is now on the <a href=""{projectListUrl}"">{MultiTenantHelpers.GetToolDisplayName()} Project List</a> and is visible to the public via the project detail page.</p>
<p><a href=""{detailUrl}"">View this project</a></p>
<p>Thank you for using the {MultiTenantHelpers.GetToolDisplayName()}!</p>
<p>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}</p>
";
            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var emailsToSendTo = new List<string> { submitterPerson.Email };
            var emailsToReplyTo = new List<string> { project.ReviewedByPerson.Email };
            var primaryContactPerson = project.GetPrimaryContact();
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
            }

            SendMessageAndLogNotification(project,
                mailMessage,
                emailsToSendTo,
                emailsToReplyTo,
                GetProjectStewardPeople(project).Select(x => x.Email).ToList(),
                NotificationType.ProjectUpdateApproved);
        }

        public static void SendReturnedMessage(Project project)
        {
            var submitterPerson = project.ProposingPerson;
            var subject = $@"Your Project Proposal ""{project.DisplayName.ToEllipsifiedString(80)}"" was not approved";
            var instructionsUrl = SitkaRoute<ProposedProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(project.ProjectID));
            var message = $@"
<p>Dear {submitterPerson.FullNameFirstLast},</p>
<p>The {MultiTenantHelpers.GetToolDisplayName()} Proposal submitted on {project.SubmissionDate.ToStringDate()} has been returned for further review.</p>
<p>The proposal was returned by {project.ReviewedByPerson.FullNameFirstLastAndOrg}. {project.ReviewedByPerson.FirstName} will contact you for additional information before this proposal can move forward.</p>
<a href=""{instructionsUrl}"">View this project</a></p>
<p>Thank you for using the {MultiTenantHelpers.GetToolDisplayName()}</p>
<p>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}</p>
";

            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            var emailsToSendTo = new List<string> { submitterPerson.Email };
            var primaryContactPerson = project.PrimaryContactPerson;
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
            }
            var emailsToReplyTo = new List<string> { project.ReviewedByPerson.Email };
            var emailsToCc = GetProjectStewardPeople(project).Select(x => x.Email).ToList();
            SendMessageAndLogNotification(project, mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc, NotificationType.ProjectReturned);
        }

        private static List<Notification> SendMessageAndLogNotification(Project project,
            MailMessage mailMessage,
            List<string> emailsToSendTo,
            List<string> emailsToReplyTo,
            List<string> emailsToCc,
            NotificationType notificationType)
        {
            var submitterPerson = project.ProposingPerson;
            var primaryContactPerson = project.PrimaryContactPerson;

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
                notification.NotificationProjects = new List<Project> { project }.Select(p => new NotificationProject(notification, p)).ToList();
                notifications.Add(notification);
            }
            return notifications;
        }

        private static List<Person> GetProjectStewardPeople(Project project)
        {
            return HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications().Union(project.GetProjectStewards()).Distinct().OrderBy(ht => ht.FullNameLastFirst).ToList();
        }
    }
}