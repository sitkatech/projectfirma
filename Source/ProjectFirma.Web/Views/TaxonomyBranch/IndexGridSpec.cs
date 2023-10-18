﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.TaxonomyBranch>
    {
        public IndexGridSpec(FirmaSession currentFirmaSession)
        {
            if (new TaxonomyBranchManageFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                Add("Delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()), 30, AgGridColumnFilterType.None);
            }

            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                Add(FieldDefinitionEnum.TaxonomyTrunk.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TaxonomyTrunk.GetDetailUrl(), a.TaxonomyTrunk.TaxonomyTrunkName), 210);    
            }            
            Add(FieldDefinitionEnum.TaxonomyBranch.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.GetTaxonomyBranchCodeAndName()), 240);
            Add(FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString(), a => new HtmlString(string.Join("<br/>", a.TaxonomyLeafs.SortByOrderThenName().Select(x => x.GetDisplayNameAsUrl()))), 420, AgGridColumnFilterType.Html);
            Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", a => a.GetAssociatedProjects(currentFirmaSession).Count, 90);
            Add("Sort Order", a => a.TaxonomyBranchSortOrder, 90, AgGridColumnFormatType.None);
            Add(FieldDefinitionEnum.TaxonomyBranchDescription.ToType().ToGridHeaderString(),a => a.TaxonomyBranchDescriptionHtmlString != null ? a.TaxonomyBranchDescriptionHtmlString : new HtmlString(string.Empty), 200, AgGridColumnFilterType.Html);
        }
    }
}
