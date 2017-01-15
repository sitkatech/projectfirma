using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Watershed
{
    public class IndexGridSpec : GridSpec<Models.Watershed>
    {
        public IndexGridSpec()
        {
            Add(Models.FieldDefinition.Watershed.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.DisplayName), 300, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.AssociatedProjects.Count, 65);
        }
    }
}