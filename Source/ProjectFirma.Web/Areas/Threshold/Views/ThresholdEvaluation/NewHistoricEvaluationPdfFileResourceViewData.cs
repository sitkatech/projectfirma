using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class NewHistoricEvaluationPdfFileResourceViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ThresholdEvaluation ThresholdEvaluation;

        public NewHistoricEvaluationPdfFileResourceViewData(Models.ThresholdEvaluation thresholdEvaluation)
        {
            ThresholdEvaluation = thresholdEvaluation;
        }
    }
}