using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class DocumentLibraryModelExtensions
    {
        public static bool IsDisplayNameUnique(IEnumerable<DocumentLibrary> documentLibraries, string displayName, int currentDocumentLibraryID)
        {
            return documentLibraries.SingleOrDefault(x =>
                x.DocumentLibraryID != currentDocumentLibraryID && string.Equals(x.DocumentLibraryName, displayName, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this DocumentLibrary documentLibrary)
        {
            return DetailUrlTemplate.ParameterReplace(documentLibrary.DocumentLibraryID);
        }

        public static HtmlString GetDisplayNameAsUrl(this DocumentLibrary documentLibrary)
        {
            return UrlTemplate.MakeHrefString(documentLibrary.GetDetailUrl(), documentLibrary.DocumentLibraryName);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this DocumentLibrary documentLibrary)
        {
            return EditUrlTemplate.ParameterReplace(documentLibrary.DocumentLibraryID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(t => t.DeleteDocumentLibrary(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this DocumentLibrary documentLibrary)
        {
            return DeleteUrlTemplate.ParameterReplace(documentLibrary.DocumentLibraryID);
        }

        public static string GetDocumentCategoryDisplayNamesAsCommaDelimitedString(this DocumentLibrary documentLibrary)
        {
            return string.Join(", ",
                documentLibrary.DocumentLibraryDocumentCategories.OrderBy(x => x.DocumentCategory.SortOrder).Select(x => x.DocumentCategory.DocumentCategoryDisplayName));
        }

        public static string GetCustomPageDisplayNamesAsCommaDelimitedString(this DocumentLibrary documentLibrary)
        {
            return string.Join(", ",
                documentLibrary.CustomPages.Select(x => x.CustomPageDisplayName));
        }
    }
}