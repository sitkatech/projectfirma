using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFirmaModels.Models
{
    public interface IAuth0User
    {
        IEnumerable<string> RoleNames { get; }

        void SetAuth0UserClaims(IAuth0UserClaims auth0Claims);
    }
}
