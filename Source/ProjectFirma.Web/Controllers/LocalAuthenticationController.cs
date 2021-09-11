/*-----------------------------------------------------------------------
<copyright file="HomeController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.LocalAuthentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common;

namespace ProjectFirma.Web.Controllers
{
    public class LocalAuthenticationController : FirmaBaseController
    {
        private const string NotSitkaAuthErrorMessage = "Can't use Firma Self Auth in Keystone mode";

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult LocalAuthLogon()
        {
            RequireLocalAuthMode();
            return LoginChallengeImpl();
        }

        [HttpPost]
        [AnonymousUnclassifiedFeature]
        public ActionResult LocalAuthLogon(LocalAuthLogonViewModel viewModel)
        {
            RequireLocalAuthMode();
            SitkaHttpApplication.Logger.Info($"LocalAuthenticationController - LocalAuthLogon() - AuthType:{FirmaWebConfiguration.AuthenticationType}");
            DateTime currentDateTime = DateTime.Now;

            var personLoginAccount = ProjectFirmaModels.SecurityUtil.UserAuthentication.Validate(HttpRequestStorage.DatabaseEntities, viewModel.UserName, viewModel.Password, this.CurrentTenant.TenantID);
            if (personLoginAccount == null)
            {
                string invalidLoginGenericMessage = $"Bad user name or password";
                SetErrorForDisplay(invalidLoginGenericMessage);
                return new RedirectResult(SitkaRoute<LocalAuthenticationController>.BuildUrlFromExpression(c => c.LocalAuthLogon()));
            }

            // PersonLoginAccount may have changed (for example, login count may have incremented)
            // But since we have no current Person, we need to use the "No Audit" SaveChanges function.
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(CurrentFirmaSession.TenantID);

            FirmaOwinStartup.MakeFirmaSessionForPersonLoggingIn(personLoginAccount.Person, currentDateTime);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, HttpRequestStorage.FirmaSession.FirmaSessionGuid.ToString()));
            var id = new ClaimsIdentity(claims, FirmaOwinStartup.CookieAuthenticationType);
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(id);

            SitkaHttpApplication.Logger.Info($"LocalAuthenticationController - Logged In PersonID:{personLoginAccount.PersonID}, email:{personLoginAccount.Person.Email}");
            // Just show home page for now..
            return new RedirectResult(SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index()));
        }

        public static void RequireLocalAuthMode()
        {
            // Make sure we are in the right mode to support Local Authentication
            Check.Require(FirmaWebConfiguration.AuthenticationType == AuthenticationType.LocalAuth, "Authentication Type is not configured correctly for this page.");
        }


        private ActionResult LoginChallengeImpl()
        {
            var localAutoLogonViewData = new LocalAuthLogonViewData(this.CurrentFirmaSession);
            var localAutoLogonViewModel = new LocalAuthLogonViewModel();

            return RazorView<LocalAuthLogon, LocalAuthLogonViewData, LocalAuthLogonViewModel>(localAutoLogonViewData, localAutoLogonViewModel);
        }

    }
}
