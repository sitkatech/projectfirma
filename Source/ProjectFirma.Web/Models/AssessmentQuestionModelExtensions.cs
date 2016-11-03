using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public static class AssessmentQuestionModelExtensions
    {
        public static FancyTreeNode ToFancyTreeNode(this AssessmentQuestion assessmentQuestion, List<IQuestionAnswer> projectAssessmentQuestions)
        {
            var projectAssessmentQuestion = projectAssessmentQuestions != null && projectAssessmentQuestions.Any()
                ? projectAssessmentQuestions.SingleOrDefault(x => x.AssessmentQuestionID == assessmentQuestion.AssessmentQuestionID)
                : null;
            var answer = projectAssessmentQuestion != null ? projectAssessmentQuestion.Answer : null;
            var fancyTreeNode = new FancyTreeNode(assessmentQuestion.AssessmentQuestionText, assessmentQuestion.AssessmentQuestionID.ToString(), false)
            {
                Answer = answer.HasValue ? answer.ToYesNo() : ViewUtilities.NoAnswerProvided
            };
            return fancyTreeNode;
        }
    }
}