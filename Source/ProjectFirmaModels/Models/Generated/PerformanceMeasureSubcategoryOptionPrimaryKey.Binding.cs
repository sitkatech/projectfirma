//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureSubcategoryOption
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureSubcategoryOption>
    {
        public PerformanceMeasureSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureSubcategoryOptionPrimaryKey(PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption) : base(performanceMeasureSubcategoryOption){}

        public static implicit operator PerformanceMeasureSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureSubcategoryOptionPrimaryKey(PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
        {
            return new PerformanceMeasureSubcategoryOptionPrimaryKey(performanceMeasureSubcategoryOption);
        }
    }
}