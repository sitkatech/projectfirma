using System.Web.Mvc;
using ProjectFirma.Web.Common;
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
                base.OnAuthorization(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}