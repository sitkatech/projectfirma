using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("_Admin for Project Updates")]
    public class ProjectUpdateAdminFeature : EIPFeature
    {
        public ProjectUpdateAdminFeature() : base(new List<Role> {Role.Admin, Role.Approver, Role.TMPOManager})
        {
        }
    }
}