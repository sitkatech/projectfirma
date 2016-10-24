using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Program
{
    public class IndexGridSpec : GridSpec<Models.Program>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }

            Add("#", a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.DisplayNumber), 60, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.FocusArea.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.FocusArea.SummaryUrl, a.FocusArea.FocusAreaName), 210);
            Add(Models.FieldDefinition.Program.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.ProgramName), 240);
            Add(Models.FieldDefinition.ActionPriority.ToGridHeaderString(), a => new HtmlString(string.Join("<br/>", a.ActionPriorities.Select(x => x.GetDisplayNameAsUrl()))), 420, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}