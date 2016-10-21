//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]
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
        public static SnapshotEIPPerformanceMeasureSubcategoryOption GetSnapshotEIPPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotEIPPerformanceMeasureSubcategoryOption> snapshotEIPPerformanceMeasureSubcategoryOptions, int snapshotEIPPerformanceMeasureSubcategoryOptionID)
        {
            var snapshotEIPPerformanceMeasureSubcategoryOption = snapshotEIPPerformanceMeasureSubcategoryOptions.SingleOrDefault(x => x.SnapshotEIPPerformanceMeasureSubcategoryOptionID == snapshotEIPPerformanceMeasureSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(snapshotEIPPerformanceMeasureSubcategoryOption, "SnapshotEIPPerformanceMeasureSubcategoryOption", snapshotEIPPerformanceMeasureSubcategoryOptionID);
            return snapshotEIPPerformanceMeasureSubcategoryOption;
        }

        public static void DeleteSnapshotEIPPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotEIPPerformanceMeasureSubcategoryOption> snapshotEIPPerformanceMeasureSubcategoryOptions, List<int> snapshotEIPPerformanceMeasureSubcategoryOptionIDList)
        {
            if(snapshotEIPPerformanceMeasureSubcategoryOptionIDList.Any())
            {
                snapshotEIPPerformanceMeasureSubcategoryOptions.Where(x => snapshotEIPPerformanceMeasureSubcategoryOptionIDList.Contains(x.SnapshotEIPPerformanceMeasureSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteSnapshotEIPPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotEIPPerformanceMeasureSubcategoryOption> snapshotEIPPerformanceMeasureSubcategoryOptions, ICollection<SnapshotEIPPerformanceMeasureSubcategoryOption> snapshotEIPPerformanceMeasureSubcategoryOptionsToDelete)
        {
            if(snapshotEIPPerformanceMeasureSubcategoryOptionsToDelete.Any())
            {
                var snapshotEIPPerformanceMeasureSubcategoryOptionIDList = snapshotEIPPerformanceMeasureSubcategoryOptionsToDelete.Select(x => x.SnapshotEIPPerformanceMeasureSubcategoryOptionID).ToList();
                snapshotEIPPerformanceMeasureSubcategoryOptions.Where(x => snapshotEIPPerformanceMeasureSubcategoryOptionIDList.Contains(x.SnapshotEIPPerformanceMeasureSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteSnapshotEIPPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotEIPPerformanceMeasureSubcategoryOption> snapshotEIPPerformanceMeasureSubcategoryOptions, int snapshotEIPPerformanceMeasureSubcategoryOptionID)
        {
            DeleteSnapshotEIPPerformanceMeasureSubcategoryOption(snapshotEIPPerformanceMeasureSubcategoryOptions, new List<int> { snapshotEIPPerformanceMeasureSubcategoryOptionID });
        }

        public static void DeleteSnapshotEIPPerformanceMeasureSubcategoryOption(this IQueryable<SnapshotEIPPerformanceMeasureSubcategoryOption> snapshotEIPPerformanceMeasureSubcategoryOptions, SnapshotEIPPerformanceMeasureSubcategoryOption snapshotEIPPerformanceMeasureSubcategoryOptionToDelete)
        {
            DeleteSnapshotEIPPerformanceMeasureSubcategoryOption(snapshotEIPPerformanceMeasureSubcategoryOptions, new List<SnapshotEIPPerformanceMeasureSubcategoryOption> { snapshotEIPPerformanceMeasureSubcategoryOptionToDelete });
        }
    }
}