//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureExpectedSubcategoryOption
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureExpectedSubcategoryOption>
    {
        public PerformanceMeasureExpectedSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureExpectedSubcategoryOptionPrimaryKey(PerformanceMeasureExpectedSubcategoryOption performanceMeasureExpectedSubcategoryOption) : base(performanceMeasureExpectedSubcategoryOption){}

        public static implicit operator PerformanceMeasureExpectedSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureExpectedSubcategoryOptionPrimaryKey(PerformanceMeasureExpectedSubcategoryOption performanceMeasureExpectedSubcategoryOption)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionPrimaryKey(performanceMeasureExpectedSubcategoryOption);
        }
    }
}