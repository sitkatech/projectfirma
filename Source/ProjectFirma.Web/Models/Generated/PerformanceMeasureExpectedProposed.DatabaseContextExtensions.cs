//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedProposed]
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
        public static PerformanceMeasureExpectedProposed GetPerformanceMeasureExpectedProposed(this IQueryable<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposeds, int performanceMeasureExpectedProposedID)
        {
            var performanceMeasureExpectedProposed = performanceMeasureExpectedProposeds.SingleOrDefault(x => x.PerformanceMeasureExpectedProposedID == performanceMeasureExpectedProposedID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpectedProposed, "PerformanceMeasureExpectedProposed", performanceMeasureExpectedProposedID);
            return performanceMeasureExpectedProposed;
        }

        public static void DeletePerformanceMeasureExpectedProposed(this IQueryable<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposeds, List<int> performanceMeasureExpectedProposedIDList)
        {
            if(performanceMeasureExpectedProposedIDList.Any())
            {
                performanceMeasureExpectedProposeds.Where(x => performanceMeasureExpectedProposedIDList.Contains(x.PerformanceMeasureExpectedProposedID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpectedProposed(this IQueryable<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposeds, ICollection<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposedsToDelete)
        {
            if(performanceMeasureExpectedProposedsToDelete.Any())
            {
                var performanceMeasureExpectedProposedIDList = performanceMeasureExpectedProposedsToDelete.Select(x => x.PerformanceMeasureExpectedProposedID).ToList();
                performanceMeasureExpectedProposeds.Where(x => performanceMeasureExpectedProposedIDList.Contains(x.PerformanceMeasureExpectedProposedID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpectedProposed(this IQueryable<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposeds, int performanceMeasureExpectedProposedID)
        {
            DeletePerformanceMeasureExpectedProposed(performanceMeasureExpectedProposeds, new List<int> { performanceMeasureExpectedProposedID });
        }

        public static void DeletePerformanceMeasureExpectedProposed(this IQueryable<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposeds, PerformanceMeasureExpectedProposed performanceMeasureExpectedProposedToDelete)
        {
            DeletePerformanceMeasureExpectedProposed(performanceMeasureExpectedProposeds, new List<PerformanceMeasureExpectedProposed> { performanceMeasureExpectedProposedToDelete });
        }
    }
}