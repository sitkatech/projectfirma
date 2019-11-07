/*-----------------------------------------------------------------------
<copyright file="FirmaBaseFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Models;


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

        // Is this called only on initial authorization? or every call? I think only first time, but let's be sure.
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            Roles = CalculateRoleNameStringFromFeature();

            var userIdentity = HttpRequestStorage.GetHttpContextUserThroughOwin().Identity;
            //if ()
            var firmaSessionFromClaimsIdentity = ClaimsIdentityHelper.FirmaSessionFromClaimsIdentity(HttpRequestStorage.GetHttpContextAuthenticationThroughOwin(), HttpRequestStorage.Tenant);
            HttpRequestStorage.FirmaSession = firmaSessionFromClaimsIdentity;

            AddLocalUserAccountRolesToClaims(HttpRequestStorage.FirmaSession, userIdentity);

            // This ends up making the calls into the RoleProvider
            base.OnAuthorization(filterContext);
        }

        public static void AddLocalUserAccountRolesToClaims(FirmaSession firmaSession, System.Security.Principal.IIdentity userIdentity)
        {
            // Is the incoming user authenticated? (We aren't dealing with the FirmaSession, we are in the process of *setting up* the FirmaSession)
            if (!userIdentity.IsAuthenticated)
            {
                return;
            }

            if (userIdentity is System.Security.Claims.ClaimsIdentity claimsIdentity)
            {
                if (firmaSession.Person != null)
                { 
                    firmaSession.Person.RoleNames.ToList().ForEach(role => claimsIdentity.AddClaim(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, role)));
                }
            }
        }

        internal string CalculateRoleNameStringFromFeature()
        {
            return String.Join(", ", GrantedRoles.Select(r => r.RoleName).ToList());
        }

        public string FeatureName => GetType().Name;

        // Hoping this can be eliminated in favor of HasPermissionByFirmaSession, but here for the moment.
        public virtual bool HasPermissionByPerson(Person person)
        {
            bool personIsAnonymous = person == null;

            // Inactive Tenants disallow anonymous/unassigned traffic
            bool tenantIsActive = MultiTenantHelpers.GetTenantAttribute().IsActive;
            if (!tenantIsActive && (personIsAnonymous || person.IsUnassigned()))
            {
                return false;
            }

            // AnonymousUnclassifiedFeatures allow anyone, at all times
            if (!_grantedRoles.Any())
            {
                return true;
            }

            // for a Role-limited feature, user must be logged in (not anonymous) and have matching Role
            bool hasMatchingRole = !personIsAnonymous && _grantedRoles.Any(x => x.RoleID == person.Role.RoleID);
            return hasMatchingRole;
        }

        // Eventually, usages like this should replace HasPermissionByPerson throughout
        public virtual bool HasPermissionByFirmaSession(FirmaSession firmaSession)
        {
            Person firmaSessionPerson = firmaSession.Person;
            return HasPermissionByPerson(firmaSessionPerson);
        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return HasPermissionByFirmaSession(HttpRequestStorage.FirmaSession);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var redirectToLogin = new RedirectResult(FirmaHelpers.GenerateLogInUrl());
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = redirectToLogin;
                return;
            }
            throw new SitkaRecordNotAuthorizedException($"You are not authorized for feature \"{FeatureName}\". Log out and log in as a different user or request additional permissions.");
        }

        public static bool IsAllowed<T>(SitkaRoute<T> sitkaRoute, FirmaSession currentFirmaSession) where T : Controller
        {
            var firmaFeatureLookupAttribute = sitkaRoute.Body.Method.GetCustomAttributes(typeof(FirmaBaseFeature), true).Cast<FirmaBaseFeature>().SingleOrDefault();
            Check.RequireNotNull(firmaFeatureLookupAttribute, $"Could not find feature for {sitkaRoute.BuildUrlFromExpression()}");
            // ReSharper disable PossibleNullReferenceException
            return firmaFeatureLookupAttribute.HasPermissionByFirmaSession(currentFirmaSession);
            // ReSharper restore PossibleNullReferenceException
        }

        public static FirmaBaseFeature InstantiateFeature(Type featureType)
        {
            return (FirmaBaseFeature)Activator.CreateInstance(featureType);
        }
    }
}
