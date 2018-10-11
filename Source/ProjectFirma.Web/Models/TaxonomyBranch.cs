/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranch.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyBranch : IAuditableEntity, ITaxonomyTier, IHaveASortOrder
    {
        public int? SortOrder
        {
            get => TaxonomyBranchSortOrder;
            set => TaxonomyBranchSortOrder = value;
        }
        public int ID => TaxonomyBranchID;

        public string DeleteUrl
        {
            get { return SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(c => c.DeleteTaxonomyBranch(TaxonomyBranchID)); }
        }

        public List<Project> GetAssociatedProjects(Person person)
        {
            return TaxonomyLeafs.SelectMany(y => y.Projects).ToList().GetActiveProjectsAndProposals(person.CanViewProposals);
        }

        public int TaxonomyTierID => TaxonomyBranchID;

        public string DisplayName
        {
            get
            {
                var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyBranchCode) ? string.Empty : string.Format("{0}: ", TaxonomyBranchCode);
                return string.Format("{0}{1}", taxonomyPrefix, TaxonomyBranchName);
            }
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName);
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(x => x.Detail(TaxonomyBranchID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyBranch, TaxonomyBranchID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public static bool IsTaxonomyBranchNameUnique(IEnumerable<TaxonomyBranch> taxonomyBranches, string taxonomyBranchName, int currentTaxonomyBranchID)
        {
            var taxonomyBranch = taxonomyBranches.SingleOrDefault(x => x.TaxonomyBranchID != currentTaxonomyBranchID && String.Equals(x.TaxonomyBranchName, taxonomyBranchName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyBranch == null;
        }

        public string AuditDescriptionString => TaxonomyBranchName;

        public List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTierPerformanceMeasures()
        {
            return TaxonomyLeafs.SelectMany(x => x.TaxonomyLeafPerformanceMeasures).GroupBy(y => y.PerformanceMeasure).ToList();
        }

        public FancyTreeNode ToFancyTreeNode(Person currentPerson)
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(SummaryUrl, DisplayName)), TaxonomyBranchID.ToString(), false)
            {
                ThemeColor = string.IsNullOrWhiteSpace(ThemeColor) ? TaxonomyTrunk.ThemeColor : ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = TaxonomyLeafs.SortByOrderThenName().Select(x => x.ToFancyTreeNode(currentPerson)).ToList()
            };
            return fancyTreeNode;
        }
    }
}
