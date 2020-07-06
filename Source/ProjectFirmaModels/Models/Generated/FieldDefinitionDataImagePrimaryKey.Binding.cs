//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FieldDefinitionDataImage
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FieldDefinitionDataImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FieldDefinitionDataImage>
    {
        public FieldDefinitionDataImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FieldDefinitionDataImagePrimaryKey(FieldDefinitionDataImage fieldDefinitionDataImage) : base(fieldDefinitionDataImage){}

        public static implicit operator FieldDefinitionDataImagePrimaryKey(int primaryKeyValue)
        {
            return new FieldDefinitionDataImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FieldDefinitionDataImagePrimaryKey(FieldDefinitionDataImage fieldDefinitionDataImage)
        {
            return new FieldDefinitionDataImagePrimaryKey(fieldDefinitionDataImage);
        }
    }
}