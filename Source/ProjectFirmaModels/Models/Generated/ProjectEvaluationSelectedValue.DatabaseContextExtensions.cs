//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectEvaluationSelectedValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectEvaluationSelectedValue GetProjectEvaluationSelectedValue(this IQueryable<ProjectEvaluationSelectedValue> projectEvaluationSelectedValues, int projectEvaluationSelectedValueID)
        {
            var projectEvaluationSelectedValue = projectEvaluationSelectedValues.SingleOrDefault(x => x.ProjectEvaluationSelectedValueID == projectEvaluationSelectedValueID);
            Check.RequireNotNullThrowNotFound(projectEvaluationSelectedValue, "ProjectEvaluationSelectedValue", projectEvaluationSelectedValueID);
            return projectEvaluationSelectedValue;
        }

    }
}