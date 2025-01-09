/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectOrganizationController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditOrganizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditOrganizationsViewModel(project, project.ProjectOrganizations.OrderBy(x => x.Organization.OrganizationName).ToList(), CurrentFirmaSession);
            return ViewEditOrganizations(viewModel, project);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditOrganizations(ProjectPrimaryKey projectPrimaryKey, EditOrganizationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditOrganizations(viewModel, project);
            }

            HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Load();
            var projectOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.Local;

            viewModel.UpdateModel(project, projectOrganizations);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditOrganizations(EditOrganizationsViewModel viewModel, Project project)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.GetFullNameFirstLastAndOrg()).ToList();
            if (CurrentPerson != null && !allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var allOrganizationRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.ToList();
            var userHasEditProjectStewardingOrganizationAsAdminPermission = new ProjectStewardingOrganizationEditAsAdminFeature().HasPermission(CurrentFirmaSession);
            var viewData = new EditOrganizationsViewData(project, CurrentFirmaSession, allOrganizations, allPeople, allOrganizationRelationshipTypes, userHasEditProjectStewardingOrganizationAsAdminPermission);
            return RazorPartialView<EditOrganizations, EditOrganizationsViewData, EditOrganizationsViewModel>(viewData, viewModel);
        }
    }
}
