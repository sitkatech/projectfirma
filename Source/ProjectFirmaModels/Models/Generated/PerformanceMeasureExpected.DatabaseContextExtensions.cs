//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpected]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureExpected GetPerformanceMeasureExpected(this IQueryable<PerformanceMeasureExpected> performanceMeasureExpecteds, int performanceMeasureExpectedID)
        {
            var performanceMeasureExpected = performanceMeasureExpecteds.SingleOrDefault(x => x.PerformanceMeasureExpectedID == performanceMeasureExpectedID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpected, "PerformanceMeasureExpected", performanceMeasureExpectedID);
            return performanceMeasureExpected;
        }

    }
}