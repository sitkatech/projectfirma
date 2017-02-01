//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentGoal]
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
        public static AssessmentGoal GetAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, int assessmentGoalID)
        {
            var assessmentGoal = assessmentGoals.SingleOrDefault(x => x.AssessmentGoalID == assessmentGoalID);
            Check.RequireNotNullThrowNotFound(assessmentGoal, "AssessmentGoal", assessmentGoalID);
            return assessmentGoal;
        }

        public static void DeleteAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, List<int> assessmentGoalIDList)
        {
            if(assessmentGoalIDList.Any())
            {
                assessmentGoals.Where(x => assessmentGoalIDList.Contains(x.AssessmentGoalID)).Delete();
            }
        }

        public static void DeleteAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, ICollection<AssessmentGoal> assessmentGoalsToDelete)
        {
            if(assessmentGoalsToDelete.Any())
            {
                var assessmentGoalIDList = assessmentGoalsToDelete.Select(x => x.AssessmentGoalID).ToList();
                assessmentGoals.Where(x => assessmentGoalIDList.Contains(x.AssessmentGoalID)).Delete();
            }
        }

        public static void DeleteAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, int assessmentGoalID)
        {
            DeleteAssessmentGoal(assessmentGoals, new List<int> { assessmentGoalID });
        }

        public static void DeleteAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, AssessmentGoal assessmentGoalToDelete)
        {
            DeleteAssessmentGoal(assessmentGoals, new List<AssessmentGoal> { assessmentGoalToDelete });
        }
    }
}