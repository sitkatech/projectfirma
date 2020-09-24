/*-----------------------------------------------------------------------
<copyright file="KeywordController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.Keyword;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.Shared.MatchmakerOrganizationControls;

namespace ProjectFirma.Web.Controllers
{
    public class KeywordController : FirmaBaseController
    {

        public const int MinimumMatchmakerKeywordFindLength = 3;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q">Do not rename this; it is bound to "q" by the bootstrap-tag library in an inaccessible way.</param>
        /// <returns></returns>
        [FirmaAdminFeature]
        public JsonResult FindMatchmakerKeyword(string q)
        { 
            var searchTerm = q.Trim();
            var matchmakerKeywordResults = HttpRequestStorage.DatabaseEntities.MatchmakerKeywords
                .Where(mmk => searchTerm.Length < MinimumMatchmakerKeywordFindLength ? mmk.MatchmakerKeywordName.StartsWith(searchTerm) : mmk.MatchmakerKeywordName.Contains(searchTerm)).ToList()
                .Select(mk => new BootstrapOrganizationMatchmakerKeyword(mk)).ToList();
            return Json(matchmakerKeywordResults);
        }

        #region Modal Pop-Up Keyword Editor

        [HttpGet]
        [OrganizationProfileViewEditFeature]
        public PartialViewResult EditMatchMakerKeywordsModal(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
           var viewModel = new MatchmakerKeywordsModalViewModel(organization);
           var viewData = new MatchmakerKeywordsModalViewData(organization);
           return RazorPartialView<MatchmakerKeywordsModal, MatchmakerKeywordsModalViewData, MatchmakerKeywordsModalViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [OrganizationProfileViewEditFeature]
        public ActionResult EditMatchMakerKeywordsModal(OrganizationPrimaryKey organizationPrimaryKey, MatchmakerKeywordsModalViewModel viewModel)
        {
            var organization = organizationPrimaryKey.EntityObject;

            if (!ModelState.IsValid)
            {
                var viewData = new MatchmakerKeywordsModalViewData(organization);
                return RazorPartialView<MatchmakerKeywordsModal, MatchmakerKeywordsModalViewData, MatchmakerKeywordsModalViewModel>(viewData, viewModel);
            }

            viewModel.UpdateModel(organization, HttpRequestStorage.DatabaseEntities, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            // Clean up any orphaned MatchmakerKeywords (just for this Tenant)
            var orphanedMatchmakerKeywords = HttpRequestStorage.DatabaseEntities.MatchmakerKeywords
                .Where(mk => !mk.OrganizationMatchmakerKeywords.Any()).ToList();
            orphanedMatchmakerKeywords.ForEach(omk => omk.Delete(HttpRequestStorage.DatabaseEntities));
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            return new ModalDialogFormJsonResult(SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.Detail(organization, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        }

        #endregion Modal Pop-Up Keyword Editor

    }
}
