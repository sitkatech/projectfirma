using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.TransportationObjective
{
    public class IndexGridSpec : GridSpec<Models.TransportationObjective>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.TransportationStrategy.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TransportationStrategy.SummaryUrl, a.TransportationStrategy.TransportationStrategyName), 435);
            Add(Models.FieldDefinition.TransportationObjective.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.TransportationObjectiveName), 240, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.FundingType.ToGridHeaderString(), a => a.FundingType.FundingTypeDisplayName, 240, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}