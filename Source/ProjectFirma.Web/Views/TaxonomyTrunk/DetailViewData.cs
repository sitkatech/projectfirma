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
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.TaxonomyTrunk
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.TaxonomyTrunk TaxonomyTrunk { get; }
        public bool UserHasTaxonomyTrunkManagePermissions { get; }
        public bool UserHasProjectTaxonomyTrunkExpenditureManagePermissions { get; }
        public string EditTaxonomyTrunkUrl { get; }
        public string TaxonomyBranchIndexUrl { get; }

        public string IndexUrl { get; }

        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public string ProjectMapFilteredUrl { get; }

        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public string TaxonomyTrunkDisplayName { get; }
        public string TaxonomyTrunkDisplayNamePluralized { get; }
        public string TaxonomyBranchDisplayNamePluralized { get; }
        public string TaxonomyLeafDisplayNamePluralized { get; }

        public bool CanHaveAssociatedPerformanceMeasures { get; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public RelatedPerformanceMeasuresViewData RelatedPerformanceMeasuresViewData { get; }

        public string EditChildrenSortOrderUrl { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.TaxonomyTrunk taxonomyTrunk,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData, bool canHaveAssociatedPerformanceMeasures,
            RelatedPerformanceMeasuresViewData relatedPerformanceMeasuresViewData,
            List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas, TaxonomyLevel taxonomyLevel,
            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations) : base(currentFirmaSession)
        {
            TaxonomyTrunk = taxonomyTrunk;
            TaxonomyTrunkDisplayName = FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel();
            TaxonomyTrunkDisplayNamePluralized = FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabelPluralized();
            TaxonomyBranchDisplayNamePluralized = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized();
            TaxonomyLeafDisplayNamePluralized = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized();

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            PageTitle = taxonomyTrunk.GetDisplayName();
            EntityName = TaxonomyTrunkDisplayName;
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.Taxonomy());

            UserHasTaxonomyTrunkManagePermissions = new TaxonomyTrunkManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            UserHasProjectTaxonomyTrunkExpenditureManagePermissions = new TaxonomyTrunkManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            EditTaxonomyTrunkUrl = SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(c => c.Edit(taxonomyTrunk.TaxonomyTrunkID));
            TaxonomyBranchIndexUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(c => c.Index());

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "taxonomyTrunkProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.TaxonomyTrunkProjectsGridJsonData(taxonomyTrunk));

            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTrunk, taxonomyLevel);

            CanHaveAssociatedPerformanceMeasures = canHaveAssociatedPerformanceMeasures;
            PerformanceMeasureChartViewDatas = performanceMeasureChartViewDatas;
            RelatedPerformanceMeasuresViewData = relatedPerformanceMeasuresViewData;

            EditChildrenSortOrderUrl = SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(x => x.EditChildrenSortOrder(taxonomyTrunk));
        }
    }
}
