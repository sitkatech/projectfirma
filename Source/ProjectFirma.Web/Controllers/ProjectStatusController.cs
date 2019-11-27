using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProjectStatus;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;

using Manage = ProjectFirma.Web.Views.ProjectStatus.Manage;
using ManageViewData = ProjectFirma.Web.Views.ProjectStatus.ManageViewData;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectStatusController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ProjectStatusListEditor.GetFirmaPage();
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectStatus> ProjectStatusGridJsonData()
        {
            var projectStatuses = HttpRequestStorage.DatabaseEntities.ProjectStatuses.ToList().OrderBy(x => x.ProjectStatusSortOrder).ToList();
            var gridSpec = new ProjectStatusGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectStatus>(projectStatuses, gridSpec);
            return gridJsonNetJObjectResult;
        }
        
        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel, null);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, null);
            }
            var projectStatus = ProjectStatus.CreateNewBlank();
            viewModel.UpdateModel(projectStatus, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllProjectStatuses.Add(projectStatus);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.ProjectStatus.ToType().GetFieldDefinitionLabel()} \"{projectStatus.ProjectStatusDisplayName}\" successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(ProjectStatusPrimaryKey projectStatusPrimaryKey)
        {
            
            var projectStatus = projectStatusPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectStatus);
            return ViewEdit(viewModel, projectStatus);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectStatusPrimaryKey projectStatusPrimaryKey, EditViewModel viewModel)
        {
            var projectStatus = projectStatusPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, projectStatus);
            }
            viewModel.UpdateModel(projectStatus, CurrentFirmaSession);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, ProjectStatus projectStatus)
        {
      
            var viewData = new EditViewData(CurrentFirmaSession);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }


        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder()
        {
            var projectStatuses = HttpRequestStorage.DatabaseEntities.ProjectStatuses;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(projectStatuses, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IQueryable<ProjectStatus> projectStatuses, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(projectStatuses), FieldDefinitionEnum.ProjectStatus.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var projectStatuses = HttpRequestStorage.DatabaseEntities.ProjectStatuses;


            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(projectStatuses, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(projectStatuses));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Delete(ProjectStatusPrimaryKey projectStatusPrimaryKey)
        {
            var projectStatus = projectStatusPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectStatus.ProjectStatusID);
            return ViewDelete(projectStatus, viewModel);
        }

        private PartialViewResult ViewDelete(ProjectStatus projectStatus, ConfirmDialogFormViewModel viewModel)
        {
            var numberOfConnectedProjectProjectStatuses = projectStatus.ProjectProjectStatuses.Count;
            var confirmMessage = numberOfConnectedProjectProjectStatuses > 0 
                ? $"Are you sure you want to delete {FieldDefinitionEnum.ProjectStatus.ToType().GetFieldDefinitionLabel()} \"{projectStatus.ProjectStatusDisplayName}\"? WARNING: This will delete {numberOfConnectedProjectProjectStatuses} project statuses already set." 
                : $"Are you sure you want to delete {FieldDefinitionEnum.ProjectStatus.ToType().GetFieldDefinitionLabel()} \"{projectStatus.ProjectStatusDisplayName}\"?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ProjectStatusPrimaryKey projectStatusPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectstatus = projectStatusPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(projectstatus, viewModel);
            }

            var message = $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} '{projectstatus.ProjectStatusDisplayName}' successfully deleted!";
            projectstatus.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }






    }
}