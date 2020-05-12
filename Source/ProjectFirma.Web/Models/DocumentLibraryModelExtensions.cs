using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string GetEditUrl(this DocumentLibrary documentLibrary)
        {
            return SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(c => c.Edit(documentLibrary.DocumentLibraryID));
        }

        public static string GetDeleteUrl(this DocumentLibrary documentLibrary)
        {
            return SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(c => c.DeleteDocumentLibrary(documentLibrary.DocumentLibraryID));
        }

        public static string GetDocumentCategoryDisplayNamesAsCommaDelimitedString(this DocumentLibrary documentLibrary)
        {
            return string.Join(", ",
                documentLibrary.DocumentLibraryDocumentCategories.Select(x => x.DocumentCategory.DocumentCategoryDisplayName));
        }

        public static string GetCustomPageDisplayNamesAsCommaDelimitedString(this DocumentLibrary documentLibrary)
        {
            return string.Join(", ",
                documentLibrary.CustomPages.Select(x => x.CustomPageDisplayName));
        }
    }
}