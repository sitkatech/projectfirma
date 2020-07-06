//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentSubGoal]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AssessmentSubGoal GetAssessmentSubGoal(this IQueryable<AssessmentSubGoal> assessmentSubGoals, int assessmentSubGoalID)
        {
            var assessmentSubGoal = assessmentSubGoals.SingleOrDefault(x => x.AssessmentSubGoalID == assessmentSubGoalID);
            Check.RequireNotNullThrowNotFound(assessmentSubGoal, "AssessmentSubGoal", assessmentSubGoalID);
            return assessmentSubGoal;
        }

    }
}