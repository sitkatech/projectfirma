using System;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.SecurityUtil
{
    public static class UserAuthentication
    {
        public static PersonLoginAccount Validate(DatabaseEntities databaseEntities, string personLoginAccountName, string passwordPlainText, int tenantID)
        {
            try
            {
                var personLoginAccount = databaseEntities.PersonLoginAccounts.GetPersonLoginAccountByNameAndTenant(personLoginAccountName, tenantID);
                Check.RequireNotNull(personLoginAccount, $"PersonLoginAccount record not found for LogonName {personLoginAccountName}");

                // Should have a valid PersonLoginAccount by now
                string userAndPersonInfoForLogging = $"PersonLoginAccountID: {personLoginAccount.PersonLoginAccountID}, PersonLoginAccountName: {personLoginAccount.PersonLoginAccountName}, PersonID: {personLoginAccount.PersonID},  Email: {personLoginAccount.Person.Email}";

                Check.Require(personLoginAccount.LoginActive, $"PersonLoginAccount record LoginActive == false, {userAndPersonInfoForLogging}");

                bool isValidLogin = DoPasswordsMatch(personLoginAccount, passwordPlainText);
                if (isValidLogin)
                {
                    //// They may have gotten the password right, but the account could still be locked for some reason
                    //status = AuthenticationStatus.Locked;
                    //Check.Require(!secUser.Person.IsLocked, $"User account is locked, {userAndPersonInfoForLogging}");

                    // If not locked, we can clear failed login attempts and continue
                    int priorFailedLoginCount = personLoginAccount.FailedLoginCount;
                    personLoginAccount.FailedLoginCount = 0;
                    personLoginAccount.LastLoginDate = DateTime.Now;
                    LogFailedLoginAttemptsClearedMessageIfApplicable(personLoginAccount, priorFailedLoginCount);
                }
                else
                {
                    personLoginAccount.FailedLoginCount++;
                    //personLoginAccount.LastAttemptedLoginDate = DateTime.Now;
                }

                Check.Require(isValidLogin, $"Bad login or password for {userAndPersonInfoForLogging}");
                Check.Require(personLoginAccount.Person.IsActive, $"Person record is inactivated, {userAndPersonInfoForLogging}");
                //Check.Require(!userHasExpiredPasswordAsComputedBeforeLogin, $"SecUser account password is expired, {userAndPersonInfoForLogging}");
                return personLoginAccount;
            }
            catch (Exception)
            {
                // Should log details here...
                return null;
            }
        }

        public static void LogFailedLoginAttemptsClearedMessageIfApplicable(PersonLoginAccount personLoginAccount, int priorFailedLoginCount)
        {
            if (priorFailedLoginCount != 0 && personLoginAccount.FailedLoginCount == 0)
            {
                //SecurityLogger.Info($"Prior count of {priorFailedLoginAttempts} failed login attempts for SecUser LogonName {this.LogonName} have been cleared. FailedLoginAttempts now {this.FailedLoginAttempts}.");
            }
        }

        private static bool DoPasswordsMatch(PersonLoginAccount personLoginAccount, string passwordPlainText)
        {
            string passwordStoredHash = personLoginAccount.PasswordHash;
            string passwordStoredSalt = personLoginAccount.PasswordSalt;

            bool matchesPassword = PBKDF2PasswordHash.ValidatePassword(passwordStoredSalt, passwordPlainText, passwordStoredHash);
            return matchesPassword;
        }
    }
}