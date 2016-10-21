using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using MoreLinq;

namespace ProjectFirma.Web.Models
{
    public static class ResidentialAllocations
    {
        public static List<int> GetRangeOfYears(this IEnumerable<ResidentialAllocation> residentialAllocations)
        {
            var startYear = residentialAllocations.Min(x => x.IssuanceYear);
            var endYear = residentialAllocations.Max(x => x.IssuanceYear);
            return DateUtilities.GetRangeOfYears(startYear, endYear).OrderBy(x => x).ToList();
        }

        public static List<Jurisdiction> GetJurisdictions(this IEnumerable<ResidentialAllocation> residentialAllocations)
        {
            var jurisdictions = residentialAllocations.DistinctBy(x => x.JurisdictionID).Select(x => x.Jurisdiction);
            return jurisdictions.OrderBy(x => x.ResidentialAllocationAbbreviation).ToList();
        }

        public static int GetNextAllocationSequence(this IEnumerable<ResidentialAllocation> residentialAllocations, int commodityPoolID, int issuanceYear)
        {
            var assignedResidentialAllocations = residentialAllocations.Where(x => x.CommodityPoolID == commodityPoolID && x.IssuanceYear == issuanceYear).ToList();

            return !assignedResidentialAllocations.Any() ? 1 : assignedResidentialAllocations.Max(x => x.AllocationSequence) + 1;
        }

        public static ResidentialAllocation GetNextUnallocated(this IEnumerable<ResidentialAllocation> residentialAllocations, int commodityPoolID)
        {
            var unallocatedAllocations = residentialAllocations.Where(x => x.CommodityPoolID == commodityPoolID && !x.IsAllocated).ToList();

            return unallocatedAllocations.Any() ? unallocatedAllocations.MinBy(x => x.AllocationSequence) : null;
        }



    }
}