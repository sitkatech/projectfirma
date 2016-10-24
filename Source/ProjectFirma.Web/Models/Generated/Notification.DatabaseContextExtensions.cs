//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Notification]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteNotification(this IQueryable<Notification> notifications, List<int> notificationIDList)
        {
            if(notificationIDList.Any())
            {
                notifications.Where(x => notificationIDList.Contains(x.NotificationID)).Delete();
            }
        }

        public static void DeleteNotification(this IQueryable<Notification> notifications, ICollection<Notification> notificationsToDelete)
        {
            if(notificationsToDelete.Any())
            {
                var notificationIDList = notificationsToDelete.Select(x => x.NotificationID).ToList();
                notifications.Where(x => notificationIDList.Contains(x.NotificationID)).Delete();
            }
        }

        public static void DeleteNotification(this IQueryable<Notification> notifications, int notificationID)
        {
            DeleteNotification(notifications, new List<int> { notificationID });
        }

        public static void DeleteNotification(this IQueryable<Notification> notifications, Notification notificationToDelete)
        {
            DeleteNotification(notifications, new List<Notification> { notificationToDelete });
        }
    }
}