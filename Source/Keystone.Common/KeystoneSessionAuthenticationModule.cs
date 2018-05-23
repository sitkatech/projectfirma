using System;
using Microsoft.IdentityModel.Web;
using log4net;

namespace Keystone.Common
{
    public class KeystoneSessionAuthenticationModule : SessionAuthenticationModule
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(KeystoneSessionAuthenticationModule));

        protected override void OnSessionSecurityTokenReceived(SessionSecurityTokenReceivedEventArgs args)
        {
            var now = DateTime.UtcNow;
            var validFrom = args.SessionToken.ValidFrom;
            var validTo = args.SessionToken.ValidTo;
            var sessionTokenLifetime = (validTo - validFrom).TotalMinutes;
            var halfSpan = sessionTokenLifetime / 2;
            if (validFrom.AddMinutes(halfSpan) < now && now < validTo)
            {
                var newValidFrom = now;
                var newValidTo = now.AddMinutes(sessionTokenLifetime);
                Logger.DebugFormat("KeystoneSessionAuthenticationModule - extending SessionToken for ClaimsPrincipal '{0}', now for endpoint '{1}' valid from '{2}' to '{3}'",
                    args.SessionToken.ClaimsPrincipal.Identity.Name, args.SessionToken.EndpointId, newValidFrom.ToLongTimeString(), newValidTo.ToLongTimeString());
                args.SessionToken = CreateSessionSecurityToken(args.SessionToken.ClaimsPrincipal, args.SessionToken.Context, newValidFrom, newValidTo, args.SessionToken.IsPersistent);
                args.ReissueCookie = true;
            }

            base.OnSessionSecurityTokenReceived(args);

        }
    }
}
