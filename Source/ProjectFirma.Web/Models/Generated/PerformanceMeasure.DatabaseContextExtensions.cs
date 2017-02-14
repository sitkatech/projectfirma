//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeletePerformanceMeasure(this List<int> performanceMeasureIDList)
        {
            if(performanceMeasureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Where(x => performanceMeasureIDList.Contains(x.PerformanceMeasureID)));
            }
        }

        public static void DeletePerformanceMeasure(this ICollection<PerformanceMeasure> performanceMeasuresToDelete)
        {
            if(performanceMeasuresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.RemoveRange(performanceMeasuresToDelete);
            }
        }

        public static void DeletePerformanceMeasure(this int performanceMeasureID)
        {
            DeletePerformanceMeasure(new List<int> { performanceMeasureID });
        }

        public static void DeletePerformanceMeasure(this PerformanceMeasure performanceMeasureToDelete)
        {
            DeletePerformanceMeasure(new List<PerformanceMeasure> { performanceMeasureToDelete });
        }
    }
}