using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Manage Demo Script")]
    public class DemoScriptManageFeature : EIPFeature
    {
        public DemoScriptManageFeature() : base(new List<EIPRole> {EIPRole.Admin, EIPRole.ReadOnlyAdmin})
        {
        }
    }
}