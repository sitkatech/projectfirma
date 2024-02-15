﻿/*-----------------------------------------------------------------------
<copyright file="ClassificationsViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ClassificationsViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectClassificationSimple> ProjectClassificationSimples { get; set; }
        
        [DisplayName("Comments")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ProposalClassificationsComment)]
        public string Comments { get; set; }

        public bool IsClassificationSystemRequired { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ClassificationsViewModel()
        {
        }

        public ClassificationsViewModel(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch, List<ProjectClassificationSimple> projectClassificationSimples, string projectClassificationsComment, bool isClassificationSystemRequired)
        {
            ProjectClassificationSimples = projectClassificationSimples;
            Comments = projectClassificationsComment;
            IsClassificationSystemRequired = isClassificationSystemRequired;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch, List<ProjectClassificationSimple> projectClassificationSimples, ProjectUpdateBatchClassificationSystem projectUpdateBatchClassificationSystem)
        {
            foreach (var projectClassificationSimple in projectClassificationSimples)
            {
                var alreadySelected = projectUpdateBatch.ProjectClassificationUpdates
                    .SingleOrDefault(x => x.ClassificationID == projectClassificationSimple.ClassificationID) != null;

                if (projectClassificationSimple.Selected && !alreadySelected)
                {
                    var projectClassificationUpdate = new ProjectClassificationUpdate(projectUpdateBatch.ProjectUpdateBatchID,
                        projectClassificationSimple.ClassificationID)
                    {
                        ProjectClassificationUpdateNotes = projectClassificationSimple.ProjectClassificationNotes
                    };

                    projectUpdateBatch.ProjectClassificationUpdates.Add(projectClassificationUpdate);
                }
                else if (projectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProjectClassification = projectUpdateBatch.ProjectClassificationUpdates.First(x => x.ClassificationID == projectClassificationSimple.ClassificationID);
                    existingProjectClassification.ProjectClassificationUpdateNotes = projectClassificationSimple.ProjectClassificationNotes;
                }
                else if (!projectClassificationSimple.Selected && alreadySelected)
                {
                    var existingProjectClassification = projectUpdateBatch.ProjectClassificationUpdates.First(x => x.ClassificationID == projectClassificationSimple.ClassificationID);
                    existingProjectClassification.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }

            if (projectUpdateBatch.IsSubmitted())
            {
                projectUpdateBatchClassificationSystem.ProjectClassificationsComment = Comments;
            }

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if (IsClassificationSystemRequired && !ProjectClassificationSimples.Any())
            {
                validationResults.Add(new ValidationResult($"You must select at least one {FieldDefinitionEnum.Classification.ToType().GetFieldDefinitionLabel()} per {FieldDefinitionEnum.ClassificationSystem.ToType().GetFieldDefinitionLabel()}"));
            }

            ProjectClassificationSimples.Select(x => x.ClassificationSystemID).Distinct().ForEach(s =>
            {
                var classificationSystem =
                    HttpRequestStorage.DatabaseEntities.ClassificationSystems.GetClassificationSystem(s);
                var selectedClassifications = ProjectClassificationSimples.Where(x => x.ClassificationSystemID == s && x.Selected);
                if (IsClassificationSystemRequired && !selectedClassifications.Any())
                {
                    validationResults.Add(new ValidationResult(
                        $"You must select at least one {classificationSystem.ClassificationSystemName}"));
                }
            });

            return validationResults;
        }
    }
}
