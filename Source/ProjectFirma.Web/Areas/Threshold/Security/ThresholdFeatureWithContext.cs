using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Threshold.Security
{
    public abstract class ThresholdFeatureWithContext : LakeTahoeInfoBaseFeature, IActionFilter
    {
        public IActionFilter ActionFilter;

        protected ThresholdFeatureWithContext(IEnumerable<ThresholdRole> grantedRoles) : base(grantedRoles.Select(x => (IRole)x).ToList(), LTInfoArea.Threshold)
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