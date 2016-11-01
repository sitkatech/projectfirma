using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Approve Proposed Project")]
    public class ProposedProjectApproveFeature : FirmaFeature
    {
        public ProposedProjectApproveFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {            
        }        
    }
}