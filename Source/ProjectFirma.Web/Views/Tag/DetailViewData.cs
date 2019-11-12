/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tag
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Tag Tag { get; }
        public string EditTagUrl { get; }
        public string ManageTagsUrl { get; }
        public bool UserHasTagManagePermissions { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoGridName { get; }
        public string BasicProjectInfoGridDataUrl { get; }

        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Tag tag) : base(currentFirmaSession)
        {
            Tag = tag;
            PageTitle = tag.TagName;
            EntityName = "Tag";
            
            EditTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Edit(tag));
            ManageTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Index());
            UserHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            BasicProjectInfoGridName = "tagProjectListGrid";

            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(currentFirmaSession, true)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} with this Tag",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} with this Tag",
                SaveFiltersInCookie = true
            };
            
            BasicProjectInfoGridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(tag));
        }
    }
}
