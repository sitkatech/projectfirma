/*-----------------------------------------------------------------------
<copyright file="EditAssessmentViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class EditAssessmentViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectAssessmentQuestionSimple> ProjectAssessmentQuestionSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAssessmentViewModel()
        {
            
        }

       public EditAssessmentViewModel(List<ProjectAssessmentQuestionSimple> projectAssessmentQuestionSimples)
        {
            ProjectAssessmentQuestionSimples = projectAssessmentQuestionSimples;
        }   
 

        public void UpdateModel(ProjectFirmaModels.Models.Project project)
        {
            foreach (var projectAssessmentQuestion in project.ProjectAssessmentQuestions)
            {
                projectAssessmentQuestion.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
            foreach (var simple in ProjectAssessmentQuestionSimples)
            {
                project.ProjectAssessmentQuestions.Add(new ProjectFirmaModels.Models.ProjectAssessmentQuestion(simple));
            }                       
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            //Validate here!

            return validationResults;
        }
    }
}
