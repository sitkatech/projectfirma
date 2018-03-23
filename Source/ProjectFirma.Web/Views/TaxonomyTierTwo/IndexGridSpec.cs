/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.TaxonomyTierTwo
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierTwo>
    {
        public IndexGridSpec(Person currentPerson)
        {
            if (new TaxonomyTierTwoManageFeature().HasPermissionByPerson(currentPerson))
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                Add(Models.FieldDefinition.TaxonomyTrunk.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TaxonomyTrunk.SummaryUrl, a.TaxonomyTrunk.TaxonomyTrunkName), 210);    
            }            
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.TaxonomyTierTwoName), 240);
            Add(Models.FieldDefinition.TaxonomyLeaf.ToGridHeaderString(), a => new HtmlString(string.Join("<br/>", a.TaxonomyLeafs.Select(x => x.GetDisplayNameAsUrl()))), 420, DhtmlxGridColumnFilterType.Html);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.GetAssociatedProjects(currentPerson).Count, 90);
        }
    }
}
