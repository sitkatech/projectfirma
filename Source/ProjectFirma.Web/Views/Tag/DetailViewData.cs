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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Tag
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Tag Tag;
        public readonly string EditTagUrl;
        public readonly string ManageTagsUrl;
        public readonly bool UserHasTagManagePermissions;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public DetailViewData(Person currentPerson, Models.Tag tag) : base(currentPerson)
        {
            Tag = tag;            
            PageTitle = tag.TagName;
            EntityName = "Tag";
            
            EditTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Edit(tag));
            ManageTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Index());
            UserHasTagManagePermissions = new TagManageFeature().HasPermissionByPerson(currentPerson);

            BasicProjectInfoGridName = "tagProjectListGrid";

            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} with this Tag",
                ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} with this Tag",
                SaveFiltersInCookie = true
            };
            
            BasicProjectInfoGridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(tag));
        }
    }
}
