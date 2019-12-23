//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureFixedTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureFixedTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureFixedTarget>
    {
        public PerformanceMeasureFixedTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureFixedTargetPrimaryKey(PerformanceMeasureFixedTarget performanceMeasureFixedTarget) : base(performanceMeasureFixedTarget){}

        public static implicit operator PerformanceMeasureFixedTargetPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureFixedTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureFixedTargetPrimaryKey(PerformanceMeasureFixedTarget performanceMeasureFixedTarget)
        {
            return new PerformanceMeasureFixedTargetPrimaryKey(performanceMeasureFixedTarget);
        }
    }
}