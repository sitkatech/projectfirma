using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyTierTwoPerformanceMeasure
{
    public class EditViewModel : FormViewModel
    {
        public int? PrimaryTaxonomyTierTwoID { get; set; }
        public List<TaxonomyTierTwoPerformanceMeasureSimple> TaxonomyTierTwoPerformanceMeasures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(List<TaxonomyTierTwoPerformanceMeasureSimple> taxonomyTierTwoPerformanceMeasureSimples, int? primaryTaxonomyTierTwoID)
        {
            TaxonomyTierTwoPerformanceMeasures = taxonomyTierTwoPerformanceMeasureSimples;
            PrimaryTaxonomyTierTwoID = primaryTaxonomyTierTwoID;
        }

        public void UpdateModel(List<Models.TaxonomyTierTwoPerformanceMeasure> currentTaxonomyTierTwoPerformanceMeasures, IList<Models.TaxonomyTierTwoPerformanceMeasure> allTaxonomyTierTwoPerformanceMeasures)
        {
            var taxonomyTierTwoPerformanceMeasuresUpdated = new List<Models.TaxonomyTierTwoPerformanceMeasure>();
            if (TaxonomyTierTwoPerformanceMeasures != null)
            {
                // Completely rebuild the list
                taxonomyTierTwoPerformanceMeasuresUpdated = TaxonomyTierTwoPerformanceMeasures.Select(x => new Models.TaxonomyTierTwoPerformanceMeasure(x.TaxonomyTierTwoID, x.PerformanceMeasureID, false)).ToList();
            }
            currentTaxonomyTierTwoPerformanceMeasures.Merge(taxonomyTierTwoPerformanceMeasuresUpdated,
                allTaxonomyTierTwoPerformanceMeasures,
                (x, y) => x.TaxonomyTierTwoID == y.TaxonomyTierTwoID && x.PerformanceMeasureID == y.PerformanceMeasureID,
                (x, y) => x.IsPrimaryTaxonomyTierTwo = (PrimaryTaxonomyTierTwoID == x.TaxonomyTierTwoID));
        }
    }
}