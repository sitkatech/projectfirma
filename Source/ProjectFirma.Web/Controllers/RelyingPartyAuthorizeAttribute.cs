using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using Keystone.Common;

namespace ProjectFirma.Web.Controllers
{
    /// <summary>
    /// Prevent unauthorized access, unless it has been specifically allowed using AllowAnonymousAttribute
    /// </summary>
    public abstract class RelyingPartyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var attributeType = typeof(AnonymousUnclassifiedFeature);
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(attributeType, true)
                                    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(attributeType, true);

            if (!skipAuthorization)
            {
                var lakeTahoeInfoBaseFeatureType = typeof(LakeTahoeInfoBaseFeature);
                var lakeTahoeInfoBaseFeatureAttribute = filterContext.ActionDescriptor.GetCustomAttributes(lakeTahoeInfoBaseFeatureType, true).SingleOrDefault();
                if (lakeTahoeInfoBaseFeatureAttribute != null && ((LakeTahoeInfoBaseFeature) lakeTahoeInfoBaseFeatureAttribute).GrantedRoles.Any())
                {

                    if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        AuthenticateUser(filterContext);
                    }
                    else
                    {
                        base.OnAuthorization(filterContext);
                    }
                }
            }
        }

        // use FAM to redirect to STS to initiate SSO - parameters come via <microsoft.identityModel> section in config
        protected void AuthenticateUser(AuthorizationContext filterContext)
        {
            var requestContext = filterContext.RequestContext;
            if (requestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ContentResult() {Content = "<!-- This is the SitkaIfInPartialPageRedirectToLoginPage (marker for Javascript ajax login redirect handling) -->"};
            }
            else
            {
                var writeQueryString = KeystoneUtilities.GetSignInRedirectUrlWithReturnUrl(requestContext, HttpContext.Current.Request.Url.ToString());
                filterContext.Result = new RedirectResult(writeQueryString);                
            }
        }
    }
}