using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.EntityModelBinding;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public class LakeTahoeInfoFeatureWithContextImpl<T> : IActionFilter where T : IHavePrimaryKey
    {
        private readonly ILakeTahoeInfoBaseFeatureWithContext<T> _lakeTahoeInfoFeatureWithContext;

        public LakeTahoeInfoFeatureWithContextImpl(ILakeTahoeInfoBaseFeatureWithContext<T> lakeTahoeInfoFeatureWithContext)
        {
            _lakeTahoeInfoFeatureWithContext = lakeTahoeInfoFeatureWithContext;
        }

        public PermissionCheckResult HasPermission(Person person, T contextModelObject)
        {
            return _lakeTahoeInfoFeatureWithContext.HasPermission(person, contextModelObject);
        }

        public void DemandPermission(Person person, T contextModelObject)
        {
            var permissionCheckResult = HasPermission(person, contextModelObject);
            if (!permissionCheckResult.HasPermission)
            {
                throw new SitkaRecordNotAuthorizedException(permissionCheckResult.PermissionDeniedMessage);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var person = HttpRequestStorage.Person;
            var ltInfoEntityPrimaryKeys = filterContext.ActionParameters.Values.OfType<LtInfoEntityPrimaryKey<T>>().ToList();

            var genericMessage = string.Format("Problem evaluating feature \"{3}\" for controller action \"{0}.{1}()\" while looking for parameter of type \"{2}\".",
                filterContext.Controller.GetType().Name,
                filterContext.ActionDescriptor.ActionName,
                typeof(LtInfoEntityPrimaryKey<T>),
                _lakeTahoeInfoFeatureWithContext.FeatureName);

            Check.Require(ltInfoEntityPrimaryKeys.Any(), genericMessage + " Change code to add that parameter.");
            Check.Require(ltInfoEntityPrimaryKeys.Count() == 1, genericMessage + " Change code so that there's only one of those parameters.");

            var primaryKeyForObject = ltInfoEntityPrimaryKeys.Single();
            DemandPermission(person, primaryKeyForObject.EntityObject);
        }
    }
}