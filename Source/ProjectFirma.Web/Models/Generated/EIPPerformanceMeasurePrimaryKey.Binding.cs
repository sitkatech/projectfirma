//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasure>
    {
        public EIPPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasurePrimaryKey(EIPPerformanceMeasure eIPPerformanceMeasure) : base(eIPPerformanceMeasure){}

        public static implicit operator EIPPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasurePrimaryKey(EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new EIPPerformanceMeasurePrimaryKey(eIPPerformanceMeasure);
        }
    }
}