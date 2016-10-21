using ProjectFirma.Web.Areas.EIP.Views;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Watershed
{
    public class IndexViewData : SiteLayoutViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, false, projectFirmaPage, true)
        {
            PageTitle = "Watersheds";            
            GridSpec = new IndexGridSpec() {ObjectNameSingular = "Watershed", ObjectNamePlural = "Watersheds", SaveFiltersInCookie = true};

            // Neuter adding of watersheds for now till we handle syncing to the indicatorSubcategory Watershed
            //var hasWatershedManagePermissions = new WatershedManageFeature().HasPermissionByPerson(currentPerson);
            //if (hasWatershedManagePermissions)
            //{
            //    var contentUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(t => t.New());
            //    GridSpec.CreatePopupForm = new ModalDialogForm(contentUrl, "Create a new Watershed");
            //}

            GridName = "watershedsGrid";
            GridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}