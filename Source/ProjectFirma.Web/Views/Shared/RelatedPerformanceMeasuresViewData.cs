/*-----------------------------------------------------------------------
<copyright file="RelatedTaxonomyTiersViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class RelatedPerformanceMeasuresViewData : FirmaUserControlViewData
    {
        public string PerformanceMeasureDisplayNamePluralized { get; set; }
        public string PerformanceMeasureDisplayName { get; set; }
        public IEnumerable<IGrouping<ProjectFirmaModels.Models.PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> TaxonomyTierPerformanceMeasures { get; }
        public HtmlString PerformanceMeasureHeaderDisplayName { get; }
        public HtmlString IsPrimaryTaxonomyTierHeaderDisplayName { get; }
        public string PerformanceMeasuresUrl { get; }
        public bool CanHaveAssociatedPerformanceMeasures { get; }

        public RelatedPerformanceMeasuresViewData(TaxonomyLevel associatePerformanceMeasureTaxonomyLevel, bool showHelpLinks, IEnumerable<IGrouping<ProjectFirmaModels.Models.PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> taxonomyTierPerformanceMeasures, bool canHaveAssociatedPerformanceMeasures)
        {
            CanHaveAssociatedPerformanceMeasures = canHaveAssociatedPerformanceMeasures;
            TaxonomyTierPerformanceMeasures = taxonomyTierPerformanceMeasures;
            var fieldDefinitionForPerformanceMeasure = FieldDefinitionEnum.PerformanceMeasure;
            PerformanceMeasureDisplayName = fieldDefinitionForPerformanceMeasure.ToType().GetFieldDefinitionLabel();
            PerformanceMeasureDisplayNamePluralized = fieldDefinitionForPerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized();
            PerformanceMeasureHeaderDisplayName = showHelpLinks
                ? LabelWithSugarForExtensions.LabelWithSugarFor(
                    fieldDefinitionForPerformanceMeasure, LabelWithSugarForExtensions.DefaultPopupWidth,
                    LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, PerformanceMeasureDisplayName)
                : new HtmlString(PerformanceMeasureDisplayName);
            var fieldDefinitionForTaxonomyTier = associatePerformanceMeasureTaxonomyLevel.ToType().GetFieldDefinition();
            var fieldDefinitionIsPrimaryTaxonomyBranch = FieldDefinitionEnum.IsPrimaryTaxonomyBranch;
            var isPrimaryTaxonomyBranchLabel = $"Is Primary {fieldDefinitionForTaxonomyTier.ToType().GetFieldDefinitionLabel()}";
            IsPrimaryTaxonomyTierHeaderDisplayName = showHelpLinks
                ? LabelWithSugarForExtensions.LabelWithSugarFor(
                    fieldDefinitionIsPrimaryTaxonomyBranch, LabelWithSugarForExtensions.DefaultPopupWidth,
                    LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, isPrimaryTaxonomyBranchLabel)
                : new HtmlString(isPrimaryTaxonomyBranchLabel);
            PerformanceMeasuresUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());
        }
    }
}
