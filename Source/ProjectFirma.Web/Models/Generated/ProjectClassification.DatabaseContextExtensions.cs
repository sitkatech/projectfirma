//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassification]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteProjectClassification(this List<int> projectClassificationIDList)
        {
            if(projectClassificationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectClassifications.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectClassifications.Where(x => projectClassificationIDList.Contains(x.ProjectClassificationID)));
            }
        }

        public static void DeleteProjectClassification(this ICollection<ProjectClassification> projectClassificationsToDelete)
        {
            if(projectClassificationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectClassifications.RemoveRange(projectClassificationsToDelete);
            }
        }

        public static void DeleteProjectClassification(this int projectClassificationID)
        {
            DeleteProjectClassification(new List<int> { projectClassificationID });
        }

        public static void DeleteProjectClassification(this ProjectClassification projectClassificationToDelete)
        {
            DeleteProjectClassification(new List<ProjectClassification> { projectClassificationToDelete });
        }
    }
}