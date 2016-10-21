using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using Summary = ProjectFirma.Web.Areas.Threshold.Views.ThresholdReportingCategory.Summary;
using SummaryViewData = ProjectFirma.Web.Areas.Threshold.Views.ThresholdReportingCategory.SummaryViewData;

namespace ProjectFirma.Web.Areas.Threshold.Controllers
{
    public class ThresholdReportingCategoryController : LakeTahoeInfoBaseController
    {
        [ThresholdIndicatorViewFeature]
        public ViewResult Summary(string thresholdReportingCategoryName)
        {
            var thresholdReportingCategory = HttpRequestStorage.DatabaseEntities.ThresholdReportingCategories.GetThresholdReportingCategoryByThresholdReportingCategoryName(thresholdReportingCategoryName);
            var thresholdEvaluationPeriods = HttpRequestStorage.DatabaseEntities.ThresholdEvaluationPeriods.ToList();
            var thresholdCategoriesAsFancyTreeNodes = new List<FancyTreeNode> { thresholdReportingCategory.ThresholdCategory.ToFancyTreeNode(thresholdEvaluationPeriods) };
            var thresholdTaxonomyViewData = new ThresholdTaxonomyViewData(thresholdCategoriesAsFancyTreeNodes, thresholdEvaluationPeriods, false);

            var indicatorRelationshipsViewData = new IndicatorRelationshipsViewData(thresholdReportingCategory.GetRelatedIndicatorsByIndicatorType(IndicatorType.Action),
                thresholdReportingCategory.GetRelatedIndicatorsByIndicatorType(IndicatorType.IntermediateResult),
                thresholdReportingCategory.GetRelatedIndicatorsByIndicatorType(IndicatorType.Outcome));
            var viewData = new SummaryViewData(CurrentPerson, thresholdReportingCategory, thresholdTaxonomyViewData, indicatorRelationshipsViewData);
            return RazorView<Summary, SummaryViewData>(viewData);
        }

        [HttpGet]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult Edit(ThresholdReportingCategoryPrimaryKey thresholdReportingCategoryPrimaryKey)
        {
            var thresholdReportingCategory = thresholdReportingCategoryPrimaryKey.EntityObject;
            var viewModel = new EditRtfContentViewModel(thresholdReportingCategory.NarrativeHtmlString);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ThresholdReportingCategoryPrimaryKey thresholdReportingCategoryPrimaryKey, EditRtfContentViewModel viewModel)
        {
            var thresholdReportingCategory = thresholdReportingCategoryPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            viewModel.UpdateModel(thresholdReportingCategory);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditRtfContentViewModel viewModel)
        {
            var viewData = new EditRtfContentViewData(CkEditorExtension.CkEditorToolbar.Minimal, null);
            return RazorPartialView<EditRtfContent, EditRtfContentViewData, EditRtfContentViewModel>(viewData, viewModel);
        }
    }
}