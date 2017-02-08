//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasureSubcategoryOption]
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
        public static SnapshotPerformanceMeasureSubcategoryOption GetSnapshotPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptions, int snapshotPerformanceMeasureSubcategoryOptionID)
        {
            var snapshotPerformanceMeasureSubcategoryOption = snapshotPerformanceMeasureSubcategoryOptions.SingleOrDefault(x => x.SnapshotPerformanceMeasureSubcategoryOptionID == snapshotPerformanceMeasureSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(snapshotPerformanceMeasureSubcategoryOption, "SnapshotPerformanceMeasureSubcategoryOption", snapshotPerformanceMeasureSubcategoryOptionID);
            return snapshotPerformanceMeasureSubcategoryOption;
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptions, List<int> snapshotPerformanceMeasureSubcategoryOptionIDList)
        {
            if(snapshotPerformanceMeasureSubcategoryOptionIDList.Any())
            {
                snapshotPerformanceMeasureSubcategoryOptions.Where(x => snapshotPerformanceMeasureSubcategoryOptionIDList.Contains(x.SnapshotPerformanceMeasureSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptions, ICollection<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptionsToDelete)
        {
            if(snapshotPerformanceMeasureSubcategoryOptionsToDelete.Any())
            {
                var snapshotPerformanceMeasureSubcategoryOptionIDList = snapshotPerformanceMeasureSubcategoryOptionsToDelete.Select(x => x.SnapshotPerformanceMeasureSubcategoryOptionID).ToList();
                snapshotPerformanceMeasureSubcategoryOptions.Where(x => snapshotPerformanceMeasureSubcategoryOptionIDList.Contains(x.SnapshotPerformanceMeasureSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptions, int snapshotPerformanceMeasureSubcategoryOptionID)
        {
            DeleteSnapshotPerformanceMeasureSubcategoryOption(snapshotPerformanceMeasureSubcategoryOptions, new List<int> { snapshotPerformanceMeasureSubcategoryOptionID });
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptions, SnapshotPerformanceMeasureSubcategoryOption snapshotPerformanceMeasureSubcategoryOptionToDelete)
        {
            DeleteSnapshotPerformanceMeasureSubcategoryOption(snapshotPerformanceMeasureSubcategoryOptions, new List<SnapshotPerformanceMeasureSubcategoryOption> { snapshotPerformanceMeasureSubcategoryOptionToDelete });
        }
    }
}