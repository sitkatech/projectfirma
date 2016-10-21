using System;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionTransferWithBonusUnit
    {
        public static TdrTransactionTransferWithBonusUnit Create(bool isPublic)
        {
            var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.GetLeadAgency(8); // TRPA
            var person = TestFramework.TestPerson.Create(leadAgency, ParcelTrackerRole.Admin);
            var leadAgencyTransactionTypeCommodity = leadAgency.LeadAgencyTransactionTypeCommodities.First(c => c.TransactionTypeCommodity.TransactionType == TransactionType.TransferWithBonusUnit);
            var tdrTransaction = TestTdrTransaction.Create(leadAgencyTransactionTypeCommodity, person);
            var commodityPool = TestCommodityPool.Create(Commodity.ResidentialAllocation);
            var sendingParcel = TestParcel.Create("1318-09-810-110");
            var receivingParcel = TestParcel.Create("029-041-02");
            var tdrTransactionTransferWithBonusUnit = new TdrTransactionTransferWithBonusUnit(tdrTransaction, sendingParcel, commodityPool, 43, isPublic ? (Ownership)Ownership.Public : Ownership.Private, receivingParcel, 41, 7);

            tdrTransactionTransferWithBonusUnit.TdrTransaction.LastUpdateDate = DateTime.Now;
            var sendingBaileyRating = BaileyRating._7;
            tdrTransactionTransferWithBonusUnit.SendingBaileyRatingID = sendingBaileyRating.BaileyRatingID;
            tdrTransactionTransferWithBonusUnit.ReceivingIPESScore = 13;
            tdrTransactionTransferWithBonusUnit.TransferPrice = 56789.99m;
            return tdrTransactionTransferWithBonusUnit;
        }
    }
}