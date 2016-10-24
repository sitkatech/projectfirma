using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class LTInfoArea
    {
        public abstract string GetCanonicalHostName();

        public abstract IRole GetRole(int roleID);
        public abstract List<IRole> GetRoles();
        public abstract string GetHomeUrl();
        public abstract string GetLogoUrl();
        public abstract string GetFavIconUrl();
        public abstract string PreferredSiteAreaLinkWidth { get; }
        protected abstract Func<Person, IRole> GetPersonRoleToUseFunc();

        public IRole GetPersonRoleToUse(Person person)
        {
            return GetPersonRoleToUseFunc().Invoke(person);
        }

        public static List<LTInfoArea> SortedAll
        {
            get { return All.OrderBy(x => x.SortOrder).ToList(); }
        }

        public List<Person> GetSupportRequestRecipients()
        {
            return HttpRequestStorage.DatabaseEntities.PersonAreas.Where(x => x.LTInfoAreaID == LTInfoAreaID && x.ReceiveSupportEmails).Select(x => x.Person).Where(x => x.IsActive).ToList();
        }

        public bool HasPermissionByPerson(Person person, IList<IRole> rolesToCheck)
        {
            return person != null && rolesToCheck.Any(x => x.RoleID == GetPersonRoleToUseFunc().Invoke(person).RoleID);
        }

        public abstract PermissionCheckResult CanManageFieldDefinitionAndIntroTextForArea(Person person);
    }

    public partial class LTInfoAreaEIP
    {
        public override string GetCanonicalHostName()
        {
            return ProjectFirmaWebConfiguration.CanonicalHostNameEIP;
        }

        public override IRole GetRole(int roleID)
        {
            return EIPRole.AllLookupDictionary[roleID];
        }

        public override List<IRole> GetRoles()
        {
            return EIPRole.All.Select(x => (IRole)x).ToList();
        }

        public override string GetHomeUrl()
        {
            return SitkaRoute<Areas.EIP.Controllers.HomeController>.BuildUrlFromExpression(x => x.Index());
        }

        public override string GetLogoUrl()
        {
            return "/Content/img/header_logo_projectFirma.png";
        }

        public override string GetFavIconUrl()
        {
            return "/Areas/EIP/Content/img/favicon-32x32.png";
        }

        public override string PreferredSiteAreaLinkWidth { get { return "150px"; }}

        protected override Func<Person, IRole> GetPersonRoleToUseFunc()
        {
            return x => x.EIPRole;
        }

        public override PermissionCheckResult CanManageFieldDefinitionAndIntroTextForArea(Person person)
        {
            if (HasPermissionByPerson(person, new List<IRole> {EIPRole.Admin, EIPRole.TMPOManager}))
            {
                return new PermissionCheckResult();
            }
            return new PermissionCheckResult("Does not have EIP administration privileges");
        }
    }

    public partial class LTInfoAreaLTInfo
    {
        public override string GetCanonicalHostName()
        {
            return ProjectFirmaWebConfiguration.CanonicalHostNameRoot;
        }

        public override IRole GetRole(int roleID)
        {
            return LTInfoRole.AllLookupDictionary[roleID];
        }

        public override List<IRole> GetRoles()
        {
            return LTInfoRole.All.Select(x => (IRole)x).ToList();
        }


        public override string GetHomeUrl()
        {
            return SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
        }

        public override string GetLogoUrl()
        {
            return null;
        }

        public override string GetFavIconUrl()
        {
            return "/Content/img/favicon-32x32.png";
        }

        public override string PreferredSiteAreaLinkWidth { get { return "140px"; } }

        protected override Func<Person, IRole> GetPersonRoleToUseFunc()
        {
            return x => x.LTInfoRole;
        }

        public override PermissionCheckResult CanManageFieldDefinitionAndIntroTextForArea(Person person)
        {
            if(HasPermissionByPerson(person, new List<IRole> { LTInfoRole.Admin }))
            {
                return new PermissionCheckResult();
            }
            return new PermissionCheckResult("Does not have Lake Tahoe Info administration privileges");
        }
    }
}