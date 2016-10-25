using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    public abstract class EIPFeature : FirmaBaseFeature
    {
        protected EIPFeature(IEnumerable<Role> roles) : base(roles.Select(x => (IRole)x).ToList()) { }
    }
}