using System;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionTransfer
    {
        public static TdrTransactionTransfer Create(Commodity commodity)
        {
            var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.GetLeadAgency(8); // TRPA
            var person = TestFramework.TestPerson.Create(leadAgency, ParcelTrackerRole.Admin);
            var leadAgencyTransactionTypeCommodity = leadAgency.LeadAgencyTransactionTypeCommodities.First(c => c.TransactionTypeCommodity.TransactionType == TransactionType.Transfer && c.TransactionTypeCommodity.Commodity == commodity);
            var tdrTransaction = TestTdrTransaction.Create(leadAgencyTransactionTypeCommodity, person);
            var sendingParcel = TestParcel.Create("1318-09-810-019");
            var receivingParcel = TestParcel.Create("029-604-10");
            var tdrTransactionTransfer = new TdrTransactionTransfer(tdrTransaction, sendingParcel, 63, Ownership.Private, receivingParcel, 52);

            tdrTransactionTransfer.TdrTransaction.LastUpdateDate = DateTime.Now;
            var sendingBaileyRating = BaileyRating._2;
            tdrTransactionTransfer.SendingBaileyRatingID = sendingBaileyRating.BaileyRatingID;
            var receivingBaileyRating = BaileyRating._6;
            tdrTransactionTransfer.ReceivingBaileyRatingID = receivingBaileyRating.BaileyRatingID;
            tdrTransactionTransfer.TransferPrice = 56789.99m;

            return tdrTransactionTransfer;
        }
    }
}