using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.FirmaPage
{
    public class FirmaPageGridSpec : GridSpec<Models.FirmaPage>
    {
        public FirmaPageGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(a)),
                        string.Format("Edit Intro Content for '{0}'", a.FirmaPageType.FirmaPageTypeDisplayName))),
                    30);
            }
            Add("Page Name", a => UrlTemplate.MakeHrefString(a.FirmaPageType.GetViewUrl(), a.FirmaPageType.FirmaPageTypeDisplayName), 180, DhtmlxGridColumnFilterType.Text);
            Add("Has Content", a => a.HasFirmaPageContent.ToYesNo(), 85, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Type", a => a.FirmaPageType.FirmaPageRenderType.FirmaPageRenderTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("FirmaPageID", a => a.FirmaPageID, 0);
        }
    }
}