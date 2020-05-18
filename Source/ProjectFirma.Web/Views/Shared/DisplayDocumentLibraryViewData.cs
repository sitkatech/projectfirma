using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared
{
    public class DisplayDocumentLibraryViewData
    {
        public readonly bool ShowDocumentLibrary;
        public readonly bool UserHasAdminPermissions;
        public readonly string DocumentLibraryUrl;
        public readonly List<DocumentCategory> DocumentCategories;
        public readonly List<DocumentLibraryDocument> Documents;
        public readonly Dictionary<int, int> TotalDocumentCountPerCategory;
        public readonly Dictionary<int, int> ViewableDocumentCountPerCategory;


        public DisplayDocumentLibraryViewData(ProjectFirmaModels.Models.CustomPage customPage, FirmaSession currentFirmaSession)
        {
            if (customPage.DocumentLibrary != null)
            {
                UserHasAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
                DocumentLibraryUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(c => c.Detail(customPage.DocumentLibrary));
                // ShowDocumentLibrary = true;
                DocumentCategories = customPage.DocumentLibrary.DocumentLibraryDocumentCategories.Select(x => x.DocumentCategory).OrderBy(x => x.SortOrder).ToList();
                Documents = customPage.DocumentLibrary.DocumentLibraryDocuments.Where(x => x.HasViewPermission(currentFirmaSession)).ToList();
                ShowDocumentLibrary = Documents.Any() || UserHasAdminPermissions;

                TotalDocumentCountPerCategory = new Dictionary<int, int>();
                ViewableDocumentCountPerCategory = new Dictionary<int, int>();

                if (ShowDocumentLibrary)
                {
                    foreach (var documentCategory in DocumentCategories)
                    {
                        TotalDocumentCountPerCategory.Add(documentCategory.DocumentCategoryID, customPage.DocumentLibrary.DocumentLibraryDocuments.Count(x => x.DocumentCategoryID == documentCategory.DocumentCategoryID));
                        ViewableDocumentCountPerCategory.Add(documentCategory.DocumentCategoryID, Documents.Count(x => x.DocumentCategoryID == documentCategory.DocumentCategoryID));
                    }
                }

                // if (TotalDocumentCountPerCategory.Values.Sum() > 0 && !Documents.Any())
                // {
                //     // documents exist, but user does not have permission to view any, so hide the whole document library
                //     ShowDocumentLibrary = false;
                // }
            }
        }
    }
}
