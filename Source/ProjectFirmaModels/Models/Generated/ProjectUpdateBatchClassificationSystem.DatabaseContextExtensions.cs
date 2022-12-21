//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatchClassificationSystem]
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
        public static ProjectUpdateBatchClassificationSystem GetProjectUpdateBatchClassificationSystem(this IQueryable<ProjectUpdateBatchClassificationSystem> projectUpdateBatchClassificationSystems, int projectUpdateBatchClassificationSystemID)
        {
            var projectUpdateBatchClassificationSystem = projectUpdateBatchClassificationSystems.SingleOrDefault(x => x.ProjectUpdateBatchClassificationSystemID == projectUpdateBatchClassificationSystemID);
            Check.RequireNotNullThrowNotFound(projectUpdateBatchClassificationSystem, "ProjectUpdateBatchClassificationSystem", projectUpdateBatchClassificationSystemID);
            return projectUpdateBatchClassificationSystem;
        }

    }
}