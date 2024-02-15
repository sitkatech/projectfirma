﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectClassificationsForProjectViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectClassificationsForProjectViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectClassificationSimple> ProjectClassificationSimples { get; set; }
        public bool IsClassificationSystemRequired { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectClassificationsForProjectViewModel()
        {            
        }
        
        public EditProjectClassificationsForProjectViewModel(List<ProjectClassificationSimple> projectClassificationSimples, bool isClassificationSystemRequired)
        {
            ProjectClassificationSimples = projectClassificationSimples;
            IsClassificationSystemRequired = isClassificationSystemRequired;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, List<ProjectClassificationSimple> projectClassificationSimples)
        {
            foreach (var projectClassificationSimple in projectClassificationSimples)
            {
                var alreadySelected = project.ProjectClassifications
                    .SingleOrDefault(x => x.ClassificationID == projectClassificationSimple.ClassificationID) != null;

                if (projectClassificationSimple.Selected && !alreadySelected)
                {
                    var projectClassification = new ProjectFirmaModels.Models.ProjectClassification(project.ProjectID,
                        projectClassificationSimple.ClassificationID)
                    {
                        ProjectClassificationNotes = projectClassificationSimple.ProjectClassificationNotes
                    };

                    project.ProjectClassifications.Add(projectClassification);
                }
                else if (projectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProjectClassification = project.ProjectClassifications.First(x => x.ClassificationID == projectClassificationSimple.ClassificationID);
                    existingProjectClassification.ProjectClassificationNotes = projectClassificationSimple.ProjectClassificationNotes;
                }
                else if (!projectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProjectClassification = project.ProjectClassifications.First(x => x.ClassificationID == projectClassificationSimple.ClassificationID);
                    existingProjectClassification.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if (IsClassificationSystemRequired && !ProjectClassificationSimples.Any(x => x.Selected))
            {
                validationResults.Add(new ValidationResult(
                    $"You must select at least one {FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel()} per {FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel()} System."));
            }

            return validationResults;
        }
    }
}
