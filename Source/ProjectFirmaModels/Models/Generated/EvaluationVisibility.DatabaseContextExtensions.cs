//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationVisibility]
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
        public static EvaluationVisibility GetEvaluationVisibility(this IQueryable<EvaluationVisibility> evaluationVisibilities, int evaluationVisibilityID)
        {
            var evaluationVisibility = evaluationVisibilities.SingleOrDefault(x => x.EvaluationVisibilityID == evaluationVisibilityID);
            Check.RequireNotNullThrowNotFound(evaluationVisibility, "EvaluationVisibility", evaluationVisibilityID);
            return evaluationVisibility;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteEvaluationVisibility(this IQueryable<EvaluationVisibility> evaluationVisibilities, List<int> evaluationVisibilityIDList)
        {
            if(evaluationVisibilityIDList.Any())
            {
                evaluationVisibilities.Where(x => evaluationVisibilityIDList.Contains(x.EvaluationVisibilityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteEvaluationVisibility(this IQueryable<EvaluationVisibility> evaluationVisibilities, ICollection<EvaluationVisibility> evaluationVisibilitiesToDelete)
        {
            if(evaluationVisibilitiesToDelete.Any())
            {
                var evaluationVisibilityIDList = evaluationVisibilitiesToDelete.Select(x => x.EvaluationVisibilityID).ToList();
                evaluationVisibilities.Where(x => evaluationVisibilityIDList.Contains(x.EvaluationVisibilityID)).Delete();
            }
        }

        public static void DeleteEvaluationVisibility(this IQueryable<EvaluationVisibility> evaluationVisibilities, int evaluationVisibilityID)
        {
            DeleteEvaluationVisibility(evaluationVisibilities, new List<int> { evaluationVisibilityID });
        }

        public static void DeleteEvaluationVisibility(this IQueryable<EvaluationVisibility> evaluationVisibilities, EvaluationVisibility evaluationVisibilityToDelete)
        {
            DeleteEvaluationVisibility(evaluationVisibilities, new List<EvaluationVisibility> { evaluationVisibilityToDelete });
        }
    }
}