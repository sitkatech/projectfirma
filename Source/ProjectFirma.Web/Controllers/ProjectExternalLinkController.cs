/*-----------------------------------------------------------------------
<copyright file="ProjectExternalLinkController.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Views.ProjectExternalLink;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectExternalLinkController : FirmaBaseController
    {
        [HttpGet]
        [ProjectExternalLinkManageFeature]
        public PartialViewResult EditProjectExternalLinks(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectExternalLinkSimples = project.ProjectExternalLinks.Select(x => new ProjectExternalLinkSimple(x)).ToList();
            var viewModel = new EditProjectExternalLinksViewModel(projectExternalLinkSimples);
            return ViewEditProjectExternalLinks(project, viewModel);
        }

        [HttpPost]
        [ProjectExternalLinkManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectExternalLinks(ProjectPrimaryKey projectPrimaryKey, EditProjectExternalLinksViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectExternalLinks(project, viewModel);
            }
            var currentProjectExternalLinks = project.ProjectExternalLinks.ToList();
            HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Load();
            var allProjectExternalLinks = HttpRequestStorage.DatabaseEntities.AllProjectExternalLinks.Local;
            viewModel.UpdateModel(currentProjectExternalLinks, allProjectExternalLinks);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectExternalLinks(Project project, EditProjectExternalLinksViewModel viewModel)
        {
            var viewData = new EditProjectExternalLinksViewData(project);
            return RazorPartialView<EditProjectExternalLinks, EditProjectExternalLinksViewData, EditProjectExternalLinksViewModel>(viewData, viewModel);
        }
    }
}
