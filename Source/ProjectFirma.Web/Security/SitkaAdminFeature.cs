using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    /// <summary>
    /// Feature for Sitka admins to adminster across tenants
    /// </summary>
    [SecurityFeatureDescription("_SitkaAdmin ")]
    public class SitkaAdminFeature : FirmaFeature
    {
        public SitkaAdminFeature()
            : base(new List<Role> { Role.SitkaAdmin })
        {
        }
    }
}