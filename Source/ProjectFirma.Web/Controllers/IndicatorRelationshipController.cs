using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.IndicatorRelationship;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class IndicatorRelationshipController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [IndicatorManageFeature]
        public PartialViewResult EditFromIndicator(IndicatorPrimaryKey indicatorPrimaryKey)
        {
            var indicator = indicatorPrimaryKey.EntityObject;
            // for now, we are expecting that the relationships are only between a non threshold indicator and a threshold indicator
            var indicatorRelationships =
                indicator.IndicatorRelationships.Where(x => x.RelatedIndicator.ThresholdIndicator != null)
                    .GroupBy(x => new {x.RelatedIndicator.ThresholdIndicator.ThresholdReportingCategoryID, x.IndicatorRelationshipTypeID});
            var indicatorThresholdReportingCategorySimples =
                indicatorRelationships.Select(y => new IndicatorThresholdReportingCategorySimple(indicator.IndicatorID, y.Key.ThresholdReportingCategoryID, y.Key.IndicatorRelationshipTypeID)).ToList();
            var viewModel = new EditViewModel(indicatorThresholdReportingCategorySimples);
            return ViewEditIndicatorRelationships(indicator, viewModel);
        }

        [HttpPost]
        [IndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditFromIndicator(IndicatorPrimaryKey indicatorPrimaryKey, EditViewModel viewModel)
        {
            var indicator = indicatorPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditIndicatorRelationships(indicator, viewModel);
            }
            var currentIndicatorRelationshipIDList = indicator.IndicatorRelationships.Select(x => x.IndicatorRelationshipID).ToList();
            UpdateImpl(viewModel, currentIndicatorRelationshipIDList);
            return new ModalDialogFormJsonResult();
        }

        [CrossAreaRoute]
        [HttpGet]
        [IndicatorManageFeature]
        public PartialViewResult EditFromThresholdReportingCategory(ThresholdReportingCategoryPrimaryKey thresholdReportingCategoryPrimaryKey)
        {
            var thresholdReportingCategory = thresholdReportingCategoryPrimaryKey.EntityObject;
            // for now, we are expecting that the relationships are only between a non threshold indicator and a threshold indicator
            var indicatorRelationships = thresholdReportingCategory.ThresholdIndicators.SelectMany(x => x.Indicator.IndicatorRelationshipsWhereYouAreTheRelatedIndicator).GroupBy(x => new {x.IndicatorID, x.IndicatorRelationshipTypeID});
            var indicatorRelationshipsimples = indicatorRelationships.Select(x => new IndicatorThresholdReportingCategorySimple(x.Key.IndicatorID, thresholdReportingCategory.ThresholdReportingCategoryID, x.Key.IndicatorRelationshipTypeID)).ToList();
            var viewModel = new EditViewModel(indicatorRelationshipsimples);
            return ViewEditIndicatorRelationships(thresholdReportingCategory, viewModel);
        }

        [CrossAreaRoute]
        [HttpPost]
        [IndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditFromThresholdReportingCategory(ThresholdReportingCategoryPrimaryKey thresholdReportingCategoryPrimaryKey, EditViewModel viewModel)
        {
            var thresholdReportingCategory = thresholdReportingCategoryPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditIndicatorRelationships(thresholdReportingCategory, viewModel);
            }
            var currentIndicatorRelationshipIDList = thresholdReportingCategory.ThresholdIndicators.SelectMany(x => x.Indicator.IndicatorRelationshipsWhereYouAreTheRelatedIndicator.Select(y => y.IndicatorRelationshipID)).ToList();
            UpdateImpl(viewModel, currentIndicatorRelationshipIDList);
            return new ModalDialogFormJsonResult();
        }

        private static void UpdateImpl(EditViewModel viewModel, List<int> indicatorRelationshipIDList)
        {
            HttpRequestStorage.DatabaseEntities.IndicatorRelationships.DeleteIndicatorRelationship(indicatorRelationshipIDList);
            HttpRequestStorage.DetectChangesAndSave();
            if (viewModel.IndicatorRelationships != null)
            {
                // Completely rebuild the list
                foreach (var indicatorRelationship in viewModel.IndicatorRelationships)
                {
                    var thresholdReportingCategory = HttpRequestStorage.DatabaseEntities.ThresholdReportingCategories.Find(indicatorRelationship.ThresholdReportingCategoryID);
                    foreach (var thresholdIndicator in thresholdReportingCategory.ThresholdIndicators)
                    {
                        HttpRequestStorage.DatabaseEntities.IndicatorRelationships.Add(new IndicatorRelationship(indicatorRelationship.IndicatorID, thresholdIndicator.IndicatorID, indicatorRelationship.IndicatorRelationshipTypeID));
                    }
                }
            }
        }

        private PartialViewResult ViewEditIndicatorRelationships(Indicator indicator, EditViewModel viewModel)
        {
            var allThresholdReportingCategories = HttpRequestStorage.DatabaseEntities.ThresholdReportingCategories.ToList().Select(x => new ThresholdReportingCategorySimple(x)).OrderBy(p => p.DisplayName).ToList();
            var viewData = new EditViewData(indicator, allThresholdReportingCategories, IndicatorRelationshipType.All.Select(x => new IndicatorRelationshipTypeSimple(x)).ToList());
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewEditIndicatorRelationships(ThresholdReportingCategory thresholdReportingCategory, EditViewModel viewModel)
        {
            var allIndicators = HttpRequestStorage.DatabaseEntities.Indicators.ToList().Where(x => x.ReportedInEIP).Select(x => new IndicatorSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var viewData = new EditViewData(thresholdReportingCategory, allIndicators, IndicatorRelationshipType.All.Select(x => new IndicatorRelationshipTypeSimple(x)).ToList());
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}