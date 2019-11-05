//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportedValue]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureReportedValue GetPerformanceMeasureReportedValue(this IQueryable<PerformanceMeasureReportedValue> performanceMeasureReportedValues, int performanceMeasureReportedValueID)
        {
            var performanceMeasureReportedValue = performanceMeasureReportedValues.SingleOrDefault(x => x.PerformanceMeasureReportedValueID == performanceMeasureReportedValueID);
            Check.RequireNotNullThrowNotFound(performanceMeasureReportedValue, "PerformanceMeasureReportedValue", performanceMeasureReportedValueID);
            return performanceMeasureReportedValue;
        }

    }
}