//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdIndicatorReported
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdIndicatorReportedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdIndicatorReported>
    {
        public ThresholdIndicatorReportedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdIndicatorReportedPrimaryKey(ThresholdIndicatorReported thresholdIndicatorReported) : base(thresholdIndicatorReported){}

        public static implicit operator ThresholdIndicatorReportedPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdIndicatorReportedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdIndicatorReportedPrimaryKey(ThresholdIndicatorReported thresholdIndicatorReported)
        {
            return new ThresholdIndicatorReportedPrimaryKey(thresholdIndicatorReported);
        }
    }
}