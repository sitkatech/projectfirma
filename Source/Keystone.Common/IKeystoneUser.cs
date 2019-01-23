using System.Collections.Generic;

namespace Keystone.Common
{
    public interface IKeystoneUser
    {
        IEnumerable<string> GetRoleNames();
        void SetKeystoneUserClaims(IKeystoneUserClaims keystoneClaims);
    }
}