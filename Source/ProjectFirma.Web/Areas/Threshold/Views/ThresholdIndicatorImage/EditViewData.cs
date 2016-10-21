using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicatorImage
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ThresholdIndicatorImage ThresholdIndicatorImage;

        public EditViewData(Models.ThresholdIndicatorImage thresholdIndicatorImage)
        {
            ThresholdIndicatorImage = thresholdIndicatorImage;
        }
    }
}