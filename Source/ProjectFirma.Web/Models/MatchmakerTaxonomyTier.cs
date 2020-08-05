using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class MatchmakerTaxonomyTier :  IHaveASortOrder
    {

        public int TaxonomyTierID { get; }
        public string DisplayName { get; }
        public HtmlString DisplayNameAsHtmlString { get; }
        public int? SortOrder { get; set; }
        public bool IsSelected { get; set; }
        
        public List<MatchmakerTaxonomyTier> Children { get; }
        public string ChildrenAltText { get; }
        public bool IncludeAllChildrenByDefault { get; }

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
            return DisplayName;
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

        public MatchmakerTaxonomyTier(TaxonomyLeaf taxonomyLeaf, bool isSelected)
        {
            TaxonomyTierID = taxonomyLeaf.TaxonomyLeafID;
            DisplayName = taxonomyLeaf.GetDisplayName();
            DisplayNameAsHtmlString = new HtmlString($"{(isSelected ? "<span class='glyphicon glyphicon-check'></span>" : "")} {DisplayName}");
            SortOrder = taxonomyLeaf.TaxonomyLeafSortOrder;
            IsSelected = isSelected;
            Children = null;
            TaxonomyLevel = TaxonomyLevelEnum.Leaf;
            TaxonomyLeaf = taxonomyLeaf;
            TaxonomyBranch = null;
            TaxonomyTrunk = null;
        }

        public MatchmakerTaxonomyTier(TaxonomyBranch taxonomyBranch, bool isSelected, List<MatchmakerTaxonomyTier> leaves)
        {
            TaxonomyTierID = taxonomyBranch.TaxonomyBranchID;
            DisplayName = taxonomyBranch.GetDisplayName();
            DisplayNameAsHtmlString = new HtmlString($"{(isSelected ? "<span class='glyphicon glyphicon-check'></span>" : "")} {DisplayName}");
            SortOrder = taxonomyBranch.TaxonomyBranchSortOrder;
            IsSelected = isSelected;
            if (leaves == null)
            {
                IncludeAllChildrenByDefault = true;
                ChildrenAltText = $"All {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized()}";
            }
            Children = leaves;
            TaxonomyLevel = TaxonomyLevelEnum.Branch;
            TaxonomyLeaf = null;
            TaxonomyBranch = taxonomyBranch;
            TaxonomyTrunk = null;
        }

        public MatchmakerTaxonomyTier(TaxonomyTrunk taxonomyTrunk, bool isSelected, List<MatchmakerTaxonomyTier> branches)
        {
            TaxonomyTierID = taxonomyTrunk.TaxonomyTrunkID;
            DisplayName = taxonomyTrunk.GetDisplayName();
            DisplayNameAsHtmlString = new HtmlString($"{(isSelected ? "<span class='glyphicon glyphicon-check'></span>" : "")} {DisplayName}");
            SortOrder = taxonomyTrunk.TaxonomyTrunkSortOrder;
            IsSelected = isSelected;
            if (branches == null)
            {
                IncludeAllChildrenByDefault = true;
                ChildrenAltText = $"All {FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized()}";
            }
            Children = branches;
            TaxonomyLevel = TaxonomyLevelEnum.Trunk;
            TaxonomyLeaf = null;
            TaxonomyBranch = null;
            TaxonomyTrunk = taxonomyTrunk;
        }

    }
}