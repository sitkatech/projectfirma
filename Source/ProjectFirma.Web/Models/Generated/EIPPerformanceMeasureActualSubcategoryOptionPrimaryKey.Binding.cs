//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureActualSubcategoryOption
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureActualSubcategoryOption>
    {
        public EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey(EIPPerformanceMeasureActualSubcategoryOption eIPPerformanceMeasureActualSubcategoryOption) : base(eIPPerformanceMeasureActualSubcategoryOption){}

        public static implicit operator EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey(EIPPerformanceMeasureActualSubcategoryOption eIPPerformanceMeasureActualSubcategoryOption)
        {
            return new EIPPerformanceMeasureActualSubcategoryOptionPrimaryKey(eIPPerformanceMeasureActualSubcategoryOption);
        }
    }
}