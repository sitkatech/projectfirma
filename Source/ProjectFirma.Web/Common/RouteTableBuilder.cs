/*-----------------------------------------------------------------------
<copyright file="RouteTableBuilder.cs" company="Sitka Technology Group">
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
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class PlaceUrlParameterBeforeControllerAndActionName : Attribute
    {
    }

    public class RouteTableBuilder
    {
        private static RouteCollection _routes;
        private readonly Dictionary<string, string> _areasDictionary;
        private readonly List<SitkaRouteTableEntry> _defaultRoutes;
        private static bool _hasRouteTableBeenBuiltYet;

        public static void ClearRoutes()
        {
            RouteTable.Routes.Clear();
            _hasRouteTableBeenBuiltYet = false;
        }

        public const string IllegalRouteExceptionMessage = "Illegal route, hit an non-optional parameter *after* an optional parameter";

        public RouteTableBuilder(RouteCollection collection, List<SitkaRouteTableEntry> defaultRoutes, Dictionary<string, string> areasDictionary)
        {
            _routes = collection;
            _areasDictionary = areasDictionary;
            _defaultRoutes = defaultRoutes;
        }

        private void SetupRouteTable(IEnumerable<MethodInfo> allActions)
        {
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var sitkaRouteEntries = SetupRouteTableImpl(allActions, _defaultRoutes, _areasDictionary);
            var duplicates = sitkaRouteEntries.GroupBy(x => x.RouteName).Where(y => y.Count() > 1).SelectMany(z => z).ToList();

            Check.Require(!duplicates.Any(), $"Unexpected duplicate routes found, check controller actions:\r\n{String.Join("\r\n", duplicates)}");

            // add the ones with a route order first
            foreach (var routeEntry in sitkaRouteEntries.Where(x => x.RouteOrder.HasValue).OrderBy(x => x.RouteOrder).ThenBy(x => x.Controller).ThenBy(x => x.Action).ThenBy(x => x.RouteName).ToList())
            {
                AddToRouteTable(routeEntry);
            }

            foreach (var routeEntry in sitkaRouteEntries.Where(x => !x.RouteOrder.HasValue).OrderBy(x => x.Controller).ThenBy(x => x.Action).ThenBy(x => x.RouteName).ToList())
            {
                AddToRouteTable(routeEntry);
            }
        }

        public static void AddToRouteTable(SitkaRouteTableEntry routeEntry)
        {
            var namespaces = new string[]{};
            if (!String.IsNullOrEmpty(routeEntry.Namespace))
            {
                namespaces = new[] {routeEntry.Namespace};
            }
            _routes.MapRoute(routeEntry.RouteName, routeEntry.RouteUrl, new { controller = routeEntry.Controller, action = routeEntry.Action }, routeEntry, namespaces);
        }

        public static List<SitkaRouteTableEntry> SetupRouteTableImpl(IEnumerable<MethodInfo> actionMethods)
        {
            return SetupRouteTableImpl(actionMethods, null, new Dictionary<string, string>());
        }

        /// <summary>
        /// Sets up all the Asp.NET MVC routes dynamically based on reflecting over all of the controller actions in the main assembly
        /// </summary>
        private static List<SitkaRouteTableEntry> SetupRouteTableImpl(IEnumerable<MethodInfo> actionMethods, List<SitkaRouteTableEntry> defaultRoutes, Dictionary<string, string> areasDictionary)
        {
            List<SitkaRouteTableEntry> sitkaRouteEntries;
            if (defaultRoutes == null || !defaultRoutes.Any())
            {
                sitkaRouteEntries = new List<SitkaRouteTableEntry>
                {
                    new SitkaRouteTableEntry("Default", String.Empty, String.Empty, SitkaController.DefaultController, SitkaController.DefaultAction, null)
                };
            }
            else
            {
                sitkaRouteEntries = defaultRoutes.Select(x => x).ToList();
            }

            var methodsOrderedByControllerThenAction = actionMethods.OrderBy(x => x.ReflectedType.Name).ThenBy(x => x.Name).ThenBy(x => IsRestrictedToPost(x).ToString()).ToList();
            var getMethodsDict = new Dictionary<string, List<string>>();

            foreach (var controllerActionMethod in methodsOrderedByControllerThenAction)
            {
                var routesForOneMethod = MakeRoutesForSingleMethod(areasDictionary, controllerActionMethod, getMethodsDict);
                sitkaRouteEntries.AddRange(routesForOneMethod);
            }

            return sitkaRouteEntries;
        }

        private static IEnumerable<SitkaRouteTableEntry> MakeRoutesForSingleMethod(Dictionary<string, string> areasDictionary, MethodInfo controllerActionMethod, Dictionary<string, List<string>> getMethodsDict)
        {
            var sitkaRouteEntries = new List<SitkaRouteTableEntry>();
            var controller = SitkaController.ControllerTypeToControllerName(controllerActionMethod.ReflectedType);
            var controllerPartForUrl = SitkaController.ControllerTypeToControllerNameForUrl(controllerActionMethod.ReflectedType);

            var isRestrictedToPost = IsRestrictedToPost(controllerActionMethod);

            var httpPostRouteSuffix = (isRestrictedToPost ? "__HttpPost" : "");
            var action = controllerActionMethod.Name;

            var routeName = $"{controller}__{action}{httpPostRouteSuffix}";

            var allParameters = controllerActionMethod.GetParameters();

            var controllerAndAction = $"{controller}.{action}";
            var parameterString = String.Join(",", allParameters.Select(x => $"{x.ParameterType.FullName} {x.Name}"));
            var actionControllerNameWithParameters = $"{controller}\t{action}\t{parameterString}";

            if (!isRestrictedToPost)
            {
                AssertOptionalParametersAreOnlyAtEndOfRoute(routeName, allParameters);

                if (!getMethodsDict.ContainsKey(controllerAndAction))
                {
                    getMethodsDict.Add(controllerAndAction, new List<string>());
                }
                getMethodsDict[controllerAndAction].Add(actionControllerNameWithParameters);
            }
            else
            {
                if (getMethodsDict.ContainsKey(controllerAndAction))
                {
                    if (!getMethodsDict[controllerAndAction].Any(actionControllerNameWithParameters.StartsWith))
                    {
                        var allGetRoutes = String.Join("\r\n", getMethodsDict[controllerAndAction]);
                        throw new ApplicationException($"The POST route {controllerAndAction} must have a corresponding GET route with the same parameters\r\nPOST route: {actionControllerNameWithParameters}\r\nGET routes: {allGetRoutes}");
                    }
                }
            }

            // see if it has a route attribute defined; if so, use that as the route url
            var routeAttribute = controllerActionMethod.GetCustomAttributes<RouteAttribute>(false).SingleOrDefault();

            // Now add in all the variants of the route based on parameter overloading
            // /Foo.mvc/Action/1 => FooController.Action(1)
            var appendParameters = allParameters.OrderBy(p => p.Position).ToList();
            var crossAreaRouteAttribute = controllerActionMethod.GetCustomAttributes<CrossAreaRouteAttribute>(false).SingleOrDefault();
            var isCrossAreaRoute = crossAreaRouteAttribute != null;
            if (areasDictionary == null || !areasDictionary.Any())
            {
                CreateSitkaTableRouteEntry(controllerActionMethod, appendParameters, routeAttribute, action, controller, routeName, sitkaRouteEntries, controllerPartForUrl, null, null, false);
            }
            else
            {
                if (isCrossAreaRoute)
                {
                    foreach (var areaKey in areasDictionary.Keys)
                    {
                        CreateSitkaTableRouteEntry(controllerActionMethod,
                            appendParameters,
                            routeAttribute,
                            action,
                            controller,
                            routeName,
                            sitkaRouteEntries,
                            controllerPartForUrl,
                            areaKey,
                            areasDictionary[areaKey],
                            true);
                    }
                }
                else
                {
                    var area = SitkaController.ControllerTypeToAreaName(controllerActionMethod.ReflectedType);
                    Check.Require(areasDictionary.ContainsKey(area), string.Format("Area \"{0}\" not found in Areas Dictionary!", area));
                    var areaAsSubdomainName = areasDictionary[area];
                    CreateSitkaTableRouteEntry(controllerActionMethod,
                        appendParameters,
                        routeAttribute,
                        action,
                        controller,
                        routeName,
                        sitkaRouteEntries,
                        controllerPartForUrl,
                        area,
                        areaAsSubdomainName,
                        false);
                }
            }
            return sitkaRouteEntries;
        }

        private static void CreateSitkaTableRouteEntry(MethodInfo controllerActionMethod, List<ParameterInfo> appendParameters, RouteAttribute routeAttribute, string action, string controller, string routeName, List<SitkaRouteTableEntry> sitkaRouteEntries, string controllerPartForUrl, string area, string areaAsSubdomainName, bool isCrossAreaRoute)
        {
            var routeNameWithArea = !string.IsNullOrWhiteSpace(area) ? $"{area}_{routeName}" : routeName;
            var routeVariants = CalculateRouteParameterPermutationsAppend(appendParameters);
            if (routeAttribute != null)
            {
                var routeEntry = CreateSitkaTableRouteEntry(controllerActionMethod, action, controller, area, areaAsSubdomainName, routeAttribute.Template, routeNameWithArea, routeAttribute.Order, isCrossAreaRoute);
                sitkaRouteEntries.Add(routeEntry);
            }
            else
            {
                for (var i = 0; i < routeVariants.Count; i++)
                {
                    var routeUrl = $"{controllerPartForUrl}/{action}{routeVariants[i]}";
                    var calculatedRouteName = $"{routeNameWithArea}__{i:0000}";
                    var routeEntry = CreateSitkaTableRouteEntry(controllerActionMethod, action, controller, area, areaAsSubdomainName, routeUrl, calculatedRouteName, null, isCrossAreaRoute);
                    sitkaRouteEntries.Add(routeEntry);
                }
            }
        }

        private static SitkaRouteTableEntry CreateSitkaTableRouteEntry(MethodInfo controllerActionMethod, string action, string controller, string area, string areaAsSubdomainName, string routeUrl, string routeName, int? routeOrder, bool isCrossAreaRoute)
        {
            var routeEntry = new SitkaRouteTableEntry(routeName, routeUrl, controllerActionMethod.ReflectedType.Namespace, controller, action, area, areaAsSubdomainName, routeOrder, isCrossAreaRoute);
            return routeEntry;
        }

        public static bool IsRestrictedToPost(MethodInfo a)
        {
            var acceptVerb = (AcceptVerbsAttribute)a.GetCustomAttributes(typeof(AcceptVerbsAttribute), false).FirstOrDefault();
            var isRestrictedToPostByAcceptVerbs = false;
            if (acceptVerb != null)
            {
                isRestrictedToPostByAcceptVerbs = acceptVerb.Verbs.Count == 1 && acceptVerb.Verbs.First().ToLower() == HttpVerbs.Post.ToString().ToLower();
            }

            return (a.GetCustomAttributes(typeof(HttpPostAttribute), false).Any() || isRestrictedToPostByAcceptVerbs)
                    && 
                   (!a.GetCustomAttributes(typeof(HttpGetAttribute), false).Any());
        }

        private static void AssertOptionalParametersAreOnlyAtEndOfRoute(string routeName, IEnumerable<ParameterInfo> parameters)
        {
            bool requireOptionalsNow = false;
            foreach (var p in parameters)
            {
                if (requireOptionalsNow)
                {
                    Check.Require(IsOptionalRouteType(p.ParameterType), $"Unreachable route found for action \"{routeName}\"");
                }
                else
                {
                    requireOptionalsNow = IsOptionalRouteType(p.ParameterType) && p.ParameterType != typeof(String);
                }
            }
        }

        private static List<string> CalculateRouteParameterPermutationsAppend(IEnumerable<ParameterInfo> parameters)
        {
            var paramList = new List<ParameterInfo>(parameters);
            var parameterList = new List<string>();

            while (true)
            {
                var parametersAsUrlFragment = paramList.JoinCsv("/", p => $"{{{p.Name}}}");
                parameterList.Add(parametersAsUrlFragment);

                var info = paramList.LastOrDefault();
                if (info == null || !IsOptionalRouteType(info.ParameterType))
                {
                    break;
                }
                paramList.Remove(info);
            }
            return parameterList;
        }

        private static List<string> CalculateRouteParameterPermutationsPrepend(IEnumerable<ParameterInfo> parameters)
        {
            var paramList = new List<ParameterInfo>(parameters);
            var parameterList = new List<string>();

            while (true)
            {
                var parameterUrl = string.Join("", paramList.Select(s => string.Format("{1}{0}", "/", ((Func<ParameterInfo, string>) (p => $"{{{p.Name}}}"))(s))).ToList());
                parameterList.Add(parameterUrl);

                var info = paramList.LastOrDefault();
                if (info == null || !IsOptionalRouteType(info.ParameterType))
                {
                    break;
                }
                paramList.Remove(info);
            }
            return parameterList;
        }

        public static bool IsOptionalRouteType(Type type)
        {
            return (type == typeof(string)) || (type.IsNullableType());
        }

        public static void Build(IEnumerable<MethodInfo> allActions)
        {
            Build(allActions, null, new Dictionary<string, string>());
        }

        public static void Build(IEnumerable<MethodInfo> allActions, List<SitkaRouteTableEntry> defaultRoutes, Dictionary<string, string> areasDictionary, bool forceReload = false)
        {
            if (!_hasRouteTableBeenBuiltYet || forceReload)
            {
                // If we've loaded before, and we are forcibly reloading..
                if (_hasRouteTableBeenBuiltYet && forceReload)
                {
                    // Clear prior routes first.
                    ClearRoutes();
                }
                var builder = new RouteTableBuilder(RouteTable.Routes, defaultRoutes, areasDictionary);
                builder.SetupRouteTable(allActions);
                _hasRouteTableBeenBuiltYet = true;
            }
        }
    }
}
