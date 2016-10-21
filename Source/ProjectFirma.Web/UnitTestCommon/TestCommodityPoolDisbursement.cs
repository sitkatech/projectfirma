using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestCommodityPoolDisbursement
    {
        public static CommodityPoolDisbursement Create(CommodityPool commodityPool, DateTime commodityPoolDisbursementDate, int disbursementAmount)
        {
            var createPerson = TestFramework.TestPerson.Create(ParcelTrackerRole.Admin);
            var commodityPoolDisbursement = CommodityPoolDisbursements.CreateNewCommodityPoolDisbursement(commodityPool, commodityPoolDisbursementDate, createPerson, disbursementAmount);
            commodityPoolDisbursement.CreatePerson = createPerson;
            commodityPoolDisbursement.CreatePersonID = createPerson.PersonID;
            return commodityPoolDisbursement;
        }
    }
}