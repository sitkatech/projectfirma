//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]
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
        public static PerformanceMeasureExpectedSubcategoryOptionProposed GetPerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposeds, int performanceMeasureExpectedSubcategoryOptionProposedID)
        {
            var performanceMeasureExpectedSubcategoryOptionProposed = performanceMeasureExpectedSubcategoryOptionProposeds.SingleOrDefault(x => x.PerformanceMeasureExpectedSubcategoryOptionProposedID == performanceMeasureExpectedSubcategoryOptionProposedID);
            Check.RequireNotNullThrowNotFound(performanceMeasureExpectedSubcategoryOptionProposed, "PerformanceMeasureExpectedSubcategoryOptionProposed", performanceMeasureExpectedSubcategoryOptionProposedID);
            return performanceMeasureExpectedSubcategoryOptionProposed;
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposeds, List<int> performanceMeasureExpectedSubcategoryOptionProposedIDList)
        {
            if(performanceMeasureExpectedSubcategoryOptionProposedIDList.Any())
            {
                performanceMeasureExpectedSubcategoryOptionProposeds.Where(x => performanceMeasureExpectedSubcategoryOptionProposedIDList.Contains(x.PerformanceMeasureExpectedSubcategoryOptionProposedID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposeds, ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposedsToDelete)
        {
            if(performanceMeasureExpectedSubcategoryOptionProposedsToDelete.Any())
            {
                var performanceMeasureExpectedSubcategoryOptionProposedIDList = performanceMeasureExpectedSubcategoryOptionProposedsToDelete.Select(x => x.PerformanceMeasureExpectedSubcategoryOptionProposedID).ToList();
                performanceMeasureExpectedSubcategoryOptionProposeds.Where(x => performanceMeasureExpectedSubcategoryOptionProposedIDList.Contains(x.PerformanceMeasureExpectedSubcategoryOptionProposedID)).Delete();
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposeds, int performanceMeasureExpectedSubcategoryOptionProposedID)
        {
            DeletePerformanceMeasureExpectedSubcategoryOptionProposed(performanceMeasureExpectedSubcategoryOptionProposeds, new List<int> { performanceMeasureExpectedSubcategoryOptionProposedID });
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposeds, PerformanceMeasureExpectedSubcategoryOptionProposed performanceMeasureExpectedSubcategoryOptionProposedToDelete)
        {
            DeletePerformanceMeasureExpectedSubcategoryOptionProposed(performanceMeasureExpectedSubcategoryOptionProposeds, new List<PerformanceMeasureExpectedSubcategoryOptionProposed> { performanceMeasureExpectedSubcategoryOptionProposedToDelete });
        }
    }
}