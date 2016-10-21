//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActual]
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
        public static EIPPerformanceMeasureActual GetEIPPerformanceMeasureActual(this IQueryable<EIPPerformanceMeasureActual> eIPPerformanceMeasureActuals, int eIPPerformanceMeasureActualID)
        {
            var eIPPerformanceMeasureActual = eIPPerformanceMeasureActuals.SingleOrDefault(x => x.EIPPerformanceMeasureActualID == eIPPerformanceMeasureActualID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureActual, "EIPPerformanceMeasureActual", eIPPerformanceMeasureActualID);
            return eIPPerformanceMeasureActual;
        }

        public static void DeleteEIPPerformanceMeasureActual(this IQueryable<EIPPerformanceMeasureActual> eIPPerformanceMeasureActuals, List<int> eIPPerformanceMeasureActualIDList)
        {
            if(eIPPerformanceMeasureActualIDList.Any())
            {
                eIPPerformanceMeasureActuals.Where(x => eIPPerformanceMeasureActualIDList.Contains(x.EIPPerformanceMeasureActualID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActual(this IQueryable<EIPPerformanceMeasureActual> eIPPerformanceMeasureActuals, ICollection<EIPPerformanceMeasureActual> eIPPerformanceMeasureActualsToDelete)
        {
            if(eIPPerformanceMeasureActualsToDelete.Any())
            {
                var eIPPerformanceMeasureActualIDList = eIPPerformanceMeasureActualsToDelete.Select(x => x.EIPPerformanceMeasureActualID).ToList();
                eIPPerformanceMeasureActuals.Where(x => eIPPerformanceMeasureActualIDList.Contains(x.EIPPerformanceMeasureActualID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActual(this IQueryable<EIPPerformanceMeasureActual> eIPPerformanceMeasureActuals, int eIPPerformanceMeasureActualID)
        {
            DeleteEIPPerformanceMeasureActual(eIPPerformanceMeasureActuals, new List<int> { eIPPerformanceMeasureActualID });
        }

        public static void DeleteEIPPerformanceMeasureActual(this IQueryable<EIPPerformanceMeasureActual> eIPPerformanceMeasureActuals, EIPPerformanceMeasureActual eIPPerformanceMeasureActualToDelete)
        {
            DeleteEIPPerformanceMeasureActual(eIPPerformanceMeasureActuals, new List<EIPPerformanceMeasureActual> { eIPPerformanceMeasureActualToDelete });
        }
    }
}