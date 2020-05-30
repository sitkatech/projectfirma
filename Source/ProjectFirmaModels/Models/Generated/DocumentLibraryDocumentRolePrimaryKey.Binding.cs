//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DocumentLibraryDocumentRole
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryDocumentRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DocumentLibraryDocumentRole>
    {
        public DocumentLibraryDocumentRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DocumentLibraryDocumentRolePrimaryKey(DocumentLibraryDocumentRole documentLibraryDocumentRole) : base(documentLibraryDocumentRole){}

        public static implicit operator DocumentLibraryDocumentRolePrimaryKey(int primaryKeyValue)
        {
            return new DocumentLibraryDocumentRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator DocumentLibraryDocumentRolePrimaryKey(DocumentLibraryDocumentRole documentLibraryDocumentRole)
        {
            return new DocumentLibraryDocumentRolePrimaryKey(documentLibraryDocumentRole);
        }
    }
}