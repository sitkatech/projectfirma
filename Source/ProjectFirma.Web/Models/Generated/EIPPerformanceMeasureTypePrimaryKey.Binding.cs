//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureType>
    {
        public EIPPerformanceMeasureTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureTypePrimaryKey(EIPPerformanceMeasureType eIPPerformanceMeasureType) : base(eIPPerformanceMeasureType){}

        public static implicit operator EIPPerformanceMeasureTypePrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureTypePrimaryKey(EIPPerformanceMeasureType eIPPerformanceMeasureType)
        {
            return new EIPPerformanceMeasureTypePrimaryKey(eIPPerformanceMeasureType);
        }
    }
}