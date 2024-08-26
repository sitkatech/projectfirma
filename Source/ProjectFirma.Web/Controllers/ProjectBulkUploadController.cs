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
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectBulkUpload;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectBulkUploadController : FirmaBaseController
    {
        [HttpGet]
        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var viewModel = new ProjectBulkUploadViewModel();
            return ViewManageBulkActivitiesUpload(viewModel);
        }

        private ViewResult ViewManageBulkActivitiesUpload(ProjectBulkUploadViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.BulkUploadProjects.GetFirmaPage();
            var downloadUploadTemplateNewActivitiesUrl = SitkaRoute<ProjectBulkUploadController>.BuildUrlFromExpression(x => x.DownloadUploadTemplateSpreadsheet());

            var viewData = new ProjectBulkUploadViewData(CurrentFirmaSession, firmaPage,  downloadUploadTemplateNewActivitiesUrl);
            return RazorView<ProjectBulkUpload, ProjectBulkUploadViewData, ProjectBulkUploadViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Manage(ProjectBulkUploadViewModel viewModel)
        {
          
            if (!ModelState.IsValid)
            { 
                return ViewManageBulkActivitiesUpload(viewModel);
            }
            
            var httpPostedFileBase = viewModel.FileResourceDatum;
            List<PendingProjectBasicsStageImport> pendingProjectBasicsStageImports;
            
            try
            {
                pendingProjectBasicsStageImports =
                    PendingProjectBasicsStageImportModelExtensions.LoadFromXlsFileStream(httpPostedFileBase.InputStream);
            }
            catch (Exception ex)
            {
                // If this is something really weird...
                if (!(ex is SitkaDisplayErrorException))
                {
                    // We want to capture the Excel file for future reference, since this blew up. But we really should be logging it into the logging folder and not a temp folder.
                    var tempFilename = Path.GetTempFileName() + ".xlsx";
                    httpPostedFileBase.SaveAs(tempFilename);
                    var errorLogMessage = string.Format("Unexpected exception while uploading Excel file by PersonID {0} ({1}). File saved at \"{2}\".\r\nException Details:\r\n{3}",
                        CurrentPerson.PersonID,
                        CurrentPerson.GetFullNameFirstLast(),
                        tempFilename,
                        ex);
                    SitkaLogger.Instance.LogDetailedErrorMessage(errorLogMessage);
                }
                var errorMessage = string.Format("There was a problem uploading your spreadsheet \"{0}\": <br/><div style=\"\">{1}</div><br/><div>No Pending {3} were saved to the database</div><br/>For assistance, please <a href=\"mailto:{2}\">contact Support</a>.", 
                    httpPostedFileBase.FileName, ex.Message, FirmaWebConfiguration.SitkaSupportEmail, FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized());
                SetErrorForDisplay(errorMessage);

                return ViewManageBulkActivitiesUpload(viewModel);
            }

            // run validation on staged data
            var errors = new Dictionary<string, IEnumerable<ValidationResult>>
            {
                { PendingProjectStageImportsHelper.BasicsSheetName, pendingProjectBasicsStageImports.ValidatePendingProjectBasicsStageImports() }
            };
            if (errors.Any(x => x.Value.Any()))
            {
                var errorMessages = PendingProjectStageImportsHelper.BuildErrorMessageDisplay(errors);
                SetErrorForDisplay(errorMessages);
                return ViewManageBulkActivitiesUpload(viewModel);
            }

            //convert staged data into Projects
            pendingProjectBasicsStageImports.CreatePendingProjectBasicsFromStagedData(CurrentFirmaSession);

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay($"{pendingProjectBasicsStageImports.Count} projects were successfully processed and saved to database.");
            return Redirect(SitkaRoute<ProjectBulkUploadController>.BuildUrlFromExpression(x => x.Manage()));
            
        }

        [FirmaAdminFeature]
        public FileContentResult DownloadUploadTemplateSpreadsheet()
        {
            var content = PendingProjectUploadTemplateSpreadsheetHelper.GetPrepopulatedTemplateSpreadsheet();
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PendingProjectUploadTemplate.xlsx");
        }
    }
}