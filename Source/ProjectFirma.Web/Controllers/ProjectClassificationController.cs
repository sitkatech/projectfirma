/*-----------------------------------------------------------------------
<copyright file="ProjectClassificationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectClassificationController : FirmaBaseController
    {
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectClassificationsForProject(ProjectPrimaryKey projectPrimaryKey, ClassificationSystemPrimaryKey classificationSystemPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            var projectClassificationSimples = GetProjectClassificationSimples(project, classificationSystem);

            var viewModel = new EditProjectClassificationsForProjectViewModel(projectClassificationSimples);
            return ViewEditProjectClassificationsForProject(project,classificationSystem, viewModel);
        }

        public static List<ProjectClassificationSimple> GetProjectClassificationSimples(Project project,
            ClassificationSystem classificationSystem)
        {
            var selectedProjectClassifications = project.ProjectClassifications.Where(x => x.Classification.ClassificationSystem == classificationSystem);

            //JHB 2/28/17: This is really brittle. The ViewModel relies on the ViewData also being ordered by DisplayName. 
            var projectClassificationSimples =
                HttpRequestStorage.DatabaseEntities.Classifications.ToList().Where(x => x.ClassificationSystem == classificationSystem).OrderBy(x => x.GetDisplayName()).Select(x => new ProjectClassificationSimple {ClassificationID = x.ClassificationID}).ToList();

            foreach (var selectedClassification in selectedProjectClassifications)
            {
                var selectedSimple = projectClassificationSimples.Single(x => x.ClassificationID == selectedClassification.ClassificationID);
                selectedSimple.Selected = true;
                selectedSimple.ProjectClassificationNotes = selectedClassification.ProjectClassificationNotes;
            }

            return projectClassificationSimples;
        }


        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectClassificationsForProject(ProjectPrimaryKey projectPrimaryKey, ClassificationSystemPrimaryKey classificationSystemPrimaryKey, EditProjectClassificationsForProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            var classificationSystem = classificationSystemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditProjectClassificationsForProject(project, classificationSystem, viewModel);
            }
            var currentProjectClassifications = viewModel.ProjectClassificationSimples;
            HttpRequestStorage.DatabaseEntities.ProjectClassifications.Load();
            viewModel.UpdateModel(project, currentProjectClassifications);
            return new ModalDialogFormJsonResult();
        }


        private PartialViewResult ViewEditProjectClassificationsForProject(Project project, ClassificationSystem classificationSystem, EditProjectClassificationsForProjectViewModel viewModel)
        {             
            var viewData = new EditProjectClassificationsForProjectViewData(project, classificationSystem);
            return RazorPartialView<EditProjectClassificationsForProject, EditProjectClassificationsForProjectViewData, EditProjectClassificationsForProjectViewModel>(viewData, viewModel);}

    }
}
