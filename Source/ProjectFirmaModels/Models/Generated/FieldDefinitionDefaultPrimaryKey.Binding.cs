//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FieldDefinitionDefault
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FieldDefinitionDefaultPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FieldDefinitionDefault>
    {
        public FieldDefinitionDefaultPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FieldDefinitionDefaultPrimaryKey(FieldDefinitionDefault fieldDefinitionDefault) : base(fieldDefinitionDefault){}

        public static implicit operator FieldDefinitionDefaultPrimaryKey(int primaryKeyValue)
        {
            return new FieldDefinitionDefaultPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FieldDefinitionDefaultPrimaryKey(FieldDefinitionDefault fieldDefinitionDefault)
        {
            return new FieldDefinitionDefaultPrimaryKey(fieldDefinitionDefault);
        }
    }
}