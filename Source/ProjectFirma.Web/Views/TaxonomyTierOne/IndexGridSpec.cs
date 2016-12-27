using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierOne>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30);
            }
            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()), a => UrlTemplate.MakeHrefString(a.TaxonomyTierTwo.TaxonomyTierThree.SummaryUrl, a.TaxonomyTierTwo.TaxonomyTierThree.TaxonomyTierThreeName), 250);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()), a => UrlTemplate.MakeHrefString(a.TaxonomyTierTwo.SummaryUrl, a.TaxonomyTierTwo.TaxonomyTierTwoName), 300);
            Add(Models.FieldDefinition.TaxonomyTierOne.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierOneDisplayName()), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.TaxonomyTierOneName), 350, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}