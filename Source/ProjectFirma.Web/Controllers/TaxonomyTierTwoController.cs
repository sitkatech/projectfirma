using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.TaxonomyTierTwo;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using DetailViewData = ProjectFirma.Web.Views.TaxonomyTierTwo.DetailViewData;
using Edit = ProjectFirma.Web.Views.TaxonomyTierTwo.Edit;
using EditViewData = ProjectFirma.Web.Views.TaxonomyTierTwo.EditViewData;
using EditViewModel = ProjectFirma.Web.Views.TaxonomyTierTwo.EditViewModel;
using Index = ProjectFirma.Web.Views.TaxonomyTierTwo.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyTierTwo.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyTierTwo.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyTierTwo.Detail;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierTwoController : FirmaBaseController
    {
        [TaxonomyTierTwoViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        [AdminFeature]
        public ViewResult Manage()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TaxonomyTierTwoList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TaxonomyTierTwoViewFeature]
        public GridJsonNetJObjectResult<TaxonomyTierTwo> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var taxonomyTierTwos = GetTaxonomyTierTwosAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyTierTwo>(taxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<TaxonomyTierTwo> GetTaxonomyTierTwosAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new TaxonomyTierTwoManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToList().OrderBy(x => x.TaxonomyTierTwoName).ToList();
        }

        [TaxonomyTierTwoViewFeature]
        public ViewResult Detail(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var taxonomyTierTwoProjects = taxonomyTierTwo.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? taxonomyTierTwoProjects.Where(p => p.IsVisibleToEveryone()).ToList() : taxonomyTierTwoProjects;

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyTierTwo, new List<int> {taxonomyTierTwo.TaxonomyTierTwoID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "TaxonomyTierTwoProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new DetailViewData(CurrentPerson,
                taxonomyTierTwo,
                projectLocationsMapInitJson,
                projectLocationsMapViewData);
            return RazorView<Summary, DetailViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewNew(viewModel);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var taxonomyTierTwo = new TaxonomyTierTwo(viewModel.TaxonomyTierThreeID, string.Empty, string.Empty);
            viewModel.UpdateModel(taxonomyTierTwo, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.Add(taxonomyTierTwo);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult Edit(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyTierTwo);
            return ViewEdit(viewModel, taxonomyTierTwo.Projects.Any(), taxonomyTierTwo.TaxonomyTierThree.DisplayName);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey, EditViewModel viewModel)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, taxonomyTierTwo.Projects.Any(), taxonomyTierTwo.TaxonomyTierThree.DisplayName);
            }
            viewModel.UpdateModel(taxonomyTierTwo, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewNew(EditViewModel viewModel)
        {
            return ViewEdit(viewModel, false, string.Empty);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, bool hasProjects, string taxonomyTierThreeDisplayName)
        {
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList()
                .OrderBy(x => x.DisplayName)
                .ToSelectList(x => x.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            var viewData = new EditViewData(taxonomyTierThrees, taxonomyTierThreeDisplayName, hasProjects);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult DeleteTaxonomyTierTwo(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyTierTwo.TaxonomyTierTwoID);
            return ViewDeleteTaxonomyTierTwo(taxonomyTierTwo, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyTierTwo(TaxonomyTierTwo taxonomyTierTwo, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyTierTwo.HasDependentObjects() && HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.Count() > 1; ;
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", MultiTenantHelpers.GetTaxonomyTierTwoDisplayName(), taxonomyTierTwo.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(MultiTenantHelpers.GetTaxonomyTierTwoDisplayName(), SitkaRoute<TaxonomyTierTwoController>.BuildLinkFromExpression(x => x.Detail(taxonomyTierTwo), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyTierTwo(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyTierTwo(taxonomyTierTwo, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.Remove(taxonomyTierTwo);
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyTierTwoViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectTaxonomyTierTwos = GetProjectsAndGridSpec(out gridSpec, taxonomyTierTwoPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTaxonomyTierTwos, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, TaxonomyTierTwo taxonomyTierTwo)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return taxonomyTierTwo.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [TaxonomyTierTwoManageFeature]
        public PartialViewResult EditDescription(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(taxonomyTierTwo.TaxonomyTierTwoDescriptionHtmlString);
            return ViewEditDescription(taxonomyTierTwo, viewModel);
        }

        [HttpPost]
        [TaxonomyTierTwoManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(taxonomyTierTwo, viewModel);
            }
            viewModel.UpdateModel(taxonomyTierTwo);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(TaxonomyTierTwo taxonomyTierTwo, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForTaxonomyTierTwo(taxonomyTierTwo, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }

        [TaxonomyTierTwoViewFeature]
        public PartialViewResult DefinitionAndGuidance(TaxonomyTierTwoPrimaryKey taxonomyTierTwoPrimaryKey)
        {
            var taxonomyTierTwo = taxonomyTierTwoPrimaryKey.EntityObject;
            var viewData = new DefinitionAndGuidanceViewData(taxonomyTierTwo);
            return RazorPartialView<DefinitionAndGuidance, DefinitionAndGuidanceViewData>(viewData);
        }
    }
}