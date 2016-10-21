using System.Collections.Generic;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface IRole
    {
        int RoleID { get; }
        string RoleName { get; }
        string RoleDisplayName { get; }
        string RoleDescription { get; }
        List<FeaturePermission> GetFeaturePermissions();
        List<Person> GetPeopleWithRole();
        LTInfoAreaEnum? LTInfoAreaEnum { get; }
        string LTInfoAreaDisplayName { get; }
        HtmlString GetDisplayNameAsUrl();
    }
}