/*-----------------------------------------------------------------------
<copyright file="EditPageContentViewData.cs" company="Tahoe Regional Planning Agency">
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

using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewPageContentViewData
    {
        public readonly Models.FirmaPage FirmaPage;
        public readonly bool ShowEditButton;
        public readonly string EditUrl;
        public readonly string FirmaPageContentID;

        public ViewPageContentViewData(Models.FirmaPage firmaPage, string editUrl, Person currentPerson)
        {
            FirmaPage = firmaPage;
            var permissionCheckResult = new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage);
            ShowEditButton = permissionCheckResult.HasPermission;
            EditUrl = editUrl;
            FirmaPageContentID = $"firmaPageContent{firmaPage.FirmaPageID}";
        }        
    }
}
