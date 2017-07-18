//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationTypeRelationshipType GetOrganizationTypeRelationshipType(this IQueryable<OrganizationTypeRelationshipType> organizationTypeRelationshipTypes, int organizationTypeRelationshipTypeID)
        {
            var organizationTypeRelationshipType = organizationTypeRelationshipTypes.SingleOrDefault(x => x.OrganizationTypeRelationshipTypeID == organizationTypeRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(organizationTypeRelationshipType, "OrganizationTypeRelationshipType", organizationTypeRelationshipTypeID);
            return organizationTypeRelationshipType;
        }

        public static void DeleteOrganizationTypeRelationshipType(this List<int> organizationTypeRelationshipTypeIDList)
        {
            if(organizationTypeRelationshipTypeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizationTypeRelationshipTypes.RemoveRange(HttpRequestStorage.DatabaseEntities.OrganizationTypeRelationshipTypes.Where(x => organizationTypeRelationshipTypeIDList.Contains(x.OrganizationTypeRelationshipTypeID)));
            }
        }

        public static void DeleteOrganizationTypeRelationshipType(this ICollection<OrganizationTypeRelationshipType> organizationTypeRelationshipTypesToDelete)
        {
            if(organizationTypeRelationshipTypesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizationTypeRelationshipTypes.RemoveRange(organizationTypeRelationshipTypesToDelete);
            }
        }

        public static void DeleteOrganizationTypeRelationshipType(this int organizationTypeRelationshipTypeID)
        {
            DeleteOrganizationTypeRelationshipType(new List<int> { organizationTypeRelationshipTypeID });
        }

        public static void DeleteOrganizationTypeRelationshipType(this OrganizationTypeRelationshipType organizationTypeRelationshipTypeToDelete)
        {
            DeleteOrganizationTypeRelationshipType(new List<OrganizationTypeRelationshipType> { organizationTypeRelationshipTypeToDelete });
        }
    }
}