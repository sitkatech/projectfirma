using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    public abstract class EIPFeatureWithContext : FirmaBaseFeature, IActionFilter
    {
        public IActionFilter ActionFilter;

        protected EIPFeatureWithContext(List<Role> grantedRoles) : base(grantedRoles.Select(x => (IRole)x).ToList())
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ActionFilter.OnActionExecuting(filterContext);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ActionFilter.OnActionExecuted(filterContext);
        }
    }
}