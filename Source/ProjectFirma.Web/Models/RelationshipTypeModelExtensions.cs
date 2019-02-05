using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class RelationshipTypeModelExtensions
    {
        public const string RelationshipTypeNameFunder = "Funder";

        public static bool IsRelationshipTypeNameUnique(List<RelationshipType> existingRelationshipTypes, string relationshipTypeName, int currentRelationshipTypeID)
        {
            var relationshipType = existingRelationshipTypes.SingleOrDefault(x => x.RelationshipTypeID != currentRelationshipTypeID && String.Equals(x.RelationshipTypeName, relationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return relationshipType == null;
        }

        public static string GetDeleteUrl(this RelationshipType relationshipType)
        {
            return SitkaRoute<OrganizationAndRelationshipTypeController>.BuildUrlFromExpression(c =>
                c.DeleteRelationshipType(relationshipType.RelationshipTypeID));
        }
    }
}