using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class AttachmentTypeModelExtensions
    {

        public static bool IsAttachmentTypeNameUnique(this List<AttachmentType> existingAttachmentTypes, string contactRelationshipTypeName, int currentAttachmentTypeID)
        {
            var contactRelationshipType = existingAttachmentTypes.SingleOrDefault(x => x.AttachmentTypeID != currentAttachmentTypeID && String.Equals(x.AttachmentTypeName, contactRelationshipTypeName, StringComparison.InvariantCultureIgnoreCase));
            return contactRelationshipType == null;
        }

        public static string GetDeleteUrl(this AttachmentType contactType)
        {
            return SitkaRoute<AttachmentTypeController>.BuildUrlFromExpression(c =>
                c.DeleteAttachmentType(contactType.AttachmentTypeID));
        }

        public static string GetContentUrl(this AttachmentType attachmentType)
        {
            return SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(x =>
                x.FieldDefinitionDetailsForAttachmentType(attachmentType.AttachmentTypeID));
        }

        public static HtmlString GetViewableRoles(this AttachmentType attachmentType)
        {
            var attachmentTypeRoles = HttpRequestStorage.DatabaseEntities.AttachmentTypeRoles.Where(x => x.AttachmentTypeID == attachmentType.AttachmentTypeID).ToList();
            return new HtmlString(attachmentTypeRoles.Any()
                ? string.Join(", ",
                    attachmentTypeRoles.OrderBy(x => x.Role?.SortOrder).Select(x =>
                        x.Role == null ? "Anonymous (Public)" : x.Role.GetRoleDisplayName()).ToList())
                : ViewUtilities.NoAnswerProvided);
        }


        public static bool HasViewPermission(this AttachmentType attachmentType, FirmaSession currentFirmaSession)
        {
            var viewTypeRoles = attachmentType.AttachmentTypeRoles;
            return (currentFirmaSession.Person != null && viewTypeRoles.Select(x => x.Role).Contains(currentFirmaSession.Role)) ||
                   new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession) ||
                   (currentFirmaSession.Person == null && viewTypeRoles.Any(x => x.Role == null));
        }
    }
}