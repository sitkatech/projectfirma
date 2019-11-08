/*-----------------------------------------------------------------------
<copyright file="ProjectImageController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.ProjectImage;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectImageController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            return NewGetResult(projectPrimaryKey);
        }

        private PartialViewResult NewGetResult(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new NewViewModel();
            return ViewNew(project, viewModel);
        }

        private PartialViewResult ViewNew(Project project, NewViewModel viewModel)
        {
            var projectImageTimings = ProjectImageTiming.All.ToSelectListWithEmptyFirstRow(x => x.ProjectImageTimingID.ToString(CultureInfo.InvariantCulture), x => x.ProjectImageTimingDisplayName);
            var viewData = new NewViewData(project, projectImageTimings);
            return RazorPartialView<New, NewViewData, NewViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, NewViewModel viewModel)
        {
            return NewPostResult(projectPrimaryKey, viewModel);
        }

        private ActionResult NewPostResult(ProjectPrimaryKey projectPrimaryKey, NewViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewNew(project, viewModel);
            }
            var projectImage = new ProjectImage(project, true);
            viewModel.UpdateModel(projectImage, CurrentFirmaSession);
            project.ProjectImages.Add(projectImage);
            SetMessageForDisplay("Photo successfully created.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectImageEditOrDeleteFeature]
        public PartialViewResult Edit(ProjectImagePrimaryKey projectImagePrimaryKey)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectImage);
            return ViewEdit(projectImage, viewModel);
        }

        private PartialViewResult ViewEdit(ProjectImage projectImage, EditViewModel viewModel)
        {
            var projectImageTimings = ProjectImageTiming.All.ToSelectListWithEmptyFirstRow(x => x.ProjectImageTimingID.ToString(CultureInfo.InvariantCulture), x => x.ProjectImageTimingDisplayName);
            var viewData = new EditViewData(projectImage, projectImageTimings);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectImagePrimaryKey projectImagePrimaryKey, EditViewModel viewModel)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(projectImage, viewModel);
            }
            viewModel.UpdateModel(projectImage, CurrentFirmaSession);
            SetMessageForDisplay("Photo successfully edited.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectImageEditOrDeleteFeature]
        public PartialViewResult DeleteProjectImage(ProjectImagePrimaryKey projectImagePrimaryKey)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectImage.ProjectImageID);
            return ViewDeleteProjectImage(projectImage, viewModel);
        }

        private PartialViewResult ViewDeleteProjectImage(ProjectImage projectImage, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage =
                $"Are you sure you want to delete this image from {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectImage.Project.GetDisplayName()}'? ({projectImage.Caption})";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectImage(ProjectImagePrimaryKey projectImagePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectImage(projectImage, viewModel);
            }
            var project = projectImage.Project;
            projectImage.DeleteFull(HttpRequestStorage.DatabaseEntities);
            // reset key photo if needed
            if (projectImage.IsKeyPhoto)
            {
                var firstNonKeyPhoto =
                    project.ProjectImages.FirstOrDefault(x => !x.IsKeyPhoto && x.ProjectImageID != projectImage.ProjectImageID);
                firstNonKeyPhoto?.SetAsKeyPhoto(project.ProjectImages.Except(new[] {firstNonKeyPhoto, projectImage}).ToList());
            }
            SetMessageForDisplay("Photo successfully deleted.");
            return new ModalDialogFormJsonResult();
        }

        [HttpPost]
        [ProjectImageEditOrDeleteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult SetKeyPhoto(ProjectImagePrimaryKey projectImagePrimaryKey)
        {
            var projectImage = projectImagePrimaryKey.EntityObject;
            projectImage.SetAsKeyPhoto();
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ProjectCreateFeature]
        public PartialViewResult NewFromProposal(ProjectPrimaryKey projectPrimaryKey)
        {
            return NewGetResult(projectPrimaryKey);
        }

        [HttpPost]
        [ProjectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewFromProposal(ProjectPrimaryKey projectPrimaryKey, NewViewModel viewModel)
        {
            return NewPostResult(projectPrimaryKey, viewModel);
        }
    }
}
