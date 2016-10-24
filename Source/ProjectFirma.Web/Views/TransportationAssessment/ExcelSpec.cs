using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.TransportationAssessment
{
    public class ProjectTransportationAssessmentExcelSpec : ExcelWorksheetSpec<IProject>
    {
        public ProjectTransportationAssessmentExcelSpec()
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
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            AddColumn("Project Name", project => project.DisplayName);

            foreach (var question  in HttpRequestStorage.DatabaseEntities.TransportationQuestions)
            {
                var transportationQuestionID = question.TransportationQuestionID;
                AddColumn(string.Format("Q {0}", question.TransportationQuestionID), project =>
                {
                    var transportationQuestionAnswer = project.GetTransportationQuestionAnswers().SingleOrDefault(x => x.TransportationQuestionID == transportationQuestionID);
                    return transportationQuestionAnswer == null ? ViewUtilities.NoAnswerProvided : transportationQuestionAnswer.Answer.ToYesNo(ViewUtilities.NoAnswerProvided);
                });
            }
        }

    }
    public class TransportationQuestionsExcelSpec : ExcelWorksheetSpec<TransportationQuestion>
    {
        public TransportationQuestionsExcelSpec()
        {
            AddColumn("Question ID", question => question.TransportationQuestionID);
            AddColumn("Goal", question => question.TransportationSubGoal.TransportationGoal.DisplayName);
            AddColumn("Indicator", question => question.TransportationSubGoal.DisplayName);
            AddColumn("Question", question => question.TransportationQuestionText);
            AddColumn("Count of Yes Answers", question => question.GetCountOfYesAnswers());
            AddColumn("Count of No Answers", question => question.GetCountOfNoAnswers());
        }

    }
}