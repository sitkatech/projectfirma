//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateCustomAttributeValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateCustomAttributeValue GetProjectUpdateCustomAttributeValue(this IQueryable<ProjectUpdateCustomAttributeValue> projectUpdateCustomAttributeValues, int projectUpdateCustomAttributeValueID)
        {
            var projectUpdateCustomAttributeValue = projectUpdateCustomAttributeValues.SingleOrDefault(x => x.ProjectUpdateCustomAttributeValueID == projectUpdateCustomAttributeValueID);
            Check.RequireNotNullThrowNotFound(projectUpdateCustomAttributeValue, "ProjectUpdateCustomAttributeValue", projectUpdateCustomAttributeValueID);
            return projectUpdateCustomAttributeValue;
        }

        public static void DeleteProjectUpdateCustomAttributeValue(this List<int> projectUpdateCustomAttributeValueIDList)
        {
            if(projectUpdateCustomAttributeValueIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateCustomAttributeValues.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectUpdateCustomAttributeValues.Where(x => projectUpdateCustomAttributeValueIDList.Contains(x.ProjectUpdateCustomAttributeValueID)));
            }
        }

        public static void DeleteProjectUpdateCustomAttributeValue(this ICollection<ProjectUpdateCustomAttributeValue> projectUpdateCustomAttributeValuesToDelete)
        {
            if(projectUpdateCustomAttributeValuesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateCustomAttributeValues.RemoveRange(projectUpdateCustomAttributeValuesToDelete);
            }
        }

        public static void DeleteProjectUpdateCustomAttributeValue(this int projectUpdateCustomAttributeValueID)
        {
            DeleteProjectUpdateCustomAttributeValue(new List<int> { projectUpdateCustomAttributeValueID });
        }

        public static void DeleteProjectUpdateCustomAttributeValue(this ProjectUpdateCustomAttributeValue projectUpdateCustomAttributeValueToDelete)
        {
            DeleteProjectUpdateCustomAttributeValue(new List<ProjectUpdateCustomAttributeValue> { projectUpdateCustomAttributeValueToDelete });
        }
    }
}