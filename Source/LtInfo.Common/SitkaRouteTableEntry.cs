using System;

namespace LtInfo.Common
{
    public class SitkaRouteTableEntry
    {
        public readonly bool IsCrossAreaRoute;
        public readonly string RouteName;
        public readonly string RouteUrl;
        public string AreaAsSubdomainName;
        public string Area;
        public readonly string Namespace;
        public readonly string Controller;
        public readonly string Action;
        public readonly int? RouteOrder;

        public SitkaRouteTableEntry(string routeName, string routeUrl, string ns, string controller, string action, int? order) : this(routeName, routeUrl, ns, controller, action, null, null, order, false)
        {
        }

        public SitkaRouteTableEntry(string routeName, string routeUrl, string ns, string controller, string action, string area, string areaAsSubdomainName, int? routeOrder, bool isCrossAreaRoute)
        {
            IsCrossAreaRoute = isCrossAreaRoute;
            RouteName = routeName;
            RouteUrl = routeUrl;
            Namespace = ns;
            Controller = controller;
            Action = action;
            Area = area;
            AreaAsSubdomainName = areaAsSubdomainName;
            RouteOrder = routeOrder;
        }

        // for debug purposes
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Area))
                return String.Format("{0}\t{1}\t{2}\t{3}", RouteName, RouteUrl, Controller, Action);

            return String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", RouteName, RouteUrl, Area, AreaAsSubdomainName, Controller, Action);
        }
    }
}