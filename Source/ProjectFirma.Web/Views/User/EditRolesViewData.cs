using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> EIPRoles;

        public EditRolesViewData(IEnumerable<SelectListItem> eipRoles)
        {
            EIPRoles = eipRoles;
        }
    }
}