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
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec{ get; }
        public string GridName{ get; }
        public string GridDataUrl{ get; }
        public string EditSortOrderUrl { get; }
        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            var taxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();
            PageTitle = taxonomyTierTwoDisplayNamePluralized;

            var hasTaxonomyTierTwoManagePermissions = new TaxonomyTierTwoManageFeature().HasPermissionByPerson(currentPerson);
            var taxonomyTierTwoDisplayName = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            GridSpec = new IndexGridSpec(currentPerson)
            {
                ObjectNameSingular = taxonomyTierTwoDisplayName,
                ObjectNamePlural = taxonomyTierTwoDisplayNamePluralized,
                SaveFiltersInCookie = true
            };

            if (hasTaxonomyTierTwoManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", taxonomyTierTwoDisplayName));
            }

            GridName = "taxonomyTierTwosGrid";
            GridDataUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            EditSortOrderUrl = SitkaRoute<TaxonomyTierTwoController>.BuildUrlFromExpression(tc => tc.EditSortOrder());
        }
    }
}
