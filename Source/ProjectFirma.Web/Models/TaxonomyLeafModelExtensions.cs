/*-----------------------------------------------------------------------
<copyright file="TaxonomyLeafModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyLeafModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return UrlTemplate.MakeHrefString(taxonomyLeaf.GetDetailUrl(), taxonomyLeaf.GetDisplayName());
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return DetailUrlTemplate.ParameterReplace(taxonomyLeaf.TaxonomyLeafID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(t => t.DeleteTaxonomyLeaf(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return DeleteUrlTemplate.ParameterReplace(taxonomyLeaf.TaxonomyLeafID);
        }

        public static List<Project> GetAssociatedProjects(this TaxonomyLeaf taxonomyLeaf, FirmaSession currentFirmaSession)
        {
            return taxonomyLeaf.Projects.ToList().GetActiveProjectsAndProposals(currentFirmaSession.Person.CanViewProposals());
        }

        public static List<Project> GetAssociatedPrimaryAndSecondaryProjects(this TaxonomyLeaf taxonomyLeaf, FirmaSession currentFirmaSession)
        {
            return taxonomyLeaf.Projects
                .Union(taxonomyLeaf.SecondaryProjectTaxonomyLeafs.Select(x => x.Project))
                .Distinct(new HavePrimaryKeyComparer<Project>())
                .ToList()
                .GetActiveProjectsAndProposals(currentFirmaSession.Person.CanViewProposals());
        }

        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<TaxonomyLeaf> taxonomyLeafs)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();

            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                BuildThreeTierSelectList(taxonomyLeafs, groups, selectListItems);
            }
            else if (MultiTenantHelpers.IsTaxonomyLevelBranch())
            {
                foreach (var taxonomyBranchGrouping in taxonomyLeafs.GroupBy(x => x.TaxonomyBranch)
                    .OrderBy(x => x.Key.TaxonomyBranchSortOrder).ThenBy(x=>x.Key.GetDisplayName()))
                {
                    var taxonomyBranch = taxonomyBranchGrouping.Key;
                    var selectListGroup = new SelectListGroup {Name = taxonomyBranch.GetDisplayName()};
                    groups.Add(taxonomyBranch.GetDisplayName(), selectListGroup);

                    foreach (var taxonomyLeaf in taxonomyBranchGrouping.OrderBy(x => x.TaxonomyLeafSortOrder).ThenBy(x=>x.GetDisplayName()))
                    {
                        selectListItems.Add(new SelectListItem
                        {
                            Value = taxonomyLeaf.TaxonomyLeafID.ToString(),
                            Text = taxonomyLeaf.GetDisplayName(),
                            Group = selectListGroup
                        });
                    }
                }
            }
            else
            {
                return taxonomyLeafs.SortByOrderThenName().ToSelectListWithEmptyFirstRow(m => m.TaxonomyLeafID.ToString(), m => m.GetDisplayName(),
                    $"Select the {MultiTenantHelpers.GetTaxonomyLeafDisplayNameForProject()}");
            }

            return selectListItems;
        }

        private static void BuildThreeTierSelectList(List<TaxonomyLeaf> taxonomyLeafs,
            Dictionary<string, SelectListGroup> groups, List<SelectListItem> selectListItems)
        {
            foreach (var taxonomyTrunkGrouping in taxonomyLeafs.GroupBy(x => x.TaxonomyBranch.TaxonomyTrunk)
                .OrderBy(x => x.Key.TaxonomyTrunkSortOrder).ThenBy(x=>x.Key.GetDisplayName()))
            {
                foreach (var taxonomyBranchGrouping in taxonomyTrunkGrouping.GroupBy(x => x.TaxonomyBranch)
                    .OrderBy(x => x.Key.TaxonomyBranchSortOrder).ThenBy(x => x.Key.GetDisplayName()))
                {
                    var taxonomyBranch = taxonomyBranchGrouping.Key;
                    var displayName = $"{taxonomyBranch.TaxonomyTrunk.GetDisplayName()} - {taxonomyBranch.GetDisplayName()}";
                    var selectListGroup = new SelectListGroup() {Name = displayName};
                    groups.Add(displayName, selectListGroup);

                    foreach (var taxonomyLeaf in taxonomyBranchGrouping.OrderBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.GetDisplayName()))
                    {
                        selectListItems.Add(new SelectListItem()
                        {
                            Value = taxonomyLeaf.TaxonomyLeafID.ToString(),
                            Text = taxonomyLeaf.GetDisplayName(),
                            Group = selectListGroup
                        });
                    }
                }
            }
        }

        public static IEnumerable<TaxonomyLeaf> OrderTaxonomyLeaves(this List<TaxonomyLeaf> taxonomyLeaves)
        {
            switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
            {
                case TaxonomyLevelEnum.Trunk:
                    return taxonomyLeaves.OrderBy(x => x.TaxonomyBranch.TaxonomyTrunk.TaxonomyTrunkSortOrder)
                        .ThenBy(x => x.TaxonomyBranch.TaxonomyTrunk.GetDisplayName())
                        .ThenBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder).ThenBy(x => x.TaxonomyBranch.GetDisplayName())
                        .ThenBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.GetDisplayName());
                case TaxonomyLevelEnum.Branch:
                    return taxonomyLeaves.OrderBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder)
                        .ThenBy(x => x.TaxonomyBranch.GetDisplayName())
                        .ThenBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.GetDisplayName());
                case TaxonomyLevelEnum.Leaf:
                    return taxonomyLeaves.OrderBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.GetDisplayName());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static IEnumerable<TaxonomyBranch> OrderTaxonomyBranches(this List<TaxonomyBranch> taxonomyBranches)
        {
            switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
            {
                case TaxonomyLevelEnum.Trunk:
                    return taxonomyBranches.OrderBy(x => x.TaxonomyTrunk.TaxonomyTrunkSortOrder)
                        .ThenBy(x => x.TaxonomyTrunk.GetDisplayName())
                        .ThenBy(x => x.TaxonomyBranchSortOrder).ThenBy(x => x.GetDisplayName());
                case TaxonomyLevelEnum.Branch:
                    return taxonomyBranches.OrderBy(x => x.TaxonomyBranchSortOrder)
                        .ThenBy(x => x.GetDisplayName());
                default:
                    // why are u sorting taxonomy branches if the taxonomy level is leaf?
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetCustomizedMapUrl(TaxonomyLeaf taxonomyLeaf) => ProjectMapCustomization.BuildCustomizedUrl(
            ProjectLocationFilterType.TaxonomyLeaf, taxonomyLeaf.TaxonomyLeafID.ToString(), ProjectColorByType.ProjectStage);

        public static bool IsTaxonomyLeafNameUnique(IEnumerable<TaxonomyLeaf> taxonomyLeafs, string taxonomyLeafName, int currentTaxonomyLeafID)
        {
            var taxonomyLeaf =
                taxonomyLeafs.SingleOrDefault(
                    x => x.TaxonomyLeafID != currentTaxonomyLeafID && String.Equals(x.TaxonomyLeafName, taxonomyLeafName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyLeaf == null;
        }

        public static FancyTreeNode ToFancyTreeNode(this TaxonomyLeaf taxonomyLeaf, FirmaSession currentFirmaSession)
        {
            var fancyTreeNode = new FancyTreeNode($"{UrlTemplate.MakeHrefString(taxonomyLeaf.GetDetailUrl(), taxonomyLeaf.GetDisplayName())}",
                taxonomyLeaf.TaxonomyLeafID.ToString(), false)
            {
                ThemeColor = String.IsNullOrWhiteSpace(taxonomyLeaf.ThemeColor) ? taxonomyLeaf.TaxonomyBranch.ThemeColor : taxonomyLeaf.ThemeColor,
                MapUrl = GetCustomizedMapUrl(taxonomyLeaf),
                Children = taxonomyLeaf.GetAssociatedProjects(currentFirmaSession).Select(x => x.ToFancyTreeNode()).OrderBy(x => x.Title).ToList()
            };
            return fancyTreeNode;
        }

        public static string GetTaxonomyLeafCodeAndName(this TaxonomyLeaf taxonomyLeaf)
        {
            if(taxonomyLeaf.TaxonomyLeafCode != null) { 
                return taxonomyLeaf.TaxonomyLeafCode + ": " + taxonomyLeaf.TaxonomyLeafName;
            }

            return taxonomyLeaf.TaxonomyLeafName;
        }

        public static string GetTaxonomyBranchCodeAndName(this TaxonomyLeaf taxonomyLeaf)
        {
            if (taxonomyLeaf.TaxonomyBranch.TaxonomyBranchCode != null)
            {
                return taxonomyLeaf.TaxonomyBranch.TaxonomyBranchCode + ": " + taxonomyLeaf.TaxonomyBranch.TaxonomyBranchName;
            }
                return taxonomyLeaf.TaxonomyBranch.TaxonomyBranchName;
        }
    }
}