/*-----------------------------------------------------------------------
<copyright file="EditProjectCustomAttributesViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectCustomAttributes = ProjectFirmaModels.Models.ProjectCustomAttributes;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectCustomAttributesViewModel : FormViewModel
    {
        public ProjectCustomAttributes ProjectCustomAttributes { get; set; }

        public IProject Project { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectCustomAttributesViewModel()
        {
        }

        public EditProjectCustomAttributesViewModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            ProjectCustomAttributes = new ProjectCustomAttributes(project, currentFirmaSession);
            Project = project;
        }

        public EditProjectCustomAttributesViewModel(ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
            ProjectCustomAttributes = new ProjectCustomAttributes(projectUpdateBatch.ProjectUpdate, currentFirmaSession);
            Project = projectUpdateBatch.ProjectUpdate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            ProjectCustomAttributes?.UpdateModel(project, currentFirmaSession);
        }
    }
}