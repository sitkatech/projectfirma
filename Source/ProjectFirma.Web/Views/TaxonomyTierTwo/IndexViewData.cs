using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetTaxonomyTierTwoDisplayNamePluralized();

            var hasTaxonomyTierTwoManagePermissions = new TaxonomyTierTwoManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTaxonomyTierTwoManagePermissions) { ObjectNameSingular = MultiTenantHelpers.GetTaxonomyTierTwoDisplayName(), ObjectNamePlural = MultiTenantHelpers.GetTaxonomyTierTwoDisplayNamePluralized(), SaveFiltersInCookie = true };

            if (hasTaxonomyTierTwoManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()));
            }

            GridName = "taxonomyTierTwosGrid";
            GridDataUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}