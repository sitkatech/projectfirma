using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public abstract class FirmaFeature : FirmaBaseFeature
    {
        protected FirmaFeature(IEnumerable<Role> roles) : base(roles.Select(x => (IRole)x).ToList()) { }
    }
}