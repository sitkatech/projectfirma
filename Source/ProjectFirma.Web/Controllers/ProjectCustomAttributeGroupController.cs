using System;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProjectCustomAttributeGroup;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;
using System.Collections.Generic;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomAttributeGroupController : FirmaBaseController
    {

        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ManageProjectCustomAttributeGroupsList.GetFirmaPage();
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectCustomAttributeGroup> ProjectCustomAttributeGroupGridJsonData()
        {
            var projectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups.ToList().OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomAttributeGroupGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectCustomAttributeGroup>(projectCustomAttributeGroups, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel()
            {
                ProjectTypeEnums = new List<ProjectTypeEnum>() { ProjectTypeEnum.Normal }
            };
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

            var projectCustomAttributeGroup = ProjectCustomAttributeGroup.CreateNewBlank();
            viewModel.UpdateModel(projectCustomAttributeGroup, CurrentFirmaSession);

            HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeGroups.Add(projectCustomAttributeGroup);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabel()} {projectCustomAttributeGroup.ProjectCustomAttributeGroupName} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey)
        {
            var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectCustomAttributeGroup);
            return ViewEdit(viewModel, projectCustomAttributeGroup);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey, EditViewModel viewModel)
        {
            var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, projectCustomAttributeGroup);
            }
            viewModel.UpdateModel(projectCustomAttributeGroup, CurrentFirmaSession);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, ProjectCustomAttributeGroup projectCustomAttributeGroup)
        {
            var instructionsFirmaPage = FirmaPageTypeEnum.ManageProjectCustomAttributeGroupInstructions.GetFirmaPage();
            var submitUrl = ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.ProjectCustomAttributeGroupID)
                ? SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.Edit(viewModel.ProjectCustomAttributeGroupID))
                : SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.New());
            var viewData = new EditViewData(CurrentFirmaSession, submitUrl, instructionsFirmaPage, projectCustomAttributeGroup);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteProjectCustomAttributeGroup(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey)
        {
            var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
            
            var viewModel = new ConfirmDialogFormViewModel(projectCustomAttributeGroup.ProjectCustomAttributeGroupID);
            return ViewDeleteProjectCustomAttributeGroup(projectCustomAttributeGroup, viewModel);
        }

        private PartialViewResult ViewDeleteProjectCustomAttributeGroup(ProjectCustomAttributeGroup projectCustomAttributeGroup, ConfirmDialogFormViewModel viewModel, string message = null)
        {
            bool canDelete = !projectCustomAttributeGroup.ProjectCustomAttributeTypes.Any();
            var deleteMessage = message ?? (canDelete 
                                    ? $"Are you sure you want to delete {FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabel()} \"{projectCustomAttributeGroup.ProjectCustomAttributeGroupName}\"?" 
                                    : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(projectCustomAttributeGroup.ProjectCustomAttributeGroupName, SitkaRoute<ProjectCustomAttributeTypeController>.BuildLinkFromExpression(x => x.Manage(), "here")));

            var viewData = new ConfirmDialogFormViewData(deleteMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectCustomAttributeGroup(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
            bool canDelete = !projectCustomAttributeGroup.ProjectCustomAttributeTypes.Any();

            if (!canDelete)
            {
                return ViewDeleteProjectCustomAttributeGroup(projectCustomAttributeGroup, viewModel, ConfirmDialogFormViewData.GetStandardCannotDeleteMessage(projectCustomAttributeGroup.ProjectCustomAttributeGroupName, SitkaRoute<ProjectCustomAttributeTypeController>.BuildLinkFromExpression(x => x.Manage(), "here")));
            }
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectCustomAttributeGroup(projectCustomAttributeGroup, viewModel);
            }

            var message = $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} '{projectCustomAttributeGroup.ProjectCustomAttributeGroupName}' successfully deleted!";
            projectCustomAttributeGroup.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }


        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder()
        {
            var projectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;
            EditSortOrderViewModel viewModel = new EditSortOrderViewModel();
            return ViewEditSortOrder(projectCustomAttributeGroups, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IQueryable<ProjectCustomAttributeGroup> projectCustomAttributeGroups, EditSortOrderViewModel viewModel)
        {
            EditSortOrderViewData viewData = new EditSortOrderViewData(new List<IHaveASortOrder>(projectCustomAttributeGroups), FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrder, EditSortOrderViewData, EditSortOrderViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderViewModel viewModel)
        {
            var projectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;


            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(projectCustomAttributeGroups, viewModel);
            }

            viewModel.UpdateModel(new List<IHaveASortOrder>(projectCustomAttributeGroups));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }
    }
}
