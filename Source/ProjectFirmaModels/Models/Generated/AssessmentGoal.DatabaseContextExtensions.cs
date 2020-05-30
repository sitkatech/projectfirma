//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentGoal]
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
        public static AssessmentGoal GetAssessmentGoal(this IQueryable<AssessmentGoal> assessmentGoals, int assessmentGoalID)
        {
            var assessmentGoal = assessmentGoals.SingleOrDefault(x => x.AssessmentGoalID == assessmentGoalID);
            Check.RequireNotNullThrowNotFound(assessmentGoal, "AssessmentGoal", assessmentGoalID);
            return assessmentGoal;
        }

    }
}