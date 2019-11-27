/*-----------------------------------------------------------------------
<copyright file="SitkaRoute.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public class SitkaRoute<T> where T : Controller
    {
        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        public MethodCallExpression Body { get; private set; }

        public Expression<Action<T>> RouteExpression { get; private set; }

        private static readonly Lazy<RequestContext> GenericRequestContextLazy = new Lazy<RequestContext>(() =>
            // ReSharper restore StaticFieldInGenericType
        {
            var sw = new StringWriter();
            var url = string.Format("http://{0}{1}", FirmaWebConfiguration.CanonicalHostName, SitkaWebConfiguration.WebApplicationRootPath);
            var request = new HttpRequest(String.Empty, url, String.Empty);
            var httpContext = new HttpContext(request, new HttpResponse(sw));
            return new RequestContext(new HttpContextWrapper(httpContext), new RouteData());
        });

        public SitkaRouteSecurity RouteSecurity { get; set; }

        public static RequestContext GenericRequestContext
        {
            get
            {
                return GenericRequestContextLazy.Value;
            }
        }

        public SitkaRoute(Expression<Action<T>> routeExpression, SitkaRouteSecurity routeSecurity) : this(routeExpression)
        {
            RouteSecurity = routeSecurity;
        }

        public SitkaRoute(Expression<Action<T>> routeExpression) 
        {
            RouteExpression = routeExpression;
            ControllerName = SitkaController.ControllerTypeToControllerName(typeof(T));
            Body = GetRouteExpressionBody(routeExpression);

            var actionName = Body.Method.Name;
            var attributes = Body.Method.GetCustomAttributes(typeof(ActionNameAttribute), false);
            if (attributes.Length > 0)
            {
                var actionNameAttr = (ActionNameAttribute) attributes[0];
                actionName = actionNameAttr.Name;
            }

            ActionName = actionName;
        }

        public string BuildUrlFromExpression()
        {
            return BuildUrlFromExpression(RouteExpression);
        }

        public string BuildAbsoluteUrlFromExpression()
        {
            return BuildAbsoluteUrlFromExpression(RouteExpression);
        }

        public string BuildAbsoluteUrlHttpsFromExpression()
        {
            return BuildAbsoluteUrlHttpsFromExpression(RouteExpression);
        }

        public static string BuildUrlFromExpression(Expression<Action<T>> routeExpression)
        {
            return LinkBuilderBuildUrlFromExpressionImpl(routeExpression);
        }

        public static string BuildSaltedUrlFromExpression(Expression<Action<T>> routeExpression)
        {
            return LinkBuilderBuildUrlFromExpressionImpl(routeExpression) + "?r=" +
                   SitkaRouteRandomizer.RandomGenerator.Next();
        }

        public static string BuildAbsoluteUrlHttpsFromExpression(Expression<Action<T>> routeExpression)
        {
            return BuildAbsoluteUrlFromExpressionImpl(routeExpression, "https");
        }

        public static string BuildAbsoluteUrlFromExpression(Expression<Action<T>> routeExpression)
        {
            return BuildAbsoluteUrlFromExpressionImpl(routeExpression, "http");
        }

        private static string BuildAbsoluteUrlFromExpressionImpl(Expression<Action<T>> routeExpression, string protocol)
        {
            var relativeUrl = LinkBuilderBuildUrlFromExpressionImpl(routeExpression);
            return BuildAbsoluteUrlFromRelativeUrl(protocol, relativeUrl);
        }

        public static string BuildAbsoluteUrlFromRelativeUrl(string relativeUrl)
        {
            return BuildAbsoluteUrlFromRelativeUrl("http", relativeUrl);
        }

        public static string BuildAbsoluteUrlFromRelativeUrl(string protocol, string relativeUrl)
        {

            var currentContext = HttpContext.Current;
            var hostName = FirmaWebConfiguration.CanonicalHostName;
            if (currentContext != null)
            {
                hostName = FirmaWebConfiguration.GetCanonicalHost(currentContext.Request.Url.Host, true) ?? FirmaWebConfiguration.CanonicalHostName;
            }

            return $"{protocol}://{hostName}{relativeUrl}";
        }
        
        private static string LinkBuilderBuildUrlFromExpressionImpl(Expression<Action<T>> routeExpression)
        {
            Check.Require(RouteTable.Routes.Any(), "RouteTable is empty and therefore no urls can be constructed. Is this being called before the route table is built? Consider using Lazy<T> or some other way to delay the call.");
            var currentContext = HttpContext.Current;
            var requestRequestContext = currentContext != null ? currentContext.Request.RequestContext : GenericRequestContext; // for unit testing, we need a request
            var route = SitkaLinkBuilder.BuildUrlFromExpression(requestRequestContext, RouteTable.Routes, routeExpression);
            Check.RequireNotNullNotEmptyNotWhitespace(route,$"Could not find a route entry for route expression \"{routeExpression.Type.Name}.{routeExpression}\"");
            Check.Require(!route.Contains("?"), $"Route expression \"{routeExpression.Type.Name}.{routeExpression.Body}\" resulted in url \"{route}\" which contains a UrlParameter converted to a QueryStringParameter, most likely due to an optional blank/null parameter preceeding another non-blank/non-null parameter. We want only url parameters for routing - no query strings - to keep more fine grained control over url appearance");
            return route;
        }

        // -- Non-static versions --
        public string BuildLinkFromExpression(string linkText)
        {
            return $"<a href=\"{BuildUrlFromExpression(RouteExpression)}\">{linkText}</a>";
        }

        public string BuildLinkFromExpression(string linkText, string titleText)
        {
            return String.Format("<a href=\"{0}\" title=\"{2}\">{1}</a>", BuildUrlFromExpression(RouteExpression), linkText, titleText);
        }

        public string BuildLinkFromExpression(string linkText, Dictionary<string, string> attributeDict)
        {
            return String.Format("<a href=\"{0}\" {2}>{1}</a>", BuildUrlFromExpression(RouteExpression), linkText, BuildAttributeString(attributeDict));
        }

        public string BuildLinkFromExpression(string linkText, string titleText, Dictionary<string, string> attributeDict)
        {
            return String.Format("<a href=\"{0}\" title=\"{2}\" {3}>{1}</a>", BuildUrlFromExpression(RouteExpression), linkText, titleText, BuildAttributeString(attributeDict));
        }

        // -- Static versions --
        public static string BuildLinkFromExpression(Expression<Action<T>> routeExpression, string linkText)
        {
            return String.Format("<a href=\"{0}\">{1}</a>", BuildUrlFromExpression(routeExpression), linkText);
        }
        
        public static string BuildLinkFromExpression(Expression<Action<T>> routeExpression, string linkText, string titleText)
        {
            return String.Format("<a href=\"{0}\" title=\"{2}\">{1}</a>", BuildUrlFromExpression(routeExpression), linkText, titleText);
        }

        public static string BuildLinkFromExpression(Expression<Action<T>> routeExpression, string linkText, Dictionary<string, string> attributeDict)
        {
            return String.Format("<a href=\"{0}\" {2}>{1}</a>", BuildUrlFromExpression(routeExpression), linkText, BuildAttributeString(attributeDict));
        }

        public static string BuildLinkFromExpression(Expression<Action<T>> routeExpression, string linkText, string titleText, Dictionary<string, string> attributeDict)
        {
            return String.Format("<a href=\"{0}\" title=\"{2}\" {3}>{1}</a>", BuildUrlFromExpression(routeExpression), linkText, titleText, BuildAttributeString(attributeDict));
        }

        public static string BuildLinkFromUrl(string url, string linkText)
        {
            return String.Format("<a href=\"{0}\">{1}</a>", url, linkText);
        }

        public static string BuildLinkFromUrl(string url, string linkText, string titleText)
        {
            return String.Format("<a href=\"{0}\" title=\"{2}\">{1}</a>", url, linkText, titleText);
        }

        public static string BuildExternalLinkFromUrl(string baseExternalUrl, string linkText)
        {
            return String.Format("<a href=\"http://{0}\">{1}</a>", baseExternalUrl, linkText);
        }

        public static MethodCallExpression GetRouteExpressionBody(Expression<Action<T>> routeExpression)
        {
            var body = routeExpression.Body as MethodCallExpression;

            Check.RequireNotNull(body, new ArgumentException("Expression must be a method call."));
            // ReSharper disable PossibleNullReferenceException
            Check.Require(body.Object == routeExpression.Parameters[0], new ArgumentException("Method call must target lambda argument."));
            // ReSharper restore PossibleNullReferenceException
            return body;
        }

        #region Private Helper Methods
        
        private static string BuildAttributeString(Dictionary<string, string> attributeDict)
        {
            return attributeDict.Aggregate(" ", (current, attribute) => current + String.Format(" {0}=\"{1}\"", attribute.Key, attribute.Value));
        }

        #endregion
    }

    internal static class SitkaRouteRandomizer
    {
        internal static Random RandomGenerator = new Random(); 
    }

    public enum SitkaRouteSecurity
    {
        Unsecured,
        SSL
    }
}