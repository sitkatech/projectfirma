//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ResidentialAllocation]
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
        public static ResidentialAllocation GetResidentialAllocation(this IQueryable<ResidentialAllocation> residentialAllocations, int residentialAllocationID)
        {
            var residentialAllocation = residentialAllocations.SingleOrDefault(x => x.ResidentialAllocationID == residentialAllocationID);
            Check.RequireNotNullThrowNotFound(residentialAllocation, "ResidentialAllocation", residentialAllocationID);
            return residentialAllocation;
        }

        public static void DeleteResidentialAllocation(this IQueryable<ResidentialAllocation> residentialAllocations, List<int> residentialAllocationIDList)
        {
            if(residentialAllocationIDList.Any())
            {
                residentialAllocations.Where(x => residentialAllocationIDList.Contains(x.ResidentialAllocationID)).Delete();
            }
        }

        public static void DeleteResidentialAllocation(this IQueryable<ResidentialAllocation> residentialAllocations, ICollection<ResidentialAllocation> residentialAllocationsToDelete)
        {
            if(residentialAllocationsToDelete.Any())
            {
                var residentialAllocationIDList = residentialAllocationsToDelete.Select(x => x.ResidentialAllocationID).ToList();
                residentialAllocations.Where(x => residentialAllocationIDList.Contains(x.ResidentialAllocationID)).Delete();
            }
        }

        public static void DeleteResidentialAllocation(this IQueryable<ResidentialAllocation> residentialAllocations, int residentialAllocationID)
        {
            DeleteResidentialAllocation(residentialAllocations, new List<int> { residentialAllocationID });
        }

        public static void DeleteResidentialAllocation(this IQueryable<ResidentialAllocation> residentialAllocations, ResidentialAllocation residentialAllocationToDelete)
        {
            DeleteResidentialAllocation(residentialAllocations, new List<ResidentialAllocation> { residentialAllocationToDelete });
        }
    }
}