//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpectedProposed]
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
        public static EIPPerformanceMeasureExpectedProposed GetEIPPerformanceMeasureExpectedProposed(this IQueryable<EIPPerformanceMeasureExpectedProposed> eIPPerformanceMeasureExpectedProposeds, int eIPPerformanceMeasureExpectedProposedID)
        {
            var eIPPerformanceMeasureExpectedProposed = eIPPerformanceMeasureExpectedProposeds.SingleOrDefault(x => x.EIPPerformanceMeasureExpectedProposedID == eIPPerformanceMeasureExpectedProposedID);
            Check.RequireNotNullThrowNotFound(eIPPerformanceMeasureExpectedProposed, "EIPPerformanceMeasureExpectedProposed", eIPPerformanceMeasureExpectedProposedID);
            return eIPPerformanceMeasureExpectedProposed;
        }

        public static void DeleteEIPPerformanceMeasureExpectedProposed(this IQueryable<EIPPerformanceMeasureExpectedProposed> eIPPerformanceMeasureExpectedProposeds, List<int> eIPPerformanceMeasureExpectedProposedIDList)
        {
            if(eIPPerformanceMeasureExpectedProposedIDList.Any())
            {
                eIPPerformanceMeasureExpectedProposeds.Where(x => eIPPerformanceMeasureExpectedProposedIDList.Contains(x.EIPPerformanceMeasureExpectedProposedID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpectedProposed(this IQueryable<EIPPerformanceMeasureExpectedProposed> eIPPerformanceMeasureExpectedProposeds, ICollection<EIPPerformanceMeasureExpectedProposed> eIPPerformanceMeasureExpectedProposedsToDelete)
        {
            if(eIPPerformanceMeasureExpectedProposedsToDelete.Any())
            {
                var eIPPerformanceMeasureExpectedProposedIDList = eIPPerformanceMeasureExpectedProposedsToDelete.Select(x => x.EIPPerformanceMeasureExpectedProposedID).ToList();
                eIPPerformanceMeasureExpectedProposeds.Where(x => eIPPerformanceMeasureExpectedProposedIDList.Contains(x.EIPPerformanceMeasureExpectedProposedID)).Delete();
            }
        }

        public static void DeleteEIPPerformanceMeasureExpectedProposed(this IQueryable<EIPPerformanceMeasureExpectedProposed> eIPPerformanceMeasureExpectedProposeds, int eIPPerformanceMeasureExpectedProposedID)
        {
            DeleteEIPPerformanceMeasureExpectedProposed(eIPPerformanceMeasureExpectedProposeds, new List<int> { eIPPerformanceMeasureExpectedProposedID });
        }

        public static void DeleteEIPPerformanceMeasureExpectedProposed(this IQueryable<EIPPerformanceMeasureExpectedProposed> eIPPerformanceMeasureExpectedProposeds, EIPPerformanceMeasureExpectedProposed eIPPerformanceMeasureExpectedProposedToDelete)
        {
            DeleteEIPPerformanceMeasureExpectedProposed(eIPPerformanceMeasureExpectedProposeds, new List<EIPPerformanceMeasureExpectedProposed> { eIPPerformanceMeasureExpectedProposedToDelete });
        }
    }
}