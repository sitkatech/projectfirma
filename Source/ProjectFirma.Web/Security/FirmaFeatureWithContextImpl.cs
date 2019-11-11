/*-----------------------------------------------------------------------
<copyright file="FirmaFeatureWithContextImpl.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.EntityModelBinding;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    public class FirmaFeatureWithContextImpl<T> : IActionFilter where T : IHavePrimaryKey
    {
        private readonly IFirmaBaseFeatureWithContext<T> _firmaFeatureWithContext;

        public FirmaFeatureWithContextImpl(IFirmaBaseFeatureWithContext<T> firmaFeatureWithContext)
        {
            _firmaFeatureWithContext = firmaFeatureWithContext;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, T contextModelObject)
        {
            return _firmaFeatureWithContext.HasPermission(firmaSession, contextModelObject);
        }

        public void DemandPermission(FirmaSession firmaSession, T contextModelObject)
        {
            var permissionCheckResult = HasPermission(firmaSession, contextModelObject);
            if (!permissionCheckResult.HasPermission)
            {
                throw new SitkaRecordNotAuthorizedException(permissionCheckResult.PermissionDeniedMessage);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var primaryKeyForObject = GetPrimaryKeyForObjectAndEnsureTenantMatch(filterContext);
            DemandPermission(HttpRequestStorage.FirmaSession, primaryKeyForObject.EntityObject);
        }

        protected LtInfoEntityPrimaryKey<T> GetPrimaryKeyForObjectAndEnsureTenantMatch(ActionExecutingContext filterContext)
        {
            var ltInfoEntityPrimaryKeys = filterContext.ActionParameters.Values.OfType<LtInfoEntityPrimaryKey<T>>().ToList();

            var genericMessage = string.Format(
                "Problem evaluating feature \"{3}\" for controller action \"{0}.{1}()\" while looking for parameter of type \"{2}\".",
                filterContext.Controller.GetType().Name,
                filterContext.ActionDescriptor.ActionName,
                typeof(LtInfoEntityPrimaryKey<T>),
                _firmaFeatureWithContext.FeatureName);

            Check.Require(ltInfoEntityPrimaryKeys.Any(), genericMessage + " Change code to add that parameter.");
            Check.Require(ltInfoEntityPrimaryKeys.Count == 1,
                genericMessage + " Change code so that there's only one of those parameters.");

            var primaryKeyForObject = ltInfoEntityPrimaryKeys.Single();
            if (primaryKeyForObject.EntityObject is IHaveATenantID hasTenantIDEntity)
            {
                var tenant = HttpRequestStorage.Tenant;
                Check.RequireThrowNotAuthorized(hasTenantIDEntity.TenantID == tenant.TenantID, $"TenantID mismatch (Expected {tenant.TenantID}, Was {hasTenantIDEntity.TenantID})!");
            }
            return primaryKeyForObject;
        }
        protected static void SetInfoMessage(ActionExecutingContext filterContext, PermissionCheckResult permissionCheckResult)
        {
            filterContext.Controller.TempData[SitkaController.InfoMessageIndex] = permissionCheckResult.PermissionDeniedMessage;
        }
    }
}
