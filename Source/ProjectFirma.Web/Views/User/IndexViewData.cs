using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.User
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string KeystoneUrl;
        public readonly string KeystoneRegisterUserUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = "Users";
            GridSpec = new IndexGridSpec() {ObjectNameSingular = "User", ObjectNamePlural = "Users", SaveFiltersInCookie = true};
            GridName = "UserGrid";
            GridDataUrl = SitkaRoute<UserController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            KeystoneUrl = ProjectFirmaWebConfiguration.KeystoneUrl;
            KeystoneRegisterUserUrl = ProjectFirmaWebConfiguration.KeystoneRegisterUserUrl;
        }
    }
}