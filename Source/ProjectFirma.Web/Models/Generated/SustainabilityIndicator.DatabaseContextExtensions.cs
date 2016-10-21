//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityIndicator]
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
        public static SustainabilityIndicator GetSustainabilityIndicator(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, int sustainabilityIndicatorID)
        {
            var sustainabilityIndicator = sustainabilityIndicators.SingleOrDefault(x => x.SustainabilityIndicatorID == sustainabilityIndicatorID);
            Check.RequireNotNullThrowNotFound(sustainabilityIndicator, "SustainabilityIndicator", sustainabilityIndicatorID);
            return sustainabilityIndicator;
        }

        public static void DeleteSustainabilityIndicator(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, List<int> sustainabilityIndicatorIDList)
        {
            if(sustainabilityIndicatorIDList.Any())
            {
                sustainabilityIndicators.Where(x => sustainabilityIndicatorIDList.Contains(x.SustainabilityIndicatorID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicator(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, ICollection<SustainabilityIndicator> sustainabilityIndicatorsToDelete)
        {
            if(sustainabilityIndicatorsToDelete.Any())
            {
                var sustainabilityIndicatorIDList = sustainabilityIndicatorsToDelete.Select(x => x.SustainabilityIndicatorID).ToList();
                sustainabilityIndicators.Where(x => sustainabilityIndicatorIDList.Contains(x.SustainabilityIndicatorID)).Delete();
            }
        }

        public static void DeleteSustainabilityIndicator(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, int sustainabilityIndicatorID)
        {
            DeleteSustainabilityIndicator(sustainabilityIndicators, new List<int> { sustainabilityIndicatorID });
        }

        public static void DeleteSustainabilityIndicator(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, SustainabilityIndicator sustainabilityIndicatorToDelete)
        {
            DeleteSustainabilityIndicator(sustainabilityIndicators, new List<SustainabilityIndicator> { sustainabilityIndicatorToDelete });
        }
    }
}