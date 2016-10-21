using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Indicator GetIndicatorByIndicatorName(this IQueryable<Indicator> indicators, string indicatorName)
        {
            var indicator = indicators.SingleOrDefault(x => x.IndicatorName == indicatorName);
            Check.RequireNotNullThrowNotFound(indicator, "Indicator", indicatorName);
            return indicator;
        }
    }
}