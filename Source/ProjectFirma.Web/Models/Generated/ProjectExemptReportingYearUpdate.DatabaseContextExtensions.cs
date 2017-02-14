//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYearUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExemptReportingYearUpdate GetProjectExemptReportingYearUpdate(this IQueryable<ProjectExemptReportingYearUpdate> projectExemptReportingYearUpdates, int projectExemptReportingYearUpdateID)
        {
            var projectExemptReportingYearUpdate = projectExemptReportingYearUpdates.SingleOrDefault(x => x.ProjectExemptReportingYearUpdateID == projectExemptReportingYearUpdateID);
            Check.RequireNotNullThrowNotFound(projectExemptReportingYearUpdate, "ProjectExemptReportingYearUpdate", projectExemptReportingYearUpdateID);
            return projectExemptReportingYearUpdate;
        }

        public static void DeleteProjectExemptReportingYearUpdate(this List<int> projectExemptReportingYearUpdateIDList)
        {
            if(projectExemptReportingYearUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYearUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectExemptReportingYearUpdates.Where(x => projectExemptReportingYearUpdateIDList.Contains(x.ProjectExemptReportingYearUpdateID)));
            }
        }

        public static void DeleteProjectExemptReportingYearUpdate(this ICollection<ProjectExemptReportingYearUpdate> projectExemptReportingYearUpdatesToDelete)
        {
            if(projectExemptReportingYearUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExemptReportingYearUpdates.RemoveRange(projectExemptReportingYearUpdatesToDelete);
            }
        }

        public static void DeleteProjectExemptReportingYearUpdate(this int projectExemptReportingYearUpdateID)
        {
            DeleteProjectExemptReportingYearUpdate(new List<int> { projectExemptReportingYearUpdateID });
        }

        public static void DeleteProjectExemptReportingYearUpdate(this ProjectExemptReportingYearUpdate projectExemptReportingYearUpdateToDelete)
        {
            DeleteProjectExemptReportingYearUpdate(new List<ProjectExemptReportingYearUpdate> { projectExemptReportingYearUpdateToDelete });
        }
    }
}