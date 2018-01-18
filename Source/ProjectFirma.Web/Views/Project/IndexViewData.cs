/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string ProposeNewProjectUrl;
        public readonly string ProjectUpdatesUrl;
        public readonly bool DisplayActionButtons;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = $"Full {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} List";

            GridSpec = new IndexGridSpec(currentPerson) {ObjectNameSingular = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}", ObjectNamePlural = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true};


            if (new ProjectCreateNewFeature().HasPermissionByPerson(CurrentPerson))
            {
                GridSpec.CustomExcelDownloadUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());
            }
            else if (currentPerson.RoleID == Models.Role.ProjectSteward.RoleID)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.DenyCreateProject()), $"New {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}");
            }

            GridName = "projectsGrid";
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Instructions(null));
            ProjectUpdatesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            DisplayActionButtons = !currentPerson.IsAnonymousOrUnassigned;
        }
    }
}
