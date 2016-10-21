using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdRole : IRole
    {
        public int RoleID { get { return ThresholdRoleID; } }
        public string RoleName { get { return ThresholdRoleName; } }
        public string RoleDisplayName { get { return ThresholdRoleDisplayName; } }
        public string RoleDescription { get { return ThresholdRoleDescription; } }

        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = this.GetFeaturePermissions(typeof(ThresholdFeature));
            featurePermissions.AddRange(this.GetFeaturePermissions(typeof(ThresholdFeatureWithContext)));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.ThresholdRoleID == RoleID).ToList();
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
    }
}