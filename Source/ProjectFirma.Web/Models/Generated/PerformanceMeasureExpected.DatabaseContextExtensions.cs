//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpected]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeletePerformanceMeasureExpected(this IQueryable<PerformanceMeasureExpected> performanceMeasureExpecteds, List<int> performanceMeasureExpectedIDList)
        {
            if(performanceMeasureExpectedIDList.Any())
            {
                performanceMeasureExpecteds.Where(x => performanceMeasureExpectedIDList.Contains(x.PerformanceMeasureExpectedID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpected(this IQueryable<PerformanceMeasureExpected> performanceMeasureExpecteds, ICollection<PerformanceMeasureExpected> performanceMeasureExpectedsToDelete)
        {
            if(performanceMeasureExpectedsToDelete.Any())
            {
                var performanceMeasureExpectedIDList = performanceMeasureExpectedsToDelete.Select(x => x.PerformanceMeasureExpectedID).ToList();
                performanceMeasureExpecteds.Where(x => performanceMeasureExpectedIDList.Contains(x.PerformanceMeasureExpectedID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpected(this IQueryable<PerformanceMeasureExpected> performanceMeasureExpecteds, int performanceMeasureExpectedID)
        {
            DeletePerformanceMeasureExpected(performanceMeasureExpecteds, new List<int> { performanceMeasureExpectedID });
        }

        public static void DeletePerformanceMeasureExpected(this IQueryable<PerformanceMeasureExpected> performanceMeasureExpecteds, PerformanceMeasureExpected performanceMeasureExpectedToDelete)
        {
            DeletePerformanceMeasureExpected(performanceMeasureExpecteds, new List<PerformanceMeasureExpected> { performanceMeasureExpectedToDelete });
        }
    }
}