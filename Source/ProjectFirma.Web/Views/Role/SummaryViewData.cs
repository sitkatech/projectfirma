using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Role
{
    public class SummaryViewData : EIPViewData
    {
        public readonly PersonWithRoleGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public List<FeaturePermission> ApprovedFeatures;
        public List<FeaturePermission> DeniedFeatures;
        public List<Person> PeopleWithRole;
        public readonly string RoleName;
        public readonly string RoleDescription;

        public SummaryViewData(Person currentPerson, IRole role)
            : base(currentPerson)
        {
            var featurePermissions = role.GetFeaturePermissions();
            ApprovedFeatures = featurePermissions.Where(x => x.HasPermission).ToList();
            DeniedFeatures = featurePermissions.Where(x => !x.HasPermission).ToList();

            RoleName = role.RoleDisplayName;
            RoleDescription = role.RoleDescription;

            GridSpec = new PersonWithRoleGridSpec() {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
            GridName = "PersonWithRoleGrid";
            GridDataUrl = SitkaRoute<RoleController>.BuildUrlFromExpression(tc => tc.PersonWithRoleGridJsonData(role.RoleID));

            PageTitle = String.Format("Role Summary for {0}", RoleName);
            EntityName = "Role Summary";
        }
    }
}