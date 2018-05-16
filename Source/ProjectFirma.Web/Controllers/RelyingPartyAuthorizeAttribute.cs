/*-----------------------------------------------------------------------
<copyright file="RelyingPartyAuthorizeAttribute.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Controllers
{
    /// <summary>
    /// Prevent unauthorized access, unless it has been specifically allowed using AllowAnonymousAttribute
    /// </summary>
    public abstract class RelyingPartyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var attributeType = typeof(AnonymousUnclassifiedFeature);
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(attributeType, true)
                                    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(attributeType,
                                        true);

            if (!skipAuthorization)
            {
                var firmaBaseFeatureType = typeof(FirmaBaseFeature);
                var firmaBaseFeatureAttribute = filterContext.ActionDescriptor.GetCustomAttributes(firmaBaseFeatureType, true).SingleOrDefault();
                if (firmaBaseFeatureAttribute != null && ((FirmaBaseFeature) firmaBaseFeatureAttribute).GrantedRoles.Any())
                {
                    base.OnAuthorization(filterContext);
                }
            }
            else
            {
                if (!HttpRequestStorage.Tenant.GetTenantAttribute().IsActive)
                {
                    var defaultTenant = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Where(x => x.IsActive).OrderBy(x => x.TenantID).First().Tenant;
                    var writeQueryString =
                        $"http://{FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(defaultTenant)}";
                    filterContext.Result = new RedirectResult(writeQueryString);
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
