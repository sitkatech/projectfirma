//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureExpectedProposed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureExpectedProposedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureExpectedProposed>
    {
        public EIPPerformanceMeasureExpectedProposedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureExpectedProposedPrimaryKey(EIPPerformanceMeasureExpectedProposed eIPPerformanceMeasureExpectedProposed) : base(eIPPerformanceMeasureExpectedProposed){}

        public static implicit operator EIPPerformanceMeasureExpectedProposedPrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureExpectedProposedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureExpectedProposedPrimaryKey(EIPPerformanceMeasureExpectedProposed eIPPerformanceMeasureExpectedProposed)
        {
            return new EIPPerformanceMeasureExpectedProposedPrimaryKey(eIPPerformanceMeasureExpectedProposed);
        }
    }
}