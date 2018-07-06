//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeUpdateValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeUpdateValue GetProjectCustomAttributeUpdateValue(this IQueryable<ProjectCustomAttributeUpdateValue> projectCustomAttributeUpdateValues, int projectCustomAttributeUpdateValueID)
        {
            var projectCustomAttributeUpdateValue = projectCustomAttributeUpdateValues.SingleOrDefault(x => x.ProjectCustomAttributeUpdateValueID == projectCustomAttributeUpdateValueID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeUpdateValue, "ProjectCustomAttributeUpdateValue", projectCustomAttributeUpdateValueID);
            return projectCustomAttributeUpdateValue;
        }

        public static void DeleteProjectCustomAttributeUpdateValue(this List<int> projectCustomAttributeUpdateValueIDList)
        {
            if(projectCustomAttributeUpdateValueIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdateValues.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeUpdateValues.Where(x => projectCustomAttributeUpdateValueIDList.Contains(x.ProjectCustomAttributeUpdateValueID)));
            }
        }

        public static void DeleteProjectCustomAttributeUpdateValue(this ICollection<ProjectCustomAttributeUpdateValue> projectCustomAttributeUpdateValuesToDelete)
        {
            if(projectCustomAttributeUpdateValuesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeUpdateValues.RemoveRange(projectCustomAttributeUpdateValuesToDelete);
            }
        }

        public static void DeleteProjectCustomAttributeUpdateValue(this int projectCustomAttributeUpdateValueID)
        {
            DeleteProjectCustomAttributeUpdateValue(new List<int> { projectCustomAttributeUpdateValueID });
        }

        public static void DeleteProjectCustomAttributeUpdateValue(this ProjectCustomAttributeUpdateValue projectCustomAttributeUpdateValueToDelete)
        {
            DeleteProjectCustomAttributeUpdateValue(new List<ProjectCustomAttributeUpdateValue> { projectCustomAttributeUpdateValueToDelete });
        }
    }
}