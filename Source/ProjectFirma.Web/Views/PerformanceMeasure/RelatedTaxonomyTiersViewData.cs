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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class RelatedTaxonomyTiersViewData : FirmaUserControlViewData
    {
        public TaxonomyLevel AssociatePerformanceMeasureTaxonomyLevel { get; }
        public string TaxonomyTierDisplayNamePluralized { get; set; }
        public string TaxonomyTierDisplayName { get; set; }
        public string PerformanceMeasureDisplayName { get; set; }
        public IEnumerable<IGrouping<TaxonomyTier, TaxonomyLeafPerformanceMeasure>> TaxonomyLeafPerformanceMeasures { get; }
        public HtmlString TaxonomyTierHeaderDisplayName { get; }

        public RelatedTaxonomyTiersViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, TaxonomyLevel associatePerformanceMeasureTaxonomyLevel, bool showHelpLinks)
        {
            TaxonomyLeafPerformanceMeasures = performanceMeasure.GetTaxonomyTiers();
            PerformanceMeasureDisplayName = MultiTenantHelpers.GetPerformanceMeasureName();
            var fieldDefinitionForTaxonomyTier = associatePerformanceMeasureTaxonomyLevel.GetFieldDefinition();
            TaxonomyTierDisplayName = fieldDefinitionForTaxonomyTier.GetFieldDefinitionLabel();
            TaxonomyTierHeaderDisplayName = showHelpLinks
                ? LabelWithSugarForExtensions.LabelWithSugarFor(
                    fieldDefinitionForTaxonomyTier,
                    LabelWithSugarForExtensions.DisplayStyle.HelpIconWithLabel, TaxonomyTierDisplayName)
                : new HtmlString(TaxonomyTierDisplayName);
            TaxonomyTierDisplayNamePluralized = fieldDefinitionForTaxonomyTier.GetFieldDefinitionLabelPluralized();
            AssociatePerformanceMeasureTaxonomyLevel = associatePerformanceMeasureTaxonomyLevel;
        }
    }
}
