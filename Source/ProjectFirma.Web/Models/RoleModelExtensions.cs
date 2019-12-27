using System.Web;
using System.Web.UI.WebControls;
using LtInfo.Common;
using Microsoft.Owin.Infrastructure;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class RoleModelExtensions
    {
        public static string GetRoleDisplayName(this Role role)
        {
            if (role.RoleID == Role.ProjectSteward.RoleID)
            {
                return FieldDefinitionEnum.ProjectSteward.ToType().GetFieldDefinitionLabel();
            }

            if (role.RoleID == Role.Normal.RoleID)
            {
                return FieldDefinitionEnum.NormalUser.ToType().GetFieldDefinitionLabel();
            }

            return role.RoleDisplayName;
        }

        public static HtmlString GetDisplayNameAsUrl(this Role role)
        {
            return UrlTemplate.MakeHrefString(SitkaRoute<RoleController>.BuildUrlFromExpression(t => t.Detail(role.RoleID)), role.GetRoleDisplayName());
        }
    }
}