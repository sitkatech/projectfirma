using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.TransportationStrategy
{
    public class IndexGridSpec : GridSpec<Models.TransportationStrategy>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }

            Add(Models.FieldDefinition.TransportationStrategy.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.TransportationStrategyName), 435);
            Add(Models.FieldDefinition.TransportationObjective.ToGridHeaderString(), a => new HtmlString(string.Join("<br/>", a.TransportationObjectives.OrderBy(x => x.TransportationObjectiveName).Select(x => x.DisplayNameAsUrl))), 240, DhtmlxGridColumnFilterType.Html);
            Add("# of Objectives", a => a.TransportationObjectives.Count, 100);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}