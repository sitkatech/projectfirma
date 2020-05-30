//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOptionUpdate]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureExpectedSubcategoryOptionUpdate GetPerformanceMeasureExpectedSubcategoryOptionUpdate(this IQueryable<PerformanceMeasureExpectedSubcategoryOptionUpdate> performanceMeasureExpectedSubcategoryOptionUpdates, int performanceMeasureExpectedSubcategoryOptionUpdateID)
        {
            var performanceMeasureExpectedSubcategoryOptionUpdate = performanceMeasureExpectedSubcategoryOptionUpdates.SingleOrDefault(x => x.PerformanceMeasureExpectedSubcategoryOptionUpdateID == performanceMeasureExpectedSubcategoryOptionUpdateID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpectedSubcategoryOptionUpdate, "PerformanceMeasureExpectedSubcategoryOptionUpdate", performanceMeasureExpectedSubcategoryOptionUpdateID);
            return performanceMeasureExpectedSubcategoryOptionUpdate;
        }

    }
}