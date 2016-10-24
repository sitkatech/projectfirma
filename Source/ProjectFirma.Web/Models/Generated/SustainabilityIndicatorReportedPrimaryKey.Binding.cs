//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityIndicatorReported
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityIndicatorReportedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityIndicatorReported>
    {
        public SustainabilityIndicatorReportedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityIndicatorReportedPrimaryKey(SustainabilityIndicatorReported sustainabilityIndicatorReported) : base(sustainabilityIndicatorReported){}

        public static implicit operator SustainabilityIndicatorReportedPrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityIndicatorReportedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityIndicatorReportedPrimaryKey(SustainabilityIndicatorReported sustainabilityIndicatorReported)
        {
            return new SustainabilityIndicatorReportedPrimaryKey(sustainabilityIndicatorReported);
        }
    }
}