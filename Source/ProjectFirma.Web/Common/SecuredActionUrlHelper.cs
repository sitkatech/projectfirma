using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public static class SecuredActionUrlHelper
    {
        private static readonly string DefaultDeniedFormat = String.Empty;

        public static bool UserHasAccess<T>(Person person, Expression<Action<T>> routeExpression) where T : Controller
        {
            return SecuredAction(person, routeExpression) != DefaultDeniedFormat;
        }

        public static string SecuredAction<T>(Person person, Expression<Action<T>> routeExpression) where T : Controller
        {
            return SecuredAction(person, routeExpression, "{0}");
        }

        public static string SecuredAction<T>(Person person, Expression<Action<T>> routeExpression, string grantedFormat) where T : Controller
        {
            return SecuredAction(person, routeExpression, grantedFormat, DefaultDeniedFormat);
        }

        public static string SecuredAction<T>(Person person, Expression<Action<T>> routeExpression, string grantedFormat, string deniedFormat) where T : Controller
        {
            var body = SitkaRoute<T>.GetRouteExpressionBody(routeExpression);
            var firmaFeatureLookupAttribute = body.Method.GetCustomAttributes(typeof(FirmaBaseFeature), true).Cast<FirmaBaseFeature>().SingleOrDefault();
            Check.RequireNotNull(firmaFeatureLookupAttribute, string.Format("Could not find feature for {0}", SitkaRoute<T>.BuildUrlFromExpression(routeExpression)));
            return firmaFeatureLookupAttribute.HasPermissionByPerson(person) ? String.Format("<a href=\"{0}\">{1}</a>", SitkaRoute<T>.BuildUrlFromExpression(routeExpression), grantedFormat) : deniedFormat;
        }

        public static string SecuredActionLink<T>(Person person, Expression<Action<T>> routeExpression, string linkText, string cssClass) where T : Controller
        {
            var grantedFormat = String.Format("<a href=\"{{0}}\" class=\"{1}\">{0}</a>", linkText, cssClass);
            return SecuredAction(person, routeExpression, grantedFormat);
        }

        public static string SecuredActionLink<T>(Person person, Expression<Action<T>> routeExpression, string linkText) where T : Controller
        {
            return SecuredActionLink(person, routeExpression, linkText, String.Empty);
        }
    }
}