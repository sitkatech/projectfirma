//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteSnapshotPerformanceMeasure(this IQueryable<SnapshotPerformanceMeasure> snapshotPerformanceMeasures, List<int> snapshotPerformanceMeasureIDList)
        {
            if(snapshotPerformanceMeasureIDList.Any())
            {
                snapshotPerformanceMeasures.Where(x => snapshotPerformanceMeasureIDList.Contains(x.SnapshotPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteSnapshotPerformanceMeasure(this IQueryable<SnapshotPerformanceMeasure> snapshotPerformanceMeasures, ICollection<SnapshotPerformanceMeasure> snapshotPerformanceMeasuresToDelete)
        {
            if(snapshotPerformanceMeasuresToDelete.Any())
            {
                var snapshotPerformanceMeasureIDList = snapshotPerformanceMeasuresToDelete.Select(x => x.SnapshotPerformanceMeasureID).ToList();
                snapshotPerformanceMeasures.Where(x => snapshotPerformanceMeasureIDList.Contains(x.SnapshotPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteSnapshotPerformanceMeasure(this IQueryable<SnapshotPerformanceMeasure> snapshotPerformanceMeasures, int snapshotPerformanceMeasureID)
        {
            DeleteSnapshotPerformanceMeasure(snapshotPerformanceMeasures, new List<int> { snapshotPerformanceMeasureID });
        }

        public static void DeleteSnapshotPerformanceMeasure(this IQueryable<SnapshotPerformanceMeasure> snapshotPerformanceMeasures, SnapshotPerformanceMeasure snapshotPerformanceMeasureToDelete)
        {
            DeleteSnapshotPerformanceMeasure(snapshotPerformanceMeasures, new List<SnapshotPerformanceMeasure> { snapshotPerformanceMeasureToDelete });
        }
    }
}