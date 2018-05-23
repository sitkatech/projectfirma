using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Web;
using log4net;

namespace Keystone.Common
{
    public class KeystoneSessionSecurityTokenHandler : SessionSecurityTokenHandler
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(KeystoneSessionSecurityTokenHandler));

        // ReSharper disable InconsistentNaming
        private const string SessionSecurityTokenHandler_ID1073_Exception = "ID1073";
        // ReSharper restore InconsistentNaming

        // suppress exception thrown by SAM TryReadSessionTokenFromCookie when FedAuth token is bad (for example after IIS reset)
        public override SecurityToken ReadToken(byte[] token, SecurityTokenResolver tokenResolver)
        {
            SecurityToken securityToken = null;

            try
            {
                securityToken = base.ReadToken(token, tokenResolver);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains(SessionSecurityTokenHandler_ID1073_Exception))
                {
                    // log user out (destroys FedAuth cookies) which will force logon (& reissue of new token, etc.)
                    Logger.InfoFormat("KeystoneSessionSecurityTokenHandler - suppressing '{0}' exception thrown from ReadToken", SessionSecurityTokenHandler_ID1073_Exception);
                    var fam = FederatedAuthentication.WSFederationAuthenticationModule;
                    fam.SignOut(false);
                }
                else
                {
                    Logger.InfoFormat("KeystoneSessionSecurityTokenHandler - rethrowing InvalidOperationException caught in ReadToken; message: {0}", ex.Message);
                    throw;
                }
            }
            
            return securityToken;
        }

        public override byte[] WriteToken(SessionSecurityToken sessionToken)
        {
            Logger.DebugFormat("KeystoneSessionSecurityTokenHandler - WriteToken for ClaimsPrincipal '{0}'", sessionToken.ClaimsPrincipal.Identity.Name);
            return base.WriteToken(sessionToken);
        }

        public override SessionSecurityToken CreateSessionSecurityToken(Microsoft.IdentityModel.Claims.IClaimsPrincipal principal, string context, string endpointId, DateTime validFrom, DateTime validTo)
        {
            Logger.DebugFormat("KeystoneSessionSecurityTokenHandler - calling CreateSessionSecurityToken for ClaimsPrincipal '{0}' for endpoint '{1}' valid from '{2}' to '{3}'", principal.Identity.Name, endpointId, validFrom.ToLongTimeString(), validTo.ToLongTimeString());
            return base.CreateSessionSecurityToken(principal, context, endpointId, validFrom, validTo);
        }

        protected override void ValidateSession(SessionSecurityToken securityToken)
        {
            Logger.DebugFormat("KeystoneSessionSecurityTokenHandler - calling ValidateSession for ClaimsPrincipal '{0}'", securityToken.ClaimsPrincipal.Identity.Name);
            base.ValidateSession(securityToken);
        }

        public override Microsoft.IdentityModel.Claims.ClaimsIdentityCollection ValidateToken(SessionSecurityToken token, string endpointId)
        {
            Logger.DebugFormat("KeystoneSessionSecurityTokenHandler - calling ValidateToken for ClaimsPrincipal '{0}' for endpoint '{1}'", token.ClaimsPrincipal.Identity.Name, endpointId);
            return base.ValidateToken(token, endpointId);
        }
    }
}
