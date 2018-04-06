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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class DetailViewData : FirmaViewData
    {
        public Models.TaxonomyTierTwo TaxonomyTierTwo { get; }
        public List<Models.PerformanceMeasure> PerformanceMeasures { get; }
        public int PerformanceMeasuresEndOfFirstHalf { get; }

        public bool UserHasTaxonomyTierTwoManagePermissions { get; }
        public string EditTaxonomyTierTwoUrl { get; }
        public string PerformanceMeasureUrl { get; }

        public string IndexUrl { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoProjectGridName { get; }
        public string BasicProjectInfoProjectGridDataUrl { get; }

        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public List<Models.PerformanceMeasure> TaxonomyTierTwoPerformanceMeasures { get; }

        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public string ProjectMapFilteredUrl { get; }

        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public string TaxonomyTierTwoDisplayName { get; }
        public string TaxonomyTierTwoDisplayNamePluralized { get; }
        public string TaxonomyTierOneDisplayNamePluralized { get; }

        public string EditChildrenSortOrderUrl { get; set; }

        public DetailViewData(Person currentPerson,
            Models.TaxonomyTierTwo taxonomyTierTwo,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData, List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas) : base(currentPerson)
        {
            TaxonomyTierTwo = taxonomyTierTwo;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            PageTitle = taxonomyTierTwo.DisplayName;
            var taxonomyTierTwoDisplayName = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            TaxonomyTierTwoDisplayName = taxonomyTierTwoDisplayName;
            TaxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();
            TaxonomyTierOneDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabelPluralized();
            EntityName = taxonomyTierTwoDisplayName;
            PerformanceMeasures = taxonomyTierTwo.TaxonomyTierTwoPerformanceMeasures.Select(x => x.PerformanceMeasure).ToList();
            PerformanceMeasuresEndOfFirstHalf = GeneralUtility.CalculateIndexOfEndOfFirstHalf(PerformanceMeasures.Count);

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();
            PerformanceMeasureChartViewDatas = performanceMeasureChartViewDatas;

            UserHasTaxonomyTierTwoManagePermissions = new TaxonomyTierTwoManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyTierTwoUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.Edit(taxonomyTierTwo.TaxonomyTierTwoID));
            PerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());

            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.Taxonomy());

            BasicProjectInfoProjectGridName = "taxonomyTierTwoProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {taxonomyTierTwoDisplayName}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {taxonomyTierTwoDisplayName}",
                SaveFiltersInCookie = true
            };
            BasicProjectInfoProjectGridDataUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTierTwo));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTierTwo);

            TaxonomyTierTwoPerformanceMeasures = taxonomyTierTwo.GetPerformanceMeasures().OrderBy(x => x.PerformanceMeasureDisplayName).ToList();

            EditChildrenSortOrderUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(x=>x.EditChildrenSortOrder(TaxonomyTierTwo));
        }
    }
}
