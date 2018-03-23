/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTrunk
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            var taxonomyTrunkPluralized = Models.FieldDefinition.TaxonomyTrunk.GetFieldDefinitionLabelPluralized();
            PageTitle = taxonomyTrunkPluralized;

            var hasTaxonomyTrunkManagePermissions = new TaxonomyTrunkManageFeature().HasPermissionByPerson(currentPerson);
            var taxonomyTrunkDisplayName = Models.FieldDefinition.TaxonomyTrunk.GetFieldDefinitionLabel();
            GridSpec = new IndexGridSpec(currentPerson) { ObjectNameSingular = taxonomyTrunkDisplayName, ObjectNamePlural = taxonomyTrunkPluralized, SaveFiltersInCookie = true };
            if (hasTaxonomyTrunkManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(t => t.New()), $"Create a new {taxonomyTrunkDisplayName}");
            }

            GridName = "taxonomyTrunksGrid";
            GridDataUrl = SitkaRoute<TaxonomyTrunkController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}
