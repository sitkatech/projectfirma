using System;
using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class TestTransactionTypeCommodity
    {
        public static TransactionTypeCommodity GetRecord(TransactionType transactionType)
        {
            var transactionTypeCommodity = HttpRequestStorage.DatabaseEntities.TransactionTypeCommodities.FirstOrDefault(ttc => ttc.TransactionTypeID == transactionType.TransactionTypeID);
            Check.RequireNotNullThrowNotFound(transactionTypeCommodity, String.Format("TransactionTypeID={0}", transactionType.TransactionTypeID));
            return transactionTypeCommodity;
        }

        public static TransactionTypeCommodity GetRecord(TransactionType transactionType, Commodity commodity)
        {
            return TransactionTypeCommodity.GetByTransactionTypeAndCommodity(transactionType.TransactionTypeID, commodity.CommodityID);
        }
    }
}