/*-----------------------------------------------------------------------
<copyright file="AttachmentTypeGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectAttachment
{
    public class ProjectAttachmentGridSpec : GridSpec<ProjectFirmaModels.Models.vProjectAttachment>
    {
        public ProjectAttachmentGridSpec(bool hasManagePermissions)
        {
            var projectFieldDefinitionLabel = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            var attachmentTypeFieldDefinitionLabel = FieldDefinitionEnum.AttachmentType.ToType().GetFieldDefinitionLabel();
            if (hasManagePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, a => DhtmlxGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(a.GetEditUrl(),
                        $"Edit Attachment \"{a.ProjectAttachmentDisplayName}\"")),
                    30, DhtmlxGridColumnFilterType.None);
            }

            Add($"Attachment Name", a => UrlTemplate.MakeHrefString(a.GetFileResourceUrl(), a.ProjectAttachmentDisplayName + " " + BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-download"), new Dictionary<string, string> { { "target", "_blank" } }), 240);
            Add($"Attachment Description", a => a.ProjectAttachmentDescription, 240);
            
            Add($"{projectFieldDefinitionLabel} Name", a => UrlTemplate.MakeHrefString(a.GetProjectDetailUrl(), a.ProjectName), 240, DhtmlxGridColumnFilterType.Text);
            Add($"{attachmentTypeFieldDefinitionLabel}", a => a.AttachmentTypeName, 240, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"File Type", a =>  FileResourceMimeType.AllLookupDictionary[a.FileResourceMimeTypeID].FileResourceMimeTypeName, 240, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}
