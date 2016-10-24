//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorReported]
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
        public static ThresholdIndicatorReported GetThresholdIndicatorReported(this IQueryable<ThresholdIndicatorReported> thresholdIndicatorReporteds, int thresholdIndicatorReportedID)
        {
            var thresholdIndicatorReported = thresholdIndicatorReporteds.SingleOrDefault(x => x.ThresholdIndicatorReportedID == thresholdIndicatorReportedID);
            Check.RequireNotNullThrowNotFound(thresholdIndicatorReported, "ThresholdIndicatorReported", thresholdIndicatorReportedID);
            return thresholdIndicatorReported;
        }

        public static void DeleteThresholdIndicatorReported(this IQueryable<ThresholdIndicatorReported> thresholdIndicatorReporteds, List<int> thresholdIndicatorReportedIDList)
        {
            if(thresholdIndicatorReportedIDList.Any())
            {
                thresholdIndicatorReporteds.Where(x => thresholdIndicatorReportedIDList.Contains(x.ThresholdIndicatorReportedID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorReported(this IQueryable<ThresholdIndicatorReported> thresholdIndicatorReporteds, ICollection<ThresholdIndicatorReported> thresholdIndicatorReportedsToDelete)
        {
            if(thresholdIndicatorReportedsToDelete.Any())
            {
                var thresholdIndicatorReportedIDList = thresholdIndicatorReportedsToDelete.Select(x => x.ThresholdIndicatorReportedID).ToList();
                thresholdIndicatorReporteds.Where(x => thresholdIndicatorReportedIDList.Contains(x.ThresholdIndicatorReportedID)).Delete();
            }
        }

        public static void DeleteThresholdIndicatorReported(this IQueryable<ThresholdIndicatorReported> thresholdIndicatorReporteds, int thresholdIndicatorReportedID)
        {
            DeleteThresholdIndicatorReported(thresholdIndicatorReporteds, new List<int> { thresholdIndicatorReportedID });
        }

        public static void DeleteThresholdIndicatorReported(this IQueryable<ThresholdIndicatorReported> thresholdIndicatorReporteds, ThresholdIndicatorReported thresholdIndicatorReportedToDelete)
        {
            DeleteThresholdIndicatorReported(thresholdIndicatorReporteds, new List<ThresholdIndicatorReported> { thresholdIndicatorReportedToDelete });
        }
    }
}