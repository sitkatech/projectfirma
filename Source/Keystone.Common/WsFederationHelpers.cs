using System.Web;
using Microsoft.IdentityModel.Protocols.WSFederation;

namespace Keystone.Common
{
    public class WsFederationHelpers
    {
        public static bool IsSignoutRequest(HttpRequest request)
        {
            var isSignoutRequest = false;

            var ssoAction = request.QueryString[WSFederationConstants.Parameters.Action];
            if (!string.IsNullOrEmpty(ssoAction))
            {
                if (ssoAction == WSFederationConstants.Actions.SignOut || ssoAction == WSFederationConstants.Actions.SignOutCleanup)
                    isSignoutRequest = true;
            }

            return isSignoutRequest;
        }
    }
}
