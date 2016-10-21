//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionAllocation]
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
        public static TdrTransactionAllocation GetTdrTransactionAllocation(this IQueryable<TdrTransactionAllocation> tdrTransactionAllocations, int tdrTransactionAllocationID)
        {
            var tdrTransactionAllocation = tdrTransactionAllocations.SingleOrDefault(x => x.TdrTransactionAllocationID == tdrTransactionAllocationID);
            Check.RequireNotNullThrowNotFound(tdrTransactionAllocation, "TdrTransactionAllocation", tdrTransactionAllocationID);
            return tdrTransactionAllocation;
        }

        public static void DeleteTdrTransactionAllocation(this IQueryable<TdrTransactionAllocation> tdrTransactionAllocations, List<int> tdrTransactionAllocationIDList)
        {
            if(tdrTransactionAllocationIDList.Any())
            {
                tdrTransactionAllocations.Where(x => tdrTransactionAllocationIDList.Contains(x.TdrTransactionAllocationID)).Delete();
            }
        }

        public static void DeleteTdrTransactionAllocation(this IQueryable<TdrTransactionAllocation> tdrTransactionAllocations, ICollection<TdrTransactionAllocation> tdrTransactionAllocationsToDelete)
        {
            if(tdrTransactionAllocationsToDelete.Any())
            {
                var tdrTransactionAllocationIDList = tdrTransactionAllocationsToDelete.Select(x => x.TdrTransactionAllocationID).ToList();
                tdrTransactionAllocations.Where(x => tdrTransactionAllocationIDList.Contains(x.TdrTransactionAllocationID)).Delete();
            }
        }

        public static void DeleteTdrTransactionAllocation(this IQueryable<TdrTransactionAllocation> tdrTransactionAllocations, int tdrTransactionAllocationID)
        {
            DeleteTdrTransactionAllocation(tdrTransactionAllocations, new List<int> { tdrTransactionAllocationID });
        }

        public static void DeleteTdrTransactionAllocation(this IQueryable<TdrTransactionAllocation> tdrTransactionAllocations, TdrTransactionAllocation tdrTransactionAllocationToDelete)
        {
            DeleteTdrTransactionAllocation(tdrTransactionAllocations, new List<TdrTransactionAllocation> { tdrTransactionAllocationToDelete });
        }
    }
}