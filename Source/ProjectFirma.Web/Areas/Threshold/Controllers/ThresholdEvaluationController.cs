using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.Threshold.Controllers
{
    public class ThresholdEvaluationController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditStatus(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new EditStatusViewModel(thresholdEvaluation);
            return ViewEditStatus(thresholdEvaluation, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditStatus(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, EditStatusViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditStatus(thresholdEvaluation, viewModel);
            }
            viewModel.UpdateModel(thresholdEvaluation);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditStatus(ThresholdEvaluation thresholdEvaluation, EditStatusViewModel viewModel)
        {
            var thresholdEvaluationStatusTypes = ThresholdEvaluationStatusType.All.ToSelectListWithEmptyFirstRow(x => x.ThresholdEvaluationStatusTypeID.ToString(), x => x.ThresholdEvaluationStatusTypeDisplayName);
            var thresholdEvaluationTrendTypes = ThresholdEvaluationTrendType.All.ToSelectListWithEmptyFirstRow(x => x.ThresholdEvaluationTrendTypeID.ToString(), x => x.ThresholdEvaluationTrendTypeDisplayName);
            var thresholdEvaluationConfidenceTypes = ThresholdEvaluationConfidenceType.All.ToSelectListWithEmptyFirstRow(x => x.ThresholdEvaluationConfidenceTypeID.ToString(), x => x.ThresholdEvaluationConfidenceTypeDisplayName);
            var viewData = new EditStatusViewData(thresholdEvaluation.ThresholdIndicator, thresholdEvaluationStatusTypes, thresholdEvaluationTrendTypes, thresholdEvaluationConfidenceTypes);
            return RazorPartialView<EditStatus, EditStatusViewData, EditStatusViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditStatusDetails(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new EditStatusDetailsViewModel(thresholdEvaluation);
            return ViewEditStatusDetails(thresholdEvaluation, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditStatusDetails(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, EditStatusDetailsViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditStatusDetails(thresholdEvaluation, viewModel);
            }
            viewModel.UpdateModel(thresholdEvaluation);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditStatusDetails(ThresholdEvaluation thresholdEvaluation, EditStatusDetailsViewModel viewModel)
        {
            var viewData = new EditStatusDetailsViewData(thresholdEvaluation);
            return RazorPartialView<EditStatusDetails, EditStatusDetailsViewData, EditStatusDetailsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditManagementStatus(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new EditManagementStatusViewModel(thresholdEvaluation);
            return ViewEditManagementStatus(viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditManagementStatus(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, EditManagementStatusViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditManagementStatus(viewModel);
            }
            viewModel.UpdateModel(thresholdEvaluation);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditManagementStatus(EditManagementStatusViewModel viewModel)
        {
            var thresholdEvaluationManagementStatusTypes = ThresholdEvaluationManagementStatusType.All.ToSelectListWithEmptyFirstRow(x => x.ThresholdEvaluationManagementStatusTypeID.ToString(),
                x => x.ThresholdEvaluationManagementStatusTypeDisplayName);
            var viewData = new EditManagementStatusViewData(thresholdEvaluationManagementStatusTypes);
            return RazorPartialView<EditManagementStatus, EditManagementStatusViewData, EditManagementStatusViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditImplementationAndEffectiveness(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new EditImplementationAndEffectivenessViewModel(thresholdEvaluation);
            return ViewEditImplementationAndEffectiveness(thresholdEvaluation, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditImplementationAndEffectiveness(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, EditImplementationAndEffectivenessViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditImplementationAndEffectiveness(thresholdEvaluation, viewModel);
            }
            viewModel.UpdateModel(thresholdEvaluation);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditImplementationAndEffectiveness(ThresholdEvaluation thresholdEvaluation, EditImplementationAndEffectivenessViewModel viewModel)
        {
            var isManagementOrPolicyStatement = thresholdEvaluation.ThresholdIndicator.IsManagementOrPolicyStatement;
            var thresholdEvaluationManagementStatusTypes = ThresholdEvaluationManagementStatusType.All.ToSelectListWithEmptyFirstRow(x => x.ThresholdEvaluationManagementStatusTypeID.ToString(),
                x => x.ThresholdEvaluationManagementStatusTypeDisplayName);
            var viewData = new EditImplementationAndEffectivenessViewData(thresholdEvaluationManagementStatusTypes, isManagementOrPolicyStatement);
            return RazorPartialView<EditImplementationAndEffectiveness, EditImplementationAndEffectivenessViewData, EditImplementationAndEffectivenessViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditRecommendations(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new EditRecommendationsViewModel(thresholdEvaluation);
            return ViewEditRecommendations(viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRecommendations(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, EditRecommendationsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditRecommendations(viewModel);
            }
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            viewModel.UpdateModel(thresholdEvaluation);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditRecommendations(EditRecommendationsViewModel viewModel)
        {
            var viewData = new EditRecommendationsViewData();
            return RazorPartialView<EditRecommendations, EditRecommendationsViewData, EditRecommendationsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult ViewThresholdEvaluationLegend()
        {
            return RazorPartialView<ViewThresholdEvaluationLegend, ViewThresholdEvaluationLegendViewData>(new ViewThresholdEvaluationLegendViewData());
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult EditMapAndCaption(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new EditMapAndCaptionViewModel(thresholdEvaluation.MapCaption);
            return ViewEditMapAndCaption(thresholdEvaluation, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditMapAndCaption(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, EditMapAndCaptionViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditMapAndCaption(thresholdEvaluation, viewModel);
            }
            viewModel.UpdateModel(thresholdEvaluation, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditMapAndCaption(ThresholdEvaluation thresholdEvaluation, EditMapAndCaptionViewModel viewModel)
        {
            var viewData = new EditMapAndCaptionViewData(thresholdEvaluation);
            return RazorPartialView<EditMapAndCaption, EditMapAndCaptionViewData, EditMapAndCaptionViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult DeleteMapImage(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            Check.Require(thresholdEvaluation.MapFileResourceID.HasValue, "No map image to delete.");
            var viewModel = new ConfirmDialogFormViewModel(thresholdEvaluation.MapFileResourceID.Value);
            return ViewDeleteMapImage(viewModel);
        }

        private PartialViewResult ViewDeleteMapImage(ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = "Are you sure you want to delete this map image?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteMapImage(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            Check.Require(thresholdEvaluation.MapFileResourceID.HasValue, "No map image to delete.");
            if (!ModelState.IsValid)
            {
                return ViewDeleteMapImage(viewModel);
            }
            var fileResourceIDToDelete = thresholdEvaluation.MapFileResourceID.Value;
            thresholdEvaluation.MapFileResourceID = null;
            HttpRequestStorage.DetectChangesAndSave();
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(new List<int> { fileResourceIDToDelete });
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult NewHistoricEvaluationPdfFileResource(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new NewHistoricEvaluationPdfFileResourceViewModel();
            var viewData = new NewHistoricEvaluationPdfFileResourceViewData(thresholdEvaluation);
            return RazorPartialView<NewHistoricEvaluationPdfFileResource, NewHistoricEvaluationPdfFileResourceViewData, NewHistoricEvaluationPdfFileResourceViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewHistoricEvaluationPdfFileResource(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, NewHistoricEvaluationPdfFileResourceViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var viewData = new NewHistoricEvaluationPdfFileResourceViewData(thresholdEvaluation);
                return RazorPartialView<NewHistoricEvaluationPdfFileResource, NewHistoricEvaluationPdfFileResourceViewData, NewHistoricEvaluationPdfFileResourceViewModel>(viewData, viewModel);
            }            
            viewModel.UpdateModel(thresholdEvaluation, CurrentPerson);
            
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult DeleteHistoricEvaluationPdfFileResource(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(thresholdEvaluation.HistoricEvaluationPdfFileResourceID.Value);
            var canDelete = !thresholdEvaluation.HasDependentObjects();
            var confirmMessage = canDelete
                ? "Are you sure you want to delete this pdf?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Historic Evaluation PDF");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteHistoricEvaluationPdfFileResource(ThresholdEvaluationPrimaryKey thresholdEvaluationPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var thresholdEvaluation = thresholdEvaluationPrimaryKey.EntityObject;

            Check.Require(thresholdEvaluation.HistoricEvaluationPdfFileResourceID.HasValue, "No PDF to delete.");

            
            var fileResourceIDList = new List<int>() {thresholdEvaluation.HistoricEvaluationPdfFileResourceID.Value};
            thresholdEvaluation.HistoricEvaluationPdfFileResourceID = null;
            HttpRequestStorage.DetectChangesAndSave();
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(fileResourceIDList);

            return new ModalDialogFormJsonResult();
        }

    }
}