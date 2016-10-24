using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Approve Proposed Project")]
    public class ProposedProjectApproveFeature : EIPFeature
    {             
        public ProposedProjectApproveFeature(): base(new List<Role> {Role.Admin, Role.Approver, Role.TMPOManager})
        {            
        }        
    }
}