using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Models
{
    public static class AssessmentSubGoalModelExtensions
    {
        public static FancyTreeNode ToFancyTreeNode(this AssessmentSubGoal assessmentSubGoal, List<IQuestionAnswer> projectAssessmentQuestionsDict)
        {
            var fancyTreeNode = new FancyTreeNode(assessmentSubGoal.DisplayName, assessmentSubGoal.AssessmentGoalID.ToString(), false)
            {
                Children = assessmentSubGoal.ActiveQuestions.Select(x => x.ToFancyTreeNode(projectAssessmentQuestionsDict)).ToList()
            };
            return fancyTreeNode;
        }

        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<AssessmentSubGoal> assessmentSubGoals)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();
            foreach (var assessmentGoalGrouping in assessmentSubGoals.GroupBy(x => x.AssessmentGoal).OrderBy(x => x.Key.AssessmentGoalNumber))
            {
                var assessmentGoal = assessmentGoalGrouping.Key;
                var topLevelGroup = new SelectListGroup() { Name = assessmentGoal.DisplayName };
                groups.Add(assessmentGoal.DisplayName, topLevelGroup);

                foreach (var assessmentSubGoal in assessmentGoalGrouping.OrderBy(x => x.AssessmentSubGoalNumber))
                {
                    selectListItems.Add(new SelectListItem { Value = assessmentSubGoal.AssessmentSubGoalID.ToString(), Text = assessmentSubGoal.DisplayName, Group = topLevelGroup });
                }

            }
            return selectListItems;
        }
    }
}