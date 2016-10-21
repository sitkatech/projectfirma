using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class LTInfoRole : IRole
    {
        public int RoleID { get { return LTInfoRoleID; } }
        public string RoleName { get { return LTInfoRoleName; } }
        public string RoleDisplayName { get { return LTInfoRoleDisplayName; } }
        public string RoleDescription { get { return LTInfoRoleDescription; } }

        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = this.GetFeaturePermissions(typeof(LakeTahoeInfoFeature));
            featurePermissions.AddRange(this.GetFeaturePermissions(typeof(LakeTahoeInfoFeatureWithContext)));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.LTInfoRoleID == RoleID).ToList();
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
            return UrlTemplate.MakeHrefString(this.GetSummaryUrl(), RoleDisplayName);
        }
    }
}