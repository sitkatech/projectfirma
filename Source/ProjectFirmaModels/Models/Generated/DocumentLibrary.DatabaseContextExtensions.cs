//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibrary]
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
        public static DocumentLibrary GetDocumentLibrary(this IQueryable<DocumentLibrary> documentLibraries, int documentLibraryID)
        {
            var documentLibrary = documentLibraries.SingleOrDefault(x => x.DocumentLibraryID == documentLibraryID);
            Check.RequireNotNullThrowNotFound(documentLibrary, "DocumentLibrary", documentLibraryID);
            return documentLibrary;
        }

    }
}