//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingOrganization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

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

        public static void DeleteProjectFundingOrganization(this List<int> projectFundingOrganizationIDList)
        {
            if(projectFundingOrganizationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingOrganizations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Where(x => projectFundingOrganizationIDList.Contains(x.ProjectFundingOrganizationID)));
            }
        }

        public static void DeleteProjectFundingOrganization(this ICollection<ProjectFundingOrganization> projectFundingOrganizationsToDelete)
        {
            if(projectFundingOrganizationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingOrganizations.RemoveRange(projectFundingOrganizationsToDelete);
            }
        }

        public static void DeleteProjectFundingOrganization(this int projectFundingOrganizationID)
        {
            DeleteProjectFundingOrganization(new List<int> { projectFundingOrganizationID });
        }

        public static void DeleteProjectFundingOrganization(this ProjectFundingOrganization projectFundingOrganizationToDelete)
        {
            DeleteProjectFundingOrganization(new List<ProjectFundingOrganization> { projectFundingOrganizationToDelete });
        }
    }
}