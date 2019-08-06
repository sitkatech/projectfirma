using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class AttachmentRelationshipTypeModelExtensions
    {

        public static bool IsAttachmentRelationshipTypeNameUnique(this List<AttachmentRelationshipType> existingAttachmentRelationshipTypes, string contactRelationshipTypeName, int currentAttachmentRelationshipTypeID)
        {
            var contactRelationshipType = existingAttachmentRelationshipTypes.SingleOrDefault(x => x.AttachmentRelationshipTypeID != currentAttachmentRelationshipTypeID && String.Equals(x.AttachmentRelationshipTypeName, contactRelationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return contactRelationshipType == null;
        }

        public static string GetDeleteUrl(this AttachmentRelationshipType contactRelationshipType)
        {
            return SitkaRoute<AttachmentRelationshipTypeController>.BuildUrlFromExpression(c =>
                c.DeleteAttachmentRelationshipType(contactRelationshipType.AttachmentRelationshipTypeID));
        }
    }
}