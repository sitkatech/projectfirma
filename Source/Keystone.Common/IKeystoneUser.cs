using System.Collections.Generic;

namespace Keystone.Common
{
    public interface IKeystoneUser
    {
        IEnumerable<string> RoleNames { get; }
        void SetKeystoneUserClaims(IKeystoneUserClaims keystoneClaims);
    }
}