//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStageCustomLabel]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectStageCustomLabel GetProjectStageCustomLabel(this IQueryable<ProjectStageCustomLabel> projectStageCustomLabels, int projectStageCustomLabelID)
        {
            var projectStageCustomLabel = projectStageCustomLabels.SingleOrDefault(x => x.ProjectStageCustomLabelID == projectStageCustomLabelID);
            Check.RequireNotNullThrowNotFound(projectStageCustomLabel, "ProjectStageCustomLabel", projectStageCustomLabelID);
            return projectStageCustomLabel;
        }

    }
}