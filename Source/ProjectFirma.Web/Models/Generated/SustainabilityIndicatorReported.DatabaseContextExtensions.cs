//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicatorReported]
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
        public static SustainabilityIndicatorReported GetSustainabilityIndicatorReported(this IQueryable<SustainabilityIndicatorReported> sustainabilityIndicatorReporteds, int sustainabilityIndicatorReportedID)
        {
            var sustainabilityIndicatorReported = sustainabilityIndicatorReporteds.SingleOrDefault(x => x.SustainabilityIndicatorReportedID == sustainabilityIndicatorReportedID);
            Check.RequireNotNullThrowNotFound(sustainabilityIndicatorReported, "SustainabilityIndicatorReported", sustainabilityIndicatorReportedID);
            return sustainabilityIndicatorReported;
        }

        public static void DeleteSustainabilityIndicatorReported(this IQueryable<SustainabilityIndicatorReported> sustainabilityIndicatorReporteds, List<int> sustainabilityIndicatorReportedIDList)
        {
            if(sustainabilityIndicatorReportedIDList.Any())
            {
                sustainabilityIndicatorReporteds.Where(x => sustainabilityIndicatorReportedIDList.Contains(x.SustainabilityIndicatorReportedID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicatorReported(this IQueryable<SustainabilityIndicatorReported> sustainabilityIndicatorReporteds, ICollection<SustainabilityIndicatorReported> sustainabilityIndicatorReportedsToDelete)
        {
            if(sustainabilityIndicatorReportedsToDelete.Any())
            {
                var sustainabilityIndicatorReportedIDList = sustainabilityIndicatorReportedsToDelete.Select(x => x.SustainabilityIndicatorReportedID).ToList();
                sustainabilityIndicatorReporteds.Where(x => sustainabilityIndicatorReportedIDList.Contains(x.SustainabilityIndicatorReportedID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicatorReported(this IQueryable<SustainabilityIndicatorReported> sustainabilityIndicatorReporteds, int sustainabilityIndicatorReportedID)
        {
            DeleteSustainabilityIndicatorReported(sustainabilityIndicatorReporteds, new List<int> { sustainabilityIndicatorReportedID });
        }

        public static void DeleteSustainabilityIndicatorReported(this IQueryable<SustainabilityIndicatorReported> sustainabilityIndicatorReporteds, SustainabilityIndicatorReported sustainabilityIndicatorReportedToDelete)
        {
            DeleteSustainabilityIndicatorReported(sustainabilityIndicatorReporteds, new List<SustainabilityIndicatorReported> { sustainabilityIndicatorReportedToDelete });
        }
    }
}