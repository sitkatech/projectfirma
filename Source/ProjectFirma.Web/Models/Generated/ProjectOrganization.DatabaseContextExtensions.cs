//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectOrganization GetProjectOrganization(this IQueryable<ProjectOrganization> projectOrganizations, int projectOrganizationID)
        {
            var projectOrganization = projectOrganizations.SingleOrDefault(x => x.ProjectOrganizationID == projectOrganizationID);
            Check.RequireNotNullThrowNotFound(projectOrganization, "ProjectOrganization", projectOrganizationID);
            return projectOrganization;
        }

        public static void DeleteProjectOrganization(this List<int> projectOrganizationIDList)
        {
            if(projectOrganizationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Where(x => projectOrganizationIDList.Contains(x.ProjectOrganizationID)));
            }
        }

        public static void DeleteProjectOrganization(this ICollection<ProjectOrganization> projectOrganizationsToDelete)
        {
            if(projectOrganizationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.RemoveRange(projectOrganizationsToDelete);
            }
        }

        public static void DeleteProjectOrganization(this int projectOrganizationID)
        {
            DeleteProjectOrganization(new List<int> { projectOrganizationID });
        }

        public static void DeleteProjectOrganization(this ProjectOrganization projectOrganizationToDelete)
        {
            DeleteProjectOrganization(new List<ProjectOrganization> { projectOrganizationToDelete });
        }
    }
}