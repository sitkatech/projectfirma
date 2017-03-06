/*-----------------------------------------------------------------------
<copyright file="SecuredActionUrlHelper.cs" company="Tahoe Regional Planning Agency">
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
