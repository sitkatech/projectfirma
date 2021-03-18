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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LtInfo.Common;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Home;
using ProjectFirma.Web.Views.LocalAuthentication;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Controllers
{
    public class LocalAuthenticationController : FirmaBaseController
    {
        private const string NotSitkaAuthErrorMessage = "Can't use Firma Self Auth in Keystone mode";

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult LocalAuthLogon()
        {
            // Make sure we are in the right mode to support Local Authentication
            var currentTenantAttributes = MultiTenantHelpers.GetTenantAttributeFromCache();
            if (currentTenantAttributes.FirmaSystemAuthenticationType != FirmaSystemAuthenticationType.FirmaSelfAuth)
            {
                // Throw up error message, go to home page
                SetErrorForDisplay(NotSitkaAuthErrorMessage);
                return new RedirectResult(SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index()));
            }

            return LoginChallengeImpl(null);
        }

        [HttpPost]
        [AnonymousUnclassifiedFeature]
        public ActionResult LocalAuthLogon(LocalAuthLogonViewModel viewModel)
        {
            ThrowErrorIfNotInSitkaAuthMode();

            var personLoginAccount = ProjectFirmaModels.SecurityUtil.UserAuthentication.Validate(HttpRequestStorage.DatabaseEntities, viewModel.UserName, viewModel.Password);
            if (personLoginAccount == null)
            {
                string invalidLoginGenericMessage = $"Bad login or password";
                SetErrorForDisplay(invalidLoginGenericMessage);
                return new RedirectResult(SitkaRoute<LocalAuthenticationController>.BuildUrlFromExpression(c => c.LocalAuthLogon()));
            }

            // PersonLoginAccount may have changed (for example, login count may have incremented)
            //HttpRequestStorage.DatabaseEntities.SaveChanges();
            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(CurrentFirmaSession.TenantID);

            /*
            var urlIsRedirectable = !String.IsNullOrWhiteSpace(viewModel.RedirectUrl);
            try
            {
                Context.SignIn(viewModel.LogonName, viewModel.Password);
                // Verbiage here uses strings "Logon" and "Login" to aid searching. The use of both terms is deliberate.
                TaurusSecurityLogger.Info(TaurusSession, $"Logon successful - Login for Pisces Web User {TaurusWebSession.BuildLogonLogoffDescriptorString(TaurusSession)} succeeded");
                UserController.ShowPasswordAboutToExpireSoonWarningIfApplicable(this.Context, Logger);
                // If they get this far, they've successfully signed in, and we can impersonate if needed.
                HandleImpersonationDuringLogin(viewModel);
            }
            catch (TaurusNoTestAccessException)
            {
                string noQaMessage = "Your account does not have access to QA.";
                Context.AddWarning(noQaMessage);
                TaurusSecurityLogger.Info(this.TaurusSession, noQaMessage);
                return View<Login, LoginViewData, LoginViewModel>(new LoginViewData(TaurusSession, urlIsRedirectable), viewModel);
            }
            catch (TaurusPasswordExpiredException)
            {
                // Since the user here should have already provided the correct, but expired, password, it seems
                // appropriate to give them additional detail about the failure reason. They've already effectively logged in.
                // -- SLG 6/18/2019
                var secUserAttemptingToLogin = SecUsers.GetSecUserByLogon(viewModel.LogonName);
                var expiredUrl = SitkaRoute<UserController>.BuildAbsoluteUrlHttpsFromExpression(c => c.UserChangePasswordForUser(secUserAttemptingToLogin.SecUserID));

                string additionalWarningDetail = String.Empty;
                if (secUserAttemptingToLogin.PasswordMustBeChangedOnNextLogin)
                {
                    additionalWarningDetail = "Your account has been marked as requiring a password change before you can log in.";
                }
                else if (secUserAttemptingToLogin.PasswordHasExceededPasswordExpirationDays())
                {
                    additionalWarningDetail = $"Passwords must be changed every {TaurusHttpRequestStorage.PwdExpirationDays} days. Your password has not been changed in {secUserAttemptingToLogin.TimeSpanSinceLastUpdatedPassword().Days} days. ";
                }

                string completeWarningMessage = $"You must change your password. {additionalWarningDetail}";
                Context.AddWarning(completeWarningMessage);

                return new RedirectResult(expiredUrl);
            }
            catch (TaurusLoginException ex)
            {
                WarnAboutDefaultPasswordIfNeeded(viewModel.Password);

                Context.AddError(ex.Message);
                TaurusSecurityLogger.Info(this.TaurusSession, ex.Message);
                return View<Login, LoginViewData, LoginViewModel>(new LoginViewData(TaurusSession, urlIsRedirectable), viewModel);
            }
            if (!ModelState.IsValid)
            {
                return View<Login, LoginViewData, LoginViewModel>(new LoginViewData(TaurusSession, urlIsRedirectable), viewModel);
            }

            // make sure the user has at least one personal portfolio
            // ReSharper disable once PossibleInvalidOperationException
            var myPortfolios = Portfolios.GetPersonalPortfolios(TaurusSession.PersonID.Value);
            if (!myPortfolios.Any())
            {
                PortfoliosHelper.CreatePersonalPortfolio(TaurusSession.Person);
            }

            if (urlIsRedirectable)
            {
                return new RedirectResult(viewModel.RedirectUrl);
            }

            if (!String.IsNullOrEmpty(viewModel.ProjectOrContractNumber))
            {
                return RedirectToProjectOrContractSearchResults(viewModel.OpenType, viewModel.ProjectOrContractNumber, TaurusSession);
            }
            if (TaurusSession.PersonSetting != null && TaurusSession.PersonSetting.DefaultStartPageID.HasValue)
            {
                var defaultStartPage = TaurusSession.PersonSetting.DefaultStartPage;
                if (defaultStartPage == DefaultStartPage.Projects)
                {
                    return new RedirectResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Index(null)));
                }
                if (defaultStartPage == DefaultStartPage.Contracts)
                {
                    return new RedirectResult(SitkaRoute<ContractController>.BuildUrlFromExpression(c => c.Index()));
                }
                if (defaultStartPage == DefaultStartPage.ProjectsAndContracts)
                {
                    return new RedirectResult(SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Landing()));
                }
                if (defaultStartPage == DefaultStartPage.Home)
                {
                    return new RedirectResult(SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index()));
                }
            }

            return new RedirectResult(SitkaRoute<DashboardController>.BuildUrlFromExpression(c => c.Index()));
            */

            // Just show home page for now..
            return new RedirectResult(SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index()));
        }

        private static void ThrowErrorIfNotInSitkaAuthMode()
        {
            // Make sure we are in the right mode to support Local Authentication
            var currentTenantAttributes = MultiTenantHelpers.GetTenantAttributeFromCache();
            if (currentTenantAttributes.FirmaSystemAuthenticationType != FirmaSystemAuthenticationType.FirmaSelfAuth)
            {
                throw new SitkaDisplayErrorException(NotSitkaAuthErrorMessage);
            }
        }


        private ActionResult LoginChallengeImpl(string loginName)
        {
            string urlToRedirectTo = CalculateURLToRedirectTo();

            // Gemini style
            /*
            bool urlIsRedirectable = !String.IsNullOrWhiteSpace(urlToRedirectTo);
            var loginViewData = new LoginViewData(TaurusSession, urlIsRedirectable);
            var viewModel = new LoginViewModel(loginName, urlToRedirectTo);
            return View<LocalAuthLogon, LocalAuthLogonViewData, LocalAuthLogonViewModel>(loginViewData, viewModel);
            */

            var localAutoLogonViewData = new LocalAuthLogonViewData(this.CurrentFirmaSession);
            var localAutoLogonViewModel = new LocalAuthLogonViewModel();

            return RazorView<LocalAuthLogon, LocalAuthLogonViewData, LocalAuthLogonViewModel>(localAutoLogonViewData, localAutoLogonViewModel);
        }

        private string CalculateURLToRedirectTo()
        {
            string urlToRedirectTo = null;
            /*
            // If we've got something rigged up with return URL, use that first
            urlToRedirectTo = CleanHostnameFromRedirectUrl(Request.QueryString[SitkaController.ReturnUrlParameter]);

            // Redirect to just "/" doesn't count
            urlToRedirectTo = urlToRedirectTo == "/" ? "" : urlToRedirectTo;

            var urlForRedirectIsNullOrWhiteSpace = String.IsNullOrWhiteSpace(urlToRedirectTo);
            // else if there's not already a url to redirect to in place, see if we can use the referrer
            // ReSharper disable once PossibleNullReferenceException
            if (urlForRedirectIsNullOrWhiteSpace && Request.UrlReferrer != null && Request.UrlReferrer.Host == Request.Url.Host)
            {
                var dontCountTheseUrlPathsForRedirection = new List<string>
                {
                    "/" + ControllerTypeToControllerNameForUrl(typeof(HomeController)), "/" + ControllerTypeToControllerNameForUrl(typeof(HelpController)), SetWebBrowserAutomationCookie.Url
                };

                var path = Request.UrlReferrer.AbsolutePath;

                if (!dontCountTheseUrlPathsForRedirection.Any(x => path.StartsWith(x, StringComparison.InvariantCultureIgnoreCase)) && path != "/")
                {
                    urlToRedirectTo = Request.UrlReferrer.ToString();
                }
            }
            */

            return urlToRedirectTo;
        }
    }
}
