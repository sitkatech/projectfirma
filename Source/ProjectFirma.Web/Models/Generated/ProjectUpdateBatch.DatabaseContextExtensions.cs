//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatch]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateBatch GetProjectUpdateBatch(this IQueryable<ProjectUpdateBatch> projectUpdateBatches, int projectUpdateBatchID)
        {
            var projectUpdateBatch = projectUpdateBatches.SingleOrDefault(x => x.ProjectUpdateBatchID == projectUpdateBatchID);
            Check.RequireNotNullThrowNotFound(projectUpdateBatch, "ProjectUpdateBatch", projectUpdateBatchID);
            return projectUpdateBatch;
        }

        public static void DeleteProjectUpdateBatch(this List<int> projectUpdateBatchIDList)
        {
            if(projectUpdateBatchIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateBatches.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectUpdateBatches.Where(x => projectUpdateBatchIDList.Contains(x.ProjectUpdateBatchID)));
            }
        }

        public static void DeleteProjectUpdateBatch(this ICollection<ProjectUpdateBatch> projectUpdateBatchesToDelete)
        {
            if(projectUpdateBatchesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectUpdateBatches.RemoveRange(projectUpdateBatchesToDelete);
            }
        }

        public static void DeleteProjectUpdateBatch(this int projectUpdateBatchID)
        {
            DeleteProjectUpdateBatch(new List<int> { projectUpdateBatchID });
        }

        public static void DeleteProjectUpdateBatch(this ProjectUpdateBatch projectUpdateBatchToDelete)
        {
            DeleteProjectUpdateBatch(new List<ProjectUpdateBatch> { projectUpdateBatchToDelete });
        }
    }
}