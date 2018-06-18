/*-----------------------------------------------------------------------
<copyright file="RelyingPartyAccountController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Security.Principal;
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
        protected abstract IKeystoneUser SyncLocalAccountStore(IKeystoneUserClaims keystoneUserClaims, IIdentity userIdentity);
    }
}
