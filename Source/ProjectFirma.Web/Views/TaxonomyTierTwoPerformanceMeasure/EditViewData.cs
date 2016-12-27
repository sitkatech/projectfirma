using System.Collections.Generic;

namespace ProjectFirma.Web.Views.TaxonomyTierTwoPerformanceMeasure
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly List<Models.TaxonomyTierTwoSimple> AllTaxonomyTierTwos;
        public readonly Models.PerformanceMeasureSimple PerformanceMeasure;

        public EditViewData(Models.PerformanceMeasureSimple performanceMeasure, List<Models.TaxonomyTierTwoSimple> taxonomyTierTwos)
        {
            PerformanceMeasure = performanceMeasure;
            AllTaxonomyTierTwos = taxonomyTierTwos;
        }
    }
}