﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectProjectStatusViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectProjectStatus
{
    public class EditProjectProjectStatusViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [StringLength(ProjectFirmaModels.Models.ProjectProjectStatus.FieldLengths.ProjectProjectStatusComment)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusComments)]
        public string ProjectProjectStatusComment { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Status)]
        public int ProjectStatusID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusUpdateDate)]
        public DateTime? ProjectStatusUpdateDate { get; set; }

        public DateTime? ProjectStatusUpdateTime { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsFinalStatusUpdate)]
        public bool IsFinalStatusUpdate { get; set; }

        [StringLength(ProjectFirmaModels.Models.ProjectProjectStatus.FieldLengths.LessonsLearned)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusLessonsLearned)]
        public string LessonsLearned { get; set; }



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectProjectStatusViewModel()
        {
            IsFinalStatusUpdate = false;
        }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectProjectStatusViewModel(DateTime projectStatusUpdateDate)
        {
            ProjectStatusUpdateDate = projectStatusUpdateDate;
            IsFinalStatusUpdate = false;
        }


        public EditProjectProjectStatusViewModel(ProjectFirmaModels.Models.ProjectProjectStatus projectProjectStatus)
        {
            ProjectProjectStatusComment = projectProjectStatus.ProjectProjectStatusComment;
            LessonsLearned = projectProjectStatus.LessonsLearned;
            ProjectStatusID = projectProjectStatus.ProjectStatusID;
            ProjectStatusUpdateDate = projectProjectStatus.ProjectProjectStatusUpdateDate;
            IsFinalStatusUpdate = projectProjectStatus.IsFinalStatusUpdate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ProjectProjectStatus projectProjectStatus, FirmaSession currentFirmaSession)
        {
            projectProjectStatus.ProjectProjectStatusComment = ProjectProjectStatusComment;
            if (IsFinalStatusUpdate)
            {
                projectProjectStatus.LessonsLearned = LessonsLearned;
            }
            else
            {
                projectProjectStatus.LessonsLearned = null;
            }
            projectProjectStatus.ProjectStatusID = ProjectStatusID;

            if (ProjectStatusUpdateTime.HasValue && ProjectStatusUpdateDate.HasValue)
            {
                var year = ProjectStatusUpdateDate.Value.Year;
                var month = ProjectStatusUpdateDate.Value.Month;
                var day = ProjectStatusUpdateDate.Value.Day;
                var hours = ProjectStatusUpdateTime.Value.Hour;
                var minutes = ProjectStatusUpdateTime.Value.Minute;
                var seconds = 0;
                projectProjectStatus.ProjectProjectStatusUpdateDate = new DateTime(year, month, day, hours, minutes, seconds);
            }
            else
            {
                projectProjectStatus.ProjectProjectStatusUpdateDate = ProjectStatusUpdateDate.Value;
            }

            projectProjectStatus.IsFinalStatusUpdate = IsFinalStatusUpdate;
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
            if (string.IsNullOrEmpty(LessonsLearned) && IsFinalStatusUpdate)
            {
                errors.Add(new ValidationResult($"Lessons Learned must be entered for Final Status Updates."));
            }

            return errors;
        }
    }
}
