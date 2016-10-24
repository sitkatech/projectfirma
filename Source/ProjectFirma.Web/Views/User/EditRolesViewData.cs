using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> EIPRoles;
        public readonly IEnumerable<SelectListItem> LtInfoRoles;

        public EditRolesViewData(IEnumerable<SelectListItem> eipRoles, IEnumerable<SelectListItem> ltInfoRoles)
        {
            EIPRoles = eipRoles;
            LtInfoRoles = ltInfoRoles;
        }
    }
}