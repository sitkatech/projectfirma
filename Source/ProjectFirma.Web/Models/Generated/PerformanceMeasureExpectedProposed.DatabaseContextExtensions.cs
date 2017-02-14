//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedProposed]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeletePerformanceMeasureExpectedProposed(this List<int> performanceMeasureExpectedProposedIDList)
        {
            if(performanceMeasureExpectedProposedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedProposeds.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedProposeds.Where(x => performanceMeasureExpectedProposedIDList.Contains(x.PerformanceMeasureExpectedProposedID)));
            }
        }

        public static void DeletePerformanceMeasureExpectedProposed(this ICollection<PerformanceMeasureExpectedProposed> performanceMeasureExpectedProposedsToDelete)
        {
            if(performanceMeasureExpectedProposedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedProposeds.RemoveRange(performanceMeasureExpectedProposedsToDelete);
            }
        }

        public static void DeletePerformanceMeasureExpectedProposed(this int performanceMeasureExpectedProposedID)
        {
            DeletePerformanceMeasureExpectedProposed(new List<int> { performanceMeasureExpectedProposedID });
        }

        public static void DeletePerformanceMeasureExpectedProposed(this PerformanceMeasureExpectedProposed performanceMeasureExpectedProposedToDelete)
        {
            DeletePerformanceMeasureExpectedProposed(new List<PerformanceMeasureExpectedProposed> { performanceMeasureExpectedProposedToDelete });
        }
    }
}