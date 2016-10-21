//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorTargetValueType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class IndicatorTargetValueTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorTargetValueType>
    {
        public IndicatorTargetValueTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorTargetValueTypePrimaryKey(IndicatorTargetValueType indicatorTargetValueType) : base(indicatorTargetValueType){}

        public static implicit operator IndicatorTargetValueTypePrimaryKey(int primaryKeyValue)
        {
            return new IndicatorTargetValueTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorTargetValueTypePrimaryKey(IndicatorTargetValueType indicatorTargetValueType)
        {
            return new IndicatorTargetValueTypePrimaryKey(indicatorTargetValueType);
        }
    }
}