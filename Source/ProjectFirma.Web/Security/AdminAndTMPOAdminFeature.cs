using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Base class for admin level features; we do not want to use this on Controller Security Feature Attribute
    /// However we can use this to verify role permissions
    /// </summary>
    [SecurityFeatureDescription("_Admin / TMPO Manager for EIP")]
    public class AdminAndTMPOAdminFeature : EIPFeature
    {
        public AdminAndTMPOAdminFeature() : base(new List<Role> {Role.Admin, Role.TMPOManager})
        {
        }
    }
}