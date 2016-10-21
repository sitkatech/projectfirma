//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicatorReportingPeriod]
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
        public static SustainabilityIndicatorReportingPeriod GetSustainabilityIndicatorReportingPeriod(this IQueryable<SustainabilityIndicatorReportingPeriod> sustainabilityIndicatorReportingPeriods, int sustainabilityIndicatorReportingPeriodID)
        {
            var sustainabilityIndicatorReportingPeriod = sustainabilityIndicatorReportingPeriods.SingleOrDefault(x => x.SustainabilityIndicatorReportingPeriodID == sustainabilityIndicatorReportingPeriodID);
            Check.RequireNotNullThrowNotFound(sustainabilityIndicatorReportingPeriod, "SustainabilityIndicatorReportingPeriod", sustainabilityIndicatorReportingPeriodID);
            return sustainabilityIndicatorReportingPeriod;
        }

        public static void DeleteSustainabilityIndicatorReportingPeriod(this IQueryable<SustainabilityIndicatorReportingPeriod> sustainabilityIndicatorReportingPeriods, List<int> sustainabilityIndicatorReportingPeriodIDList)
        {
            if(sustainabilityIndicatorReportingPeriodIDList.Any())
            {
                sustainabilityIndicatorReportingPeriods.Where(x => sustainabilityIndicatorReportingPeriodIDList.Contains(x.SustainabilityIndicatorReportingPeriodID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicatorReportingPeriod(this IQueryable<SustainabilityIndicatorReportingPeriod> sustainabilityIndicatorReportingPeriods, ICollection<SustainabilityIndicatorReportingPeriod> sustainabilityIndicatorReportingPeriodsToDelete)
        {
            if(sustainabilityIndicatorReportingPeriodsToDelete.Any())
            {
                var sustainabilityIndicatorReportingPeriodIDList = sustainabilityIndicatorReportingPeriodsToDelete.Select(x => x.SustainabilityIndicatorReportingPeriodID).ToList();
                sustainabilityIndicatorReportingPeriods.Where(x => sustainabilityIndicatorReportingPeriodIDList.Contains(x.SustainabilityIndicatorReportingPeriodID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicatorReportingPeriod(this IQueryable<SustainabilityIndicatorReportingPeriod> sustainabilityIndicatorReportingPeriods, int sustainabilityIndicatorReportingPeriodID)
        {
            DeleteSustainabilityIndicatorReportingPeriod(sustainabilityIndicatorReportingPeriods, new List<int> { sustainabilityIndicatorReportingPeriodID });
        }

        public static void DeleteSustainabilityIndicatorReportingPeriod(this IQueryable<SustainabilityIndicatorReportingPeriod> sustainabilityIndicatorReportingPeriods, SustainabilityIndicatorReportingPeriod sustainabilityIndicatorReportingPeriodToDelete)
        {
            DeleteSustainabilityIndicatorReportingPeriod(sustainabilityIndicatorReportingPeriods, new List<SustainabilityIndicatorReportingPeriod> { sustainabilityIndicatorReportingPeriodToDelete });
        }
    }
}