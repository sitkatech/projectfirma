using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ThresholdCategory;
using Index = ProjectFirma.Web.Views.ThresholdCategory.Index;
using IndexViewData = ProjectFirma.Web.Views.ThresholdCategory.IndexViewData;
using Summary = ProjectFirma.Web.Views.ThresholdCategory.Summary;
using SummaryViewData = ProjectFirma.Web.Views.ThresholdCategory.SummaryViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ThresholdCategoryController : LakeTahoeInfoBaseController
    {
        [IndicatorViewFeature]
        public ViewResult Index()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.ThresholdCategoriesList);
            var thresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.ToList();
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [HttpGet]
        [IndicatorManageFeature]
        public PartialViewResult Edit(ThresholdCategoryPrimaryKey thresholdCategoryPrimaryKey)
        {
            var thresholdCategory = thresholdCategoryPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(thresholdCategory);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [IndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ThresholdCategoryPrimaryKey thresholdCategoryPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var thresholdCategory = thresholdCategoryPrimaryKey.EntityObject;
            viewModel.UpdateModel(thresholdCategory, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [IndicatorViewFeature]
        public ViewResult Summary(string thresholdCategoryName)
        {
            var thresholdCategory = HttpRequestStorage.DatabaseEntities.ThresholdCategories.GetThresholdCategoryByThresholdCategoryeName(thresholdCategoryName);
            var viewData = new SummaryViewData(CurrentPerson, thresholdCategory);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [IndicatorViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(ThresholdCategoryPrimaryKey thresholdCategoryPrimaryKey)
        {
            BasicProjectInfoGridSpec gridSpec;
            var projectThresholdCategorys = GetProjectsAndGridSpec(out gridSpec, thresholdCategoryPrimaryKey.EntityObject);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectThresholdCategorys, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private List<Project> GetProjectsAndGridSpec(out BasicProjectInfoGridSpec gridSpec, ThresholdCategory thresholdCategory)
        {
            gridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false);
            return thresholdCategory.AssociatedProjects.ToList();
        }
    }
}