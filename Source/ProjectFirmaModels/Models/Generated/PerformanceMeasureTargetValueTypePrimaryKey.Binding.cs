//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureTargetValueType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureTargetValueTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureTargetValueType>
    {
        public PerformanceMeasureTargetValueTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureTargetValueTypePrimaryKey(PerformanceMeasureTargetValueType performanceMeasureTargetValueType) : base(performanceMeasureTargetValueType){}

        public static implicit operator PerformanceMeasureTargetValueTypePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureTargetValueTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureTargetValueTypePrimaryKey(PerformanceMeasureTargetValueType performanceMeasureTargetValueType)
        {
            return new PerformanceMeasureTargetValueTypePrimaryKey(performanceMeasureTargetValueType);
        }
    }
}