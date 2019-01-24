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

using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Tag
{
    public class DetailViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.Tag Tag;
        public readonly string EditTagUrl;
        public readonly string ManageTagsUrl;
        public readonly bool UserHasTagManagePermissions;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;

        public DetailViewData(Person currentPerson, ProjectFirmaModels.Models.Tag tag) : base(currentPerson)
        {
            Tag = tag;            
            PageTitle = tag.TagName;
            EntityName = "Tag";
            
            EditTagUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Edit(tag));
            ManageTagsUrl = SitkaRoute<TagController>.BuildUrlFromExpression(c => c.Index());
            UserHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);

            BasicProjectInfoGridName = "tagProjectListGrid";

            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} with this Tag",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} with this Tag",
                SaveFiltersInCookie = true
            };
            
            BasicProjectInfoGridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(tag));
        }
    }
}
