/*-----------------------------------------------------------------------
<copyright file="ExcelSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Assessment
{
    public class ProjectAssessmentExcelSpec : ExcelWorksheetSpec<IProject>
    {
        public ProjectAssessmentExcelSpec()
        {
            AddColumn($"{Models.FieldDefinition.ProjectName.GetFieldDefinitionLabel()}", project => project.DisplayName);

            foreach (var assessmentQuestion in HttpRequestStorage.DatabaseEntities.AssessmentQuestions)
            {
                var questionID = assessmentQuestion.AssessmentQuestionID;
                AddColumn($"Q {assessmentQuestion.AssessmentQuestionID}", project =>
                {
                    var questionAnswer = project.GetQuestionAnswers().SingleOrDefault(x => x.AssessmentQuestionID == questionID);
                    return questionAnswer == null ? ViewUtilities.NoAnswerProvided : questionAnswer.Answer.ToYesNo(ViewUtilities.NoAnswerProvided);
                });
            }
        }
    }

    public class QuestionsExcelSpec : ExcelWorksheetSpec<AssessmentQuestion>
    {
        public QuestionsExcelSpec()
        {
            AddColumn("Question ID", question => question.AssessmentQuestionID);
            AddColumn("Goal", question => question.AssessmentSubGoal.AssessmentGoal.DisplayName);
            AddColumn("Sub Goal", question => question.AssessmentSubGoal.DisplayName);
            AddColumn("Question", question => question.AssessmentQuestionText);
            AddColumn("Count of Yes Answers", question => question.GetCountOfYesAnswers());
            AddColumn("Count of No Answers", question => question.GetCountOfNoAnswers());
        }
    }
}
