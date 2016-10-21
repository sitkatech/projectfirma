using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("_Admin for Project Updates")]
    public class ProjectUpdateAdminFeature : EIPFeature
    {
        public ProjectUpdateAdminFeature() : base(new List<EIPRole> {EIPRole.Admin, EIPRole.Approver, EIPRole.TMPOManager})
        {
        }
    }
}