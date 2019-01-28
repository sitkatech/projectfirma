using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTier
    {
        public int TaxonomyTierID { get; }
        public string ThemeColor { get; }
        public string DisplayName { get; }
        public HtmlString DisplayNameAsUrl { get; }

        public string DetailUrl { get; }

        public List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> TaxonomyTierPerformanceMeasures { get; }
        public int? SortOrder { get; }

        public FancyTreeNode ToFancyTreeNode(Person currentPerson)
        {
            return new FancyTreeNode("", "", false);
        }

        public TaxonomyTier(TaxonomyLeaf taxonomyLeaf)
        {
            TaxonomyTierID = taxonomyLeaf.TaxonomyLeafID;
            ThemeColor = taxonomyLeaf.ThemeColor;
            DisplayName = taxonomyLeaf.GetDisplayName();
            DisplayNameAsUrl = taxonomyLeaf.GetDisplayNameAsUrl();
            DetailUrl = taxonomyLeaf.GetDetailUrl();
            TaxonomyTierPerformanceMeasures = taxonomyLeaf.GetTaxonomyTierPerformanceMeasures();
            SortOrder = taxonomyLeaf.TaxonomyLeafSortOrder;
        }

        public TaxonomyTier(TaxonomyBranch taxonomyBranch)
        {
            TaxonomyTierID = taxonomyBranch.TaxonomyBranchID;
            ThemeColor = taxonomyBranch.ThemeColor;
            DisplayName = taxonomyBranch.GetDisplayName();
            DisplayNameAsUrl = taxonomyBranch.GetDisplayNameAsUrl();
            DetailUrl = taxonomyBranch.GetDetailUrl();
            TaxonomyTierPerformanceMeasures = taxonomyBranch.GetTaxonomyTierPerformanceMeasures();
            SortOrder = taxonomyBranch.TaxonomyBranchSortOrder;
        }

        public TaxonomyTier(TaxonomyTrunk taxonomyTrunk)
        {
            TaxonomyTierID = taxonomyTrunk.TaxonomyTrunkID;
            ThemeColor = taxonomyTrunk.ThemeColor;
            DisplayName = taxonomyTrunk.GetDisplayName();
            DisplayNameAsUrl = taxonomyTrunk.GetDisplayNameAsUrl();
            DetailUrl = taxonomyTrunk.GetDetailUrl();
            TaxonomyTierPerformanceMeasures = taxonomyTrunk.GetTaxonomyTierPerformanceMeasures();
            SortOrder = taxonomyTrunk.TaxonomyTrunkSortOrder;
        }
    }
}