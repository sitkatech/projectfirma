//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureActual
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureActual>
    {
        public EIPPerformanceMeasureActualPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureActualPrimaryKey(EIPPerformanceMeasureActual eIPPerformanceMeasureActual) : base(eIPPerformanceMeasureActual){}

        public static implicit operator EIPPerformanceMeasureActualPrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureActualPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureActualPrimaryKey(EIPPerformanceMeasureActual eIPPerformanceMeasureActual)
        {
            return new EIPPerformanceMeasureActualPrimaryKey(eIPPerformanceMeasureActual);
        }
    }
}