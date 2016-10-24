using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class Role : IRole
    {
        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = this.GetFeaturePermissions(typeof(EIPFeature));
            featurePermissions.AddRange(this.GetFeaturePermissions(typeof(EIPFeatureWithContext)));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.RoleID == RoleID).ToList();
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Summary(RoleID)), RoleDisplayName);
        }

        public static string GetAnonymousRoleUrl()
        {
            return SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Anonymous());
        }
    }
}