/*-----------------------------------------------------------------------
<copyright file="EditAssessmentViewModel.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class EditAssessmentViewModel : FormViewModel, IValidatableObject
    {
        public List<ProposedProjectAssessmentQuestionSimple> ProposedProjectAssessmentQuestionSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAssessmentViewModel()
        {
            
        }

       public EditAssessmentViewModel(List<ProposedProjectAssessmentQuestionSimple> proposedProjectAssessmentQuestionSimples)
        {
            ProposedProjectAssessmentQuestionSimples = proposedProjectAssessmentQuestionSimples;
        }   
 

        public void UpdateModel(Models.ProposedProject proposedProject)
        {
            proposedProject.ProposedProjectAssessmentQuestions.DeleteProposedProjectAssessmentQuestion();
            foreach (var simple in ProposedProjectAssessmentQuestionSimples)
            {
                proposedProject.ProposedProjectAssessmentQuestions.Add(new ProposedProjectAssessmentQuestion(simple));
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
