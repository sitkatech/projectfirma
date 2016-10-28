//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureExpectedSubcategoryOptionProposed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureExpectedSubcategoryOptionProposed>
    {
        public PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(PerformanceMeasureExpectedSubcategoryOptionProposed performanceMeasureExpectedSubcategoryOptionProposed) : base(performanceMeasureExpectedSubcategoryOptionProposed){}

        public static implicit operator PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(PerformanceMeasureExpectedSubcategoryOptionProposed performanceMeasureExpectedSubcategoryOptionProposed)
        {
            return new PerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(performanceMeasureExpectedSubcategoryOptionProposed);
        }
    }
}