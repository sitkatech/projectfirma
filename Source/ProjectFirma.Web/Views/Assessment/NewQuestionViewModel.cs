/*-----------------------------------------------------------------------
<copyright file="NewQuestionViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class NewQuestionViewModel : FormViewModel
    {

        [Required]
        [DisplayName("Question Text")]
        [StringLength(AssessmentQuestion.FieldLengths.AssessmentQuestionText)]
        public string AssessmentQuestionText { get; set; }

        [Required]
        [DisplayName("Associated Goal and PerformanceMeasure")]
        public int AssessmentSubGoalID { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewQuestionViewModel()
        {
        }        
        
        public void UpdateModel(AssessmentQuestion question, FirmaSession currentFirmaSession)
        {
            question.AssessmentQuestionText = AssessmentQuestionText;
            question.AssessmentSubGoalID = AssessmentSubGoalID;
        }
    }
}
