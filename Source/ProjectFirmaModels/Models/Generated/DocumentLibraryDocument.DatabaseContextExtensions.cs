//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocument]
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
        public static DocumentLibraryDocument GetDocumentLibraryDocument(this IQueryable<DocumentLibraryDocument> documentLibraryDocuments, int documentLibraryDocumentID)
        {
            var documentLibraryDocument = documentLibraryDocuments.SingleOrDefault(x => x.DocumentLibraryDocumentID == documentLibraryDocumentID);
            Check.RequireNotNullThrowNotFound(documentLibraryDocument, "DocumentLibraryDocument", documentLibraryDocumentID);
            return documentLibraryDocument;
        }

    }
}