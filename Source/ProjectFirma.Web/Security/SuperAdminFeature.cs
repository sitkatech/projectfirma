using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Base class for admin level features
    /// </summary>
    public abstract class EIPAdminFeature : EIPFeature
    {
        protected EIPAdminFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }      
    }
}