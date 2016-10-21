//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransactionTypeCommodity]
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
        public static TransactionTypeCommodity GetTransactionTypeCommodity(this IQueryable<TransactionTypeCommodity> transactionTypeCommodities, int transactionTypeCommodityID)
        {
            var transactionTypeCommodity = transactionTypeCommodities.SingleOrDefault(x => x.TransactionTypeCommodityID == transactionTypeCommodityID);
            Check.RequireNotNullThrowNotFound(transactionTypeCommodity, "TransactionTypeCommodity", transactionTypeCommodityID);
            return transactionTypeCommodity;
        }

        public static void DeleteTransactionTypeCommodity(this IQueryable<TransactionTypeCommodity> transactionTypeCommodities, List<int> transactionTypeCommodityIDList)
        {
            if(transactionTypeCommodityIDList.Any())
            {
                transactionTypeCommodities.Where(x => transactionTypeCommodityIDList.Contains(x.TransactionTypeCommodityID)).Delete();
            }
        }

        public static void DeleteTransactionTypeCommodity(this IQueryable<TransactionTypeCommodity> transactionTypeCommodities, ICollection<TransactionTypeCommodity> transactionTypeCommoditiesToDelete)
        {
            if(transactionTypeCommoditiesToDelete.Any())
            {
                var transactionTypeCommodityIDList = transactionTypeCommoditiesToDelete.Select(x => x.TransactionTypeCommodityID).ToList();
                transactionTypeCommodities.Where(x => transactionTypeCommodityIDList.Contains(x.TransactionTypeCommodityID)).Delete();
            }
        }

        public static void DeleteTransactionTypeCommodity(this IQueryable<TransactionTypeCommodity> transactionTypeCommodities, int transactionTypeCommodityID)
        {
            DeleteTransactionTypeCommodity(transactionTypeCommodities, new List<int> { transactionTypeCommodityID });
        }

        public static void DeleteTransactionTypeCommodity(this IQueryable<TransactionTypeCommodity> transactionTypeCommodities, TransactionTypeCommodity transactionTypeCommodityToDelete)
        {
            DeleteTransactionTypeCommodity(transactionTypeCommodities, new List<TransactionTypeCommodity> { transactionTypeCommodityToDelete });
        }
    }
}