using System;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SustainabilityIndicator GetSustainabilityIndicatorByName(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, string sustainabilityIndicatorName)
        {
            return GetSustainabilityIndicatorByName(sustainabilityIndicators, sustainabilityIndicatorName, true);
        }

        public static SustainabilityIndicator GetSustainabilityIndicatorByName(this IQueryable<SustainabilityIndicator> sustainabilityIndicators, string sustainabilityIndicatorName, bool requireRecordFound)
        {
            var sustainabilityIndicator = sustainabilityIndicators.SingleOrDefault(x => x.Indicator.IndicatorName == sustainabilityIndicatorName);
            if (requireRecordFound)
            {
                Check.RequireNotNull(sustainabilityIndicator, String.Format("Sustainability Indicator '{0}' not found!", sustainabilityIndicatorName));
            }
            return sustainabilityIndicator;
        }
    }
}