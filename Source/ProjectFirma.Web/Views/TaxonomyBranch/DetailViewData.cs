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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.TaxonomyBranch TaxonomyBranch { get; }

        public bool UserHasTaxonomyBranchManagePermissions { get; }
        public string EditTaxonomyBranchUrl { get; }

        public string IndexUrl { get; }

        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public string ProjectMapFilteredUrl { get; }

        public string TaxonomyBranchDisplayName { get; }
        public string TaxonomyBranchDisplayNamePluralized { get; }
        public string TaxonomyLeafDisplayNamePluralized { get; }

        public bool CanHaveAssociatedPerformanceMeasures { get; }
        public List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas { get; }
        public RelatedPerformanceMeasuresViewData RelatedPerformanceMeasuresViewData { get; }

        public string EditChildrenSortOrderUrl { get; }

        public DetailViewData(Person currentPerson,
            ProjectFirmaModels.Models.TaxonomyBranch taxonomyBranch,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData, 
            bool canHaveAssociatedPerformanceMeasures, 
            RelatedPerformanceMeasuresViewData relatedPerformanceMeasuresViewData, 
            List<PerformanceMeasureChartViewData> performanceMeasureChartViewDatas, 
            TaxonomyLevel taxonomyLevel,
            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations) : base(currentPerson)
        {
            TaxonomyBranch = taxonomyBranch;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            PageTitle = taxonomyBranch.GetDisplayName();
            var taxonomyBranchDisplayName = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
            TaxonomyBranchDisplayName = taxonomyBranchDisplayName;
            TaxonomyBranchDisplayNamePluralized = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized();
            TaxonomyLeafDisplayNamePluralized = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized();
            EntityName = taxonomyBranchDisplayName;

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTaxonomyBranchManagePermissions = new TaxonomyBranchManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyBranchUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(c => c.Edit(taxonomyBranch.TaxonomyBranchID));

            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.Taxonomy());

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentPerson, projectCustomDefaultGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "taxonomyBranchProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.TaxonomyBranchProjectsGridJsonData(taxonomyBranch));

            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyBranch, taxonomyLevel);

            CanHaveAssociatedPerformanceMeasures = canHaveAssociatedPerformanceMeasures;
            RelatedPerformanceMeasuresViewData = relatedPerformanceMeasuresViewData;
            PerformanceMeasureChartViewDatas = performanceMeasureChartViewDatas;

            EditChildrenSortOrderUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(x => x.EditChildrenSortOrder(taxonomyBranch));
        }
    }
}
