using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditStatusDetailsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ThresholdEvaluation ThresholdEvaluation;

        public EditStatusDetailsViewData(Models.ThresholdEvaluation thresholdEvaluation)
        {
            ThresholdEvaluation = thresholdEvaluation;
        }
    }
}