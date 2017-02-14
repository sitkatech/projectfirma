//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Notification]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Notification GetNotification(this IQueryable<Notification> notifications, int notificationID)
        {
            var notification = notifications.SingleOrDefault(x => x.NotificationID == notificationID);
            Check.RequireNotNullThrowNotFound(notification, "Notification", notificationID);
            return notification;
        }

        public static void DeleteNotification(this List<int> notificationIDList)
        {
            if(notificationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllNotifications.RemoveRange(HttpRequestStorage.DatabaseEntities.Notifications.Where(x => notificationIDList.Contains(x.NotificationID)));
            }
        }

        public static void DeleteNotification(this ICollection<Notification> notificationsToDelete)
        {
            if(notificationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllNotifications.RemoveRange(notificationsToDelete);
            }
        }

        public static void DeleteNotification(this int notificationID)
        {
            DeleteNotification(new List<int> { notificationID });
        }

        public static void DeleteNotification(this Notification notificationToDelete)
        {
            DeleteNotification(new List<Notification> { notificationToDelete });
        }
    }
}