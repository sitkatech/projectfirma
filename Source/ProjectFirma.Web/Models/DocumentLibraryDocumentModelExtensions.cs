using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class DocumentLibraryDocumentModelExtensions
    {
        public static bool IsDisplayNameUnique(IEnumerable<DocumentLibraryDocument> documentLibraryDocuments, string displayName, int currentDocumentLibraryDocumentID)
        {
            return documentLibraryDocuments.SingleOrDefault(x =>
                x.DocumentLibraryDocumentID != currentDocumentLibraryDocumentID && string.Equals(x.DocumentTitle, displayName, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        // public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        // public static string GetDetailUrl(this DocumentLibraryDocument documentLibraryDocument)
        // {
        //     return DetailUrlTemplate.ParameterReplace(documentLibraryDocument.DocumentLibraryID);
        // }
        //
        // public static HtmlString GetDisplayNameAsUrl(this DocumentLibraryDocument documentLibraryDocument)
        // {
        //     return UrlTemplate.MakeHrefString(documentLibraryDocument.GetDetailUrl(), documentLibraryDocument.DocumentTitle);
        // }

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
    }
}