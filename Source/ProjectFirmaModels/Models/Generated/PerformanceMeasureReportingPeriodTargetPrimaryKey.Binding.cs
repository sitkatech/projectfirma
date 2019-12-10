//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureReportingPeriodTarget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportingPeriodTargetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureReportingPeriodTarget>
    {
        public PerformanceMeasureReportingPeriodTargetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureReportingPeriodTargetPrimaryKey(PerformanceMeasureReportingPeriodTarget performanceMeasureReportingPeriodTarget) : base(performanceMeasureReportingPeriodTarget){}

        public static implicit operator PerformanceMeasureReportingPeriodTargetPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureReportingPeriodTargetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureReportingPeriodTargetPrimaryKey(PerformanceMeasureReportingPeriodTarget performanceMeasureReportingPeriodTarget)
        {
            return new PerformanceMeasureReportingPeriodTargetPrimaryKey(performanceMeasureReportingPeriodTarget);
        }
    }
}