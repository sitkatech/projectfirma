//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeValue GetProjectCustomAttributeValue(this IQueryable<ProjectCustomAttributeValue> projectCustomAttributeValues, int projectCustomAttributeValueID)
        {
            var projectCustomAttributeValue = projectCustomAttributeValues.SingleOrDefault(x => x.ProjectCustomAttributeValueID == projectCustomAttributeValueID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeValue, "ProjectCustomAttributeValue", projectCustomAttributeValueID);
            return projectCustomAttributeValue;
        }

        public static void DeleteProjectCustomAttributeValue(this List<int> projectCustomAttributeValueIDList)
        {
            if(projectCustomAttributeValueIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeValues.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeValues.Where(x => projectCustomAttributeValueIDList.Contains(x.ProjectCustomAttributeValueID)));
            }
        }

        public static void DeleteProjectCustomAttributeValue(this ICollection<ProjectCustomAttributeValue> projectCustomAttributeValuesToDelete)
        {
            if(projectCustomAttributeValuesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeValues.RemoveRange(projectCustomAttributeValuesToDelete);
            }
        }

        public static void DeleteProjectCustomAttributeValue(this int projectCustomAttributeValueID)
        {
            DeleteProjectCustomAttributeValue(new List<int> { projectCustomAttributeValueID });
        }

        public static void DeleteProjectCustomAttributeValue(this ProjectCustomAttributeValue projectCustomAttributeValueToDelete)
        {
            DeleteProjectCustomAttributeValue(new List<ProjectCustomAttributeValue> { projectCustomAttributeValueToDelete });
        }
    }
}