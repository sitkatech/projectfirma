//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationStatus]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EvaluationStatus GetEvaluationStatus(this IQueryable<EvaluationStatus> evaluationStatuses, int evaluationStatusID)
        {
            var evaluationStatus = evaluationStatuses.SingleOrDefault(x => x.EvaluationStatusID == evaluationStatusID);
            Check.RequireNotNullThrowNotFound(evaluationStatus, "EvaluationStatus", evaluationStatusID);
            return evaluationStatus;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteEvaluationStatus(this IQueryable<EvaluationStatus> evaluationStatuses, List<int> evaluationStatusIDList)
        {
            if(evaluationStatusIDList.Any())
            {
                evaluationStatuses.Where(x => evaluationStatusIDList.Contains(x.EvaluationStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteEvaluationStatus(this IQueryable<EvaluationStatus> evaluationStatuses, ICollection<EvaluationStatus> evaluationStatusesToDelete)
        {
            if(evaluationStatusesToDelete.Any())
            {
                var evaluationStatusIDList = evaluationStatusesToDelete.Select(x => x.EvaluationStatusID).ToList();
                evaluationStatuses.Where(x => evaluationStatusIDList.Contains(x.EvaluationStatusID)).Delete();
            }
        }

        public static void DeleteEvaluationStatus(this IQueryable<EvaluationStatus> evaluationStatuses, int evaluationStatusID)
        {
            DeleteEvaluationStatus(evaluationStatuses, new List<int> { evaluationStatusID });
        }

        public static void DeleteEvaluationStatus(this IQueryable<EvaluationStatus> evaluationStatuses, EvaluationStatus evaluationStatusToDelete)
        {
            DeleteEvaluationStatus(evaluationStatuses, new List<EvaluationStatus> { evaluationStatusToDelete });
        }
    }
}