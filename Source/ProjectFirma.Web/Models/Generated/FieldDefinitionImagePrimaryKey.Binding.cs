//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FieldDefinitionImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class FieldDefinitionImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FieldDefinitionImage>
    {
        public FieldDefinitionImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FieldDefinitionImagePrimaryKey(FieldDefinitionImage fieldDefinitionImage) : base(fieldDefinitionImage){}

        public static implicit operator FieldDefinitionImagePrimaryKey(int primaryKeyValue)
        {
            return new FieldDefinitionImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FieldDefinitionImagePrimaryKey(FieldDefinitionImage fieldDefinitionImage)
        {
            return new FieldDefinitionImagePrimaryKey(fieldDefinitionImage);
        }
    }
}