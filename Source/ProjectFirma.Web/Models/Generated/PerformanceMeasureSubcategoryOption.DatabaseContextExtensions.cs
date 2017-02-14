//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureSubcategoryOption GetPerformanceMeasureSubcategoryOption(this IQueryable<PerformanceMeasureSubcategoryOption> performanceMeasureSubcategoryOptions, int performanceMeasureSubcategoryOptionID)
        {
            var performanceMeasureSubcategoryOption = performanceMeasureSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureSubcategoryOptionID == performanceMeasureSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(performanceMeasureSubcategoryOption, "PerformanceMeasureSubcategoryOption", performanceMeasureSubcategoryOptionID);
            return performanceMeasureSubcategoryOption;
        }

        public static void DeletePerformanceMeasureSubcategoryOption(this List<int> performanceMeasureSubcategoryOptionIDList)
        {
            if(performanceMeasureSubcategoryOptionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureSubcategoryOptions.Where(x => performanceMeasureSubcategoryOptionIDList.Contains(x.PerformanceMeasureSubcategoryOptionID)));
            }
        }

        public static void DeletePerformanceMeasureSubcategoryOption(this ICollection<PerformanceMeasureSubcategoryOption> performanceMeasureSubcategoryOptionsToDelete)
        {
            if(performanceMeasureSubcategoryOptionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.RemoveRange(performanceMeasureSubcategoryOptionsToDelete);
            }
        }

        public static void DeletePerformanceMeasureSubcategoryOption(this int performanceMeasureSubcategoryOptionID)
        {
            DeletePerformanceMeasureSubcategoryOption(new List<int> { performanceMeasureSubcategoryOptionID });
        }

        public static void DeletePerformanceMeasureSubcategoryOption(this PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOptionToDelete)
        {
            DeletePerformanceMeasureSubcategoryOption(new List<PerformanceMeasureSubcategoryOption> { performanceMeasureSubcategoryOptionToDelete });
        }
    }
}