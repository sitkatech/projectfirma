//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationType GetOrganizationType(this IQueryable<OrganizationType> organizationTypes, int organizationTypeID)
        {
            var organizationType = organizationTypes.SingleOrDefault(x => x.OrganizationTypeID == organizationTypeID);
            Check.RequireNotNullThrowNotFound(organizationType, "OrganizationType", organizationTypeID);
            return organizationType;
        }

        public static void DeleteOrganizationType(this List<int> organizationTypeIDList)
        {
            if(organizationTypeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizationTypes.RemoveRange(HttpRequestStorage.DatabaseEntities.OrganizationTypes.Where(x => organizationTypeIDList.Contains(x.OrganizationTypeID)));
            }
        }

        public static void DeleteOrganizationType(this ICollection<OrganizationType> organizationTypesToDelete)
        {
            if(organizationTypesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizationTypes.RemoveRange(organizationTypesToDelete);
            }
        }

        public static void DeleteOrganizationType(this int organizationTypeID)
        {
            DeleteOrganizationType(new List<int> { organizationTypeID });
        }

        public static void DeleteOrganizationType(this OrganizationType organizationTypeToDelete)
        {
            DeleteOrganizationType(new List<OrganizationType> { organizationTypeToDelete });
        }
    }
}