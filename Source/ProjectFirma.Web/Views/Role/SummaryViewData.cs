using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Role
{
    public class SummaryViewData : SiteLayoutViewData
    {
        public readonly PersonWithRoleGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public List<FeaturePermission> ApprovedFeatures;
        public List<FeaturePermission> DeniedFeatures;
        public List<Person> PeopleWithRole;
        public readonly string RoleName;
        public readonly string RoleDescription;
        public readonly LTInfoAreaEnum? LTInfoAreaEnum;
        public readonly string LTInfoAreaName;

        public SummaryViewData(Person currentPerson, IRole role)
            : base(currentPerson, false)
        {
            var featurePermissions = role.GetFeaturePermissions();
            ApprovedFeatures = featurePermissions.Where(x => x.HasPermission).ToList();
            DeniedFeatures = featurePermissions.Where(x => !x.HasPermission).ToList();
            
            RoleName = role.RoleDisplayName;
            RoleDescription = role.RoleDescription;
            LTInfoAreaEnum = role.LTInfoAreaEnum;
            LTInfoAreaName = role.LTInfoAreaDisplayName;

            //Grid
            if (role.LTInfoAreaEnum.HasValue)
            {
                GridSpec = new PersonWithRoleGridSpec() {ObjectNameSingular = "Person", ObjectNamePlural = "People", SaveFiltersInCookie = true};
                GridName = "PersonWithRoleGrid";
                GridDataUrl = SitkaRoute<RoleController>.BuildUrlFromExpression(tc => tc.PersonWithRoleGridJsonData(role.LTInfoAreaEnum.Value, role.RoleID));
            }
            //Site Layout
            PageTitle = String.Format("Role Summary for {0}: {1}", LTInfoAreaName, RoleName);
            EntityName = "Role Summary";
        }
    }
}