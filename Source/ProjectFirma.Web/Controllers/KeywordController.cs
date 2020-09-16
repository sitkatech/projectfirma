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

using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
//using ProjectFirma.Web.Views.Keyword;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Views.Shared.MatchmakerKeyword;
using ProjectFirma.Web.Views.Shared.MatchmakerOrganizationControls;
using ProjectFirmaModels;
//using Detail = ProjectFirma.Web.Views.Keyword.Detail;
//using DetailViewData = ProjectFirma.Web.Views.Keyword.DetailViewData;
//using Edit = ProjectFirma.Web.Views.Keyword.Edit;
//using EditViewData = ProjectFirma.Web.Views.Keyword.EditViewData;
//using EditViewModel = ProjectFirma.Web.Views.Keyword.EditViewModel;
//using Index = ProjectFirma.Web.Views.Keyword.Index;
//using IndexGridSpec = ProjectFirma.Web.Views.Keyword.IndexGridSpec;
//using IndexViewData = ProjectFirma.Web.Views.Keyword.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class KeywordController : FirmaBaseController
    {
        //[FirmaAdminFeature]
        //public ViewResult Index()
        //{
        //    var firmaPage = FirmaPageTypeEnum.KeywordList.GetFirmaPage();
        //    var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
        //    return RazorView<Index, IndexViewData>(viewData);
        //}

        //[FirmaAdminFeature]
        //public GridJsonNetJObjectResult<Keyword> IndexGridJsonData()
        //{
        //    var hasKeywordDeletePermission = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
        //    var gridSpec = new IndexGridSpec(hasKeywordDeletePermission);
        //    var Keywords = HttpRequestStorage.DatabaseEntities.Keywords.OrderBy(x => x.KeywordName).ToList();
        //    var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Keyword>(Keywords, gridSpec);
        //    return gridJsonNetJObjectResult;
        //}

        //[HttpGet]
        //[FirmaAdminFeature]
        //public PartialViewResult New()
        //{
        //    var viewModel = new EditViewModel();
        //    return ViewEdit(viewModel);
        //}

        //[HttpPost]
        //[FirmaAdminFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult New(EditViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewEdit(viewModel);
        //    }
        //    var Keyword = new Keyword(string.Empty);
        //    viewModel.UpdateModel(Keyword, CurrentFirmaSession);
        //    HttpRequestStorage.DatabaseEntities.AllKeywords.Add(Keyword);
        //    HttpRequestStorage.DatabaseEntities.SaveChanges();
        //    SetMessageForDisplay($"Keyword {Keyword.GetDisplayNameAsUrl()} successfully created.");
        //    return new ModalDialogFormJsonResult();
        //}

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(MatchmakerKeywordPrimaryKey matchmakerKeywordPrimaryKey)
        {
            var matchmakerKeyword = matchmakerKeywordPrimaryKey.EntityObject;
            throw new NotImplementedException("Only half implemented here; seeing if Matt actually wants this or if it falls short of MVP.");
            //var viewModel = new EditViewModel(matchmakerKeyword);
            //return ViewEdit(viewModel);
        }

        //[HttpPost]
        //[FirmaAdminFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult Edit(KeywordPrimaryKey KeywordPrimaryKey, EditViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewEdit(viewModel);
        //    }
        //    var Keyword = KeywordPrimaryKey.EntityObject;
        //    viewModel.UpdateModel(Keyword, CurrentFirmaSession);
        //    return new ModalDialogFormJsonResult(SitkaRoute<KeywordController>.BuildUrlFromExpression(x => x.Detail(Keyword.KeywordName)));
        //}

        //private PartialViewResult ViewEdit(EditViewModel viewModel)
        //{
        //    var viewData = new EditViewData();
        //    return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        //}

        [FirmaAdminFeature]
        public ViewResult Detail(string matchmakerKeywordName)
        {
            var matchmakerKeyword = HttpRequestStorage.DatabaseEntities.MatchmakerKeywords.GetMatchmakerKeyword(matchmakerKeywordName);
            Check.RequireNotNullThrowNotFound(matchmakerKeyword, matchmakerKeywordName);
            var viewData = new MatchmakerKeywordDetailViewData(CurrentFirmaSession, matchmakerKeyword);
            return RazorView<MatchmakerKeywordDetail, MatchmakerKeywordDetailViewData>(viewData);
        }

        //[HttpGet]
        //[FirmaAdminFeature]
        //public PartialViewResult DeleteKeyword(KeywordPrimaryKey KeywordPrimaryKey)
        //{
        //    var Keyword = KeywordPrimaryKey.EntityObject;
        //    var viewModel = new ConfirmDialogFormViewModel(Keyword.KeywordID);
        //    return ViewDeleteKeyword(Keyword, viewModel);
        //}

        //private PartialViewResult ViewDeleteKeyword(Keyword Keyword, ConfirmDialogFormViewModel viewModel)
        //{
        //    var confirmMessage = $"Are you sure you want to delete this Keyword '{Keyword.KeywordName}'?";
        //    var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
        //    return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        //}

        //[HttpPost]
        //[FirmaAdminFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult DeleteKeyword(KeywordPrimaryKey KeywordPrimaryKey, ConfirmDialogFormViewModel viewModel)
        //{
        //    var Keyword = KeywordPrimaryKey.EntityObject;
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewDeleteKeyword(Keyword, viewModel);
        //    }
        //    Keyword.DeleteFull(HttpRequestStorage.DatabaseEntities);
        //    return new ModalDialogFormJsonResult();
        //}

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult RemoveMatchmakerKeywordsFromOrganization()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RemoveMatchmakerKeywordsFromOrganization(BulkMatchmakerKeywordOrganizationsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult();
            }
            // find MatchmakerKeyword, remove it from this Organization
            var existingKeyword = HttpRequestStorage.DatabaseEntities.MatchmakerKeywords.GetMatchmakerKeyword(viewModel.MatchmakerKeywordName);
            existingKeyword.DeleteChildren(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult AddMatchmakerKeywordsToOrganization()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult AddMatchmakerKeywordsToOrganization(BulkMatchmakerKeywordOrganizationsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult();
            }
            var existingKeyword = AddMatchmakerKeywordsToOrganizationImpl(viewModel);
            HttpRequestStorage.DatabaseEntities.SaveChanges(); 
            return Json(new BootstrapOrganizationMatchmakerKeyword(existingKeyword));
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult AddMatchmakerKeywordsToOrganizationModal()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddMatchmakerKeywordsToOrganizationModal(BulkMatchmakerKeywordOrganizationsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new ModalDialogFormJsonResult();
            }
            AddMatchmakerKeywordsToOrganizationImpl(viewModel);
            return new ModalDialogFormJsonResult();
        }

        private static MatchmakerKeyword AddMatchmakerKeywordsToOrganizationImpl(BulkMatchmakerKeywordOrganizationsViewModel viewModel)
        {
            var existingMatchmakerKeyword = HttpRequestStorage.DatabaseEntities.MatchmakerKeywords.GetMatchmakerKeyword(viewModel.MatchmakerKeywordName);
            if (existingMatchmakerKeyword == null)
            {
                existingMatchmakerKeyword = new MatchmakerKeyword(viewModel.MatchmakerKeywordName);
                HttpRequestStorage.DatabaseEntities.AllMatchmakerKeywords.Add(existingMatchmakerKeyword);
            }

            var newProjectKeywords =
                viewModel.OrganizationIDList.Select(organizationID => new OrganizationMatchmakerKeyword(organizationID, existingMatchmakerKeyword.MatchmakerKeywordID))
                    .ToList();

            // Merge with TenantID as well?

            HttpRequestStorage.DatabaseEntities.OrganizationMatchmakerKeywords.Load();
            var allOrganizationMatchmakerKeywords = HttpRequestStorage.DatabaseEntities.AllOrganizationMatchmakerKeywords.Local;
            existingMatchmakerKeyword.OrganizationMatchmakerKeywords.MergeNew(newProjectKeywords, (x1, y) => x1.OrganizationID == y.OrganizationID && x1.MatchmakerKeywordID == y.MatchmakerKeywordID, allOrganizationMatchmakerKeywords);
            return existingMatchmakerKeyword;
        }

        /*
        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(KeywordPrimaryKey KeywordPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true);
            var projectGeospatialAreas = KeywordPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectGeospatialAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }
        */

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

        /*
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult BulkMatchmakerKeywordOrganizations()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public PartialViewResult BulkMatchmakerKeywordOrganizations(BulkMatchmakerKeywordOrganizationsViewModel viewModel)
        {
            var organizationDisplayNames = new List<string>();

            if (viewModel.OrganizationIDList != null)
            {
                var organizations = HttpRequestStorage.DatabaseEntities.Organizations.Where(o => viewModel.OrganizationIDList.Contains(o.OrganizationID)).ToList();
                organizationDisplayNames = organizations.Select(x => x.GetDisplayName()).ToList();
            }
            var viewData = new BulkMatchmakerKeywordOrganizationsViewData(organizationDisplayNames);
            return RazorPartialView<BulkKeywordProjects, BulkMatchmakerKeywordOrganizationsViewData, BulkMatchmakerKeywordOrganizationsViewModel>(viewData, viewModel);
        }
        */
    }
}
