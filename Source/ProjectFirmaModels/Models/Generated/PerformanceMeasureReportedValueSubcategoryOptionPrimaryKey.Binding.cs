//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureReportedValueSubcategoryOption
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureReportedValueSubcategoryOption>
    {
        public PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey(PerformanceMeasureReportedValueSubcategoryOption performanceMeasureReportedValueSubcategoryOption) : base(performanceMeasureReportedValueSubcategoryOption){}

        public static implicit operator PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey(PerformanceMeasureReportedValueSubcategoryOption performanceMeasureReportedValueSubcategoryOption)
        {
            return new PerformanceMeasureReportedValueSubcategoryOptionPrimaryKey(performanceMeasureReportedValueSubcategoryOption);
        }
    }
}