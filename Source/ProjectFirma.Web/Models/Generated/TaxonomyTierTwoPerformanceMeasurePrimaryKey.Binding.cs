//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTierTwoPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTierTwoPerformanceMeasure>
    {
        public TaxonomyTierTwoPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTierTwoPerformanceMeasurePrimaryKey(TaxonomyTierTwoPerformanceMeasure taxonomyTierTwoPerformanceMeasure) : base(taxonomyTierTwoPerformanceMeasure){}

        public static implicit operator TaxonomyTierTwoPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTierTwoPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTierTwoPerformanceMeasurePrimaryKey(TaxonomyTierTwoPerformanceMeasure taxonomyTierTwoPerformanceMeasure)
        {
            return new TaxonomyTierTwoPerformanceMeasurePrimaryKey(taxonomyTierTwoPerformanceMeasure);
        }
    }
}