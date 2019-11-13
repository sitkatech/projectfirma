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

using System.Linq;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class IndexViewData : FirmaViewData
    {        
        public IndexGridSpec GridSpec{ get; }
        public string GridName{ get; }
        public string GridDataUrl{ get; }
        public string EditSortOrderUrl { get; }
        public bool OfferEditSortOrder { get; }
        public bool HasTaxonomyBranchManagePermissions { get; }
        public string NewUrl { get; }
        public string TaxonomyBranchDisplayName { get; }
        public bool IsNotTaxonomyLevelLeaf { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            var taxonomyBranchDisplayNamePluralized = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized();
            PageTitle = taxonomyBranchDisplayNamePluralized;

            // only let them sort tier two taxonomy if that's the highest level.
            OfferEditSortOrder = MultiTenantHelpers.IsTaxonomyLevelBranch();

            HasTaxonomyBranchManagePermissions = new TaxonomyBranchManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            IsNotTaxonomyLevelLeaf = !MultiTenantHelpers.IsTaxonomyLevelLeaf();

            var taxonomyBranchDisplayName = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
            GridSpec = new IndexGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = taxonomyBranchDisplayName,
                ObjectNamePlural = taxonomyBranchDisplayNamePluralized,
                SaveFiltersInCookie = true
            };

            GridName = "taxonomyBranchesGrid";
            GridDataUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            NewUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(t => t.New());
            EditSortOrderUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.EditSortOrder());
            TaxonomyBranchDisplayName = taxonomyBranchDisplayName;
        }
    }
}
