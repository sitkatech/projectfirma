using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    public abstract class EIPFeatureWithContext : LakeTahoeInfoBaseFeature, IActionFilter
    {
        public IActionFilter ActionFilter;

        protected EIPFeatureWithContext(List<EIPRole> grantedRoles) : base(grantedRoles.Select(x => (IRole)x).ToList(), LTInfoArea.EIP)
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