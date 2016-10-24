//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFirmaPage]
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
        public static ProjectFirmaPage GetProjectFirmaPage(this IQueryable<ProjectFirmaPage> projectFirmaPages, int projectFirmaPageID)
        {
            var projectFirmaPage = projectFirmaPages.SingleOrDefault(x => x.ProjectFirmaPageID == projectFirmaPageID);
            Check.RequireNotNullThrowNotFound(projectFirmaPage, "ProjectFirmaPage", projectFirmaPageID);
            return projectFirmaPage;
        }

        public static void DeleteProjectFirmaPage(this IQueryable<ProjectFirmaPage> projectFirmaPages, List<int> projectFirmaPageIDList)
        {
            if(projectFirmaPageIDList.Any())
            {
                projectFirmaPages.Where(x => projectFirmaPageIDList.Contains(x.ProjectFirmaPageID)).Delete();
            }
        }

        public static void DeleteProjectFirmaPage(this IQueryable<ProjectFirmaPage> projectFirmaPages, ICollection<ProjectFirmaPage> projectFirmaPagesToDelete)
        {
            if(projectFirmaPagesToDelete.Any())
            {
                var projectFirmaPageIDList = projectFirmaPagesToDelete.Select(x => x.ProjectFirmaPageID).ToList();
                projectFirmaPages.Where(x => projectFirmaPageIDList.Contains(x.ProjectFirmaPageID)).Delete();
            }
        }

        public static void DeleteProjectFirmaPage(this IQueryable<ProjectFirmaPage> projectFirmaPages, int projectFirmaPageID)
        {
            DeleteProjectFirmaPage(projectFirmaPages, new List<int> { projectFirmaPageID });
        }

        public static void DeleteProjectFirmaPage(this IQueryable<ProjectFirmaPage> projectFirmaPages, ProjectFirmaPage projectFirmaPageToDelete)
        {
            DeleteProjectFirmaPage(projectFirmaPages, new List<ProjectFirmaPage> { projectFirmaPageToDelete });
        }
    }
}