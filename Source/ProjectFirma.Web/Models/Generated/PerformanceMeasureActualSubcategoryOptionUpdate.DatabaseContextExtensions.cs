//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActualSubcategoryOptionUpdate GetPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<PerformanceMeasureActualSubcategoryOptionUpdate> performanceMeasureActualSubcategoryOptionUpdates, int performanceMeasureActualSubcategoryOptionUpdateID)
        {
            var performanceMeasureActualSubcategoryOptionUpdate = performanceMeasureActualSubcategoryOptionUpdates.SingleOrDefault(x => x.PerformanceMeasureActualSubcategoryOptionUpdateID == performanceMeasureActualSubcategoryOptionUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualSubcategoryOptionUpdate, "PerformanceMeasureActualSubcategoryOptionUpdate", performanceMeasureActualSubcategoryOptionUpdateID);
            return performanceMeasureActualSubcategoryOptionUpdate;
        }

        public static void DeletePerformanceMeasureActualSubcategoryOptionUpdate(this List<int> performanceMeasureActualSubcategoryOptionUpdateIDList)
        {
            if(performanceMeasureActualSubcategoryOptionUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptionUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptionUpdates.Where(x => performanceMeasureActualSubcategoryOptionUpdateIDList.Contains(x.PerformanceMeasureActualSubcategoryOptionUpdateID)));
            }
        }

        public static void DeletePerformanceMeasureActualSubcategoryOptionUpdate(this ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> performanceMeasureActualSubcategoryOptionUpdatesToDelete)
        {
            if(performanceMeasureActualSubcategoryOptionUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptionUpdates.RemoveRange(performanceMeasureActualSubcategoryOptionUpdatesToDelete);
            }
        }

        public static void DeletePerformanceMeasureActualSubcategoryOptionUpdate(this int performanceMeasureActualSubcategoryOptionUpdateID)
        {
            DeletePerformanceMeasureActualSubcategoryOptionUpdate(new List<int> { performanceMeasureActualSubcategoryOptionUpdateID });
        }

        public static void DeletePerformanceMeasureActualSubcategoryOptionUpdate(this PerformanceMeasureActualSubcategoryOptionUpdate performanceMeasureActualSubcategoryOptionUpdateToDelete)
        {
            DeletePerformanceMeasureActualSubcategoryOptionUpdate(new List<PerformanceMeasureActualSubcategoryOptionUpdate> { performanceMeasureActualSubcategoryOptionUpdateToDelete });
        }
    }
}