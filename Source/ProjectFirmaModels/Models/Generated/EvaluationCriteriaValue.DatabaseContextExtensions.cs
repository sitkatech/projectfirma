//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriteriaValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EvaluationCriteriaValue GetEvaluationCriteriaValue(this IQueryable<EvaluationCriteriaValue> evaluationCriteriaValues, int evaluationCriteriaValueID)
        {
            var evaluationCriteriaValue = evaluationCriteriaValues.SingleOrDefault(x => x.EvaluationCriteriaValueID == evaluationCriteriaValueID);
            Check.RequireNotNullThrowNotFound(evaluationCriteriaValue, "EvaluationCriteriaValue", evaluationCriteriaValueID);
            return evaluationCriteriaValue;
        }

    }
}