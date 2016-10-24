using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ProjectFirmaPage
{
    public class ProjectFirmaPageGridSpec : GridSpec<Models.ProjectFirmaPage>
    {
        public ProjectFirmaPageGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<ProjectFirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(a)),
                        string.Format("Edit Intro Content for '{0}'", a.ProjectFirmaPageType.ProjectFirmaPageTypeDisplayName))),
                    30);
            }
            Add("Page Name", a => UrlTemplate.MakeHrefString(a.ProjectFirmaPageType.GetViewUrl(), a.ProjectFirmaPageType.ProjectFirmaPageTypeDisplayName), 180, DhtmlxGridColumnFilterType.Text);
            Add("Has Content", a => a.HasProjectFirmaPageContent.ToYesNo(), 85, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Type", a => a.ProjectFirmaPageType.ProjectFirmaPageRenderType.ProjectFirmaPageRenderTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("ProjectFirmaPageID", a => a.ProjectFirmaPageID, 0);
        }
    }
}