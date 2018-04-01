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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTrunk
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.TaxonomyTrunk TaxonomyTrunk;
        public readonly bool UserHasTaxonomyTrunkManagePermissions;
        public readonly bool UserHasProjectTaxonomyTrunkExpenditureManagePermissions;
        public readonly string EditTaxonomyTrunkUrl;
        public readonly string TaxonomyBranchIndexUrl;

        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;

        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly string TaxonomyTrunkDisplayName;
        public readonly string TaxonomyTrunkDisplayNamePluralized;
        public readonly string TaxonomyBranchDisplayNamePluralized;
        public readonly string TaxonomyLeafDisplayNamePluralized;

        public DetailViewData(Person currentPerson,
            Models.TaxonomyTrunk taxonomyTrunk,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyTrunk = taxonomyTrunk;
            TaxonomyTrunkDisplayName = Models.FieldDefinition.TaxonomyTrunk.GetFieldDefinitionLabel();
            TaxonomyTrunkDisplayNamePluralized = Models.FieldDefinition.TaxonomyTrunk.GetFieldDefinitionLabelPluralized();
            TaxonomyBranchDisplayNamePluralized = Models.FieldDefinition.TaxonomyBranch.GetFieldDefinitionLabelPluralized();
            TaxonomyLeafDisplayNamePluralized = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabelPluralized();

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            PageTitle = taxonomyTrunk.DisplayName;
            EntityName = TaxonomyTrunkDisplayName;
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.Taxonomy());

            UserHasTaxonomyTrunkManagePermissions = new TaxonomyTrunkManageFeature().HasPermissionByPerson(CurrentPerson);
            UserHasProjectTaxonomyTrunkExpenditureManagePermissions = new TaxonomyTrunkManageFeature().HasPermissionByPerson(currentPerson);
            EditTaxonomyTrunkUrl = SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(c => c.Edit(taxonomyTrunk.TaxonomyTrunkID));
            TaxonomyBranchIndexUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(c => c.Index());

            BasicProjectInfoGridName = "taxonomyTrunkProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {TaxonomyTrunkDisplayName}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} with this {TaxonomyTrunkDisplayName}",
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTrunk));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTrunk);
        }
    }
}
