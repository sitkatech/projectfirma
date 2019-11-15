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

using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirmaModels.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.TaxonomyLeaf;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomGridController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult ManageProjectCustomGrids()
        {
            var firmaPage = FirmaPageTypeEnum.ManageProjectCustomGrids.GetFirmaPage();
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var projectCustomFullGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Full.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();

            var viewData = new ManageProjectCustomGridsViewData(CurrentFirmaSession, firmaPage, projectCustomDefaultGridConfigurations, projectCustomFullGridConfigurations);
            return RazorView<ManageProjectCustomGrids, ManageProjectCustomGridsViewData>(viewData);
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
            var gridTypeID = viewModel.ProjectCustomGridConfigurationSimples.First().ProjectCustomGridTypeID;
            var existingProjectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.ProjectCustomGridTypeID == gridTypeID).ToList();
            var allProjectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.AllProjectCustomGridConfigurations.Local;
            viewModel.UpdateModel(existingProjectCustomGridConfigurations, allProjectCustomGridConfigurations);
            SetMessageForDisplay("Successfully Updated Custom Grid");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditProjectCustomGrid(EditProjectCustomGridViewModel viewModel)
        {
            var viewData = new EditProjectCustomGridViewData();
            return RazorPartialView<EditProjectCustomGrid, EditProjectCustomGridViewData, EditProjectCustomGridViewModel>(viewData, viewModel);
        }

        //
        // Custom grid data endpoints
        //

        // All active projects for custom Default grid
        [ProjectsViewFullListFeature]
        public GridJsonNetJObjectResult<Project> AllActiveProjectsCustomGridDefaultJsonData()
        {
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomGridConfigurations);
            var projects = GetProjectEnumerableWithIncludesForPerformance().ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        // All active projects for custom Full grid
        [ProjectsViewFullListFeature]
        public GridJsonNetJObjectResult<Project> AllActiveProjectsCustomGridFullJsonData()
        {
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Full.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomGridConfigurations);
            var projects = GetProjectEnumerableWithIncludesForPerformance().ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static IQueryable<Project> GetProjectEnumerableWithIncludesForPerformance()
        {
            var projectEnum = HttpRequestStorage.DatabaseEntities.Projects.Include(x => x.PerformanceMeasureActuals)
                .Include(x => x.ProjectFundingSourceBudgets).Include(x => x.ProjectFundingSourceExpenditures)
                .Include(x => x.ProjectImages).Include(x => x.ProjectGeospatialAreas)
                .Include(x => x.ProjectOrganizations)
                .Include(x => x.ProjectCustomAttributes.Select(y => y.ProjectCustomAttributeValues))
                .Include(x => x.SecondaryProjectTaxonomyLeafs).Include(x => x.ProjectTags.Select(y => y.Tag))
                .Include(x => x.PrimaryContactPerson)
                .Include(x => x.ProjectProjectStatuses);
            return projectEnum;
        }

        // Projects where current user's organization is lead implementer or project steward for custom Default grid
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<Project> MyOrganizationProjectsCustomGridDefaultJsonData()
        {
            var organization = CurrentPerson.Organization;
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomGridConfigurations);
            var projects = HttpRequestStorage.DatabaseEntities.Projects
                .ToList().GetActiveProjects()
                .Where(p => organization.IsLeadImplementingOrganizationForProject(p) || organization.IsProjectStewardOrganizationForProject(p))
                .OrderBy(x => x.GetDisplayName()).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        //  Projects for a taxonomy trunk for custom Default grid
        [TaxonomyTrunkViewFeature]
        public GridJsonNetJObjectResult<Project> TaxonomyTrunkProjectsGridJsonData(TaxonomyTrunkPrimaryKey taxonomyTrunkPrimaryKey)
        {
            var projectCustomGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomGridConfigurations);
            var projectTaxonomyTrunks = taxonomyTrunkPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectTaxonomyTrunks, gridSpec);
            return gridJsonNetJObjectResult;
        }

        // Projects for a taxonomy branch for custom Default grid
        [TaxonomyBranchViewFeature]
        public GridJsonNetJObjectResult<Project> TaxonomyBranchProjectsGridJsonData(TaxonomyBranchPrimaryKey taxonomyBranchPrimaryKey)
        {
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations);
            var taxonomyBranchProjects = taxonomyBranchPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(taxonomyBranchProjects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        // Projects for a taxonomy branch for custom Default grid
        [TaxonomyLeafViewFeature]
        public GridJsonNetJObjectResult<Project> TaxonomyLeafProjectsGridJsonData(TaxonomyLeafPrimaryKey taxonomyLeafPrimaryKey)
        {
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations);
            var taxonomyLeaf = taxonomyLeafPrimaryKey.EntityObject;
            var taxonomyLeafProjects = taxonomyLeaf.GetAssociatedProjects(CurrentFirmaSession);
            return new GridJsonNetJObjectResult<Project>(taxonomyLeafProjects, gridSpec);
        }

        // Projects for a classification for custom Default grid
        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<Project> ClassificationProjectsGridJsonData(ClassificationPrimaryKey classificationPrimaryKey)
        {
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations);
            var projectClassifications = classificationPrimaryKey.EntityObject.GetAssociatedProjects(CurrentFirmaSession);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectClassifications, gridSpec);
            return gridJsonNetJObjectResult;
        }

        // Projects for a geospatial area for custom Default grid
        [GeospatialAreaViewFeature]
        public GridJsonNetJObjectResult<Project> GeospatialAreaProjectsGridJsonData(GeospatialAreaPrimaryKey geospatialAreaPrimaryKey)
        {
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations);
            var projectGeospatialAreas = geospatialAreaPrimaryKey.EntityObject.GetAssociatedProjects(CurrentFirmaSession);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectGeospatialAreas, gridSpec);
            return gridJsonNetJObjectResult;
        }

        // Featured projects for custom Default grid
        [ProjectManageFeaturedFeature]
        public GridJsonNetJObjectResult<Project> FeaturedProjectsGridJsonData()
        {
            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations);
            var featuredProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(p => p.IsFeatured).ToList().GetActiveProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(featuredProjects, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}
