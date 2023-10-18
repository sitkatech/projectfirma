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

using System.Web;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.OrganizationTypeAndOrganizationRelationshipType
{
    public class OrganizationTypeGridSpec : GridSpec<OrganizationType>
    {
        public OrganizationTypeGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(OrganizationTypeModelExtensions.GetDeleteUrl(x), true, !x.HasDependentObjects()), 30, AgGridColumnFilterType.None);
                Add("edit", a => AgGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<OrganizationTypeAndOrganizationRelationshipTypeController>.BuildUrlFromExpression(t => t.EditOrganizationType(a)),
                        $"Edit {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()} '{a.OrganizationTypeName}'")),
                    30, AgGridColumnFilterType.None);
            }

            Add($"{FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()} Name", a => a.OrganizationTypeName, 240);
            Add($"{FieldDefinitionEnum.OrganizationTypeAbbreviation.ToType().ToGridHeaderString()}", a => a.OrganizationTypeAbbreviation, 200);
            Add($"{FieldDefinitionEnum.IsDefaultOrganizationType.ToType().ToGridHeaderString()}", a => a.IsDefaultOrganizationType.ToCheckboxImageOrEmptyForGrid(), 80);
            Add($"{FieldDefinitionEnum.IsFundingType.ToType().ToGridHeaderString()}", a => a.IsFundingType.ToCheckboxImageOrEmptyForGrid(), 80);
            Add($"{FieldDefinitionEnum.ShowOnProjectMaps.ToType().ToGridHeaderString()}", a => a.ShowOnProjectMaps.ToCheckboxImageOrEmptyForGrid(), 150);
            Add($"{FieldDefinitionEnum.LegendColor.ToType().ToGridHeaderString()}", a => ToLegendColor(a), 90, AgGridColumnFilterType.None);
        }

        private static HtmlString ToLegendColor(OrganizationType organizationType)
        {
            var div = new TagBuilder("div");
            div.Attributes["style"] = $"background-color: {organizationType.LegendColor}; height: 1em; width: 1em; display: block; margin: auto;";
            return div.ToString().ToHTMLFormattedString();
        }
    }
}
