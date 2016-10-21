//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdReportingCategory
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ThresholdReportingCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdReportingCategory>
    {
        public ThresholdReportingCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdReportingCategoryPrimaryKey(ThresholdReportingCategory thresholdReportingCategory) : base(thresholdReportingCategory){}

        public static implicit operator ThresholdReportingCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ThresholdReportingCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdReportingCategoryPrimaryKey(ThresholdReportingCategory thresholdReportingCategory)
        {
            return new ThresholdReportingCategoryPrimaryKey(thresholdReportingCategory);
        }
    }
}