//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureSubcategoryOption GetPerformanceMeasureSubcategoryOption(this IQueryable<PerformanceMeasureSubcategoryOption> performanceMeasureSubcategoryOptions, int performanceMeasureSubcategoryOptionID)
        {
            var performanceMeasureSubcategoryOption = performanceMeasureSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureSubcategoryOptionID == performanceMeasureSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureSubcategoryOption, "PerformanceMeasureSubcategoryOption", performanceMeasureSubcategoryOptionID);
            return performanceMeasureSubcategoryOption;
        }

    }
}