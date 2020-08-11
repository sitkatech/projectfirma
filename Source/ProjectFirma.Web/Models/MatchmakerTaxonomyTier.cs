using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class MatchmakerTaxonomyTier :  IHaveASortOrder
    {
        public int TaxonomyTierID { get; }
        public string DisplayName { get; }
        public int? SortOrder { get; set; }
        public List<MatchmakerTaxonomyTier> Children { get; }
        public List<MatchmakerTaxonomyTier> GrandChildren { get; }
        public int MaximumChildrenCount { get; }
        public int MaximumGrandChildrenCount { get; }
        private TaxonomyLevelEnum TaxonomyLevel { get; }
        public TaxonomyLeaf TaxonomyLeaf { get; }
        public TaxonomyBranch TaxonomyBranch { get; }
        public TaxonomyTrunk TaxonomyTrunk { get; }

        public ComboTreeNode ToComboTreeNode()
        {
            switch (TaxonomyLevel)
            {
                case TaxonomyLevelEnum.Leaf:
                    return TaxonomyLeaf.ToComboTreeNode();
                case TaxonomyLevelEnum.Branch:
                    return TaxonomyBranch.ToComboTreeNode();
                case TaxonomyLevelEnum.Trunk:
                    return TaxonomyTrunk.ToComboTreeNode();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string GetDisplayName()
        {
            return DisplayName.ToEllipsifiedString(50);
        }

        public void SetSortOrder(int? value)
        {
            SortOrder = value;
        }

        public int? GetSortOrder()
        {
            return SortOrder;
        }

        public int GetID()
        {
            return TaxonomyTierID;
        }

        public MatchmakerTaxonomyTier(TaxonomyLeaf taxonomyLeaf)
        {
            TaxonomyTierID = taxonomyLeaf.TaxonomyLeafID;
            DisplayName = taxonomyLeaf.GetDisplayName();
            SortOrder = taxonomyLeaf.TaxonomyLeafSortOrder;
            Children = null;
            TaxonomyLevel = TaxonomyLevelEnum.Leaf;
            TaxonomyLeaf = taxonomyLeaf;
            TaxonomyBranch = null;
            TaxonomyTrunk = null;
            MaximumChildrenCount = 0;
        }

        public MatchmakerTaxonomyTier(TaxonomyBranch taxonomyBranch, List<MatchmakerTaxonomyTier> leaves)
        {
            TaxonomyTierID = taxonomyBranch.TaxonomyBranchID;
            DisplayName = taxonomyBranch.GetDisplayName();
            SortOrder = taxonomyBranch.TaxonomyBranchSortOrder;
            Children = leaves;
            TaxonomyLevel = TaxonomyLevelEnum.Branch;
            TaxonomyLeaf = null;
            TaxonomyBranch = taxonomyBranch;
            TaxonomyTrunk = null;
            MaximumChildrenCount = taxonomyBranch.TaxonomyLeafs.Count;
        }

        public MatchmakerTaxonomyTier(TaxonomyTrunk taxonomyTrunk, List<MatchmakerTaxonomyTier> branches)
        {
            TaxonomyTierID = taxonomyTrunk.TaxonomyTrunkID;
            DisplayName = taxonomyTrunk.GetDisplayName();
            SortOrder = taxonomyTrunk.TaxonomyTrunkSortOrder;
            Children = branches;
            TaxonomyLevel = TaxonomyLevelEnum.Trunk;
            TaxonomyLeaf = null;
            TaxonomyBranch = null;
            TaxonomyTrunk = taxonomyTrunk;
            MaximumChildrenCount = taxonomyTrunk.TaxonomyBranches.Count;
        }

        public MatchmakerTaxonomyTier(TaxonomyTrunk taxonomyTrunk, List<MatchmakerTaxonomyTier> branches, List<MatchmakerTaxonomyTier> leaves)
        {
            TaxonomyTierID = taxonomyTrunk.TaxonomyTrunkID;
            DisplayName = taxonomyTrunk.GetDisplayName();
            SortOrder = taxonomyTrunk.TaxonomyTrunkSortOrder;
            Children = branches;
            GrandChildren = leaves;
            TaxonomyLevel = TaxonomyLevelEnum.Trunk;
            TaxonomyLeaf = null;
            TaxonomyBranch = null;
            TaxonomyTrunk = taxonomyTrunk;
            MaximumChildrenCount = taxonomyTrunk.TaxonomyBranches.Count;
            MaximumGrandChildrenCount = taxonomyTrunk.TaxonomyBranches.Sum(x => x.TaxonomyLeafs.Count);
        }

        public string GetTaxonomyTierCountText()
        {
            var countSelected = Children.Count;
            var message = $"{countSelected} selected";

            if (countSelected == MaximumChildrenCount)
            {
                switch (TaxonomyLevel)
                {
                    case TaxonomyLevelEnum.Trunk:
                        // children are branches
                        message = $"All {FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized()}";
                        break;
                    case TaxonomyLevelEnum.Branch:
                        // children are leaves
                        message = $"All {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized()}";
                        break;
                    case TaxonomyLevelEnum.Leaf:
                        // shouldn't be called
                        message = $"All {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized()}";
                        break;
                }
            }

            return message;
        }

        public static string GetTaxonomyTierCountText(int countSelected, int maximumChildrenCount, TaxonomyLevelEnum taxonomyLevel)
        {
            var message = $"{countSelected} selected";

            if (countSelected == maximumChildrenCount)
            {
                switch (taxonomyLevel)
                {
                    case TaxonomyLevelEnum.Trunk:
                        message = $"All {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabelPluralized()}";
                        break;
                    case TaxonomyLevelEnum.Branch:
                        message = $"All {FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized()}";
                        break;
                    case TaxonomyLevelEnum.Leaf:
                        message = $"All {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized()}";
                        break;
                }
            }

            return message;
        }
    }
}