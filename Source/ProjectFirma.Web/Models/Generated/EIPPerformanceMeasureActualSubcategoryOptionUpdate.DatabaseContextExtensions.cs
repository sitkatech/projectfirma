//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]
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
        public static EIPPerformanceMeasureActualSubcategoryOptionUpdate GetEIPPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<EIPPerformanceMeasureActualSubcategoryOptionUpdate> eIPPerformanceMeasureActualSubcategoryOptionUpdates, int eIPPerformanceMeasureActualSubcategoryOptionUpdateID)
        {
            var eIPPerformanceMeasureActualSubcategoryOptionUpdate = eIPPerformanceMeasureActualSubcategoryOptionUpdates.SingleOrDefault(x => x.EIPPerformanceMeasureActualSubcategoryOptionUpdateID == eIPPerformanceMeasureActualSubcategoryOptionUpdateID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureActualSubcategoryOptionUpdate, "EIPPerformanceMeasureActualSubcategoryOptionUpdate", eIPPerformanceMeasureActualSubcategoryOptionUpdateID);
            return eIPPerformanceMeasureActualSubcategoryOptionUpdate;
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<EIPPerformanceMeasureActualSubcategoryOptionUpdate> eIPPerformanceMeasureActualSubcategoryOptionUpdates, List<int> eIPPerformanceMeasureActualSubcategoryOptionUpdateIDList)
        {
            if(eIPPerformanceMeasureActualSubcategoryOptionUpdateIDList.Any())
            {
                eIPPerformanceMeasureActualSubcategoryOptionUpdates.Where(x => eIPPerformanceMeasureActualSubcategoryOptionUpdateIDList.Contains(x.EIPPerformanceMeasureActualSubcategoryOptionUpdateID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<EIPPerformanceMeasureActualSubcategoryOptionUpdate> eIPPerformanceMeasureActualSubcategoryOptionUpdates, ICollection<EIPPerformanceMeasureActualSubcategoryOptionUpdate> eIPPerformanceMeasureActualSubcategoryOptionUpdatesToDelete)
        {
            if(eIPPerformanceMeasureActualSubcategoryOptionUpdatesToDelete.Any())
            {
                var eIPPerformanceMeasureActualSubcategoryOptionUpdateIDList = eIPPerformanceMeasureActualSubcategoryOptionUpdatesToDelete.Select(x => x.EIPPerformanceMeasureActualSubcategoryOptionUpdateID).ToList();
                eIPPerformanceMeasureActualSubcategoryOptionUpdates.Where(x => eIPPerformanceMeasureActualSubcategoryOptionUpdateIDList.Contains(x.EIPPerformanceMeasureActualSubcategoryOptionUpdateID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<EIPPerformanceMeasureActualSubcategoryOptionUpdate> eIPPerformanceMeasureActualSubcategoryOptionUpdates, int eIPPerformanceMeasureActualSubcategoryOptionUpdateID)
        {
            DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(eIPPerformanceMeasureActualSubcategoryOptionUpdates, new List<int> { eIPPerformanceMeasureActualSubcategoryOptionUpdateID });
        }

        public static void DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<EIPPerformanceMeasureActualSubcategoryOptionUpdate> eIPPerformanceMeasureActualSubcategoryOptionUpdates, EIPPerformanceMeasureActualSubcategoryOptionUpdate eIPPerformanceMeasureActualSubcategoryOptionUpdateToDelete)
        {
            DeleteEIPPerformanceMeasureActualSubcategoryOptionUpdate(eIPPerformanceMeasureActualSubcategoryOptionUpdates, new List<EIPPerformanceMeasureActualSubcategoryOptionUpdate> { eIPPerformanceMeasureActualSubcategoryOptionUpdateToDelete });
        }
    }
}