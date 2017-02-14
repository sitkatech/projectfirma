//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImplementingOrganization]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteProjectImplementingOrganization(this List<int> projectImplementingOrganizationIDList)
        {
            if(projectImplementingOrganizationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectImplementingOrganizations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectImplementingOrganizations.Where(x => projectImplementingOrganizationIDList.Contains(x.ProjectImplementingOrganizationID)));
            }
        }

        public static void DeleteProjectImplementingOrganization(this ICollection<ProjectImplementingOrganization> projectImplementingOrganizationsToDelete)
        {
            if(projectImplementingOrganizationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectImplementingOrganizations.RemoveRange(projectImplementingOrganizationsToDelete);
            }
        }

        public static void DeleteProjectImplementingOrganization(this int projectImplementingOrganizationID)
        {
            DeleteProjectImplementingOrganization(new List<int> { projectImplementingOrganizationID });
        }

        public static void DeleteProjectImplementingOrganization(this ProjectImplementingOrganization projectImplementingOrganizationToDelete)
        {
            DeleteProjectImplementingOrganization(new List<ProjectImplementingOrganization> { projectImplementingOrganizationToDelete });
        }
    }
}