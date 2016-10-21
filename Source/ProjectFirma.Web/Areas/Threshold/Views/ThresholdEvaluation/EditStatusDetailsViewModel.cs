using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditStatusDetailsViewModel : FormViewModel
    {

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationStatusRationale)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.StatusRationale)]
        public string StatusRationale { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationTrendRationale)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.TrendRationale)]
        public string TrendRationale { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationConfidenceStatus)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.ConfidenceStatus)]
        public string ConfidenceStatus { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationConfidenceTrend)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.ConfidenceTrend)]
        public string ConfidenceTrend { get; set; }
        
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationConfidenceOverall)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.ConfidenceOverall)]
        public string ConfidenceOverall { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditStatusDetailsViewModel()
        {
        }

        public EditStatusDetailsViewModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            StatusRationale = thresholdEvaluation.StatusRationale;
            TrendRationale = thresholdEvaluation.TrendRationale;
            ConfidenceStatus = thresholdEvaluation.ConfidenceStatus;
            ConfidenceTrend = thresholdEvaluation.ConfidenceTrend;
            ConfidenceOverall = thresholdEvaluation.ConfidenceOverall;
        }

        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            thresholdEvaluation.StatusRationale = StatusRationale;
            thresholdEvaluation.TrendRationale = TrendRationale;
            thresholdEvaluation.ConfidenceStatus = ConfidenceStatus;
            thresholdEvaluation.ConfidenceTrend = ConfidenceTrend;
            thresholdEvaluation.ConfidenceOverall = ConfidenceOverall;
        }
    }
}