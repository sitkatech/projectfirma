using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.TaxonomyTierTwo TaxonomyTierTwo;
        public readonly List<Models.PerformanceMeasure> PerformanceMeasures;
        public readonly int PerformanceMeasuresEndOfFirstHalf;

        public readonly bool UserHasTaxonomyTierTwoManagePermissions;
        public readonly string EditTaxonomyTierTwoUrl;
        public readonly string PerformanceMeasureUrl;

        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoProjectGridName;
        public readonly string BasicProjectInfoProjectGridDataUrl;

        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly List<Models.PerformanceMeasure> TaxonomyTierTwoPerformanceMeasures;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;

        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;

        public DetailViewData(Person currentPerson,
            Models.TaxonomyTierTwo taxonomyTierTwo,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyTierTwo = taxonomyTierTwo;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            PageTitle = taxonomyTierTwo.DisplayName;
            EntityName = MultiTenantHelpers.GetTaxonomyTierTwoDisplayName();
            new TaxonomyTierTwoPerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
            PerformanceMeasures = taxonomyTierTwo.TaxonomyTierTwoPerformanceMeasures.Select(x => x.PerformanceMeasure).ToList();
            PerformanceMeasuresEndOfFirstHalf = GeneralUtility.CalculateIndexOfEndOfFirstHalf(PerformanceMeasures.Count);

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            var projectIDs = TaxonomyTierTwo.Projects.Select(y => y.ProjectID).ToList();
            PerformanceMeasureChartViewDatas =
                TaxonomyTierTwo.GetPerformanceMeasures()
                    .ToList()
                    .Select(x => new PerformanceMeasureChartViewData(x, true, ChartViewMode.Small, projectIDs))
                    .ToList();

            UserHasTaxonomyTierTwoManagePermissions = new TaxonomyTierTwoManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyTierTwoUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.Edit(taxonomyTierTwo.TaxonomyTierTwoID));
            PerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());

            IndexUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.Index());

            BasicProjectInfoProjectGridName = "taxonomyTierTwoProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = string.Format("Project with this {0}", MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()),
                ObjectNamePlural = string.Format("Projects with this {0}", MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()),
                SaveFiltersInCookie = true
            };
            BasicProjectInfoProjectGridDataUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTierTwo));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTierTwo);

            TaxonomyTierTwoPerformanceMeasures = taxonomyTierTwo.GetPerformanceMeasures().OrderBy(x => x.PerformanceMeasureDisplayName).ToList();
        }
    }
}