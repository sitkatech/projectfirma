using System;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ThresholdIndicator GetThresholdIndicatorByName(this IQueryable<ThresholdIndicator> thresholdIndicators, string thresholdIndicatorName)
        {
            return GetThresholdIndicatorByName(thresholdIndicators, thresholdIndicatorName, true);
        }

        public static ThresholdIndicator GetThresholdIndicatorByName(this IQueryable<ThresholdIndicator> thresholdIndicators, string thresholdIndicatorName, bool requireRecordFound)
        {
            var thresholdIndicator = thresholdIndicators.SingleOrDefault(x => x.Indicator.IndicatorName == thresholdIndicatorName);
            if (requireRecordFound)
            {
                Check.RequireNotNull(thresholdIndicator, String.Format("Threshold Indicator '{0}' not found!", thresholdIndicatorName));
            }
            return thresholdIndicator;
        }
    }
}