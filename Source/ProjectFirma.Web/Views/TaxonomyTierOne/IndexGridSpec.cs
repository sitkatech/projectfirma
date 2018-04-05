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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierOne>
    {
        public IndexGridSpec(Person currentPerson)
        {
            if (new TaxonomyTierOneManageFeature().HasPermissionByPerson(currentPerson))
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30, DhtmlxGridColumnFilterType.None);
            }
            Add(Models.FieldDefinition.TaxonomyTierOne.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.TaxonomyTierOneName), 350, DhtmlxGridColumnFilterType.Html);
            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() >= 2)
            {
                Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TaxonomyTierTwo.SummaryUrl, a.TaxonomyTierTwo.TaxonomyTierTwoName), 300);
            }
            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.TaxonomyTierTwo.TaxonomyTierThree.SummaryUrl, a.TaxonomyTierTwo.TaxonomyTierThree.TaxonomyTierThreeName), 250);    
            }    
            
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.GetAssociatedProjects(currentPerson).Count, 90);
        }
    }
}
