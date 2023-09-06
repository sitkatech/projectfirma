using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStatus
{
    public class ProjectStatusGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectStatus>
    {
        public ProjectStatusGridSpec()
        {

            Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add("edit", x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, AgGridColumnFilterType.None);
            Add("Name", a => a.ProjectStatusName, 200, AgGridColumnFilterType.Html);
            Add("Display Name", a => a.ProjectStatusDisplayName, 200, AgGridColumnFilterType.Text);
            Add("Description", a => a.ProjectStatusDescription, 300);
            Add("Color", a => a.ProjectStatusColor, 150, AgGridColumnFilterType.None);

        }
    }
}
