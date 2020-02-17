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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirmaModels.Models;
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

        public EditProjectCustomAttributesViewModel(ProjectFirmaModels.Models.Project project)
        {
            ProjectCustomAttributes = new ProjectCustomAttributes(project);
            Project = project;
        }

        public EditProjectCustomAttributesViewModel(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectCustomAttributes = new ProjectCustomAttributes(projectUpdateBatch.ProjectUpdate);
            Project = projectUpdateBatch.ProjectUpdate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            ProjectCustomAttributes?.UpdateModel(project, currentFirmaSession);
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();
            errors.AddRange(ValidateAllCustomAttributes().GetWarningMessages().Select(m => new ValidationResult(m)));
            return errors;
        }

        public ProjectCustomAttributesValidationResult ValidateAllCustomAttributes()
        {
            var customAttributesValidationResult = new ProjectCustomAttributesValidationResult(Project);
            return customAttributesValidationResult;
        }
    }
}