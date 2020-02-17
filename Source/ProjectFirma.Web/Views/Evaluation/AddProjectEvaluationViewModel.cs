/*-----------------------------------------------------------------------
<copyright file="AddProjectEvaluationViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class AddProjectEvaluationViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int EvaluationID { get; set; }

        [Required(ErrorMessage = "You must select at least one item to save.")]
        public List<int> ProjectIDs { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public AddProjectEvaluationViewModel()
        {
        }

        public AddProjectEvaluationViewModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            EvaluationID = evaluation.EvaluationID;
            ProjectIDs = evaluation.ProjectEvaluations.Select(x => x.ProjectID).ToList();
        }

        public void UpdateModel(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Evaluation evaluation)
        {
            if (ProjectIDs == null || !ProjectIDs.Any())
            {
                return;
            }
            foreach (var projectID in ProjectIDs)
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Single(x => x.ProjectID == projectID);
                if (project == null)
                {
                    //bad projectID from front-end
                    continue;
                }

                // get or create a new one
                var projectEvaluation = ProjectEvaluationModelExtensions.GetOrCreateProjectEvaluation(evaluation, project);
                HttpRequestStorage.DatabaseEntities.AllProjectEvaluations.Add(projectEvaluation);
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges(currentFirmaSession);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var currentProjectEvaluations = HttpRequestStorage.DatabaseEntities.ProjectEvaluations.Where(x => x.EvaluationID == EvaluationID).ToList();

            // cannot have a project in an evaluation more than once
            var projectsAlreadyInEvaluation = currentProjectEvaluations.Where(x => ProjectIDs.Contains(x.ProjectID)).ToList();
            if (projectsAlreadyInEvaluation.Any())
            {
                var projectStringsAlreadyInEvaluation = projectsAlreadyInEvaluation.Select(x => $"\"{x.Project.ProjectName}\"").ToList();
                yield return new SitkaValidationResult<AddProjectEvaluationViewModel, List<int>>($"The following {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} are already in this evaluation: {string.Join(", ", projectStringsAlreadyInEvaluation)}. {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} must be unique in an evaluation.",m => m.ProjectIDs);
            }
        }
    }
}
