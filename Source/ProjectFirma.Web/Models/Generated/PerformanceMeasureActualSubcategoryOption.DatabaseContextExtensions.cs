//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeletePerformanceMeasureActualSubcategoryOption(this List<int> performanceMeasureActualSubcategoryOptionIDList)
        {
            if(performanceMeasureActualSubcategoryOptionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Where(x => performanceMeasureActualSubcategoryOptionIDList.Contains(x.PerformanceMeasureActualSubcategoryOptionID)));
            }
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this ICollection<PerformanceMeasureActualSubcategoryOption> performanceMeasureActualSubcategoryOptionsToDelete)
        {
            if(performanceMeasureActualSubcategoryOptionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureActualSubcategoryOptions.RemoveRange(performanceMeasureActualSubcategoryOptionsToDelete);
            }
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this int performanceMeasureActualSubcategoryOptionID)
        {
            DeletePerformanceMeasureActualSubcategoryOption(new List<int> { performanceMeasureActualSubcategoryOptionID });
        }

        public static void DeletePerformanceMeasureActualSubcategoryOption(this PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOptionToDelete)
        {
            DeletePerformanceMeasureActualSubcategoryOption(new List<PerformanceMeasureActualSubcategoryOption> { performanceMeasureActualSubcategoryOptionToDelete });
        }
    }
}