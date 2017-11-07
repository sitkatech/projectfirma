/*-----------------------------------------------------------------------
<copyright file="SitkaLinkBuilder.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using Microsoft.Web.Mvc;

namespace ProjectFirma.Web.Common
{
    /// <summary>
    /// This is a replacement for <see cref="LinkBuilder.BuildUrlFromExpression{TController}"/> it calls <see cref="RouteCollectionExtensions.GetVirtualPathForArea(System.Web.Routing.RouteCollection,System.Web.Routing.RequestContext,System.Web.Routing.RouteValueDictionary)"/> which is too slow
    /// </summary>
    public static class SitkaLinkBuilder
    {
        /// <summary>
        /// Builds a URL based on the Expression passed in
        /// </summary>
        /// <typeparam name="TController">Controller Type Only</typeparam>
        /// <param name="context">The current ViewContext</param>
        /// <param name="routeCollection">The <see cref="RouteCollection"/> to use for building the URL.</param>
        /// <param name="action">The action to invoke</param>
        /// <returns></returns>
        public static string BuildUrlFromExpression<TController>(RequestContext context, RouteCollection routeCollection, Expression<Action<TController>> action) where TController : Controller
        {
            // 4/4/2016 RL: We could not simply just use RouteValueDictionary routeValues = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(action) because it is not Area aware;
            // so we had to get the guts of that method call and do it ourself to make it respect areas

            var body = action.Body as MethodCallExpression;
            Check.RequireNotNull(body, "MvcResources.ExpressionHelper_MustBeMethodCall");
            // ReSharper disable PossibleNullReferenceException
            var actionName = GetTargetActionName(body.Method);
            // ReSharper restore PossibleNullReferenceException

            var controllerType = typeof(TController);
            var controllerName = SitkaController.ControllerTypeToControllerName(controllerType);

            var routeValues = GetRouteValuesFromExpression(body, controllerType.Namespace, controllerName, actionName);

            var vpd = routeCollection.GetVirtualPath(context, routeValues);
            if (vpd == null)
            {
                return null;
            }
            
            var routeUrl = vpd.VirtualPath;
            return routeUrl;
        }

        private static RouteValueDictionary GetRouteValuesFromExpression(MethodCallExpression body, string areaName, string controllerName, string actionName)
        {
            var routeValues = LinkBuilder.BuildParameterValuesFromExpression(body) ?? new RouteValueDictionary();
            foreach (var pair in routeValues.Where(x => x.Value == null).ToList())
            {
                routeValues.Remove(pair.Key);
            }

            routeValues.Add("controller", controllerName);
            routeValues.Add("action", actionName);
            return routeValues;
        }

        private static string GetTargetActionName(MethodInfo methodInfo)
        {
            var name = methodInfo.Name;

            if (methodInfo.IsDefined(typeof(NonActionAttribute), true))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "MvcResources.ExpressionHelper_CannotCallNonAction", new object[] { name }));
            }

            var attribute = methodInfo.GetCustomAttributes(typeof(ActionNameAttribute), true).OfType<ActionNameAttribute>().FirstOrDefault();

            if (attribute != null)
            {
                return attribute.Name;
            }

            if (methodInfo.DeclaringType.IsSubclassOf(typeof(AsyncController)))
            {
                if (name.EndsWith("Async", StringComparison.OrdinalIgnoreCase))
                {
                    return name.Substring(0, name.Length - "Async".Length);
                }
                if (name.EndsWith("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "MvcResources.ExpressionHelper_CannotCallCompletedMethod", new object[] { name }));
                }
            }

            return name;
        }
    }
}
