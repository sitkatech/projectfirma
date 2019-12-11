//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureOverallTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureOverallTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureOverallTarget>
    {
        public PerformanceMeasureOverallTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureOverallTargetPrimaryKey(PerformanceMeasureOverallTarget performanceMeasureOverallTarget) : base(performanceMeasureOverallTarget){}

        public static implicit operator PerformanceMeasureOverallTargetPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureOverallTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureOverallTargetPrimaryKey(PerformanceMeasureOverallTarget performanceMeasureOverallTarget)
        {
            return new PerformanceMeasureOverallTargetPrimaryKey(performanceMeasureOverallTarget);
        }
    }
}