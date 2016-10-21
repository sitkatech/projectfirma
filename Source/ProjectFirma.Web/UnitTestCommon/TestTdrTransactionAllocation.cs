using System;
using ProjectFirma.Web.Models;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionAllocation
    {
        public static TdrTransactionAllocation Create(CommodityPool commodityPool, DateTime createDate, int allocatedQuantity, bool isPublic)
        {
            Check.Assert(commodityPool.Commodity != Commodity.ResidentialAllocation, "Residential Allocations must include a Residential Allocation Number");
            var tdrTransaction = TestTdrTransaction.Create();
            var parcel = TestParcel.Create("1318-23-401-010");
            var tdrTransactionAllocation = new TdrTransactionAllocation(tdrTransaction, commodityPool, isPublic ? (Ownership) Ownership.Public : Ownership.Private, parcel, allocatedQuantity);
            tdrTransactionAllocation.TdrTransaction.LastUpdateDate = createDate;
            tdrTransactionAllocation.ReceivingIPESScore = 3;
            tdrTransactionAllocation.TdrTransaction.Comments = TestFramework.MakeTestName("Comments");
            commodityPool.TdrTransactionAllocationsWhereYouAreTheSendingAllocationPool.Add(tdrTransactionAllocation);
            return tdrTransactionAllocation;
        }

        public static TdrTransactionAllocation CreateResidentialTransactionAllocation(CommodityPool commodityPool, DateTime createDate, ResidentialAllocation residentialAllocation, bool isPublic)
        {
            var tdrTransaction = TestTdrTransaction.Create();
            var parcel = TestParcel.Create("1318-23-401-010");
            var tdrTransactionAllocation = new TdrTransactionAllocation(tdrTransaction, commodityPool, isPublic ? (Ownership) Ownership.Public : Ownership.Private, parcel, 1);
            tdrTransactionAllocation.TdrTransaction.ResidentialAllocation = residentialAllocation;
            residentialAllocation.TdrTransaction = tdrTransaction;
            residentialAllocation.TdrTransactionID = tdrTransaction.TdrTransactionID;

            tdrTransactionAllocation.TdrTransaction.LastUpdateDate = createDate;
            tdrTransactionAllocation.ReceivingIPESScore = 3;
            tdrTransactionAllocation.TdrTransaction.Comments = TestFramework.MakeTestName("Comments");
            commodityPool.TdrTransactionAllocationsWhereYouAreTheSendingAllocationPool.Add(tdrTransactionAllocation);
            return tdrTransactionAllocation;
        }

        public static TdrTransactionAllocation Create(CommodityPool commodityPool)
        {
            return Create(commodityPool, DateTime.Now, 0, true);
        }

        public static TdrTransactionAllocation Create()
        {
//            var commodityPool = CommodityPools.List().First(a => !string.IsNullOrWhiteSpace(a.APNNumber));
            var commodityPool = TestCommodityPool.Create(Commodity.ResidentialAllocation);
            return Create(commodityPool);
        }
    }
}