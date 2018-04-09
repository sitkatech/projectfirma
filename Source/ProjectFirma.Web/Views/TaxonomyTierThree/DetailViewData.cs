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

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class DetailViewData : FirmaViewData
    {
        public Models.TaxonomyTierThree TaxonomyTierThree { get; }
        public bool UserHasTaxonomyTierThreeManagePermissions { get; }
        public bool UserHasProjectTaxonomyTierThreeExpenditureManagePermissions { get; }
        public string EditTaxonomyTierThreeUrl { get; }
        public string TaxonomyTierTwoIndexUrl { get; }

        public string IndexUrl { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoGridName { get; }
        public string BasicProjectInfoGridDataUrl { get; }

        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public string ProjectMapFilteredUrl { get; }

        public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }

        public string TaxonomyTierThreeDisplayName { get; }
        public string TaxonomyTierThreeDisplayNamePluralized { get; }
        public string TaxonomyTierTwoDisplayNamePluralized { get; }
        public string TaxonomyTierOneDisplayNamePluralized { get; }

        public string EditChildrenSortOrderUrl { get; }

        public DetailViewData(Person currentPerson,
            Models.TaxonomyTierThree taxonomyTierThree,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyTierThree = taxonomyTierThree;
            TaxonomyTierThreeDisplayName = Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabel();
            TaxonomyTierThreeDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierThree.GetFieldDefinitionLabelPluralized();
            TaxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();
            TaxonomyTierOneDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabelPluralized();

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            PageTitle = taxonomyTierThree.DisplayName;
            EntityName = TaxonomyTierThreeDisplayName;
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.Taxonomy());

            UserHasTaxonomyTierThreeManagePermissions = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(CurrentPerson);
            UserHasProjectTaxonomyTierThreeExpenditureManagePermissions = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(currentPerson);
            EditTaxonomyTierThreeUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(c => c.Edit(taxonomyTierThree.TaxonomyTierThreeID));
            TaxonomyTierTwoIndexUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(c => c.Index());

            BasicProjectInfoGridName = "taxonomyTierThreeProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this {TaxonomyTierThreeDisplayName}",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} with this {TaxonomyTierThreeDisplayName}",
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTierThree));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTierThree);

            EditChildrenSortOrderUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(tc=>tc.EditChildrenSortOrder(TaxonomyTierThree));
        }
    }
}
