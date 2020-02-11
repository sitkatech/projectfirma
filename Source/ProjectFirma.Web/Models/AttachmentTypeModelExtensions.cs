using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class AttachmentTypeModelExtensions
    {

        public static bool IsAttachmentTypeNameUnique(this List<AttachmentType> existingAttachmentTypes, string contactRelationshipTypeName, int currentAttachmentTypeID)
        {
            var contactRelationshipType = existingAttachmentTypes.SingleOrDefault(x => x.AttachmentRelationshipTypeID != currentAttachmentTypeID && String.Equals(x.AttachmentRelationshipTypeName, contactRelationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return contactRelationshipType == null;
        }

        public static string GetDeleteUrl(this AttachmentType contactType)
        {
            return SitkaRoute<AttachmentTypeController>.BuildUrlFromExpression(c =>
                c.DeleteAttachmentType(contactType.AttachmentRelationshipTypeID));
        }
    }
}