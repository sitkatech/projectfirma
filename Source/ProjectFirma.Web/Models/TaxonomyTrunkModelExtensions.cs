using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyTrunkModelExtensions
    {
        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this TaxonomyTrunk taxonomyTrunk)
        {
            return DetailUrlTemplate.ParameterReplace(taxonomyTrunk.TaxonomyTrunkID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(t => t.DeleteTaxonomyTrunk(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this TaxonomyTrunk taxonomyTrunk)
        {
            return DeleteUrlTemplate.ParameterReplace(taxonomyTrunk.TaxonomyTrunkID);
        }

        public static HtmlString GetDisplayNameAsUrl(this TaxonomyTrunk taxonomyTrunk)
        {
            return UrlTemplate.MakeHrefString(taxonomyTrunk.GetDetailUrl(), taxonomyTrunk.GetDisplayName());
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

        public static List<Project> GetAssociatedProjects(this TaxonomyTrunk taxonomyTrunk, Person currentPerson)
        {
            return taxonomyTrunk.TaxonomyBranches.SelectMany(x => x.TaxonomyLeafs.SelectMany(y => y.Projects)).ToList().GetActiveProjectsAndProposals(currentPerson.CanViewProposals());
        }

        public static FancyTreeNode ToFancyTreeNode(this TaxonomyTrunk taxonomyTrunk, FirmaSession currentFirmaSession)
        {
            var fancyTreeNode = new FancyTreeNode($"{UrlTemplate.MakeHrefString(taxonomyTrunk.GetDetailUrl(), taxonomyTrunk.GetDisplayName())}",
                taxonomyTrunk.TaxonomyTrunkID.ToString(), true)
            {
                ThemeColor = taxonomyTrunk.ThemeColor,
                MapUrl = taxonomyTrunk.GetCustomizedMapUrl(),
                Children = taxonomyTrunk.TaxonomyBranches.ToList().SortByOrderThenName().Select(x => x.ToFancyTreeNode(currentFirmaSession))
                    .ToList()
            };
            return fancyTreeNode;
        }
    }
}