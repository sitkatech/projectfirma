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

    }
}