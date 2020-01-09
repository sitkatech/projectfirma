/*-----------------------------------------------------------------------
<copyright file="AttachmentRelationshipTypeGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AttachmentRelationshipType
{
    public class AttachmentRelationshipTypeGridSpec : GridSpec<ProjectFirmaModels.Models.AttachmentRelationshipType>
    {
        public AttachmentRelationshipTypeGridSpec(bool hasManagePermissions)
        {
            var basicsColumnGroupCount = 5;

            if (hasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, x.CanDelete()), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<AttachmentRelationshipTypeController>.BuildUrlFromExpression(t => t.EditAttachmentRelationshipType(a)),
                        $"Edit {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} \"{a.AttachmentRelationshipTypeName}\"")),
                    30, DhtmlxGridColumnFilterType.None);
                basicsColumnGroupCount += 2;
            }

            Add($"{FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} Name", a => a.AttachmentRelationshipTypeName, 240);
            Add($"{FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} Description", a => a.AttachmentRelationshipTypeDescription, 240);
            Add($"Allowed File Types", a => a.AttachmentRelationshipTypeFileResourceMimeTypes.GetFileResourceMimeTypeDisplayNamesAsCommaDelimitedList(), 240);
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                Add(
                    $"Applicable to the following {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()}",
                    a => a.AttachmentRelationshipTypeTaxonomyTrunks.GetTaxonomyTrunkNamesAsCommaDelimitedList(), 240);
            }

            Add("Number of Allowed Attachments", a => a.NumberOfAllowedAttachments, 80);
            Add("Maximum File Size", a => a.MaxFileSizeForDisplay, 140);



        }
    }
}
