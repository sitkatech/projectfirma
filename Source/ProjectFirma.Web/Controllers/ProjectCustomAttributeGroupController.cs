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

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomAttributeGroupController : FirmaBaseController
    {

        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ManageProjectCustomAttributeGroupsList.GetFirmaPage();
            var viewData = new ManageViewData(CurrentPerson, firmaPage);
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

            var projectCustomAttributeGroup = ProjectCustomAttributeGroup.CreateNewBlank();
            viewModel.UpdateModel(projectCustomAttributeGroup, CurrentPerson);

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
            viewModel.UpdateModel(projectCustomAttributeGroup, CurrentPerson);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, ProjectCustomAttributeGroup projectCustomAttributeGroup)
        {
            var instructionsFirmaPage = FirmaPageTypeEnum.ManageProjectCustomAttributeGroupInstructions.GetFirmaPage();
            var submitUrl = ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.ProjectCustomAttributeGroupID)
                ? SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.Edit(viewModel.ProjectCustomAttributeGroupID))
                : SitkaRoute<ProjectCustomAttributeGroupController>.BuildUrlFromExpression(x => x.New());
            var viewData = new EditViewData(CurrentPerson, submitUrl, instructionsFirmaPage, projectCustomAttributeGroup);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        //[FirmaAdminFeature]
        //public ViewResult Detail(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey)
        //{
        //    var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
        //    var viewData = new DetailViewData(CurrentPerson, projectCustomAttributeGroup);
        //    return RazorView<Detail, DetailViewData>(viewData);
        //}


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteProjectCustomAttributeGroup(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey)
        {
            var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectCustomAttributeGroup.ProjectCustomAttributeGroupID);
            return ViewDeleteProjectCustomAttributeGroup(projectCustomAttributeGroup, viewModel);
        }

        private PartialViewResult ViewDeleteProjectCustomAttributeGroup(ProjectCustomAttributeGroup projectCustomAttributeGroup, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete {FieldDefinitionEnum.ProjectCustomAttributeGroup.ToType().GetFieldDefinitionLabel()} \"{projectCustomAttributeGroup.ProjectCustomAttributeGroupName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        //[HttpPost]
        //[FirmaAdminFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult DeleteProjectCustomAttributeGroup(ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey, ConfirmDialogFormViewModel viewModel)
        //{
        //    var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewDeleteProjectCustomAttributeGroup(projectCustomAttributeGroup, viewModel);
        //    }

        //    var message = $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} '{projectCustomAttributeGroup.ProjectCustomAttributeGroupName}' successfully deleted!";
        //    projectCustomAttributeGroup.DeleteFull(HttpRequestStorage.DatabaseEntities);
        //    SetMessageForDisplay(message);
        //    return new ModalDialogFormJsonResult();
        //}
    }
}
