//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriterionValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EvaluationCriterionValue GetEvaluationCriterionValue(this IQueryable<EvaluationCriterionValue> evaluationCriterionValues, int evaluationCriterionValueID)
        {
            var evaluationCriterionValue = evaluationCriterionValues.SingleOrDefault(x => x.EvaluationCriterionValueID == evaluationCriterionValueID);
            Check.RequireNotNullThrowNotFound(evaluationCriterionValue, "EvaluationCriterionValue", evaluationCriterionValueID);
            return evaluationCriterionValue;
        }

    }
}