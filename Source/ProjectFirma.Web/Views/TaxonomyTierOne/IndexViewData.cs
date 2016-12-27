using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetTaxonomyTierOneDisplayNamePluralized();

            var hasTaxonomyTierOneManagePermissions = new TaxonomyTierOneManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTaxonomyTierOneManagePermissions)
            {
                ObjectNameSingular = MultiTenantHelpers.GetTaxonomyTierOneDisplayName(),
                ObjectNamePlural = MultiTenantHelpers.GetTaxonomyTierOneDisplayNamePluralized(),
                SaveFiltersInCookie = true
            };

            if (hasTaxonomyTierOneManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", MultiTenantHelpers.GetTaxonomyTierOneDisplayName()));
            }

            GridName = "taxonomyTierOnesGrid";
            GridDataUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}