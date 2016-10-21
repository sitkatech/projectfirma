using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Areas.EIP.Views.FocusArea
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Focus Areas";

            var hasFocusAreaManagePermissions = new FocusAreaManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasFocusAreaManagePermissions) {ObjectNameSingular = "Focus Area", ObjectNamePlural = "Focus Areas", SaveFiltersInCookie = true};
            if (hasFocusAreaManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<FocusAreaController>.BuildUrlFromExpression(t => t.New()), "Create a new Focus Area");
            }

            GridName = "focusAreasGrid";
            GridDataUrl = SitkaRoute<FocusAreaController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}