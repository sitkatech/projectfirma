using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public abstract class FirmaFeatureWithContext : FirmaBaseFeature, IActionFilter
    {
        public IActionFilter ActionFilter;

        protected FirmaFeatureWithContext(List<Role> grantedRoles) : base(grantedRoles.Select(x => (IRole)x).ToList())
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