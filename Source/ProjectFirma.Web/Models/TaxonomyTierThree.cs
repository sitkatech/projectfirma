/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierThree.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyTierThree : IAuditableEntity, ITaxonomyTier
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(c => c.DeleteTaxonomyTierThree(TaxonomyTierThreeID)); }
        }

        public int TaxonomyTierID => TaxonomyTierThreeID;

        public string DisplayName
        {
            get
            {
                var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyTierThreeCode) ? string.Empty : string.Format("{0}: ", TaxonomyTierThreeCode);
                return string.Format("{0}{1}", taxonomyPrefix, TaxonomyTierThreeName);
            }
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName);
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(x => x.Detail(TaxonomyTierThreeID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TaxonomyTierThree, TaxonomyTierThreeID.ToString(), ProjectColorByType.ProjectStage); }
        }

        public ICollection<Project> Projects
        {
            get { return TaxonomyTierTwos.SelectMany(x => x.TaxonomyTierOnes.SelectMany(y => y.Projects)).ToList(); }
        }

        public static bool IsTaxonomyTierThreeNameUnique(IEnumerable<TaxonomyTierThree> taxonomyTierThrees, string taxonomyTierThreeName, int currentTaxonomyTierThreeID)
        {
            var taxonomyTierThree = taxonomyTierThrees.SingleOrDefault(x => x.TaxonomyTierThreeID != currentTaxonomyTierThreeID && String.Equals(x.TaxonomyTierThreeName, taxonomyTierThreeName, StringComparison.InvariantCultureIgnoreCase));
            return taxonomyTierThree == null;
        }

        public string AuditDescriptionString
        {
            get { return DisplayName; }
        }

        public List<TaxonomyTierOne> TaxonomyTierOnes
        {
            get { return TaxonomyTierTwos.SelectMany(x => x.TaxonomyTierOnes).OrderBy(x => x.TaxonomyTierOneName).ToList(); }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0}", UrlTemplate.MakeHrefString(SummaryUrl, DisplayName)), TaxonomyTierThreeID.ToString(), true)
            {
                ThemeColor = ThemeColor,
                MapUrl = CustomizedMapUrl,
                Children = TaxonomyTierTwos.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}
