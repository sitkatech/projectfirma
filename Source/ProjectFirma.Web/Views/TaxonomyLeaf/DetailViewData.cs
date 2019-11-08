/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.TaxonomyLeaf
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.TaxonomyLeaf TaxonomyLeaf { get; }
        public bool UserHasTaxonomyLeafManagePermissions { get; }
        public string EditTaxonomyLeafUrl { get; }
        public string IndexUrl { get; }

        public ProjectForTaxonomyLeafGridSpec BasicProjectInfoGridSpec { get; }
        public string SecondaryBasicProjectInfoGridName { get; }
        public string SecondaryBasicProjectInfoGridDataUrl { get; set; }
        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public ProjectLocationsMapInitJson PrimaryProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData PrimaryProjectLocationsMapViewData { get; }
        public ProjectLocationsMapInitJson SecondaryProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData SecondaryProjectLocationsMapViewData { get; }
        public string ProjectMapFilteredUrl { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string TaxonomyLeafDisplayNamePluralized { get; }

        public bool CanHaveAssociatedPerformanceMeasures { get; }
        public RelatedPerformanceMeasuresViewData RelatedPerformanceMeasuresViewData { get; }
        public TenantAttribute TenantAttribute { get; }
        public IEnumerable<ProjectFirmaModels.Models.PerformanceMeasure> PerformanceMeasures { get; }
        public Dictionary<int, PerformanceMeasureChartViewData> PrimaryPerformanceMeasureChartViewDataByPerformanceMeasure { get; }
        public Dictionary<int, PerformanceMeasureChartViewData> SecondaryPerformanceMeasureChartViewDataByPerformanceMeasure { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.TaxonomyLeaf taxonomyLeaf,
            ProjectLocationsMapInitJson primaryProjectLocationsMapInitJson,
            ProjectLocationsMapInitJson secondaryProjectLocationsMapInitJson,
            ProjectLocationsMapViewData primaryProjectLocationsMapViewData,
            ProjectLocationsMapViewData secondaryProjectLocationsMapViewData,
            bool canHaveAssociatedPerformanceMeasures,
            RelatedPerformanceMeasuresViewData relatedPerformanceMeasuresViewData,
            TaxonomyLevel taxonomyLevel,
            TenantAttribute tenantAttribute,
            IEnumerable<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures,
            Dictionary<int, PerformanceMeasureChartViewData> primaryPerformanceMeasureChartViewDataByPerformanceMeasure,
            Dictionary<int, PerformanceMeasureChartViewData> secondaryPerformanceMeasureChartViewDataByPerformanceMeasure,
            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations) : base(currentFirmaSession)
        {
            TaxonomyLeaf = taxonomyLeaf;
            PageTitle = taxonomyLeaf.GetDisplayName();
            var fieldDefinitionTaxonomyLeaf = FieldDefinitionEnum.TaxonomyLeaf;
            var taxonomyLeafDisplayName = fieldDefinitionTaxonomyLeaf.ToType().GetFieldDefinitionLabel();
            EntityName = taxonomyLeafDisplayName;

            PrimaryProjectLocationsMapInitJson = primaryProjectLocationsMapInitJson;
            PrimaryProjectLocationsMapViewData = primaryProjectLocationsMapViewData;
            SecondaryProjectLocationsMapInitJson = secondaryProjectLocationsMapInitJson;
            SecondaryProjectLocationsMapViewData = secondaryProjectLocationsMapViewData;
            ProjectMapFilteredUrl = PrimaryProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTaxonomyLeafManagePermissions = new TaxonomyLeafManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            EditTaxonomyLeafUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(c => c.Edit(taxonomyLeaf));
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(x => x.Taxonomy());

            SecondaryBasicProjectInfoGridName = "secondaryLeafProjectListGrid";
            BasicProjectInfoGridSpec = new ProjectForTaxonomyLeafGridSpec(currentFirmaSession, true, taxonomyLeaf)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} with this {taxonomyLeafDisplayName}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} with this {taxonomyLeafDisplayName}",
                SaveFiltersInCookie = true
            };

            SecondaryBasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(tc => tc.SecondaryProjectsGridJsonData(taxonomyLeaf));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyLeaf, taxonomyLevel);

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "taxonomyLeafProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.TaxonomyLeafProjectsGridJsonData(taxonomyLeaf));

            TaxonomyLeafDisplayName = taxonomyLeafDisplayName;
            TaxonomyLeafDisplayNamePluralized = fieldDefinitionTaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized();

            CanHaveAssociatedPerformanceMeasures = canHaveAssociatedPerformanceMeasures;
            PerformanceMeasures = performanceMeasures;
            PrimaryPerformanceMeasureChartViewDataByPerformanceMeasure = primaryPerformanceMeasureChartViewDataByPerformanceMeasure;
            SecondaryPerformanceMeasureChartViewDataByPerformanceMeasure = secondaryPerformanceMeasureChartViewDataByPerformanceMeasure;
            RelatedPerformanceMeasuresViewData = relatedPerformanceMeasuresViewData;

            TenantAttribute = tenantAttribute;
        }
    }
}
