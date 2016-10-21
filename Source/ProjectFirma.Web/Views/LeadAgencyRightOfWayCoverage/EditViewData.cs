using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.LeadAgencyRightOfWayCoverage
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Commodites;
        public readonly IEnumerable<SelectListItem> BaileyRatings;

        public EditViewData(IEnumerable<SelectListItem> commodites, IEnumerable<SelectListItem> baileyRatings)
        {
            Commodites = commodites;
            BaileyRatings = baileyRatings;
        }
    }
}