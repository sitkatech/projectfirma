//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class IndicatorTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorType>
    {
        public IndicatorTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorTypePrimaryKey(IndicatorType indicatorType) : base(indicatorType){}

        public static implicit operator IndicatorTypePrimaryKey(int primaryKeyValue)
        {
            return new IndicatorTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorTypePrimaryKey(IndicatorType indicatorType)
        {
            return new IndicatorTypePrimaryKey(indicatorType);
        }
    }
}