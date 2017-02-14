//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentSubGoal]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AssessmentSubGoal GetAssessmentSubGoal(this IQueryable<AssessmentSubGoal> assessmentSubGoals, int assessmentSubGoalID)
        {
            var assessmentSubGoal = assessmentSubGoals.SingleOrDefault(x => x.AssessmentSubGoalID == assessmentSubGoalID);
            Check.RequireNotNullThrowNotFound(assessmentSubGoal, "AssessmentSubGoal", assessmentSubGoalID);
            return assessmentSubGoal;
        }

        public static void DeleteAssessmentSubGoal(this List<int> assessmentSubGoalIDList)
        {
            if(assessmentSubGoalIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAssessmentSubGoals.RemoveRange(HttpRequestStorage.DatabaseEntities.AssessmentSubGoals.Where(x => assessmentSubGoalIDList.Contains(x.AssessmentSubGoalID)));
            }
        }

        public static void DeleteAssessmentSubGoal(this ICollection<AssessmentSubGoal> assessmentSubGoalsToDelete)
        {
            if(assessmentSubGoalsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllAssessmentSubGoals.RemoveRange(assessmentSubGoalsToDelete);
            }
        }

        public static void DeleteAssessmentSubGoal(this int assessmentSubGoalID)
        {
            DeleteAssessmentSubGoal(new List<int> { assessmentSubGoalID });
        }

        public static void DeleteAssessmentSubGoal(this AssessmentSubGoal assessmentSubGoalToDelete)
        {
            DeleteAssessmentSubGoal(new List<AssessmentSubGoal> { assessmentSubGoalToDelete });
        }
    }
}