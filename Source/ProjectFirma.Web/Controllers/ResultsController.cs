﻿/*-----------------------------------------------------------------------
<copyright file="ResultsController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class ResultsController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult AccomplishmentsDashboard()
        {
            if (MultiTenantHelpers.DisplaySimpleAccomplishmentDashboard())
            {
                // for NCRP only (aka Tenant that uses Custom Project Dashboard), make this page admin only
                Check.RequireThrowNotAuthorized(!MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession) || new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession), "You are not authorized to view this page.");

                var firmaPage = FirmaPageTypeEnum.ProjectResults.GetFirmaPage();
                var performanceMeasureGroups = HttpRequestStorage.DatabaseEntities.PerformanceMeasureGroups.Where(x => x.PerformanceMeasures.Any())
                    .OrderBy(x => x.PerformanceMeasureGroupName).ToList();
                var viewData =
                    new SimpleAccomplishmentsDashboardViewData(CurrentFirmaSession, firmaPage, performanceMeasureGroups);
                return RazorView<SimpleAccomplishmentsDashboard, SimpleAccomplishmentsDashboardViewData>(viewData);
            }
            else
            {
                var firmaPage = FirmaPageTypeEnum.ProjectResults.GetFirmaPage();
                var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();

                List<Organization> organizations;
                // default to Funding Organizations if no relationship type is selected to report in the dashboard.
                var relationshipTypeToReportInAccomplishmentsDashboard = MultiTenantHelpers.GetOrganizationRelationshipTypeToReportInAccomplishmentsDashboard();
                if (relationshipTypeToReportInAccomplishmentsDashboard == null)
                {
                    var expectedFundingOrganizations = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceBudgets
                        .Select(x => x.FundingSource.Organization).ToList();
                    var reportedFundingOrganization = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures
                        .Select(x => x.FundingSource.Organization).ToList();

                    expectedFundingOrganizations.AddRange(reportedFundingOrganization);
                    organizations = expectedFundingOrganizations.Distinct(new HavePrimaryKeyComparer<Organization>()).OrderBy(x => x.OrganizationName).ToList();
                }
                else
                {
                    organizations = HttpRequestStorage.DatabaseEntities.Projects.ToList().SelectMany(x =>
                        x.ProjectOrganizations.Where(y =>
                            y.OrganizationRelationshipType == relationshipTypeToReportInAccomplishmentsDashboard).Select(z => z.Organization)).ToList().Distinct(new HavePrimaryKeyComparer<Organization>()).OrderBy(x => x.OrganizationName).ToList();
                }

                var defaultEndYear = FirmaDateUtilities.CalculateCurrentYearToUseForRequiredReporting();
                var defaultBeginYear = defaultEndYear - (defaultEndYear - MultiTenantHelpers.GetMinimumYear());
                var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
                var taxonomyTiers = associatePerformanceMeasureTaxonomyLevel.GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder).ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase).ToList();
                var viewData = new AccomplishmentsDashboardViewData(CurrentFirmaSession, firmaPage, tenantAttribute,
                    organizations, FirmaDateUtilities.GetRangeOfYearsForReporting(), defaultBeginYear,
                    defaultEndYear, taxonomyTiers, associatePerformanceMeasureTaxonomyLevel);
                return RazorView<AccomplishmentsDashboard, AccomplishmentsDashboardViewData>(viewData);
            }
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult SpendingByOrganizationTypeByOrganization(int organizationID, int beginYear, int endYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(organizationID, beginYear, endYear);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.Where(x => x.IsFundingType).OrderBy(x => x.OrganizationTypeName == "Other").ThenBy(x => x.OrganizationTypeName).ToList();

            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var taxonomyTiers = tenantAttribute.TaxonomyLevel.GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder).ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase).ToList();

            var viewData = new SpendingByOrganizationTypeByOrganizationViewData(tenantAttribute, organizationTypes, projectFundingSourceExpenditures, taxonomyTiers);
            return RazorPartialView<SpendingByOrganizationTypeByOrganization,
                SpendingByOrganizationTypeByOrganizationViewData>(viewData);
        }

        private static List<ProjectFundingSourceExpenditure> GetProjectExpendituresByOrganizationType(int organizationID, int beginYear, int endYear)
        {
            var projectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.ToList().Where(x => x.CalendarYear >= beginYear && x.CalendarYear <= endYear).Where(x => !x.Project.IsPendingProject()).ToList();
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) && MultiTenantHelpers.DisplayAccomplishmentDashboard())
            {
                var accomplishmentsDashboardIncludeReportingOrganizationType = MultiTenantHelpers.GetAccomplishmentsDashboardFundingDisplayType();

                switch (accomplishmentsDashboardIncludeReportingOrganizationType.ToEnum)
                {
                    case AccomplishmentsDashboardFundingDisplayTypeEnum.AllFundingReceived:
                        return projectFundingSourceExpenditures.Where(x => x.Project.GetOrganizationsToReportInAccomplishments().Any(y => y.OrganizationID == organizationID) && x.FundingSource.OrganizationID != organizationID).OrderBy(x => x.Project.ProjectName).ToList();
                    case AccomplishmentsDashboardFundingDisplayTypeEnum.OnlyFundingProvided:
                        return projectFundingSourceExpenditures.Where(x => x.FundingSource.Organization.OrganizationID == organizationID).OrderBy(x => x.Project.ProjectName).ToList();
                }
               
            }

            return projectFundingSourceExpenditures.OrderBy(x => x.Project.ProjectName).ToList();
        }

        [AnonymousUnclassifiedFeature]
        public JsonNetJObjectResult OrganizationDashboardSummary(int organizationID)
        {
            List<Project> projects;
            Organization organization = null;

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) &&
                MultiTenantHelpers.DisplayAccomplishmentDashboard())
            {
                organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
                projects = organization.GetAllActiveProjectsWhereOrganizationReportsInAccomplishmentsDashboard(CurrentFirmaSession);
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic(), CurrentFirmaSession).ToList();
            }

            var projectCount = projects.Count;
            var partnerCount = GetPartnerOrganizations(organizationID).Count;
            var totalInvestment = MultiTenantHelpers.GetAccomplishmentsDashboardFundingDisplayType()
                .GetInvestmentAmount(organization, projects.SelectMany(x => x.ProjectFundingSourceExpenditures));

            return new JsonNetJObjectResult(new
            {
                ProjectCount = projectCount,
                PartnerCount = partnerCount,
                TotalInvestment = totalInvestment.ToGroupedNumeric()
            });
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult OrganizationAccomplishments(int organizationID, int taxonomyTierID)
        {
            List<Project> projects;
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) &&
                MultiTenantHelpers.DisplayAccomplishmentDashboard())
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
                projects = organization.GetAllActiveProjectsAndProposals(CurrentFirmaSession);
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic(), CurrentFirmaSession).ToList();
            }

            var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            TaxonomyTier taxonomyTier;
            if (associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Trunk)
            {
                taxonomyTier = new TaxonomyTier(HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.GetTaxonomyTrunk(taxonomyTierID));
            }
            else if (associatePerformanceMeasureTaxonomyLevel == TaxonomyLevel.Branch)
            {
                taxonomyTier = new TaxonomyTier(HttpRequestStorage.DatabaseEntities.TaxonomyBranches.GetTaxonomyBranch(taxonomyTierID));
            }
            else
            {
                taxonomyTier = new TaxonomyTier(HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.GetTaxonomyLeaf(taxonomyTierID));
            }

            var projectIDs = projects.Select(x => x.ProjectID).Distinct().ToList();
            var primaryPerformanceMeasuresForTaxonomyTier = taxonomyTier.TaxonomyTierPerformanceMeasures.Select(x => x.Key).ToList();
            var performanceMeasures = primaryPerformanceMeasuresForTaxonomyTier.SelectMany(x => x.PerformanceMeasureActuals.Where(y => projectIDs.Contains(y.ProjectID))).Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>()).OrderBy(x => x.PerformanceMeasureDisplayName).ToList();
            var performanceMeasureChartViewDatas = performanceMeasures.Select(x => new PerformanceMeasureChartViewData(x, CurrentFirmaSession, false, projects, false)).ToList();

            var viewData = new OrganizationAccomplishmentsViewData(performanceMeasureChartViewDatas, taxonomyTier, associatePerformanceMeasureTaxonomyLevel);
            return RazorPartialView<OrganizationAccomplishments, OrganizationAccomplishmentsViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult ParticipatingOrganizations(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var partnerOrganizations = GetPartnerOrganizations(organizationPrimaryKey.PrimaryKeyValue);

            var viewData = new ParticipatingOrganizationsViewData(partnerOrganizations.OrderByDescending(x=> x.Count()).Take(9).ToList());
            return RazorPartialView<ParticipatingOrganizations, ParticipatingOrganizationsViewData>(viewData);
        }

        private List<IGrouping<Organization, ProjectOrganizationRelationship>> GetPartnerOrganizations(int organizationID)
        {
            List<IGrouping<Organization, ProjectOrganizationRelationship>> partnerOrganizations;

            var includeReportingOrganizationType = MultiTenantHelpers.GetAccomplishmentsDashboardIncludeReportingOrganizationType();
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) &&
                MultiTenantHelpers.DisplayAccomplishmentDashboard())
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
                partnerOrganizations = organization
                    .GetAllActiveProjectsWhereOrganizationReportsInAccomplishmentsDashboard(CurrentFirmaSession)
                    .SelectMany(x => x.GetAssociatedOrganizationRelationships().Where(y => y.Organization.OrganizationID != organizationID && 
                                                                               y.Organization.OrganizationType.IsFundingType && //filter by only orgs that can be funders to remove state senate and assembly districts 
                                                                               y.Organization.IsActive))
                    .GroupBy(x => x.Organization, new HavePrimaryKeyComparer<Organization>())
                    .ToList();
            }
            else
            {
                var activeProjectsAndProposals = HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic(), CurrentFirmaSession);
                var projectOrganizationRelationshipsForActiveProjects = activeProjectsAndProposals
                    .SelectMany(x => x.GetAssociatedOrganizationRelationships().Where(y => y.Organization.OrganizationType.IsFundingType && //filter by only orgs that can be funders to remove state senate and assembly districts 
                                                                               y.Organization.IsActive)).ToList();

                var projectOrganizationRelationshipsToReport = projectOrganizationRelationshipsForActiveProjects
                    .Where(x => includeReportingOrganizationType || !x.Organization.CanBeReportedInAccomplishmentsDashboard()).ToList();

                partnerOrganizations = projectOrganizationRelationshipsToReport
                    .GroupBy(x => x.Organization, new HavePrimaryKeyComparer<Organization>())
                    .ToList();
            }

            return partnerOrganizations;
        }

        [ProjectLocationsViewFeature]
        public ViewResult ProjectMap()
        {
            List<int> filterValues;
            ProjectLocationFilterType projectLocationFilterType;
            ProjectColorByType colorByValue;

            var currentPersonCanViewProposals = CurrentFirmaSession.CanViewProposals();
            if (!String.IsNullOrEmpty(Request.QueryString[ProjectMapCustomization.FilterByQueryStringParameter]))
            {
                projectLocationFilterType = ProjectLocationFilterType.ToType(Request
                    .QueryString[ProjectMapCustomization.FilterByQueryStringParameter]
                    .ParseAsEnum<ProjectLocationFilterTypeEnum>());
            }
            else
            {
                projectLocationFilterType = ProjectMapCustomization.DefaultLocationFilterType;
            }

            if (!String.IsNullOrEmpty(Request.QueryString[ProjectMapCustomization.FilterValuesQueryStringParameter]))
            {
                var filterValuesAsString = Request.QueryString[ProjectMapCustomization.FilterValuesQueryStringParameter]
                    .Split(',');
                filterValues = filterValuesAsString.Select(Int32.Parse).ToList();
            }
            else
            {
                filterValues = GetDefaultFilterValuesForFilterType(projectLocationFilterType.ToEnum, currentPersonCanViewProposals);
            }

            if (!String.IsNullOrEmpty(Request.QueryString[ProjectMapCustomization.ColorByQueryStringParameter]))
            {
                colorByValue = ProjectColorByType.ToType(Request
                    .QueryString[ProjectMapCustomization.ColorByQueryStringParameter]
                    .ParseAsEnum<ProjectColorByTypeEnum>());
            }
            else
            {
                colorByValue = ProjectMapCustomization.DefaultColorByType;
            }

            var firmaPage = FirmaPageTypeEnum.ProjectMap.GetFirmaPage();

            var projectsToShow = ProjectMapCustomization.ProjectsForMap(currentPersonCanViewProposals, CurrentFirmaSession);

            var initialCustomization =
                new ProjectMapCustomization(projectLocationFilterType, filterValues, colorByValue);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    projectsToShow.MappedPointsToGeoJsonFeatureCollection(false, true, true), "red", 1,
                    LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                initialCustomization, "ProjectLocationsMap", true);
            // Add Organization Type boundaries according to configuration
            projectLocationsMapInitJson.Layers.AddRange(HttpRequestStorage.DatabaseEntities.Organizations.GetConfiguredBoundaryLayersGeoJson());

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, null, MultiTenantHelpers.GetTopLevelTaxonomyTiers(), currentPersonCanViewProposals, true);

            
            var projectLocationFilterTypesAndValues = CreateProjectLocationFilterTypesAndValuesDictionary(currentPersonCanViewProposals);
            var projectLocationsUrl = SitkaRoute<ResultsController>.BuildAbsoluteUrlHttpsFromExpression(x => x.ProjectMap());

            var filteredProjectsWithLocationAreasUrl =
                SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.FilteredProjectsWithLocationAreas(null));

            var projectColorByTypes = new List<ProjectColorByType> {ProjectColorByType.ProjectStage};
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                projectColorByTypes.Add(ProjectColorByType.TaxonomyTrunk);
            }
            else if (MultiTenantHelpers.IsTaxonomyLevelBranch())
            {
                projectColorByTypes.Add(ProjectColorByType.TaxonomyBranch);
            }
            var viewData = new ProjectMapViewData(CurrentFirmaSession,
                firmaPage,
                projectLocationsMapInitJson,
                projectLocationsMapViewData,
                projectLocationFilterTypesAndValues,
                projectLocationsUrl, filteredProjectsWithLocationAreasUrl, projectColorByTypes, ProjectColorByType.ProjectStage.GetDisplayNameFieldDefinition());
            return RazorView<ProjectMap, ProjectMapViewData>(viewData);
        }

        private static Dictionary<ProjectLocationFilterTypeSimple, IEnumerable<SelectListItem>> CreateProjectLocationFilterTypesAndValuesDictionary(bool showProposals)
        {
            var projectLocationFilterTypesAndValues =
                new Dictionary<ProjectLocationFilterTypeSimple, IEnumerable<SelectListItem>>();

            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                var taxonomyTrunksAsSelectListItems =
                    HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.OrderBy(x => x.TaxonomyTrunkSortOrder).ThenBy(x => x.TaxonomyTrunkName).ToSelectList(
                        x => x.TaxonomyTrunkID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
                projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.TaxonomyTrunk),
                    taxonomyTrunksAsSelectListItems);
            }

            if (!MultiTenantHelpers.IsTaxonomyLevelLeaf())
            {
                var taxonomyBranchesAsSelectListItems =
                    HttpRequestStorage.DatabaseEntities.TaxonomyBranches.OrderBy(x => x.TaxonomyTrunk.TaxonomyTrunkSortOrder).ThenBy(x => x.TaxonomyBranchSortOrder).ThenBy(x => x.TaxonomyBranchName).ToSelectList(
                        x => x.TaxonomyBranchID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
                projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.TaxonomyBranch),
                    taxonomyBranchesAsSelectListItems);
            }


            var taxonomyLeafsAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.OrderBy(x => x.TaxonomyBranch.TaxonomyTrunk.TaxonomyTrunkSortOrder).ThenBy(x => x.TaxonomyBranch.TaxonomyBranchSortOrder).ThenBy(x => x.TaxonomyLeafSortOrder).ThenBy(x => x.TaxonomyLeafName).ToSelectList(
                    x => x.TaxonomyLeafID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
            projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.TaxonomyLeaf),
                taxonomyLeafsAsSelectListItems);

            foreach (var classificationSystem in MultiTenantHelpers.GetClassificationSystems())
            {
                var classificationsAsSelectList = classificationSystem.Classifications.OrderBy(x => x.GetSortOrder()).ThenBy(x => x.GetDisplayName()).ToSelectList(
                    x => x.ClassificationID.ToString(CultureInfo.InvariantCulture),
                    x => x.GetDisplayName());

                projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.Classification, classificationSystem.ClassificationSystemName, $"_{classificationSystem.ClassificationSystemID}"), classificationsAsSelectList);
            }

            var projectStagesAsSelectListItems = ProjectMapCustomization.GetProjectStagesForMap(showProposals).ToSelectList(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), x => x.GetProjectStageDisplayName());
            projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.ProjectStage), projectStagesAsSelectListItems);

            return projectLocationFilterTypesAndValues;
        }

        public static List<int> GetDefaultFilterValuesForFilterType(ProjectLocationFilterTypeEnum projectLocationFilterType, bool currentPersonCanViewProposals)
        {
            switch (projectLocationFilterType)
            {
                case ProjectLocationFilterTypeEnum.TaxonomyTrunk:
                    return HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.Select(x => x.TaxonomyTrunkID).ToList();
                case ProjectLocationFilterTypeEnum.TaxonomyBranch:
                    return HttpRequestStorage.DatabaseEntities.TaxonomyBranches.Select(x => x.TaxonomyBranchID).ToList();
                case ProjectLocationFilterTypeEnum.TaxonomyLeaf:
                    return HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.Select(x => x.TaxonomyLeafID).ToList();
                case ProjectLocationFilterTypeEnum.Classification:
                    return MultiTenantHelpers.GetClassificationSystems().SelectMany(x => x.Classifications)
                        .Select(x => x.ClassificationID).ToList();
                default:
                    // project stage
                    return ProjectMapCustomization.GetDefaultLocationFilterValues(currentPersonCanViewProposals);
            }
        }

        [ProjectLocationsViewFeature]
        [HttpGet]
        public ContentResult FilteredProjectsWithLocationAreas()
        {
            return new ContentResult();
        }

        [ProjectLocationsViewFeature]
        [HttpPost]
        public JsonNetJArrayResult FilteredProjectsWithLocationAreas(ProjectMapCustomization projectMapCustomization)
        {
            if (projectMapCustomization.FilterPropertyValues == null ||
                !projectMapCustomization.FilterPropertyValues.Any())
            {
                return new JsonNetJArrayResult(new List<object>());
            }
            var projectLocationFilterTypeFromFilterPropertyName = projectMapCustomization
                .GetProjectLocationFilterTypeFromFilterPropertyName();
            var filterFunction =
                projectLocationFilterTypeFromFilterPropertyName.GetFilterFunction(projectMapCustomization
                    .FilterPropertyValues);
            var allProjectsForMap = ProjectMapCustomization.ProjectsForMap(CurrentFirmaSession.CanViewProposals(), CurrentFirmaSession);
            var filteredProjects = allProjectsForMap.Where(filterFunction.Compile())
                .ToList();

            var filteredProjectsWithLocationAreas = filteredProjects.Where(x => !x.HasProjectLocationPoint(false)).ToList();
            // Add projects where locations are private
            filteredProjectsWithLocationAreas.AddRange(ProjectMapCustomization.GetProjectsWithPrivateLocations());

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var taxonomyTiersAsFancyTreeNodes = taxonomyLevel
                .GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder)
                .ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase)
                .Select(x => x.ToFancyTreeNode(CurrentFirmaSession))
                .ToList();
            var projectsIDsThatDoNotHaveSimpleLocation = filteredProjectsWithLocationAreas
                .Select(project => project.ProjectID.ToString()).ToList();
            switch (taxonomyLevel.ToEnum)
            {
                case TaxonomyLevelEnum.Leaf:
                    PruneProjectsFromTaxonomyLeaves(taxonomyTiersAsFancyTreeNodes, projectsIDsThatDoNotHaveSimpleLocation);
                    break;
                case TaxonomyLevelEnum.Branch:
                    PruneTaxonomyBranchesWithNoProjects(taxonomyTiersAsFancyTreeNodes, projectsIDsThatDoNotHaveSimpleLocation);
                    break;
                case TaxonomyLevelEnum.Trunk:
                    foreach (var taxonomyTrunkNode in taxonomyTiersAsFancyTreeNodes)
                    {
                        var taxonomyBranchNodes = taxonomyTrunkNode.Children.ToList();
                        PruneTaxonomyBranchesWithNoProjects(taxonomyBranchNodes, projectsIDsThatDoNotHaveSimpleLocation);
                        taxonomyTrunkNode.Children = taxonomyBranchNodes;
                    }
                    taxonomyTiersAsFancyTreeNodes.RemoveAll(x => !x.Children.Any());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new JsonNetJArrayResult(taxonomyTiersAsFancyTreeNodes);
        }

        private static void PruneTaxonomyBranchesWithNoProjects(List<FancyTreeNode> taxonomyBranchNodes,
            List<string> projectsIDsThatDoNotHaveSimpleLocation)
        {
            foreach (var taxonomyBranchNode in taxonomyBranchNodes)
            {
                var taxonomyLeafNodes = taxonomyBranchNode.Children.ToList();
                PruneProjectsFromTaxonomyLeaves(taxonomyLeafNodes, projectsIDsThatDoNotHaveSimpleLocation);
                taxonomyBranchNode.Children = taxonomyLeafNodes;
            }
            taxonomyBranchNodes.RemoveAll(x => !x.Children.Any());

        }

        private static void PruneProjectsFromTaxonomyLeaves(List<FancyTreeNode> taxonomyLeafNodes,
            List<string> projectsIDsThatDoNotHaveSimpleLocation)
        {
            foreach (var taxonomyLeafNode in taxonomyLeafNodes)
            {
                taxonomyLeafNode.Children.RemoveAll(x => !projectsIDsThatDoNotHaveSimpleLocation.Contains(x.Key));
            }

            taxonomyLeafNodes.RemoveAll(x => !x.Children.Any());
        }

        [SpendingByPerformanceMeasureByProjectViewFeature]
        public ViewResult SpendingByPerformanceMeasureByProject(int? performanceMeasureID)
        {
            var firmaPage = FirmaPageTypeEnum.SpendingByPerformanceMeasureByProject.GetFirmaPage();
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var selectedPerformanceMeasure = performanceMeasureID.HasValue
                ? performanceMeasures.Single(x => x.PerformanceMeasureID == performanceMeasureID)
                : performanceMeasures.First();
            var accomplishmentsChartViewData =
                new PerformanceMeasureChartViewData(selectedPerformanceMeasure, CurrentFirmaSession, false, new List<Project>(), true); 

            var viewData = new SpendingByPerformanceMeasureByProjectViewData(CurrentFirmaSession, firmaPage,
                performanceMeasures, selectedPerformanceMeasure, accomplishmentsChartViewData);
            var viewModel = new SpendingByPerformanceMeasureByProjectViewModel();
            return RazorView<SpendingByPerformanceMeasureByProject, SpendingByPerformanceMeasureByProjectViewData,
                SpendingByPerformanceMeasureByProjectViewModel>(viewData, viewModel);
        }

        [SpendingByPerformanceMeasureByProjectViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureSubcategoriesTotalReportedValue>
            SpendingByPerformanceMeasureByProjectGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var performanceMeasureSubcategoriesTotalReportedValues =
                GetSpendingByPerformanceMeasureByProjectAndGridSpec(out var gridSpec, performanceMeasure, CurrentFirmaSession);
            var gridJsonNetJObjectResult =
                new GridJsonNetJObjectResult<PerformanceMeasureSubcategoriesTotalReportedValue>(
                    performanceMeasureSubcategoriesTotalReportedValues, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureSubcategoriesTotalReportedValue> GetSpendingByPerformanceMeasureByProjectAndGridSpec(
                out SpendingByPerformanceMeasureByProjectGridSpec gridSpec,
                PerformanceMeasure performanceMeasure, 
                FirmaSession currentFirmaSession)
        {
            gridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(performanceMeasure);
            return PerformanceMeasureModelExtensions.SubcategoriesTotalReportedValues(currentFirmaSession, performanceMeasure);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult ConfigureAccomplishmentsDashboard()
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new ConfigureAccomplishmentsDashboardViewModel(tenantAttribute);
            return ViewConfigureAccomplishmentsDashboard(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ConfigureAccomplishmentsDashboard(ConfigureAccomplishmentsDashboardViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewConfigureAccomplishmentsDashboard(viewModel);
            }

            var organizationRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes;

            viewModel.UpdateModel(organizationRelationshipTypes);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewConfigureAccomplishmentsDashboard(ConfigureAccomplishmentsDashboardViewModel viewModel)
        {
            IEnumerable<SelectListItem> organizationRelationshipTypes = HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes
                .ToList().ToSelectListWithEmptyFirstRow(
                    x => x.OrganizationRelationshipTypeID.ToString(CultureInfo.InvariantCulture),
                    x => x.OrganizationRelationshipTypeName.ToString(CultureInfo.InvariantCulture), "Funding Organization (Default)");
            var viewData = new ConfigureAccomplishmentsDashboardViewData(organizationRelationshipTypes);
            return RazorPartialView<ConfigureAccomplishmentsDashboard, ConfigureAccomplishmentsDashboardViewData,
                ConfigureAccomplishmentsDashboardViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult FundingStatus()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomFundingStatusPage(CurrentFirmaSession), "This page is not available for this tenant.");
            var firmaPage = FirmaPageTypeEnum.FundingStatusHeader.GetFirmaPage();
            var firmaPageFooter = FirmaPageTypeEnum.FundingStatusFooter.GetFirmaPage();
            
            // set up Funding Summary pie chart
            var summaryChartTitle = "NTA Funding Summary";
            var summaryChartContainerID = summaryChartTitle.Replace(" ", "");
            var googlePieChartSlices = ProjectModelExtensions.GetFundingStatusPieChartSlices();
            var googleChartDataTable = ProjectModelExtensions.GetFundingStatusSummaryGoogleChartDataTable(googlePieChartSlices);
            var summaryConfiguration = new GooglePieChartConfiguration(summaryChartTitle, MeasurementUnitTypeEnum.Dollars, googlePieChartSlices, GoogleChartType.PieChart, googleChartDataTable) { PieSliceText = "value-and-percentage" };
            summaryConfiguration.ChartArea.Top = 60;
            var summaryGoogleChart = new GoogleChartJson(summaryChartTitle, summaryChartContainerID, summaryConfiguration,
                GoogleChartType.PieChart, googleChartDataTable, null);
            summaryGoogleChart.CanConfigureChart = false;

            // set up Funding by Owner Org Type column chart
            var statusByOrgTypeChartTitle = "NTA Funding Status by NTA Owner Organization Type";
            var orgTypeChartContainerID = statusByOrgTypeChartTitle.Replace(" ", "");
            var googleChartAxisHorizontal = new GoogleChartAxis("NTA Organization Type", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
            var googleChartAxis = new GoogleChartAxis("Total Budget", MeasurementUnitTypeEnum.Dollars, GoogleChartAxisLabelFormat.Decimal);
            var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxis };
            var orgTypeToAmounts = ProjectModelExtensions.GetFundingForAllProjectsByOwnerOrgType(CurrentFirmaSession);
            var orgTypeGoogleChartDataTable = ProjectModelExtensions.GetFundingStatusByOwnerOrgTypeGoogleChartDataTable(orgTypeToAmounts);
            var orgTypeChartConfig = new GoogleChartConfiguration(statusByOrgTypeChartTitle, true, GoogleChartType.ColumnChart, orgTypeGoogleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);
            // need to ignore null GoogleChartSeries so the custom colors match up to the column chart correctly
            orgTypeChartConfig.SetSeriesIgnoringNullGoogleChartSeries(orgTypeGoogleChartDataTable);
            orgTypeChartConfig.Tooltip = new GoogleChartTooltip(true);
            orgTypeChartConfig.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            var orgTypeGoogleChart = new GoogleChartJson(statusByOrgTypeChartTitle, orgTypeChartContainerID, orgTypeChartConfig, GoogleChartType.ColumnChart, orgTypeGoogleChartDataTable, orgTypeToAmounts.Keys.Select(x => x.OrganizationTypeName).ToList());
            orgTypeGoogleChart.CanConfigureChart = false;

            var viewData = new FundingStatusViewData(CurrentFirmaSession, firmaPage, firmaPageFooter, summaryGoogleChart, orgTypeGoogleChart);
            return RazorView<FundingStatus, FundingStatusViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult ProgressDashboard()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProgressDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            var firmaPage = FirmaPageTypeEnum.ProgressDashboardIntro.GetFirmaPage();

            var activeProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Where(x => x.ProjectStageID != ProjectStage.Terminated.ProjectStageID && x.ProjectStageID != ProjectStage.Deferred.ProjectStageID).ToList();

            /* Progress Overview section numbers*/
            var projectCount = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjects().Count(x => x.ProjectStageID != ProjectStage.Terminated.ProjectStageID && x.ProjectStageID != ProjectStage.Deferred.ProjectStageID);
            var fundsCommittedToProgramDecimal = HttpRequestStorage.DatabaseEntities.FundingSources.Sum(x => x.FundingSourceAmount);
            var fundsCommittedToProgram = fundsCommittedToProgramDecimal.HasValue ? Math.Round(fundsCommittedToProgramDecimal.Value / 1000000) : 0;
            var partnershipCount = activeProjects.SelectMany(x => x.GetAssociatedOrganizations()).Distinct().Count();

            /* Acres Constructed | By The Numbers section numbers*/
           
            // PerformanceMeasureID = 3731 is the Outcome "Dust Suppression Acres Counted Towards SWRCB WR 2017-0134 Target"
            var dustSuppressionPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3731);

            // PerformanceMeasureID = 3737 "Fish and Wildlife Habitat Acres Counted Towards SWRCB WR 2017-0134 Target"
            var fishAndWildlifeHabitatAcresCountedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3737);
            
            // these 8 performance measures are for the 6 boxes. need the "completed" values only?
            var endangeredSpeciesHabitatPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3750);
            var publicAmenitiesAndRecreationAccessPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3756);
            var grassBalesPlacedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3759);
            var stormwaterSpreadingAreasCreatedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3760);
            var surfaceRougheningConductedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3761);
            var vegetationEnhancementConductedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3736);
            var aquaticHabitatCreatedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3782);
            var wetlandHabitatCreatedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3783);
            
            
            var acresConstructedByTheNumbersFirmaPage = FirmaPageTypeEnum.ProgressDashboardAcresConstructedByTheNumbers.GetFirmaPage();

            /* Acres Constructed pie charts */
            // PerformanceMeasureID = 3781 is the Outcome "Acres Converted"
            var acresConvertedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3781);
            var totalAcresConvertedDustSuppression = acresConvertedPerformanceMeasure.GetTotalActualsForPerformanceMeasureSubcategoryOption(6383);
            var totalAcresConvertedDustSuppressionImplementationOnly = acresConvertedPerformanceMeasure.GetTotalActualsForActiveProjectsForPerformanceMeasureSubcategoryOption(6383);
            var dustSuppressionValues = dustSuppressionPerformanceMeasure.GetProgressDashboardValues(totalAcresConvertedDustSuppression, totalAcresConvertedDustSuppressionImplementationOnly);
            var dustSuppressionPieChart = MakeGoogleChartJsonForProgressDashboardPieChart(dustSuppressionPerformanceMeasure, dustSuppressionValues);

            var totalAcresConvertedFishAndWildlifeHabitat = acresConvertedPerformanceMeasure.GetTotalActualsForPerformanceMeasureSubcategoryOption(6384);
            var totalAcresConvertedFishAndWildlifeHabitatImplementationOnly = acresConvertedPerformanceMeasure.GetTotalActualsForActiveProjectsForPerformanceMeasureSubcategoryOption(6384);
            var fishAndWildlifeHabitatAcresCountedValues = fishAndWildlifeHabitatAcresCountedPerformanceMeasure.GetProgressDashboardValues(totalAcresConvertedFishAndWildlifeHabitat, totalAcresConvertedFishAndWildlifeHabitatImplementationOnly);
            var fishAndWildlifeHabitatAcresCountedPieChart = MakeGoogleChartJsonForProgressDashboardPieChart(fishAndWildlifeHabitatAcresCountedPerformanceMeasure, fishAndWildlifeHabitatAcresCountedValues);


            var endangeredSpeciesHabitatCreatedValues = endangeredSpeciesHabitatPerformanceMeasure.GetProgressDashboardValues();
            var publicAmenitiesAndRecreationValues = publicAmenitiesAndRecreationAccessPerformanceMeasure.GetProgressDashboardValues();
            var grassBalesPlacedValues = grassBalesPlacedPerformanceMeasure.GetProgressDashboardValues();
            var stormwaterSpreadingAreasCreatedValues = stormwaterSpreadingAreasCreatedPerformanceMeasure.GetProgressDashboardValues();
            var surfaceRougheningConductedValues = surfaceRougheningConductedPerformanceMeasure.GetProgressDashboardValues();
            var vegetationEnhancementConductedValues = vegetationEnhancementConductedPerformanceMeasure.GetProgressDashboardValues();
            var aquaticHabitatCreatedValues = aquaticHabitatCreatedPerformanceMeasure.GetProgressDashboardValues();
            var wetlandHabitatCreatedValues = wetlandHabitatCreatedPerformanceMeasure.GetProgressDashboardValues();

            var dustSuppressionFirmaPage = FirmaPageTypeEnum.ProgressDashboardDustSuppression.GetFirmaPage();
            var fishAndWildlifeHabitatFirmaPage = FirmaPageTypeEnum.ProgressDashboardFishAndWildlifeHabitat.GetFirmaPage();

            var dustSuppressionChartJsonsAndProjectColors = MakeGoogleChartJsonsForProgressDashboardBarChart(dustSuppressionPerformanceMeasure, 6383);
            var fishAndWildlifeHabitatAcresCountedChartJsonsAndProjectColors = MakeGoogleChartJsonsForProgressDashboardBarChart(fishAndWildlifeHabitatAcresCountedPerformanceMeasure, 6384);


            var viewData = new ProgressDashboardViewData(CurrentFirmaSession, firmaPage, projectCount, fundsCommittedToProgram, partnershipCount,
                acresConstructedByTheNumbersFirmaPage, dustSuppressionFirmaPage, fishAndWildlifeHabitatFirmaPage,
                dustSuppressionPieChart, fishAndWildlifeHabitatAcresCountedPieChart, 
                dustSuppressionValues, fishAndWildlifeHabitatAcresCountedValues,
                dustSuppressionChartJsonsAndProjectColors.Item1, dustSuppressionChartJsonsAndProjectColors.Item2,
                fishAndWildlifeHabitatAcresCountedChartJsonsAndProjectColors.Item1, fishAndWildlifeHabitatAcresCountedChartJsonsAndProjectColors.Item2,

                dustSuppressionPerformanceMeasure,
                fishAndWildlifeHabitatAcresCountedPerformanceMeasure,
                endangeredSpeciesHabitatPerformanceMeasure,
                publicAmenitiesAndRecreationAccessPerformanceMeasure,
                grassBalesPlacedPerformanceMeasure,
                stormwaterSpreadingAreasCreatedPerformanceMeasure,
                surfaceRougheningConductedPerformanceMeasure,
                vegetationEnhancementConductedPerformanceMeasure,
                aquaticHabitatCreatedPerformanceMeasure,
                wetlandHabitatCreatedPerformanceMeasure,
                endangeredSpeciesHabitatCreatedValues[0],
                publicAmenitiesAndRecreationValues[0], 
                grassBalesPlacedValues[0], 
                stormwaterSpreadingAreasCreatedValues[0], 
                surfaceRougheningConductedValues[0],
                vegetationEnhancementConductedValues[0],
                aquaticHabitatCreatedValues[0],
                wetlandHabitatCreatedValues[0]
            );
            return RazorView<ProgressDashboard, ProgressDashboardViewData>(viewData);
        }

        private GoogleChartJson MakeGoogleChartJsonForProgressDashboardPieChart(PerformanceMeasure performanceMeasure, List<double> values)
        {
            var chartTitle = performanceMeasure.GetDisplayName();
            var pieSliceTextStyle = new GoogleChartTextStyle("ffffff") { IsBold = true, FontSize = 20 };

            // 80% will give space to show google charts legend
            //var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "80%", 10, 10);

            // 90% is enough space for our custom legend
            var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "90%", 10, 10);

            var googleChartContainerID = chartTitle.Replace(" ", "").Replace("&", "").Replace("-", "_");
            var googlePieChartSlices = performanceMeasure.GetProgressDashboardPieChartSlices(values);
            var googleChartDataTable = PerformanceMeasureModelExtensions.GetProgressDashboardPieChartDataTable(googlePieChartSlices);
            var googlePieChartConfiguration = new GooglePieChartConfiguration(
                    chartTitle, MeasurementUnitTypeEnum.Acres, googlePieChartSlices,
                    GoogleChartType.PieChart, googleChartDataTable, pieSliceTextStyle, googleChartConfigurationArea)
                { PieSliceText = "value", PieHole = 0.4 };
            googlePieChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            return new GoogleChartJson(chartTitle, googleChartContainerID, googlePieChartConfiguration, GoogleChartType.PieChart, googleChartDataTable, null);

        }

        private Tuple<List<GoogleChartJson>, Dictionary<Project, Tuple<string, double, bool>>> MakeGoogleChartJsonsForProgressDashboardBarChart(PerformanceMeasure performanceMeasure, int convertedAcresPerformanceMeasureSubcategoryOptionID)
        {
            var googleChartJsons = new List<GoogleChartJson>();
            var projectToColorValueAndHasConverted = new Dictionary<Project, Tuple<string, double, bool>>();
            var performanceMeasureReportingPeriods = performanceMeasure.GetPerformanceMeasureReportingPeriodsFromActuals();

            var groupedByProject = new List<IGrouping<Project, PerformanceMeasureActual>>();
            var chartColumns = new List<string>();
            if (performanceMeasure.PerformanceMeasureActuals.Any())
            {
                groupedByProject = performanceMeasure.PerformanceMeasureActuals.GroupBy(x => x.Project).ToList();
                chartColumns = groupedByProject.Select(x => x.Key.ProjectName).OrderBy(x => x).ToList();

                var chartAndProjectToColorDictionary = performanceMeasure.GetProgressDashboardGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasureReportingPeriods, groupedByProject, chartColumns, false, convertedAcresPerformanceMeasureSubcategoryOptionID);
                var googleChartDataTable = chartAndProjectToColorDictionary.Item1;

                var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}CompletedAcres";

                var googleChartAxisHorizontal = new GoogleChartAxis("Year", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
                var googleChartAxis = new GoogleChartAxis("Acres", MeasurementUnitTypeEnum.Acres, GoogleChartAxisLabelFormat.Short);
                var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxis };

                var chartConfiguration = new GoogleChartConfiguration(chartName, true, GoogleChartType.ColumnChart,
                    googleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);

                chartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
                chartConfiguration.SetSeriesIgnoringNullGoogleChartSeries(googleChartDataTable);

                var googleChartJson = new GoogleChartJson("Acres by Year", chartName, chartConfiguration,
                    GoogleChartType.ColumnChart, googleChartDataTable,
                    chartColumns, null, null, false);
                googleChartJson.CanConfigureChart = false;

                googleChartJsons.Add(googleChartJson);

                chartAndProjectToColorDictionary = performanceMeasure.GetProgressDashboardGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasureReportingPeriods, groupedByProject, chartColumns, true, convertedAcresPerformanceMeasureSubcategoryOptionID);
                var googleChartDataTableCumulative = chartAndProjectToColorDictionary.Item1;

                var chartNameCumulative = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}CompletedAcresCumulative";

                var googleChartAxisHorizontalCumulative = new GoogleChartAxis("Year", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
                var googleChartAxisCumulative = new GoogleChartAxis("Acres", MeasurementUnitTypeEnum.Acres, GoogleChartAxisLabelFormat.Short);
                var googleChartAxisVerticalsCumulative = new List<GoogleChartAxis> { googleChartAxisCumulative };

                var chartConfigurationCumulative = new GoogleChartConfiguration(chartNameCumulative, true, GoogleChartType.ColumnChart,
                    googleChartDataTableCumulative, googleChartAxisHorizontalCumulative, googleChartAxisVerticalsCumulative);

                chartConfigurationCumulative.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
                chartConfigurationCumulative.SetSeriesIgnoringNullGoogleChartSeries(googleChartDataTableCumulative);

                var googleChartJsonCumulative = new GoogleChartJson("Acres", chartNameCumulative, chartConfigurationCumulative,
                    GoogleChartType.ColumnChart, googleChartDataTableCumulative,
                    chartColumns, null, null, true);
                googleChartJsonCumulative.CanConfigureChart = false;

                googleChartJsons.Add(googleChartJsonCumulative);


                groupedByProject.OrderBy(x => x.Key.ProjectName).Select(x =>
                {
                    var calendarYearReportedValue = x.Sum(pmrv => pmrv.ActualValue);
                    return calendarYearReportedValue;
                });

                var projectToColor = chartAndProjectToColorDictionary.Item2;

                projectToColorValueAndHasConverted = groupedByProject.OrderBy(x => x.Key.ProjectName).ToDictionary(x => x.Key,
                    x => new Tuple<string, double, bool>(projectToColor[x.Key.ProjectName], x.Sum(pmrv => pmrv.ActualValue), x.Key.PerformanceMeasureActuals.Any(y =>
                        y.PerformanceMeasureActualSubcategoryOptions.Any(z =>
                            z.PerformanceMeasureSubcategoryOptionID == convertedAcresPerformanceMeasureSubcategoryOptionID))) );
            }

            return new Tuple<List<GoogleChartJson>, Dictionary<Project, Tuple<string, double, bool>>>(googleChartJsons, projectToColorValueAndHasConverted) ;
        }


        private static int ProjectTypeClassificationID = 17;
        private static int CountyGeospatialAreaTypeID = 24;
        private static int TribeGeospatialAreaTypeID = 22;
        private static int DisadvantagedCommunityStatusGeospatialAreaTypeID = 23;
        private static int NotTriballyOwnedGeospatialAreaID = 12143;

        // Allow admin access only for now
        [AnonymousUnclassifiedFeature]
        public ViewResult ProjectDashboard()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            var firmaPage = FirmaPageTypeEnum.NCRPProjectDashboard.GetFirmaPage();

            GetProjectSummaryData(out var projects, out var partners, out var projectsInUnderservedCommunities, out var totalAwarded, out var totalMatched, out var totalInvestment);

            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities
                .ProjectCustomGridConfigurations
                .Where(x => x.IsEnabled &&
                            x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID)
                .OrderBy(x => x.SortOrder).ToList();
            var projectDetails = HttpRequestStorage.DatabaseEntities.vProjectDetails.ToDictionary(x => x.ProjectID);
            var projectGridSpec =
                new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations,
                    ProjectCustomGridType.Default.ToEnum, projectDetails, CurrentFirmaSession.Tenant)
                {
                    ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                    SaveFiltersInCookie = true
                };

            var projectTypes = HttpRequestStorage.DatabaseEntities.Classifications.Where(x => x.ClassificationSystemID == ProjectTypeClassificationID).OrderBy(x => x.DisplayName)
                .ToSelectList(x => x.ClassificationID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);

            var countiesAndTribes = HttpRequestStorage.DatabaseEntities.GeospatialAreas
                .Where(x =>
                    (x.GeospatialAreaTypeID == CountyGeospatialAreaTypeID ||
                     x.GeospatialAreaTypeID == TribeGeospatialAreaTypeID) &&
                    x.GeospatialAreaID != NotTriballyOwnedGeospatialAreaID).OrderBy(x => x.GeospatialAreaShortName)
                .ToSelectList(x => x.GeospatialAreaID.ToString(CultureInfo.InvariantCulture),
                    x => x.GeospatialAreaShortName);

            var underservedCommunitiesGoogleChart =
                GetUnderservedCommunitiesPieChartForProjectDashboard(projects, projectsInUnderservedCommunities);
            var projectsByOwnerOrgTypeGoogleChart = GetProjectsByOwnerOrgTypeChart(projects);
            var projectsByCountyAndTribalLandGoogleChart = GetProjectsByCountyAndTribalLandChart(projects);
            var projectsByProjectTypeGoogleChart = GetProjectsByProjectTypeChart(projects);
            var projectStagesGoogleChart = GetProjectStagesPieChartForProjectDashboard(projects);
            var fundingOrganizationGoogleChart = GetFundingOrganizationChart(projects);
            var projectDashboardChartsViewData =
                new ProjectDashboardChartsViewData(underservedCommunitiesGoogleChart, DisadvantagedCommunityStatusGeospatialAreaTypeID, projectsByOwnerOrgTypeGoogleChart,
                    projectsByCountyAndTribalLandGoogleChart, CountyGeospatialAreaTypeID, TribeGeospatialAreaTypeID,
                    projectsByProjectTypeGoogleChart, ProjectTypeClassificationID, projectStagesGoogleChart,
                    fundingOrganizationGoogleChart);

            var viewData =
                new ProjectDashboardViewData(CurrentFirmaSession, firmaPage, projects.Count, partners.Count, totalAwarded, totalMatched, totalInvestment,
                    projectGridSpec, projectTypes, countiesAndTribes, projectDashboardChartsViewData);
            return RazorView<ProjectDashboard, ProjectDashboardViewData>(viewData);
        }



        // Allow admin access only for now
        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<Project> ProjectDashboardProjectsGridJsonData()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");

            var projectCustomDefaultGridConfigurations = HttpRequestStorage.DatabaseEntities.ProjectCustomGridConfigurations.Where(x => x.IsEnabled && x.ProjectCustomGridTypeID == ProjectCustomGridType.Default.ProjectCustomGridTypeID).OrderBy(x => x.SortOrder).ToList();
            var projectDetails = HttpRequestStorage.DatabaseEntities.vProjectDetails.ToDictionary(x => x.ProjectID);
            var gridSpec = new ProjectCustomGridSpec(CurrentFirmaSession, projectCustomDefaultGridConfigurations, ProjectCustomGridType.Default.ToEnum, projectDetails, CurrentTenant);

            var projects = GetProjectsForProjectDashboard();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projects, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AnonymousUnclassifiedFeature]
        public JsonNetJObjectResult ProjectDashboardProjectSummary()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            GetProjectSummaryData(out var projects, out var partners, out var projectsInUnderservedCommunities, out var totalAwarded, out var totalMatched, out var totalInvestment);
            return new JsonNetJObjectResult(new
            {
                ProjectCount = projects.Count.ToGroupedNumeric(),
                PartnerCount = partners.Count.ToGroupedNumeric(),
                ProjectsInUnderservedCommunitiesCount = projectsInUnderservedCommunities.Count.ToGroupedNumeric(),
                TotalAwarded = totalAwarded.ToGroupedNumeric(),
                TotalMatched = totalMatched.ToGroupedNumeric(),
                TotalInvestment = totalInvestment.ToGroupedNumeric()
            });
        }

        private void GetProjectSummaryData(out List<Project> projects, out List<Organization> projectSponsors, out List<Project> projectsInUnderservedCommunities, out decimal totalAwarded, out decimal totalMatched, out decimal totalInvestment)
        {
            projects = GetProjectsForProjectDashboard();

            projectSponsors = projects
                .SelectMany(x => x.ProjectOrganizations).Where(x => x.OrganizationRelationshipType.IsPrimaryContact).Select(x => x.Organization).Distinct().ToList();
            var geospatialAreaNames = new List<string>()
            {
                "Disadvantaged Community",
                "Severely Disadvantaged Community"
            };
            projectsInUnderservedCommunities = projects.Where(x => x.ProjectGeospatialAreas.Any(y => geospatialAreaNames.Contains(y.GeospatialArea.GeospatialAreaName))).ToList();


            var fundingSourceCustomAttributeDictionary = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributes
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var fundingSourceCustomAttributeValueDictionary = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeValues
                .GroupBy(x => x.FundingSourceCustomAttributeID)
                .ToDictionary(x => x.Key, y => y.ToList());

            // NCRP Award custom attribute
            var fundingSourceCustomAttributeType =
                HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.SingleOrDefault(x =>
                    x.FundingSourceCustomAttributeTypeName.Equals("NCRP Award"));

            totalAwarded = 0;
            totalMatched = 0;
            totalInvestment = 0;
            if (fundingSourceCustomAttributeType != null)
            {
                var fundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList();

                var awardFundingSourceIDs = fundingSources.Where(x =>
                    x.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType,
                        fundingSourceCustomAttributeDictionary, fundingSourceCustomAttributeValueDictionary).Equals("Yes")).Select(x => x.FundingSourceID).ToList();

                var matchedFundingSourceIDs = fundingSources.Where(x =>
                    x.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType,
                        fundingSourceCustomAttributeDictionary, fundingSourceCustomAttributeValueDictionary).Equals("No")).Select(x => x.FundingSourceID).ToList();


                totalAwarded = Math.Round(projects.Sum(x => x.GetSecuredFundingForFundingSources(awardFundingSourceIDs) ?? 0));
                totalMatched = Math.Round(projects.Sum(x => x.GetSecuredFundingForFundingSources(matchedFundingSourceIDs) ?? 0));
                totalInvestment = totalAwarded + totalMatched;
            }
        }

        private GoogleChartJson GetUnderservedCommunitiesPieChartForProjectDashboard(List<Project> projects,  List<Project> projectsInUnderservedCommunities)
        {
            var chartTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by Underserved Community Status";
            var pieChartContainerID = chartTitle.Replace(" ", "");

            var googlePieChartSlices = ProjectModelExtensions.GetUnderservedCommunitiesForProjectDashboardPieChartSlices(projects, projectsInUnderservedCommunities);
            var googleChartDataTable = ProjectModelExtensions.GetUnderservedCommunitiesForProjectDashboardGoogleChartDataTable(googlePieChartSlices);

            var pieSliceTextStyle = new GoogleChartTextStyle("#FFFFFF") { IsBold = true, FontSize = 20 };
            var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "90%", 10, 10);

            var pieChartConfiguration = new GooglePieChartConfiguration(chartTitle, MeasurementUnitTypeEnum.Number,
                googlePieChartSlices, GoogleChartType.PieChart, googleChartDataTable, pieSliceTextStyle,
                googleChartConfigurationArea) {PieSliceText = "value", PieHole = 0.4 };
            pieChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);

            var pieChart = new GoogleChartJson(chartTitle, pieChartContainerID, pieChartConfiguration,
                GoogleChartType.PieChart, googleChartDataTable, null);
            pieChart.CanConfigureChart = false;
            return pieChart;

        }

        private GoogleChartJson GetProjectsByOwnerOrgTypeChart(List<Project> projects)
        {
            // set up Projects by Owner Org Type column chart
            var projectByOrgTypeChartTitle = "Projects by Project Sponsor Type";
            var orgTypeChartContainerID = projectByOrgTypeChartTitle.Replace(" ", "");
            var googleChartAxis = new GoogleChartAxis("Organization Type", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
            var googleChartAxisHorizontal = new GoogleChartAxis("Number of Projects", null, GoogleChartAxisLabelFormat.Decimal);
            var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxis };
            var orgTypeToProjectCounts = ProjectModelExtensions.GetProjectCountByOwnerOrgType(projects);
            var orgTypeGoogleChartDataTable = ProjectModelExtensions.GetProjectsByOwnerOrgTypeGoogleChartDataTable(orgTypeToProjectCounts);

            var orgTypeChartConfig = new GoogleChartConfiguration(projectByOrgTypeChartTitle, true, GoogleChartType.BarChart, orgTypeGoogleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);
            orgTypeChartConfig.SeriesType = "bars";
            orgTypeChartConfig.ChartArea = new GoogleChartConfigurationArea()
            {
                Width = "100%",
                Height = "80%",
                Left = "40%",
                Top = 10
            };
            // need to ignore null GoogleChartSeries so the custom colors match up to the column chart correctly
            orgTypeChartConfig.SetSeriesIgnoringNullGoogleChartSeries(orgTypeGoogleChartDataTable);
            orgTypeChartConfig.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            orgTypeChartConfig.Tooltip = new GoogleChartTooltip { ShowColorCode = false };

            var orgTypeGoogleChart = new GoogleChartJson(projectByOrgTypeChartTitle, orgTypeChartContainerID, orgTypeChartConfig, GoogleChartType.BarChart, orgTypeGoogleChartDataTable, orgTypeToProjectCounts.Keys.Select(x => x.OrganizationTypeName).ToList());
            orgTypeGoogleChart.CanConfigureChart = false;
            return orgTypeGoogleChart;
        }

        private GoogleChartJson GetProjectsByCountyAndTribalLandChart(List<Project> projects)
        {
            // set up Projects by County & Tribal Land column chart
            var projectByCountyChartTitle = "Projects by County and Tribal Land";
            var countyChartContainerID = projectByCountyChartTitle.Replace(" ", "");
            var googleChartAxis = new GoogleChartAxis("County Names and Tribal Land", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
            var googleChartAxisHorizontal = new GoogleChartAxis("Number of Projects", null, GoogleChartAxisLabelFormat.Decimal);
            var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxis };

            var counties = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => x.GeospatialAreaTypeID == CountyGeospatialAreaTypeID).ToList();
            // all tribal land except for "Not Tribally owned land as identified by federal BIA map layer" (ID = 12143)
            var tribes = HttpRequestStorage.DatabaseEntities.GeospatialAreas.Where(x => x.GeospatialAreaTypeID == TribeGeospatialAreaTypeID && x.GeospatialAreaID != NotTriballyOwnedGeospatialAreaID).ToList();

            var projectGeospatialAreas = projects.SelectMany(x => x.ProjectGeospatialAreas).ToList();
            var countyIDs = counties.Select(x => x.GeospatialAreaID).ToList();

            var countyToProjectCounts = projectGeospatialAreas.Where(x => countyIDs.Contains(x.GeospatialAreaID))
                .GroupBy(x => x.GeospatialArea).OrderBy(x => x.Key.GeospatialAreaName).ToDictionary(x => x.Key, x => x.Count());

            var tribalIDs = tribes.Select(x => x.GeospatialAreaID).ToList();
            var tribalLandProjectCount = projects.SelectMany(x => x.ProjectGeospatialAreas).Where(x => tribalIDs.Contains(x.GeospatialAreaID))
                .Select(x => x.Project).Distinct().Count();

            var orgTypeGoogleChartDataTable = ProjectModelExtensions.GetProjectsByCountyAndTribalLandGoogleChartDataTable(countyToProjectCounts, tribalLandProjectCount);

            var chartColumns = countyToProjectCounts.Keys.Select(x => x.GeospatialAreaName).ToList();
            if (tribalLandProjectCount > 0)
            {
                chartColumns.Add("Tribal Land As Identified by Federal BIA Map");
            }

            var countyChartConfig = new GoogleChartConfiguration(projectByCountyChartTitle, true, GoogleChartType.BarChart, orgTypeGoogleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);
            // need to ignore null GoogleChartSeries so the custom colors match up to the column chart correctly
            countyChartConfig.SetSeriesIgnoringNullGoogleChartSeries(orgTypeGoogleChartDataTable);
            countyChartConfig.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            countyChartConfig.Tooltip = new GoogleChartTooltip { ShowColorCode = false };
            countyChartConfig.SeriesType = "bars";
            countyChartConfig.ChartArea = new GoogleChartConfigurationArea()
            {
                Width = "100%",
                Height = "80%",
                Left = "40%",
                Top = 10
            };

            var countyAndTribalLandGoogleChart = new GoogleChartJson(projectByCountyChartTitle, countyChartContainerID, countyChartConfig, GoogleChartType.BarChart, orgTypeGoogleChartDataTable, chartColumns);
            countyAndTribalLandGoogleChart.CanConfigureChart = false;
            return countyAndTribalLandGoogleChart;
        }

        private GoogleChartJson GetProjectsByProjectTypeChart(List<Project> projects)
        {
            // set up Projects by County & Tribal Land column chart
            var projectByProjectTypeChartTitle = "Projects by Project Types";
            var projectTypeChartContainerID = projectByProjectTypeChartTitle.Replace(" ", "");
            var googleChartAxis = new GoogleChartAxis("Project Type", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
            var googleChartAxisHorizontal = new GoogleChartAxis("Number of Projects", null, GoogleChartAxisLabelFormat.Decimal);
            var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxis };

            var projectTypes = HttpRequestStorage.DatabaseEntities.Classifications.Where(x => x.ClassificationSystemID == ProjectTypeClassificationID).ToList();
            var projectClassifications = projects.SelectMany(x => x.ProjectClassifications).ToList();
            var projectTypeIDs = projectTypes.Select(x => x.ClassificationID).ToList();

            var projectTypeToProjectCount = projectClassifications.Where(x => projectTypeIDs.Contains(x.ClassificationID))
                .GroupBy(x => x.Classification).OrderBy(x => x.Key.DisplayName).ToDictionary(x => x.Key, x => x.Count());

            var projectTypeGoogleChartDataTable = ProjectModelExtensions.GetProjectsByProjectTypeGoogleChartDataTable(projectTypeToProjectCount);

            var chartColumns = projectTypeToProjectCount.Keys.Select(x => x.DisplayName).ToList();
           
            var projectTypeChartConfig = new GoogleChartConfiguration(projectByProjectTypeChartTitle, false, GoogleChartType.BarChart, projectTypeGoogleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);
            // need to ignore null GoogleChartSeries so the custom colors match up to the column chart correctly
            projectTypeChartConfig.SetSeriesIgnoringNullGoogleChartSeries(projectTypeGoogleChartDataTable);
            projectTypeChartConfig.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            projectTypeChartConfig.Tooltip = new GoogleChartTooltip { ShowColorCode = false };
            projectTypeChartConfig.SeriesType = "bars";
            projectTypeChartConfig.ChartArea = new GoogleChartConfigurationArea()
            {
                Width = "100%",
                Height = "80%",
                Left = "40%",
                Top = 10
            };

            var countyAndTribalLandGoogleChart = new GoogleChartJson(projectByProjectTypeChartTitle, projectTypeChartContainerID, projectTypeChartConfig, GoogleChartType.BarChart, projectTypeGoogleChartDataTable, chartColumns);
            countyAndTribalLandGoogleChart.CanConfigureChart = false;
            return countyAndTribalLandGoogleChart;
        }

        private GoogleChartJson GetProjectStagesPieChartForProjectDashboard(List<Project> projects)
        {
            var chartTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by {FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel()}";
            var pieChartContainerID = chartTitle.Replace(" ", "");

            var googlePieChartSlices = ProjectModelExtensions.GetProjectStagesForProjectDashboardPieChartSlices(projects);
            var googleChartDataTable = ProjectModelExtensions.GetProjectStagesForProjectDashboardGoogleChartDataTable(googlePieChartSlices);

            var pieSliceTextStyle = new GoogleChartTextStyle("#FFFFFF") { IsBold = true, FontSize = 20 };
            var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "90%", 10, 10);

            var pieChartConfiguration = new GooglePieChartConfiguration(chartTitle, MeasurementUnitTypeEnum.Number,
                    googlePieChartSlices, GoogleChartType.PieChart, googleChartDataTable, pieSliceTextStyle,
                    googleChartConfigurationArea)
                { PieSliceText = "value", PieHole = 0.4 };
            pieChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);

            var pieChart = new GoogleChartJson(chartTitle, pieChartContainerID, pieChartConfiguration,
                GoogleChartType.PieChart, googleChartDataTable, null);
            pieChart.CanConfigureChart = false;
            return pieChart;

        }

        private GoogleChartJson GetFundingOrganizationChart(List<Project> projects)
        {

            // set up Funding by Owner Org Type column chart
            var fundingOrgChartTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by Funding Organization";
            var fundingOrgChartContainerID = fundingOrgChartTitle.Replace(" ", "");
            var googleChartAxisHorizontal = new GoogleChartAxis("Funding Organization", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
            var googleChartAxisVerticalFundingAmount = new GoogleChartAxis("Funding Amount", MeasurementUnitTypeEnum.Dollars, GoogleChartAxisLabelFormat.Decimal);
            var googleChartAxisVerticalProjectCount = new GoogleChartAxis("Number of Projects", null, GoogleChartAxisLabelFormat.Decimal);
            var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxisVerticalFundingAmount , googleChartAxisVerticalProjectCount };

            var orgToProjectCountAndFundingAmount = ProjectModelExtensions.GetProjectCountAndFundingAmountFundingOrganization(projects, new List<int>() { 9312 });
            var fundingOrgGoogleChartDataTable = ProjectModelExtensions.GetProjectCountBudgetByFundingOrganizationGoogleChartDataTable(orgToProjectCountAndFundingAmount);


            var fundingOrgChartConfig = new GoogleChartConfiguration(fundingOrgChartTitle, false, GoogleChartType.ColumnChart, fundingOrgGoogleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);
            // need to ignore null GoogleChartSeries so the custom colors match up to the column chart correctly
            fundingOrgChartConfig.SetSeriesIgnoringNullGoogleChartSeries(fundingOrgGoogleChartDataTable);
            fundingOrgChartConfig.Tooltip = new GoogleChartTooltip(true);
            fundingOrgChartConfig.Legend.SetLegendPosition(GoogleChartLegendPosition.Top);

            var fundingOrgGoogleChart = new GoogleChartJson(fundingOrgChartTitle, fundingOrgChartContainerID, fundingOrgChartConfig, GoogleChartType.ColumnChart, fundingOrgGoogleChartDataTable, orgToProjectCountAndFundingAmount.Keys.Select(x => x.OrganizationName).ToList());
            fundingOrgGoogleChart.CanConfigureChart = true;
            return fundingOrgGoogleChart;
        }


        [AnonymousUnclassifiedFeature]
        public PartialViewResult ProjectDashboardCharts()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            GetProjectSummaryData(out var projects, out var partners, out var projectsInUnderservedCommunities, out var totalAwarded, out var totalMatched, out var totalInvestment);
            var underservedCommunitiesGoogleChart = GetUnderservedCommunitiesPieChartForProjectDashboard(projects, projectsInUnderservedCommunities);
            var projectsByOwnerOrgTypeGoogleChart = GetProjectsByOwnerOrgTypeChart(projects);
            var projectsByCountyAndTribalLandGoogleChart = GetProjectsByCountyAndTribalLandChart(projects);
            var projectsByProjectTypeGoogleChart = GetProjectsByProjectTypeChart(projects);
            var projectStagesGoogleChart = GetProjectStagesPieChartForProjectDashboard(projects);
            var fundingOrganizationGoogleChart = GetFundingOrganizationChart(projects);
            var viewData = new ProjectDashboardChartsViewData(underservedCommunitiesGoogleChart, DisadvantagedCommunityStatusGeospatialAreaTypeID,
                projectsByOwnerOrgTypeGoogleChart, projectsByCountyAndTribalLandGoogleChart, CountyGeospatialAreaTypeID,
                TribeGeospatialAreaTypeID, projectsByProjectTypeGoogleChart, ProjectTypeClassificationID,
                projectStagesGoogleChart, fundingOrganizationGoogleChart);
            return RazorPartialView<ProjectDashboardCharts, ProjectDashboardChartsViewData>(viewData);
        }

        private List<Project> GetProjectsForProjectDashboard()
        {
            var projectStages = GetProjectStagesForProjectDashboard();
            var projectTypes = GetProjectTypesForProjectDashboard();
            var countiesAndTribes = GetCountiesAndTribesForProjectDashboard();

            var projects = GetProjectEnumerableWithIncludesForPerformance()
                .Where(x => projectStages.Contains(x.ProjectStageID)).ToList();
            if (projectTypes.Count > 0)
            {
                projects = projects.Where(x => x.ProjectClassifications.Any(y =>
                    y.Classification.ClassificationSystemID == ProjectTypeClassificationID && projectTypes.Contains(y.ClassificationID))).ToList();
            }

            if (countiesAndTribes.Count > 0)
            {
                projects = projects.Where(x => x.ProjectGeospatialAreas.Any(y =>
                    (y.GeospatialArea.GeospatialAreaTypeID == CountyGeospatialAreaTypeID || y.GeospatialArea.GeospatialAreaTypeID == TribeGeospatialAreaTypeID) 
                    && y.GeospatialAreaID != NotTriballyOwnedGeospatialAreaID
                    && countiesAndTribes.Contains(y.GeospatialAreaID))).ToList();
            }

            return projects;
        }

        private static List<Project> GetProjectEnumerableWithIncludesForPerformance()
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects
                .Include(x => x.ProjectFundingSourceBudgets)
                .Include(x => x.SecondaryProjectTaxonomyLeafs)
                .Include(x => x.ProjectTags.Select(y => y.Tag))
                .Include(x => x.ProjectNoFundingSourceIdentifieds)
                .Include(x => x.ProjectProjectStatuses)
                .ToList();

            return projects.GetActiveProjects();
        }

        private List<int> GetProjectStagesForProjectDashboard()
        {
            var projectStages = new List<int>
            {
                ProjectStage.PlanningDesign.ProjectStageID,
                ProjectStage.Implementation.ProjectStageID,
                ProjectStage.PostImplementation.ProjectStageID,
                ProjectStage.Completed.ProjectStageID
            };
            if (!string.IsNullOrEmpty(Request.QueryString[ProjectDashboardViewData.ProjectStagesQueryStringParameter]))
            {

                var filterValuesAsString = Request.QueryString[ProjectDashboardViewData.ProjectStagesQueryStringParameter]
                    .Split(',');
                projectStages = filterValuesAsString.Select(int.Parse).ToList();
            }
            return projectStages;
        }

        private List<int> GetProjectTypesForProjectDashboard()
        {
            var projectTypeIDs = HttpRequestStorage.DatabaseEntities.Classifications
                .Where(x => x.ClassificationID == ProjectTypeClassificationID).Select(x => x.ClassificationID).ToList();

            if (!string.IsNullOrEmpty(Request.QueryString[ProjectDashboardViewData.ProjectTypesQueryStringParameter]))
            {
                var filterValuesAsString = Request.QueryString[ProjectDashboardViewData.ProjectTypesQueryStringParameter]
                    .Split(',');
                projectTypeIDs = filterValuesAsString.Select(int.Parse).ToList();
            }
            return projectTypeIDs;
        }

        private List<int> GetCountiesAndTribesForProjectDashboard()
        {
            var geospatialAreaIDs = HttpRequestStorage.DatabaseEntities.GeospatialAreas
                .Where(x =>
                    (x.GeospatialAreaTypeID == CountyGeospatialAreaTypeID ||
                     x.GeospatialAreaTypeID == TribeGeospatialAreaTypeID) &&
                    x.GeospatialAreaID != NotTriballyOwnedGeospatialAreaID).Select(x => x.GeospatialAreaID).ToList();

            if (!string.IsNullOrEmpty(Request.QueryString[ProjectDashboardViewData.CountiesTribesQueryStringParameter]))
            {
                var filterValuesAsString = Request.QueryString[ProjectDashboardViewData.CountiesTribesQueryStringParameter]
                    .Split(',');
                geospatialAreaIDs = filterValuesAsString.Select(int.Parse).ToList();
            }
            return geospatialAreaIDs;
        }
    }
}
