//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureExpected
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureExpectedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureExpectedPrimaryKey(PerformanceMeasureExpected performanceMeasureExpected) : base(performanceMeasureExpected){}

        public static implicit operator PerformanceMeasureExpectedPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureExpectedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureExpectedPrimaryKey(PerformanceMeasureExpected performanceMeasureExpected)
        {
            return new PerformanceMeasureExpectedPrimaryKey(performanceMeasureExpected);
        }
    }
}