using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Roles;

        public EditRolesViewData(IEnumerable<SelectListItem> roles)
        {
            Roles = roles;
        }
    }
}