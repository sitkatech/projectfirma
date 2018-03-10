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

using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.CustomPage
{
    public class IndexViewData : FirmaViewData
    {
        public readonly CustomPageGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string CustomPageUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson, null)
        {
            PageTitle = "Manage Custom Pages";

            GridSpec = new CustomPageGridSpec(new FirmaPageViewListFeature().HasPermissionByPerson(currentPerson))
            {
                ObjectNameSingular = "Page",
                ObjectNamePlural = "Pages",
                SaveFiltersInCookie = true
            };
            GridName = "customPagesGrid";
            GridDataUrl = SitkaRoute<CustomPageController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            CustomPageUrl = SitkaRoute<CustomPageController>.BuildUrlFromExpression(x => x.CustomPageDetails(UrlTemplate.Parameter1Int));
        }
    }
}
