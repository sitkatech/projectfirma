using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicatorImage;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Areas.Threshold.Controllers
{
    public class ThresholdIndicatorImageController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult New(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            var viewModel = new NewViewModel();
            return ViewNew(thresholdIndicator, viewModel);
        }

        private PartialViewResult ViewNew(ThresholdIndicator thresholdIndicator, NewViewModel viewModel)
        {
            var viewData = new NewViewData(thresholdIndicator);
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ThresholdIndicatorPrimaryKey thresholdIndicatorPrimaryKey, NewViewModel viewModel)
        {
            var thresholdIndicator = thresholdIndicatorPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNew(thresholdIndicator, viewModel);
            }
            var thresholdIndicatorImage = new ThresholdIndicatorImage(thresholdIndicator, false);
            viewModel.UpdateModel(thresholdIndicatorImage, CurrentPerson);
            thresholdIndicator.ThresholdIndicatorImages.Add(thresholdIndicatorImage);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult Edit(ThresholdIndicatorImagePrimaryKey thresholdIndicatorImagePrimaryKey)
        {
            var thresholdIndicatorImage = thresholdIndicatorImagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(thresholdIndicatorImage);
            return ViewEdit(thresholdIndicatorImage, viewModel);
        }

        private PartialViewResult ViewEdit(ThresholdIndicatorImage thresholdIndicatorImage, EditViewModel viewModel)
        {
            var viewData = new EditViewData(thresholdIndicatorImage);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ThresholdIndicatorImagePrimaryKey thresholdIndicatorImagePrimaryKey, EditViewModel viewModel)
        {
            var thresholdIndicatorImage = thresholdIndicatorImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(thresholdIndicatorImage, viewModel);
            }
            viewModel.UpdateModel(thresholdIndicatorImage, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        public PartialViewResult Delete(ThresholdIndicatorImagePrimaryKey thresholdIndicatorImagePrimaryKey)
        {
            var thresholdIndicatorImage = thresholdIndicatorImagePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(thresholdIndicatorImage.ThresholdIndicatorImageID);
            return ViewDelete(thresholdIndicatorImage, viewModel);
        }

        private PartialViewResult ViewDelete(ThresholdIndicatorImage thresholdIndicatorImage, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !thresholdIndicatorImage.HasDependentObjects();
            var confirmMessage = canDelete
                ? "Are you sure you want to delete this image?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Threshold Indicator Image");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [CrossAreaRoute]
        [ThresholdIndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ThresholdIndicatorImagePrimaryKey thresholdIndicatorImagePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var thresholdIndicatorImage = thresholdIndicatorImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(thresholdIndicatorImage, viewModel);
            }

            DeleteImages(new[] { thresholdIndicatorImage });

            // reset key photo if needed
            var userHasPermissionToSetKeyPhoto = new ThresholdIndicatorManageFeature().HasPermissionByPerson(CurrentPerson);
            if (userHasPermissionToSetKeyPhoto && thresholdIndicatorImage.IsKeyPhoto)
            {
                var thresholdIndicator = thresholdIndicatorImage.ThresholdIndicator;
                var firstNonKeyPhoto = thresholdIndicator.ThresholdIndicatorImages.FirstOrDefault(x => !x.IsKeyPhoto && x.ThresholdIndicatorImageID != thresholdIndicatorImage.ThresholdIndicatorImageID);
                if (firstNonKeyPhoto != null)
                {
                    firstNonKeyPhoto.SetAsKeyPhoto(thresholdIndicator.ThresholdIndicatorImages.Except(new[] {firstNonKeyPhoto, thresholdIndicatorImage}).ToList());
                }
            }

            return new ModalDialogFormJsonResult();
        }

        private static void DeleteImages(ICollection<ThresholdIndicatorImage> thresholdIndicatorImages)
        {
            var thresholdIndicatorImageFileResourceIDsToDelete = thresholdIndicatorImages.Select(x => x.FileResourceID).ToList();
            var thresholdIndicatorImageIDsToDelete = thresholdIndicatorImages.Select(x => x.ThresholdIndicatorImageID).ToList();
            HttpRequestStorage.DatabaseEntities.ThresholdIndicatorImages.DeleteThresholdIndicatorImage(thresholdIndicatorImageIDsToDelete);
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(thresholdIndicatorImageFileResourceIDsToDelete);
        }
    }
}