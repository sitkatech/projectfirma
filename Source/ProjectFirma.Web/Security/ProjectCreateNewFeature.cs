using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create New Project")]
    public class ProjectCreateNewFeature : FirmaFeature
    {
        public ProjectCreateNewFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}