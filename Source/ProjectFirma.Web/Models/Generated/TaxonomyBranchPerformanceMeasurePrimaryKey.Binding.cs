//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyBranchPerformanceMeasure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyBranchPerformanceMeasurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyBranchPerformanceMeasure>
    {
        public TaxonomyBranchPerformanceMeasurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyBranchPerformanceMeasurePrimaryKey(TaxonomyBranchPerformanceMeasure taxonomyBranchPerformanceMeasure) : base(taxonomyBranchPerformanceMeasure){}

        public static implicit operator TaxonomyBranchPerformanceMeasurePrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyBranchPerformanceMeasurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyBranchPerformanceMeasurePrimaryKey(TaxonomyBranchPerformanceMeasure taxonomyBranchPerformanceMeasure)
        {
            return new TaxonomyBranchPerformanceMeasurePrimaryKey(taxonomyBranchPerformanceMeasure);
        }
    }
}