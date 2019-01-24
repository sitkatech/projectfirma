/*-----------------------------------------------------------------------
<copyright file="OrganizationAccomplishmentsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;

namespace ProjectFirma.Web.Views.Results
{
    public class OrganizationAccomplishmentsViewData
    {
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public ITaxonomyTier TaxonomyTier { get; }
        public string PerformanceMeasureDisplayName { get; }
        public string OrganizationDisplayName { get; }
        public string PerformanceMeasureDisplayNamePluralized { get; }
        public string TaxonomyTierDisplayName { get; }

        public OrganizationAccomplishmentsViewData(List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas, ITaxonomyTier taxonomyTier, TaxonomyLevel associatePerformanceMeasureTaxonomyLevel)
        {
            PerformanceMeasureChartViewDatas = performanceMeasureChartViewDatas;
            TaxonomyTier = taxonomyTier;
            TaxonomyTierDisplayName = associatePerformanceMeasureTaxonomyLevel.ToType().GetFieldDefinition().ToType().GetFieldDefinitionLabel();
            var fieldDefinitionForPerformanceMeasure = FieldDefinitionEnum.PerformanceMeasure;
            PerformanceMeasureDisplayName = fieldDefinitionForPerformanceMeasure.ToType().GetFieldDefinitionLabel();
            PerformanceMeasureDisplayNamePluralized = fieldDefinitionForPerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized();
            OrganizationDisplayName = FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel();
        }
    }
}
