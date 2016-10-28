//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureExpectedProposed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureExpectedProposedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureExpectedProposed>
    {
        public PerformanceMeasureExpectedProposedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureExpectedProposedPrimaryKey(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed) : base(performanceMeasureExpectedProposed){}

        public static implicit operator PerformanceMeasureExpectedProposedPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureExpectedProposedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureExpectedProposedPrimaryKey(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed)
        {
            return new PerformanceMeasureExpectedProposedPrimaryKey(performanceMeasureExpectedProposed);
        }
    }
}