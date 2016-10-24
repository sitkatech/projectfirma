using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Role;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class EIPRole : IRole
    {
        public int RoleID { get { return EIPRoleID; } }
        public string RoleName { get { return EIPRoleName; } }
        public string RoleDisplayName { get { return EIPRoleDisplayName; } }
        public string RoleDescription { get { return EIPRoleDescription; } }

        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = this.GetFeaturePermissions(typeof(EIPFeature));
            featurePermissions.AddRange(this.GetFeaturePermissions(typeof(EIPFeatureWithContext)));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.EIPRoleID == RoleID).ToList();
        }

        public LTInfoAreaEnum? LTInfoAreaEnum
        {
            get { return LTInfoArea.ToEnum; }
        }

        public string LTInfoAreaDisplayName
        {
            get { return LTInfoArea.LTInfoAreaDisplayName; }
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Summary(LTInfoArea.ToEnum, RoleID)), RoleDisplayName);
        }

        public static string GetAnonymousRoleUrl()
        {
            return SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Anonymous());
        }
    }
}