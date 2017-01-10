using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyTierOne : IAuditableEntity
    {
        public string DisplayName
        {
            get { return string.Format("{0}", TaxonomyTierOneName); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyTierOne, TaxonomyTierOneID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public string ThemeColor
        {
            get { return TaxonomyTierTwo.ThemeColor; }
        }

        public static bool IsTaxonomyTierOneNameUnique(IEnumerable<TaxonomyTierOne> taxonomyTierOnes, string taxonomyTierOneName, int currentTaxonomyTierOneID)
        {
            var taxonomyTierOne =
                taxonomyTierOnes.SingleOrDefault(
                    x => x.TaxonomyTierOneID != currentTaxonomyTierOneID && String.Equals(x.TaxonomyTierOneName, taxonomyTierOneName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyTierOne == null;
        }

        public string AuditDescriptionString
        {
            get { return TaxonomyTierOneName; }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(this.GetSummaryUrl(), TaxonomyTierOneName)), TaxonomyTierOneID.ToString(), false)
            {
                ThemeColor = ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = Projects.Select(x => x.ToFancyTreeNode()).OrderBy(x => x.Title).ToList()
            };
            return fancyTreeNode;
        }
    }
}