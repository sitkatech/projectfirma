using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create New Proposed Project")]
    public class ProposedProjectCreateNewFeature : EIPFeature
    {
        public ProposedProjectCreateNewFeature()
            : base(new List<Role> { Role.Normal, Role.Approver, Role.Admin, Role.TMPOManager })
        {
        }
    }
}