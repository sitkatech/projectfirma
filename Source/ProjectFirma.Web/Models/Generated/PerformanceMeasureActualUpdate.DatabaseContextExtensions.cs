//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualUpdate]
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
        public static PerformanceMeasureActualUpdate GetPerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, int performanceMeasureActualUpdateID)
        {
            var performanceMeasureActualUpdate = performanceMeasureActualUpdates.SingleOrDefault(x => x.PerformanceMeasureActualUpdateID == performanceMeasureActualUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualUpdate, "PerformanceMeasureActualUpdate", performanceMeasureActualUpdateID);
            return performanceMeasureActualUpdate;
        }

        public static void DeletePerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, List<int> performanceMeasureActualUpdateIDList)
        {
            if(performanceMeasureActualUpdateIDList.Any())
            {
                performanceMeasureActualUpdates.Where(x => performanceMeasureActualUpdateIDList.Contains(x.PerformanceMeasureActualUpdateID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, ICollection<PerformanceMeasureActualUpdate> performanceMeasureActualUpdatesToDelete)
        {
            if(performanceMeasureActualUpdatesToDelete.Any())
            {
                var performanceMeasureActualUpdateIDList = performanceMeasureActualUpdatesToDelete.Select(x => x.PerformanceMeasureActualUpdateID).ToList();
                performanceMeasureActualUpdates.Where(x => performanceMeasureActualUpdateIDList.Contains(x.PerformanceMeasureActualUpdateID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, int performanceMeasureActualUpdateID)
        {
            DeletePerformanceMeasureActualUpdate(performanceMeasureActualUpdates, new List<int> { performanceMeasureActualUpdateID });
        }

        public static void DeletePerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, PerformanceMeasureActualUpdate performanceMeasureActualUpdateToDelete)
        {
            DeletePerformanceMeasureActualUpdate(performanceMeasureActualUpdates, new List<PerformanceMeasureActualUpdate> { performanceMeasureActualUpdateToDelete });
        }
    }
}