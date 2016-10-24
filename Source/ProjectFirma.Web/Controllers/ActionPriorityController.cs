using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Edit = ProjectFirma.Web.Views.ActionPriority.Edit;
using EditViewData = ProjectFirma.Web.Views.ActionPriority.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.ActionPriority.EditViewModel;
using Index = ProjectFirma.Web.Views.ActionPriority.Index;
using IndexGridSpec = ProjectFirma.Web.Views.ActionPriority.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.ActionPriority.IndexViewData;
using Summary = ProjectFirma.Web.Views.ActionPriority.Summary;
using SummaryViewData = ProjectFirma.Web.Views.ActionPriority.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ActionPriorityController : LakeTahoeInfoBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [AdminReadOnlyViewEverythingFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.ActionPrioritiesList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<ActionPriority> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var actionPriorities = GetActionPrioritiesAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ActionPriority>(actionPriorities, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ActionPriority> GetActionPrioritiesAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new ActionPriorityManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.ActionPriorities.ToList().OrderBy(x => x.DisplayNumber).ToList();
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult Summary(ActionPriorityPrimaryKey actionPriorityPrimaryKey)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;

            var actionPriorityProjects = actionPriority.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? actionPriorityProjects.Where(p => p.IsVisibleToEveryone()).ToList() : actionPriorityProjects;

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.ActionPriority, new List<int> {actionPriority.ActionPriorityID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "ActionPriorityProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new SummaryViewData(CurrentPerson, actionPriority, projectLocationsMapInitJson, projectLocationsMapViewData);

            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [ActionPriorityManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [ActionPriorityManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var actionPriority = new ActionPriority(viewModel.ProgramID,
                ActionPriority.GetNextActionPriorityNumberForProgram(HttpRequestStorage.DatabaseEntities.ActionPriorities, viewModel.ProgramID),
                string.Empty);
            viewModel.UpdateModel(actionPriority, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.ActionPriorities.Add(actionPriority);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ActionPriorityManageFeature]
        public PartialViewResult Edit(ActionPriorityPrimaryKey actionPriorityPrimaryKey)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(actionPriority);
            return ViewEdit(viewModel, actionPriority.Projects.Any(), actionPriority.Program.DisplayName);
        }

        [HttpPost]
        [ActionPriorityManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ActionPriorityPrimaryKey actionPriorityPrimaryKey, EditViewModel viewModel)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, actionPriority.Projects.Any(), actionPriority.Program.DisplayName);
            }
            // reset the actionPriority number if focus area is changed
            if (!actionPriority.Projects.Any() && actionPriority.ProgramID != viewModel.ProgramID)
            {
                actionPriority.ActionPriorityNumber = ActionPriority.GetNextActionPriorityNumberForProgram(HttpRequestStorage.DatabaseEntities.ActionPriorities, viewModel.ProgramID);
            }
            viewModel.UpdateModel(actionPriority, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, false, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool hasProjects, string programDisplayName)
        {
            var programs = HttpRequestStorage.DatabaseEntities.Programs.ToList().OrderBy(x => x.DisplayName).ToSelectList(x => x.ProgramID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var viewData = new EditViewData(programs, programDisplayName, hasProjects);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ActionPriorityManageFeature]
        public PartialViewResult DeleteActionPriority(ActionPriorityPrimaryKey actionPriorityPrimaryKey)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(actionPriority.ActionPriorityID);
            return ViewDeleteActionPriority(actionPriority, viewModel);
        }

        private PartialViewResult ViewDeleteActionPriority(ActionPriority actionPriority, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !actionPriority.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Action Priority '{0}'?", actionPriority.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Action Priority", SitkaRoute<ActionPriorityController>.BuildLinkFromExpression(x => x.Summary(actionPriority), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ActionPriorityManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteActionPriority(ActionPriorityPrimaryKey actionPriorityPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteActionPriority(actionPriority, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ActionPriorities.Remove(actionPriority);
            return new ModalDialogFormJsonResult();
        }

        [ActionPriorityViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(ActionPriorityPrimaryKey actionPriorityPrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectActionPrioritys = GetProjectsAndGridSpec(out gridSpec, actionPriorityPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectActionPrioritys, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, ActionPriority actionPriority)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return actionPriority.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [ActionPriorityManageFeature]
        public PartialViewResult EditDescription(ActionPriorityPrimaryKey actionPriorityPrimaryKey)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(actionPriority.ActionPriorityDescriptionHtmlString);
            return ViewEditDescription(actionPriority, viewModel);
        }

        [HttpPost]
        [ActionPriorityManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(ActionPriorityPrimaryKey actionPriorityPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var actionPriority = actionPriorityPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(actionPriority, viewModel);
            }
            viewModel.UpdateModel(actionPriority);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(ActionPriority actionPriority, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForActionPriority(actionPriority, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }
    }
}