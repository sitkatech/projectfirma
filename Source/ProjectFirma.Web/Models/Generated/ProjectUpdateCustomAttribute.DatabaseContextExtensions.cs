//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateCustomAttribute]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateCustomAttribute GetProjectUpdateCustomAttribute(this IQueryable<ProjectUpdateCustomAttribute> projectUpdateCustomAttributes, int projectUpdateCustomAttributeID)
        {
            var projectUpdateCustomAttribute = projectUpdateCustomAttributes.SingleOrDefault(x => x.ProjectUpdateCustomAttributeID == projectUpdateCustomAttributeID);
            Check.RequireNotNullThrowNotFound(projectUpdateCustomAttribute, "ProjectUpdateCustomAttribute", projectUpdateCustomAttributeID);
            return projectUpdateCustomAttribute;
        }

        public static void DeleteProjectUpdateCustomAttribute(this List<int> projectUpdateCustomAttributeIDList)
        {
            if(projectUpdateCustomAttributeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateCustomAttributes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectUpdateCustomAttributes.Where(x => projectUpdateCustomAttributeIDList.Contains(x.ProjectUpdateCustomAttributeID)));
            }
        }

        public static void DeleteProjectUpdateCustomAttribute(this ICollection<ProjectUpdateCustomAttribute> projectUpdateCustomAttributesToDelete)
        {
            if(projectUpdateCustomAttributesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateCustomAttributes.RemoveRange(projectUpdateCustomAttributesToDelete);
            }
        }

        public static void DeleteProjectUpdateCustomAttribute(this int projectUpdateCustomAttributeID)
        {
            DeleteProjectUpdateCustomAttribute(new List<int> { projectUpdateCustomAttributeID });
        }

        public static void DeleteProjectUpdateCustomAttribute(this ProjectUpdateCustomAttribute projectUpdateCustomAttributeToDelete)
        {
            DeleteProjectUpdateCustomAttribute(new List<ProjectUpdateCustomAttribute> { projectUpdateCustomAttributeToDelete });
        }
    }
}