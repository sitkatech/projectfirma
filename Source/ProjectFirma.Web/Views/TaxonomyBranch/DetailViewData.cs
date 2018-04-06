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

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.TaxonomyBranch TaxonomyBranch;
        public readonly List<Models.PerformanceMeasure> PerformanceMeasures;
        public readonly int PerformanceMeasuresEndOfFirstHalf;

        public readonly bool UserHasTaxonomyBranchManagePermissions;
        public readonly string EditTaxonomyBranchUrl;
        public readonly string PerformanceMeasureUrl;

        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoProjectGridName;
        public readonly string BasicProjectInfoProjectGridDataUrl;

        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly List<Models.PerformanceMeasure> TaxonomyBranchPerformanceMeasures;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;

        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;
        public readonly string TaxonomyBranchDisplayName;
        public readonly string TaxonomyBranchDisplayNamePluralized;
        public readonly string TaxonomyLeafDisplayNamePluralized;

        public DetailViewData(Person currentPerson,
            Models.TaxonomyBranch taxonomyBranch,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData, List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas) : base(currentPerson)
        {
            TaxonomyBranch = taxonomyBranch;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            PageTitle = taxonomyBranch.DisplayName;
            var taxonomyBranchDisplayName = Models.FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabel();
            TaxonomyBranchDisplayName = taxonomyBranchDisplayName;
            TaxonomyBranchDisplayNamePluralized = Models.FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabelPluralized();
            TaxonomyLeafDisplayNamePluralized = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabelPluralized();
            EntityName = taxonomyBranchDisplayName;
            PerformanceMeasures = taxonomyBranch.GetPerformanceMeasures();
            PerformanceMeasuresEndOfFirstHalf = GeneralUtility.CalculateIndexOfEndOfFirstHalf(PerformanceMeasures.Count);

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();
            PerformanceMeasureChartViewDatas = performanceMeasureChartViewDatas;

            UserHasTaxonomyBranchManagePermissions = new TaxonomyBranchManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyBranchUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(c => c.Edit(taxonomyBranch.TaxonomyBranchID));
            PerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());

            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.Taxonomy());

            BasicProjectInfoProjectGridName = "taxonomyBranchProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {taxonomyBranchDisplayName}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {taxonomyBranchDisplayName}",
                SaveFiltersInCookie = true
            };
            BasicProjectInfoProjectGridDataUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyBranch));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyBranch);

            TaxonomyBranchPerformanceMeasures = taxonomyBranch.GetPerformanceMeasures().OrderBy(x => x.PerformanceMeasureDisplayName).ToList();
        }
    }
}
