using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicator
{
    public class EditStandardsMetadataViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> ThresholdStandardTypes;

        public EditStandardsMetadataViewData(IEnumerable<SelectListItem> thresholdStandardTypes)
        {
            ThresholdStandardTypes = thresholdStandardTypes;
        }
    }
}