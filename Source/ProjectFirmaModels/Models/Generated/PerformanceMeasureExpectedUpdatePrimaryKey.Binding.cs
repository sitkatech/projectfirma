//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureExpectedUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureExpectedUpdate>
    {
        public PerformanceMeasureExpectedUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureExpectedUpdatePrimaryKey(PerformanceMeasureExpectedUpdate performanceMeasureExpectedUpdate) : base(performanceMeasureExpectedUpdate){}

        public static implicit operator PerformanceMeasureExpectedUpdatePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureExpectedUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureExpectedUpdatePrimaryKey(PerformanceMeasureExpectedUpdate performanceMeasureExpectedUpdate)
        {
            return new PerformanceMeasureExpectedUpdatePrimaryKey(performanceMeasureExpectedUpdate);
        }
    }
}