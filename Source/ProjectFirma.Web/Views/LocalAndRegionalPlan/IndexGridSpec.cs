using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.LocalAndRegionalPlan
{
    public class IndexGridSpec : GridSpec<Models.LocalAndRegionalPlan>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.LocalAndRegionalPlan.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.DisplayName), 550, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.AssociatedProjects.Count, 90);
        }
    }
}