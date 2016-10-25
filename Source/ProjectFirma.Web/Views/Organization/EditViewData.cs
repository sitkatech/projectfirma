using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Sectors;
        public readonly IEnumerable<SelectListItem> People;
        public readonly bool IsInKeystone;
        public readonly string RequestOrganizationChangeUrl;

        public EditViewData(IEnumerable<SelectListItem> sectors, IEnumerable<SelectListItem> people, bool isInKeystone, string requestOrganizationChangeUrl)
        {
            Sectors = sectors;
            People = people;
            IsInKeystone = isInKeystone;
            RequestOrganizationChangeUrl = requestOrganizationChangeUrl;
        }
    }
}