//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeTypeRole]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectCustomAttributeTypeRole GetProjectCustomAttributeTypeRole(this IQueryable<ProjectCustomAttributeTypeRole> projectCustomAttributeTypeRoles, int projectCustomAttributeTypeRoleID)
        {
            var projectCustomAttributeTypeRole = projectCustomAttributeTypeRoles.SingleOrDefault(x => x.ProjectCustomAttributeTypeRoleID == projectCustomAttributeTypeRoleID);
            Check.RequireNotNullThrowNotFound(projectCustomAttributeTypeRole, "ProjectCustomAttributeTypeRole", projectCustomAttributeTypeRoleID);
            return projectCustomAttributeTypeRole;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteProjectCustomAttributeTypeRole(this IQueryable<ProjectCustomAttributeTypeRole> projectCustomAttributeTypeRoles, List<int> projectCustomAttributeTypeRoleIDList)
        {
            if(projectCustomAttributeTypeRoleIDList.Any())
            {
                projectCustomAttributeTypeRoles.Where(x => projectCustomAttributeTypeRoleIDList.Contains(x.ProjectCustomAttributeTypeRoleID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteProjectCustomAttributeTypeRole(this IQueryable<ProjectCustomAttributeTypeRole> projectCustomAttributeTypeRoles, ICollection<ProjectCustomAttributeTypeRole> projectCustomAttributeTypeRolesToDelete)
        {
            if(projectCustomAttributeTypeRolesToDelete.Any())
            {
                var projectCustomAttributeTypeRoleIDList = projectCustomAttributeTypeRolesToDelete.Select(x => x.ProjectCustomAttributeTypeRoleID).ToList();
                projectCustomAttributeTypeRoles.Where(x => projectCustomAttributeTypeRoleIDList.Contains(x.ProjectCustomAttributeTypeRoleID)).Delete();
            }
        }

        public static void DeleteProjectCustomAttributeTypeRole(this IQueryable<ProjectCustomAttributeTypeRole> projectCustomAttributeTypeRoles, int projectCustomAttributeTypeRoleID)
        {
            DeleteProjectCustomAttributeTypeRole(projectCustomAttributeTypeRoles, new List<int> { projectCustomAttributeTypeRoleID });
        }

        public static void DeleteProjectCustomAttributeTypeRole(this IQueryable<ProjectCustomAttributeTypeRole> projectCustomAttributeTypeRoles, ProjectCustomAttributeTypeRole projectCustomAttributeTypeRoleToDelete)
        {
            DeleteProjectCustomAttributeTypeRole(projectCustomAttributeTypeRoles, new List<ProjectCustomAttributeTypeRole> { projectCustomAttributeTypeRoleToDelete });
        }
    }
}