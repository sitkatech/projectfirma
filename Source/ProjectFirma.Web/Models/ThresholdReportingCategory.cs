using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdReportingCategory
    {
        public List<Indicator> GetRelatedIndicatorsByIndicatorType(IndicatorType indicatorType)
        {
            return ThresholdIndicators.SelectMany(x => x.Indicator.GetRelatedIndicatorsByIndicatorType(indicatorType)).Distinct(new HavePrimaryKeyComparer<Indicator>()).ToList();
        }

        public string FullDisplayName
        {
            get { return string.Format("{0} - {1}", ThresholdCategory.DisplayName, DisplayName); }
        }
    }
}