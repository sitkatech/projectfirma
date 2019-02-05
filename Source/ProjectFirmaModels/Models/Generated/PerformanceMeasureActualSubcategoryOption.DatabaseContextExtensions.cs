//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActualSubcategoryOption GetPerformanceMeasureActualSubcategoryOption(this IQueryable<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions, int performanceMeasureActualSubcategoryOptionID)
        {
            var performanceMeasureActualSubcategoryOption = performanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureActualSubcategoryOptionID == performanceMeasureActualSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualSubcategoryOption, "PerformanceMeasureActualSubcategoryOption", performanceMeasureActualSubcategoryOptionID);
            return performanceMeasureActualSubcategoryOption;
        }

    }
}