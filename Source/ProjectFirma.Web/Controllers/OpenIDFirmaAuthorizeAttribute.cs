using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    
    public class OpenIDFirmaAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var principal = HttpRequestStorage.GetHttpContextUserThroughOwin();

            var attributeType = typeof(AnonymousUnclassifiedFeature);
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(attributeType, true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(attributeType, true);

            if (!principal.Identity.IsAuthenticated && !skipAuthorization)
            {
                var baseFeatureType = typeof(FirmaBaseFeature);
                var baseFeatureAttribute = filterContext.ActionDescriptor.GetCustomAttributes(baseFeatureType, true).SingleOrDefault();

                if (baseFeatureAttribute != null && ((FirmaBaseFeature)baseFeatureAttribute).GrantedRoles.Any())
                {
                    base.OnAuthorization(filterContext);
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}