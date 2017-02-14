//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotPerformanceMeasureSubcategoryOption]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this List<int> snapshotPerformanceMeasureSubcategoryOptionIDList)
        {
            if(snapshotPerformanceMeasureSubcategoryOptionIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotPerformanceMeasureSubcategoryOptions.RemoveRange(HttpRequestStorage.DatabaseEntities.SnapshotPerformanceMeasureSubcategoryOptions.Where(x => snapshotPerformanceMeasureSubcategoryOptionIDList.Contains(x.SnapshotPerformanceMeasureSubcategoryOptionID)));
            }
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this ICollection<SnapshotPerformanceMeasureSubcategoryOption> snapshotPerformanceMeasureSubcategoryOptionsToDelete)
        {
            if(snapshotPerformanceMeasureSubcategoryOptionsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSnapshotPerformanceMeasureSubcategoryOptions.RemoveRange(snapshotPerformanceMeasureSubcategoryOptionsToDelete);
            }
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this int snapshotPerformanceMeasureSubcategoryOptionID)
        {
            DeleteSnapshotPerformanceMeasureSubcategoryOption(new List<int> { snapshotPerformanceMeasureSubcategoryOptionID });
        }

        public static void DeleteSnapshotPerformanceMeasureSubcategoryOption(this SnapshotPerformanceMeasureSubcategoryOption snapshotPerformanceMeasureSubcategoryOptionToDelete)
        {
            DeleteSnapshotPerformanceMeasureSubcategoryOption(new List<SnapshotPerformanceMeasureSubcategoryOption> { snapshotPerformanceMeasureSubcategoryOptionToDelete });
        }
    }
}