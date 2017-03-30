/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.TaxonomyTierOne TaxonomyTierOne;
        public readonly bool UserHasTaxonomyTierOneManagePermissions;
        public readonly string EditTaxonomyTierOneUrl;
        public readonly string IndexUrl;

        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string ProjectMapFilteredUrl;
        public readonly string TaxonomyTierOneDisplayName;
        public readonly string TaxonomyTierOneDisplayNamePluralized;

        public DetailViewData(Person currentPerson,
            Models.TaxonomyTierOne taxonomyTierOne,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            TaxonomyTierOne = taxonomyTierOne;
            PageTitle = taxonomyTierOne.DisplayName;
            var taxonomyTierOneDisplayName = Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabel();
            EntityName = taxonomyTierOneDisplayName;

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTaxonomyTierOneManagePermissions = new TaxonomyTierOneManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTaxonomyTierOneUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(c => c.Edit(taxonomyTierOne));
            IndexUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(x => x.Index());

            BasicProjectInfoGridName = "taxonomyTierOneProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = string.Format("Project with this {0}", taxonomyTierOneDisplayName),
                ObjectNamePlural = string.Format("Projects with this {0}", taxonomyTierOneDisplayName),
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(taxonomyTierOne));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(taxonomyTierOne);

            TaxonomyTierOneDisplayName = Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabel();
            TaxonomyTierOneDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierOne.GetFieldDefinitionLabelPluralized();
        }
    }
}
