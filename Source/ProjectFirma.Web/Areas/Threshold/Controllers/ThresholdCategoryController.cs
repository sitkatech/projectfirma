using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Edit = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.Edit;
using EditViewData = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.EditViewData;
using EditViewModel = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.EditViewModel;
using Index = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.Index;
using IndexViewData = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.IndexViewData;
using Summary = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory.SummaryViewData;

namespace ProjectFirma.Web.Areas.Threshold.Controllers
{
    public class ThresholdCategoryController : LakeTahoeInfoBaseController
    {
        [ThresholdIndicatorViewFeature]
        public ViewResult Index()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.ThresholdsTaxonomy);
            var thresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.ToList();
            var thresholdEvaluationPeriods = HttpRequestStorage.DatabaseEntities.ThresholdEvaluationPeriods.ToList();
            var thresholdCategoriesAsFancyTreeNodes = thresholdCategories.Select(x => x.ToFancyTreeNode(thresholdEvaluationPeriods)).ToList();
            var thresholdTaxonomyViewData = new ThresholdTaxonomyViewData(thresholdCategoriesAsFancyTreeNodes, thresholdEvaluationPeriods, true);
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage, thresholdTaxonomyViewData);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [HttpGet]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult Edit(ThresholdCategoryPrimaryKey thresholdCategoryPrimaryKey)
        {
            var thresholdCategory = thresholdCategoryPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(thresholdCategory);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ThresholdIndicatorManageFeature]
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

        [ThresholdIndicatorViewFeature]
        public ViewResult Summary(string thresholdCategoryName)
        {
            var thresholdCategory = HttpRequestStorage.DatabaseEntities.ThresholdCategories.GetThresholdCategoryByThresholdCategoryeName(thresholdCategoryName);
            var thresholdEvaluationPeriods = HttpRequestStorage.DatabaseEntities.ThresholdEvaluationPeriods.ToList();
            var thresholdCategoriesAsFancyTreeNodes = new List<FancyTreeNode> {thresholdCategory.ToFancyTreeNode(thresholdEvaluationPeriods)};
            var thresholdTaxonomyViewData = new ThresholdTaxonomyViewData(thresholdCategoriesAsFancyTreeNodes, thresholdEvaluationPeriods, false);
            var indicatorRelationshipsViewData = new IndicatorRelationshipsViewData(thresholdCategory.GetRelatedIndicatorsByIndicatorType(IndicatorType.Action),
                thresholdCategory.GetRelatedIndicatorsByIndicatorType(IndicatorType.IntermediateResult),
                thresholdCategory.GetRelatedIndicatorsByIndicatorType(IndicatorType.Outcome));
            var viewData = new SummaryViewData(CurrentPerson, thresholdCategory, thresholdTaxonomyViewData, indicatorRelationshipsViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [ThresholdIndicatorViewFeature]
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