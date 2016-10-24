using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Features")]
    public class TransportationManageFeature : EIPFeature
    {
        public TransportationManageFeature() : base(new List<Role> { Role.Admin, Role.TMPOManager })
        {
        }
    }
}