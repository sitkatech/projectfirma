//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageRole]
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
        public static CustomPageRole GetCustomPageRole(this IQueryable<CustomPageRole> customPageRoles, int customPageRoleID)
        {
            var customPageRole = customPageRoles.SingleOrDefault(x => x.CustomPageRoleID == customPageRoleID);
            Check.RequireNotNullThrowNotFound(customPageRole, "CustomPageRole", customPageRoleID);
            return customPageRole;
        }

    }
}