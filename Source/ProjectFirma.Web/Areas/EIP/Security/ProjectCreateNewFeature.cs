using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Create New Project")]
    public class ProjectCreateNewFeature : EIPFeature
    {
        public ProjectCreateNewFeature() : base(new List<EIPRole> { EIPRole.Admin, EIPRole.TMPOManager })
        {
        }
    }
}