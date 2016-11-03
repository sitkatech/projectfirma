using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class IndexGridSpec : GridSpec<Models.FundingSource>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.FundingSource.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.DisplayName), 320, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.Organization.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Organization.GetSummaryUrl(), a.Organization.DisplayName), 300);
            Add(Models.FieldDefinition.Sector.ToGridHeaderString(), a => a.Organization.Sector.SectorDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.FundingSourceDescription.ToGridHeaderString(), a => a.FundingSourceDescription, 300);
            Add("Is Active", a => a.IsActive.ToYesNo(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("# of Projects", a => a.AssociatedProjects.Count, 90);
        }
    }
}