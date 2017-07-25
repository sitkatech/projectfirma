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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.FirmaPage
{
    public class IndexViewData : FirmaViewData
    {
        public readonly FirmaPageGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string FirmaPageUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson, null)
        {
            PageTitle = "Manage Page Content";

            GridSpec = new FirmaPageGridSpec(new FirmaPageViewListFeature().HasPermissionByPerson(currentPerson))
            {
                ObjectNameSingular = "Page",
                ObjectNamePlural = "Pages",
                SaveFiltersInCookie = true
            };
            GridName = "firmaPagesGrid";
            GridDataUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            FirmaPageUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(x => x.FirmaPageDetails(UrlTemplate.Parameter1Int));
        }
    }
}
