using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("_Admin for ProjectFirma")]
    public class FirmaAdminFeature : EIPFeature
    {
        public FirmaAdminFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin }) { }
    }
}