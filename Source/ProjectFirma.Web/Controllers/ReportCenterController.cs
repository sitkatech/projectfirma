/*-----------------------------------------------------------------------
<copyright file="ReportCenterController.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.ReportTemplates;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ReportCenter;
using ProjectFirma.Web.Views.Shared;
using SharpDocx;

namespace ProjectFirma.Web.Controllers
{
    public class ReportCenterController : FirmaBaseController
    {

        [CrossAreaRoute]
        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult Projects()
        {
            var firmaPage = FirmaPageTypeEnum.ReportCenterProjects.GetFirmaPage();
            var projectCustomReportCenterGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.ReportCenter.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var viewData = new ProjectsViewData(CurrentFirmaSession, firmaPage, projectCustomReportCenterGridConfigurations);
            return RazorView<Projects, ProjectsViewData>(viewData);
        }


        [CrossAreaRoute]
        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult Index()
        {
            // todo: firma page and firma page type
            var firmaPage = FirmaPageTypeEnum.ReportCenter.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel
            {
                ReportTemplateModelTypeID = (int) ReportTemplateModelTypeEnum.MultipleModels
            };
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(viewModel.FileResourceData, CurrentFirmaSession);
            var reportTemplateModelType = ReportTemplateModelType.All.FirstOrDefault(x => x.ReportTemplateModelTypeID == viewModel.ReportTemplateModelTypeID);
            var reportTemplateModel = ReportTemplateModel.All.FirstOrDefault(x => x.ReportTemplateModelID == viewModel.ReportTemplateModelID);
            var reportTemplate = ReportTemplate.CreateNewBlank(fileResource, reportTemplateModelType, reportTemplateModel);

            ValidateReportTemplate(reportTemplate, out var reportIsValid, out var errorMessage, out var sourceCode);

            if (reportIsValid)
            {
                viewModel.UpdateModel(reportTemplate, fileResource, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);
                SitkaDbContext.SaveChanges();
                SetMessageForDisplay($"Report Template \"{reportTemplate.DisplayName}\" successfully created.");
            }
            else
            {
                SetErrorForDisplay($"There was an error with this template: {errorMessage}");
                SetErrorWithScrollablePreForDisplay($"{sourceCode}");
            }


            return new ModalDialogFormJsonResult();
        }

        void ValidateReportTemplate(ReportTemplate reportTemplate, out bool reportIsValid, out string errorMessage, out string sourceCode)
        {
            errorMessage = "";
            sourceCode = "";

            var reportTemplateModel = reportTemplate.ReportTemplateModel.ToEnum;
            List<int> selectedModelIDs;

            switch (reportTemplateModel)
            {
                case ReportTemplateModelEnum.Project:
                    // select 10 random models to test the report with
                    selectedModelIDs = HttpRequestStorage.DatabaseEntities.Projects.OrderBy(x => Guid.NewGuid())
                        .Select(x => x.ProjectID).Take(10).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            try
            {
                var reportTemplateGenerator = new ReportTemplateGenerator(reportTemplate, selectedModelIDs);
                reportTemplateGenerator.Generate();
                reportIsValid = true;
            }
            catch (SharpDocxCompilationException exception)
            {
                errorMessage = exception.Errors;
                sourceCode = exception.SourceCode;
                reportIsValid = false;
            }

        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(ReportTemplatePrimaryKey reportTemplatePrimaryKey)
        {
            var reportTemplate = reportTemplatePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(reportTemplate);
            return ViewEdit(viewModel, reportTemplate);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ReportTemplatePrimaryKey reportTemplatePrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var fileResource = (viewModel.FileResourceData != null) ? FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(viewModel.FileResourceData, CurrentFirmaSession) : HttpRequestStorage.DatabaseEntities.FileResources.First(x => x.FileResourceID == viewModel.FileResourceID);
            var reportTemplate = reportTemplatePrimaryKey.EntityObject;
            viewModel.UpdateModel(reportTemplate, fileResource, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Report Template \"{reportTemplate.DisplayName}\" successfully updated.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var viewData = new EditViewData();
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, ReportTemplate reportTemplate)
        {
            var viewData = new EditViewData(reportTemplate);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Delete(ReportTemplatePrimaryKey reportTemplatePrimaryKey)
        {
            var reportTemplate = reportTemplatePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reportTemplate.ReportTemplateID);
            return ViewDelete(reportTemplate, viewModel);
        }

        private PartialViewResult ViewDelete(ReportTemplate reportTemplate, ConfirmDialogFormViewModel viewModel)
        {

            var canDelete = new ReportTemplateManageFeature().HasPermission(CurrentFirmaSession, reportTemplate).HasPermission;

            var confirmMessage = canDelete
                ? $"Are you sure you want to delete the \"{reportTemplate.DisplayName}\" Report Template?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"Report Template");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ReportTemplatePrimaryKey reportTemplatePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var reportTemplate = reportTemplatePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(reportTemplate, viewModel);
            }
            reportTemplate.DeleteFullWithFileResource(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }


        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ReportTemplate> IndexGridJsonData()
        {
            var hasManagePermissions = new ReportTemplateManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new ReportTemplateGridSpec(hasManagePermissions);
            var reportTemplates = HttpRequestStorage.DatabaseEntities.ReportTemplates.OrderBy(x => x.DisplayName).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ReportTemplate>(reportTemplates, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult SelectReportToGenerateFromSelectedProjects()
        {
            return new PartialViewResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public PartialViewResult SelectReportToGenerateFromSelectedProjects(GenerateReportsViewModel viewModel)
        {
            // Get the list of projects and then order them by the order they were received from the post request
            var projectsList = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
            projectsList = projectsList.OrderBy(p => viewModel.ProjectIDList.IndexOf(p.ProjectID)).ToList();
            var reportTemplateSelectListItems =
                HttpRequestStorage.DatabaseEntities.ReportTemplates.ToList().Where(x => x.ReportTemplateModel.ReportTemplateModelID == ReportTemplateModel.Project.PrimaryKey).ToSelectList(x => x.ReportTemplateID.ToString(),
                    x => x.DisplayName);
            var viewData = new GenerateReportsViewData(CurrentFirmaSession, projectsList, reportTemplateSelectListItems);
            return RazorPartialView<GenerateReports, GenerateReportsViewData, GenerateReportsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public ActionResult GenerateReportsFromSelectedProjects()
        {
            return new PartialViewResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public ActionResult GenerateReportsFromSelectedProjects(GenerateReportsViewModel viewModel)
        {
            var reportTemplatePrimaryKey = (ReportTemplatePrimaryKey) viewModel.ReportTemplateID;
            var reportTemplate = reportTemplatePrimaryKey.EntityObject;
            var selectedModelIDs = viewModel.ProjectIDList;
            var reportTemplateGenerator = new ReportTemplateGenerator(reportTemplate, selectedModelIDs);
            return reportTemplateGenerator.GenerateAndDownload();
        }

    }
}