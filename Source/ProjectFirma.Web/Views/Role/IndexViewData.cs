using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Role
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            GridSpec = new IndexGridSpec { ObjectNameSingular = "Role", ObjectNamePlural = "Roles", SaveFiltersInCookie = true };
            GridName = "RoleGrid";
            GridDataUrl = SitkaRoute<RoleController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());

            PageTitle = "Roles Index";
        }
    }
}