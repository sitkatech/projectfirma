using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierTwo>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }

            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()), a => UrlTemplate.MakeHrefString(a.TaxonomyTierThree.SummaryUrl, a.TaxonomyTierThree.TaxonomyTierThreeName), 210);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.TaxonomyTierTwoName), 240);
            Add(Models.FieldDefinition.TaxonomyTierOne.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierOneDisplayName()), a => new HtmlString(string.Join("<br/>", a.TaxonomyTierOnes.Select(x => x.GetDisplayNameAsUrl()))), 420, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}