/*-----------------------------------------------------------------------
<copyright file="Notification.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Email;

namespace ProjectFirma.Web.Models
{
    public partial class Notification
    {
        public static string FirmaSignature = string.Format("{0} team<br/><br/><img src=\"http://clackamaspartnership.org/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png\" width=\"600\" />", MultiTenantHelpers.GetTenantDisplayName());

        public HtmlString GetFullDescriptionFromUserPerspective()
        {
            var displayNameAsUrl = NotificationProjects.Any() ? NotificationProjects.First().Project.DisplayNameAsUrl : new HtmlString("<Deleted Project>");
            switch (NotificationType.ToEnum)
            {
                case NotificationTypeEnum.ProjectUpdateReminder:
                    return new HtmlString("Project Update reminder sent.");
                case NotificationTypeEnum.ProjectUpdateSubmitted:
                    return new HtmlString(String.Format("The update for project {0} was submitted", displayNameAsUrl));
                case NotificationTypeEnum.ProjectUpdateReturned:
                    return new HtmlString(String.Format("The update for project {0} has been returned", displayNameAsUrl));
                case NotificationTypeEnum.ProjectUpdateApproved:
                    return new HtmlString(String.Format("The update for project {0} was approved", displayNameAsUrl));
                case NotificationTypeEnum.Custom:
                    return new HtmlString("A customized notification was sent.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetFullDescriptionFromProjectPerspective()
        {
            switch (NotificationType.ToEnum)
            {
                case NotificationTypeEnum.ProjectUpdateReminder:
                    return "Project Update reminder sent.";
                case NotificationTypeEnum.ProjectUpdateSubmitted:
                    return "Project update was submitted";
                case NotificationTypeEnum.ProjectUpdateReturned:
                    return "Project update has been returned";
                case NotificationTypeEnum.ProjectUpdateApproved:
                    return "Project update was approved";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static List<Notification> SendMessageAndLogNotification(MailMessage mailMessage, IEnumerable<string> emailsToSendTo, IEnumerable<string> emailsToReplyTo, IEnumerable<string> emailsToCc, List<Person> notificationPeople, DateTime notificationDate, List<Project> notificationProjects, NotificationType notificationType)
        {
            SendMessage(mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc);
            var notifications = new List<Notification>();
            foreach (var notificationPerson in notificationPeople)
            {
                var notification = new Notification(notificationType, notificationPerson, notificationDate);
                notification.NotificationProjects = notificationProjects.Select(p => new NotificationProject(notification, p)).ToList();
                notifications.Add(notification);
            }
            return notifications;
        }

        public static void SendMessage(MailMessage mailMessage, IEnumerable<string> emailsToSendTo, IEnumerable<string> emailsToReplyTo, IEnumerable<string> emailsToCc)
        {
            mailMessage.From = DoNotReplyMailAddress();
            foreach (var email in emailsToSendTo)
            {
                mailMessage.To.Add(email);
            }
            foreach (var email in emailsToReplyTo)
            {
                mailMessage.ReplyToList.Add(email);
            }
            foreach (var emailToCc in emailsToCc)
            {
                mailMessage.CC.Add(emailToCc);
            }
            mailMessage.Bcc.Add(FirmaWebConfiguration.SitkaSupportEmail);
            SitkaSmtpClient.Send(mailMessage);
        }

        public static MailAddress DoNotReplyMailAddress()
        {
            return new MailAddress(Common.FirmaWebConfiguration.DoNotReplyEmail, "Sitka as Administrator of ProjectFirma");
        }

        private static MailMessage GenerateProjectUpdateReturnedMessage(ProjectUpdateBatch projectUpdateBatch,
            string personNames,
            ProjectUpdateHistory latestProjectUpdateHistorySubmitted,
            Person returnerPerson)
        {
            var instructionsUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(projectUpdateBatch.Project));
            var message = string.Format(@"
Dear {0},
<p>
    The update submitted for project {1} on {2} has been returned by {3}.
</p>
<p>
    <a href=""{4}"">View this project update</a>
</p>
<p>
    Please review this update and address the comments that {5} left for you. If you have questions, please email: {6}
</p>
Thank you,<br />
{7}
", personNames, projectUpdateBatch.Project.DisplayName, latestProjectUpdateHistorySubmitted.TransitionDate.ToStringDate(), returnerPerson.FullNameFirstLastAndOrg, instructionsUrl,
                returnerPerson.FirstName,
                returnerPerson.Email,
                FirmaSignature);

            var subject = string.Format("The update for project {0} has been returned - please review and re-submit", projectUpdateBatch.Project.DisplayName);
            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true};
            return mailMessage;
        }

        private static void SendMessageAndLogNotificationForProjectUpdateTransition(ProjectUpdateBatch projectUpdateBatch,
            MailMessage mailMessage,
            List<string> emailsToSendTo,
            List<string> emailsToReplyTo,
            List<string> emailsToCc, NotificationType notificationType)
        {
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var primaryContactPerson = projectUpdateBatch.Project.PrimaryContactPerson;

            var notificationPeople = new List<Person> { submitterPerson };
            if (primaryContactPerson != null && submitterPerson.PersonID != primaryContactPerson.PersonID)
            {
                notificationPeople.Add(primaryContactPerson);
            }

            SendMessageAndLogNotification(mailMessage,
                emailsToSendTo,
                emailsToReplyTo,
                emailsToCc,
                notificationPeople,
                DateTime.Now,
                new List<Project> {projectUpdateBatch.Project},
                notificationType);
        }

        private static MailMessage GenerateProjectUpdateSubmittedMessage(ProjectUpdateBatch projectUpdateBatch, ProjectUpdateHistory latestProjectUpdateHistorySubmitted, Person submitterPerson)
        {
            var subject = String.Format("The update for project {0} was submitted", projectUpdateBatch.Project.DisplayName);
            var instructionsUrl = SitkaRoute<ProjectUpdateController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(projectUpdateBatch.Project));
            var message = String.Format(@"
<p>The update for project {0} on {1} was just submitted by {2}.</p>
<p>Please review and Approve or Return it at your earliest convenience.<br />
<a href=""{3}"">View this project update</a></p>
<p>You received this email because you are assigned to receive support notifications within the ProjectFirma tool.</p>
", projectUpdateBatch.Project.DisplayName, latestProjectUpdateHistorySubmitted.TransitionDate.ToStringDate(), submitterPerson.FullNameFirstLastAndOrg, instructionsUrl);

            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true};
            return mailMessage;
        }

        public static void SendSubmittedMessage(List<Person> peopleToNotify, ProjectUpdateBatch projectUpdateBatch)
        {
            Check.Require(projectUpdateBatch.ProjectUpdateState == ProjectUpdateState.Submitted, "Need to be in Submitted state to send the Submitted email!");
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var submitterEmails = new List<string> { submitterPerson.Email };
            var primaryContactPerson = projectUpdateBatch.Project.PrimaryContactPerson;
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                submitterEmails.Add(primaryContactPerson.Email);
            }

            var emailsToSendTo = peopleToNotify.Select(x => x.Email).ToList();
            var mailMessage = GenerateProjectUpdateSubmittedMessage(projectUpdateBatch, latestProjectUpdateHistorySubmitted, submitterPerson);

            SendMessageAndLogNotificationForProjectUpdateTransition(projectUpdateBatch, mailMessage, emailsToSendTo, submitterEmails, new List<string>(), NotificationType.ProjectUpdateSubmitted);
        }

        public static void SendReturnedMessage(List<Person> peopleToCc, ProjectUpdateBatch projectUpdateBatch)
        {
            Check.Require(projectUpdateBatch.ProjectUpdateState == ProjectUpdateState.Returned, "Need to be in Returned state to send the Returned email!");
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var emailsToSendTo = new List<string> { submitterPerson.Email };

            var personNames = submitterPerson.FullNameFirstLast;
            var primaryContactPerson = projectUpdateBatch.Project.PrimaryContactPerson;
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
                personNames += String.Format(" and {0}", primaryContactPerson.FullNameFirstLast);
            }

            var returnerPerson = projectUpdateBatch.LatestProjectUpdateHistoryReturned.UpdatePerson;
            var mailMessage = GenerateProjectUpdateReturnedMessage(projectUpdateBatch, personNames, latestProjectUpdateHistorySubmitted, returnerPerson);

            SendMessageAndLogNotificationForProjectUpdateTransition(projectUpdateBatch,
                mailMessage,
                emailsToSendTo,
                new List<string> { returnerPerson.Email },
                peopleToCc.Select(x => x.Email).ToList(),
                NotificationType.ProjectUpdateReturned);
        }

        public static void SendApprovalMessage(List<Person> peopleToCc, ProjectUpdateBatch projectUpdateBatch)
        {
            Check.Require(projectUpdateBatch.ProjectUpdateState == ProjectUpdateState.Approved, "Need to be in Approved state to send the Approved email!");
            var latestProjectUpdateHistorySubmitted = projectUpdateBatch.LatestProjectUpdateHistorySubmitted;
            var submitterPerson = latestProjectUpdateHistorySubmitted.UpdatePerson;
            var emailsToSendTo = new List<string> { submitterPerson.Email };

            var personNames = submitterPerson.FullNameFirstLast;
            var primaryContactPerson = projectUpdateBatch.Project.PrimaryContactPerson;
            if (primaryContactPerson != null && !String.Equals(primaryContactPerson.Email, submitterPerson.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                emailsToSendTo.Add(primaryContactPerson.Email);
                personNames += String.Format(" and {0}", primaryContactPerson.FullNameFirstLast);
            }

            var approverPerson = projectUpdateBatch.LastUpdatePerson;
            var mailMessage = GenerateProjectUpdateApprovalMessage(projectUpdateBatch, personNames, latestProjectUpdateHistorySubmitted, approverPerson);

            SendMessageAndLogNotificationForProjectUpdateTransition(projectUpdateBatch,
                mailMessage,
                emailsToSendTo,
                new List<string> {approverPerson.Email},
                peopleToCc.Select(x => x.Email).ToList(),
                NotificationType.ProjectUpdateApproved);
        }

        private static MailMessage GenerateProjectUpdateApprovalMessage(ProjectUpdateBatch projectUpdateBatch,
            string personNames,
            ProjectUpdateHistory latestProjectUpdateHistorySubmitted,
            Person approverPerson)
        {
            var detailUrl = SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Detail(projectUpdateBatch.Project));
            var message = String.Format(@"
Dear {0},
<p>
    The update submitted for project {1} on {2} was approved by {3}.
</p>
<p>
    There is no action for you to take - this is simply a notification email. The updates for this project are now visible to the general public on this project's detail page:
</p>
<p>
    <a href=""{4}"">View this project</a>
</p>
Thank you for keeping your project information and accomplishments up to date!<br />
{5}
", personNames, projectUpdateBatch.Project.DisplayName, latestProjectUpdateHistorySubmitted.TransitionDate.ToStringDate(), approverPerson.FullNameFirstLastAndOrg, detailUrl,
                FirmaSignature);

            var subject = String.Format("The update for project {0} was approved", projectUpdateBatch.Project.DisplayName);
            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true};
            return mailMessage;
        }

        public static void SendProposedProjectSubmittedMessage(List<Person> peopleToNotify, ProposedProject proposedProject)
        {
            var submitterPerson = proposedProject.ProposingPerson;
            var submitterEmails = new List<string> { submitterPerson.Email };
            var emailsToSendTo = peopleToNotify.Select(x => x.Email).ToList();
            var mailMessage = GenerateProposedProjectSubmittedMessage(proposedProject, submitterPerson);
            var notificationProposedProject = new List<ProposedProject> {proposedProject};

            SendMessageAndLogProposedProjectNotifications(mailMessage, emailsToSendTo, submitterEmails, new List<string>(), peopleToNotify, DateTime.Now, notificationProposedProject, NotificationType.ProposedProjectSubmitted);
                
        }

        private static MailMessage GenerateProposedProjectSubmittedMessage(ProposedProject proposedProject, Person submitterPerson)
        {
            var subject = String.Format("A Project Proposal was submitted by {0}", submitterPerson.FullNameFirstLastAndOrg);
            var instructionsUrl = SitkaRoute<ProposedProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Instructions(proposedProject.ProposedProjectID));
            var message = String.Format(@"
<p>A proposal was submitted for a new Project, “{0}”.</p>
<p>The proposal was submitted on {1} by {2}.<br />
<p>Please review and Approve or Return it at your earliest convenience.</p>
<a href=""{3}"">View this proposal</a></p>
<p>You received this email because you are assigned to receive support notifications within the ProjectFirma tool.</p>
", proposedProject.DisplayName, proposedProject.ProposingDate.ToStringDate(), submitterPerson.FullNameFirstLastAndOrg, instructionsUrl);

            var mailMessage = new MailMessage { Subject = subject, Body = message, IsBodyHtml = true };
            return mailMessage;
        }        

        public static List<Notification> SendMessageAndLogProposedProjectNotifications(MailMessage mailMessage, IEnumerable<string> emailsToSendTo, IEnumerable<string> emailsToReplyTo, IEnumerable<string> emailsToCc, List<Person> notificationPeople, DateTime notificationDate, List<ProposedProject> notificationProposedProjects, NotificationType notificationType)
        {
            SendMessage(mailMessage, emailsToSendTo, emailsToReplyTo, emailsToCc);
            var notifications = new List<Notification>();
            foreach (var notificationPerson in notificationPeople)
            {
                var notification = new Notification(notificationType, notificationPerson, notificationDate);
                notification.NotificationProposedProjects = notificationProposedProjects.Select(p => new NotificationProposedProject(notification, p)).ToList();
                notifications.Add(notification);
            }
            return notifications;
        }

    }
}
