using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Watershed;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Detail = ProjectFirma.Web.Views.Watershed.Detail;
using DetailViewData = ProjectFirma.Web.Views.Watershed.DetailViewData;
using Index = ProjectFirma.Web.Views.Watershed.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Watershed.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Watershed.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class WatershedController : FirmaBaseController
    {
        [WatershedManageFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }
        
        [WatershedViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.WatershedsList);
            var layerGeoJsons = new List<LayerGeoJson>();
            var jurisdictions = HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures();
            var geoJsonForJurisdictions = Jurisdiction.ToGeoJsonFeatureCollection(jurisdictions);
            layerGeoJsons.Add(new LayerGeoJson("County/City", geoJsonForJurisdictions, "#FF6C2D", 0.6m, LayerInitialVisibility.Hide));

            var watersheds = HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures();
            var geoJsonForWatersheds = Models.Watershed.ToGeoJsonFeatureCollection(watersheds);
            layerGeoJsons.Add(new LayerGeoJson("Watershed", geoJsonForWatersheds, "#59ACFF", 0.6m, LayerInitialVisibility.Show));

            var mapInitJson = new MapInitJson("watershedIndex", 10, layerGeoJsons, BoundingBox.MakeNewDefaultBoundingBox());
            var viewData = new IndexViewData(CurrentPerson, firmaPage, mapInitJson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [WatershedViewFeature]
        public GridJsonNetJObjectResult<Watershed> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var watersheds = GetWatershedsAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Watershed>(watersheds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Watershed> GetWatershedsAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            gridSpec = new IndexGridSpec();
            return HttpRequestStorage.DatabaseEntities.Watersheds.OrderBy(x => x.WatershedName).ToList();
        }

        [HttpGet]
        [WatershedManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [WatershedManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var watershed = new Watershed(string.Empty);
            viewModel.UpdateModel(watershed, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.Watersheds.Add(watershed);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [WatershedManageFeature]
        public PartialViewResult Edit(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(watershed);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [WatershedManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(WatershedPrimaryKey watershedPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var watershed = watershedPrimaryKey.EntityObject;
            viewModel.UpdateModel(watershed, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [WatershedViewFeature]
        public ViewResult Detail(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            var mapDivID = string.Format("watershed_{0}_Map", watershed.WatershedID);
            var layers = MapInitJson.GetWatershedLayers(watershed, watershed.AssociatedProjects);
            var mapInitJson = new MapInitJson(mapDivID, 10, layers, new BoundingBox(watershed.WatershedFeature));

            var projectFundingSourceExpenditures = watershed.AssociatedProjects.SelectMany(x => x.ProjectFundingSourceExpenditures);

            var chartPopupUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(x => x.GoogleChartPopup(watershedPrimaryKey));
            var googleChartJson = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.Organization.Sector.SectorDisplayName,
                Sector.All.Select(x => x.SectorDisplayName).ToList(),
                x => x.FundingSource.Organization.Sector.SectorDisplayName,
                "ReportedExpendituresChart",
                watershed.DisplayName, chartPopupUrl);

            var calendarYearExpendituresLineChartViewData = new CalendarYearExpendituresLineChartViewData(googleChartJson,
                FirmaHelpers.DefaultColorRange);

            var viewData = new DetailViewData(CurrentPerson, watershed, mapInitJson, calendarYearExpendituresLineChartViewData);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [WatershedManageFeature]
        public PartialViewResult DeleteWatershed(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(watershed.WatershedID);
            return ViewDeleteWatershed(watershed, viewModel);
        }

        private PartialViewResult ViewDeleteWatershed(Watershed watershed, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !watershed.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this Watershed '{0}'?", watershed.WatershedName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Watershed", SitkaRoute<WatershedController>.BuildLinkFromExpression(x => x.Detail(watershed), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [WatershedManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteWatershed(WatershedPrimaryKey watershedPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteWatershed(watershed, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.Watersheds.Remove(watershed);
            return new ModalDialogFormJsonResult();
        }

        [WatershedViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(WatershedPrimaryKey watershedPrimaryKey)
        {
            var gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectWatersheds = watershedPrimaryKey.EntityObject.AssociatedProjects.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectWatersheds, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult GoogleChartPopup(WatershedPrimaryKey watershedPrimaryKey)
        {
            var watershed = watershedPrimaryKey.EntityObject;
            var projectFundingSourceExpenditures = watershed.AssociatedProjects.SelectMany(x => x.ProjectFundingSourceExpenditures);

            var googleChart = projectFundingSourceExpenditures.ToGoogleChart(x => x.FundingSource.Organization.Sector.SectorDisplayName,
                Sector.All.Select(x => x.SectorDisplayName).ToList(),
                x => x.FundingSource.Organization.Sector.SectorDisplayName,
                "ReportedExpendituresChart",
                watershed.DisplayName, string.Empty);

            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }

    }
}