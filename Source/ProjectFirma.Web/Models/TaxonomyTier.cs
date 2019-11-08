using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTier : IHavePrimaryKey
    {

        public int TaxonomyTierID { get; }
        public string ThemeColor { get; }
        public string DisplayName { get; }
        public HtmlString DisplayNameAsUrl { get; }

        public string DetailUrl { get; }

        public List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> TaxonomyTierPerformanceMeasures { get; }
        public int? SortOrder { get; }

        private TaxonomyLevelEnum TaxonomyLevel { get; }

        public TaxonomyLeaf TaxonomyLeaf { get; }
        public TaxonomyBranch TaxonomyBranch { get; }
        public TaxonomyTrunk TaxonomyTrunk { get; }

        public FancyTreeNode ToFancyTreeNode(FirmaSession currentFirmaSession)
        {
            switch (TaxonomyLevel)
            {
                case TaxonomyLevelEnum.Leaf:
                    return TaxonomyLeaf.ToFancyTreeNode(currentFirmaSession);
                case TaxonomyLevelEnum.Branch:
                    return TaxonomyBranch.ToFancyTreeNode(currentFirmaSession);
                case TaxonomyLevelEnum.Trunk:
                    return TaxonomyTrunk.ToFancyTreeNode(currentFirmaSession);
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
            TaxonomyLevel = TaxonomyLevelEnum.Leaf;
            TaxonomyLeaf = taxonomyLeaf;
            TaxonomyBranch = null;
            TaxonomyTrunk = null;
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
            TaxonomyLevel = TaxonomyLevelEnum.Branch;
            TaxonomyLeaf = null;
            TaxonomyBranch = taxonomyBranch;
            TaxonomyTrunk = null;
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
            TaxonomyLevel = TaxonomyLevelEnum.Trunk;
            TaxonomyLeaf = null;
            TaxonomyBranch = null;
            TaxonomyTrunk = taxonomyTrunk;
        }

        public int PrimaryKey => TaxonomyTierID;
    }
}