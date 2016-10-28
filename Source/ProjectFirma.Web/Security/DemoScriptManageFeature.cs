using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Demo Script")]
    public class DemoScriptManageFeature : FirmaFeature
    {
        public DemoScriptManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ReadOnlyAdmin })
        {
        }
    }
}