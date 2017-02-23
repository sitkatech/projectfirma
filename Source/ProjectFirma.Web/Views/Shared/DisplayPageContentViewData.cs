/*-----------------------------------------------------------------------
<copyright file="DisplayPageContentViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class DisplayPageContentViewData : FirmaViewData
    {
        public readonly bool ShowEditButton;
        public readonly string EditUrl;

        public DisplayPageContentViewData(Person currentPerson, FirmaPageType firmaPageType) : base(currentPerson, Models.FirmaPage.GetFirmaPageByPageType(firmaPageType), false)
        {
            PageTitle = firmaPageType.FirmaPageTypeDisplayName;
            var firmaPageByPageType = Models.FirmaPage.GetFirmaPageByPageType(firmaPageType);
            var permissionCheckResult = new FirmaPageManageFeature().HasPermission(currentPerson, firmaPageByPageType);
            ShowEditButton = permissionCheckResult.HasPermission;
            EditUrl = SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.EditPageContent(firmaPageType.ToEnum));
        }
    }
}
