using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using LtInfo.Common.Email;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class NotificationModelExtensions
    {
        public static MailAddress DoNotReplyMailAddress()
        {
            return new MailAddress(FirmaWebConfiguration.DoNotReplyEmail, MultiTenantHelpers.GetToolDisplayName());
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
            SitkaSmtpClient.Send(mailMessage);
        }
    }
}