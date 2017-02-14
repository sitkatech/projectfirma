//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProject]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static NotificationProject GetNotificationProject(this IQueryable<NotificationProject> notificationProjects, int notificationProjectID)
        {
            var notificationProject = notificationProjects.SingleOrDefault(x => x.NotificationProjectID == notificationProjectID);
            Check.RequireNotNullThrowNotFound(notificationProject, "NotificationProject", notificationProjectID);
            return notificationProject;
        }

        public static void DeleteNotificationProject(this List<int> notificationProjectIDList)
        {
            if(notificationProjectIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllNotificationProjects.RemoveRange(HttpRequestStorage.DatabaseEntities.NotificationProjects.Where(x => notificationProjectIDList.Contains(x.NotificationProjectID)));
            }
        }

        public static void DeleteNotificationProject(this ICollection<NotificationProject> notificationProjectsToDelete)
        {
            if(notificationProjectsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllNotificationProjects.RemoveRange(notificationProjectsToDelete);
            }
        }

        public static void DeleteNotificationProject(this int notificationProjectID)
        {
            DeleteNotificationProject(new List<int> { notificationProjectID });
        }

        public static void DeleteNotificationProject(this NotificationProject notificationProjectToDelete)
        {
            DeleteNotificationProject(new List<NotificationProject> { notificationProjectToDelete });
        }
    }
}