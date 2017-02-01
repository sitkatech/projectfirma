//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureMonitoringProgram]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeletePerformanceMeasureMonitoringProgram(this IQueryable<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringPrograms, List<int> performanceMeasureMonitoringProgramIDList)
        {
            if(performanceMeasureMonitoringProgramIDList.Any())
            {
                performanceMeasureMonitoringPrograms.Where(x => performanceMeasureMonitoringProgramIDList.Contains(x.PerformanceMeasureMonitoringProgramID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this IQueryable<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringPrograms, ICollection<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringProgramsToDelete)
        {
            if(performanceMeasureMonitoringProgramsToDelete.Any())
            {
                var performanceMeasureMonitoringProgramIDList = performanceMeasureMonitoringProgramsToDelete.Select(x => x.PerformanceMeasureMonitoringProgramID).ToList();
                performanceMeasureMonitoringPrograms.Where(x => performanceMeasureMonitoringProgramIDList.Contains(x.PerformanceMeasureMonitoringProgramID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this IQueryable<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringPrograms, int performanceMeasureMonitoringProgramID)
        {
            DeletePerformanceMeasureMonitoringProgram(performanceMeasureMonitoringPrograms, new List<int> { performanceMeasureMonitoringProgramID });
        }

        public static void DeletePerformanceMeasureMonitoringProgram(this IQueryable<PerformanceMeasureMonitoringProgram> performanceMeasureMonitoringPrograms, PerformanceMeasureMonitoringProgram performanceMeasureMonitoringProgramToDelete)
        {
            DeletePerformanceMeasureMonitoringProgram(performanceMeasureMonitoringPrograms, new List<PerformanceMeasureMonitoringProgram> { performanceMeasureMonitoringProgramToDelete });
        }
    }
}