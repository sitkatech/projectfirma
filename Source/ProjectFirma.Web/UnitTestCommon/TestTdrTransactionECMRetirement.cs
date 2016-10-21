using System;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionECMRetirement
    {
        public static TdrTransactionECMRetirement Create()
        {
            var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.GetLeadAgency(8); // TRPA
            var person = TestFramework.TestPerson.Create(leadAgency, ParcelTrackerRole.Admin);
            var leadAgencyTransactionTypeCommodity = leadAgency.LeadAgencyTransactionTypeCommodities.First(c => c.TransactionTypeCommodity.TransactionType == TransactionType.ECMRetirement);
            var tdrTransaction = TestTdrTransaction.Create(leadAgencyTransactionTypeCommodity, person);
            var landBank = HttpRequestStorage.DatabaseEntities.LandBanks.GetLandBank(1); // CTC
            var sendingParcel = TestParcel.Create("1318-16-710-002");
            var tdrTransactionEcmRetirement = new TdrTransactionECMRetirement(tdrTransaction, landBank, sendingParcel, 77, 56789.99m);
            var tdrTransactionECMRetirement = tdrTransactionEcmRetirement;
            tdrTransactionECMRetirement.TdrTransaction.LastUpdateDate = DateTime.Now;
            tdrTransactionECMRetirement.SendingIPESScore = 3;
            return tdrTransactionECMRetirement;
        }
    }
}