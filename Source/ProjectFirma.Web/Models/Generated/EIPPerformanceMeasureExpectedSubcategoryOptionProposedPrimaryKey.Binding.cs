//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureExpectedSubcategoryOptionProposed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureExpectedSubcategoryOptionProposed>
    {
        public EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(EIPPerformanceMeasureExpectedSubcategoryOptionProposed eIPPerformanceMeasureExpectedSubcategoryOptionProposed) : base(eIPPerformanceMeasureExpectedSubcategoryOptionProposed){}

        public static implicit operator EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(EIPPerformanceMeasureExpectedSubcategoryOptionProposed eIPPerformanceMeasureExpectedSubcategoryOptionProposed)
        {
            return new EIPPerformanceMeasureExpectedSubcategoryOptionProposedPrimaryKey(eIPPerformanceMeasureExpectedSubcategoryOptionProposed);
        }
    }
}