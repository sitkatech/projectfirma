/*-----------------------------------------------------------------------
<copyright file="SitkaRouteTableEntry.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
