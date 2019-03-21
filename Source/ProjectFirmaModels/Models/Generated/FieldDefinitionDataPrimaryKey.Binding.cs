//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FieldDefinitionData
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FieldDefinitionDataPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FieldDefinitionData>
    {
        public FieldDefinitionDataPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FieldDefinitionDataPrimaryKey(FieldDefinitionData fieldDefinitionData) : base(fieldDefinitionData){}

        public static implicit operator FieldDefinitionDataPrimaryKey(int primaryKeyValue)
        {
            return new FieldDefinitionDataPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FieldDefinitionDataPrimaryKey(FieldDefinitionData fieldDefinitionData)
        {
            return new FieldDefinitionDataPrimaryKey(fieldDefinitionData);
        }
    }
}