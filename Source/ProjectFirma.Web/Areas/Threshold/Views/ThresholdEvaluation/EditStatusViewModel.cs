using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditStatusViewModel : FormViewModel
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationStatus)]
        public int? ThresholdEvaluationStatusTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationTrend)]
        public int? ThresholdEvaluationTrendTypeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationConfidence)]
        public int? ThresholdEvaluationConfidenceTypeID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditStatusViewModel()
        {
            
        }     
        
        public EditStatusViewModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            ThresholdEvaluationStatusTypeID = thresholdEvaluation.ThresholdEvaluationStatusTypeID;
            ThresholdEvaluationTrendTypeID = thresholdEvaluation.ThresholdEvaluationTrendTypeID;
            ThresholdEvaluationConfidenceTypeID = thresholdEvaluation.ThresholdEvaluationConfidenceTypeID;
        }

        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            thresholdEvaluation.ThresholdEvaluationStatusTypeID = ThresholdEvaluationStatusTypeID;
            thresholdEvaluation.ThresholdEvaluationTrendTypeID = ThresholdEvaluationTrendTypeID;
            thresholdEvaluation.ThresholdEvaluationConfidenceTypeID = ThresholdEvaluationConfidenceTypeID;
        }
    }
}