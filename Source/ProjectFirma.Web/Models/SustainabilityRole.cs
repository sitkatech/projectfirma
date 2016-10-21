using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.Sustainability.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class SustainabilityRole : IRole
    {
        public int RoleID { get { return SustainabilityRoleID; } }
        public string RoleName { get { return SustainabilityRoleName; } }
        public string RoleDisplayName { get { return SustainabilityRoleDisplayName; } }
        public string RoleDescription { get { return SustainabilityRoleDescription; } }

        public List<FeaturePermission> GetFeaturePermissions()
        {
            var featurePermissions = this.GetFeaturePermissions(typeof(SustainabilityFeature));
            featurePermissions.AddRange(this.GetFeaturePermissions(typeof(SustainabilityFeatureWithContext)));
            return featurePermissions;
        }

        public List<Person> GetPeopleWithRole()
        {
            return HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.SustainabilityRoleID == RoleID).ToList();
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