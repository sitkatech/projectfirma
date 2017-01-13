using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierThree>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }

            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.TaxonomyTierThreeName), 240);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()), a => new HtmlString(string.Join("<br/>", a.TaxonomyTierTwos.Select(x => x.GetDisplayNameAsUrl()))), 340, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}