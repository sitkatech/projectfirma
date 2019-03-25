//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActual]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureActual GetPerformanceMeasureActual(this IQueryable<PerformanceMeasureActual> performanceMeasureActuals, int performanceMeasureActualID)
        {
            var performanceMeasureActual = performanceMeasureActuals.SingleOrDefault(x => x.PerformanceMeasureActualID == performanceMeasureActualID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActual, "PerformanceMeasureActual", performanceMeasureActualID);
            return performanceMeasureActual;
        }

    }
}