//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicatorReportedSubcategoryOption]
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
        public static SustainabilityIndicatorReportedSubcategoryOption GetSustainabilityIndicatorReportedSubcategoryOption(this IQueryable<SustainabilityIndicatorReportedSubcategoryOption> sustainabilityIndicatorReportedSubcategoryOptions, int sustainabilityIndicatorReportedSubcategoryOptionID)
        {
            var sustainabilityIndicatorReportedSubcategoryOption = sustainabilityIndicatorReportedSubcategoryOptions.SingleOrDefault(x => x.SustainabilityIndicatorReportedSubcategoryOptionID == sustainabilityIndicatorReportedSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(sustainabilityIndicatorReportedSubcategoryOption, "SustainabilityIndicatorReportedSubcategoryOption", sustainabilityIndicatorReportedSubcategoryOptionID);
            return sustainabilityIndicatorReportedSubcategoryOption;
        }

        public static void DeleteSustainabilityIndicatorReportedSubcategoryOption(this IQueryable<SustainabilityIndicatorReportedSubcategoryOption> sustainabilityIndicatorReportedSubcategoryOptions, List<int> sustainabilityIndicatorReportedSubcategoryOptionIDList)
        {
            if(sustainabilityIndicatorReportedSubcategoryOptionIDList.Any())
            {
                sustainabilityIndicatorReportedSubcategoryOptions.Where(x => sustainabilityIndicatorReportedSubcategoryOptionIDList.Contains(x.SustainabilityIndicatorReportedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicatorReportedSubcategoryOption(this IQueryable<SustainabilityIndicatorReportedSubcategoryOption> sustainabilityIndicatorReportedSubcategoryOptions, ICollection<SustainabilityIndicatorReportedSubcategoryOption> sustainabilityIndicatorReportedSubcategoryOptionsToDelete)
        {
            if(sustainabilityIndicatorReportedSubcategoryOptionsToDelete.Any())
            {
                var sustainabilityIndicatorReportedSubcategoryOptionIDList = sustainabilityIndicatorReportedSubcategoryOptionsToDelete.Select(x => x.SustainabilityIndicatorReportedSubcategoryOptionID).ToList();
                sustainabilityIndicatorReportedSubcategoryOptions.Where(x => sustainabilityIndicatorReportedSubcategoryOptionIDList.Contains(x.SustainabilityIndicatorReportedSubcategoryOptionID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicatorReportedSubcategoryOption(this IQueryable<SustainabilityIndicatorReportedSubcategoryOption> sustainabilityIndicatorReportedSubcategoryOptions, int sustainabilityIndicatorReportedSubcategoryOptionID)
        {
            DeleteSustainabilityIndicatorReportedSubcategoryOption(sustainabilityIndicatorReportedSubcategoryOptions, new List<int> { sustainabilityIndicatorReportedSubcategoryOptionID });
        }

        public static void DeleteSustainabilityIndicatorReportedSubcategoryOption(this IQueryable<SustainabilityIndicatorReportedSubcategoryOption> sustainabilityIndicatorReportedSubcategoryOptions, SustainabilityIndicatorReportedSubcategoryOption sustainabilityIndicatorReportedSubcategoryOptionToDelete)
        {
            DeleteSustainabilityIndicatorReportedSubcategoryOption(sustainabilityIndicatorReportedSubcategoryOptions, new List<SustainabilityIndicatorReportedSubcategoryOption> { sustainabilityIndicatorReportedSubcategoryOptionToDelete });
        }
    }
}