/*-----------------------------------------------------------------------
<copyright file="TechnicalAssistanceRequestController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.TechnicalAssistanceRequest;
using ProjectFirmaModels.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{
    public class TechnicalAssistanceRequestController : FirmaBaseController
    {
        [HttpGet]
        [TechnicalAssistanceRequestsViewFeature]
        public ViewResult TechnicalAssistanceReport()
        {
            var firmaPage = FirmaPageTypeEnum.TechnicalAssistanceReport.GetFirmaPage();
            var viewData = new TechnicalAssistanceReportViewData(CurrentFirmaSession, firmaPage);
            return RazorView<TechnicalAssistanceReport, TechnicalAssistanceReportViewData>(viewData);
        }

        [TechnicalAssistanceRequestsViewFeature]
        public GridJsonNetJObjectResult<TechnicalAssistanceRequest> TechnicalAssistanceReportGridJsonData()
        {
            var technicalAssistanceParameters = HttpRequestStorage.DatabaseEntities.TechnicalAssistanceParameters.ToList();
            var gridSpec = new TechnicalAssistanceReportGridSpec(CurrentFirmaSession, technicalAssistanceParameters);
            var technicalAssistanceRequests = HttpRequestStorage.DatabaseEntities.TechnicalAssistanceRequests.OrderBy(x => x.Project.ProjectName).ThenByDescending(x => x.FiscalYear).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<TechnicalAssistanceRequest>(technicalAssistanceRequests, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditTechnicalAssistanceRequestsForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditTechnicalAssistanceRequestsViewModel(project);
            return ViewEditTechnicalAssistanceRequests(project, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditTechnicalAssistanceRequestsForProject(ProjectPrimaryKey projectPrimaryKey, EditTechnicalAssistanceRequestsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditTechnicalAssistanceRequests(project, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.TechnicalAssistanceRequests.Load();
            var allTechnicalAssistanceRequests = HttpRequestStorage.DatabaseEntities.AllTechnicalAssistanceRequests.Local;
            var currentTechnicalAssistanceRequests = project.TechnicalAssistanceRequests.ToList();
            viewModel.UpdateModel(CurrentFirmaSession, currentTechnicalAssistanceRequests, allTechnicalAssistanceRequests, project);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditTechnicalAssistanceRequests(Project project, EditTechnicalAssistanceRequestsViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.TechnicalAssistanceInstructions.GetFirmaPage();
            var technicalAssistanceTypes = TechnicalAssistanceType.All;
            var fiscalYearStrings = FirmaDateUtilities.GetRangeOfYears(MultiTenantHelpers.GetMinimumYear(), FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting() + 2).OrderByDescending(x => x).Select(x => new CalendarYearString(x)).ToList();
            var personDictionary = HttpRequestStorage.DatabaseEntities.People.Where(x => x.RoleID == Role.Admin.RoleID || x.RoleID == Role.ProjectSteward.RoleID).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList().Select(x => new PersonSimple(x)).ToList();
            var viewData = new EditTechnicalAssistanceRequestsViewData(CurrentFirmaSession, firmaPage, project, technicalAssistanceTypes, fiscalYearStrings, personDictionary);
            return RazorPartialView<EditTechnicalAssistanceRequests, EditTechnicalAssistanceRequestsViewData, EditTechnicalAssistanceRequestsViewModel>(viewData, viewModel);
        }

    }
}