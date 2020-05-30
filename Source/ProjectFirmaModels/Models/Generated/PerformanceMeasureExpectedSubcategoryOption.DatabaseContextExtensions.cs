//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOption]
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
        public static PerformanceMeasureExpectedSubcategoryOption GetPerformanceMeasureExpectedSubcategoryOption(this IQueryable<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptions, int performanceMeasureExpectedSubcategoryOptionID)
        {
            var performanceMeasureExpectedSubcategoryOption = performanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureExpectedSubcategoryOptionID == performanceMeasureExpectedSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpectedSubcategoryOption, "PerformanceMeasureExpectedSubcategoryOption", performanceMeasureExpectedSubcategoryOptionID);
            return performanceMeasureExpectedSubcategoryOption;
        }

    }
}