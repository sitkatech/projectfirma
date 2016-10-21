//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectThresholdCategory]
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
        public static ProjectThresholdCategory GetProjectThresholdCategory(this IQueryable<ProjectThresholdCategory> projectThresholdCategories, int projectThresholdCategoryID)
        {
            var projectThresholdCategory = projectThresholdCategories.SingleOrDefault(x => x.ProjectThresholdCategoryID == projectThresholdCategoryID);
            Check.RequireNotNullThrowNotFound(projectThresholdCategory, "ProjectThresholdCategory", projectThresholdCategoryID);
            return projectThresholdCategory;
        }

        public static void DeleteProjectThresholdCategory(this IQueryable<ProjectThresholdCategory> projectThresholdCategories, List<int> projectThresholdCategoryIDList)
        {
            if(projectThresholdCategoryIDList.Any())
            {
                projectThresholdCategories.Where(x => projectThresholdCategoryIDList.Contains(x.ProjectThresholdCategoryID)).Delete();
            }
        }

        public static void DeleteProjectThresholdCategory(this IQueryable<ProjectThresholdCategory> projectThresholdCategories, ICollection<ProjectThresholdCategory> projectThresholdCategoriesToDelete)
        {
            if(projectThresholdCategoriesToDelete.Any())
            {
                var projectThresholdCategoryIDList = projectThresholdCategoriesToDelete.Select(x => x.ProjectThresholdCategoryID).ToList();
                projectThresholdCategories.Where(x => projectThresholdCategoryIDList.Contains(x.ProjectThresholdCategoryID)).Delete();
            }
        }

        public static void DeleteProjectThresholdCategory(this IQueryable<ProjectThresholdCategory> projectThresholdCategories, int projectThresholdCategoryID)
        {
            DeleteProjectThresholdCategory(projectThresholdCategories, new List<int> { projectThresholdCategoryID });
        }

        public static void DeleteProjectThresholdCategory(this IQueryable<ProjectThresholdCategory> projectThresholdCategories, ProjectThresholdCategory projectThresholdCategoryToDelete)
        {
            DeleteProjectThresholdCategory(projectThresholdCategories, new List<ProjectThresholdCategory> { projectThresholdCategoryToDelete });
        }
    }
}