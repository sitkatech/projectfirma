/*-----------------------------------------------------------------------
<copyright file="EditProposalClassificationsViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DocumentFormat.OpenXml.Presentation;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using MoreLinq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class EditProposalClassificationsViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectClassificationSimple> ProjectClassificationSimples { get; set; }
        
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ProposalClassificationsComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProposalClassificationsViewModel()
        {
        }

        public EditProposalClassificationsViewModel(List<ProjectClassificationSimple> projectClassificationSimples, ProjectFirmaModels.Models.Project project)
        {
            ProjectClassificationSimples = projectClassificationSimples;
            Comments = project.ProposalClassificationsComment;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, List<ProjectClassificationSimple> projectClassificationSimples)
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
                    existingProjectClassification.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }

            if (project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval)
            {
                project.ProposalClassificationsComment = Comments;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if (!ProjectClassificationSimples.Any())
            {
                validationResults.Add(new ValidationResult($"You must select at least one {FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel()} per {FieldDefinitionEnum.ClassificationSystem.ToType().GetFieldDefinitionLabel()}"));
            }

            ProjectClassificationSimples.Select(x => x.ClassificationSystemID).Distinct().ForEach(s =>
            {
                var classificationSystem =
                    HttpRequestStorage.DatabaseEntities.ClassificationSystems.GetClassificationSystem(s);
                var selectedClassifications = ProjectClassificationSimples.Where(x => x.ClassificationSystemID == s && x.Selected);
                if (!selectedClassifications.Any())
                {
                    validationResults.Add(new ValidationResult(
                        $"You must select at least one {classificationSystem.ClassificationSystemName}"));
                }
            });

            return validationResults;
        }
    }
}
