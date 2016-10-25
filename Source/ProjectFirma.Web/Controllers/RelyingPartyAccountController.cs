using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using Keystone.Common;
using LtInfo.Common;

namespace ProjectFirma.Web.Controllers
{
    public abstract class RelyingPartyAccountController : FirmaBaseController
    {
        protected abstract string HomeUrl { get; }

        [AnonymousUnclassifiedFeature]
        [ValidateInput(false)] // Note: needed to allow for WSFederationMessage which may contain characters that would require HTML encoding
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LogOn(string wresult)
        {
            return Redirect(KeystoneUtilities.LogOnActionResult(System.Web.HttpContext.Current.Request, HomeUrl, SyncLocalAccountStore));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [LoggedInUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult LogOn()
        {
            var returnUrl = !string.IsNullOrWhiteSpace(Request["returnUrl"]) ? Request["returnUrl"] : HomeUrl;
            return Redirect(returnUrl);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [AnonymousUnclassifiedFeature]
        public ActionResult Register()
        {
            return Redirect(HomeUrl);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [AnonymousUnclassifiedFeature]
        public ActionResult LogOff()
        {
            var returnUrl = !string.IsNullOrWhiteSpace(Request["returnUrl"]) ? Request["returnUrl"] : HomeUrl;
            return Redirect(KeystoneUtilities.LogOffActionResultWithReturnUrl(System.Web.HttpContext.Current.Request, User.Identity, HomeUrl, returnUrl));
        }

        // RP specific logic to sync or on-the-fly provision of local user account - claims are parsed into IKeystoneUserClaims provided object
        protected abstract IKeystoneUser SyncLocalAccountStore(IKeystoneUserClaims keystoneUserClaims);
    }
}