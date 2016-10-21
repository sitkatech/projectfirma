//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionLandBankAcquisition]
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
        public static TdrTransactionLandBankAcquisition GetTdrTransactionLandBankAcquisition(this IQueryable<TdrTransactionLandBankAcquisition> tdrTransactionLandBankAcquisitions, int tdrTransactionLandBankAcquisitionID)
        {
            var tdrTransactionLandBankAcquisition = tdrTransactionLandBankAcquisitions.SingleOrDefault(x => x.TdrTransactionLandBankAcquisitionID == tdrTransactionLandBankAcquisitionID);
            Check.RequireNotNullThrowNotFound(tdrTransactionLandBankAcquisition, "TdrTransactionLandBankAcquisition", tdrTransactionLandBankAcquisitionID);
            return tdrTransactionLandBankAcquisition;
        }

        public static void DeleteTdrTransactionLandBankAcquisition(this IQueryable<TdrTransactionLandBankAcquisition> tdrTransactionLandBankAcquisitions, List<int> tdrTransactionLandBankAcquisitionIDList)
        {
            if(tdrTransactionLandBankAcquisitionIDList.Any())
            {
                tdrTransactionLandBankAcquisitions.Where(x => tdrTransactionLandBankAcquisitionIDList.Contains(x.TdrTransactionLandBankAcquisitionID)).Delete();
            }
        }

        public static void DeleteTdrTransactionLandBankAcquisition(this IQueryable<TdrTransactionLandBankAcquisition> tdrTransactionLandBankAcquisitions, ICollection<TdrTransactionLandBankAcquisition> tdrTransactionLandBankAcquisitionsToDelete)
        {
            if(tdrTransactionLandBankAcquisitionsToDelete.Any())
            {
                var tdrTransactionLandBankAcquisitionIDList = tdrTransactionLandBankAcquisitionsToDelete.Select(x => x.TdrTransactionLandBankAcquisitionID).ToList();
                tdrTransactionLandBankAcquisitions.Where(x => tdrTransactionLandBankAcquisitionIDList.Contains(x.TdrTransactionLandBankAcquisitionID)).Delete();
            }
        }

        public static void DeleteTdrTransactionLandBankAcquisition(this IQueryable<TdrTransactionLandBankAcquisition> tdrTransactionLandBankAcquisitions, int tdrTransactionLandBankAcquisitionID)
        {
            DeleteTdrTransactionLandBankAcquisition(tdrTransactionLandBankAcquisitions, new List<int> { tdrTransactionLandBankAcquisitionID });
        }

        public static void DeleteTdrTransactionLandBankAcquisition(this IQueryable<TdrTransactionLandBankAcquisition> tdrTransactionLandBankAcquisitions, TdrTransactionLandBankAcquisition tdrTransactionLandBankAcquisitionToDelete)
        {
            DeleteTdrTransactionLandBankAcquisition(tdrTransactionLandBankAcquisitions, new List<TdrTransactionLandBankAcquisition> { tdrTransactionLandBankAcquisitionToDelete });
        }
    }
}