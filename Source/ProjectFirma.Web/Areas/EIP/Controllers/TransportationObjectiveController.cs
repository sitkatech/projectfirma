using System.Collections.Generic;
using System.Globalization;
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
using ProjectFirma.Web.Areas.EIP.Views.TransportationObjective;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Areas.EIP.Views.TransportationObjective.Index;
using IndexGridSpec = ProjectFirma.Web.Areas.EIP.Views.TransportationObjective.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Areas.EIP.Views.TransportationObjective.IndexViewData;
using Summary = ProjectFirma.Web.Areas.EIP.Views.TransportationObjective.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.EIP.Views.TransportationObjective.SummaryViewData;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class TransportationObjectiveController : LakeTahoeInfoBaseController
    {
        [TransportationObjectiveViewFeature]
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
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.TransportationObjectivesList);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TransportationObjectiveViewFeature]
        public GridJsonNetJObjectResult<TransportationObjective> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var transportationObjectives = GetTransportationObjectivesAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TransportationObjective>(transportationObjectives, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<TransportationObjective> GetTransportationObjectivesAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new TransportationObjectiveManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.TransportationObjectives.ToList().OrderBy(x => x.DisplayName).ToList();
        }

        [TransportationObjectiveViewFeature]
        public ViewResult Summary(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;

            var chartPopupUrl = SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(x => x.GoogleChartPopup(transportationObjectivePrimaryKey));
            var googleChartJson = transportationObjective.Projects.SelectMany(p => p.ProjectFundingSourceExpenditures)
                .ToList()
                .ToGoogleChart(x => x.Project.TransportationObjective.DisplayName,
                    new List<string> {transportationObjective.DisplayName},
                    x => x.Project.TransportationObjective.SortOrder,
                    "ReportedExpendituresChart",
                    "Annual Expenditure by Transportation Objective", chartPopupUrl);

            var transportationExpendituresBarChartViewData = new TransportationExpendituresBarChartViewData(googleChartJson);

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TransportationObjective,
                new List<int> {transportationObjective.TransportationObjectiveID},
                ProjectColorByType.ProjectStage);
            var projects = transportationObjective.Projects.ToList();            
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "TransporationObjectiveProjectMap");
                        
            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new SummaryViewData(CurrentPerson, transportationObjective, transportationExpendituresBarChartViewData, projectLocationsMapInitJson, projectLocationsMapViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [TransportationObjectiveManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TransportationObjectiveManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var transportationObjective = new TransportationObjective(viewModel.TransportationStrategyID, string.Empty, FundingType.Capital.FundingTypeID);
            viewModel.UpdateModel(transportationObjective, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.TransportationObjectives.Add(transportationObjective);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TransportationObjectiveManageFeature]
        public PartialViewResult Edit(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(transportationObjective);
            return ViewEdit(viewModel,
                transportationObjective.Projects.Any(),
                transportationObjective.TransportationStrategy.DisplayName,
                transportationObjective.FundingType.FundingTypeDisplayName);
        }

        [HttpPost]
        [TransportationObjectiveManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey, EditViewModel viewModel)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel,
                    transportationObjective.Projects.Any(),
                    transportationObjective.TransportationStrategy.DisplayName,
                    transportationObjective.FundingType.FundingTypeDisplayName);
            }
            viewModel.UpdateModel(transportationObjective, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, false, string.Empty, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool hasProjects, string transportationStrategyDisplayName, string fundingTypeDisplayName)
        {
            var transportationStrategies =
                HttpRequestStorage.DatabaseEntities.TransportationStrategies.ToList()
                    .OrderBy(x => x.DisplayName)
                    .ToSelectList(x => x.TransportationStrategyID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var fundingTypes =
                FundingType.All.OrderBy(x => x.FundingTypeDisplayName)
                    .ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), x => x.FundingTypeDisplayName);
            var viewData = new EditViewData(transportationStrategies, transportationStrategyDisplayName, fundingTypes, fundingTypeDisplayName, hasProjects);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TransportationObjectiveManageFeature]
        public PartialViewResult DeleteTransportationObjective(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(transportationObjective.TransportationObjectiveID);
            return ViewDeleteTransportationObjective(transportationObjective, viewModel);
        }

        private PartialViewResult ViewDeleteTransportationObjective(TransportationObjective transportationObjective, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !transportationObjective.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Transportation Objective '{0}'?", transportationObjective.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Transportation Objective",
                    SitkaRoute<TransportationObjectiveController>.BuildLinkFromExpression(x => x.Summary(transportationObjective), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TransportationObjectiveManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTransportationObjective(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTransportationObjective(transportationObjective, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.TransportationObjectives.Remove(transportationObjective);
            return new ModalDialogFormJsonResult();
        }

        [TransportationObjectiveViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            TransportationListProjectGridSpec gridSpec;
            var projectTransportationObjectives = GetProjectsAndGridSpec(out gridSpec, transportationObjectivePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTransportationObjectives, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out TransportationListProjectGridSpec gridSpec, TransportationObjective transportationObjective)
        {
            gridSpec = new TransportationListProjectGridSpec(CurrentPerson);
            return transportationObjective.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [TransportationObjectiveManageFeature]
        public PartialViewResult EditDescription(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(transportationObjective.TransportationObjectiveDescriptionHtmlString);
            return ViewEditDescription(transportationObjective, viewModel);
        }

        [HttpPost]
        [TransportationObjectiveManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey, EditRtfContentViewModel viewModel)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(transportationObjective, viewModel);
            }
            viewModel.UpdateModel(transportationObjective);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(TransportationObjective transportationObjective, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForTransportationObjective(transportationObjective, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult GoogleChartPopup(TransportationObjectivePrimaryKey transportationObjectivePrimaryKey)
        {
            var transportationObjective = transportationObjectivePrimaryKey.EntityObject;
            
            var googleChart = transportationObjective.Projects.SelectMany(p => p.ProjectFundingSourceExpenditures)
                .ToList()
                .ToGoogleChart(x => x.Project.TransportationObjective.DisplayName,
                    new List<string> { transportationObjective.DisplayName },
                    x => x.Project.TransportationObjective.SortOrder,
                    "ReportedExpendituresChart",
                    "Annual Expenditure by Transportation Objective", string.Empty);

            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }
    }
}