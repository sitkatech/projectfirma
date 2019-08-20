﻿/*-----------------------------------------------------------------------
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

namespace ProjectFirma.Web.Views.ProjectAttachment
{
    public class ProjectAttachmentGridSpec : GridSpec<ProjectFirmaModels.Models.ProjectAttachment>
    {
        public ProjectAttachmentGridSpec(bool hasManagePermissions)
        {
            var basicsColumnGroupCount = 5;

            if (hasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(t => t.Edit(a)),
                        $"Edit Attachment \"{a.DisplayName}\"")),
                    30, DhtmlxGridColumnFilterType.None);
                basicsColumnGroupCount += 2;
            }

            Add($"Attachment Name", a => a.DisplayName, 240);
            Add($"Attachment Description", a => a.Description, 240);
            Add($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Name", a => UrlTemplate.MakeHrefString(a.Project.GetDetailUrl(), a.Project.ProjectName), 240, DhtmlxGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ProjectAttachmentRelationshipType.ToType().GetFieldDefinitionLabel()}", a => a.AttachmentRelationshipType.AttachmentRelationshipTypeName, 240, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"File Type", a => a.Attachment.FileResourceMimeType.FileResourceMimeTypeName, 240, DhtmlxGridColumnFilterType.SelectFilterStrict);
            
        }
    }
}