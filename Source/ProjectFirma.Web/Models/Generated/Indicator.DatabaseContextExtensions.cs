//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Indicator]
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
        public static Indicator GetIndicator(this IQueryable<Indicator> indicators, int indicatorID)
        {
            var indicator = indicators.SingleOrDefault(x => x.IndicatorID == indicatorID);
            Check.RequireNotNullThrowNotFound(indicator, "Indicator", indicatorID);
            return indicator;
        }

        public static void DeleteIndicator(this IQueryable<Indicator> indicators, List<int> indicatorIDList)
        {
            if(indicatorIDList.Any())
            {
                indicators.Where(x => indicatorIDList.Contains(x.IndicatorID)).Delete();
            }
        }

        public static void DeleteIndicator(this IQueryable<Indicator> indicators, ICollection<Indicator> indicatorsToDelete)
        {
            if(indicatorsToDelete.Any())
            {
                var indicatorIDList = indicatorsToDelete.Select(x => x.IndicatorID).ToList();
                indicators.Where(x => indicatorIDList.Contains(x.IndicatorID)).Delete();
            }
        }

        public static void DeleteIndicator(this IQueryable<Indicator> indicators, int indicatorID)
        {
            DeleteIndicator(indicators, new List<int> { indicatorID });
        }

        public static void DeleteIndicator(this IQueryable<Indicator> indicators, Indicator indicatorToDelete)
        {
            DeleteIndicator(indicators, new List<Indicator> { indicatorToDelete });
        }
    }
}