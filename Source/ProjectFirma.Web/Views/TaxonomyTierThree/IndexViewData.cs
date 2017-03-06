/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = MultiTenantHelpers.GetTaxonomyTierThreeDisplayNamePluralized();

            var hasTaxonomyTierThreeManagePermissions = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTaxonomyTierThreeManagePermissions) { ObjectNameSingular = MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(), ObjectNamePlural = MultiTenantHelpers.GetTaxonomyTierThreeDisplayNamePluralized(), SaveFiltersInCookie = true };
            if (hasTaxonomyTierThreeManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(t => t.New()), string.Format("Create a new {0}", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()));
            }

            GridName = "taxonomyTierThreesGrid";
            GridDataUrl = SitkaRoute<TaxonomyTierThreeController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}
