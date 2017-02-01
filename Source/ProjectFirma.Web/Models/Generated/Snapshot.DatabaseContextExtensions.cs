//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Snapshot]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteSnapshot(this IQueryable<Snapshot> snapshots, List<int> snapshotIDList)
        {
            if(snapshotIDList.Any())
            {
                snapshots.Where(x => snapshotIDList.Contains(x.SnapshotID)).Delete();
            }
        }

        public static void DeleteSnapshot(this IQueryable<Snapshot> snapshots, ICollection<Snapshot> snapshotsToDelete)
        {
            if(snapshotsToDelete.Any())
            {
                var snapshotIDList = snapshotsToDelete.Select(x => x.SnapshotID).ToList();
                snapshots.Where(x => snapshotIDList.Contains(x.SnapshotID)).Delete();
            }
        }

        public static void DeleteSnapshot(this IQueryable<Snapshot> snapshots, int snapshotID)
        {
            DeleteSnapshot(snapshots, new List<int> { snapshotID });
        }

        public static void DeleteSnapshot(this IQueryable<Snapshot> snapshots, Snapshot snapshotToDelete)
        {
            DeleteSnapshot(snapshots, new List<Snapshot> { snapshotToDelete });
        }
    }
}