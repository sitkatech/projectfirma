using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Objective")]
    public class TransportationObjectiveManageFeature : FirmaFeature
    {
        public TransportationObjectiveManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}