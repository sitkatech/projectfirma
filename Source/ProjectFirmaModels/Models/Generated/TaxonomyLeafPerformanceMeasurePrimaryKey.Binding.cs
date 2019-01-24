//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyLeafPerformanceMeasure
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyLeafPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyLeafPerformanceMeasure>
    {
        public TaxonomyLeafPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyLeafPerformanceMeasurePrimaryKey(TaxonomyLeafPerformanceMeasure taxonomyLeafPerformanceMeasure) : base(taxonomyLeafPerformanceMeasure){}

        public static implicit operator TaxonomyLeafPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyLeafPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyLeafPerformanceMeasurePrimaryKey(TaxonomyLeafPerformanceMeasure taxonomyLeafPerformanceMeasure)
        {
            return new TaxonomyLeafPerformanceMeasurePrimaryKey(taxonomyLeafPerformanceMeasure);
        }
    }
}