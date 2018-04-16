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
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyLeafModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return UrlTemplate.MakeHrefString(taxonomyLeaf.GetSummaryUrl(), taxonomyLeaf.DisplayName);
        }

        public static string GetSummaryUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(x =>
                x.Detail(taxonomyLeaf.TaxonomyLeafID));
        }

        public static string GetDeleteUrl(this TaxonomyLeaf taxonomyLeaf)
        {
            return SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(c =>
                c.DeleteTaxonomyLeaf(taxonomyLeaf.TaxonomyLeafID));
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
                    .OrderBy(x => x.Key.TaxonomyBranchSortOrder).ThenBy(x=>x.Key.DisplayName))
                {
                    var taxonomyBranch = taxonomyBranchGrouping.Key;
                    var selectListGroup = new SelectListGroup {Name = taxonomyBranch.DisplayName};
                    groups.Add(taxonomyBranch.DisplayName, selectListGroup);

                    foreach (var taxonomyLeaf in taxonomyBranchGrouping.OrderBy(x => x.TaxonomyLeafSortOrder).ThenBy(x=>x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem
                        {
                            Value = taxonomyLeaf.TaxonomyLeafID.ToString(),
                            Text = taxonomyLeaf.DisplayName,
                            Group = selectListGroup
                        });
                    }
                }
            }
            else
            {
                return taxonomyLeafs.SortByOrderThenName().ToSelectListWithEmptyFirstRow(m => m.TaxonomyLeafID.ToString(), m => m.DisplayName,
                    $"Select the {MultiTenantHelpers.GetTaxonomyLeafDisplayNameForProject()}");
            }

            return selectListItems;
        }

        private static void BuildThreeTierSelectList(List<TaxonomyLeaf> taxonomyLeafs,
            Dictionary<string, SelectListGroup> groups, List<SelectListItem> selectListItems)
        {
            foreach (var taxonomyTrunkGrouping in taxonomyLeafs.GroupBy(x => x.TaxonomyBranch.TaxonomyTrunk)
                .OrderBy(x => x.Key.TaxonomyTrunkSortOrder).ThenBy(x=>x.Key.DisplayName))
            {
                foreach (var taxonomyBranchGrouping in taxonomyTrunkGrouping.GroupBy(x => x.TaxonomyBranch)
                    .OrderBy(x => x.Key.TaxonomyBranchSortOrder).ThenBy(x => x.Key.DisplayName))
                {
                    var taxonomyBranch = taxonomyBranchGrouping.Key;
                    var displayName = $"{taxonomyBranch.TaxonomyTrunk.DisplayName} - {taxonomyBranch.DisplayName}";
                    var selectListGroup = new SelectListGroup() {Name = displayName};
                    groups.Add(displayName, selectListGroup);

                    foreach (var taxonomyLeaf in taxonomyBranchGrouping.OrderBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem()
                        {
                            Value = taxonomyLeaf.TaxonomyLeafID.ToString(),
                            Text = taxonomyLeaf.DisplayName,
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
                        .ThenBy(x => x.TaxonomyBranch.TaxonomyTrunk.DisplayName)
                        .ThenBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder).ThenBy(x => x.TaxonomyBranch.DisplayName)
                        .ThenBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.DisplayName);
                case TaxonomyLevelEnum.Branch:
                    return taxonomyLeaves.OrderBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder)
                        .ThenBy(x => x.TaxonomyBranch.DisplayName)
                        .ThenBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.DisplayName);
                case TaxonomyLevelEnum.Leaf:
                    return taxonomyLeaves.OrderBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.DisplayName);
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
                        .ThenBy(x => x.TaxonomyTrunk.DisplayName)
                        .ThenBy(x => x.TaxonomyBranchSortOrder).ThenBy(x => x.DisplayName);
                case TaxonomyLevelEnum.Branch:
                    return taxonomyBranches.OrderBy(x => x.TaxonomyBranchSortOrder)
                        .ThenBy(x => x.DisplayName);
                default:
                    // why are u sorting taxonomy branches if the taxonomy level is leaf?
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}