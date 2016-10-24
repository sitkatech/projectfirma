//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureActualSubcategoryOptionUpdate
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureActualSubcategoryOptionUpdate>
    {
        public EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(EIPPerformanceMeasureActualSubcategoryOptionUpdate eIPPerformanceMeasureActualSubcategoryOptionUpdate) : base(eIPPerformanceMeasureActualSubcategoryOptionUpdate){}

        public static implicit operator EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(EIPPerformanceMeasureActualSubcategoryOptionUpdate eIPPerformanceMeasureActualSubcategoryOptionUpdate)
        {
            return new EIPPerformanceMeasureActualSubcategoryOptionUpdatePrimaryKey(eIPPerformanceMeasureActualSubcategoryOptionUpdate);
        }
    }
}