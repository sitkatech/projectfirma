//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureActualSubcategoryOptionUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureActualSubcategoryOptionUpdate>
    {
        public PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(PerformanceMeasureActualSubcategoryOptionUpdate performanceMeasureActualSubcategoryOptionUpdate) : base(performanceMeasureActualSubcategoryOptionUpdate){}

        public static implicit operator PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(PerformanceMeasureActualSubcategoryOptionUpdate performanceMeasureActualSubcategoryOptionUpdate)
        {
            return new PerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(performanceMeasureActualSubcategoryOptionUpdate);
        }
    }
}