//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionTransferWithBonusUnit]
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
        public static TdrTransactionTransferWithBonusUnit GetTdrTransactionTransferWithBonusUnit(this IQueryable<TdrTransactionTransferWithBonusUnit> tdrTransactionTransferWithBonusUnits, int tdrTransactionTransferWithBonusUnitID)
        {
            var tdrTransactionTransferWithBonusUnit = tdrTransactionTransferWithBonusUnits.SingleOrDefault(x => x.TdrTransactionTransferWithBonusUnitID == tdrTransactionTransferWithBonusUnitID);
            Check.RequireNotNullThrowNotFound(tdrTransactionTransferWithBonusUnit, "TdrTransactionTransferWithBonusUnit", tdrTransactionTransferWithBonusUnitID);
            return tdrTransactionTransferWithBonusUnit;
        }

        public static void DeleteTdrTransactionTransferWithBonusUnit(this IQueryable<TdrTransactionTransferWithBonusUnit> tdrTransactionTransferWithBonusUnits, List<int> tdrTransactionTransferWithBonusUnitIDList)
        {
            if(tdrTransactionTransferWithBonusUnitIDList.Any())
            {
                tdrTransactionTransferWithBonusUnits.Where(x => tdrTransactionTransferWithBonusUnitIDList.Contains(x.TdrTransactionTransferWithBonusUnitID)).Delete();
            }
        }

        public static void DeleteTdrTransactionTransferWithBonusUnit(this IQueryable<TdrTransactionTransferWithBonusUnit> tdrTransactionTransferWithBonusUnits, ICollection<TdrTransactionTransferWithBonusUnit> tdrTransactionTransferWithBonusUnitsToDelete)
        {
            if(tdrTransactionTransferWithBonusUnitsToDelete.Any())
            {
                var tdrTransactionTransferWithBonusUnitIDList = tdrTransactionTransferWithBonusUnitsToDelete.Select(x => x.TdrTransactionTransferWithBonusUnitID).ToList();
                tdrTransactionTransferWithBonusUnits.Where(x => tdrTransactionTransferWithBonusUnitIDList.Contains(x.TdrTransactionTransferWithBonusUnitID)).Delete();
            }
        }

        public static void DeleteTdrTransactionTransferWithBonusUnit(this IQueryable<TdrTransactionTransferWithBonusUnit> tdrTransactionTransferWithBonusUnits, int tdrTransactionTransferWithBonusUnitID)
        {
            DeleteTdrTransactionTransferWithBonusUnit(tdrTransactionTransferWithBonusUnits, new List<int> { tdrTransactionTransferWithBonusUnitID });
        }

        public static void DeleteTdrTransactionTransferWithBonusUnit(this IQueryable<TdrTransactionTransferWithBonusUnit> tdrTransactionTransferWithBonusUnits, TdrTransactionTransferWithBonusUnit tdrTransactionTransferWithBonusUnitToDelete)
        {
            DeleteTdrTransactionTransferWithBonusUnit(tdrTransactionTransferWithBonusUnits, new List<TdrTransactionTransferWithBonusUnit> { tdrTransactionTransferWithBonusUnitToDelete });
        }
    }
}