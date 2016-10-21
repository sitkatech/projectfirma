//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionStateHistory]
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
        public static TdrTransactionStateHistory GetTdrTransactionStateHistory(this IQueryable<TdrTransactionStateHistory> tdrTransactionStateHistories, int tdrTransactionStateHistoryID)
        {
            var tdrTransactionStateHistory = tdrTransactionStateHistories.SingleOrDefault(x => x.TdrTransactionStateHistoryID == tdrTransactionStateHistoryID);
            Check.RequireNotNullThrowNotFound(tdrTransactionStateHistory, "TdrTransactionStateHistory", tdrTransactionStateHistoryID);
            return tdrTransactionStateHistory;
        }

        public static void DeleteTdrTransactionStateHistory(this IQueryable<TdrTransactionStateHistory> tdrTransactionStateHistories, List<int> tdrTransactionStateHistoryIDList)
        {
            if(tdrTransactionStateHistoryIDList.Any())
            {
                tdrTransactionStateHistories.Where(x => tdrTransactionStateHistoryIDList.Contains(x.TdrTransactionStateHistoryID)).Delete();
            }
        }

        public static void DeleteTdrTransactionStateHistory(this IQueryable<TdrTransactionStateHistory> tdrTransactionStateHistories, ICollection<TdrTransactionStateHistory> tdrTransactionStateHistoriesToDelete)
        {
            if(tdrTransactionStateHistoriesToDelete.Any())
            {
                var tdrTransactionStateHistoryIDList = tdrTransactionStateHistoriesToDelete.Select(x => x.TdrTransactionStateHistoryID).ToList();
                tdrTransactionStateHistories.Where(x => tdrTransactionStateHistoryIDList.Contains(x.TdrTransactionStateHistoryID)).Delete();
            }
        }

        public static void DeleteTdrTransactionStateHistory(this IQueryable<TdrTransactionStateHistory> tdrTransactionStateHistories, int tdrTransactionStateHistoryID)
        {
            DeleteTdrTransactionStateHistory(tdrTransactionStateHistories, new List<int> { tdrTransactionStateHistoryID });
        }

        public static void DeleteTdrTransactionStateHistory(this IQueryable<TdrTransactionStateHistory> tdrTransactionStateHistories, TdrTransactionStateHistory tdrTransactionStateHistoryToDelete)
        {
            DeleteTdrTransactionStateHistory(tdrTransactionStateHistories, new List<TdrTransactionStateHistory> { tdrTransactionStateHistoryToDelete });
        }
    }
}