//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureActualUpdate
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureActualUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureActualUpdate>
    {
        public EIPPerformanceMeasureActualUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureActualUpdatePrimaryKey(EIPPerformanceMeasureActualUpdate eIPPerformanceMeasureActualUpdate) : base(eIPPerformanceMeasureActualUpdate){}

        public static implicit operator EIPPerformanceMeasureActualUpdatePrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureActualUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureActualUpdatePrimaryKey(EIPPerformanceMeasureActualUpdate eIPPerformanceMeasureActualUpdate)
        {
            return new EIPPerformanceMeasureActualUpdatePrimaryKey(eIPPerformanceMeasureActualUpdate);
        }
    }
}