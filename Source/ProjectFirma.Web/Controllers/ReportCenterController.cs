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
using SharpDocx;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ReportCenter;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class ReportCenterController : FirmaBaseController
    {

        [CrossAreaRoute]
        [HttpGet]
        public ViewResult Index()
        {
            // todo: firma page and firma page type
            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(viewModel.FileResourceData, CurrentFirmaSession);
            var reportTemplateModelType = HttpRequestStorage.DatabaseEntities.ReportTemplateModelTypes.FirstOrDefault(x => x.ReportTemplateModelTypeID == viewModel.ReportTemplateModelTypeID);
            var reportTemplateModel = HttpRequestStorage.DatabaseEntities.ReportTemplateModels.FirstOrDefault(x => x.ReportTemplateModelID == viewModel.ReportTemplateModelID);

            var reportTemplate = ReportTemplate.CreateNewBlank(fileResource, reportTemplateModelType, reportTemplateModel);
            viewModel.UpdateModel(reportTemplate, fileResource, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Report Template \"{reportTemplate.DisplayName}\" successfully created.");
            return new ModalDialogFormJsonResult();
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
            var projectsList = HttpRequestStorage.DatabaseEntities.Projects.Where(x => viewModel.ProjectIDList.Contains(x.ProjectID)).ToList();
            var reportTemplateSelectListItems =
                HttpRequestStorage.DatabaseEntities.ReportTemplates.AsEnumerable().ToSelectList(x => x.ReportTemplateID.ToString(),
                    x => x.DisplayName);
            var viewData = new GenerateReportsViewData(CurrentFirmaSession, projectsList, reportTemplateSelectListItems);
            return RazorPartialView<GenerateReports, GenerateReportsViewData, GenerateReportsViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult GenerateReportsFromSelectedProjects()
        {
            return new PartialViewResult();
        }

        [HttpPost]
        [FirmaAdminFeature]
        public PartialViewResult GenerateReportsFromSelectedProjects(GenerateReportsViewModel viewModel)
        {
            return new PartialViewResult();
        }

        [CrossAreaRoute]
        [HttpGet]
        public ContentResult TestDocxTemplate()
        {
            /**
             * In reality we are probably going to store the templates in the FileResource table (or a document template table?). For SharpDocx we would likely retrieve that file, save it to the temp folder with a unique name, and use that path
             * as the template path.
             *
             * We would probably compile the reports to a tmp directory as well, and serve it to the user from there.
             *
             */
            var templatePath =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\model-testing.docx";
            var compilePath = "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\model-testing-compiled.docx";


            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();

            var projectModelList = new List<DocxProjectModel>();

            //projectModelList.Add(new DocxProjectModel(projects.First()));

            for (int i = 0; i < projects.Count(); i++)
            {
                projectModelList.Add(new DocxProjectModel(projects[i]));
            }


            var model = new DocxTemplateModel()
            {
                Title = "Title of report",
                Projects = projectModelList
            };


            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, model);
            document.ImageDirectory =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\images";
            document.Generate(compilePath);


            return Content(String.Empty);
        }

        [CrossAreaRoute]
        [HttpGet]
        public ContentResult MonthlyStatusReport(ProjectPrimaryKey projectPrimaryKey)
        {

            var project = projectPrimaryKey.EntityObject;

            var templatePath =
                "C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\monthly-status-report.docx";
            var compilePath = $"C:\\git\\sitkatech\\projectfirma\\Source\\ProjectFirma.Web\\Content\\document-templates\\monthly-status-report-{project.ProjectID}.docx";

            var projectModel = new DocxProjectModel(project);

            var document = DocumentFactory.Create<ProjectFirmaDocxDocument>(templatePath, projectModel);

            document.Generate(compilePath);

            return Content(String.Empty);
        }

    }
}