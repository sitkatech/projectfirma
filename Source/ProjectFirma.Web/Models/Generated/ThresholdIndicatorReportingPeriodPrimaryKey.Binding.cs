//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdIndicatorReportingPeriod
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdIndicatorReportingPeriodPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdIndicatorReportingPeriod>
    {
        public ThresholdIndicatorReportingPeriodPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdIndicatorReportingPeriodPrimaryKey(ThresholdIndicatorReportingPeriod thresholdIndicatorReportingPeriod) : base(thresholdIndicatorReportingPeriod){}

        public static implicit operator ThresholdIndicatorReportingPeriodPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdIndicatorReportingPeriodPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdIndicatorReportingPeriodPrimaryKey(ThresholdIndicatorReportingPeriod thresholdIndicatorReportingPeriod)
        {
            return new ThresholdIndicatorReportingPeriodPrimaryKey(thresholdIndicatorReportingPeriod);
        }
    }
}