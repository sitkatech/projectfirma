using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Classification;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using DetailViewData = ProjectFirma.Web.Views.Classification.DetailViewData;
using Detail = ProjectFirma.Web.Views.Classification.Detail;
using Index = ProjectFirma.Web.Views.Classification.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Classification.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Classification.IndexViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ClassificationController : FirmaBaseController
    {
        [PerformanceMeasureViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ClassificationsList);
            var viewData = new IndexViewData(CurrentPerson, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<Classification> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(new PerformanceMeasureManageFeature().HasPermissionByPerson(CurrentPerson));
            var taxonomyTierOnes = HttpRequestStorage.DatabaseEntities.Classifications.ToList().OrderBy(x => x.ClassificationName).ToList();
            return new GridJsonNetJObjectResult<Classification>(taxonomyTierOnes, gridSpec);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var classification = new Classification(viewModel.DisplayName, string.Empty, "#BBBBBB", string.Empty);
            viewModel.UpdateModel(classification, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.Classifications.Add(classification);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay(string.Format("New {0} {1} successfully created!", MultiTenantHelpers.GetClassificationDisplayName(), classification.GetDisplayNameAsUrl()));

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult Edit(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(classification);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ClassificationPrimaryKey classificationPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var classification = classificationPrimaryKey.EntityObject;
            viewModel.UpdateModel(classification, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult DeleteClassification(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(classification.ClassificationID);
            return ViewDeleteClassification(classification, viewModel);
        }

        private PartialViewResult ViewDeleteClassification(Classification classification, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !classification.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this {0} '{1}'?", MultiTenantHelpers.GetClassificationDisplayName(), classification.DisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(MultiTenantHelpers.GetClassificationDisplayName(), SitkaRoute<ClassificationController>.BuildLinkFromExpression(x => x.Detail(classification), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteClassification(ClassificationPrimaryKey classificationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var classification = classificationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteClassification(classification, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.Classifications.Remove(classification);
            return new ModalDialogFormJsonResult();
        }

        [PerformanceMeasureViewFeature]
        public ViewResult Detail(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var classification = classificationPrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentPerson, classification);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [PerformanceMeasureViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(ClassificationPrimaryKey classificationPrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectClassifications = GetProjectsAndGridSpec(out gridSpec, classificationPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectClassifications, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, Classification classification)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            return classification.AssociatedProjects.ToList();
        }
    }
}