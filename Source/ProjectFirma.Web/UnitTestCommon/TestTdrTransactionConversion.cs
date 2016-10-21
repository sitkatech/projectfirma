using System;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionConversion
    {
        public static TdrTransactionConversion Create()
        {
            var leadAgency = HttpRequestStorage.DatabaseEntities.LeadAgencies.GetLeadAgency(8); // TRPA
            var person = TestFramework.TestPerson.Create(leadAgency, ParcelTrackerRole.Admin);
            var leadAgencyTransactionTypeCommodity = leadAgency.LeadAgencyTransactionTypeCommodities.First(c => c.TransactionTypeCommodity.TransactionType == TransactionType.Conversion);
            var tdrTransaction = TestTdrTransaction.Create(leadAgencyTransactionTypeCommodity, person);
            var commodityConvertedTo = tdrTransaction.Commodity.GetCommoditiesConvertibleTo().First();
            var parcel = TestParcel.Create("092-051-007");
            var tdrTransactionConversion = new TdrTransactionConversion(tdrTransaction, parcel, Ownership.Public, commodityConvertedTo, 11, 10);
            tdrTransactionConversion.TdrTransaction.LastUpdateDate = DateTime.Now;
            var sendingBaileyRating = BaileyRating._7;
            tdrTransactionConversion.BaileyRatingID = sendingBaileyRating.BaileyRatingID;

            return tdrTransactionConversion;
        }
    }
}