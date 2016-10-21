//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[NotificationProposedProject]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteNotificationProposedProject(this IQueryable<NotificationProposedProject> notificationProposedProjects, List<int> notificationProposedProjectIDList)
        {
            if(notificationProposedProjectIDList.Any())
            {
                notificationProposedProjects.Where(x => notificationProposedProjectIDList.Contains(x.NotificationProposedProjectID)).Delete();
            }
        }

        public static void DeleteNotificationProposedProject(this IQueryable<NotificationProposedProject> notificationProposedProjects, ICollection<NotificationProposedProject> notificationProposedProjectsToDelete)
        {
            if(notificationProposedProjectsToDelete.Any())
            {
                var notificationProposedProjectIDList = notificationProposedProjectsToDelete.Select(x => x.NotificationProposedProjectID).ToList();
                notificationProposedProjects.Where(x => notificationProposedProjectIDList.Contains(x.NotificationProposedProjectID)).Delete();
            }
        }

        public static void DeleteNotificationProposedProject(this IQueryable<NotificationProposedProject> notificationProposedProjects, int notificationProposedProjectID)
        {
            DeleteNotificationProposedProject(notificationProposedProjects, new List<int> { notificationProposedProjectID });
        }

        public static void DeleteNotificationProposedProject(this IQueryable<NotificationProposedProject> notificationProposedProjects, NotificationProposedProject notificationProposedProjectToDelete)
        {
            DeleteNotificationProposedProject(notificationProposedProjects, new List<NotificationProposedProject> { notificationProposedProjectToDelete });
        }
    }
}