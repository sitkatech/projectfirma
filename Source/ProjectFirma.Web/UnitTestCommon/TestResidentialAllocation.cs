using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestResidentialAllocation
    {
        public const int AlreadyAllocatedFromPoolJurisdictionID = 3;
        public const string AlreadyAllocatedFromPoolJurisdictionAbbreviation = "SLT";

        public static ResidentialAllocation Create(CommodityPoolDisbursement commodityPoolDisbursement)
        {
            var j = TestJurisdiction.Create();
            j.ResidentialAllocationAbbreviation = "TT";

            return new ResidentialAllocation(j, 2015, ResidentialAllocationType.Original, 1, commodityPoolDisbursement, false, commodityPoolDisbursement.CommodityPool);
        }

        public static List<ResidentialAllocation> CreateManyResidentialAllocations()
        {
            var residentialAllocations = new List<ResidentialAllocation>()
            {
                new ResidentialAllocation(3, 2009, 1, 1, 136, false, 71),
                new ResidentialAllocation(3, 2009, 1, 2, 136, false, 71),
                new ResidentialAllocation(4, 2009, 1, 1, 142, false, 72),
                new ResidentialAllocation(5, 2009, 1, 1, 148, false, 73),
                new ResidentialAllocation(1, 2011, 1, 1, 125, false, 69),
                new ResidentialAllocation(4, 2011, 1, 1, 143, false, 72),
                new ResidentialAllocation(3, 2013, 1, 1, 138, false, 71),
                new ResidentialAllocation(4, 2013, 1, 1, 144, false, 72),
                new ResidentialAllocation(5, 2013, 1, 1, 150, false, 73),
                new ResidentialAllocation(3, 2014, 1, 13, 139, false, 71),
                new ResidentialAllocation(4, 2014, 1, 11, 145, false, 72),
                new ResidentialAllocation(1, 2015, 1, 1, 128, false, 69),
                new ResidentialAllocation(2, 2015, 1, 1, 134, false, 70),
                new ResidentialAllocation(4, 2015, 1, 1, 146, false, 72),
                new ResidentialAllocation(1, 2016, 1, 1, 129, false, 69),
                new ResidentialAllocation(3, 2016, 1, 1, 141, false, 71),
                new ResidentialAllocation(4, 2016, 1, 1, 147, false, 72),
                new ResidentialAllocation(4, 2016, 1, 2, 147, false, 72),
                new ResidentialAllocation(4, 2016, 1, 3, 147, false, 72),
                new ResidentialAllocation(6, 2014, 4, 1, 155, false, 74),
                new ResidentialAllocation(6, 2016, 4, 2, 157, false, 74),
                new ResidentialAllocation(6, 2016, 4, 3, 157, false, 74),
            };

            var assignedFromTRPAPool = new ResidentialAllocation(6, 2016, 4, 1, 157, false, 74);
            var assignedToJurisdiction = TestJurisdiction.Create();
            
            assignedToJurisdiction.ResidentialAllocationAbbreviation = AlreadyAllocatedFromPoolJurisdictionAbbreviation;
            assignedToJurisdiction.JurisdictionID = AlreadyAllocatedFromPoolJurisdictionID;
            assignedFromTRPAPool.AssignedToJurisdiction = assignedToJurisdiction;
            assignedFromTRPAPool.AssignedToJurisdictionID = assignedToJurisdiction.JurisdictionID;
            

            residentialAllocations.Add(assignedFromTRPAPool);
            return residentialAllocations;
        }
        
    }
}