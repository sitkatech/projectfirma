//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransaction]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TdrTransaction GetTdrTransaction(this IQueryable<TdrTransaction> tdrTransactions, int tdrTransactionID)
        {
            var tdrTransaction = tdrTransactions.SingleOrDefault(x => x.TdrTransactionID == tdrTransactionID);
            Check.RequireNotNullThrowNotFound(tdrTransaction, "TdrTransaction", tdrTransactionID);
            return tdrTransaction;
        }

        public static void DeleteTdrTransaction(this IQueryable<TdrTransaction> tdrTransactions, List<int> tdrTransactionIDList)
        {
            if(tdrTransactionIDList.Any())
            {
                tdrTransactions.Where(x => tdrTransactionIDList.Contains(x.TdrTransactionID)).Delete();
            }
        }

        public static void DeleteTdrTransaction(this IQueryable<TdrTransaction> tdrTransactions, ICollection<TdrTransaction> tdrTransactionsToDelete)
        {
            if(tdrTransactionsToDelete.Any())
            {
                var tdrTransactionIDList = tdrTransactionsToDelete.Select(x => x.TdrTransactionID).ToList();
                tdrTransactions.Where(x => tdrTransactionIDList.Contains(x.TdrTransactionID)).Delete();
            }
        }

        public static void DeleteTdrTransaction(this IQueryable<TdrTransaction> tdrTransactions, int tdrTransactionID)
        {
            DeleteTdrTransaction(tdrTransactions, new List<int> { tdrTransactionID });
        }

        public static void DeleteTdrTransaction(this IQueryable<TdrTransaction> tdrTransactions, TdrTransaction tdrTransactionToDelete)
        {
            DeleteTdrTransaction(tdrTransactions, new List<TdrTransaction> { tdrTransactionToDelete });
        }
    }
}