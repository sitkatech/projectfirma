using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Must be at least logged in and have role >= Normal
    /// </summary>
    [SecurityFeatureDescription("Has a ProjectFirma role")]
    public class LoggedInAndNotUnassignedRoleUnclassifiedFeature : FirmaFeature
    {
        public LoggedInAndNotUnassignedRoleUnclassifiedFeature()
            : base(FirmaBaseFeatureHelpers.AllRolesExceptUnassigned)
        {
        }
    }
}