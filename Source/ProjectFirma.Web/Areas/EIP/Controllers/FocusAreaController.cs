using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.FocusArea;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Areas.EIP.Views.FocusArea.Index;
using IndexGridSpec = ProjectFirma.Web.Areas.EIP.Views.FocusArea.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Areas.EIP.Views.FocusArea.IndexViewData;
using Summary = ProjectFirma.Web.Areas.EIP.Views.FocusArea.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.EIP.Views.FocusArea.SummaryViewData;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class FocusAreaController : LakeTahoeInfoBaseController
    {
        [FocusAreaViewFeature]
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
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.FocusAreasList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [FocusAreaViewFeature]
        public GridJsonNetJObjectResult<FocusArea> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var focusAreas = GetFocusAreasAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<FocusArea>(focusAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<FocusArea> GetFocusAreasAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new FocusAreaManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.FocusAreas.ToList().OrderBy(x => x.DisplayNumber).ToList();
        }

        [FocusAreaViewFeature]
        public ViewResult Summary(FocusAreaPrimaryKey focusAreaPrimaryKey)
        {
            var focusArea = focusAreaPrimaryKey.EntityObject;

            var focusAreaProjects = focusArea.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? focusAreaProjects.Where(p => p.IsVisibleToEveryone()).ToList() : focusAreaProjects;

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.FocusArea, new List<int> {focusArea.FocusAreaID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "FocusAreaProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new SummaryViewData(CurrentPerson, focusArea, projectLocationsMapInitJson, projectLocationsMapViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [FocusAreaManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FocusAreaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var nextFocusAreaNumber = FocusArea.GetNextFocusAreaNumber(HttpRequestStorage.DatabaseEntities.FocusAreas);
            var focusArea = new FocusArea(nextFocusAreaNumber, string.Empty);
            viewModel.UpdateModel(focusArea, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.FocusAreas.Add(focusArea);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FocusAreaManageFeature]
        public PartialViewResult Edit(FocusAreaPrimaryKey focusAreaPrimaryKey)

        {
            var focusArea = focusAreaPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(focusArea);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FocusAreaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(FocusAreaPrimaryKey focusAreaPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var focusArea = focusAreaPrimaryKey.EntityObject;
            viewModel.UpdateModel(focusArea, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FocusAreaManageFeature]
        public PartialViewResult DeleteFocusArea(FocusAreaPrimaryKey focusAreaPrimaryKey)
        {
            var focusArea = focusAreaPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(focusArea.FocusAreaID);
            return ViewDeleteFocusArea(focusArea, viewModel);
        }

        private PartialViewResult ViewDeleteFocusArea(FocusArea focusArea, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !focusArea.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Focus Area '{0}'?", focusArea.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Focus Area", SitkaRoute<FocusAreaController>.BuildLinkFromExpression(x => x.Summary(focusArea), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FocusAreaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteFocusArea(FocusAreaPrimaryKey focusAreaPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var focusArea = focusAreaPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteFocusArea(focusArea, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.FocusAreas.Remove(focusArea);
            return new ModalDialogFormJsonResult();
        }

        [FocusAreaViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(FocusAreaPrimaryKey focusAreaPrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectFocusAreas = GetProjectsAndGridSpec(out gridSpec, focusAreaPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectFocusAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, FocusArea focusArea)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return focusArea.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [FocusAreaManageFeature]
        public PartialViewResult EditDescription(FocusAreaPrimaryKey focusAreaPrimaryKey)
        {
            var focusArea = focusAreaPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(focusArea.FocusAreaDescriptionHtmlString);
            return ViewEditDescription(focusArea, viewModel);
        }

        [HttpPost]
        [FocusAreaManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(FocusAreaPrimaryKey focusAreaPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var focusArea = focusAreaPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(focusArea, viewModel);
            }
            viewModel.UpdateModel(focusArea);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(FocusArea focusArea, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForFocusArea(focusArea, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }
    }
}