using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LtInfo.Common
{
    internal static class DomainRegexCache
    {
        // since we're often going to have the same pattern used in multiple routes, it's best to build just one regex per pattern
        private static readonly ConcurrentDictionary<string, Regex> DomainRegexes = new ConcurrentDictionary<string, Regex>();

        internal static Regex CreateDomainRegex(string domain)
        {
            return DomainRegexes.GetOrAdd(domain, (d) =>
            {
                d = d.Replace("/", @"\/")
                     .Replace(".", @"\.")
                     .Replace("-", @"\-")
                     .Replace("{", @"(?<")
                     .Replace("}", @">(?:[a-zA-Z0-9_-]+))");

                return new Regex("^" + d + "$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);
            });
        }
    }


    public class DomainRoute : Route
    {
        public readonly SitkaRouteTableEntry SitkaRouteTableEntry;
        private const string DomainRouteMatchKey = "DomainRoute.Match";
        private const string DomainRouteInsertionsKey = "DomainRoute.Insertions";
        private readonly Regex _domainRegex;

        public readonly string Domain;

        public DomainRoute(SitkaRouteTableEntry sitkaRouteTableEntry, string[] namespaces)
            : base(
                sitkaRouteTableEntry.RouteUrl,
                new RouteValueDictionary(new { controller = sitkaRouteTableEntry.Controller, action = sitkaRouteTableEntry.Action, sitkaRouteTableEntry.Area }),
                null,
                new RouteValueDictionary(
                    new {Namespaces = namespaces, sitkaRouteTableEntry.Area, UseNamespaceFallback = false, Domain = sitkaRouteTableEntry.AreaAsSubdomainName, sitkaRouteTableEntry.IsCrossAreaRoute}),
                new MvcRouteHandler())
        {
            SitkaRouteTableEntry = sitkaRouteTableEntry;
            Domain = sitkaRouteTableEntry.AreaAsSubdomainName;
            _domainRegex = DomainRegexCache.CreateDomainRegex(Domain);
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestDomain = httpContext.Request.Url.Host;

            var domainMatch = _domainRegex.Match(requestDomain);
            if (!domainMatch.Success)
                return null;

            var existingMatch = httpContext.Items[DomainRouteMatchKey] as string;

            if (existingMatch == null)
                httpContext.Items[DomainRouteMatchKey] = Domain;
            else if (existingMatch != Domain)
                return null;

            var data = base.GetRouteData(httpContext);
            if (data == null)
                return null;

            var myInsertions = new HashSet<string>();

            for (var i = 1; i < domainMatch.Groups.Count; i++)
            {
                var group = domainMatch.Groups[i];
                if (group.Success)
                {
                    var key = _domainRegex.GroupNameFromNumber(i);
                    if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(group.Value))
                    {
                        // could throw here if data.Values.ContainsKey(key) if we wanted to prevent multiple matches
                        data.Values[key] = group.Value;
                        myInsertions.Add(key);
                    }
                }
            }

            httpContext.Items[DomainRouteInsertionsKey] = myInsertions;
            return data;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            var virtualPathData = base.GetVirtualPath(requestContext, RemoveDomainTokens(requestContext, values));
            return virtualPathData;
        }

        private RouteValueDictionary RemoveDomainTokens(RequestContext requestContext, RouteValueDictionary values)
        {
            var myInsertions = requestContext.HttpContext.Items[DomainRouteInsertionsKey] as HashSet<string>;

            if (myInsertions != null)
            {
                foreach (var key in myInsertions)
                {
                    if (values.ContainsKey(key))
                        values.Remove(key);
                }
            }

            return values;
        }
    }
}