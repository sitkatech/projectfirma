﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectAttachment
{
    public class ProjectAttachmentIndexViewData : FirmaViewData
    {

        public ProjectAttachmentGridSpec ProjectAttachmentGridSpec { get; }
        public string ProjectAttachmentGridName { get; }
        public string ProjectAttachmentGridDataUrl { get; }
        public bool HasManagePermissions { get; }

        public ProjectAttachmentIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Attachments";

            var hasManagePermissions = new ProjectAttachmentEditAsAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            ProjectAttachmentGridSpec = new ProjectAttachmentGridSpec(hasManagePermissions) { ObjectNameSingular = $"Attachment", ObjectNamePlural = $"Attachments", SaveFiltersInCookie = true };

            ProjectAttachmentGridName = "projectAttachmentGrid";
            ProjectAttachmentGridDataUrl = SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(c => c.ProjectAttachmentGridJsonData());
            HasManagePermissions = hasManagePermissions;
        }
    }
}
