using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ResidentialAllocation GetResidentialAllocationByResidentialAllocationNumber(this IQueryable<ResidentialAllocation> residentialAllocations, string residentialAllocationNumber)
        {
            return GetResidentialAllocationByResidentialAllocationNumber(residentialAllocations, residentialAllocationNumber, true);
        }

        public static ResidentialAllocation GetResidentialAllocationByResidentialAllocationNumber(this IQueryable<ResidentialAllocation> residentialAllocations, string residentialAllocationNumber, bool requireRecord)
        {
            var residentialAllocation = residentialAllocations.ToList().SingleOrDefault(x => x.ResidentialAllocationNumber.Equals(residentialAllocationNumber, StringComparison.InvariantCultureIgnoreCase));
            if (requireRecord && residentialAllocation == null)
            {
                throw new SitkaRecordNotFoundException(string.Format("Residential Allocation '{0}' not found!", residentialAllocationNumber));
            }
            return residentialAllocation;
        }

        public static IEnumerable<SelectListItem> GetAvailableResidentialAllocationNumbersAsSelectListItems(this IEnumerable<ResidentialAllocation> residentialAllocations, ResidentialAllocation existingResidentialAllocation)
        {
            var availableResidentialAllocationNumbers =
                GetAvailableResidentialAllocationNumbers(residentialAllocations, existingResidentialAllocation)
                    .ToSelectListWithEmptyFirstRow(x => x.ResidentialAllocationID.ToString(), x => x.ResidentialAllocationNumber);
            return availableResidentialAllocationNumbers;
        }

        public static IEnumerable<ResidentialAllocation> GetAvailableResidentialAllocationNumbers(this IEnumerable<ResidentialAllocation> residentialAllocations, ResidentialAllocation existingResidentialAllocation)
        {
            var existingResidentialAllocationID = existingResidentialAllocation == null ? (int?)null : existingResidentialAllocation.ResidentialAllocationID;
            return residentialAllocations.ToList()
                .Where(x => !x.IsAllocated || x.ResidentialAllocationID == existingResidentialAllocationID)
                .ToList()
                .OrderBy(x => x.ResidentialAllocationNumber);
        }

        public static bool IsResidentialAllocationNumberUnique(this IQueryable<ResidentialAllocation> residentialAllocations, string residentialAllocationNumber, int currentResidentialAllocationID)
        {
            var residentialAllocation = residentialAllocations.ToList().SingleOrDefault(x => x.ResidentialAllocationID != currentResidentialAllocationID && String.Equals(x.ResidentialAllocationNumber, residentialAllocationNumber, StringComparison.InvariantCultureIgnoreCase));
            return residentialAllocation == null;
        }

    }
}