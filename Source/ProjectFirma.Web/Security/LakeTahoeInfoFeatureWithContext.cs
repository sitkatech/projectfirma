using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public abstract class LakeTahoeInfoFeatureWithContext : LakeTahoeInfoBaseFeature, IActionFilter
    {
        public IActionFilter ActionFilter;

        protected LakeTahoeInfoFeatureWithContext(IList<LTInfoRole> grantedRoles)
            : base(grantedRoles.Select(x => (IRole)x).ToList(), LTInfoArea.LTInfo)
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