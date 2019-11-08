/*-----------------------------------------------------------------------
<copyright file="AccountController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Controllers
{
    public class AccountController : SitkaController
    {
        protected string HomeUrl
        {
            // Fully-qualified due to ambiguous reference.
            get { return SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(c => c.Index()); }
        }

        protected override bool IsCurrentUserAnonymous()
        {
            return HttpRequestStorage.FirmaSession.IsAnonymousUser();
        }

        protected override string LoginUrl
        {
            get { return SitkaRoute<AccountController>.BuildAbsoluteUrlHttpsFromExpression(c => c.LogOn()); }
        }

        [LoggedInUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult LogOn()
        {
            //look up cookie and return to url we were previously on, otherwise homepage.
            var returnUrl = Request.Cookies["ReturnURL"];

            if (!string.IsNullOrWhiteSpace(returnUrl?.Value))
            {
                returnUrl.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(returnUrl);

                return Redirect(HttpUtility.UrlDecode(returnUrl.Value));
            }

            // placeholder route - since url is secured, authorize filter should redirect to SSO flow (since no EM.Common.Keystone.AllowAnonymous attribute)
            return Redirect(HomeUrl);
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult LogOff()
        {
            // If we are impersonating, we drop back to the original user instead of fully logging out.
            var currentFirmaSession = HttpRequestStorage.FirmaSession;
            if (currentFirmaSession.IsImpersonating())
            {
                var previousPageUri = Request.UrlReferrer;
                currentFirmaSession.ResumeOriginalUser(previousPageUri, out string statusMessage);
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(currentFirmaSession.Person.TenantID);
                //TaurusSecurityLogger.Info(this.TaurusSession, statusMessage);
                SetInfoForDisplay(statusMessage);
                return Redirect("/");
            }

            // Otherwise, we just log off normally
            Request.GetOwinContext().Authentication.SignOut();
            var currentPerson = HttpRequestStorage.Person;
            currentFirmaSession.Delete(HttpRequestStorage.DatabaseEntities);
            HttpRequestStorage.DatabaseEntities.SaveChanges(currentPerson);
            return Redirect("/");
        }

        [AnonymousUnclassifiedFeature]
        public ActionResult SignoutCleanup(string sid)
        {
            var cp = (ClaimsPrincipal)HttpContext.User;
            var sidClaim = cp.FindFirst("sid");
            if (sidClaim != null && sidClaim.Value == sid)
            {
                Request.GetOwinContext().Authentication.SignOut("Cookies");
            }

            return Content(string.Empty);
        }

        protected override ISitkaDbContext SitkaDbContext => HttpRequestStorage.DatabaseEntities;

        // also need to decide how to handle account verification status and also implement hash on db row to avoid unnecessary updates
        [AnonymousUnclassifiedFeature]
        public ContentResult NotAuthorized()
        {
            return Content("Not Authorized");
        }
    }
}
