/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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

namespace ProjectFirma.Web.Views.TaxonomyTierOne
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierOne>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30);
            }
            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierThreeDisplayName()), a => UrlTemplate.MakeHrefString(a.TaxonomyTierTwo.TaxonomyTierThree.SummaryUrl, a.TaxonomyTierTwo.TaxonomyTierThree.TaxonomyTierThreeName), 250);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierTwoDisplayName()), a => UrlTemplate.MakeHrefString(a.TaxonomyTierTwo.SummaryUrl, a.TaxonomyTierTwo.TaxonomyTierTwoName), 300);
            Add(Models.FieldDefinition.TaxonomyTierOne.ToGridHeaderString(MultiTenantHelpers.GetTaxonomyTierOneDisplayName()), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.TaxonomyTierOneName), 350, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}
