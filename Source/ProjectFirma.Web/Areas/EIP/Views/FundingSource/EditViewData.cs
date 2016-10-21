using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.FundingSource
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Organizations;

        public EditViewData(IEnumerable<SelectListItem> organizations)
        {
            Organizations = organizations;
        }
    }
}