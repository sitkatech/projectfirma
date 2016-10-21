//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionTransfer]
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
        public static TdrTransactionTransfer GetTdrTransactionTransfer(this IQueryable<TdrTransactionTransfer> tdrTransactionTransfers, int tdrTransactionTransferID)
        {
            var tdrTransactionTransfer = tdrTransactionTransfers.SingleOrDefault(x => x.TdrTransactionTransferID == tdrTransactionTransferID);
            Check.RequireNotNullThrowNotFound(tdrTransactionTransfer, "TdrTransactionTransfer", tdrTransactionTransferID);
            return tdrTransactionTransfer;
        }

        public static void DeleteTdrTransactionTransfer(this IQueryable<TdrTransactionTransfer> tdrTransactionTransfers, List<int> tdrTransactionTransferIDList)
        {
            if(tdrTransactionTransferIDList.Any())
            {
                tdrTransactionTransfers.Where(x => tdrTransactionTransferIDList.Contains(x.TdrTransactionTransferID)).Delete();
            }
        }

        public static void DeleteTdrTransactionTransfer(this IQueryable<TdrTransactionTransfer> tdrTransactionTransfers, ICollection<TdrTransactionTransfer> tdrTransactionTransfersToDelete)
        {
            if(tdrTransactionTransfersToDelete.Any())
            {
                var tdrTransactionTransferIDList = tdrTransactionTransfersToDelete.Select(x => x.TdrTransactionTransferID).ToList();
                tdrTransactionTransfers.Where(x => tdrTransactionTransferIDList.Contains(x.TdrTransactionTransferID)).Delete();
            }
        }

        public static void DeleteTdrTransactionTransfer(this IQueryable<TdrTransactionTransfer> tdrTransactionTransfers, int tdrTransactionTransferID)
        {
            DeleteTdrTransactionTransfer(tdrTransactionTransfers, new List<int> { tdrTransactionTransferID });
        }

        public static void DeleteTdrTransactionTransfer(this IQueryable<TdrTransactionTransfer> tdrTransactionTransfers, TdrTransactionTransfer tdrTransactionTransferToDelete)
        {
            DeleteTdrTransactionTransfer(tdrTransactionTransfers, new List<TdrTransactionTransfer> { tdrTransactionTransferToDelete });
        }
    }
}