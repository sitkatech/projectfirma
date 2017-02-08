//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureExpectedSubcategoryOption GetPerformanceMeasureExpectedSubcategoryOption(this IQueryable<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptions, int performanceMeasureExpectedSubcategoryOptionID)
        {
            var performanceMeasureExpectedSubcategoryOption = performanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureExpectedSubcategoryOptionID == performanceMeasureExpectedSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpectedSubcategoryOption, "PerformanceMeasureExpectedSubcategoryOption", performanceMeasureExpectedSubcategoryOptionID);
            return performanceMeasureExpectedSubcategoryOption;
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this IQueryable<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptions, List<int> performanceMeasureExpectedSubcategoryOptionIDList)
        {
            if(performanceMeasureExpectedSubcategoryOptionIDList.Any())
            {
                performanceMeasureExpectedSubcategoryOptions.Where(x => performanceMeasureExpectedSubcategoryOptionIDList.Contains(x.PerformanceMeasureExpectedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this IQueryable<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptions, ICollection<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptionsToDelete)
        {
            if(performanceMeasureExpectedSubcategoryOptionsToDelete.Any())
            {
                var performanceMeasureExpectedSubcategoryOptionIDList = performanceMeasureExpectedSubcategoryOptionsToDelete.Select(x => x.PerformanceMeasureExpectedSubcategoryOptionID).ToList();
                performanceMeasureExpectedSubcategoryOptions.Where(x => performanceMeasureExpectedSubcategoryOptionIDList.Contains(x.PerformanceMeasureExpectedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this IQueryable<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptions, int performanceMeasureExpectedSubcategoryOptionID)
        {
            DeletePerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpectedSubcategoryOptions, new List<int> { performanceMeasureExpectedSubcategoryOptionID });
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this IQueryable<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptions, PerformanceMeasureExpectedSubcategoryOption performanceMeasureExpectedSubcategoryOptionToDelete)
        {
            DeletePerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpectedSubcategoryOptions, new List<PerformanceMeasureExpectedSubcategoryOption> { performanceMeasureExpectedSubcategoryOptionToDelete });
        }
    }
}