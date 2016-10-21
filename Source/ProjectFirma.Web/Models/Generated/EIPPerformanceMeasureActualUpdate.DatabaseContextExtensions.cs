//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActualUpdate]
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
        public static EIPPerformanceMeasureActualUpdate GetEIPPerformanceMeasureActualUpdate(this IQueryable<EIPPerformanceMeasureActualUpdate> eIPPerformanceMeasureActualUpdates, int eIPPerformanceMeasureActualUpdateID)
        {
            var eIPPerformanceMeasureActualUpdate = eIPPerformanceMeasureActualUpdates.SingleOrDefault(x => x.EIPPerformanceMeasureActualUpdateID == eIPPerformanceMeasureActualUpdateID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureActualUpdate, "EIPPerformanceMeasureActualUpdate", eIPPerformanceMeasureActualUpdateID);
            return eIPPerformanceMeasureActualUpdate;
        }

        public static void DeleteEIPPerformanceMeasureActualUpdate(this IQueryable<EIPPerformanceMeasureActualUpdate> eIPPerformanceMeasureActualUpdates, List<int> eIPPerformanceMeasureActualUpdateIDList)
        {
            if(eIPPerformanceMeasureActualUpdateIDList.Any())
            {
                eIPPerformanceMeasureActualUpdates.Where(x => eIPPerformanceMeasureActualUpdateIDList.Contains(x.EIPPerformanceMeasureActualUpdateID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActualUpdate(this IQueryable<EIPPerformanceMeasureActualUpdate> eIPPerformanceMeasureActualUpdates, ICollection<EIPPerformanceMeasureActualUpdate> eIPPerformanceMeasureActualUpdatesToDelete)
        {
            if(eIPPerformanceMeasureActualUpdatesToDelete.Any())
            {
                var eIPPerformanceMeasureActualUpdateIDList = eIPPerformanceMeasureActualUpdatesToDelete.Select(x => x.EIPPerformanceMeasureActualUpdateID).ToList();
                eIPPerformanceMeasureActualUpdates.Where(x => eIPPerformanceMeasureActualUpdateIDList.Contains(x.EIPPerformanceMeasureActualUpdateID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActualUpdate(this IQueryable<EIPPerformanceMeasureActualUpdate> eIPPerformanceMeasureActualUpdates, int eIPPerformanceMeasureActualUpdateID)
        {
            DeleteEIPPerformanceMeasureActualUpdate(eIPPerformanceMeasureActualUpdates, new List<int> { eIPPerformanceMeasureActualUpdateID });
        }

        public static void DeleteEIPPerformanceMeasureActualUpdate(this IQueryable<EIPPerformanceMeasureActualUpdate> eIPPerformanceMeasureActualUpdates, EIPPerformanceMeasureActualUpdate eIPPerformanceMeasureActualUpdateToDelete)
        {
            DeleteEIPPerformanceMeasureActualUpdate(eIPPerformanceMeasureActualUpdates, new List<EIPPerformanceMeasureActualUpdate> { eIPPerformanceMeasureActualUpdateToDelete });
        }
    }
}