//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequestUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceRequestUpdate GetProjectFundingSourceRequestUpdate(this IQueryable<ProjectFundingSourceRequestUpdate> projectFundingSourceRequestUpdates, int projectFundingSourceRequestUpdateID)
        {
            var projectFundingSourceRequestUpdate = projectFundingSourceRequestUpdates.SingleOrDefault(x => x.ProjectFundingSourceRequestUpdateID == projectFundingSourceRequestUpdateID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceRequestUpdate, "ProjectFundingSourceRequestUpdate", projectFundingSourceRequestUpdateID);
            return projectFundingSourceRequestUpdate;
        }

        public static void DeleteProjectFundingSourceRequestUpdate(this List<int> projectFundingSourceRequestUpdateIDList)
        {
            if(projectFundingSourceRequestUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequestUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectFundingSourceRequestUpdates.Where(x => projectFundingSourceRequestUpdateIDList.Contains(x.ProjectFundingSourceRequestUpdateID)));
            }
        }

        public static void DeleteProjectFundingSourceRequestUpdate(this ICollection<ProjectFundingSourceRequestUpdate> projectFundingSourceRequestUpdatesToDelete)
        {
            if(projectFundingSourceRequestUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequestUpdates.RemoveRange(projectFundingSourceRequestUpdatesToDelete);
            }
        }

        public static void DeleteProjectFundingSourceRequestUpdate(this int projectFundingSourceRequestUpdateID)
        {
            DeleteProjectFundingSourceRequestUpdate(new List<int> { projectFundingSourceRequestUpdateID });
        }

        public static void DeleteProjectFundingSourceRequestUpdate(this ProjectFundingSourceRequestUpdate projectFundingSourceRequestUpdateToDelete)
        {
            DeleteProjectFundingSourceRequestUpdate(new List<ProjectFundingSourceRequestUpdate> { projectFundingSourceRequestUpdateToDelete });
        }
    }
}