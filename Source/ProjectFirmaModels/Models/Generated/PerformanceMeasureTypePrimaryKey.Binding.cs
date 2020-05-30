//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureType>
    {
        public PerformanceMeasureTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureTypePrimaryKey(PerformanceMeasureType performanceMeasureType) : base(performanceMeasureType){}

        public static implicit operator PerformanceMeasureTypePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureTypePrimaryKey(PerformanceMeasureType performanceMeasureType)
        {
            return new PerformanceMeasureTypePrimaryKey(performanceMeasureType);
        }
    }
}