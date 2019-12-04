//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureTarget>
    {
        public PerformanceMeasureTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureTargetPrimaryKey(PerformanceMeasureTarget performanceMeasureTarget) : base(performanceMeasureTarget){}

        public static implicit operator PerformanceMeasureTargetPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureTargetPrimaryKey(PerformanceMeasureTarget performanceMeasureTarget)
        {
            return new PerformanceMeasureTargetPrimaryKey(performanceMeasureTarget);
        }
    }
}