//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProject]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static NotificationProject GetNotificationProject(this IQueryable<NotificationProject> notificationProjects, int notificationProjectID)
        {
            var notificationProject = notificationProjects.SingleOrDefault(x => x.NotificationProjectID == notificationProjectID);
            Check.RequireNotNullThrowNotFound(notificationProject, "NotificationProject", notificationProjectID);
            return notificationProject;
        }

    }
}