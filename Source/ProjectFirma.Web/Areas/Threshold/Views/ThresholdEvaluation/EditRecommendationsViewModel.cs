using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditRecommendationsViewModel : FormViewModel
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationAnalyticApproach)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.AnalyticApproachRecommendation)]
        public string AnalyticalApproachRecommendation { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationMonitoringApproach)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.MonitoringApproachRecommendation)]
        public string MonitoringApproachRecommendation { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationModificationOfTheThresholdStandardOrIndicator)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.ModificationOfTheThresholdStandardOrIndicator)]
        public string ModificationOfTheThresholdStandardOrIndicator { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationAttainOrMaintainThreshold)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.AttainOrMaintainThreshold)]
        public string AttainOrMaintainThreshold { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRecommendationsViewModel()
        {
        }

        public EditRecommendationsViewModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            AnalyticalApproachRecommendation = thresholdEvaluation.AnalyticApproachRecommendation;
            MonitoringApproachRecommendation = thresholdEvaluation.MonitoringApproachRecommendation;
            ModificationOfTheThresholdStandardOrIndicator = thresholdEvaluation.ModificationOfTheThresholdStandardOrIndicator;
            AttainOrMaintainThreshold = thresholdEvaluation.AttainOrMaintainThreshold;
        }

        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            thresholdEvaluation.AnalyticApproachRecommendation = AnalyticalApproachRecommendation;
            thresholdEvaluation.MonitoringApproachRecommendation = MonitoringApproachRecommendation;
            thresholdEvaluation.ModificationOfTheThresholdStandardOrIndicator = ModificationOfTheThresholdStandardOrIndicator;
            thresholdEvaluation.AttainOrMaintainThreshold = AttainOrMaintainThreshold;
        }
    }
}