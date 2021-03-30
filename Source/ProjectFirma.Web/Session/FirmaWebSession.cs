using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Web.Mvc.Filters;
using DocumentFormat.OpenXml.Office2013.Word;
using log4net;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using Person = ProjectFirmaModels.Models.Person;

namespace ProjectFirma.Web.Session
{
    public class FirmaWebSession
    {
        public const string FirmaSessionBaseCookieName = "__Host-FirmaSessionCookie";
        //private readonly ITaurusHttpContext _taurusHttpContext;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(FirmaWebSession));

        
        //public FirmaWebSession(/*ITaurusHttpContext taurusHttpTaurusHttpContext*/WebRequestMethods.Http)
        /*
        {
            //_taurusHttpContext = taurusHttpTaurusHttpContext;

            if (_taurusHttpContext.SessionCookieExistsAndIsValid())
            {
                var FirmaSessionGuid = TaurusHttpContextHelper.ParseSessionCookie(_context.Request.Cookies[TaurusWebSession.TaurusSessionCookieName]);
                var taurusSessionGuid = _taurusHttpContext.SessionCookieTaurusSessionGuidGet();
                TaurusSession = TaurusSession.GetTaurusSessionByTaurusSessionGuid(taurusSessionGuid);
                if (TaurusSession != null)
                {
                    SetSessionToContextAndThread();
                    TaurusSession.Save();
                    return;
                }
            }
            else
            {
                TaurusSession = TaurusSession.MakeAnonymousSession(taurusHttpTaurusHttpContext.UserIpAddress);
            }
            SetToAnonymousSession(taurusHttpTaurusHttpContext.UserIpAddress);
        }
        */

        public static string GetTenantizedFirmaSessionCookieName(Tenant tenant)
        {
            return $"{FirmaSessionBaseCookieName}_tenant_{tenant.TenantID}";
        }

        public static FirmaSession GetSessionFromCookie(AuthenticationContext filterContext, Tenant currentTenant)
        {
            var httpCookieCollection = filterContext.RequestContext.HttpContext.Request.Cookies;
            if (TaurusHttpContextHelper.IsSessionCookiePresentAndValid(currentTenant, httpCookieCollection))
            {
                //var FirmaSessionGuid = TaurusHttpContextHelper.ParseSessionCookie(_context.Request.Cookies[TaurusWebSession.TaurusSessionCookieName]);
                var FirmaSessionGuid = TaurusHttpContextHelper.ParseSessionCookie(httpCookieCollection[GetTenantizedFirmaSessionCookieName(currentTenant)]);

            }

            // HACK just to get airborne!
            // Otherwise, anonymous user. We make a new session each time, which seems flawed - but not sure how else to handle yet. -- SLG
            var firmaSessionForAnonymousPerson = FirmaSession.MakeEmptyFirmaSession(HttpRequestStorage.DatabaseEntities, HttpRequestStorage.Tenant);
            return firmaSessionForAnonymousPerson;
        }


        /*
        private void SetToAnonymousSession(string optionalIpAddress = null)
        {
            TaurusSession = TaurusSession.MakeAnonymousSession(optionalIpAddress);
            TaurusSession.Save();
            SetSessionToCookieAndContextAndThread();
        }

        public object this[string name]
        {
            get => _taurusHttpContext.GetSessionObject(name);
            set => _taurusHttpContext.SetSessionObject(name, value);
        }

        public TaurusSession TaurusSession { get; private set; }

        public string UserIpAddress => _taurusHttpContext.UserIpAddress;

        public bool Contains(string name)
        {
            return this[name] != null;
        }

        /// <summary>
        /// Central point for all the steps need to sign in.
        /// </summary>
        public void SignIn(string logonName, string password)
        {
            LoginViaTaurusAuthenticationAndAssignPersonToTaurusSession(logonName, password, TaurusSession);
            SetSessionToContextAndThread();
        }

        /// <summary>
        /// Central point for all steps needed to sign out. Can be called repeatedly without ill effect. Will reset a partially logged in <see cref="TaurusSession"/> to be fully logged out.
        /// </summary>
        public void SignOut()
        {
            // Tear down anything existing
            // ---------------------------

            // Stash these for reference before we kill the session
            string userDescriptorString = BuildLogonLogoffDescriptorString(TaurusSession);
            string ipAddress = TaurusSession.IpAddress;

            TaurusSession.Delete();
            _taurusHttpContext.SessionAbandon();

            // Verbiage here uses strings "Logout" and "Logoff" to aid searching. The use of both terms is deliberate.
            Logger.InfoFormat("Logoout successful - Logoff for Pisces Web User {0} succeeded", userDescriptorString);

            // Setup a new one as anonymous
            // ----------------------------
            SetToAnonymousSession(ipAddress);
        }

        /// <summary>
        /// Consistent descriptor for Logon/Logoff description, including session GUID
        /// </summary>
        public static string BuildLogonLogoffDescriptorString(TaurusSession taurusSession)
        {
            string logonName = taurusSession.LogonName ?? TaurusSession.AnonymousDisplayString;
            string sessionGuid = taurusSession.TaurusSessionGuid.ToString();
            string userDisplayName = taurusSession.UserDisplayName;
            int loginCount = taurusSession.Person?.SecUser.LoginCount ?? 0;

            return $"[{logonName} - {userDisplayName}] SessionGuid: {sessionGuid}, IPAddress: {taurusSession.IpAddress}, LoginCount: {loginCount}";
        }

        public static TaurusPrincipal SetSessionToThread(TaurusSession taurusSession)
        {
            var principal = new TaurusPrincipal(taurusSession, new TaurusIdentity(taurusSession.TaurusSessionGuid));
            Thread.CurrentPrincipal = principal;
            return principal;
        }

        private void SetSessionToContextAndThread()
        {
            _taurusHttpContext.User = SetSessionToThread(TaurusSession);
        }

        private void SetSessionToCookieAndContextAndThread()
        {
            // Persist into the cookie
            _taurusHttpContext.SessionCookieTaurusSessionGuidSet(TaurusSession.TaurusSessionGuid);

            // Convert this thread over to the user immediately
            SetSessionToContextAndThread();
        }

        /// <summary>
        /// Perform a login against Taurus and setup a taurusSession
        /// </summary>
        public static void LoginViaTaurusAuthenticationAndAssignPersonToTaurusSession(string logonName, string password, TaurusSession taurusSession)
        {
            if (String.IsNullOrWhiteSpace(logonName) || String.IsNullOrWhiteSpace(password))
            {
                throw new TaurusLoginException("Login name and password are required", logonName);
            }
            var secUser = TaurusAuthentication.Authenticate(logonName, password);

            var person = People.GetPerson(secUser.PersonID);
            // Currently, this only gets checked when Pisces is UP but Taurus is DOWN. Otherwise, we fail on the .Authenticate() call above, which is just
            // a Pisces Auth call. Thinking about ways to improve this.
            CheckPiscesSystemStatusForLockoutOfLogins(person);

            // Logon successful, insert the new taurusSession into the Taurus database
            AssignPersonToTaurusSession(person, taurusSession);
        }

        private static void CheckPiscesSystemStatusForLockoutOfLogins(Person person)
        {
            // Taurus logins prevented if the system is down, and the user is not an Admin, or lacks access.
            var taurusSystemStatus = PiscesSystemStatuses.GetPiscesSystemStatuses().Single(gss => gss.PiscesSystem.PiscesSystemName == "TaurusWeb");
            var roles = person.SecUserRoles.Select(pr => pr.SecRole).ToList();
            bool personIsAdmin = roles.Any(r => r.SecRoleID == SecRole.SystemAdministrator.SecRoleID);
            bool personHasBackstageAccess = roles.Any(r => r.SecRoleID == SecRole.PiscesWebDowntimeAccess.SecRoleID);
            bool personIsSmokeTester = roles.Any(r => r.SecRoleID == SecRole.SmokeTester.SecRoleID);
            bool systemIsUp = taurusSystemStatus.SystemIsUp;
            bool canUserLogIn = systemIsUp || personIsAdmin || personHasBackstageAccess || personIsSmokeTester;
            if (!canUserLogIn)
            {
                var lockoutMessage = $"Logins are currently disabled on the CBFish website for non-admins. Current system status: {taurusSystemStatus.SystemStatusDescription}. You can try logging in again in a few minutes. Please email {TaurusWebConfiguration.SupportEmail} if you have any questions.";
                Logger.ErrorFormat("login request for {0} failed with reason \"{1}\"", person.LogonName, lockoutMessage);
                throw new TaurusLoginException(lockoutMessage, person.LogonName);
            }
        }

        /// <summary>
        /// Creates a <see cref="TaurusSession"/> for a <see cref="Person"/>. Should be using <see cref="LoginViaTaurusAuthenticationAndAssignPersonToTaurusSession"/> for main use case.
        /// Background threads will use this
        /// </summary>
        public static void AssignPersonToTaurusSession(Person person, TaurusSession taurusSession)
        {
            Check.EnsureNotNull(person, "Not expecting null person here!");
            taurusSession.Person = person;
            taurusSession.Save();

            if (!(taurusSession.Person.SecUserRoles.Any() || taurusSession.Person.ShouldHaveParticipantRole()))
            {
                const string noAccessMessage = "You do not have permission to access this site";
                Logger.ErrorFormat("login request for {0} failed with reason \"{1}\"", person.LogonName, noAccessMessage);
                throw new TaurusLoginException($"Login failed with reason \"{noAccessMessage}\"", taurusSession.LogonName);
            }

            taurusSession.Person.RecordLogin();
        }

        /// <summary>
        /// Change a CBFish/Pisces's user password when the current password is known and provided.
        /// </summary>
        /// <param name="logonName">Logon name</param>
        /// <param name="currentPassword">Current, valid password</param>
        /// <param name="newPassword">New password to change to</param>
        public static void ChangePasswordWhenPasswordIsKnown(string logonName, string currentPassword, string newPassword)
        {
            TaurusAuthentication.UpdatePassword(logonName, currentPassword, newPassword);
        }

        /// <summary>
        /// Change a CBFish/Pisces's user logon name.
        /// </summary>
        /// <param name="taurusSession">session</param>
        /// <param name="userMakingChanges">SecUser record of the user making changes</param>
        /// <param name="userBeingEdited">SecUser record of the user being edited</param>
        /// <param name="oldLogonName">Old logon name</param>
        /// <param name="newLogonName">New logon name</param>
        public static IEnumerable<ValidationResult> ValidateAndChangeLogonName(TaurusSession taurusSession, SecUser userMakingChanges, SecUser userBeingEdited, string oldLogonName, string newLogonName)
        {
            var personBeingEdited = userBeingEdited.Person;
            new EditPersonContactInfoFeature().DemandPermission(taurusSession, personBeingEdited);

            var validationResults = SecUserValidator.ValidateSecUserLogonNameAndEmailAddress(newLogonName, personBeingEdited.EmailAddress, personBeingEdited.PersonID);
            if (validationResults.Any())
            {
                return validationResults;
            }

            userBeingEdited.LogonName = newLogonName;
            userBeingEdited.SaveLogAll(userMakingChanges);

            return validationResults;
        }

        /// <summary>
        /// Change a CBFish/Pisces user password when the current password is not known, but the user has authenticated that they have
        /// control over the email address for the account.
        /// </summary>
        /// <param name="passwordResetRequest"></param>
        /// <param name="newPassword"></param>
        public static void ChangePasswordWhenUserHasAuthenticatedViaPasswordResetRequest(PasswordResetRequest passwordResetRequest, string newPassword)
        {
            Check.EnsureNotNull(passwordResetRequest);
            bool accountLockedBeforePasswordResetRequest = passwordResetRequest.PersonWithPasswordToBeResetPerson.IsLocked;
            var hashMethod = HashUtil.GetDefaultHashMethod();
            SecUser.PasswordSelfUpdate(passwordResetRequest.PersonWithPasswordToBeResetPerson.LogonName, newPassword, hashMethod, SecUser.PasswordSelfUpdateContext.PasswordReset);

            var userAndPersonDetailInfoForLogging = $"SecUserID: {passwordResetRequest.PersonWithPasswordToBeResetPerson.PiscesSecUserID}, LogonName: {passwordResetRequest.PersonWithPasswordToBeResetPerson.LogonName}, DisplayName: {passwordResetRequest.PersonWithPasswordToBeResetPerson.DisplayName}, EmailAddress: {passwordResetRequest.PersonWithPasswordToBeResetPerson.EmailAddress}";
            Logger.Info($"Password changed via PasswordResetRequest for {userAndPersonDetailInfoForLogging}");
            // The PasswordSelfUpdate does the clearing itself, but logging has to happen up here
            if (accountLockedBeforePasswordResetRequest)
            {
                Logger.Info($"PasswordResetRequest also cleared locked out account for {userAndPersonDetailInfoForLogging}");
            }
        }

        /// <summary>
        /// TaurusSession for doing system background work via <see cref="People.SystemPersonID"/>. "Adds comment to better identify the session when inspecting the current session table.
        /// </summary>
        public static TaurusSession MakeSystemSession(string sessionComment)
        {
            var systemPerson = People.GetPerson(People.SystemPersonID);
            var taurusSessionForSystemPerson = TaurusSession.MakeAnonymousSession();
            taurusSessionForSystemPerson.TaurusSessionComment = sessionComment;
            AssignPersonToTaurusSession(systemPerson, taurusSessionForSystemPerson);
            return taurusSessionForSystemPerson;
        }
        */
    }
}