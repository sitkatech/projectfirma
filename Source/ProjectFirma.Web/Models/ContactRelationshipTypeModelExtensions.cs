using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class ContactRelationshipTypeModelExtensions
    {

        public static bool IsContactRelationshipTypeNameUnique(this List<ContactRelationshipType> existingContactRelationshipTypes, string contactRelationshipTypeName, int currentContactRelationshipTypeID)
        {
            var contactRelationshipType = existingContactRelationshipTypes.SingleOrDefault(x => x.ContactRelationshipTypeID != currentContactRelationshipTypeID && String.Equals(x.ContactRelationshipTypeName, contactRelationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return contactRelationshipType == null;
        }

        public static string GetDeleteUrl(this ContactRelationshipType contactRelationshipType)
        {
            return SitkaRoute<ContactRelationshipTypeController>.BuildUrlFromExpression(c =>
                c.DeleteContactRelationshipType(contactRelationshipType.ContactRelationshipTypeID));
        }
    }
}