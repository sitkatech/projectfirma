using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicatorImage
{
    public class NewViewData
    {
        public readonly Models.ThresholdIndicator ThresholdIndicator;
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;

        public NewViewData(Models.ThresholdIndicator thresholdIndicator)
        {
            ThresholdIndicator = thresholdIndicator;
            SupportedFileExtensions = new List<string> {"jpg", "png", "gif", "tiff", "bmp"};
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
        }
    }
}