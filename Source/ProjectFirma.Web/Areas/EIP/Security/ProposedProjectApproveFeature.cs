using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Approve Proposed Project")]
    public class ProposedProjectApproveFeature : EIPFeature
    {             
        public ProposedProjectApproveFeature(): base(new List<EIPRole> {EIPRole.Admin, EIPRole.Approver, EIPRole.TMPOManager})
        {            
        }        
    }
}