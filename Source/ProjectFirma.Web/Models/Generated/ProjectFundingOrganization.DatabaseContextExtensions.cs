//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingOrganization]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingOrganization GetProjectFundingOrganization(this IQueryable<ProjectFundingOrganization> projectFundingOrganizations, int projectFundingOrganizationID)
        {
            var projectFundingOrganization = projectFundingOrganizations.SingleOrDefault(x => x.ProjectFundingOrganizationID == projectFundingOrganizationID);
            Check.RequireNotNullThrowNotFound(projectFundingOrganization, "ProjectFundingOrganization", projectFundingOrganizationID);
            return projectFundingOrganization;
        }

        public static void DeleteProjectFundingOrganization(this IQueryable<ProjectFundingOrganization> projectFundingOrganizations, List<int> projectFundingOrganizationIDList)
        {
            if(projectFundingOrganizationIDList.Any())
            {
                projectFundingOrganizations.Where(x => projectFundingOrganizationIDList.Contains(x.ProjectFundingOrganizationID)).Delete();
            }
        }

        public static void DeleteProjectFundingOrganization(this IQueryable<ProjectFundingOrganization> projectFundingOrganizations, ICollection<ProjectFundingOrganization> projectFundingOrganizationsToDelete)
        {
            if(projectFundingOrganizationsToDelete.Any())
            {
                var projectFundingOrganizationIDList = projectFundingOrganizationsToDelete.Select(x => x.ProjectFundingOrganizationID).ToList();
                projectFundingOrganizations.Where(x => projectFundingOrganizationIDList.Contains(x.ProjectFundingOrganizationID)).Delete();
            }
        }

        public static void DeleteProjectFundingOrganization(this IQueryable<ProjectFundingOrganization> projectFundingOrganizations, int projectFundingOrganizationID)
        {
            DeleteProjectFundingOrganization(projectFundingOrganizations, new List<int> { projectFundingOrganizationID });
        }

        public static void DeleteProjectFundingOrganization(this IQueryable<ProjectFundingOrganization> projectFundingOrganizations, ProjectFundingOrganization projectFundingOrganizationToDelete)
        {
            DeleteProjectFundingOrganization(projectFundingOrganizations, new List<ProjectFundingOrganization> { projectFundingOrganizationToDelete });
        }
    }
}