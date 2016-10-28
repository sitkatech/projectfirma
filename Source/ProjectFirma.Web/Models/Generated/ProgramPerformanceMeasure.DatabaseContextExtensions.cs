//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProgramPerformanceMeasure]
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
        public static ProgramPerformanceMeasure GetProgramPerformanceMeasure(this IQueryable<ProgramPerformanceMeasure> programPerformanceMeasures, int programPerformanceMeasureID)
        {
            var programPerformanceMeasure = programPerformanceMeasures.SingleOrDefault(x => x.ProgramPerformanceMeasureID == programPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(programPerformanceMeasure, "ProgramPerformanceMeasure", programPerformanceMeasureID);
            return programPerformanceMeasure;
        }

        public static void DeleteProgramPerformanceMeasure(this IQueryable<ProgramPerformanceMeasure> programPerformanceMeasures, List<int> programPerformanceMeasureIDList)
        {
            if(programPerformanceMeasureIDList.Any())
            {
                programPerformanceMeasures.Where(x => programPerformanceMeasureIDList.Contains(x.ProgramPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteProgramPerformanceMeasure(this IQueryable<ProgramPerformanceMeasure> programPerformanceMeasures, ICollection<ProgramPerformanceMeasure> programPerformanceMeasuresToDelete)
        {
            if(programPerformanceMeasuresToDelete.Any())
            {
                var programPerformanceMeasureIDList = programPerformanceMeasuresToDelete.Select(x => x.ProgramPerformanceMeasureID).ToList();
                programPerformanceMeasures.Where(x => programPerformanceMeasureIDList.Contains(x.ProgramPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteProgramPerformanceMeasure(this IQueryable<ProgramPerformanceMeasure> programPerformanceMeasures, int programPerformanceMeasureID)
        {
            DeleteProgramPerformanceMeasure(programPerformanceMeasures, new List<int> { programPerformanceMeasureID });
        }

        public static void DeleteProgramPerformanceMeasure(this IQueryable<ProgramPerformanceMeasure> programPerformanceMeasures, ProgramPerformanceMeasure programPerformanceMeasureToDelete)
        {
            DeleteProgramPerformanceMeasure(programPerformanceMeasures, new List<ProgramPerformanceMeasure> { programPerformanceMeasureToDelete });
        }
    }
}