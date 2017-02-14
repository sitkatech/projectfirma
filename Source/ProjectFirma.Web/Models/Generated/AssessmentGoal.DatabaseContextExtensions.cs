//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentGoal]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AssessmentGoal GetAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, int assessmentGoalID)
        {
            var assessmentGoal = assessmentGoals.SingleOrDefault(x => x.AssessmentGoalID == assessmentGoalID);
            Check.RequireNotNullThrowNotFound(assessmentGoal, "AssessmentGoal", assessmentGoalID);
            return assessmentGoal;
        }

        public static void DeleteAssessmentGoal(this List<int> assessmentGoalIDList)
        {
            if(assessmentGoalIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAssessmentGoals.RemoveRange(HttpRequestStorage.DatabaseEntities.AssessmentGoals.Where(x => assessmentGoalIDList.Contains(x.AssessmentGoalID)));
            }
        }

        public static void DeleteAssessmentGoal(this ICollection<AssessmentGoal> assessmentGoalsToDelete)
        {
            if(assessmentGoalsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAssessmentGoals.RemoveRange(assessmentGoalsToDelete);
            }
        }

        public static void DeleteAssessmentGoal(this int assessmentGoalID)
        {
            DeleteAssessmentGoal(new List<int> { assessmentGoalID });
        }

        public static void DeleteAssessmentGoal(this AssessmentGoal assessmentGoalToDelete)
        {
            DeleteAssessmentGoal(new List<AssessmentGoal> { assessmentGoalToDelete });
        }
    }
}