using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class ContactTypeModelExtensions
    {
        public static bool IsContactTypeNameUnique(IEnumerable<ContactType> contactTypes, string contactTypeName, int currentContactTypeID)
        {
            var contactType = contactTypes.SingleOrDefault(x => x.ContactTypeID != currentContactTypeID && String.Equals(x.ContactTypeName, contactTypeName, StringComparison.InvariantCultureIgnoreCase));
            return contactType == null;
        }

        public static bool IsContactTypeAbbreviationUnique(IEnumerable<ContactType> contactTypes, string contactAbbreviation, int currentContactTypeID)
        {
            var contactType = contactTypes.SingleOrDefault(x => x.ContactTypeID != currentContactTypeID && String.Equals(x.ContactTypeAbbreviation, contactAbbreviation, StringComparison.InvariantCultureIgnoreCase));
            return contactType == null;
        }

        public static string GetDeleteUrl(ContactType contactType)
        {
            return SitkaRoute<ContactTypeAndContactRelationshipTypeController>.BuildUrlFromExpression(c =>
                c.DeleteContactType(contactType.ContactTypeID));
        }
    }
}