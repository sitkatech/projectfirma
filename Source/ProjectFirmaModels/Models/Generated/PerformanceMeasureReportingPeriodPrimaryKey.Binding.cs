//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureReportingPeriod
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportingPeriodPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureReportingPeriod>
    {
        public PerformanceMeasureReportingPeriodPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureReportingPeriodPrimaryKey(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod) : base(performanceMeasureReportingPeriod){}

        public static implicit operator PerformanceMeasureReportingPeriodPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureReportingPeriodPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureReportingPeriodPrimaryKey(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            return new PerformanceMeasureReportingPeriodPrimaryKey(performanceMeasureReportingPeriod);
        }
    }
}