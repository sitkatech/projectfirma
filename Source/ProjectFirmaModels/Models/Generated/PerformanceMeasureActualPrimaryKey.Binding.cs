//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureActual
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureActualPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureActual>
    {
        public PerformanceMeasureActualPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureActualPrimaryKey(PerformanceMeasureActual performanceMeasureActual) : base(performanceMeasureActual){}

        public static implicit operator PerformanceMeasureActualPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureActualPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureActualPrimaryKey(PerformanceMeasureActual performanceMeasureActual)
        {
            return new PerformanceMeasureActualPrimaryKey(performanceMeasureActual);
        }
    }
}