using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    public abstract class EIPFeature : LakeTahoeInfoBaseFeature
    {
        protected EIPFeature(IEnumerable<EIPRole> roles) : base(roles.Select(x => (IRole)x).ToList(), LTInfoArea.EIP) { }
    }
}