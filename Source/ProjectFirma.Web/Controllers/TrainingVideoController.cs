/*-----------------------------------------------------------------------
<copyright file="HomeController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Home;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirma.Web.Views.TrainingVideo;
using ProjectFirmaModels.Models;
using TrainingVideo = ProjectFirmaModels.Models.TrainingVideo;

namespace ProjectFirma.Web.Controllers
{
    public class TrainingVideoController : FirmaBaseController
    {


        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult ManageTrainingVideos()
        {
            var viewData = new ManageTrainingVideosViewData(CurrentFirmaSession);
            return RazorView<ManageTrainingVideos, ManageTrainingVideosViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<TrainingVideo> ManageTrainingVideosGridJsonData()
        {
            var gridSpec = new ManageTrainingVideosGridSpec();
            var trainingVideos = HttpRequestStorage.DatabaseEntities.TrainingVideos.ToList().SortByOrderThenName().ToList();
            return new GridJsonNetJObjectResult<TrainingVideo>(trainingVideos, gridSpec);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var trainingVideo = new TrainingVideo(string.Empty, default(DateTime), string.Empty);
            var viewModel = new EditViewModel(trainingVideo);
            return ViewEditTrainingVideo(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            var trainingVideo = new TrainingVideo(string.Empty, default(DateTime), string.Empty);
            if (!ModelState.IsValid)
            {
                return ViewEditTrainingVideo(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.TrainingVideoRoles.Load();
            var trainingVideoRoles = HttpRequestStorage.DatabaseEntities.AllTrainingVideoRoles.Local;

            viewModel.UpdateModel(trainingVideo, trainingVideoRoles);
            HttpRequestStorage.DatabaseEntities.AllTrainingVideos.Add(trainingVideo);

            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(TrainingVideoPrimaryKey trainingVideoPrimaryKey)
        {
            var trainingVideo = trainingVideoPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(trainingVideo);
            return ViewEditTrainingVideo(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(TrainingVideoPrimaryKey trainingVideoPrimaryKey, EditViewModel viewModel)
        {
            var trainingVideo = trainingVideoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditTrainingVideo(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.TrainingVideoRoles.Load();
            var trainingVideoRoles = HttpRequestStorage.DatabaseEntities.AllTrainingVideoRoles.Local;

            viewModel.UpdateModel(trainingVideo, trainingVideoRoles);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditTrainingVideo(EditViewModel viewModel)
        {
            var viewData = new EditViewData(CurrentFirmaSession);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteTrainingVideo(TrainingVideoPrimaryKey trainingVideoPrimaryKey)
        {
            var trainingVideo = trainingVideoPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(trainingVideo.TrainingVideoID);
            return ViewDeleteTrainingVideo(trainingVideo, viewModel);
        }

        private PartialViewResult ViewDeleteTrainingVideo(TrainingVideo trainingVideo, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete the Training Video '{trainingVideo.VideoName}'?";

            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTrainingVideo(TrainingVideoPrimaryKey trainingVideoPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var trainingVideo = trainingVideoPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteTrainingVideo(trainingVideo, viewModel);
            }
            SetMessageForDisplay($"Training Video '{trainingVideo.VideoName}' successfully removed.");

            trainingVideo.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }


        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder()
        {
            var trainingVideos = HttpRequestStorage.DatabaseEntities.TrainingVideos;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(trainingVideos, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IQueryable<TrainingVideo> trainingVideos, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(trainingVideos), "Training Videos");
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var trainingVideos = HttpRequestStorage.DatabaseEntities.TrainingVideos;
            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(trainingVideos, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(trainingVideos));
            SetMessageForDisplay("Successfully Updated Classification Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
