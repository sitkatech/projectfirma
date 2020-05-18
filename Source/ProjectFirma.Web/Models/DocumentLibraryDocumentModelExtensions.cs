using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class DocumentLibraryDocumentModelExtensions
    {
        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(t => t.EditDocument(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this DocumentLibraryDocument documentLibraryDocument)
        {
            return EditUrlTemplate.ParameterReplace(documentLibraryDocument.DocumentLibraryDocumentID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(t => t.DeleteDocument(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this DocumentLibraryDocument documentLibraryDocument)
        {
            return DeleteUrlTemplate.ParameterReplace(documentLibraryDocument.DocumentLibraryDocumentID);
        }

        public static HtmlString GetViewableRoles(this DocumentLibraryDocument documentLibraryDocument)
        {
            var documentLibraryDocumentRoles = HttpRequestStorage.DatabaseEntities.DocumentLibraryDocumentRoles.Where(x => x.DocumentLibraryDocumentID == documentLibraryDocument.DocumentLibraryDocumentID).ToList();
            return new HtmlString(documentLibraryDocumentRoles.Any()
                ? string.Join(", ", documentLibraryDocumentRoles.OrderBy(x => x.RoleID).Select(x => x.Role == null ? "Anonymous (Public)" : x.Role.GetRoleDisplayName()).ToList())
                : ViewUtilities.NoAnswerProvided);
        }

        public static bool HasViewPermission(this DocumentLibraryDocument documentLibraryDocument, FirmaSession currentFirmaSession)
        {
            var viewTypeRoles = documentLibraryDocument.DocumentLibraryDocumentRoles;
            return (currentFirmaSession.Person != null && viewTypeRoles.Select(x => x.Role).Contains(currentFirmaSession.Role)) || new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession) || (currentFirmaSession.Person == null && viewTypeRoles.Any(x => x.Role == null));
        }
    }
}