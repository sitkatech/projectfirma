//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureExpectedSubcategoryOptionUpdate>
    {
        public PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey(PerformanceMeasureExpectedSubcategoryOptionUpdate performanceMeasureExpectedSubcategoryOptionUpdate) : base(performanceMeasureExpectedSubcategoryOptionUpdate){}

        public static implicit operator PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey(PerformanceMeasureExpectedSubcategoryOptionUpdate performanceMeasureExpectedSubcategoryOptionUpdate)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionUpdatePrimaryKey(performanceMeasureExpectedSubcategoryOptionUpdate);
        }
    }
}