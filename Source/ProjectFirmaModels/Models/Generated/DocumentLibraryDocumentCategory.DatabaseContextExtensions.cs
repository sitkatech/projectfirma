//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentCategory]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static DocumentLibraryDocumentCategory GetDocumentLibraryDocumentCategory(this IQueryable<DocumentLibraryDocumentCategory> documentLibraryDocumentCategories, int documentLibraryDocumentCategoryID)
        {
            var documentLibraryDocumentCategory = documentLibraryDocumentCategories.SingleOrDefault(x => x.DocumentLibraryDocumentCategoryID == documentLibraryDocumentCategoryID);
            Check.RequireNotNullThrowNotFound(documentLibraryDocumentCategory, "DocumentLibraryDocumentCategory", documentLibraryDocumentCategoryID);
            return documentLibraryDocumentCategory;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDocumentLibraryDocumentCategory(this IQueryable<DocumentLibraryDocumentCategory> documentLibraryDocumentCategories, List<int> documentLibraryDocumentCategoryIDList)
        {
            if(documentLibraryDocumentCategoryIDList.Any())
            {
                documentLibraryDocumentCategories.Where(x => documentLibraryDocumentCategoryIDList.Contains(x.DocumentLibraryDocumentCategoryID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDocumentLibraryDocumentCategory(this IQueryable<DocumentLibraryDocumentCategory> documentLibraryDocumentCategories, ICollection<DocumentLibraryDocumentCategory> documentLibraryDocumentCategoriesToDelete)
        {
            if(documentLibraryDocumentCategoriesToDelete.Any())
            {
                var documentLibraryDocumentCategoryIDList = documentLibraryDocumentCategoriesToDelete.Select(x => x.DocumentLibraryDocumentCategoryID).ToList();
                documentLibraryDocumentCategories.Where(x => documentLibraryDocumentCategoryIDList.Contains(x.DocumentLibraryDocumentCategoryID)).Delete();
            }
        }

        public static void DeleteDocumentLibraryDocumentCategory(this IQueryable<DocumentLibraryDocumentCategory> documentLibraryDocumentCategories, int documentLibraryDocumentCategoryID)
        {
            DeleteDocumentLibraryDocumentCategory(documentLibraryDocumentCategories, new List<int> { documentLibraryDocumentCategoryID });
        }

        public static void DeleteDocumentLibraryDocumentCategory(this IQueryable<DocumentLibraryDocumentCategory> documentLibraryDocumentCategories, DocumentLibraryDocumentCategory documentLibraryDocumentCategoryToDelete)
        {
            DeleteDocumentLibraryDocumentCategory(documentLibraryDocumentCategories, new List<DocumentLibraryDocumentCategory> { documentLibraryDocumentCategoryToDelete });
        }
    }
}