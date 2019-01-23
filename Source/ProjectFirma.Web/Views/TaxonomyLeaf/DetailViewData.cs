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

using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.TaxonomyLeaf
{
    public class DetailViewData : FirmaViewData
    {
        public Models.TaxonomyLeaf TaxonomyLeaf { get; }
        public bool UserHasTaxonomyLeafManagePermissions { get; }
        public string EditTaxonomyLeafUrl { get; }
        public string IndexUrl { get; }

        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoGridName { get; }
        public string BasicProjectInfoGridDataUrl { get; }
        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public string ProjectMapFilteredUrl { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string TaxonomyLeafDisplayNamePluralized { get; }

        public bool CanHaveAssociatedPerformanceMeasures { get; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public RelatedPerformanceMeasuresViewData RelatedPerformanceMeasuresViewData { get; }

        public DetailViewData(Person currentPerson,
            Models.TaxonomyLeaf taxonomyLeaf,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData, bool canHaveAssociatedPerformanceMeasures,
            RelatedPerformanceMeasuresViewData relatedPerformanceMeasuresViewData,
            List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas, TaxonomyLevel taxonomyLevel) : base(currentPerson)
        {
            TaxonomyLeaf = taxonomyLeaf;
            PageTitle = taxonomyLeaf.GetDisplayName();
            var fieldDefinitionTaxonomyLeaf = Models.FieldDefinition.TaxonomyLeaf;
            var taxonomyLeafDisplayName = fieldDefinitionTaxonomyLeaf.GetFieldDefinitionLabel();
            EntityName = taxonomyLeafDisplayName;

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTaxonomyLeafManagePermissions = new TaxonomyLeafManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyLeafUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(c => c.Edit(taxonomyLeaf));
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(x => x.Taxonomy());

            BasicProjectInfoGridName = "taxonomyLeafProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {taxonomyLeafDisplayName}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} with this {taxonomyLeafDisplayName}",
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyLeaf));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyLeaf, taxonomyLevel);

            TaxonomyLeafDisplayName = taxonomyLeafDisplayName;
            TaxonomyLeafDisplayNamePluralized = fieldDefinitionTaxonomyLeaf.GetFieldDefinitionLabelPluralized();

            CanHaveAssociatedPerformanceMeasures = canHaveAssociatedPerformanceMeasures;
            PerformanceMeasureChartViewDatas = performanceMeasureChartViewDatas;
            RelatedPerformanceMeasuresViewData = relatedPerformanceMeasuresViewData;
        }
    }
}
