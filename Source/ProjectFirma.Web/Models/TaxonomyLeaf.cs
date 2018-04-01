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
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyLeaf : IAuditableEntity
    {
        public string DisplayName
        {
            get
            {
                var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyLeafCode) ? string.Empty : string.Format("{0}: ", TaxonomyLeafCode);
                return string.Format("{0}{1}", taxonomyPrefix, TaxonomyLeafName);
            }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyLeaf, TaxonomyLeafID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public string ThemeColor
        {
            get { return TaxonomyBranch.ThemeColor; }
        }

        public static bool IsTaxonomyLeafNameUnique(IEnumerable<TaxonomyLeaf> taxonomyLeafs, string taxonomyLeafName, int currentTaxonomyLeafID)
        {
            var taxonomyLeaf =
                taxonomyLeafs.SingleOrDefault(
                    x => x.TaxonomyLeafID != currentTaxonomyLeafID && String.Equals(x.TaxonomyLeafName, taxonomyLeafName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyLeaf == null;
        }

        public string AuditDescriptionString
        {
            get { return TaxonomyLeafName; }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(this.GetSummaryUrl(), DisplayName)), TaxonomyLeafID.ToString(), false)
            {
                ThemeColor = ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = Projects.Select(x => x.ToFancyTreeNode()).OrderBy(x => x.Title).ToList()
            };
            return fancyTreeNode;
        }

        public List<Project> GetAssociatedProjects(Person currentPerson)
        {
            return Projects.ToList().GetActiveProjectsAndProposals(currentPerson.CanViewProposals);
        }
    }
}
