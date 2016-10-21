//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureExpected
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureExpectedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureExpected>
    {
        public EIPPerformanceMeasureExpectedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureExpectedPrimaryKey(EIPPerformanceMeasureExpected eIPPerformanceMeasureExpected) : base(eIPPerformanceMeasureExpected){}

        public static implicit operator EIPPerformanceMeasureExpectedPrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureExpectedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureExpectedPrimaryKey(EIPPerformanceMeasureExpected eIPPerformanceMeasureExpected)
        {
            return new EIPPerformanceMeasureExpectedPrimaryKey(eIPPerformanceMeasureExpected);
        }
    }
}