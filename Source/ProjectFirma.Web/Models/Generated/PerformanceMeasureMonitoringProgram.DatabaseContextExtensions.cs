//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureMonitoringProgram]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureMonitoringProgram GetPerformanceMeasureMonitoringProgram(this IQueryable<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringPrograms, int performanceMeasureMonitoringProgramID)
        {
            var performanceMeasureMonitoringProgram = performanceMeasureMonitoringPrograms.SingleOrDefault(x => x.PerformanceMeasureMonitoringProgramID == performanceMeasureMonitoringProgramID);
            Check.RequireNotNullThrowNotFound(performanceMeasureMonitoringProgram, "PerformanceMeasureMonitoringProgram", performanceMeasureMonitoringProgramID);
            return performanceMeasureMonitoringProgram;
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this List<int> performanceMeasureMonitoringProgramIDList)
        {
            if(performanceMeasureMonitoringProgramIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureMonitoringPrograms.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureMonitoringPrograms.Where(x => performanceMeasureMonitoringProgramIDList.Contains(x.PerformanceMeasureMonitoringProgramID)));
            }
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this ICollection<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringProgramsToDelete)
        {
            if(performanceMeasureMonitoringProgramsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureMonitoringPrograms.RemoveRange(performanceMeasureMonitoringProgramsToDelete);
            }
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this int performanceMeasureMonitoringProgramID)
        {
            DeletePerformanceMeasureMonitoringProgram(new List<int> { performanceMeasureMonitoringProgramID });
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this PerformanceMeasureMonitoringProgram performanceMeasureMonitoringProgramToDelete)
        {
            DeletePerformanceMeasureMonitoringProgram(new List<PerformanceMeasureMonitoringProgram> { performanceMeasureMonitoringProgramToDelete });
        }
    }
}