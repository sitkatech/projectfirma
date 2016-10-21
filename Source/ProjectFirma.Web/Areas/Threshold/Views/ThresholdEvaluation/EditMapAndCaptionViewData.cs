using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditMapAndCaptionViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ThresholdEvaluation ThresholdEvaluation;

        public EditMapAndCaptionViewData(Models.ThresholdEvaluation thresholdEvaluation)
        {
            ThresholdEvaluation = thresholdEvaluation;
        }
    }
}