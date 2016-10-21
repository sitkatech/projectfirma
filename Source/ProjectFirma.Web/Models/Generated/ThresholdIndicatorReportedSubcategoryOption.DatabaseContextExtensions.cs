//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorReportedSubcategoryOption]
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
        public static ThresholdIndicatorReportedSubcategoryOption GetThresholdIndicatorReportedSubcategoryOption(this IQueryable<ThresholdIndicatorReportedSubcategoryOption> thresholdIndicatorReportedSubcategoryOptions, int thresholdIndicatorReportedSubcategoryOptionID)
        {
            var thresholdIndicatorReportedSubcategoryOption = thresholdIndicatorReportedSubcategoryOptions.SingleOrDefault(x => x.ThresholdIndicatorReportedSubcategoryOptionID == thresholdIndicatorReportedSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(thresholdIndicatorReportedSubcategoryOption, "ThresholdIndicatorReportedSubcategoryOption", thresholdIndicatorReportedSubcategoryOptionID);
            return thresholdIndicatorReportedSubcategoryOption;
        }

        public static void DeleteThresholdIndicatorReportedSubcategoryOption(this IQueryable<ThresholdIndicatorReportedSubcategoryOption> thresholdIndicatorReportedSubcategoryOptions, List<int> thresholdIndicatorReportedSubcategoryOptionIDList)
        {
            if(thresholdIndicatorReportedSubcategoryOptionIDList.Any())
            {
                thresholdIndicatorReportedSubcategoryOptions.Where(x => thresholdIndicatorReportedSubcategoryOptionIDList.Contains(x.ThresholdIndicatorReportedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorReportedSubcategoryOption(this IQueryable<ThresholdIndicatorReportedSubcategoryOption> thresholdIndicatorReportedSubcategoryOptions, ICollection<ThresholdIndicatorReportedSubcategoryOption> thresholdIndicatorReportedSubcategoryOptionsToDelete)
        {
            if(thresholdIndicatorReportedSubcategoryOptionsToDelete.Any())
            {
                var thresholdIndicatorReportedSubcategoryOptionIDList = thresholdIndicatorReportedSubcategoryOptionsToDelete.Select(x => x.ThresholdIndicatorReportedSubcategoryOptionID).ToList();
                thresholdIndicatorReportedSubcategoryOptions.Where(x => thresholdIndicatorReportedSubcategoryOptionIDList.Contains(x.ThresholdIndicatorReportedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorReportedSubcategoryOption(this IQueryable<ThresholdIndicatorReportedSubcategoryOption> thresholdIndicatorReportedSubcategoryOptions, int thresholdIndicatorReportedSubcategoryOptionID)
        {
            DeleteThresholdIndicatorReportedSubcategoryOption(thresholdIndicatorReportedSubcategoryOptions, new List<int> { thresholdIndicatorReportedSubcategoryOptionID });
        }

        public static void DeleteThresholdIndicatorReportedSubcategoryOption(this IQueryable<ThresholdIndicatorReportedSubcategoryOption> thresholdIndicatorReportedSubcategoryOptions, ThresholdIndicatorReportedSubcategoryOption thresholdIndicatorReportedSubcategoryOptionToDelete)
        {
            DeleteThresholdIndicatorReportedSubcategoryOption(thresholdIndicatorReportedSubcategoryOptions, new List<ThresholdIndicatorReportedSubcategoryOption> { thresholdIndicatorReportedSubcategoryOptionToDelete });
        }
    }
}