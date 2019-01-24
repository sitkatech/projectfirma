//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectOrganization GetProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, int projectOrganizationID)
        {
            var projectOrganization = projectOrganizations.SingleOrDefault(x => x.ProjectOrganizationID == projectOrganizationID);
            Check.RequireNotNullThrowNotFound(projectOrganization, "ProjectOrganization", projectOrganizationID);
            return projectOrganization;
        }

    }
}