using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class OrganizationRelationshipTypeModelExtensions
    {
        public const string OrganizationRelationshipTypeNameFunder = "Funder";

        public static bool IsOrganizationRelationshipTypeNameUnique(List<OrganizationRelationshipType> existingOrganizationRelationshipTypes, string organizationRelationshipTypeName, int currentOrganizationRelationshipTypeID)
        {
            var relationshipType = existingOrganizationRelationshipTypes.SingleOrDefault(x => x.OrganizationRelationshipTypeID != currentOrganizationRelationshipTypeID && String.Equals(x.OrganizationRelationshipTypeName, organizationRelationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return relationshipType == null;
        }

        public static string GetDeleteUrl(this OrganizationRelationshipType organizationRelationshipType)
        {
            return SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(c =>
                c.DeleteOrganizationRelationshipType(organizationRelationshipType.OrganizationRelationshipTypeID));
        }
    }
}