using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.TaxonomyTierThree TaxonomyTierThree;
        public readonly bool UserHasTaxonomyTierThreeManagePermissions;
        public readonly bool UserHasProjectTaxonomyTierThreeExpenditureManagePermissions;
        public readonly string EditTaxonomyTierThreeUrl;
        public readonly string TaxonomyTierTwoIndexUrl;

        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;

        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public DetailViewData(Person currentPerson,
            Models.TaxonomyTierThree taxonomyTierThree,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyTierThree = taxonomyTierThree;

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            PageTitle = taxonomyTierThree.DisplayName;
            EntityName = MultiTenantHelpers.GetTaxonomyTierThreeDisplayName();
            IndexUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(c => c.Index());

            UserHasTaxonomyTierThreeManagePermissions = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(CurrentPerson);
            UserHasProjectTaxonomyTierThreeExpenditureManagePermissions = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(currentPerson);
            EditTaxonomyTierThreeUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(c => c.Edit(taxonomyTierThree.TaxonomyTierThreeID));
            TaxonomyTierTwoIndexUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.Index());

            BasicProjectInfoGridName = "taxonomyTierThreeProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = string.Format("Project with this {0}", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()),
                ObjectNamePlural = string.Format("Projects with this {0}", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()),
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTierThree));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTierThree);
        }
    }
}