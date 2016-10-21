using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using FluentValidation.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using Keystone.Common;
using Microsoft.IdentityModel.Web;
using Microsoft.IdentityModel.Web.Configuration;

namespace ProjectFirma.Web
{
    public class Global : SitkaGlobalBase
    {
        public static Dictionary<string, string> AreasDictionary = new Dictionary<string, string>
        {
            {string.Empty, ProjectFirmaWebConfiguration.CanonicalHostNameRoot},
            {LTInfoArea.EIP.LTInfoAreaName, ProjectFirmaWebConfiguration.CanonicalHostNameEIP},
            {LTInfoArea.Sustainability.LTInfoAreaName, ProjectFirmaWebConfiguration.CanonicalHostNameSustainability},
            {LTInfoArea.ParcelTracker.LTInfoAreaName, ProjectFirmaWebConfiguration.CanonicalHostNameParcelTracker},
            {LTInfoArea.Threshold.LTInfoAreaName, ProjectFirmaWebConfiguration.CanonicalHostNameThresholds}
        };

        protected void Application_Start()
        {
            SitkaLogger.RegisterLogger(new LakeTahoeInfoLogger());

            // this needs to match the Area Name declared in the Areas folder

            // create the default routes for the app and the areas
            var defaultRoutes =
                AreasDictionary.Select(
                    keyValuePair =>
                        new SitkaRouteTableEntry(string.Format("{0}_Default", keyValuePair.Key),
                            String.Empty,
                            string.Format("ProjectFirma.Web{0}.Controllers", !string.IsNullOrWhiteSpace(keyValuePair.Key) ? string.Format(".Areas.{0}", keyValuePair.Key) : string.Empty),
                            SitkaController.DefaultController,
                            SitkaController.DefaultAction,
                            keyValuePair.Key,
                            keyValuePair.Value,
                            null,
                            false)).ToList();

            ApplicationStart("ProjectFirma",
                LtInfoWebConfiguration.WebApplicationVersionInfo.Value.ApplicationVersion,
                LtInfoWebConfiguration.WebApplicationVersionInfo.Value.DateCompiled,
                LakeTahoeInfoBaseController.AllControllerActionMethods,
                new List<string>
                {
                    "~/Views/Shared/TextControls/{0}.cshtml",
                    "~/Areas/EIP/Views/Shared/ExpenditureAndBudgetControls/{0}.cshtml",
                    "~/Areas/EIP/Views/Shared/EIPPerformanceMeasureControls/{0}.cshtml",
                    "~/Areas/EIP/Views/Shared/ProjectControls/{0}.cshtml",
                    "~/Areas/EIP/Views/Shared/ProjectLocationControls/{0}.cshtml",
                    "~/Areas/EIP/Views/Shared/ProjectUpdateDiffControls/{0}.cshtml"
                }, defaultRoutes, AreasDictionary);

            // we need to explicitly add the hangfire route
            RouteTableBuilder.AddToRouteTable(new SitkaRouteTableEntry("Hangfire", "hangfire", "ProjectFirma.Web.Controllers", "Home", "hangfire", null, ProjectFirmaWebConfiguration.CanonicalHostNameRoot, null, false));

            Logger.InfoFormat("Latest Database Migration: {0}", ProjectFirmaWebConfiguration.LatestDatabaseMigration.Value);
            RegisterGlobalFilters(GlobalFilters.Filters);
            FluentValidationModelValidatorProvider.Configure();

            FederatedAuthentication.ServiceConfigurationCreated += FederatedAuthentication_ServiceConfigurationCreated;
        }

        // ReSharper disable InconsistentNaming
        protected static void FederatedAuthentication_ServiceConfigurationCreated(object sender, ServiceConfigurationCreatedEventArgs e)
        // ReSharper restore InconsistentNaming
        {
            var sessionHandler = new KeystoneSessionSecurityTokenHandler();
            e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(sessionHandler);
        }


        // ReSharper disable InconsistentNaming
        protected void Session_Start(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            // keep this seeming no-op line - it prevents "): Session state has created a session id, but cannot save it because the response was already flushed by the application." errors
#pragma warning disable 168
            var sessionID = Session.SessionID;
#pragma warning restore 168
        }

        // ReSharper disable InconsistentNaming
        protected void Application_Error(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            ApplicationError();
        }

        // ReSharper disable InconsistentNaming
        protected void Application_BeginRequest(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            KeystoneUtilities.SignOutOnBadCookie(Request, Response);

            // Call this in Application_BeginRequest because later on it can be too late to be mucking with the Response HTTP Headers
            AddCachingHeaders(Response, Request, LtInfoWebConfiguration.CacheStaticContentTimeSpan);

            ApplicationBeginRequest();
        }

        /// <summary>
        /// Try to log anything that's an error that's slipped past <see cref="Application_Error"/> such as certain errors from a webservice
        /// Like the <see cref="HttpStatusCode.UnsupportedMediaType"/> 415 which comes up if there's a SOAP binding mismatch
        /// </summary>
        // ReSharper disable InconsistentNaming
        protected void Application_EndRequest(object sender, EventArgs e)
        // ReSharper restore InconsistentNaming
        {
            ApplicationEndRequest();
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Require SSL from this point forward
            filters.Add(new RequireHttpsAttribute());
        }

        public override string ErrorUrl
        {
            get { return SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Error(), ProjectFirmaWebConfiguration.CanonicalHostNameRoot); }
        }

        public override string NotFoundUrl
        {
            get { return SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(x => x.NotFound(), ProjectFirmaWebConfiguration.CanonicalHostNameRoot); }
        }

        public override string ErrorHtml
        {
            get { return "<h2>Aw Shucks!</h2><p>An error has occurred.   The development staff has been notified and will be working to fix this problem in a jiffy!</p>"; }
        }

        public override string NotFoundHtml
        {
            get { return "<h2>Aw Shucks!</h2><p>Sorry, the page or item you requested does not exist.</p>"; }
        }
    }
}