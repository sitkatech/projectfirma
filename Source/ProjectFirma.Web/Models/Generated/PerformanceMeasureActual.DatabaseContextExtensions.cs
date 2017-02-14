//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActual]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActual GetPerformanceMeasureActual(this IQueryable<PerformanceMeasureActual> performanceMeasureActuals, int performanceMeasureActualID)
        {
            var performanceMeasureActual = performanceMeasureActuals.SingleOrDefault(x => x.PerformanceMeasureActualID == performanceMeasureActualID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActual, "PerformanceMeasureActual", performanceMeasureActualID);
            return performanceMeasureActual;
        }

        public static void DeletePerformanceMeasureActual(this List<int> performanceMeasureActualIDList)
        {
            if(performanceMeasureActualIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Where(x => performanceMeasureActualIDList.Contains(x.PerformanceMeasureActualID)));
            }
        }

        public static void DeletePerformanceMeasureActual(this ICollection<PerformanceMeasureActual> performanceMeasureActualsToDelete)
        {
            if(performanceMeasureActualsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActuals.RemoveRange(performanceMeasureActualsToDelete);
            }
        }

        public static void DeletePerformanceMeasureActual(this int performanceMeasureActualID)
        {
            DeletePerformanceMeasureActual(new List<int> { performanceMeasureActualID });
        }

        public static void DeletePerformanceMeasureActual(this PerformanceMeasureActual performanceMeasureActualToDelete)
        {
            DeletePerformanceMeasureActual(new List<PerformanceMeasureActual> { performanceMeasureActualToDelete });
        }
    }
}