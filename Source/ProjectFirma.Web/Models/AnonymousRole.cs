using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class AnonymousRole : IRole
    {
        public int RoleID { get { return ModelObjectHelpers.NotYetAssignedID; } }
        public string RoleName { get { return "Anonymous"; } }
        public string RoleDisplayName { get { return "Anonymous (no login required)"; } }
        public string RoleDescription { get { return "This is the default security level for users who do not have a login. Any logged in user can also access all of these features."; } }
        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = IRoleExtensions.GetFeaturePermissions(null, typeof(AnonymousUnclassifiedFeature));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return new List<Person>();
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Anonymous()), RoleDisplayName);
        }
    }
}