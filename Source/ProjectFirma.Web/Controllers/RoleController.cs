using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Role;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class RoleController : LakeTahoeInfoBaseController
    {
        [LakeTahoeInfoAdminFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [UserEditFeature]
        public GridJsonNetJObjectResult<IRole> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var roleSummaries = GetRoleSummaryData();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<IRole>(roleSummaries, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserEditFeature]
        public GridJsonNetJObjectResult<Person> PersonWithRoleGridJsonData(int roleID)
        {
            var role = Role.AllLookupDictionary[roleID];
            var gridSpec = new PersonWithRoleGridSpec();
            var peopleWithRole = role.GetPeopleWithRole();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(peopleWithRole, gridSpec);
            return gridJsonNetJObjectResult;
        }

        public static List<IRole> GetRoleSummaryData()
        {
            var roles = new List<IRole> {new AnonymousRole()};
            roles.AddRange(Role.All);
            return roles.OrderBy(x => x.RoleDisplayName).ToList();
        }

        [LakeTahoeInfoAdminFeature]
        public ViewResult Anonymous()
        {
            return ViewSummary(new AnonymousRole());
        }

        [LakeTahoeInfoAdminFeature]
        public ViewResult Summary(int roleID)
        {
            var role = Role.AllLookupDictionary[roleID];
            return ViewSummary(role);
        }

        private ViewResult ViewSummary(IRole role)
        {
            var viewData = new SummaryViewData(CurrentPerson, role);
            return RazorView<Summary, SummaryViewData>(viewData);
        }
    }
}