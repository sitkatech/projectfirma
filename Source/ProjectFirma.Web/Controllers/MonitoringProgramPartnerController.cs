/*-----------------------------------------------------------------------
<copyright file="MonitoringProgramPartnerController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.MonitoringProgramPartner;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class MonitoringProgramPartnerController : FirmaBaseController
    {
        [HttpGet]
        [MonitoringProgramManageFeature]
        public PartialViewResult Edit(MonitoringProgramPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectOrganizationSimples = project.MonitoringProgramPartners.Select(x => new MonitoringProgramPartnerSimple(x)).ToList();
            var viewModel = new EditMonitoringProgramPartnersViewModel(projectOrganizationSimples);
            return ViewEdit(project, viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(MonitoringProgramPrimaryKey projectPrimaryKey, EditMonitoringProgramPartnersViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(project, viewModel);
            }
            var currentMonitoringProgramPartners = project.MonitoringProgramPartners.ToList();
            HttpRequestStorage.DatabaseEntities.MonitoringProgramPartners.Load();
            var allMonitoringProgramPartners = HttpRequestStorage.DatabaseEntities.AllMonitoringProgramPartners.Local;
            viewModel.UpdateModel(currentMonitoringProgramPartners, allMonitoringProgramPartners);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(MonitoringProgram project, EditMonitoringProgramPartnersViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Select(x => new OrganizationSimple(x)).OrderBy(p => p.OrganizationName).ToList();
            var viewData = new EditMonitoringProgramPartnersViewData(project, allOrganizations);
            return RazorPartialView<EditMonitoringProgramPartners, EditMonitoringProgramPartnersViewData, EditMonitoringProgramPartnersViewModel>(viewData, viewModel);
        }
    }
}
