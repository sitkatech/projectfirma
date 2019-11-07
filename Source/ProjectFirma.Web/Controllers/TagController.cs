/*-----------------------------------------------------------------------
<copyright file="TagController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Tag;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using Detail = ProjectFirma.Web.Views.Tag.Detail;
using DetailViewData = ProjectFirma.Web.Views.Tag.DetailViewData;
using Edit = ProjectFirma.Web.Views.Tag.Edit;
using EditViewData = ProjectFirma.Web.Views.Tag.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.Tag.EditViewModel;
using Index = ProjectFirma.Web.Views.Tag.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Tag.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Tag.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class TagController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.TagList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Tag> IndexGridJsonData()
        {
            var hasTagDeletePermission = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new IndexGridSpec(hasTagDeletePermission);
            var tags = HttpRequestStorage.DatabaseEntities.Tags.OrderBy(x => x.TagName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Tag>(tags, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var tag = new Tag(string.Empty);
            viewModel.UpdateModel(tag, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllTags.Add(tag);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Tag {tag.GetDisplayNameAsUrl()} successfully created.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(TagPrimaryKey tagPrimaryKey)
        {
            var tag = tagPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(tag);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TagPrimaryKey tagPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var tag = tagPrimaryKey.EntityObject;
            viewModel.UpdateModel(tag, CurrentFirmaSession);
            return new ModalDialogFormJsonResult(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Detail(tag.TagName)));
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        public ViewResult Detail(string tagName)
        {
            var tag = HttpRequestStorage.DatabaseEntities.Tags.GetTag(tagName);
            Check.RequireNotNullThrowNotFound(tag, tagName);
            var viewData = new DetailViewData(CurrentFirmaSession, tag);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteTag(TagPrimaryKey tagPrimaryKey)
        {
            var tag = tagPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(tag.TagID);
            return ViewDeleteTag(tag, viewModel);
        }

        private PartialViewResult ViewDeleteTag(Tag tag, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete this Tag '{tag.TagName}'?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTag(TagPrimaryKey tagPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var tag = tagPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTag(tag, viewModel);
            }
            tag.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult RemoveTagsFromProject()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RemoveTagsFromProject(BulkTagProjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult();
            }
            // find tag, remove it from this project
            var existingTag = HttpRequestStorage.DatabaseEntities.Tags.GetTag(viewModel.TagName);
            existingTag.DeleteChildren(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult AddTagsToProject()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult AddTagsToProject(BulkTagProjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult();
            }
            var existingTag = AddTagsToProjectImpl(viewModel);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return Json(new BootstrapTag(existingTag));
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult AddTagsToProjectModal()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddTagsToProjectModal(BulkTagProjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new ModalDialogFormJsonResult();
            }
            AddTagsToProjectImpl(viewModel);
            return new ModalDialogFormJsonResult();
        }

        private static Tag AddTagsToProjectImpl(BulkTagProjectsViewModel viewModel)
        {
            var existingTag = HttpRequestStorage.DatabaseEntities.Tags.GetTag(viewModel.TagName);
            if (existingTag == null)
            {
                existingTag = new Tag(viewModel.TagName);
                HttpRequestStorage.DatabaseEntities.AllTags.Add(existingTag);
            }

            var newProjectTags =
                viewModel.ProjectIDList.Select(projectID => new ProjectTag(projectID, existingTag.TagID))
                    .ToList();

            HttpRequestStorage.DatabaseEntities.ProjectTags.Load();
            var allProjectTags = HttpRequestStorage.DatabaseEntities.AllProjectTags.Local;
            existingTag.ProjectTags.MergeNew(newProjectTags, (x, y) => x.ProjectID == y.ProjectID && x.TagID == y.TagID, allProjectTags);
            return existingTag;
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TagPrimaryKey tagPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true);
            var projectGeospatialAreas = tagPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectGeospatialAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [FirmaAdminFeature]
        public JsonResult Find(string q)
        {
            var searchTerm = q.Trim();
            var projectFindResults = HttpRequestStorage.DatabaseEntities.Tags
                .Where(x => searchTerm.Length < 3 ? x.TagName.StartsWith(searchTerm) : x.TagName.Contains(searchTerm)).ToList()
                .Select(x => new BootstrapTag(x));
            return Json(projectFindResults);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ContentResult BulkTagProjects()
        {
            return new ContentResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public PartialViewResult BulkTagProjects(BulkTagProjectsViewModel viewModel)
        {
            var projectDisplayNames = new List<string>();

            if (viewModel.ProjectIDList != null)
            {
                var projects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
                projectDisplayNames = projects.Select(x => x.GetDisplayName()).ToList();
            }
            var viewData = new BulkTagProjectsViewData(projectDisplayNames);
            return RazorPartialView<BulkTagProjects, BulkTagProjectsViewData, BulkTagProjectsViewModel>(viewData, viewModel);
        }
    }
}
