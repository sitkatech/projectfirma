//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportedValueSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureReportedValueSubcategoryOption GetPerformanceMeasureReportedValueSubcategoryOption(this IQueryable<PerformanceMeasureReportedValueSubcategoryOption> performanceMeasureReportedValueSubcategoryOptions, int performanceMeasureReportedValueSubcategoryOptionID)
        {
            var performanceMeasureReportedValueSubcategoryOption = performanceMeasureReportedValueSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureReportedValueSubcategoryOptionID == performanceMeasureReportedValueSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureReportedValueSubcategoryOption, "PerformanceMeasureReportedValueSubcategoryOption", performanceMeasureReportedValueSubcategoryOptionID);
            return performanceMeasureReportedValueSubcategoryOption;
        }

    }
}