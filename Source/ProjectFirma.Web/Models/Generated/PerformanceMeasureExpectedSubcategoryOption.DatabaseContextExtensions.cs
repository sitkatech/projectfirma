//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this List<int> performanceMeasureExpectedSubcategoryOptionIDList)
        {
            if(performanceMeasureExpectedSubcategoryOptionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptions.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptions.Where(x => performanceMeasureExpectedSubcategoryOptionIDList.Contains(x.PerformanceMeasureExpectedSubcategoryOptionID)));
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this ICollection<PerformanceMeasureExpectedSubcategoryOption> performanceMeasureExpectedSubcategoryOptionsToDelete)
        {
            if(performanceMeasureExpectedSubcategoryOptionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptions.RemoveRange(performanceMeasureExpectedSubcategoryOptionsToDelete);
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this int performanceMeasureExpectedSubcategoryOptionID)
        {
            DeletePerformanceMeasureExpectedSubcategoryOption(new List<int> { performanceMeasureExpectedSubcategoryOptionID });
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOption(this PerformanceMeasureExpectedSubcategoryOption performanceMeasureExpectedSubcategoryOptionToDelete)
        {
            DeletePerformanceMeasureExpectedSubcategoryOption(new List<PerformanceMeasureExpectedSubcategoryOption> { performanceMeasureExpectedSubcategoryOptionToDelete });
        }
    }
}