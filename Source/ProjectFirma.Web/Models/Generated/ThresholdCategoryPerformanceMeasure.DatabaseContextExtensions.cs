//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategoryPerformanceMeasure]
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
        public static ThresholdCategoryPerformanceMeasure GetThresholdCategoryPerformanceMeasure(this IQueryable<ThresholdCategoryPerformanceMeasure> thresholdCategoryPerformanceMeasures, int thresholdCategoryPerformanceMeasureID)
        {
            var thresholdCategoryPerformanceMeasure = thresholdCategoryPerformanceMeasures.SingleOrDefault(x => x.ThresholdCategoryPerformanceMeasureID == thresholdCategoryPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(thresholdCategoryPerformanceMeasure, "ThresholdCategoryPerformanceMeasure", thresholdCategoryPerformanceMeasureID);
            return thresholdCategoryPerformanceMeasure;
        }

        public static void DeleteThresholdCategoryPerformanceMeasure(this IQueryable<ThresholdCategoryPerformanceMeasure> thresholdCategoryPerformanceMeasures, List<int> thresholdCategoryPerformanceMeasureIDList)
        {
            if(thresholdCategoryPerformanceMeasureIDList.Any())
            {
                thresholdCategoryPerformanceMeasures.Where(x => thresholdCategoryPerformanceMeasureIDList.Contains(x.ThresholdCategoryPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteThresholdCategoryPerformanceMeasure(this IQueryable<ThresholdCategoryPerformanceMeasure> thresholdCategoryPerformanceMeasures, ICollection<ThresholdCategoryPerformanceMeasure> thresholdCategoryPerformanceMeasuresToDelete)
        {
            if(thresholdCategoryPerformanceMeasuresToDelete.Any())
            {
                var thresholdCategoryPerformanceMeasureIDList = thresholdCategoryPerformanceMeasuresToDelete.Select(x => x.ThresholdCategoryPerformanceMeasureID).ToList();
                thresholdCategoryPerformanceMeasures.Where(x => thresholdCategoryPerformanceMeasureIDList.Contains(x.ThresholdCategoryPerformanceMeasureID)).Delete();
            }
        }

        public static void DeleteThresholdCategoryPerformanceMeasure(this IQueryable<ThresholdCategoryPerformanceMeasure> thresholdCategoryPerformanceMeasures, int thresholdCategoryPerformanceMeasureID)
        {
            DeleteThresholdCategoryPerformanceMeasure(thresholdCategoryPerformanceMeasures, new List<int> { thresholdCategoryPerformanceMeasureID });
        }

        public static void DeleteThresholdCategoryPerformanceMeasure(this IQueryable<ThresholdCategoryPerformanceMeasure> thresholdCategoryPerformanceMeasures, ThresholdCategoryPerformanceMeasure thresholdCategoryPerformanceMeasureToDelete)
        {
            DeleteThresholdCategoryPerformanceMeasure(thresholdCategoryPerformanceMeasures, new List<ThresholdCategoryPerformanceMeasure> { thresholdCategoryPerformanceMeasureToDelete });
        }
    }
}