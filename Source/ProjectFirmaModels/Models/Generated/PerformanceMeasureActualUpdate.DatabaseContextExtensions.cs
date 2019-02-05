//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActualUpdate GetPerformanceMeasureActualUpdate(this IQueryable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates, int performanceMeasureActualUpdateID)
        {
            var performanceMeasureActualUpdate = performanceMeasureActualUpdates.SingleOrDefault(x => x.PerformanceMeasureActualUpdateID == performanceMeasureActualUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualUpdate, "PerformanceMeasureActualUpdate", performanceMeasureActualUpdateID);
            return performanceMeasureActualUpdate;
        }

    }
}