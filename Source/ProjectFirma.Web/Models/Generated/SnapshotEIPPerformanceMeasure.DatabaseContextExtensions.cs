//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotEIPPerformanceMeasure]
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
        public static SnapshotEIPPerformanceMeasure GetSnapshotEIPPerformanceMeasure(this IQueryable<SnapshotEIPPerformanceMeasure> snapshotEIPPerformanceMeasures, int snapshotEIPPerformanceMeasureID)
        {
            var snapshotEIPPerformanceMeasure = snapshotEIPPerformanceMeasures.SingleOrDefault(x => x.SnapshotEIPPerformanceMeasureID == snapshotEIPPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(snapshotEIPPerformanceMeasure, "SnapshotEIPPerformanceMeasure", snapshotEIPPerformanceMeasureID);
            return snapshotEIPPerformanceMeasure;
        }

        public static void DeleteSnapshotEIPPerformanceMeasure(this IQueryable<SnapshotEIPPerformanceMeasure> snapshotEIPPerformanceMeasures, List<int> snapshotEIPPerformanceMeasureIDList)
        {
            if(snapshotEIPPerformanceMeasureIDList.Any())
            {
                snapshotEIPPerformanceMeasures.Where(x => snapshotEIPPerformanceMeasureIDList.Contains(x.SnapshotEIPPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteSnapshotEIPPerformanceMeasure(this IQueryable<SnapshotEIPPerformanceMeasure> snapshotEIPPerformanceMeasures, ICollection<SnapshotEIPPerformanceMeasure> snapshotEIPPerformanceMeasuresToDelete)
        {
            if(snapshotEIPPerformanceMeasuresToDelete.Any())
            {
                var snapshotEIPPerformanceMeasureIDList = snapshotEIPPerformanceMeasuresToDelete.Select(x => x.SnapshotEIPPerformanceMeasureID).ToList();
                snapshotEIPPerformanceMeasures.Where(x => snapshotEIPPerformanceMeasureIDList.Contains(x.SnapshotEIPPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteSnapshotEIPPerformanceMeasure(this IQueryable<SnapshotEIPPerformanceMeasure> snapshotEIPPerformanceMeasures, int snapshotEIPPerformanceMeasureID)
        {
            DeleteSnapshotEIPPerformanceMeasure(snapshotEIPPerformanceMeasures, new List<int> { snapshotEIPPerformanceMeasureID });
        }

        public static void DeleteSnapshotEIPPerformanceMeasure(this IQueryable<SnapshotEIPPerformanceMeasure> snapshotEIPPerformanceMeasures, SnapshotEIPPerformanceMeasure snapshotEIPPerformanceMeasureToDelete)
        {
            DeleteSnapshotEIPPerformanceMeasure(snapshotEIPPerformanceMeasures, new List<SnapshotEIPPerformanceMeasure> { snapshotEIPPerformanceMeasureToDelete });
        }
    }
}