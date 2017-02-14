//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpected]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PerformanceMeasureExpected GetPerformanceMeasureExpected(this IQueryable<PerformanceMeasureExpected> performanceMeasureExpecteds, int performanceMeasureExpectedID)
        {
            var performanceMeasureExpected = performanceMeasureExpecteds.SingleOrDefault(x => x.PerformanceMeasureExpectedID == performanceMeasureExpectedID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpected, "PerformanceMeasureExpected", performanceMeasureExpectedID);
            return performanceMeasureExpected;
        }

        public static void DeletePerformanceMeasureExpected(this List<int> performanceMeasureExpectedIDList)
        {
            if(performanceMeasureExpectedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpecteds.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Where(x => performanceMeasureExpectedIDList.Contains(x.PerformanceMeasureExpectedID)));
            }
        }

        public static void DeletePerformanceMeasureExpected(this ICollection<PerformanceMeasureExpected> performanceMeasureExpectedsToDelete)
        {
            if(performanceMeasureExpectedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpecteds.RemoveRange(performanceMeasureExpectedsToDelete);
            }
        }

        public static void DeletePerformanceMeasureExpected(this int performanceMeasureExpectedID)
        {
            DeletePerformanceMeasureExpected(new List<int> { performanceMeasureExpectedID });
        }

        public static void DeletePerformanceMeasureExpected(this PerformanceMeasureExpected performanceMeasureExpectedToDelete)
        {
            DeletePerformanceMeasureExpected(new List<PerformanceMeasureExpected> { performanceMeasureExpectedToDelete });
        }
    }
}