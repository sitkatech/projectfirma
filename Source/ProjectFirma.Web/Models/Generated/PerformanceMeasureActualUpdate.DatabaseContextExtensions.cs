//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActualUpdate GetPerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, int performanceMeasureActualUpdateID)
        {
            var performanceMeasureActualUpdate = performanceMeasureActualUpdates.SingleOrDefault(x => x.PerformanceMeasureActualUpdateID == performanceMeasureActualUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualUpdate, "PerformanceMeasureActualUpdate", performanceMeasureActualUpdateID);
            return performanceMeasureActualUpdate;
        }

        public static void DeletePerformanceMeasureActualUpdate(this List<int> performanceMeasureActualUpdateIDList)
        {
            if(performanceMeasureActualUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualUpdates.Where(x => performanceMeasureActualUpdateIDList.Contains(x.PerformanceMeasureActualUpdateID)));
            }
        }

        public static void DeletePerformanceMeasureActualUpdate(this ICollection<PerformanceMeasureActualUpdate> performanceMeasureActualUpdatesToDelete)
        {
            if(performanceMeasureActualUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualUpdates.RemoveRange(performanceMeasureActualUpdatesToDelete);
            }
        }

        public static void DeletePerformanceMeasureActualUpdate(this int performanceMeasureActualUpdateID)
        {
            DeletePerformanceMeasureActualUpdate(new List<int> { performanceMeasureActualUpdateID });
        }

        public static void DeletePerformanceMeasureActualUpdate(this PerformanceMeasureActualUpdate performanceMeasureActualUpdateToDelete)
        {
            DeletePerformanceMeasureActualUpdate(new List<PerformanceMeasureActualUpdate> { performanceMeasureActualUpdateToDelete });
        }
    }
}