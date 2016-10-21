using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicator;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using MoreLinq;

namespace ProjectFirma.Web.Areas.Threshold.Controllers
{
    public class ThresholdIndicatorController : LakeTahoeInfoBaseController
    {

        [ThresholdIndicatorViewFeature]
        public ViewResult InfoSheet(string indicatorName)
        {
            var indicator = HttpRequestStorage.DatabaseEntities.Indicators.GetIndicatorByIndicatorName(indicatorName);
            Check.RequireNotNull(indicator.ThresholdIndicator, string.Format("Indicator {0} is not reportable via the Threshold Dashboard!", indicator.IndicatorDisplayName));
            var thresholdEvaluation =
                indicator.ThresholdIndicator.ThresholdEvaluations.SingleOrDefault(
                    x => x.ThresholdEvaluationPeriod.ThresholdEvaluationYear == ThresholdEvaluation.CurrentThresholdEvaluationYear);
            Check.RequireNotNull(thresholdEvaluation,
                string.Format("No Threshold Evaluation found for Indicator {0}, Year {1}!", indicator.IndicatorDisplayName, ThresholdEvaluation.CurrentThresholdEvaluationYear));

            var indicatorRelationshipsViewData = new IndicatorRelationshipsViewData(indicator.GetRelatedIndicatorsByIndicatorType(IndicatorType.Action),
                indicator.GetRelatedIndicatorsByIndicatorType(IndicatorType.IntermediateResult),
                indicator.GetRelatedIndicatorsByIndicatorType(IndicatorType.Outcome));

            var indicatorChartViewData = new IndicatorChartViewData(indicator, false, ChartViewMode.Small, null);

            var imageGalleryViewData = new ImageGalleryViewData(CurrentPerson, "Threshold Indicator Figures", indicator.ThresholdIndicator.ThresholdIndicatorImages, false, null, null, true, x => x.CaptionOnFullView, "Figure");

            var viewData = new InfoSheetViewData(CurrentPerson, thresholdEvaluation, indicatorRelationshipsViewData, indicatorChartViewData, imageGalleryViewData);
            return RazorView<InfoSheet, InfoSheetViewData>(viewData);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditBackground(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            var viewModel = new EditBackgroundViewModel(thresholdIndicator);
            return ViewEditBackground(viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBackground(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey, EditBackgroundViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditBackground(viewModel);
            }
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            viewModel.UpdateModel(thresholdIndicator);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditBackground(EditBackgroundViewModel viewModel)
        {
            var viewData = new EditBackgroundViewData();
            return RazorPartialView<EditBackground, EditBackgroundViewData, EditBackgroundViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditStandardsMetadata(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            var viewModel = new EditStandardsMetadataViewModel(thresholdIndicator);
            return ViewEditStandardsMetadata(viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditStandardsMetadata(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey, EditStandardsMetadataViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditStandardsMetadata(viewModel);
            }
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            viewModel.UpdateModel(thresholdIndicator);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditStandardsMetadata(EditStandardsMetadataViewModel viewModel)
        {
            var thresholdStandardTypes = ThresholdStandardType.All.ToSelectListWithEmptyFirstRow(x => x.ThresholdStandardTypeID.ToString(), x => x.ThresholdStandardTypeDisplayName);
            var viewData = new EditStandardsMetadataViewData(thresholdStandardTypes);
            return RazorPartialView<EditStandardsMetadata, EditStandardsMetadataViewData, EditStandardsMetadataViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public ActionResult EditIndicatorReporteds(string indicatorName)
        {
            var thresholdIndicator = HttpRequestStorage.DatabaseEntities.ThresholdIndicators.GetThresholdIndicatorByName(indicatorName);
            var viewModel = new EditIndicatorReportedsViewModel(thresholdIndicator);
            return ViewEditIndicatorReporteds(thresholdIndicator, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditIndicatorReporteds(string indicatorName, EditIndicatorReportedsViewModel viewModel)
        {
            var thresholdIndicator = HttpRequestStorage.DatabaseEntities.ThresholdIndicators.GetThresholdIndicatorByName(indicatorName);
            if (!ModelState.IsValid)
            {
                return ViewEditIndicatorReporteds(thresholdIndicator, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ThresholdIndicatorReporteds.Load();
            HttpRequestStorage.DatabaseEntities.ThresholdIndicatorReportedSubcategoryOptions.Load();
            HttpRequestStorage.DatabaseEntities.ThresholdIndicatorReportingPeriods.Load();
            viewModel.UpdateModel(thresholdIndicator, HttpRequestStorage.DatabaseEntities.ThresholdIndicatorReporteds.Local,
                HttpRequestStorage.DatabaseEntities.ThresholdIndicatorReportedSubcategoryOptions.Local,
                HttpRequestStorage.DatabaseEntities.ThresholdIndicatorReportingPeriods.Local);
            return new ModalDialogFormJsonResult();
        }

        private ActionResult ViewEditIndicatorReporteds(ThresholdIndicator thresholdIndicator, EditIndicatorReportedsViewModel viewModel)
        {
            var indicatorTargetValueTypes = IndicatorTargetValueType.All.ToList();
            var defaultReportingPeriodYear = thresholdIndicator.ThresholdIndicatorReportingPeriods.Any()
                ? thresholdIndicator.ThresholdIndicatorReportingPeriods.Max(x => x.ThresholdIndicatorReportingPeriodBeginDate.Year) + 1
                : DateTime.Now.Year;
            var indicator = thresholdIndicator.Indicator;
            var viewDataForAngular = new EditIndicatorReportedsViewDataForAngular(indicator,
                defaultReportingPeriodYear,
                indicatorTargetValueTypes.ToDictionary(x => x.IndicatorTargetValueTypeName, x => x.IndicatorTargetValueTypeID));
            var viewData = new EditIndicatorReportedsViewData(indicator, viewDataForAngular, indicatorTargetValueTypes);
            return RazorPartialView<EditIndicatorReporteds, EditIndicatorReportedsViewData, EditIndicatorReportedsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult NewOptionalChartImageFileResource(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            var viewModel = new NewOptionalChartImageFileResourceViewModel();
            var viewData = new NewOptionalChartImageFileResourceViewData();
            return RazorPartialView<NewOptionalChartImageFileResource, NewOptionalChartImageFileResourceViewData, NewOptionalChartImageFileResourceViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]   
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewOptionalChartImageFileResource(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey, NewOptionalChartImageFileResourceViewModel viewModel)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var viewData = new NewOptionalChartImageFileResourceViewData();
                return RazorPartialView<NewOptionalChartImageFileResource, NewOptionalChartImageFileResourceViewData, NewOptionalChartImageFileResourceViewModel>(viewData, viewModel);
            }
            viewModel.UpdateModel(thresholdIndicator, CurrentPerson);

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult DeleteOptionalChartImageFileResource(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;

            var canDelete = thresholdIndicator.OptionalChartImageFileResourceID.HasValue;

            var confirmMessage = canDelete
                ? "Are you sure you want to delete this image?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("chart image");

            var viewModel = new ConfirmDialogFormViewModel(thresholdIndicator.OptionalChartImageFileResourceID.Value);
            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteOptionalChartImageFileResource(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;

            Check.Require(thresholdIndicator.OptionalChartImageFileResourceID.HasValue, "No image to delete.");


            var fileResourceIDList = new List<int>() { thresholdIndicator.OptionalChartImageFileResourceID.Value };
            thresholdIndicator.OptionalChartImageFileResourceID = null;
            HttpRequestStorage.DetectChangesAndSave();
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(fileResourceIDList);

            return new ModalDialogFormJsonResult();
        }

    }
}