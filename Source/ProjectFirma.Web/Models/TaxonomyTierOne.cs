/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierOne.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
    public partial class TaxonomyTierOne : IAuditableEntity
    {
        public string DisplayName
        {
            get
            {
                var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyTierOneCode) ? string.Empty : string.Format("{0}: ", TaxonomyTierOneCode);
                return string.Format("{0}{1}", taxonomyPrefix, TaxonomyTierOneName);
            }
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
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(this.GetSummaryUrl(), DisplayName)), TaxonomyTierOneID.ToString(), false)
            {
                ThemeColor = ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = Projects.Select(x => x.ToFancyTreeNode()).OrderBy(x => x.Title).ToList()
            };
            return fancyTreeNode;
        }
    }
}
