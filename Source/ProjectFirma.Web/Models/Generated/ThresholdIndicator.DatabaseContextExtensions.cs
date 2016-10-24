//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicator]
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
        public static ThresholdIndicator GetThresholdIndicator(this IQueryable<ThresholdIndicator> thresholdIndicators, int thresholdIndicatorID)
        {
            var thresholdIndicator = thresholdIndicators.SingleOrDefault(x => x.ThresholdIndicatorID == thresholdIndicatorID);
            Check.RequireNotNullThrowNotFound(thresholdIndicator, "ThresholdIndicator", thresholdIndicatorID);
            return thresholdIndicator;
        }

        public static void DeleteThresholdIndicator(this IQueryable<ThresholdIndicator> thresholdIndicators, List<int> thresholdIndicatorIDList)
        {
            if(thresholdIndicatorIDList.Any())
            {
                thresholdIndicators.Where(x => thresholdIndicatorIDList.Contains(x.ThresholdIndicatorID)).Delete();
            }
        }

        public static void DeleteThresholdIndicator(this IQueryable<ThresholdIndicator> thresholdIndicators, ICollection<ThresholdIndicator> thresholdIndicatorsToDelete)
        {
            if(thresholdIndicatorsToDelete.Any())
            {
                var thresholdIndicatorIDList = thresholdIndicatorsToDelete.Select(x => x.ThresholdIndicatorID).ToList();
                thresholdIndicators.Where(x => thresholdIndicatorIDList.Contains(x.ThresholdIndicatorID)).Delete();
            }
        }

        public static void DeleteThresholdIndicator(this IQueryable<ThresholdIndicator> thresholdIndicators, int thresholdIndicatorID)
        {
            DeleteThresholdIndicator(thresholdIndicators, new List<int> { thresholdIndicatorID });
        }

        public static void DeleteThresholdIndicator(this IQueryable<ThresholdIndicator> thresholdIndicators, ThresholdIndicator thresholdIndicatorToDelete)
        {
            DeleteThresholdIndicator(thresholdIndicators, new List<ThresholdIndicator> { thresholdIndicatorToDelete });
        }
    }
}