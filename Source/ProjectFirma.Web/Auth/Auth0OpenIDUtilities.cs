using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using log4net;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Auth
{
    public class Auth0OpenIDUtilities
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(Auth0OpenIDUtilities));

        public static void OpenIDClaimHandler(
            Func<IAuth0UserClaims, IIdentity, IAuth0User> syncLocalAccountStore,
            IIdentity userIdentity)
        {
            Auth0OpenIDUtilities.Logger.DebugFormat("Before call to ParseClaims");
            IAuth0UserClaims openIdClaims = Auth0ClaimsHelpers.ParseOpenIDClaims(userIdentity);
            Auth0OpenIDUtilities.Logger.DebugFormat("After call to ParseClaims");
            Auth0OpenIDUtilities.Logger.DebugFormat("Before call to SyncLocalAccountStore");
            IAuth0User user = syncLocalAccountStore(openIdClaims, userIdentity);
            Auth0OpenIDUtilities.Logger.DebugFormat("After call to SyncLocalAccountStore");
            Auth0OpenIDUtilities.Logger.DebugFormat("Before mapping of Roles to claims");
            Auth0OpenIDUtilities.AddLocalUserAccountRolesToClaims(user, userIdentity);
            Auth0OpenIDUtilities.Logger.DebugFormat("After mapping of Roles to claims");
        }

        public static void AddLocalUserAccountRolesToClaims(IAuth0User user, IIdentity userIdentity)
        {
            ClaimsIdentity claimsIdentity;
            if ((claimsIdentity = userIdentity as ClaimsIdentity) == null)
                return;
            user.RoleNames.ToList<string>().ForEach((Action<string>)(role => claimsIdentity.AddClaim(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role))));
        }
    }
}