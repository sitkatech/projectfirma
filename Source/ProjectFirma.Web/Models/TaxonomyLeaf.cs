/*-----------------------------------------------------------------------
<copyright file="TaxonomyLeaf.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyLeaf : IAuditableEntity, ITaxonomyTier, IHaveASortOrder
    {
        public int? SortOrder
        {
            get => TaxonomyLeafSortOrder;
            set => TaxonomyLeafSortOrder = value;
        }
        public int ID => TaxonomyLeafID;

        public string DisplayName
        {
            get
            {
                var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyLeafCode) ? string.Empty : $"{TaxonomyLeafCode}: ";
                return $"{taxonomyPrefix}{TaxonomyLeafName}";
            }
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return TaxonomyLeafModelExtensions.GetDisplayNameAsUrl(this);
        }
        public string SummaryUrl => this.GetSummaryUrl();

        public string CustomizedMapUrl => ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyLeaf, TaxonomyLeafID.ToString(), ProjectColorByType.ProjectStage);

        public int TaxonomyTierID => TaxonomyLeafID;

        public static bool IsTaxonomyLeafNameUnique(IEnumerable<TaxonomyLeaf> taxonomyLeafs, string taxonomyLeafName, int currentTaxonomyLeafID)
        {
            var taxonomyLeaf =
                taxonomyLeafs.SingleOrDefault(
                    x => x.TaxonomyLeafID != currentTaxonomyLeafID && String.Equals(x.TaxonomyLeafName, taxonomyLeafName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyLeaf == null;
        }

        public string AuditDescriptionString => TaxonomyLeafName;

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode($"{UrlTemplate.MakeHrefString(this.GetSummaryUrl(), DisplayName)}", TaxonomyLeafID.ToString(), false)
            {
                ThemeColor = string.IsNullOrWhiteSpace(ThemeColor) ? TaxonomyBranch.ThemeColor : ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = Projects.Select(x => x.ToFancyTreeNode()).OrderBy(x => x.Title).ToList()
            };
            return fancyTreeNode;
        }

        public List<Project> GetAssociatedProjects(Person currentPerson)
        {
            return Projects.ToList().GetActiveProjectsAndProposals(currentPerson.CanViewProposals);
        }

        public List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTierPerformanceMeasures()
        {
            return TaxonomyLeafPerformanceMeasures.GroupBy(x => x.PerformanceMeasure).ToList();
        }
    }
}
