using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Security
{
    public class PermissionCheckResult
    {
        public readonly bool HasPermission;
        public readonly string PermissionDeniedMessage;

        public PermissionCheckResult(string permissionDeniedMessage)
        {
            Check.RequireNotNullNotEmptyNotWhitespace(permissionDeniedMessage, "Should have a message on why permission is denied!");
            PermissionDeniedMessage = permissionDeniedMessage;
            HasPermission = false;
        }

        public PermissionCheckResult()
        {
            HasPermission = true;
            PermissionDeniedMessage = string.Empty;
        }
    }
}