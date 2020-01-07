/*-----------------------------------------------------------------------
<copyright file="EditNoteViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectProjectStatus
{
    public class EditProjectProjectStatusViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectProjectStatus.FieldLengths.ProjectProjectStatusComment)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStatusComments)]
        public string ProjectProjectStatusComment { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStatus)]
        public int ProjectStatusID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStatusUpdateDate)]
        public DateTime? ProjectStatusUpdateDate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsFinalStatusReport)]
        public bool IsFinalStatusReport { get; set; }

        [StringLength(ProjectFirmaModels.Models.ProjectProjectStatus.FieldLengths.LessonsLearned)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStatusLessonsLearned)]
        public string LessonsLearned { get; set; }



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectProjectStatusViewModel()
        {
            IsFinalStatusReport = false;
        }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectProjectStatusViewModel(DateTime projectStatusUpdateDate)
        {
            ProjectStatusUpdateDate = projectStatusUpdateDate;
            IsFinalStatusReport = false;
        }


        public EditProjectProjectStatusViewModel(ProjectFirmaModels.Models.ProjectProjectStatus projectProjectStatus)
        {
            ProjectProjectStatusComment = projectProjectStatus.ProjectProjectStatusComment;
            LessonsLearned = projectProjectStatus.LessonsLearned;
            ProjectStatusID = projectProjectStatus.ProjectStatusID;
            ProjectStatusUpdateDate = projectProjectStatus.ProjectProjectStatusUpdateDate;
            IsFinalStatusReport = projectProjectStatus.IsFinalStatusUpdate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectProjectStatus projectProjectStatus, FirmaSession currentFirmaSession)
        {
            projectProjectStatus.ProjectProjectStatusComment = ProjectProjectStatusComment;
            if (IsFinalStatusReport)
            {
                projectProjectStatus.LessonsLearned = LessonsLearned;
            }
            else
            {
                projectProjectStatus.LessonsLearned = null;
            }
            projectProjectStatus.ProjectStatusID = ProjectStatusID;
            projectProjectStatus.ProjectProjectStatusUpdateDate = ProjectStatusUpdateDate.Value;
            projectProjectStatus.IsFinalStatusUpdate = IsFinalStatusReport;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectProjectStatus.PrimaryKey))
            {
                projectProjectStatus.ProjectProjectStatusCreateDate = DateTime.Now;
                projectProjectStatus.ProjectProjectStatusCreatePerson = currentFirmaSession.Person;
            }
            else
            {
                projectProjectStatus.ProjectProjectStatusLastEditedDate = DateTime.Now;
                projectProjectStatus.ProjectProjectStatusLastEditedPerson = currentFirmaSession.Person;
            }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            

            // Expenditures note is required if no expenditures to enter is selected
            if (string.IsNullOrEmpty(LessonsLearned) && IsFinalStatusReport)
            {
                errors.Add(new ValidationResult($"Lessons Learned must be entered for Final Status Reports."));
            }

            return errors;
        }
    }
}
