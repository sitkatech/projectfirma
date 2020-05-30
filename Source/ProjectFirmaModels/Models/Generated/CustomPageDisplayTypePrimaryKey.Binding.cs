//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CustomPageDisplayType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CustomPageDisplayTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CustomPageDisplayType>
    {
        public CustomPageDisplayTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CustomPageDisplayTypePrimaryKey(CustomPageDisplayType customPageDisplayType) : base(customPageDisplayType){}

        public static implicit operator CustomPageDisplayTypePrimaryKey(int primaryKeyValue)
        {
            return new CustomPageDisplayTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator CustomPageDisplayTypePrimaryKey(CustomPageDisplayType customPageDisplayType)
        {
            return new CustomPageDisplayTypePrimaryKey(customPageDisplayType);
        }
    }
}