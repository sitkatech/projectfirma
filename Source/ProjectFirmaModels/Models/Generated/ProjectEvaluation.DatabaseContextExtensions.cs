//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectEvaluation]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectEvaluation GetProjectEvaluation(this IQueryable<ProjectEvaluation> projectEvaluations, int projectEvaluationID)
        {
            var projectEvaluation = projectEvaluations.SingleOrDefault(x => x.ProjectEvaluationID == projectEvaluationID);
            Check.RequireNotNullThrowNotFound(projectEvaluation, "ProjectEvaluation", projectEvaluationID);
            return projectEvaluation;
        }

    }
}