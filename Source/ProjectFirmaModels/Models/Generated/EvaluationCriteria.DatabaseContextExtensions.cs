//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriteria]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EvaluationCriteria GetEvaluationCriteria(this IQueryable<EvaluationCriteria> evaluationCriterias, int evaluationCriteriaID)
        {
            var evaluationCriteria = evaluationCriterias.SingleOrDefault(x => x.EvaluationCriteriaID == evaluationCriteriaID);
            Check.RequireNotNullThrowNotFound(evaluationCriteria, "EvaluationCriteria", evaluationCriteriaID);
            return evaluationCriteria;
        }

    }
}