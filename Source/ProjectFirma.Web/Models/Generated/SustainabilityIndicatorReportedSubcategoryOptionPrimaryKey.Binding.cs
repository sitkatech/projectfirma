//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SustainabilityIndicatorReportedSubcategoryOption
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SustainabilityIndicatorReportedSubcategoryOption>
    {
        public SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey(SustainabilityIndicatorReportedSubcategoryOption sustainabilityIndicatorReportedSubcategoryOption) : base(sustainabilityIndicatorReportedSubcategoryOption){}

        public static implicit operator SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey(SustainabilityIndicatorReportedSubcategoryOption sustainabilityIndicatorReportedSubcategoryOption)
        {
            return new SustainabilityIndicatorReportedSubcategoryOptionPrimaryKey(sustainabilityIndicatorReportedSubcategoryOption);
        }
    }
}