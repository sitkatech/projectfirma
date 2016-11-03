using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class AssessmentGoalModelExtensions
    {
        public static FancyTreeNode ToFancyTreeNode(this AssessmentGoal assessmentGoal, List<IQuestionAnswer> projectAssessmentQuestionsDict)
        {
            var fancyTreeNode = new FancyTreeNode(assessmentGoal.DisplayName, assessmentGoal.AssessmentGoalID.ToString(), false)
            {
                Children = assessmentGoal.AssessmentSubGoals.Select(x => x.ToFancyTreeNode(projectAssessmentQuestionsDict)).ToList(),
            };
            return fancyTreeNode;
        }
    }
}