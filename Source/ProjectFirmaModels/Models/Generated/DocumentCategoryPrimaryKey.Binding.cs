//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DocumentCategory
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DocumentCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DocumentCategory>
    {
        public DocumentCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DocumentCategoryPrimaryKey(DocumentCategory documentCategory) : base(documentCategory){}

        public static implicit operator DocumentCategoryPrimaryKey(int primaryKeyValue)
        {
            return new DocumentCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator DocumentCategoryPrimaryKey(DocumentCategory documentCategory)
        {
            return new DocumentCategoryPrimaryKey(documentCategory);
        }
    }
}