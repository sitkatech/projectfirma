using System;
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
            AddColumn("Proposal or Project", project =>
            {
                switch (project.ProjectType)
                {
                    case ProjectType.Project:
                        return "Project";
                    case ProjectType.ProposedProject:
                        return "Proposal";
                    case ProjectType.ProjectUpdate:
                        throw new ArgumentOutOfRangeException();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            AddColumn("Project Name", project => project.DisplayName);

            foreach (var assessmentQuestion in HttpRequestStorage.DatabaseEntities.AssessmentQuestions)
            {
                var questionID = assessmentQuestion.AssessmentQuestionID;
                AddColumn(string.Format("Q {0}", assessmentQuestion.AssessmentQuestionID), project =>
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