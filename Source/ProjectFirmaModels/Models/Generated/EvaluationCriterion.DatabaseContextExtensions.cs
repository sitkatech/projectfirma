//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriterion]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EvaluationCriterion GetEvaluationCriterion(this IQueryable<EvaluationCriterion> evaluationCriterions, int evaluationCriterionID)
        {
            var evaluationCriterion = evaluationCriterions.SingleOrDefault(x => x.EvaluationCriterionID == evaluationCriterionID);
            Check.RequireNotNullThrowNotFound(evaluationCriterion, "EvaluationCriterion", evaluationCriterionID);
            return evaluationCriterion;
        }

    }
}