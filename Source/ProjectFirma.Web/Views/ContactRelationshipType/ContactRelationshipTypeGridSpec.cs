/*-----------------------------------------------------------------------
<copyright file="ContactRelationshipTypeGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ContactRelationshipType
{
    public class ContactRelationshipTypeGridSpec : GridSpec<ProjectFirmaModels.Models.ContactRelationshipType>
    {
        public ContactRelationshipTypeGridSpec(bool hasManagePermissions)
        {
            var basicsColumnGroupCount = 5;

            if (hasManagePermissions)
            {
                Add("delete", x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, x.CanDelete()), 30, AgGridColumnFilterType.None);
                Add("edit", a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<ContactRelationshipTypeController>.BuildUrlFromExpression(t => t.EditContactRelationshipType(a)),
                        $"Edit {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} \"{a.ContactRelationshipTypeName}\"")),
                    30, AgGridColumnFilterType.None);
                basicsColumnGroupCount += 2;
            }

            Add($"{FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} Name", a => a.ContactRelationshipTypeName, 240);
            Add(FieldDefinitionEnum.ContactRelationshipTypeAcceptsMultipleValues.ToType().ToGridHeaderString(), a => a.ContactRelationshipTypeAcceptsMultipleValues.ToCheckboxImageOrEmptyForGrid(), 120);
            Add(FieldDefinitionEnum.IsContactRelationshipTypeRequired.ToType().ToGridHeaderString(), a => a.IsContactRelationshipTypeRequired.ToCheckboxImageOrEmptyForGrid(), 120);
            Add(FieldDefinitionEnum.CanContactTypeManageProject.ToType().ToGridHeaderString(), a => a.CanManageProject.ToCheckboxImageOrEmptyForGrid(), 120);
            Add("If Contact Relationship Type is required, Minimum Project Stage to require by", a => a.IsContactRelationshipRequiredMinimumProjectStage != null ? a.IsContactRelationshipRequiredMinimumProjectStage.GetProjectStageDisplayName() : string.Empty, 300);
        }
    }
}
