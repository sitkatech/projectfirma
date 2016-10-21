using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Role
{
    public class IndexViewData : SiteLayoutViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson)
            : base(currentPerson, false)
        {
            GridSpec = new IndexGridSpec { ObjectNameSingular = "Role", ObjectNamePlural = "Roles", SaveFiltersInCookie = true };
            GridName = "RoleGrid";
            GridDataUrl = SitkaRoute<RoleController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            PageTitle = "Roles Index";
        }
    }
}