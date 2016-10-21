using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class IndexGridSpec : GridSpec<Models.MonitoringProgram>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.MonitoringProgram.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.DisplayName), 450, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MonitoringProgramUrl.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.MonitoringProgramUrl, a.MonitoringProgramUrl), 200, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MonitoringApproach.ToGridHeaderString(), a => a.MonitoringApproach, 450);
            Add("# of Partners", a => a.MonitoringProgramPartners.Count, 90);
        }
    }
}