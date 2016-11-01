using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("_Admin for Project Updates")]
    public class ProjectUpdateAdminFeature : FirmaFeature
    {
        public ProjectUpdateAdminFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}