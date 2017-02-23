/*-----------------------------------------------------------------------
<copyright file="ProposedProjectAssessmentQuestionSimple.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
namespace ProjectFirma.Web.Models
{
    public class ProposedProjectAssessmentQuestionSimple
    {
        public int ProposedProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProposedProjectAssessmentQuestionSimple()
        {
        }

        //Build a simple for a question that has already been answered
        public ProposedProjectAssessmentQuestionSimple(ProposedProjectAssessmentQuestion proposedProjectAssessmentQuestion)
        {
            ProposedProjectID = proposedProjectAssessmentQuestion.ProposedProjectID;
            AssessmentQuestionID = proposedProjectAssessmentQuestion.AssessmentQuestionID;
            Answer = proposedProjectAssessmentQuestion.Answer;
        }


        //Build a simple when we only have the question, but no answer
        public ProposedProjectAssessmentQuestionSimple(AssessmentQuestion assessmentQuestion, ProposedProject proposedProject)
        {
            AssessmentQuestionID = assessmentQuestion.AssessmentQuestionID;
            ProposedProjectID = proposedProject.ProposedProjectID;
            Answer = null;
        }
    }
}
