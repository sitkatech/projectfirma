//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DocumentLibraryDocument
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryDocumentPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DocumentLibraryDocument>
    {
        public DocumentLibraryDocumentPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DocumentLibraryDocumentPrimaryKey(DocumentLibraryDocument documentLibraryDocument) : base(documentLibraryDocument){}

        public static implicit operator DocumentLibraryDocumentPrimaryKey(int primaryKeyValue)
        {
            return new DocumentLibraryDocumentPrimaryKey(primaryKeyValue);
        }

        public static implicit operator DocumentLibraryDocumentPrimaryKey(DocumentLibraryDocument documentLibraryDocument)
        {
            return new DocumentLibraryDocumentPrimaryKey(documentLibraryDocument);
        }
    }
}