/*-----------------------------------------------------------------------
<copyright file="FirmaBaseFeature.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Models;
using Keystone.Common;

namespace ProjectFirma.Web.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public abstract class FirmaBaseFeature : RelyingPartyAuthorizeAttribute
    {
        private readonly IList<IRole> _grantedRoles;

        public IList<IRole> GrantedRoles => _grantedRoles;

        protected FirmaBaseFeature(IList<IRole> grantedRoles) // params
        {
            // Force user to pass us empty lists to make life simpler
            Check.RequireNotNull(grantedRoles, "Can\'t pass null for Granted Roles.");

            // At least one of these must be set
            //Check.Ensure(grantedRoles.Any(), "Must set at least one Role");

            _grantedRoles = grantedRoles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Roles = CalculateRoleNameStringFromFeature();

            // MR #321 - force reload of user roles onto IClaimsIdentity
            KeystoneUtilities.AddLocalUserAccountRolesToClaims(HttpRequestStorage.Person);

            // This ends up making the calls into the RoleProvider
            base.OnAuthorization(filterContext);
        }

        internal string CalculateRoleNameStringFromFeature()
        {
            return String.Join(", ", GrantedRoles.Select(r => r.RoleName).ToList());
        }

        public string FeatureName => GetType().Name;

        public virtual bool HasPermissionByPerson(Person person)
        {
            if (!_grantedRoles.Any()) // AnonymousUnclassifiedFeature case
            {
                return true; 
            }
            return person != null && _grantedRoles.Any(x => x.RoleID == person.Role.RoleID);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return HasPermissionByPerson(HttpRequestStorage.Person);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var redirectToLogin = new RedirectResult(FirmaHelpers.GenerateLogInUrlWithReturnUrl());
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = redirectToLogin;
                return;
            }
            throw new SitkaRecordNotAuthorizedException($"You are not authorized for feature \"{FeatureName}\". Log out and log in as a different user or request additional permissions.");
        }

        public static bool IsAllowed<T>(SitkaRoute<T> sitkaRoute, Person currentPerson) where T : Controller
        {
            var firmaFeatureLookupAttribute = sitkaRoute.Body.Method.GetCustomAttributes(typeof(FirmaBaseFeature), true).Cast<FirmaBaseFeature>().SingleOrDefault();
            Check.RequireNotNull(firmaFeatureLookupAttribute, $"Could not find feature for {sitkaRoute.BuildUrlFromExpression()}");
            // ReSharper disable PossibleNullReferenceException
            return firmaFeatureLookupAttribute.HasPermissionByPerson(currentPerson);
            // ReSharper restore PossibleNullReferenceException
        }

        public static FirmaBaseFeature InstantiateFeature(Type featureType)
        {
            return (FirmaBaseFeature)Activator.CreateInstance(featureType);
        }
    }
}
