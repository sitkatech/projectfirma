using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Approve Proposed Project")]
    public class ProposedProjectApproveFeature : EIPFeature
    {
        public ProposedProjectApproveFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.Approver, Role.TMPOManager })
        {            
        }        
    }
}