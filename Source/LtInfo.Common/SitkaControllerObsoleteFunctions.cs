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