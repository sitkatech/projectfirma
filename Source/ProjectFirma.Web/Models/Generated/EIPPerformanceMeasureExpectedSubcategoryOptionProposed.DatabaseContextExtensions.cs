//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpectedSubcategoryOptionProposed]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static EIPPerformanceMeasureExpectedSubcategoryOptionProposed GetEIPPerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, int eIPPerformanceMeasureExpectedSubcategoryOptionProposedID)
        {
            var eIPPerformanceMeasureExpectedSubcategoryOptionProposed = eIPPerformanceMeasureExpectedSubcategoryOptionProposeds.SingleOrDefault(x => x.EIPPerformanceMeasureExpectedSubcategoryOptionProposedID == eIPPerformanceMeasureExpectedSubcategoryOptionProposedID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureExpectedSubcategoryOptionProposed, "EIPPerformanceMeasureExpectedSubcategoryOptionProposed", eIPPerformanceMeasureExpectedSubcategoryOptionProposedID);
            return eIPPerformanceMeasureExpectedSubcategoryOptionProposed;
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, List<int> eIPPerformanceMeasureExpectedSubcategoryOptionProposedIDList)
        {
            if(eIPPerformanceMeasureExpectedSubcategoryOptionProposedIDList.Any())
            {
                eIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Where(x => eIPPerformanceMeasureExpectedSubcategoryOptionProposedIDList.Contains(x.EIPPerformanceMeasureExpectedSubcategoryOptionProposedID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, ICollection<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> eIPPerformanceMeasureExpectedSubcategoryOptionProposedsToDelete)
        {
            if(eIPPerformanceMeasureExpectedSubcategoryOptionProposedsToDelete.Any())
            {
                var eIPPerformanceMeasureExpectedSubcategoryOptionProposedIDList = eIPPerformanceMeasureExpectedSubcategoryOptionProposedsToDelete.Select(x => x.EIPPerformanceMeasureExpectedSubcategoryOptionProposedID).ToList();
                eIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Where(x => eIPPerformanceMeasureExpectedSubcategoryOptionProposedIDList.Contains(x.EIPPerformanceMeasureExpectedSubcategoryOptionProposedID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, int eIPPerformanceMeasureExpectedSubcategoryOptionProposedID)
        {
            DeleteEIPPerformanceMeasureExpectedSubcategoryOptionProposed(eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, new List<int> { eIPPerformanceMeasureExpectedSubcategoryOptionProposedID });
        }

        public static void DeleteEIPPerformanceMeasureExpectedSubcategoryOptionProposed(this IQueryable<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, EIPPerformanceMeasureExpectedSubcategoryOptionProposed eIPPerformanceMeasureExpectedSubcategoryOptionProposedToDelete)
        {
            DeleteEIPPerformanceMeasureExpectedSubcategoryOptionProposed(eIPPerformanceMeasureExpectedSubcategoryOptionProposeds, new List<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> { eIPPerformanceMeasureExpectedSubcategoryOptionProposedToDelete });
        }
    }
}