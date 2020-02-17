//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Evaluation]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Evaluation GetEvaluation(this IQueryable<Evaluation> evaluations, int evaluationID)
        {
            var evaluation = evaluations.SingleOrDefault(x => x.EvaluationID == evaluationID);
            Check.RequireNotNullThrowNotFound(evaluation, "Evaluation", evaluationID);
            return evaluation;
        }

    }
}