//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedSubcategoryOptionProposed]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this List<int> performanceMeasureExpectedSubcategoryOptionProposedIDList)
        {
            if(performanceMeasureExpectedSubcategoryOptionProposedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptionProposeds.RemoveRange(HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpectedSubcategoryOptionProposeds.Where(x => performanceMeasureExpectedSubcategoryOptionProposedIDList.Contains(x.PerformanceMeasureExpectedSubcategoryOptionProposedID)));
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> performanceMeasureExpectedSubcategoryOptionProposedsToDelete)
        {
            if(performanceMeasureExpectedSubcategoryOptionProposedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureExpectedSubcategoryOptionProposeds.RemoveRange(performanceMeasureExpectedSubcategoryOptionProposedsToDelete);
            }
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this int performanceMeasureExpectedSubcategoryOptionProposedID)
        {
            DeletePerformanceMeasureExpectedSubcategoryOptionProposed(new List<int> { performanceMeasureExpectedSubcategoryOptionProposedID });
        }

        public static void DeletePerformanceMeasureExpectedSubcategoryOptionProposed(this PerformanceMeasureExpectedSubcategoryOptionProposed performanceMeasureExpectedSubcategoryOptionProposedToDelete)
        {
            DeletePerformanceMeasureExpectedSubcategoryOptionProposed(new List<PerformanceMeasureExpectedSubcategoryOptionProposed> { performanceMeasureExpectedSubcategoryOptionProposedToDelete });
        }
    }
}