//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasure]
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
        public static PerformanceMeasure GetPerformanceMeasure(this IQueryable<PerformanceMeasure> performanceMeasures, int performanceMeasureID)
        {
            var performanceMeasure = performanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureID);
            Check.RequireNotNullThrowNotFound(performanceMeasure, "PerformanceMeasure", performanceMeasureID);
            return performanceMeasure;
        }

        public static void DeletePerformanceMeasure(this IQueryable<PerformanceMeasure> performanceMeasures, List<int> performanceMeasureIDList)
        {
            if(performanceMeasureIDList.Any())
            {
                performanceMeasures.Where(x => performanceMeasureIDList.Contains(x.PerformanceMeasureID)).Delete();
            }
        }

        public static void DeletePerformanceMeasure(this IQueryable<PerformanceMeasure> performanceMeasures, ICollection<PerformanceMeasure> performanceMeasuresToDelete)
        {
            if(performanceMeasuresToDelete.Any())
            {
                var performanceMeasureIDList = performanceMeasuresToDelete.Select(x => x.PerformanceMeasureID).ToList();
                performanceMeasures.Where(x => performanceMeasureIDList.Contains(x.PerformanceMeasureID)).Delete();
            }
        }

        public static void DeletePerformanceMeasure(this IQueryable<PerformanceMeasure> performanceMeasures, int performanceMeasureID)
        {
            DeletePerformanceMeasure(performanceMeasures, new List<int> { performanceMeasureID });
        }

        public static void DeletePerformanceMeasure(this IQueryable<PerformanceMeasure> performanceMeasures, PerformanceMeasure performanceMeasureToDelete)
        {
            DeletePerformanceMeasure(performanceMeasures, new List<PerformanceMeasure> { performanceMeasureToDelete });
        }
    }
}