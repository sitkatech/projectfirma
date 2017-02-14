//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SnapshotPerformanceMeasure GetSnapshotPerformanceMeasure(this IQueryable<SnapshotPerformanceMeasure> snapshotPerformanceMeasures, int snapshotPerformanceMeasureID)
        {
            var snapshotPerformanceMeasure = snapshotPerformanceMeasures.SingleOrDefault(x => x.SnapshotPerformanceMeasureID == snapshotPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(snapshotPerformanceMeasure, "SnapshotPerformanceMeasure", snapshotPerformanceMeasureID);
            return snapshotPerformanceMeasure;
        }

        public static void DeleteSnapshotPerformanceMeasure(this List<int> snapshotPerformanceMeasureIDList)
        {
            if(snapshotPerformanceMeasureIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotPerformanceMeasures.RemoveRange(HttpRequestStorage.DatabaseEntities.SnapshotPerformanceMeasures.Where(x => snapshotPerformanceMeasureIDList.Contains(x.SnapshotPerformanceMeasureID)));
            }
        }

        public static void DeleteSnapshotPerformanceMeasure(this ICollection<SnapshotPerformanceMeasure> snapshotPerformanceMeasuresToDelete)
        {
            if(snapshotPerformanceMeasuresToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotPerformanceMeasures.RemoveRange(snapshotPerformanceMeasuresToDelete);
            }
        }

        public static void DeleteSnapshotPerformanceMeasure(this int snapshotPerformanceMeasureID)
        {
            DeleteSnapshotPerformanceMeasure(new List<int> { snapshotPerformanceMeasureID });
        }

        public static void DeleteSnapshotPerformanceMeasure(this SnapshotPerformanceMeasure snapshotPerformanceMeasureToDelete)
        {
            DeleteSnapshotPerformanceMeasure(new List<SnapshotPerformanceMeasure> { snapshotPerformanceMeasureToDelete });
        }
    }
}