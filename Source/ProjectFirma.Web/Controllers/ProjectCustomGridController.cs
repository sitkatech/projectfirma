/*-----------------------------------------------------------------------
<copyright file="ProjectCustomGridController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirmaModels.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomGridController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult ManageProjectCustomGrids()
        {
            var viewData = new ManageProjectCustomGridsViewData(CurrentPerson);
            return RazorView<ManageProjectCustomGrids, ManageProjectCustomGridsViewData>(viewData);
        }

        [ProjectsViewFullListFeature]
        public GridJsonNetJObjectResult<Project> ProjectCustomGridFullJsonData()
        {
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Full.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentPerson, projectCustomGridConfigurations);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.Include(x => x.PerformanceMeasureActuals).Include(x => x.ProjectFundingSourceBudgets).Include(x => x.ProjectFundingSourceExpenditures).Include(x => x.ProjectImages).Include(x => x.ProjectGeospatialAreas).Include(x => x.ProjectOrganizations).Include(x => x.ProjectCustomAttributes.Select(y => y.ProjectCustomAttributeValues)).Include(x => x.SecondaryProjectTaxonomyLeafs).Include(x => x.ProjectTags.Select(y => y.Tag)).Include(x => x.PrimaryContactPerson).ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ProjectsViewFullListFeature]  //TODO: Is this right?
        public GridJsonNetJObjectResult<Project> ProjectCustomGridDefaultJsonData()
        {
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Full.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentPerson, projectCustomGridConfigurations);
            var projects = HttpRequestStorage.DatabaseEntities.Projects.Include(x => x.PerformanceMeasureActuals).Include(x => x.ProjectFundingSourceBudgets).Include(x => x.ProjectFundingSourceExpenditures).Include(x => x.ProjectImages).Include(x => x.ProjectGeospatialAreas).Include(x => x.ProjectOrganizations).Include(x => x.ProjectCustomAttributes.Select(y => y.ProjectCustomAttributeValues)).Include(x => x.SecondaryProjectTaxonomyLeafs).Include(x => x.ProjectTags.Select(y => y.Tag)).Include(x => x.PrimaryContactPerson).ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult EditProjectCustomGrid(ProjectCustomGridTypePrimaryKey projectCustomGridTypePrimaryKey)
        {
            var projectCustomGridTypeID = projectCustomGridTypePrimaryKey.EntityObject.ProjectCustomGridTypeID;
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.ProjectCustomGridTypeID == projectCustomGridTypeID).ToList();
            var geospatialAreaTypes = HttpRequestStorage.DatabaseEntities.GeospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName).ToList();
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.OrderBy(x => x.ProjectCustomAttributeTypeName).ToList();
            var viewModel = new EditProjectCustomGridViewModel(projectCustomGridTypeID, projectCustomGridConfigurations, geospatialAreaTypes, projectCustomAttributeTypes);
            return ViewEditProjectCustomGrid(viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectCustomGrid(ProjectCustomGridTypePrimaryKey projectCustomGridTypePrimaryKey, EditProjectCustomGridViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditProjectCustomGrid(viewModel);
            }

            return ViewEditProjectCustomGrid(viewModel);
        }

        private PartialViewResult ViewEditProjectCustomGrid(EditProjectCustomGridViewModel viewModel)
        {
            var viewData = new EditProjectCustomGridViewData();
            return RazorPartialView<EditProjectCustomGrid, EditProjectCustomGridViewData, EditProjectCustomGridViewModel>(viewData, viewModel);
        }
    }
}
