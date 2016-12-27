using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.TaxonomyTierThree;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Index = ProjectFirma.Web.Views.TaxonomyTierThree.Index;
using IndexGridSpec = ProjectFirma.Web.Views.TaxonomyTierThree.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.TaxonomyTierThree.IndexViewData;
using Summary = ProjectFirma.Web.Views.TaxonomyTierThree.Summary;
using SummaryViewData = ProjectFirma.Web.Views.TaxonomyTierThree.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class TaxonomyTierThreeController : FirmaBaseController
    {
        [TaxonomyTierThreeViewFeature]
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
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TaxonomyTierThreesList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [TaxonomyTierThreeViewFeature]
        public GridJsonNetJObjectResult<TaxonomyTierThree> IndexGridJsonData()
        {
            IndexGridSpec gridSpec;
            var taxonomyTierThrees = GetTaxonomyTierThreesAndGridSpec(out gridSpec, CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TaxonomyTierThree>(taxonomyTierThrees, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<TaxonomyTierThree> GetTaxonomyTierThreesAndGridSpec(out IndexGridSpec gridSpec, Person currentPerson)
        {
            var hasDeletePermission = new TaxonomyTierThreeManageFeature().HasPermissionByPerson(currentPerson);
            gridSpec = new IndexGridSpec(hasDeletePermission);
            return HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList().OrderBy(x => x.TaxonomyTierThreeName).ToList();
        }

        [TaxonomyTierThreeViewFeature]
        public ViewResult Summary(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey)
        {
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;

            var taxonomyTierThreeProjects = taxonomyTierThree.Projects.ToList();
            var projects = IsCurrentUserAnonymous() ? taxonomyTierThreeProjects.Where(p => p.IsVisibleToEveryone()).ToList() : taxonomyTierThreeProjects;

            var projectMapCustomization = new ProjectMapCustomization(ProjectLocationFilterType.TaxonomyTierThree, new List<int> {taxonomyTierThree.TaxonomyTierThreeID}, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, projectMapCustomization, "TaxonomyTierThreeProjectMap");

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, ProjectColorByType.ProjectStage.ProjectColorByTypeDisplayName);

            var viewData = new SummaryViewData(CurrentPerson, taxonomyTierThree, projectLocationsMapInitJson, projectLocationsMapViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [TaxonomyTierThreeManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TaxonomyTierThreeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var taxonomyTierThree = new TaxonomyTierThree(string.Empty);
            viewModel.UpdateModel(taxonomyTierThree, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.Add(taxonomyTierThree);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [TaxonomyTierThreeManageFeature]
        public PartialViewResult Edit(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey)

        {
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(taxonomyTierThree);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [TaxonomyTierThreeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;
            viewModel.UpdateModel(taxonomyTierThree, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [TaxonomyTierThreeManageFeature]
        public PartialViewResult DeleteTaxonomyTierThree(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey)
        {
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(taxonomyTierThree.TaxonomyTierThreeID);
            return ViewDeleteTaxonomyTierThree(taxonomyTierThree, viewModel);
        }

        private PartialViewResult ViewDeleteTaxonomyTierThree(TaxonomyTierThree taxonomyTierThree, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !taxonomyTierThree.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(), taxonomyTierThree.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(MultiTenantHelpers.GetTaxonomyTierThreeDisplayName(), SitkaRoute<TaxonomyTierThreeController>.BuildLinkFromExpression(x => x.Summary(taxonomyTierThree), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [TaxonomyTierThreeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTaxonomyTierThree(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTaxonomyTierThree(taxonomyTierThree, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.Remove(taxonomyTierThree);
            return new ModalDialogFormJsonResult();
        }

        [TaxonomyTierThreeViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectTaxonomyTierThrees = GetProjectsAndGridSpec(out gridSpec, taxonomyTierThreePrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTaxonomyTierThrees, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, TaxonomyTierThree taxonomyTierThree)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true);
            return taxonomyTierThree.Projects.OrderBy(x => x.DisplayName).ToList();
        }

        [HttpGet]
        [TaxonomyTierThreeManageFeature]
        public PartialViewResult EditDescription(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey)
        {
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(taxonomyTierThree.TaxonomyTierThreeDescriptionHtmlString);
            return ViewEditDescription(taxonomyTierThree, viewModel);
        }

        [HttpPost]
        [TaxonomyTierThreeManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditDescription(TaxonomyTierThreePrimaryKey taxonomyTierThreePrimaryKey, EditRtfContentViewModel viewModel)
        {
            var taxonomyTierThree = taxonomyTierThreePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditDescription(taxonomyTierThree, viewModel);
            }
            viewModel.UpdateModel(taxonomyTierThree);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditDescription(TaxonomyTierThree taxonomyTierThree, EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.CkEditorUploadFileResourceForTaxonomyTierThree(taxonomyTierThree, null)));
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }
    }
}