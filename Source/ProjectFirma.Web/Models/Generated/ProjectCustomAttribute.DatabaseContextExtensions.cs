//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttribute]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttribute GetProjectCustomAttribute(this IQueryable<ProjectCustomAttribute> projectCustomAttributes, int projectCustomAttributeID)
        {
            var projectCustomAttribute = projectCustomAttributes.SingleOrDefault(x => x.ProjectCustomAttributeID == projectCustomAttributeID);
            Check.RequireNotNullThrowNotFound(projectCustomAttribute, "ProjectCustomAttribute", projectCustomAttributeID);
            return projectCustomAttribute;
        }

        public static void DeleteProjectCustomAttribute(this List<int> projectCustomAttributeIDList)
        {
            if(projectCustomAttributeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectCustomAttributes.Where(x => projectCustomAttributeIDList.Contains(x.ProjectCustomAttributeID)));
            }
        }

        public static void DeleteProjectCustomAttribute(this ICollection<ProjectCustomAttribute> projectCustomAttributesToDelete)
        {
            if(projectCustomAttributesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributes.RemoveRange(projectCustomAttributesToDelete);
            }
        }

        public static void DeleteProjectCustomAttribute(this int projectCustomAttributeID)
        {
            DeleteProjectCustomAttribute(new List<int> { projectCustomAttributeID });
        }

        public static void DeleteProjectCustomAttribute(this ProjectCustomAttribute projectCustomAttributeToDelete)
        {
            DeleteProjectCustomAttribute(new List<ProjectCustomAttribute> { projectCustomAttributeToDelete });
        }
    }
}