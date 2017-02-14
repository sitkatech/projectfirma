//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotSectorExpenditure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

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

        public static void DeleteSnapshotSectorExpenditure(this List<int> snapshotSectorExpenditureIDList)
        {
            if(snapshotSectorExpenditureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotSectorExpenditures.RemoveRange(HttpRequestStorage.DatabaseEntities.SnapshotSectorExpenditures.Where(x => snapshotSectorExpenditureIDList.Contains(x.SnapshotSectorExpenditureID)));
            }
        }

        public static void DeleteSnapshotSectorExpenditure(this ICollection<SnapshotSectorExpenditure> snapshotSectorExpendituresToDelete)
        {
            if(snapshotSectorExpendituresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotSectorExpenditures.RemoveRange(snapshotSectorExpendituresToDelete);
            }
        }

        public static void DeleteSnapshotSectorExpenditure(this int snapshotSectorExpenditureID)
        {
            DeleteSnapshotSectorExpenditure(new List<int> { snapshotSectorExpenditureID });
        }

        public static void DeleteSnapshotSectorExpenditure(this SnapshotSectorExpenditure snapshotSectorExpenditureToDelete)
        {
            DeleteSnapshotSectorExpenditure(new List<SnapshotSectorExpenditure> { snapshotSectorExpenditureToDelete });
        }
    }
}