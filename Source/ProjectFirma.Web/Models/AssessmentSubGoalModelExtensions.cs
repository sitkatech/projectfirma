/*-----------------------------------------------------------------------
<copyright file="AssessmentSubGoalModelExtensions.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
