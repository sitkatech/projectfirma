//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorMonitoringProgram]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static IndicatorMonitoringProgram GetIndicatorMonitoringProgram(this IQueryable<IndicatorMonitoringProgram> indicatorMonitoringPrograms, int indicatorMonitoringProgramID)
        {
            var indicatorMonitoringProgram = indicatorMonitoringPrograms.SingleOrDefault(x => x.IndicatorMonitoringProgramID == indicatorMonitoringProgramID);
            Check.RequireNotNullThrowNotFound(indicatorMonitoringProgram, "IndicatorMonitoringProgram", indicatorMonitoringProgramID);
            return indicatorMonitoringProgram;
        }

        public static void DeleteIndicatorMonitoringProgram(this IQueryable<IndicatorMonitoringProgram> indicatorMonitoringPrograms, List<int> indicatorMonitoringProgramIDList)
        {
            if(indicatorMonitoringProgramIDList.Any())
            {
                indicatorMonitoringPrograms.Where(x => indicatorMonitoringProgramIDList.Contains(x.IndicatorMonitoringProgramID)).Delete();
            }
        }

        public static void DeleteIndicatorMonitoringProgram(this IQueryable<IndicatorMonitoringProgram> indicatorMonitoringPrograms, ICollection<IndicatorMonitoringProgram> indicatorMonitoringProgramsToDelete)
        {
            if(indicatorMonitoringProgramsToDelete.Any())
            {
                var indicatorMonitoringProgramIDList = indicatorMonitoringProgramsToDelete.Select(x => x.IndicatorMonitoringProgramID).ToList();
                indicatorMonitoringPrograms.Where(x => indicatorMonitoringProgramIDList.Contains(x.IndicatorMonitoringProgramID)).Delete();
            }
        }

        public static void DeleteIndicatorMonitoringProgram(this IQueryable<IndicatorMonitoringProgram> indicatorMonitoringPrograms, int indicatorMonitoringProgramID)
        {
            DeleteIndicatorMonitoringProgram(indicatorMonitoringPrograms, new List<int> { indicatorMonitoringProgramID });
        }

        public static void DeleteIndicatorMonitoringProgram(this IQueryable<IndicatorMonitoringProgram> indicatorMonitoringPrograms, IndicatorMonitoringProgram indicatorMonitoringProgramToDelete)
        {
            DeleteIndicatorMonitoringProgram(indicatorMonitoringPrograms, new List<IndicatorMonitoringProgram> { indicatorMonitoringProgramToDelete });
        }
    }
}