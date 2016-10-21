//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityIndicatorReportingPeriod
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityIndicatorReportingPeriodPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityIndicatorReportingPeriod>
    {
        public SustainabilityIndicatorReportingPeriodPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityIndicatorReportingPeriodPrimaryKey(SustainabilityIndicatorReportingPeriod sustainabilityIndicatorReportingPeriod) : base(sustainabilityIndicatorReportingPeriod){}

        public static implicit operator SustainabilityIndicatorReportingPeriodPrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityIndicatorReportingPeriodPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityIndicatorReportingPeriodPrimaryKey(SustainabilityIndicatorReportingPeriod sustainabilityIndicatorReportingPeriod)
        {
            return new SustainabilityIndicatorReportingPeriodPrimaryKey(sustainabilityIndicatorReportingPeriod);
        }
    }
}