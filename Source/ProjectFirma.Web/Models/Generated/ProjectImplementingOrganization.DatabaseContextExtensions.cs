//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImplementingOrganization]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectImplementingOrganization GetProjectImplementingOrganization(this IQueryable<ProjectImplementingOrganization> projectImplementingOrganizations, int projectImplementingOrganizationID)
        {
            var projectImplementingOrganization = projectImplementingOrganizations.SingleOrDefault(x => x.ProjectImplementingOrganizationID == projectImplementingOrganizationID);
            Check.RequireNotNullThrowNotFound(projectImplementingOrganization, "ProjectImplementingOrganization", projectImplementingOrganizationID);
            return projectImplementingOrganization;
        }

        public static void DeleteProjectImplementingOrganization(this IQueryable<ProjectImplementingOrganization> projectImplementingOrganizations, List<int> projectImplementingOrganizationIDList)
        {
            if(projectImplementingOrganizationIDList.Any())
            {
                projectImplementingOrganizations.Where(x => projectImplementingOrganizationIDList.Contains(x.ProjectImplementingOrganizationID)).Delete();
            }
        }

        public static void DeleteProjectImplementingOrganization(this IQueryable<ProjectImplementingOrganization> projectImplementingOrganizations, ICollection<ProjectImplementingOrganization> projectImplementingOrganizationsToDelete)
        {
            if(projectImplementingOrganizationsToDelete.Any())
            {
                var projectImplementingOrganizationIDList = projectImplementingOrganizationsToDelete.Select(x => x.ProjectImplementingOrganizationID).ToList();
                projectImplementingOrganizations.Where(x => projectImplementingOrganizationIDList.Contains(x.ProjectImplementingOrganizationID)).Delete();
            }
        }

        public static void DeleteProjectImplementingOrganization(this IQueryable<ProjectImplementingOrganization> projectImplementingOrganizations, int projectImplementingOrganizationID)
        {
            DeleteProjectImplementingOrganization(projectImplementingOrganizations, new List<int> { projectImplementingOrganizationID });
        }

        public static void DeleteProjectImplementingOrganization(this IQueryable<ProjectImplementingOrganization> projectImplementingOrganizations, ProjectImplementingOrganization projectImplementingOrganizationToDelete)
        {
            DeleteProjectImplementingOrganization(projectImplementingOrganizations, new List<ProjectImplementingOrganization> { projectImplementingOrganizationToDelete });
        }
    }
}