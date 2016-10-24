using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ActionPriority
{
    public class IndexGridSpec : GridSpec<Models.ActionPriority>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30);
            }
            Add("#", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.DisplayNumber), 60, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.FocusArea.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Program.FocusArea.SummaryUrl, a.Program.FocusArea.FocusAreaName), 250);
            Add(Models.FieldDefinition.Program.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Program.SummaryUrl, a.Program.ProgramName), 300);
            Add(Models.FieldDefinition.ActionPriority.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.ActionPriorityName), 350, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}