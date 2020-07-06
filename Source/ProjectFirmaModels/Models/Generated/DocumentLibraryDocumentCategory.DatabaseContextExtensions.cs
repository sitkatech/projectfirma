//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentCategory]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
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

    }
}