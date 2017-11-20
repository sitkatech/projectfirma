using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public class FirmaFeatureForProject : FirmaFeatureWithContextImpl<Project>
    {
        public FirmaFeatureForProject(IFirmaBaseFeatureWithContext<Project> firmaFeatureWithContext) : base(firmaFeatureWithContext)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var primaryKeyForObject = GetPrimaryKeyForObjectAndEnsureTenantMatch(filterContext);
            var permissionCheckResult = HasPermission(HttpRequestStorage.Person, primaryKeyForObject.EntityObject);
            if (!permissionCheckResult.HasPermission)
            {
                filterContext.Result = new RedirectResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(primaryKeyForObject.PrimaryKeyValue)));
                SetInfoMessage(filterContext, permissionCheckResult);
            }
        }
    }
}