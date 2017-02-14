//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceExpenditureUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceExpenditureUpdate GetProjectFundingSourceExpenditureUpdate(this IQueryable<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, int projectFundingSourceExpenditureUpdateID)
        {
            var projectFundingSourceExpenditureUpdate = projectFundingSourceExpenditureUpdates.SingleOrDefault(x => x.ProjectFundingSourceExpenditureUpdateID == projectFundingSourceExpenditureUpdateID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceExpenditureUpdate, "ProjectFundingSourceExpenditureUpdate", projectFundingSourceExpenditureUpdateID);
            return projectFundingSourceExpenditureUpdate;
        }

        public static void DeleteProjectFundingSourceExpenditureUpdate(this List<int> projectFundingSourceExpenditureUpdateIDList)
        {
            if(projectFundingSourceExpenditureUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditureUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditureUpdates.Where(x => projectFundingSourceExpenditureUpdateIDList.Contains(x.ProjectFundingSourceExpenditureUpdateID)));
            }
        }

        public static void DeleteProjectFundingSourceExpenditureUpdate(this ICollection<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdatesToDelete)
        {
            if(projectFundingSourceExpenditureUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceExpenditureUpdates.RemoveRange(projectFundingSourceExpenditureUpdatesToDelete);
            }
        }

        public static void DeleteProjectFundingSourceExpenditureUpdate(this int projectFundingSourceExpenditureUpdateID)
        {
            DeleteProjectFundingSourceExpenditureUpdate(new List<int> { projectFundingSourceExpenditureUpdateID });
        }

        public static void DeleteProjectFundingSourceExpenditureUpdate(this ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdateToDelete)
        {
            DeleteProjectFundingSourceExpenditureUpdate(new List<ProjectFundingSourceExpenditureUpdate> { projectFundingSourceExpenditureUpdateToDelete });
        }
    }
}