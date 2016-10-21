//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpected]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EIPPerformanceMeasureExpected GetEIPPerformanceMeasureExpected(this IQueryable<EIPPerformanceMeasureExpected> eIPPerformanceMeasureExpecteds, int eIPPerformanceMeasureExpectedID)
        {
            var eIPPerformanceMeasureExpected = eIPPerformanceMeasureExpecteds.SingleOrDefault(x => x.EIPPerformanceMeasureExpectedID == eIPPerformanceMeasureExpectedID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureExpected, "EIPPerformanceMeasureExpected", eIPPerformanceMeasureExpectedID);
            return eIPPerformanceMeasureExpected;
        }

        public static void DeleteEIPPerformanceMeasureExpected(this IQueryable<EIPPerformanceMeasureExpected> eIPPerformanceMeasureExpecteds, List<int> eIPPerformanceMeasureExpectedIDList)
        {
            if(eIPPerformanceMeasureExpectedIDList.Any())
            {
                eIPPerformanceMeasureExpecteds.Where(x => eIPPerformanceMeasureExpectedIDList.Contains(x.EIPPerformanceMeasureExpectedID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpected(this IQueryable<EIPPerformanceMeasureExpected> eIPPerformanceMeasureExpecteds, ICollection<EIPPerformanceMeasureExpected> eIPPerformanceMeasureExpectedsToDelete)
        {
            if(eIPPerformanceMeasureExpectedsToDelete.Any())
            {
                var eIPPerformanceMeasureExpectedIDList = eIPPerformanceMeasureExpectedsToDelete.Select(x => x.EIPPerformanceMeasureExpectedID).ToList();
                eIPPerformanceMeasureExpecteds.Where(x => eIPPerformanceMeasureExpectedIDList.Contains(x.EIPPerformanceMeasureExpectedID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpected(this IQueryable<EIPPerformanceMeasureExpected> eIPPerformanceMeasureExpecteds, int eIPPerformanceMeasureExpectedID)
        {
            DeleteEIPPerformanceMeasureExpected(eIPPerformanceMeasureExpecteds, new List<int> { eIPPerformanceMeasureExpectedID });
        }

        public static void DeleteEIPPerformanceMeasureExpected(this IQueryable<EIPPerformanceMeasureExpected> eIPPerformanceMeasureExpecteds, EIPPerformanceMeasureExpected eIPPerformanceMeasureExpectedToDelete)
        {
            DeleteEIPPerformanceMeasureExpected(eIPPerformanceMeasureExpecteds, new List<EIPPerformanceMeasureExpected> { eIPPerformanceMeasureExpectedToDelete });
        }
    }
}