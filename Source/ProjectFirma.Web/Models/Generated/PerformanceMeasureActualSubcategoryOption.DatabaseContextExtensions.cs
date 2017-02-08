//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOption]
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
        public static PerformanceMeasureActualSubcategoryOption GetPerformanceMeasureActualSubcategoryOption(this IQueryable<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions, int performanceMeasureActualSubcategoryOptionID)
        {
            var performanceMeasureActualSubcategoryOption = performanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureActualSubcategoryOptionID == performanceMeasureActualSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureActualSubcategoryOption, "PerformanceMeasureActualSubcategoryOption", performanceMeasureActualSubcategoryOptionID);
            return performanceMeasureActualSubcategoryOption;
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this IQueryable<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions, List<int> performanceMeasureActualSubcategoryOptionIDList)
        {
            if(performanceMeasureActualSubcategoryOptionIDList.Any())
            {
                performanceMeasureActualSubcategoryOptions.Where(x => performanceMeasureActualSubcategoryOptionIDList.Contains(x.PerformanceMeasureActualSubcategoryOptionID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this IQueryable<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions, ICollection<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptionsToDelete)
        {
            if(performanceMeasureActualSubcategoryOptionsToDelete.Any())
            {
                var performanceMeasureActualSubcategoryOptionIDList = performanceMeasureActualSubcategoryOptionsToDelete.Select(x => x.PerformanceMeasureActualSubcategoryOptionID).ToList();
                performanceMeasureActualSubcategoryOptions.Where(x => performanceMeasureActualSubcategoryOptionIDList.Contains(x.PerformanceMeasureActualSubcategoryOptionID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this IQueryable<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions, int performanceMeasureActualSubcategoryOptionID)
        {
            DeletePerformanceMeasureActualSubcategoryOption(performanceMeasureActualSubcategoryOptions, new List<int> { performanceMeasureActualSubcategoryOptionID });
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this IQueryable<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptions, PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOptionToDelete)
        {
            DeletePerformanceMeasureActualSubcategoryOption(performanceMeasureActualSubcategoryOptions, new List<PerformanceMeasureActualSubcategoryOption> { performanceMeasureActualSubcategoryOptionToDelete });
        }
    }
}