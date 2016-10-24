using System;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// These have been implemented as extension methods on <see cref="Person"/> so we can handle the anonymous user as a null person object
    /// </summary>
    public static class PersonModelExtensions
    {
        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1Int)));

        public static HtmlString GetFullNameFirstLastAsUrl(this Person person)
        {
            return UrlTemplate.MakeHrefString(person.GetSummaryUrl(), person.FullNameFirstLast);
        }

        public static HtmlString GetFullNameFirstLastAndOrgAsUrl(this Person person)
        {
            var userUrl = person.GetFullNameFirstLastAsUrl();
            var orgUrl = person.Organization.GetDisplayNameAsUrl();
            return new HtmlString(String.Format("{0} - {1}", userUrl, orgUrl));
        }

        public static HtmlString GetFullNameFirstLastAsStringAndOrgAsUrl(this Person person)
        {
            var userString = person.FullNameFirstLast;
            var orgUrl = person.Organization.GetDisplayNameAsUrl();
            return new HtmlString(String.Format("{0} - {1}", userString, orgUrl));
        }

        public static string GetEditUrl(this Person person)
        {
            return SitkaRoute<UserController>.BuildUrlFromExpression(t => t.EditRoles(person));
        }

        public static string GetSummaryUrl(this Person person)
        {
            return SummaryUrlTemplate.ParameterReplace(person.PersonID);
        }

        public static bool IsSitkaAdministrator(this Person person)
        {
            return person != null && person.Role == Role.SitkaAdmin;
        }

        public static bool IsAdministrator(this Person person)
        {
            return person != null && person.Role == Role.Admin && IsSitkaAdministrator(person);
        }

        public static bool IsApprover(this Person person)
        {
            return person != null && (IsAdministrator(person) || person.Role == Role.Approver || person.Role == Role.TMPOManager);
        }

        public static bool ShouldReceiveEIPNotifications(this Person person)
        {
            return person.ReceiveSupportEmails;
        }

        public static bool IsReadOnlyAdmin(this Person person)
        {
            return person != null && person.Role == Role.ReadOnlyAdmin;
        }

        public static bool IsReadOnly(this Person person)
        {
            return (person != null && person.Role == Role.ReadOnlyNormal) || (person != null && person.Role == Role.ReadOnlyAdmin);
        }

        public static string GetKeystoneEditLink(this Person person)
        {
            return string.Format("{0}{1}", ProjectFirmaWebConfiguration.KeystoneUserProfileUrl, person.PersonGuid);
        }
    }
}