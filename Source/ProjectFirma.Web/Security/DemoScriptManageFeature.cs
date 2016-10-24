using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Demo Script")]
    public class DemoScriptManageFeature : EIPFeature
    {
        public DemoScriptManageFeature() : base(new List<Role> {Role.Admin, Role.ReadOnlyAdmin})
        {
        }
    }
}