using ProjectFirma.Web.Areas.EIP.Controllers;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Areas.EIP.Views.Tag
{
    public class TagGridSpec : GridSpec<Models.Tag>
    {
        public TagGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add(string.Empty,
                    a => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(t => t.Edit(a.TagID)),
                        string.Format("Edit Tag'{0}'", a.TagName))),
                    30);
            }
            Add("Field", a => a.TagName, 300);
        }
    }
}