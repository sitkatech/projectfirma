using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyTrunkModelExtensions
    {
        public static string GetDeleteUrl(TaxonomyTrunk taxonomyTrunk)
        {
            return SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(c => c.DeleteTaxonomyTrunk(taxonomyTrunk.TaxonomyTrunkID));
        }

        public static HtmlString GetDisplayNameAsUrl(TaxonomyTrunk taxonomyTrunk)
        {
            return UrlTemplate.MakeHrefString(taxonomyTrunk.GetDetailUrl(), taxonomyTrunk.GetDisplayName());
        }

        public static string GetDetailUrl(TaxonomyTrunk taxonomyTrunk)
        {
            return SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(x => x.Detail(taxonomyTrunk.TaxonomyTrunkID));
        }

        public static bool IsTaxonomyTrunkNameUnique(this IEnumerable<TaxonomyTrunk> taxonomyTrunks, string taxonomyTrunkName, int currentTaxonomyTrunkID)
        {
            var taxonomyTrunk = taxonomyTrunks.SingleOrDefault(x => x.TaxonomyTrunkID != currentTaxonomyTrunkID && String.Equals(x.TaxonomyTrunkName, taxonomyTrunkName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyTrunk == null;
        }

        public static string GetCustomizedMapUrl(this TaxonomyTrunk taxonomyTrunk)
        {
            return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyTrunk, taxonomyTrunk.TaxonomyTrunkID.ToString(), ProjectColorByType.ProjectStage);
        }

        public static FancyTreeNode ToFancyTreeNode(TaxonomyTrunk taxonomyTrunk, Person currentPerson)
        {
            var fancyTreeNode = new FancyTreeNode($"{UrlTemplate.MakeHrefString(taxonomyTrunk.GetDetailUrl(), taxonomyTrunk.GetDisplayName())}",
                taxonomyTrunk.TaxonomyTrunkID.ToString(), true)
            {
                ThemeColor = taxonomyTrunk.ThemeColor,
                MapUrl = taxonomyTrunk.GetCustomizedMapUrl(),
                Children = taxonomyTrunk.TaxonomyBranches.ToList().SortByOrderThenName().Select(x => x.ToFancyTreeNode(currentPerson))
                    .ToList()
            };
            return fancyTreeNode;
        }
    }
}