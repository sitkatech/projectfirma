using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory
{
    public class IndicatorRelationshipsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<Indicator> ActionIndicators;
        public readonly List<Indicator> IntermediateResultIndicators;
        public readonly List<Indicator> OutcomeIndicators;

        public IndicatorRelationshipsViewData(List<Indicator> actionIndicators, List<Indicator> intermediateResultIndicators, List<Indicator> outcomeIndicators)
        {
            ActionIndicators = actionIndicators;
            IntermediateResultIndicators = intermediateResultIndicators;
            OutcomeIndicators = outcomeIndicators;
        }
    }
}