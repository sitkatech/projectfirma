using System;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionLandBankAcquisition
    {
        public static TdrTransactionLandBankAcquisition Create()
        {
            var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.GetLeadAgency(8); // TRPA
            var person = TestFramework.TestPerson.Create(leadAgency, ParcelTrackerRole.Admin);
            var leadAgencyTransactionTypeCommodity = leadAgency.LeadAgencyTransactionTypeCommodities.First(c => c.TransactionTypeCommodity.TransactionType == TransactionType.LandBankAcquisition);
            var landBank = HttpRequestStorage.DatabaseEntities.LandBanks.GetLandBank(1); // CTC
            var tdrTransaction = TestTdrTransaction.Create(leadAgencyTransactionTypeCommodity, person);
            var sendingParcel = TestParcel.Create("1318-22-001-002");
            var tdrTransactionLandBankAcquisition = new TdrTransactionLandBankAcquisition(tdrTransaction, sendingParcel, 12, landBank, 56789.99m);
            tdrTransactionLandBankAcquisition.TdrTransaction.LastUpdateDate = DateTime.Now;
            var sendingBaileyRating = BaileyRating.a_1;
            tdrTransactionLandBankAcquisition.SendingBaileyRatingID = sendingBaileyRating.BaileyRatingID;
            return tdrTransactionLandBankAcquisition;
        }
    }
}