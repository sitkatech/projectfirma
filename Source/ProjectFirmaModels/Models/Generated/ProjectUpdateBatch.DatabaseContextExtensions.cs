//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatch]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateBatch GetProjectUpdateBatch(this IQueryable<ProjectUpdateBatch> projectUpdateBatches, int projectUpdateBatchID)
        {
            var projectUpdateBatch = projectUpdateBatches.SingleOrDefault(x => x.ProjectUpdateBatchID == projectUpdateBatchID);
            Check.RequireNotNullThrowNotFound(projectUpdateBatch, "ProjectUpdateBatch", projectUpdateBatchID);
            return projectUpdateBatch;
        }

    }
}