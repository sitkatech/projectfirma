using System;
using System.Linq;
using System.Web;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class NotificationTypeModelExtensions
    {
        public static HtmlString GetFullDescriptionFromUserPerspective(this Notification notification)
        {
            switch(notification.NotificationType.ToEnum)
            {
                case NotificationTypeEnum.ProjectUpdateReminder:
                    return new HtmlString($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update reminder sent.");
                case NotificationTypeEnum.ProjectUpdateSubmitted:
                    return new HtmlString($"The update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {GetNotificationProjectDisplayNameAsHrefs(notification)} was submitted");
                case NotificationTypeEnum.ProjectUpdateReturned:
                    return new HtmlString($"The update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {GetNotificationProjectDisplayNameAsHrefs(notification)} has been returned");
                case NotificationTypeEnum.ProjectUpdateApproved:
                    return new HtmlString($"The update for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {GetNotificationProjectDisplayNameAsHrefs(notification)} was approved");
                case NotificationTypeEnum.Custom:
                    return new HtmlString("A customized notification was sent.");
                case NotificationTypeEnum.ProjectSubmitted:
                    return new HtmlString($"A {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} proposal {GetNotificationProjectDisplayNameAsHrefs(notification)} was submitted for review");
                case NotificationTypeEnum.ProjectApproved:
                    return new HtmlString($"A {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} proposal {GetNotificationProjectDisplayNameAsHrefs(notification)} was approved");
                case NotificationTypeEnum.ProjectReturned:
                    return new HtmlString($"A {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} proposal {GetNotificationProjectDisplayNameAsHrefs(notification)} was returned for additional information");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetFullDescriptionFromProjectPerspective(this NotificationType notificationType)
        {
            switch (notificationType.ToEnum)
            {
                case NotificationTypeEnum.ProjectUpdateReminder:
                    return $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update reminder sent.";
                case NotificationTypeEnum.ProjectUpdateSubmitted:
                    return $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update was submitted";
                case NotificationTypeEnum.ProjectUpdateReturned:
                    return $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update has been returned";
                case NotificationTypeEnum.ProjectUpdateApproved:
                    return $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} update was approved";
                case NotificationTypeEnum.Custom:
                    return string.Empty;
                case NotificationTypeEnum.ProjectSubmitted:
                    return "Proposal was submitted.";
                case NotificationTypeEnum.ProjectApproved:
                    return "Proposal was approved.";
                case NotificationTypeEnum.ProjectReturned:
                    return "Proposal was returned.";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private static HtmlString GetNotificationProjectDisplayNameAsHrefs(Notification notification)
        {
            return new HtmlString(string.Join(", ", notification.NotificationProjects.OrderBy(x => x.Project.ProjectName).Select(x => x.Project.GetDisplayNameAsUrl())));
        }

    }
}