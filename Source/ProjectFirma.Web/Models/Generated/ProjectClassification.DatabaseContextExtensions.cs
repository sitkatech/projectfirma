//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassification]
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
        public static ProjectClassification GetProjectClassification(this IQueryable<ProjectClassification> projectClassifications, int projectClassificationID)
        {
            var projectClassification = projectClassifications.SingleOrDefault(x => x.ProjectClassificationID == projectClassificationID);
            Check.RequireNotNullThrowNotFound(projectClassification, "ProjectClassification", projectClassificationID);
            return projectClassification;
        }

        public static void DeleteProjectClassification(this IQueryable<ProjectClassification> projectClassifications, List<int> projectClassificationIDList)
        {
            if(projectClassificationIDList.Any())
            {
                projectClassifications.Where(x => projectClassificationIDList.Contains(x.ProjectClassificationID)).Delete();
            }
        }

        public static void DeleteProjectClassification(this IQueryable<ProjectClassification> projectClassifications, ICollection<ProjectClassification> projectClassificationsToDelete)
        {
            if(projectClassificationsToDelete.Any())
            {
                var projectClassificationIDList = projectClassificationsToDelete.Select(x => x.ProjectClassificationID).ToList();
                projectClassifications.Where(x => projectClassificationIDList.Contains(x.ProjectClassificationID)).Delete();
            }
        }

        public static void DeleteProjectClassification(this IQueryable<ProjectClassification> projectClassifications, int projectClassificationID)
        {
            DeleteProjectClassification(projectClassifications, new List<int> { projectClassificationID });
        }

        public static void DeleteProjectClassification(this IQueryable<ProjectClassification> projectClassifications, ProjectClassification projectClassificationToDelete)
        {
            DeleteProjectClassification(projectClassifications, new List<ProjectClassification> { projectClassificationToDelete });
        }
    }
}