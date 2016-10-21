using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditStatusViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ThresholdIndicator ThresholdIndicator;
        public readonly IEnumerable<SelectListItem> ThresholdEvaluationStatusTypes;
        public readonly IEnumerable<SelectListItem> ThresholdEvaluationTrendTypes;
        public readonly IEnumerable<SelectListItem> ThresholdEvaluationConfidenceTypes;

        public EditStatusViewData(Models.ThresholdIndicator thresholdIndicator, IEnumerable<SelectListItem> thresholdEvaluationStatusTypes, IEnumerable<SelectListItem> thresholdEvaluationTrendTypes, IEnumerable<SelectListItem> thresholdEvaluationConfidenceTypes)
        {
            ThresholdEvaluationStatusTypes = thresholdEvaluationStatusTypes;
            ThresholdIndicator = thresholdIndicator;
            ThresholdEvaluationTrendTypes = thresholdEvaluationTrendTypes;
            ThresholdEvaluationConfidenceTypes = thresholdEvaluationConfidenceTypes;
        }
    }
}