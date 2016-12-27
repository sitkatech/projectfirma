using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Classification;
using Index = ProjectFirma.Web.Views.Classification.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Classification.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Classification.IndexViewData;
using Summary = ProjectFirma.Web.Views.Classification.Summary;
using SummaryViewData = ProjectFirma.Web.Views.Classification.SummaryViewData;

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
            var gridSpec = new IndexGridSpec();
            var taxonomyTierOnes = HttpRequestStorage.DatabaseEntities.Classifications.ToList().OrderBy(x => x.ClassificationName).ToList();
            return new GridJsonNetJObjectResult<Classification>(taxonomyTierOnes, gridSpec);
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

        [PerformanceMeasureViewFeature]
        public ViewResult Summary(string classificationName)
        {
            var classification = HttpRequestStorage.DatabaseEntities.Classifications.GetClassificationByClassificationeName(classificationName);
            var viewData = new SummaryViewData(CurrentPerson, classification);
            return RazorView<Summary, SummaryViewData>(viewData);
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