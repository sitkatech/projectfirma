using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create New Proposed Project")]
    public class ProposedProjectCreateNewFeature : EIPFeature
    {
        public ProposedProjectCreateNewFeature()
            : base(new List<Role> { Role.Normal, Role.Approver, Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
        }
    }
}