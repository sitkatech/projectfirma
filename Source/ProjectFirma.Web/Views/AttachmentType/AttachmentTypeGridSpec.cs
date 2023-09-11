﻿/*-----------------------------------------------------------------------
<copyright file="AttachmentTypeGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AttachmentType
{
    public class AttachmentTypeGridSpec : GridSpec<ProjectFirmaModels.Models.AttachmentType>
    {
        public AttachmentTypeGridSpec(bool hasManagePermissions)
        {
            var basicsColumnGroupCount = 5;

            if (hasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, x.CanDelete()), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<AttachmentTypeController>.BuildUrlFromExpression(t => t.EditAttachmentType(a)),
                        $"Edit {FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} \"{a.AttachmentTypeName}\"")),
                    30, DhtmlxGridColumnFilterType.None);
                basicsColumnGroupCount += 2;
            }

            Add($"{FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} Name", a => a.AttachmentTypeName, 240);
            Add($"{FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel()} Description", a => a.AttachmentTypeDescription, 240);
            Add($"Allowed File Types", a => a.AttachmentTypeFileResourceMimeTypes.GetFileResourceMimeTypeDisplayNamesAsCommaDelimitedList(), 240);
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                Add(
                    $"Applicable to the following {FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel()}",
                    a => a.AttachmentTypeTaxonomyTrunks.GetTaxonomyTrunkNamesAsCommaDelimitedList(), 240);
            }

            Add("# of Allowed Attachments", a => a.NumberOfAllowedAttachments, 80);
            Add("Maximum File Size", a => a.MaxFileSizeForDisplay, 140);
            Add(FieldDefinitionEnum.QuickAccessAttachment.ToType().ToGridHeaderString(), a => a.IsQuickAccessAttachment.ToYesNo(), 140);
            Add(FieldDefinitionEnum.AttachmentTypeViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, DhtmlxGridColumnFilterType.Html);



        }
    }
}
