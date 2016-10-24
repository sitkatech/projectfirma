using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Tag;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using Edit = ProjectFirma.Web.Views.Tag.Edit;
using EditViewData = ProjectFirma.Web.Views.Tag.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.Tag.EditViewModel;
using Index = ProjectFirma.Web.Views.Tag.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Tag.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Tag.IndexViewData;
using Summary = ProjectFirma.Web.Views.Tag.Summary;
using SummaryViewData = ProjectFirma.Web.Views.Tag.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class TagController : LakeTahoeInfoBaseController
    {
        [TagViewFeature]
        public ViewResult Index()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.TagList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TagViewFeature]
        public GridJsonNetJObjectResult<Tag> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var tags = GetTagsAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Tag>(tags, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Tag> GetTagsAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasTagDeletePermission = new TagManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasTagDeletePermission);
            return HttpRequestStorage.DatabaseEntities.Tags.OrderBy(x => x.TagName).ToList();
        }

        [HttpGet]
        [TagManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TagManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var tag = new Tag(string.Empty);
            viewModel.UpdateModel(tag, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.Tags.Add(tag);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TagManageFeature]
        public PartialViewResult Edit(TagPrimaryKey tagPrimaryKey)
        {
            var tag = tagPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(tag);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TagManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TagPrimaryKey tagPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var tag = tagPrimaryKey.EntityObject;
            viewModel.UpdateModel(tag, CurrentPerson);
            return new ModalDialogFormJsonResult(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.Summary(tag.TagName)));
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [TagViewFeature]
        public ViewResult Summary(string tagName)
        {
            var tag = HttpRequestStorage.DatabaseEntities.Tags.GetTag(tagName);
            Check.RequireNotNullThrowNotFound(tag, tagName);
            var viewData = new SummaryViewData(CurrentPerson, tag);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [TagManageFeature]
        public PartialViewResult DeleteTag(TagPrimaryKey tagPrimaryKey)
        {
            var tag = tagPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(tag.TagID);
            return ViewDeleteTag(tag, viewModel);
        }

        private PartialViewResult ViewDeleteTag(Tag tag, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = string.Format("Are you sure you want to delete this Tag '{0}'?", tag.TagName);
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TagManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTag(TagPrimaryKey tagPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var tag = tagPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTag(tag, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectTags.RemoveRange(tag.ProjectTags);
            HttpRequestStorage.DatabaseEntities.Tags.Remove(tag);
            return new ModalDialogFormJsonResult();
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [TagManageFeature]
        public ContentResult RemoveTagsFromProject()
        {
            return new ContentResult();
        }

        [HttpPost]
        [TagManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RemoveTagsFromProject(BulkTagProjectsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult();
            }
            // find tag, remove it from this project
            var existingTag = HttpRequestStorage.DatabaseEntities.Tags.GetTag(viewModel.TagName);
            if (existingTag != null)
            {
                var projectTags = existingTag.ProjectTags.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
                HttpRequestStorage.DatabaseEntities.ProjectTags.RemoveRange(projectTags);
            }
            return new ModalDialogFormJsonResult();
        }

        /// <summary>
        /// Dummy get signature so that it can find the post action
        /// </summary>
        [HttpGet]
        [TagManageFeature]
        public ContentResult AddTagsToProject()
        {
            return new ContentResult();
        }

        [HttpPost]
        [TagManageFeature]
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
        [TagManageFeature]
        public ContentResult AddTagsToProjectModal()
        {
            return new ContentResult();
        }

        [HttpPost]
        [TagManageFeature]
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
                HttpRequestStorage.DatabaseEntities.Tags.Add(existingTag);
            }

            var newProjectTags =
                viewModel.ProjectIDList.Select(projectID => new ProjectTag(projectID, existingTag.TagID))
                    .ToList();

            HttpRequestStorage.DatabaseEntities.ProjectTags.Load();
            var allProjectTags = HttpRequestStorage.DatabaseEntities.ProjectTags.Local;
            existingTag.ProjectTags.MergeNew(newProjectTags, (x, y) => x.ProjectID == y.ProjectID && x.TagID == y.TagID, allProjectTags);
            return existingTag;
        }

        [TagManageFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TagPrimaryKey tagPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            var projectWatersheds = tagPrimaryKey.EntityObject.AssociatedProjects.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectWatersheds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [TagManageFeature]
        public JsonResult Find(string q)
        {
            var searchTerm = q.Trim();
            var projectFindResults = HttpRequestStorage.DatabaseEntities.Tags
                .Where(x => searchTerm.Length < 3 ? x.TagName.StartsWith(searchTerm) : x.TagName.Contains(searchTerm)).ToList()
                .Select(x => new BootstrapTag(x));
            return Json(projectFindResults);
        }

        [HttpGet]
        [TagManageFeature]
        public ContentResult BulkTagProjects()
        {
            return new ContentResult();
        }

        [HttpPost]
        [TagManageFeature]
        public PartialViewResult BulkTagProjects(BulkTagProjectsViewModel viewModel)
        {
            var projectDisplayNames = new List<string>();

            if (viewModel.ProjectIDList != null)
            {
                var projects = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
                projectDisplayNames = projects.Select(x => x.DisplayName).ToList();
            }
            var viewData = new BulkTagProjectsViewData(projectDisplayNames);
            return RazorPartialView<BulkTagProjects, BulkTagProjectsViewData, BulkTagProjectsViewModel>(viewData, viewModel);
        }
    }
}