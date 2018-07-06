//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeType GetProjectCustomAttributeType(this IQueryable<ProjectCustomAttributeType> projectCustomAttributeTypes, int projectCustomAttributeTypeID)
        {
            var projectCustomAttributeType = projectCustomAttributeTypes.SingleOrDefault(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeTypeID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeType, "ProjectCustomAttributeType", projectCustomAttributeTypeID);
            return projectCustomAttributeType;
        }

        public static void DeleteProjectCustomAttributeType(this List<int> projectCustomAttributeTypeIDList)
        {
            if(projectCustomAttributeTypeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeTypes.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Where(x => projectCustomAttributeTypeIDList.Contains(x.ProjectCustomAttributeTypeID)));
            }
        }

        public static void DeleteProjectCustomAttributeType(this ICollection<ProjectCustomAttributeType> projectCustomAttributeTypesToDelete)
        {
            if(projectCustomAttributeTypesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeTypes.RemoveRange(projectCustomAttributeTypesToDelete);
            }
        }

        public static void DeleteProjectCustomAttributeType(this int projectCustomAttributeTypeID)
        {
            DeleteProjectCustomAttributeType(new List<int> { projectCustomAttributeTypeID });
        }

        public static void DeleteProjectCustomAttributeType(this ProjectCustomAttributeType projectCustomAttributeTypeToDelete)
        {
            DeleteProjectCustomAttributeType(new List<ProjectCustomAttributeType> { projectCustomAttributeTypeToDelete });
        }
    }
}