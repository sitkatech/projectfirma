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
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyLeaf
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.TaxonomyLeaf TaxonomyLeaf;
        public readonly bool UserHasTaxonomyLeafManagePermissions;
        public readonly string EditTaxonomyLeafUrl;
        public readonly string IndexUrl;

        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;
        public readonly string TaxonomyLeafDisplayName;
        public readonly string TaxonomyLeafDisplayNamePluralized;

        public DetailViewData(Person currentPerson,
            Models.TaxonomyLeaf taxonomyLeaf,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyLeaf = taxonomyLeaf;
            PageTitle = taxonomyLeaf.DisplayName;
            var taxonomyLeafDisplayName = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
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
                ObjectNameSingular = string.Format("Project with this {0}", taxonomyLeafDisplayName),
                ObjectNamePlural = string.Format("Projects with this {0}", taxonomyLeafDisplayName),
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyLeaf));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyLeaf);

            TaxonomyLeafDisplayName = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabel();
            TaxonomyLeafDisplayNamePluralized = Models.FieldDefinition.TaxonomyLeaf.GetFieldDefinitionLabelPluralized();
        }
    }
}
