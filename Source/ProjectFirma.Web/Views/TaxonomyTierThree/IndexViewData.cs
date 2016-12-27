using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetTaxonomyTierThreeDisplayNamePluralized();

            var hasTaxonomyTierThreeManagePermissions = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTaxonomyTierThreeManagePermissions) { ObjectNameSingular = MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(), ObjectNamePlural = MultiTenantHelpers.GetTaxonomyTierThreeDisplayNamePluralized(), SaveFiltersInCookie = true };
            if (hasTaxonomyTierThreeManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()));
            }

            GridName = "taxonomyTierThreesGrid";
            GridDataUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}