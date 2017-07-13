/*-----------------------------------------------------------------------
<copyright file="FirmaHomePageImageController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.FirmaHomePageImage;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class FirmaHomePageImageController : FirmaBaseController
    {

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new NewViewModel();
            return ViewNew(viewModel);
        }


        private PartialViewResult ViewNew(NewViewModel viewModel)
        {
            var viewData = new NewViewData();
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }


        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewNew(viewModel);
            }
            var firmaHomePageImage = new FirmaHomePageImage(-1, null, 0);
            viewModel.UpdateModel(firmaHomePageImage, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllFirmaHomePageImages.Add(firmaHomePageImage);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(FirmaHomePageImagePrimaryKey firmaHomePageImagePrimaryKey)
        {
            var firmaHomePageImage = firmaHomePageImagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(firmaHomePageImage);
            return ViewEdit(firmaHomePageImage, viewModel);
        }


        private PartialViewResult ViewEdit(FirmaHomePageImage firmaHomePageImage, EditViewModel viewModel)
        {
            var viewData = new EditViewData(firmaHomePageImage);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }


        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(FirmaHomePageImagePrimaryKey firmaHomePageImagePrimaryKey, EditViewModel viewModel)
        {
            var firmaHomePageImage = firmaHomePageImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(firmaHomePageImage, viewModel);
            }
            viewModel.UpdateModel(firmaHomePageImage, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteFirmaHomePageImage(FirmaHomePageImagePrimaryKey firmaHomePageImagePrimaryKey)
        {
            var firmaHomePageImage = firmaHomePageImagePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(firmaHomePageImage.FirmaHomePageImageID);
            return ViewDeleteFirmaHomePageImage(firmaHomePageImage, viewModel);
        }


        private PartialViewResult ViewDeleteFirmaHomePageImage(FirmaHomePageImage firmaHomePageImage, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage =
                $"Are you sure you want to delete this image? ({firmaHomePageImage.Caption})";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }


        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteFirmaHomePageImage(FirmaHomePageImagePrimaryKey firmaHomePageImagePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var firmaHomePageImage = firmaHomePageImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteFirmaHomePageImage(firmaHomePageImage, viewModel);
            }
            firmaHomePageImage.DeleteFirmaHomePageImage();
            return new ModalDialogFormJsonResult();
        }
      

    }
}
