using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class ResultsByTaxonomyTierTwoViewData : FirmaViewData
    {
        public readonly List<Models.TaxonomyTierThree> TaxonomyTierThrees;
        public readonly Models.TaxonomyTierTwo SelectedTaxonomyTierTwo;
        public readonly string ResultsByTaxonomyTierTwoUrl;
        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;

        public ResultsByTaxonomyTierTwoViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            List<Models.TaxonomyTierThree> taxonomyTierThrees,
            Models.TaxonomyTierTwo selectedTaxonomyTierTwo) : base(currentPerson, firmaPage, false)
        {
            TaxonomyTierThrees = taxonomyTierThrees;
            PageTitle = string.Format("Results by {0}", MultiTenantHelpers.GetTaxonomyTierTwoDisplayName());
            SelectedTaxonomyTierTwo = selectedTaxonomyTierTwo;
            ResultsByTaxonomyTierTwoUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ResultsByTaxonomyTierTwo(UrlTemplate.Parameter1Int));

            var projectIDs = selectedTaxonomyTierTwo.Projects.Select(y => y.ProjectID).ToList();
            PerformanceMeasureChartViewDatas =
                selectedTaxonomyTierTwo.GetPerformanceMeasures()
                    .ToList()
                    .Select(x => new PerformanceMeasureChartViewData(x, true, ChartViewMode.Small, projectIDs))
                    .ToList();
        }
    }
}