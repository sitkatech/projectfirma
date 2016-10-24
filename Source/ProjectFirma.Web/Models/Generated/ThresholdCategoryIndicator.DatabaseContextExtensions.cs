//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategoryIndicator]
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
        public static ThresholdCategoryIndicator GetThresholdCategoryIndicator(this IQueryable<ThresholdCategoryIndicator> thresholdCategoryIndicators, int thresholdCategoryIndicatorID)
        {
            var thresholdCategoryIndicator = thresholdCategoryIndicators.SingleOrDefault(x => x.ThresholdCategoryIndicatorID == thresholdCategoryIndicatorID);
            Check.RequireNotNullThrowNotFound(thresholdCategoryIndicator, "ThresholdCategoryIndicator", thresholdCategoryIndicatorID);
            return thresholdCategoryIndicator;
        }

        public static void DeleteThresholdCategoryIndicator(this IQueryable<ThresholdCategoryIndicator> thresholdCategoryIndicators, List<int> thresholdCategoryIndicatorIDList)
        {
            if(thresholdCategoryIndicatorIDList.Any())
            {
                thresholdCategoryIndicators.Where(x => thresholdCategoryIndicatorIDList.Contains(x.ThresholdCategoryIndicatorID)).Delete();
            }
        }

        public static void DeleteThresholdCategoryIndicator(this IQueryable<ThresholdCategoryIndicator> thresholdCategoryIndicators, ICollection<ThresholdCategoryIndicator> thresholdCategoryIndicatorsToDelete)
        {
            if(thresholdCategoryIndicatorsToDelete.Any())
            {
                var thresholdCategoryIndicatorIDList = thresholdCategoryIndicatorsToDelete.Select(x => x.ThresholdCategoryIndicatorID).ToList();
                thresholdCategoryIndicators.Where(x => thresholdCategoryIndicatorIDList.Contains(x.ThresholdCategoryIndicatorID)).Delete();
            }
        }

        public static void DeleteThresholdCategoryIndicator(this IQueryable<ThresholdCategoryIndicator> thresholdCategoryIndicators, int thresholdCategoryIndicatorID)
        {
            DeleteThresholdCategoryIndicator(thresholdCategoryIndicators, new List<int> { thresholdCategoryIndicatorID });
        }

        public static void DeleteThresholdCategoryIndicator(this IQueryable<ThresholdCategoryIndicator> thresholdCategoryIndicators, ThresholdCategoryIndicator thresholdCategoryIndicatorToDelete)
        {
            DeleteThresholdCategoryIndicator(thresholdCategoryIndicators, new List<ThresholdCategoryIndicator> { thresholdCategoryIndicatorToDelete });
        }
    }
}