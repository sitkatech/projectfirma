/*-----------------------------------------------------------------------
<copyright file="SitkaControllerObsoleteFunctions.cs" company="Sitka Technology Group">
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
using System.Web.Mvc;
using System.Web.Routing;

namespace LtInfo.Common
{
    public partial class SitkaController
    {
        public const string ObsoleteMessage = "Use strongly typed versions instead that take compile time route expressions. These versions are here to serve as warnings to *not* use these.";

        [Obsolete(ObsoleteMessage)]
        protected new PartialViewResult PartialView(string viewName, object model)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        [Obsolete(ObsoleteMessage)]
        protected new PartialViewResult PartialView(string viewName)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToAction(string actionName)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToAction(string actionName, object untypedcrap)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToAction(string actionName, RouteValueDictionary untypedcrap)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToAction(string actionName, string controllerName)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToAction(string actionName, string controllerName, object untypedcrap)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToRoute(object untyped)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToRoute(string routeName)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToRoute(RouteValueDictionary routeValues)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToRoute(string routeName, RouteValueDictionary routeValues)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new RedirectToRouteResult RedirectToRoute(string routeName, object routeValues)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View()
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(IView x)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(object x)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(string viewName)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(string viewName, string master)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(string viewName, string master, object untypedstuff)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(IView view, object model)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }

        /// <summary>
        /// These obsoleted overloads need to stick around - they are required to keep us honest in our controllers since we don't want to use these methods - we should be using the strongly typed versions instead!
        /// </summary>
        [Obsolete(ObsoleteMessage)]
        protected new ViewResult View(string viewName, object model)
        {
            throw new InvalidOperationException(ObsoleteMessage);
        }


    }
}
