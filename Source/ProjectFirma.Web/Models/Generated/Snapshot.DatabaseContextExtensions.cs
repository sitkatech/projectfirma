//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Snapshot]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Snapshot GetSnapshot(this IQueryable<Snapshot> snapshots, int snapshotID)
        {
            var snapshot = snapshots.SingleOrDefault(x => x.SnapshotID == snapshotID);
            Check.RequireNotNullThrowNotFound(snapshot, "Snapshot", snapshotID);
            return snapshot;
        }

        public static void DeleteSnapshot(this List<int> snapshotIDList)
        {
            if(snapshotIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshots.RemoveRange(HttpRequestStorage.DatabaseEntities.Snapshots.Where(x => snapshotIDList.Contains(x.SnapshotID)));
            }
        }

        public static void DeleteSnapshot(this ICollection<Snapshot> snapshotsToDelete)
        {
            if(snapshotsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshots.RemoveRange(snapshotsToDelete);
            }
        }

        public static void DeleteSnapshot(this int snapshotID)
        {
            DeleteSnapshot(new List<int> { snapshotID });
        }

        public static void DeleteSnapshot(this Snapshot snapshotToDelete)
        {
            DeleteSnapshot(new List<Snapshot> { snapshotToDelete });
        }
    }
}