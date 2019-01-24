//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasure GetPerformanceMeasure(this IQueryable<PerformanceMeasure> performanceMeasures, int performanceMeasureID)
        {
            var performanceMeasure = performanceMeasures.SingleOrDefault(x => x.PerformanceMeasureID == performanceMeasureID);
            Check.RequireNotNullThrowNotFound(performanceMeasure, "PerformanceMeasure", performanceMeasureID);
            return performanceMeasure;
        }

    }
}