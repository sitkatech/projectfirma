//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Notification]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Notification GetNotification(this IQueryable<Notification> notifications, int notificationID)
        {
            var notification = notifications.SingleOrDefault(x => x.NotificationID == notificationID);
            Check.RequireNotNullThrowNotFound(notification, "Notification", notificationID);
            return notification;
        }

    }
}