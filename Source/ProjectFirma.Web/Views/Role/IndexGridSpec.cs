using ProjectFirma.Web.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Role
{
    public class IndexGridSpec : GridSpec<IRole>
    {
        public IndexGridSpec()
        {
            Add("Site Area", a => a.LTInfoAreaDisplayName, 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Role", a => a.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.Html);
            Add("Count", a => a.GetPeopleWithRole().Count, 50);
        }
    }
}