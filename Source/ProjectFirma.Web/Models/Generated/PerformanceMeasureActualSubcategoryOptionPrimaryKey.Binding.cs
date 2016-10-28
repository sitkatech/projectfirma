//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureActualSubcategoryOption
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureActualSubcategoryOption>
    {
        public PerformanceMeasureActualSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureActualSubcategoryOptionPrimaryKey(PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOption) : base(performanceMeasureActualSubcategoryOption){}

        public static implicit operator PerformanceMeasureActualSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureActualSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureActualSubcategoryOptionPrimaryKey(PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOption)
        {
            return new PerformanceMeasureActualSubcategoryOptionPrimaryKey(performanceMeasureActualSubcategoryOption);
        }
    }
}