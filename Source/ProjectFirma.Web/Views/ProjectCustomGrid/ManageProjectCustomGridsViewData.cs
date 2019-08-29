﻿/*-----------------------------------------------------------------------
<copyright file="ManageProjectCustomGridsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomGrid
{
    public class ManageProjectCustomGridsViewData : FirmaViewData
    {
        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public string CustomizeDefaultGridUrl { get; }


        public ProjectCustomGridSpec ProjectCustomFullGridSpec { get; }
        public string ProjectCustomFullGridName { get; }
        public string ProjectCustomFullGridDataUrl { get; }
        public string CustomizeFullGridUrl { get; }

        public ManageProjectCustomGridsViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage, 
                                                List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations, 
                                                List<ProjectCustomGridConfiguration>  projectCustomFullGridConfigurations) 
                                                : base(currentPerson, firmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Custom Grids";

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentPerson, projectCustomDefaultGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "projectsCustomDefaultGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.AllActiveProjectsCustomGridDefaultJsonData());

            CustomizeDefaultGridUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.EditProjectCustomGrid(1));

            ProjectCustomFullGridSpec = new ProjectCustomGridSpec(currentPerson, projectCustomFullGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            if (currentPerson.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID)
            {
                ProjectCustomFullGridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.DenyCreateProject()), $"New {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            }
            ProjectCustomFullGridName = "projectsCustomFullGrid";
            ProjectCustomFullGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.AllActiveProjectsCustomGridFullJsonData());
            CustomizeFullGridUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.EditProjectCustomGrid(2));
        }
    }
}