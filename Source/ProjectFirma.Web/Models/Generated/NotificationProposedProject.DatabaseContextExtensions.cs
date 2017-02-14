//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProposedProject]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static NotificationProposedProject GetNotificationProposedProject(this IQueryable<NotificationProposedProject> notificationProposedProjects, int notificationProposedProjectID)
        {
            var notificationProposedProject = notificationProposedProjects.SingleOrDefault(x => x.NotificationProposedProjectID == notificationProposedProjectID);
            Check.RequireNotNullThrowNotFound(notificationProposedProject, "NotificationProposedProject", notificationProposedProjectID);
            return notificationProposedProject;
        }

        public static void DeleteNotificationProposedProject(this List<int> notificationProposedProjectIDList)
        {
            if(notificationProposedProjectIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllNotificationProposedProjects.RemoveRange(HttpRequestStorage.DatabaseEntities.NotificationProposedProjects.Where(x => notificationProposedProjectIDList.Contains(x.NotificationProposedProjectID)));
            }
        }

        public static void DeleteNotificationProposedProject(this ICollection<NotificationProposedProject> notificationProposedProjectsToDelete)
        {
            if(notificationProposedProjectsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllNotificationProposedProjects.RemoveRange(notificationProposedProjectsToDelete);
            }
        }

        public static void DeleteNotificationProposedProject(this int notificationProposedProjectID)
        {
            DeleteNotificationProposedProject(new List<int> { notificationProposedProjectID });
        }

        public static void DeleteNotificationProposedProject(this NotificationProposedProject notificationProposedProjectToDelete)
        {
            DeleteNotificationProposedProject(new List<NotificationProposedProject> { notificationProposedProjectToDelete });
        }
    }
}