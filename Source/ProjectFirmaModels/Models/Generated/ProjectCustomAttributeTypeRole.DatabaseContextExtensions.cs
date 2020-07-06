//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeTypeRole]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
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

    }
}