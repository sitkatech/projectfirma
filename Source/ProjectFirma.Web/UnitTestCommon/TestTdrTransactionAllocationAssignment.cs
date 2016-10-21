using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTdrTransactionAllocationAssignment
    {
        public static TdrTransactionAllocationAssignment Create(CommodityPool commodityPool, DateTime createDate, bool isPublic)
        {
            var tdrTransaction = TestTdrTransaction.Create();
            var retiredSensitiveParcel = TestParcel.Create("1318-23-401-010");
            var receivingParcel = TestParcel.Create("029-604-10");
            var ownership = isPublic ? (Ownership)Ownership.Public : Ownership.Private;
            var tdrTransactionAllocationAssignment = new TdrTransactionAllocationAssignment(tdrTransaction, commodityPool, ownership, retiredSensitiveParcel, ownership, receivingParcel, 1);
            tdrTransactionAllocationAssignment.TdrTransaction.LastUpdateDate = createDate;
            tdrTransactionAllocationAssignment.ReceivingIPESScore = 3;
            tdrTransactionAllocationAssignment.TdrTransaction.Comments = TestFramework.MakeTestName("Comments");
            commodityPool.TdrTransactionAllocationAssignmentsWhereYouAreTheSendingAllocationPool.Add(tdrTransactionAllocationAssignment);
            return tdrTransactionAllocationAssignment;
        }

        public static TdrTransactionAllocationAssignment Create(CommodityPool commodityPool)
        {
            return Create(commodityPool, DateTime.Now, true);
        }

        public static TdrTransactionAllocationAssignment Create()
        {
            //            var commodityPool = CommodityPools.List().First(a => !string.IsNullOrWhiteSpace(a.APNNumber));
            var commodityPool = TestCommodityPool.Create(Commodity.ResidentialAllocation);
            return Create(commodityPool);
        }
    }
}