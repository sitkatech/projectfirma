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

        public IList<IRole> GrantedRoles
        {
            get { return _grantedRoles; }
        }

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

        public string FeatureName
        {
            get { return GetType().Name; }
        }

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
            throw new SitkaRecordNotAuthorizedException(String.Format("You are not authorized for feature \"{0}\". Log out and log in as a different user or request additional permissions.", FeatureName));
        }

        public static bool IsAllowed<T>(SitkaRoute<T> sitkaRoute, Person currentPerson) where T : Controller
        {
            var firmaFeatureLookupAttribute = sitkaRoute.Body.Method.GetCustomAttributes(typeof(FirmaBaseFeature), true).Cast<FirmaBaseFeature>().SingleOrDefault();
            Check.RequireNotNull(firmaFeatureLookupAttribute, String.Format("Could not find feature for {0}", sitkaRoute.BuildUrlFromExpression()));
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