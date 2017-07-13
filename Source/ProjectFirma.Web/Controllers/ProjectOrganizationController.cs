/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationController.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectOrganization;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectOrganizationController : FirmaBaseController
    {
        [HttpGet]
        [ProjectOrganizationManageFeature]
        public PartialViewResult EditOrganizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditOrganizationsViewModel(project.GetAllProjectOrganizations(), project);
            return ViewEditOrganizations(viewModel);
        }

        [HttpPost]
        [ProjectOrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditOrganizations(ProjectPrimaryKey projectPrimaryKey, EditOrganizationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditOrganizations(viewModel);
            }

            HttpRequestStorage.DatabaseEntities.ProjectOrganizations.Load();
            var projectOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectOrganizations.Local;

            viewModel.UpdateModel(project, projectOrganizations);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditOrganizations(EditOrganizationsViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.FullNameFirstLastAndOrg).ToList();
            if (!allPeople.Contains(CurrentPerson))
            {
                allPeople.Add(CurrentPerson);
            }
            var viewData = new EditOrganizationsViewData(allOrganizations, allPeople);
            return RazorPartialView<EditOrganizations, EditOrganizationsViewData, EditOrganizationsViewModel>(viewData, viewModel);
        }
    }
}
