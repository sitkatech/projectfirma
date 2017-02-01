//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentSubGoal]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteAssessmentSubGoal(this IQueryable<AssessmentSubGoal> assessmentSubGoals, List<int> assessmentSubGoalIDList)
        {
            if(assessmentSubGoalIDList.Any())
            {
                assessmentSubGoals.Where(x => assessmentSubGoalIDList.Contains(x.AssessmentSubGoalID)).Delete();
            }
        }

        public static void DeleteAssessmentSubGoal(this IQueryable<AssessmentSubGoal> assessmentSubGoals, ICollection<AssessmentSubGoal> assessmentSubGoalsToDelete)
        {
            if(assessmentSubGoalsToDelete.Any())
            {
                var assessmentSubGoalIDList = assessmentSubGoalsToDelete.Select(x => x.AssessmentSubGoalID).ToList();
                assessmentSubGoals.Where(x => assessmentSubGoalIDList.Contains(x.AssessmentSubGoalID)).Delete();
            }
        }

        public static void DeleteAssessmentSubGoal(this IQueryable<AssessmentSubGoal> assessmentSubGoals, int assessmentSubGoalID)
        {
            DeleteAssessmentSubGoal(assessmentSubGoals, new List<int> { assessmentSubGoalID });
        }

        public static void DeleteAssessmentSubGoal(this IQueryable<AssessmentSubGoal> assessmentSubGoals, AssessmentSubGoal assessmentSubGoalToDelete)
        {
            DeleteAssessmentSubGoal(assessmentSubGoals, new List<AssessmentSubGoal> { assessmentSubGoalToDelete });
        }
    }
}