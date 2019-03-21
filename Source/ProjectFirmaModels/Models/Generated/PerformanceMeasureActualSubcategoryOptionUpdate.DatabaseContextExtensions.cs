//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActualSubcategoryOptionUpdate GetPerformanceMeasureActualSubcategoryOptionUpdate(this IQueryable<PerformanceMeasureActualSubcategoryOptionUpdate> performanceMeasureActualSubcategoryOptionUpdates, int performanceMeasureActualSubcategoryOptionUpdateID)
        {
            var performanceMeasureActualSubcategoryOptionUpdate = performanceMeasureActualSubcategoryOptionUpdates.SingleOrDefault(x => x.PerformanceMeasureActualSubcategoryOptionUpdateID == performanceMeasureActualSubcategoryOptionUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualSubcategoryOptionUpdate, "PerformanceMeasureActualSubcategoryOptionUpdate", performanceMeasureActualSubcategoryOptionUpdateID);
            return performanceMeasureActualSubcategoryOptionUpdate;
        }

    }
}