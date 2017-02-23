/*-----------------------------------------------------------------------
<copyright file="FieldDefinitionGridSpec.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.FieldDefinition
{
    public class FieldDefinitionGridSpec : GridSpec<Models.FieldDefinition>
    {
        public FieldDefinitionGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add(string.Empty,
                    a =>
                        DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(
                            new ModalDialogForm(
                                SitkaRoute<FieldDefinitionController>.BuildUrlFromExpression(t => t.Edit(a)),
                                string.Format("Edit Field Definition '{0}'", a.FieldDefinitionDisplayName))),
                    30);
            }
            Add("Field Name", a => a.FieldDefinitionDisplayName, 250);
            Add("Defined?", a => a.HasDefinition.ToYesNo(), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("FieldDefinitionID", a => a.FieldDefinitionID, 0);
        }
    }
}
