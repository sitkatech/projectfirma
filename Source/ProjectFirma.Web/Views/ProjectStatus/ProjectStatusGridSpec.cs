using LtInfo.Common.DhtmlWrappers;
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

            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, DhtmlxGridColumnFilterType.None);
            Add("Name", a => a.ProjectStatusName, 200, DhtmlxGridColumnFilterType.Html);
            Add("Display Name", a => a.ProjectStatusDisplayName, 200, DhtmlxGridColumnFilterType.Text);
            Add("Description", a => a.ProjectStatusDescription, 300);
            Add("Color", a => a.ProjectStatusColor, 150, DhtmlxGridColumnFilterType.None);

        }
    }
}
