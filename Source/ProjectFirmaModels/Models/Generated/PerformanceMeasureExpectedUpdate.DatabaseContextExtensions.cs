//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureExpectedUpdate GetPerformanceMeasureExpectedUpdate(this IQueryable<PerformanceMeasureExpectedUpdate> performanceMeasureExpectedUpdates, int performanceMeasureExpectedUpdateID)
        {
            var performanceMeasureExpectedUpdate = performanceMeasureExpectedUpdates.SingleOrDefault(x => x.PerformanceMeasureExpectedUpdateID == performanceMeasureExpectedUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpectedUpdate, "PerformanceMeasureExpectedUpdate", performanceMeasureExpectedUpdateID);
            return performanceMeasureExpectedUpdate;
        }

    }
}