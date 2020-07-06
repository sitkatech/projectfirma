//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[DocumentLibraryDocumentRole]
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
        public static DocumentLibraryDocumentRole GetDocumentLibraryDocumentRole(this IQueryable<DocumentLibraryDocumentRole> documentLibraryDocumentRoles, int documentLibraryDocumentRoleID)
        {
            var documentLibraryDocumentRole = documentLibraryDocumentRoles.SingleOrDefault(x => x.DocumentLibraryDocumentRoleID == documentLibraryDocumentRoleID);
            Check.RequireNotNullThrowNotFound(documentLibraryDocumentRole, "DocumentLibraryDocumentRole", documentLibraryDocumentRoleID);
            return documentLibraryDocumentRole;
        }

    }
}