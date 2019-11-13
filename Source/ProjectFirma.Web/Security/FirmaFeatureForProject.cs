using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

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
            var permissionCheckResult = HasPermission(HttpRequestStorage.FirmaSession, primaryKeyForObject.EntityObject);
            if (!permissionCheckResult.HasPermission)
            {
                filterContext.Result = new RedirectResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(x => x.Detail(primaryKeyForObject.PrimaryKeyValue)));
                SetInfoMessage(filterContext, permissionCheckResult);
            }
        }
    }
}