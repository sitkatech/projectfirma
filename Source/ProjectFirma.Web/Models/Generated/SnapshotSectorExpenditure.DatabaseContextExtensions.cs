//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotSectorExpenditure]
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
        public static SnapshotSectorExpenditure GetSnapshotSectorExpenditure(this IQueryable<SnapshotSectorExpenditure> snapshotSectorExpenditures, int snapshotSectorExpenditureID)
        {
            var snapshotSectorExpenditure = snapshotSectorExpenditures.SingleOrDefault(x => x.SnapshotSectorExpenditureID == snapshotSectorExpenditureID);
            Check.RequireNotNullThrowNotFound(snapshotSectorExpenditure, "SnapshotSectorExpenditure", snapshotSectorExpenditureID);
            return snapshotSectorExpenditure;
        }

        public static void DeleteSnapshotSectorExpenditure(this IQueryable<SnapshotSectorExpenditure> snapshotSectorExpenditures, List<int> snapshotSectorExpenditureIDList)
        {
            if(snapshotSectorExpenditureIDList.Any())
            {
                snapshotSectorExpenditures.Where(x => snapshotSectorExpenditureIDList.Contains(x.SnapshotSectorExpenditureID)).Delete();
            }
        }

        public static void DeleteSnapshotSectorExpenditure(this IQueryable<SnapshotSectorExpenditure> snapshotSectorExpenditures, ICollection<SnapshotSectorExpenditure> snapshotSectorExpendituresToDelete)
        {
            if(snapshotSectorExpendituresToDelete.Any())
            {
                var snapshotSectorExpenditureIDList = snapshotSectorExpendituresToDelete.Select(x => x.SnapshotSectorExpenditureID).ToList();
                snapshotSectorExpenditures.Where(x => snapshotSectorExpenditureIDList.Contains(x.SnapshotSectorExpenditureID)).Delete();
            }
        }

        public static void DeleteSnapshotSectorExpenditure(this IQueryable<SnapshotSectorExpenditure> snapshotSectorExpenditures, int snapshotSectorExpenditureID)
        {
            DeleteSnapshotSectorExpenditure(snapshotSectorExpenditures, new List<int> { snapshotSectorExpenditureID });
        }

        public static void DeleteSnapshotSectorExpenditure(this IQueryable<SnapshotSectorExpenditure> snapshotSectorExpenditures, SnapshotSectorExpenditure snapshotSectorExpenditureToDelete)
        {
            DeleteSnapshotSectorExpenditure(snapshotSectorExpenditures, new List<SnapshotSectorExpenditure> { snapshotSectorExpenditureToDelete });
        }
    }
}