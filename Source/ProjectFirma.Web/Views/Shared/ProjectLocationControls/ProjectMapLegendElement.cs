/*-----------------------------------------------------------------------
<copyright file="ProjectMapLegendElement.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapLegendElement
    {
        public readonly int LegendID;
        public readonly string LegendColor;
        public readonly string LegendText;

        public ProjectMapLegendElement(int legendID, string legendColor, string legendText)
        {
            LegendID = legendID;
            LegendColor = legendColor;
            LegendText = legendText;
        }

        public static Dictionary<string, List<ProjectMapLegendElement>> BuildLegendFormatDictionary(List<ITaxonomyTier> topLevelTaxonomyTiers, bool isCurrentUserAnonymous)
        {
            var legendFormats = new Dictionary<string, List<ProjectMapLegendElement>>
            {
                {
                    ProjectColorByType.ProjectStage.ProjectColorByTypeNameWithIdentifier,
                    ProjectMapCustomization.GetProjectStagesForMap(isCurrentUserAnonymous).Where(x => x.ShouldShowOnMap()).OrderBy(x => x.SortOrder).Select(x => new ProjectMapLegendElement(x.ProjectStageID, x.ProjectStageColor, x.ProjectStageDisplayName)).ToList()
                },
                {
                    MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3 ? ProjectColorByType.TaxonomyTierThree.ProjectColorByTypeNameWithIdentifier : ProjectColorByType.TaxonomyTierTwo.ProjectColorByTypeNameWithIdentifier,
                    topLevelTaxonomyTiers.Select(x => new ProjectMapLegendElement(x.TaxonomyTierID, x.ThemeColor, x.DisplayName)).ToList()
                }
            };

            return legendFormats;
        }
    }
}
