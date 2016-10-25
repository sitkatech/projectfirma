using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Organizations;

        public EditViewData(IEnumerable<SelectListItem> organizations)
        {
            Organizations = organizations;
        }
    }
}