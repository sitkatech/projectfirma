/*-----------------------------------------------------------------------
<copyright file="EditProjectClassificationsForProjectViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectClassificationsForProjectViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectClassificationSimple> ProjectClassificationSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectClassificationsForProjectViewModel()
        {            
        }
        
        public EditProjectClassificationsForProjectViewModel(List<ProjectClassificationSimple> projectClassificationSimples)
        {
            ProjectClassificationSimples = projectClassificationSimples;
        }

        public void UpdateModel(Models.Project project, List<ProjectClassificationSimple> projectClassificationSimples)
        {
            foreach (var projectClassificationSimple in projectClassificationSimples)
            {
                var alreadySelected = project.ProjectClassifications
                    .SingleOrDefault(x => x.ClassificationID == projectClassificationSimple.ClassificationID) != null;

                if (projectClassificationSimple.Selected && !alreadySelected)
                {
                    var projectClassification = new ProjectClassification(project.ProjectID,
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
                    existingProjectClassification.DeleteProjectClassification();
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

            if (!ProjectClassificationSimples.Any(x => x.Selected))
            {
                validationResults.Add(new ValidationResult(string.Format("You must select at least one {0}.", Models.FieldDefinition.Classification.GetFieldDefinitionLabel())));
            }

            var classifications = HttpRequestStorage.DatabaseEntities.Classifications.ToList();
            foreach (var projectClassificationSimple in ProjectClassificationSimples)
            {
                if (projectClassificationSimple.Selected && string.IsNullOrWhiteSpace(projectClassificationSimple.ProjectClassificationNotes))
                {
                    var classificationName = classifications.Single(x => x.ClassificationID == projectClassificationSimple.ClassificationID).DisplayName;
                    validationResults.Add(new ValidationResult(String.Format("You must include notes for {0}", classificationName)));
                }
            }
            return validationResults;
        }
    }
}
