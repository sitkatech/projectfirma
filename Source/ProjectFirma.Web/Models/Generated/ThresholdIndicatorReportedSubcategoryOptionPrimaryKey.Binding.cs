//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdIndicatorReportedSubcategoryOption
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdIndicatorReportedSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdIndicatorReportedSubcategoryOption>
    {
        public ThresholdIndicatorReportedSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdIndicatorReportedSubcategoryOptionPrimaryKey(ThresholdIndicatorReportedSubcategoryOption thresholdIndicatorReportedSubcategoryOption) : base(thresholdIndicatorReportedSubcategoryOption){}

        public static implicit operator ThresholdIndicatorReportedSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdIndicatorReportedSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdIndicatorReportedSubcategoryOptionPrimaryKey(ThresholdIndicatorReportedSubcategoryOption thresholdIndicatorReportedSubcategoryOption)
        {
            return new ThresholdIndicatorReportedSubcategoryOptionPrimaryKey(thresholdIndicatorReportedSubcategoryOption);
        }
    }
}