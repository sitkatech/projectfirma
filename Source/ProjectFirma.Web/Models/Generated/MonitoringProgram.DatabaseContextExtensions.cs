//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgram]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MonitoringProgram GetMonitoringProgram(this IQueryable<MonitoringProgram> monitoringPrograms, int monitoringProgramID)
        {
            var monitoringProgram = monitoringPrograms.SingleOrDefault(x => x.MonitoringProgramID == monitoringProgramID);
            Check.RequireNotNullThrowNotFound(monitoringProgram, "MonitoringProgram", monitoringProgramID);
            return monitoringProgram;
        }

        public static void DeleteMonitoringProgram(this List<int> monitoringProgramIDList)
        {
            if(monitoringProgramIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMonitoringPrograms.RemoveRange(HttpRequestStorage.DatabaseEntities.MonitoringPrograms.Where(x => monitoringProgramIDList.Contains(x.MonitoringProgramID)));
            }
        }

        public static void DeleteMonitoringProgram(this ICollection<MonitoringProgram> monitoringProgramsToDelete)
        {
            if(monitoringProgramsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMonitoringPrograms.RemoveRange(monitoringProgramsToDelete);
            }
        }

        public static void DeleteMonitoringProgram(this int monitoringProgramID)
        {
            DeleteMonitoringProgram(new List<int> { monitoringProgramID });
        }

        public static void DeleteMonitoringProgram(this MonitoringProgram monitoringProgramToDelete)
        {
            DeleteMonitoringProgram(new List<MonitoringProgram> { monitoringProgramToDelete });
        }
    }
}