using System;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomAttributeType;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomAttributeTypeController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ManageProjectCustomAttributeTypesList);
            var viewData = new ManageViewData(CurrentPerson, firmaPage);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectCustomAttributeType> ProjectCustomAttributeTypeGridJsonData()
        {
            var gridSpec = new ProjectCustomAttributeTypeGridSpec();
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().OrderBy(x => x.ProjectCustomAttributeTypeName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectCustomAttributeType>(projectCustomAttributeTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        //[FirmaAdminFeature]
        //public GridJsonNetJObjectResult<ProjectType> ProjectTypeGridJsonData(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        //{
        //    var gridSpec = new ProjectTypeGridSpec(CurrentPerson);
        //    var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
        //    var projectTypes = projectCustomAttributeType.ProjectTypeProjectCustomAttributeTypes.Select(x => x.ProjectType).OrderBy(x => x.ProjectTypeName).ToList();
        //    var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectType>(projectTypes, gridSpec);
        //    return gridJsonNetJObjectResult;
        //}

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult New()
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

            var projectCustomAttributeTypePurpose = ProjectCustomAttributeTypePurpose.AllLookupDictionary[viewModel.ProjectCustomAttributeTypePurposeID.GetValueOrDefault()];

            var projectCustomAttributeType = new ProjectCustomAttributeType(String.Empty, ProjectCustomAttributeDataType.String, false, projectCustomAttributeTypePurpose);
            viewModel.UpdateModel(projectCustomAttributeType, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeTypes.Add(projectCustomAttributeType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Custom Attribute Type {projectCustomAttributeType.ProjectCustomAttributeTypeName} succesfully created.");

            return RedirectToAction(new SitkaRoute<ProjectCustomAttributeTypeController>(c => c.Detail(projectCustomAttributeType.PrimaryKey)));
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult Edit(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectCustomAttributeType);
            return ViewEdit(viewModel, projectCustomAttributeType);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey, EditViewModel viewModel)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, projectCustomAttributeType);
            }
            viewModel.UpdateModel(projectCustomAttributeType, CurrentPerson);

            return RedirectToAction(new SitkaRoute<ProjectCustomAttributeTypeController>(c => c.Detail(projectCustomAttributeType.PrimaryKey)));
        }

        private ViewResult ViewEdit(EditViewModel viewModel, ProjectCustomAttributeType projectCustomAttributeType)
        {
            var instructionsFirmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ManageProjectCustomAttributeTypeInstructions);
            var projectCustomAttributeInstructionsFirmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ManageProjectCustomAttributeInstructions);

            var submitUrl = ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.ProjectCustomAttributeTypeID) ? SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Edit(viewModel.ProjectCustomAttributeTypeID)) : SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.New());
            var viewData = new EditViewData(CurrentPerson, MeasurementUnitType.All, ProjectCustomAttributeDataType.All, submitUrl, instructionsFirmaPage, projectCustomAttributeInstructionsFirmaPage, projectCustomAttributeType);
            return RazorView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        public ViewResult Detail(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentPerson, projectCustomAttributeType);
            return RazorView<Detail, DetailViewData>(viewData);
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteProjectCustomAttributeType(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectCustomAttributeType.ProjectCustomAttributeTypeID);
            return ViewDeleteProjectCustomAttributeType(projectCustomAttributeType, viewModel);
        }

        private PartialViewResult ViewDeleteProjectCustomAttributeType(ProjectCustomAttributeType projectCustomAttributeType, ConfirmDialogFormViewModel viewModel)
        {
            //var projectTypeLabel = projectCustomAttributeType.ProjectTypeProjectCustomAttributeTypes.Count == 1 ? FieldDefinition.ProjectType.GetFieldDefinitionLabel() : FieldDefinition.ProjectType.GetFieldDefinitionLabelPluralized();
            //var projectLabel = projectCustomAttributeType.ProjectCustomAttributes.Count == 1 ? FieldDefinition.Project.GetFieldDefinitionLabel() : FieldDefinition.Project.GetFieldDefinitionLabelPluralized();
            //string confirmMessage;
            string confirmMessage = "";
            //if (projectCustomAttributeType.ProjectCustomAttributeTypePurpose != ProjectCustomAttributeTypePurpose.Maintenance)
            //{
            //    confirmMessage =
            //        $"Attribute Type '{projectCustomAttributeType.ProjectCustomAttributeTypeName}' is associated with {projectCustomAttributeType.ProjectTypeProjectCustomAttributeTypes.Count} {projectTypeLabel} and {projectCustomAttributeType.ProjectCustomAttributes.Count} {projectLabel}.<br /><br />Are you sure you want to delete this {FieldDefinition.ProjectCustomAttributeType.GetFieldDefinitionLabel()}?";
            //}
            //else
            //{

            //    var maintenanceRecordCount = projectCustomAttributeType.MaintenanceRecordObservations.Select(x => x.MaintenanceRecord).Count();
            //    var maintenanceRecordLabel = maintenanceRecordCount == 1
            //        ? FieldDefinition.MaintenanceRecord.GetFieldDefinitionLabel()
            //        : FieldDefinition.MaintenanceRecord.GetFieldDefinitionLabelPluralized();
            //    confirmMessage =
            //        $"Attribute Type '{projectCustomAttributeType.ProjectCustomAttributeTypeName}' is associated with {projectCustomAttributeType.ProjectTypeProjectCustomAttributeTypes.Count} {projectTypeLabel} and {maintenanceRecordCount} {maintenanceRecordLabel}.<br /><br />Are you sure you want to delete this {FieldDefinition.ProjectCustomAttributeType.GetFieldDefinitionLabel()}?";
            //}
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectCustomAttributeType(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectCustomAttributeType(projectCustomAttributeType, viewModel);
            }

            var message = $"{FieldDefinition.ProjectCustomAttributeType.GetFieldDefinitionLabel()} '{projectCustomAttributeType.ProjectCustomAttributeTypeName}' successfully deleted!";
            projectCustomAttributeType.DeleteFull();
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }
    }
}
