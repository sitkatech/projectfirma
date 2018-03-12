/*-----------------------------------------------------------------------
<copyright file="CustomPageGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.CustomPage
{
    public class CustomPageGridSpec : GridSpec<Models.CustomPage>
    {
        public CustomPageGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {               
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, hasManagePermissions, true), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<CustomPageController>.BuildUrlFromExpression(t => t.Edit(a)),
                        "Edit")),
                    30);
            }
            Add("Page Name", a => UrlTemplate.MakeHrefString(a.AboutPageUrl, a.CustomPageDisplayName), 180, DhtmlxGridColumnFilterType.Text);
            Add("Has Content", a => a.HasPageContent.ToYesNo(), 85, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.CustomPageDisplayType.ToGridHeaderString(), a => a.CustomPageDisplayType.CustomPageDisplayTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
