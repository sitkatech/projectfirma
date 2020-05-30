//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DocumentLibraryDocumentCategory
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryDocumentCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DocumentLibraryDocumentCategory>
    {
        public DocumentLibraryDocumentCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DocumentLibraryDocumentCategoryPrimaryKey(DocumentLibraryDocumentCategory documentLibraryDocumentCategory) : base(documentLibraryDocumentCategory){}

        public static implicit operator DocumentLibraryDocumentCategoryPrimaryKey(int primaryKeyValue)
        {
            return new DocumentLibraryDocumentCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator DocumentLibraryDocumentCategoryPrimaryKey(DocumentLibraryDocumentCategory documentLibraryDocumentCategory)
        {
            return new DocumentLibraryDocumentCategoryPrimaryKey(documentLibraryDocumentCategory);
        }
    }
}