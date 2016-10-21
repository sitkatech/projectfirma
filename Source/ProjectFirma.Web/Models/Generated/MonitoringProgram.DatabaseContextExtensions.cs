//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgram]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

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

        public static void DeleteMonitoringProgram(this IQueryable<MonitoringProgram> monitoringPrograms, List<int> monitoringProgramIDList)
        {
            if(monitoringProgramIDList.Any())
            {
                monitoringPrograms.Where(x => monitoringProgramIDList.Contains(x.MonitoringProgramID)).Delete();
            }
        }

        public static void DeleteMonitoringProgram(this IQueryable<MonitoringProgram> monitoringPrograms, ICollection<MonitoringProgram> monitoringProgramsToDelete)
        {
            if(monitoringProgramsToDelete.Any())
            {
                var monitoringProgramIDList = monitoringProgramsToDelete.Select(x => x.MonitoringProgramID).ToList();
                monitoringPrograms.Where(x => monitoringProgramIDList.Contains(x.MonitoringProgramID)).Delete();
            }
        }

        public static void DeleteMonitoringProgram(this IQueryable<MonitoringProgram> monitoringPrograms, int monitoringProgramID)
        {
            DeleteMonitoringProgram(monitoringPrograms, new List<int> { monitoringProgramID });
        }

        public static void DeleteMonitoringProgram(this IQueryable<MonitoringProgram> monitoringPrograms, MonitoringProgram monitoringProgramToDelete)
        {
            DeleteMonitoringProgram(monitoringPrograms, new List<MonitoringProgram> { monitoringProgramToDelete });
        }
    }
}