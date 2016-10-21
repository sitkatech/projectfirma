//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProgramEIPPerformanceMeasure]
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
        public static ProgramEIPPerformanceMeasure GetProgramEIPPerformanceMeasure(this IQueryable<ProgramEIPPerformanceMeasure> programEIPPerformanceMeasures, int programEIPPerformanceMeasureID)
        {
            var programEIPPerformanceMeasure = programEIPPerformanceMeasures.SingleOrDefault(x => x.ProgramEIPPerformanceMeasureID == programEIPPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(programEIPPerformanceMeasure, "ProgramEIPPerformanceMeasure", programEIPPerformanceMeasureID);
            return programEIPPerformanceMeasure;
        }

        public static void DeleteProgramEIPPerformanceMeasure(this IQueryable<ProgramEIPPerformanceMeasure> programEIPPerformanceMeasures, List<int> programEIPPerformanceMeasureIDList)
        {
            if(programEIPPerformanceMeasureIDList.Any())
            {
                programEIPPerformanceMeasures.Where(x => programEIPPerformanceMeasureIDList.Contains(x.ProgramEIPPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteProgramEIPPerformanceMeasure(this IQueryable<ProgramEIPPerformanceMeasure> programEIPPerformanceMeasures, ICollection<ProgramEIPPerformanceMeasure> programEIPPerformanceMeasuresToDelete)
        {
            if(programEIPPerformanceMeasuresToDelete.Any())
            {
                var programEIPPerformanceMeasureIDList = programEIPPerformanceMeasuresToDelete.Select(x => x.ProgramEIPPerformanceMeasureID).ToList();
                programEIPPerformanceMeasures.Where(x => programEIPPerformanceMeasureIDList.Contains(x.ProgramEIPPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteProgramEIPPerformanceMeasure(this IQueryable<ProgramEIPPerformanceMeasure> programEIPPerformanceMeasures, int programEIPPerformanceMeasureID)
        {
            DeleteProgramEIPPerformanceMeasure(programEIPPerformanceMeasures, new List<int> { programEIPPerformanceMeasureID });
        }

        public static void DeleteProgramEIPPerformanceMeasure(this IQueryable<ProgramEIPPerformanceMeasure> programEIPPerformanceMeasures, ProgramEIPPerformanceMeasure programEIPPerformanceMeasureToDelete)
        {
            DeleteProgramEIPPerformanceMeasure(programEIPPerformanceMeasures, new List<ProgramEIPPerformanceMeasure> { programEIPPerformanceMeasureToDelete });
        }
    }
}