//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluation]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdEvaluation GetThresholdEvaluation(this IQueryable<ThresholdEvaluation> thresholdEvaluations, int thresholdEvaluationID)
        {
            var thresholdEvaluation = thresholdEvaluations.SingleOrDefault(x => x.ThresholdEvaluationID == thresholdEvaluationID);
            Check.RequireNotNullThrowNotFound(thresholdEvaluation, "ThresholdEvaluation", thresholdEvaluationID);
            return thresholdEvaluation;
        }

        public static void DeleteThresholdEvaluation(this IQueryable<ThresholdEvaluation> thresholdEvaluations, List<int> thresholdEvaluationIDList)
        {
            if(thresholdEvaluationIDList.Any())
            {
                thresholdEvaluations.Where(x => thresholdEvaluationIDList.Contains(x.ThresholdEvaluationID)).Delete();
            }
        }

        public static void DeleteThresholdEvaluation(this IQueryable<ThresholdEvaluation> thresholdEvaluations, ICollection<ThresholdEvaluation> thresholdEvaluationsToDelete)
        {
            if(thresholdEvaluationsToDelete.Any())
            {
                var thresholdEvaluationIDList = thresholdEvaluationsToDelete.Select(x => x.ThresholdEvaluationID).ToList();
                thresholdEvaluations.Where(x => thresholdEvaluationIDList.Contains(x.ThresholdEvaluationID)).Delete();
            }
        }

        public static void DeleteThresholdEvaluation(this IQueryable<ThresholdEvaluation> thresholdEvaluations, int thresholdEvaluationID)
        {
            DeleteThresholdEvaluation(thresholdEvaluations, new List<int> { thresholdEvaluationID });
        }

        public static void DeleteThresholdEvaluation(this IQueryable<ThresholdEvaluation> thresholdEvaluations, ThresholdEvaluation thresholdEvaluationToDelete)
        {
            DeleteThresholdEvaluation(thresholdEvaluations, new List<ThresholdEvaluation> { thresholdEvaluationToDelete });
        }
    }
}