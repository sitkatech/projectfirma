using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy.Index;
using IndexGridSpec = ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy.IndexViewData;
using Summary = ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy.SummaryViewData;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class TransportationStrategyController : LakeTahoeInfoBaseController
    {
        [TransportationStrategyViewFeature]
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
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.TransportationStrategiesList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TransportationStrategyViewFeature]
        public GridJsonNetJObjectResult<TransportationStrategy> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var transportationStrategies = GetTransportationStrategiesAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TransportationStrategy>(transportationStrategies, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<TransportationStrategy> GetTransportationStrategiesAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new TransportationStrategyManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.TransportationStrategies.ToList().OrderBy(x => x.DisplayName).ToList();
        }

        [TransportationStrategyViewFeature]
        public ViewResult Summary(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;

            var allTransportationStrategies = HttpRequestStorage.DatabaseEntities.TransportationStrategies.ToList();
            var relevantTransportationObjectives =
                allTransportationStrategies.Where(x => x.TransportationStrategyID == transportationStrategy.TransportationStrategyID)
                    .SelectMany(x => x.TransportationObjectives)
                    .OrderBy(x => x.SortOrder)
                    .Select(x => x.DisplayName)
                    .ToList();

            var chartPopupUrl = SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(x => x.GoogleChartPopup(transportationStrategyPrimaryKey));
            var googleChart = transportationStrategy.Projects.SelectMany(x => x.ProjectFundingSourceExpenditures)
                .ToList()
                .ToGoogleChart(x => x.Project.TransportationObjective.DisplayName,
                    relevantTransportationObjectives,
                    x => x.Project.TransportationObjective.SortOrder,
                    "ReportedExpendituresChart",
                    "Annual Expenditure by Transportation Strategy",
                    chartPopupUrl);

            var transportationExpendituresBarChartViewData = new TransportationExpendituresBarChartViewData(googleChart);

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TransportationStrategy,
                new List<int> {transportationStrategy.TransportationStrategyID},
                ProjectColorByType.ProjectStage);

            var projects = transportationStrategy.Projects.ToList();
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "TransporationStrategyProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new SummaryViewData(CurrentPerson,
                transportationStrategy,
                transportationExpendituresBarChartViewData,
                projectLocationsMapInitJson,
                projectLocationsMapViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [TransportationStrategyManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TransportationStrategyManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var transportationStrategy = new TransportationStrategy(string.Empty);
            viewModel.UpdateModel(transportationStrategy, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.TransportationStrategies.Add(transportationStrategy);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TransportationStrategyManageFeature]
        public PartialViewResult Edit(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(transportationStrategy);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TransportationStrategyManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            viewModel.UpdateModel(transportationStrategy, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TransportationStrategyManageFeature]
        public PartialViewResult DeleteTransportationStrategy(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(transportationStrategy.TransportationStrategyID);
            return ViewDeleteTransportationStrategy(transportationStrategy, viewModel);
        }

        private PartialViewResult ViewDeleteTransportationStrategy(TransportationStrategy transportationStrategy, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !transportationStrategy.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this TransportationStrategy '{0}'?", transportationStrategy.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("TransportationStrategy",
                    SitkaRoute<TransportationStrategyController>.BuildLinkFromExpression(x => x.Summary(transportationStrategy), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TransportationStrategyManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTransportationStrategy(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTransportationStrategy(transportationStrategy, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.TransportationStrategies.Remove(transportationStrategy);
            return new ModalDialogFormJsonResult();
        }

        [TransportationStrategyViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            TransportationListProjectGridSpec gridSpec;
            var projectTransportationStrategies = GetProjectsAndGridSpec(out gridSpec, transportationStrategyPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTransportationStrategies, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out TransportationListProjectGridSpec gridSpec, TransportationStrategy transportationStrategy)
        {
            gridSpec = new TransportationListProjectGridSpec(CurrentPerson);
            return transportationStrategy.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [TransportationStrategyManageFeature]
        public PartialViewResult EditDescription(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(transportationStrategy.TransportationStrategyDescriptionHtmlString);
            return ViewEditDescription(transportationStrategy, viewModel);
        }

        [HttpPost]
        [TransportationStrategyManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(transportationStrategy, viewModel);
            }
            viewModel.UpdateModel(transportationStrategy);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(TransportationStrategy transportationStrategy, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForTransportationStrategy(transportationStrategy, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult GoogleChartPopup(TransportationStrategyPrimaryKey transportationStrategyPrimaryKey)
        {
            var transportationStrategy = transportationStrategyPrimaryKey.EntityObject;

            var allTransportationStrategies = HttpRequestStorage.DatabaseEntities.TransportationStrategies.ToList();
            var relevantTransportationObjectives =
                allTransportationStrategies.Where(x => x.TransportationStrategyID == transportationStrategy.TransportationStrategyID)
                    .SelectMany(x => x.TransportationObjectives)
                    .OrderBy(x => x.SortOrder)
                    .Select(x => x.DisplayName)
                    .ToList();

            var googleChart = transportationStrategy.Projects.SelectMany(x => x.ProjectFundingSourceExpenditures)
                .ToList()
                .ToGoogleChart(x => x.Project.TransportationObjective.DisplayName,
                    relevantTransportationObjectives,
                    x => x.Project.TransportationObjective.SortOrder,
                    "ReportedExpendituresChart",
                    "Annual Expenditure by Transportation Strategy",
                    string.Empty);

            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }

    }
}