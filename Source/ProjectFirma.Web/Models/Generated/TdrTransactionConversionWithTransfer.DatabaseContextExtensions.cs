//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionConversionWithTransfer]
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
        public static TdrTransactionConversionWithTransfer GetTdrTransactionConversionWithTransfer(this IQueryable<TdrTransactionConversionWithTransfer> tdrTransactionConversionWithTransfers, int tdrTransactionConversionWithTransferID)
        {
            var tdrTransactionConversionWithTransfer = tdrTransactionConversionWithTransfers.SingleOrDefault(x => x.TdrTransactionConversionWithTransferID == tdrTransactionConversionWithTransferID);
            Check.RequireNotNullThrowNotFound(tdrTransactionConversionWithTransfer, "TdrTransactionConversionWithTransfer", tdrTransactionConversionWithTransferID);
            return tdrTransactionConversionWithTransfer;
        }

        public static void DeleteTdrTransactionConversionWithTransfer(this IQueryable<TdrTransactionConversionWithTransfer> tdrTransactionConversionWithTransfers, List<int> tdrTransactionConversionWithTransferIDList)
        {
            if(tdrTransactionConversionWithTransferIDList.Any())
            {
                tdrTransactionConversionWithTransfers.Where(x => tdrTransactionConversionWithTransferIDList.Contains(x.TdrTransactionConversionWithTransferID)).Delete();
            }
        }

        public static void DeleteTdrTransactionConversionWithTransfer(this IQueryable<TdrTransactionConversionWithTransfer> tdrTransactionConversionWithTransfers, ICollection<TdrTransactionConversionWithTransfer> tdrTransactionConversionWithTransfersToDelete)
        {
            if(tdrTransactionConversionWithTransfersToDelete.Any())
            {
                var tdrTransactionConversionWithTransferIDList = tdrTransactionConversionWithTransfersToDelete.Select(x => x.TdrTransactionConversionWithTransferID).ToList();
                tdrTransactionConversionWithTransfers.Where(x => tdrTransactionConversionWithTransferIDList.Contains(x.TdrTransactionConversionWithTransferID)).Delete();
            }
        }

        public static void DeleteTdrTransactionConversionWithTransfer(this IQueryable<TdrTransactionConversionWithTransfer> tdrTransactionConversionWithTransfers, int tdrTransactionConversionWithTransferID)
        {
            DeleteTdrTransactionConversionWithTransfer(tdrTransactionConversionWithTransfers, new List<int> { tdrTransactionConversionWithTransferID });
        }

        public static void DeleteTdrTransactionConversionWithTransfer(this IQueryable<TdrTransactionConversionWithTransfer> tdrTransactionConversionWithTransfers, TdrTransactionConversionWithTransfer tdrTransactionConversionWithTransferToDelete)
        {
            DeleteTdrTransactionConversionWithTransfer(tdrTransactionConversionWithTransfers, new List<TdrTransactionConversionWithTransfer> { tdrTransactionConversionWithTransferToDelete });
        }
    }
}