using System;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.User
{
    public class ImpersonateUserButtonViewData
    {
        // The below would be a lot simpler, but we wanted to make it hard to impersonate yourself, which could prove 
        // very confusing.

        public readonly Person PersonToImpersonate;
        public readonly bool HasRightsToImpersonate;
        public readonly bool PersonCanBeImpersonated;
        /// <summary>
        /// Meets all security and workflow permissions to show the button (at least one of the versions of it)
        /// </summary>
        public readonly bool ShouldShowButton;
        /// <summary>
        /// Is the user being offered for impersonation different from the current logged-in user?
        /// </summary>
        public readonly bool IsDifferentUserFromCurrentLoggedInUser;
        /// <summary>
        /// This user we are showing the button for is the original, actual identity of the user, who is currently impersonating someone else. 
        /// </summary>
        public readonly bool IsOriginalIdentityWhenImpersonating;
        public readonly string SwitchUserVerb;
        public readonly string ImpersonateUserUrl;

        public ImpersonateUserButtonViewData(FirmaSession firmaSession, Person personToImpersonate)
        {
            PersonToImpersonate = personToImpersonate;

            ImpersonateUserUrl = SitkaRoute<UserController>.BuildUrlFromExpression(c => c.ImpersonateUser(PersonToImpersonate.PersonID));

            // Flawed - Won't work WHEN impersonating. ** FIX **
            HasRightsToImpersonate = new FirmaImpersonateUserFeature().HasPermission(firmaSession, personToImpersonate).HasPermission;

            IsDifferentUserFromCurrentLoggedInUser = personToImpersonate.PersonID != firmaSession.PersonID;
            IsOriginalIdentityWhenImpersonating = personToImpersonate.PersonID == firmaSession.OriginalPersonID;
            PersonCanBeImpersonated = personToImpersonate != null;
            SwitchUserVerb = IsOriginalIdentityWhenImpersonating ? "Resume being" : "Impersonate";

            var tenantAttributes = MultiTenantHelpers.GetTenantAttribute();

            // Tenant configuration - is impersonation allowed.
            ShouldShowButton = FirmaWebConfiguration.ImpersonationAllowedInEnvironment && HasRightsToImpersonate && PersonCanBeImpersonated && IsDifferentUserFromCurrentLoggedInUser;
        }

    }

    public abstract class ImpersonateUserButton : TypedWebPartialViewPage<ImpersonateUserButtonViewData>
    {
        public static UrlTemplate<int> ImpersonateUserUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(lc => lc.ImpersonateUser(UrlTemplate.Parameter1Int)));
        public static UrlTemplate<int> ImpersonateUserSinglePageUrlTemplate = new UrlTemplate<int>(SitkaRoute<UserController>.BuildUrlFromExpression(lc => lc.SinglePageImpersonateUser(UrlTemplate.Parameter1Int)));

        public static void RenderPartialView(HtmlHelper html, ImpersonateUserButtonViewData viewData)
        {
            html.RenderRazorSitkaPartial<ImpersonateUserButton, ImpersonateUserButtonViewData>(viewData);
        }

        /// <summary>
        /// Link maker for use in grid and such
        /// </summary>
        /// <param name="personToImpersonate"></param>
        /// <returns></returns>
        public static string MakeImpersonatePostHtml(Person personToImpersonate)
        {
            // Can't impersonate an anonymous user
            if (personToImpersonate == null)
            {
                return String.Empty;
            }

            string theLinkUrl = ImpersonateUserUrlTemplate.ParameterReplace(personToImpersonate.PersonID);
            int personId = personToImpersonate.PersonID;

            string templateHtml = "<form id=\"ImpersonationForm_{1}\" name=\"ImpersonationForm_{1}\" action=\"{0}\" method=\"post\"><input id=\"ImpersonateUser_{1}_Button\" type=\"hidden\" name=\"ImpersonateUser_{1}\" value=\"Impersonate {2}\"/><a href=\"javascript:{{ }}\" onclick=\"document.getElementById('ImpersonationForm_{1}').submit();\">{3}</a></form>";
            string linkHtmlTemplate = "<span class=\"glyphicon glyphicon-{0}\" aria-hidden=\"true\" title=\"Impersonate {1}\"></span>";

            string linkHtml = String.Format(linkHtmlTemplate, "user", personToImpersonate.GetFullNameFirstLast());
            string fullHtml = String.Format(templateHtml, theLinkUrl, personId, personToImpersonate.GetFullNameFirstLast(), linkHtml);
            return fullHtml;
        }

        public static HtmlString MakeImpersonateSinglePageHtmlLink(Person personToImpersonate)
        {
            if (personToImpersonate == null)
            {
                return new HtmlString(String.Empty);
            }

            string theLinkUrl = ImpersonateUserSinglePageUrlTemplate.ParameterReplace(personToImpersonate.PersonID);

            string linkHtmlTemplate = "<span class=\"glyphicon glyphicon-{0}\" aria-hidden=\"true\" title=\"Impersonate {1}\"></span>";
            // I wish Bootstrap offered a "domino" or mask icon, but this is all I could come up with quickly. Feel free to change these! -- SLG
            string linkHtml = String.Format(linkHtmlTemplate,  "user", personToImpersonate.GetFullNameFirstLast());
            // Controller is actually irrelevant here
            string theHref = SitkaRoute<UserController>.BuildLinkFromUrl(theLinkUrl, linkHtml, $"impersonate user {personToImpersonate.GetFullNameFirstLast()}");
            return new HtmlString(theHref);
        }
    }
}
