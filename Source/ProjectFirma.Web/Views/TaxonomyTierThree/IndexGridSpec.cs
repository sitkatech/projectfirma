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
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.TaxonomyTierThree
{
    public class IndexGridSpec : GridSpec<Models.TaxonomyTierThree>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }

            Add(Models.FieldDefinition.TaxonomyTierThree.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.SummaryUrl, a.TaxonomyTierThreeName), 240);
            Add(Models.FieldDefinition.TaxonomyTierTwo.ToGridHeaderString(), a => new HtmlString(string.Join("<br/>", a.TaxonomyTierTwos.Select(x => x.GetDisplayNameAsUrl()))), 340, DhtmlxGridColumnFilterType.Html);
            Add("# of Projects", a => a.Projects.Count, 90);
        }
    }
}
