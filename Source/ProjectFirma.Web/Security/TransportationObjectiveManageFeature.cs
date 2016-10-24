using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Objective")]
    public class TransportationObjectiveManageFeature : EIPFeature
    {
        public TransportationObjectiveManageFeature() : base(new List<Role> { Role.Admin, Role.TMPOManager })
        {
        }
    }
}