using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Sustainability.Security
{
    public abstract class SustainabilityFeatureWithContext : LakeTahoeInfoBaseFeature, IActionFilter
    {
        public IActionFilter ActionFilter;

        protected SustainabilityFeatureWithContext(IEnumerable<SustainabilityRole> grantedRoles) : base(grantedRoles.Select(x => (IRole)x).ToList(), LTInfoArea.Sustainability)
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