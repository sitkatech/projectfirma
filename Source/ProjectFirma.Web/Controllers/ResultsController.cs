/*-----------------------------------------------------------------------
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
using Newtonsoft.Json;
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
            // PerformanceMeasureID = 3757 is the Outcome "Total Acres Constructed"
            var acresConstructedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3757);
            var totalAcresConstructedInConstruction = acresConstructedPerformanceMeasure.GetTotalActualsForPerformanceMeasureSubcategoryOption(6293);
            var totalAcresConstructedCompleted = acresConstructedPerformanceMeasure.GetTotalActualsForPerformanceMeasureSubcategoryOption(6282);

            // PerformanceMeasureID = 3731 is the Outcome "Area Treated for Dust Suppression"
            var dustSuppressionPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3731);
            // PerformanceMeasureID = 3736 is "Area Treated for Vegetation Enhancement"
            var vegetationEnhancementPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3736);
            // PerformanceMeasureID = 3737 "Area of Aquatic Habitat Created"
            var aquaticHabitatCreatedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3737);
            // PerformanceMeasureID = 3750 is "Area of Endangered & Special Status Species Habitat Created"
            var endangeredSpeciesHabitatCreatedPerformanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Single(x => x.PerformanceMeasureID == 3750);
            var acresConstructedByTheNumbersFirmaPage = FirmaPageTypeEnum.ProgressDashboardAcresConstructedByTheNumbers.GetFirmaPage();

            /* Acres Constructed pie charts */
            var acresConstructedPieChartFirmaPage = FirmaPageTypeEnum.ProgressDashboardAcresConstructedPieCharts.GetFirmaPage();
            var dustSuppressionValues = dustSuppressionPerformanceMeasure.GetProgressDashboardPieChartValues(6114, 6254);
            var areaTreatedForDustSuppressionPieChart = MakeGoogleChartJsonForProgressDashboardPieChart(dustSuppressionPerformanceMeasure, dustSuppressionValues);

            var vegetationEnhancementValues = vegetationEnhancementPerformanceMeasure.GetProgressDashboardPieChartValues(6122, 6253);
            var areaTreatedForVegetationEnhancementGoogleChart = MakeGoogleChartJsonForProgressDashboardPieChart(vegetationEnhancementPerformanceMeasure, vegetationEnhancementValues);

            var aquaticHabitatCreatedValues = aquaticHabitatCreatedPerformanceMeasure.GetProgressDashboardPieChartValues(6123, 6189);
            var aquaticHabitatCreatedPieChart = MakeGoogleChartJsonForProgressDashboardPieChart(aquaticHabitatCreatedPerformanceMeasure, aquaticHabitatCreatedValues);


            var endangeredSpeciesHabitatCreatedValues = endangeredSpeciesHabitatCreatedPerformanceMeasure.GetProgressDashboardPieChartValues(6255, 6256);
            var endangeredSpeciesHabitatCreatedPieChart = MakeGoogleChartJsonForProgressDashboardPieChart(endangeredSpeciesHabitatCreatedPerformanceMeasure, endangeredSpeciesHabitatCreatedValues);


            var dustSuppressionChartJsonsAndProjectColors = MakeGoogleChartJsonsForProgressDashboardBarChart(dustSuppressionPerformanceMeasure, 6114);
            var vegetationEnhancementChartJsonsAndProjectColors = MakeGoogleChartJsonsForProgressDashboardBarChart(vegetationEnhancementPerformanceMeasure, 6122);
            var aquaticHabitatCreatedChartJsonsAndProjectColors = MakeGoogleChartJsonsForProgressDashboardBarChart(aquaticHabitatCreatedPerformanceMeasure, 6123);
            var endangeredSpeciesHabitatChartJsonsAndProjectColors = MakeGoogleChartJsonsForProgressDashboardBarChart(endangeredSpeciesHabitatCreatedPerformanceMeasure, 6255);

            var dustSuppressionDisplayName = dustSuppressionPerformanceMeasure.GetDisplayName();
            var vegetationEnhancementDisplayName = vegetationEnhancementPerformanceMeasure.GetDisplayName();
            var aquaticHabitatDisplayName = aquaticHabitatCreatedPerformanceMeasure.GetDisplayName();
            var endangeredSpeciesHabitatDisplayName = endangeredSpeciesHabitatCreatedPerformanceMeasure.GetDisplayName();


            var viewData = new ProgressDashboardViewData(CurrentFirmaSession, firmaPage, projectCount, fundsCommittedToProgram, partnershipCount,
                totalAcresConstructedInConstruction, totalAcresConstructedCompleted, acresConstructedByTheNumbersFirmaPage, acresConstructedPieChartFirmaPage,
                areaTreatedForDustSuppressionPieChart, areaTreatedForVegetationEnhancementGoogleChart, aquaticHabitatCreatedPieChart, endangeredSpeciesHabitatCreatedPieChart,
                dustSuppressionValues, vegetationEnhancementValues, aquaticHabitatCreatedValues, endangeredSpeciesHabitatCreatedValues,
                dustSuppressionChartJsonsAndProjectColors.Item1, dustSuppressionChartJsonsAndProjectColors.Item2,
                vegetationEnhancementChartJsonsAndProjectColors.Item1, vegetationEnhancementChartJsonsAndProjectColors.Item2,
                aquaticHabitatCreatedChartJsonsAndProjectColors.Item1, aquaticHabitatCreatedChartJsonsAndProjectColors.Item2,
                endangeredSpeciesHabitatChartJsonsAndProjectColors.Item1, endangeredSpeciesHabitatChartJsonsAndProjectColors.Item2,
                dustSuppressionDisplayName, vegetationEnhancementDisplayName, aquaticHabitatDisplayName, endangeredSpeciesHabitatDisplayName);
            return RazorView<ProgressDashboard, ProgressDashboardViewData>(viewData);
        }

        private GoogleChartJson MakeGoogleChartJsonForProgressDashboardPieChart(PerformanceMeasure performanceMeasure, List<double> values)
        {
            var chartTitle = performanceMeasure.GetDisplayName();
            var pieSliceTextStyle = new GoogleChartTextStyle("#1c2329") { IsBold = true, FontSize = 20 };

            // 80% will give space to show google charts legend
            //var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "80%", 10, 10);

            // 90% is enough space for our custom legend
            var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "90%", 10, 10);

            var googleChartContainerID = chartTitle.Replace(" ", "").Replace("&", "");
            var googlePieChartSlices = performanceMeasure.GetProgressDashboardPieChartSlices(values);
            var googleChartDataTable = PerformanceMeasureModelExtensions.GetProgressDashboardPieChartDataTable(googlePieChartSlices);
            var googlePieChartConfiguration = new GooglePieChartConfiguration(
                    chartTitle, MeasurementUnitTypeEnum.Acres, googlePieChartSlices,
                    GoogleChartType.PieChart, googleChartDataTable, pieSliceTextStyle, googleChartConfigurationArea)
                { PieSliceText = "value", PieHole = 0.4 };
            googlePieChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            return new GoogleChartJson(chartTitle, googleChartContainerID, googlePieChartConfiguration, GoogleChartType.PieChart, googleChartDataTable, null);

        }

        private Tuple<List<GoogleChartJson>, Dictionary<Project, Tuple<string, double>>> MakeGoogleChartJsonsForProgressDashboardBarChart(PerformanceMeasure performanceMeasure, int acresCompletedSubcategoryOptionID)
        {
            var googleChartJsons = new List<GoogleChartJson>();
            var projectToColorAndValue = new Dictionary<Project, Tuple<string, double>>();
            var performanceMeasureReportingPeriods = performanceMeasure.GetPerformanceMeasureReportingPeriodsFromActuals();

            var groupedByProject = new List<IGrouping<Project, PerformanceMeasureActualSubcategoryOption>>();
            var chartColumns = new List<string>();
            if (performanceMeasure.PerformanceMeasureActualSubcategoryOptions.Any(x => x.PerformanceMeasureSubcategoryOptionID == acresCompletedSubcategoryOptionID))
            {
                groupedByProject = performanceMeasure.PerformanceMeasureActualSubcategoryOptions
                    .Where(x => x.PerformanceMeasureSubcategoryOptionID == acresCompletedSubcategoryOptionID).GroupBy(x => x.PerformanceMeasureActual.Project).ToList();
                chartColumns = groupedByProject.Select(x => x.Key.ProjectName).OrderBy(x => x).ToList();

                var chartAndProjectToColorDictionary = performanceMeasure.GetProgressDashboardGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasureReportingPeriods, groupedByProject, chartColumns, false);
                var googleChartDataTable = chartAndProjectToColorDictionary.Item1;

                var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}CompletedAcres";

                var googleChartAxisHorizontal = new GoogleChartAxis("Year", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
                var googleChartAxis = new GoogleChartAxis("Completed Acres", MeasurementUnitTypeEnum.Acres, GoogleChartAxisLabelFormat.Short);
                var googleChartAxisVerticals = new List<GoogleChartAxis> { googleChartAxis };

                var chartConfiguration = new GoogleChartConfiguration(chartName, true, GoogleChartType.ColumnChart,
                    googleChartDataTable, googleChartAxisHorizontal, googleChartAxisVerticals);

                chartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
                chartConfiguration.SetSeriesIgnoringNullGoogleChartSeries(googleChartDataTable);

                var googleChartJson = new GoogleChartJson("Completed Acres", chartName, chartConfiguration,
                    GoogleChartType.ColumnChart, googleChartDataTable,
                    chartColumns, null, null, false);
                googleChartJson.CanConfigureChart = false;

                googleChartJsons.Add(googleChartJson);

                chartAndProjectToColorDictionary = performanceMeasure.GetProgressDashboardGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasureReportingPeriods, groupedByProject, chartColumns, true);
                var googleChartDataTableCumulative = chartAndProjectToColorDictionary.Item1;

                var chartNameCumulative = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}CompletedAcresCumulative";

                var googleChartAxisHorizontalCumulative = new GoogleChartAxis("Year", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
                var googleChartAxisCumulative = new GoogleChartAxis("Completed Acres", MeasurementUnitTypeEnum.Acres, GoogleChartAxisLabelFormat.Short);
                var googleChartAxisVerticalsCumulative = new List<GoogleChartAxis> { googleChartAxisCumulative };

                var chartConfigurationCumulative = new GoogleChartConfiguration(chartNameCumulative, true, GoogleChartType.ColumnChart,
                    googleChartDataTableCumulative, googleChartAxisHorizontalCumulative, googleChartAxisVerticalsCumulative);

                chartConfigurationCumulative.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
                chartConfigurationCumulative.SetSeriesIgnoringNullGoogleChartSeries(googleChartDataTableCumulative);

                var googleChartJsonCumulative = new GoogleChartJson("Completed Acres", chartNameCumulative, chartConfigurationCumulative,
                    GoogleChartType.ColumnChart, googleChartDataTableCumulative,
                    chartColumns, null, null, true);
                googleChartJsonCumulative.CanConfigureChart = false;

                googleChartJsons.Add(googleChartJsonCumulative);


                groupedByProject.OrderBy(x => x.Key.ProjectName).Select(x =>
                {
                    var calendarYearReportedValue = x.Sum(pmsorv => pmsorv.PerformanceMeasureActual.ActualValue);
                    return calendarYearReportedValue;
                });

                var projectToColor = chartAndProjectToColorDictionary.Item2;

                projectToColorAndValue = groupedByProject.OrderBy(x => x.Key.ProjectName).ToDictionary(x => x.Key,
                    x => new Tuple<string, double>(projectToColor[x.Key.ProjectName], x.Sum(pmsorv => pmsorv.PerformanceMeasureActual.ActualValue)) );
            }

            return new Tuple<List<GoogleChartJson>, Dictionary<Project, Tuple<string, double>>>(googleChartJsons, projectToColorAndValue) ;
        }

        // Allow admin access only for now
        [FirmaAdminFeature]
        public ViewResult ProjectDashboard()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            var firmaPage = FirmaPageTypeEnum.NCRPProjectDashboard.GetFirmaPage();

            GetProjectSummaryData(out var projects, out var partners, out var projectsInUnderservedCommunities);

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

            var tempIDToSolutionValue = GetSolutionsDictionaryForProjectDashboard();
            var solutionsSelectList = tempIDToSolutionValue.ToSelectList(x => x.Key.ToString(CultureInfo.InvariantCulture), x => x.Value).ToList();

            var underservedCommunitiesGoogleChart =
                GetUndersercedCommunitiesPieChartForProjectDashboard(projects, projectsInUnderservedCommunities);
            var projectDashboardChartsViewData =
                new ProjectDashboardChartsViewData(underservedCommunitiesGoogleChart);

            var viewData =
                new ProjectDashboardViewData(CurrentFirmaSession, firmaPage, projects.Count, partners.Count,
                    projectsInUnderservedCommunities.Count, projectGridSpec, solutionsSelectList, projectDashboardChartsViewData);
            return RazorView<ProjectDashboard, ProjectDashboardViewData>(viewData);
        }



        // Allow admin access only for now
        [FirmaAdminFeature]
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

        [FirmaAdminFeature]
        public JsonNetJObjectResult ProjectDashboardProjectSummary()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            GetProjectSummaryData(out var projects, out var partners, out var projectsInUnderservedCommunities);
            return new JsonNetJObjectResult(new
            {
                ProjectCount = projects.Count.ToGroupedNumeric(),
                PartnerCount = partners.Count.ToGroupedNumeric(),
                ProjectsInUnderservedCommunitiesCount = projectsInUnderservedCommunities.Count.ToGroupedNumeric()
            });
        }

        private void GetProjectSummaryData(out List<Project> projects, out List<Organization> projectSponsors, out List<Project> projectsInUnderservedCommunities)
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
        }

        private GoogleChartJson GetUndersercedCommunitiesPieChartForProjectDashboard(List<Project> projects,  List<Project> projectsInUnderservedCommunities)
        {


            // var chartTitle = performanceMeasure.GetDisplayName();
            // var pieSliceTextStyle = new GoogleChartTextStyle("#1c2329") { IsBold = true, FontSize = 20 };
            //
            // // 80% will give space to show google charts legend
            // //var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "80%", 10, 10);
            //
            // // 90% is enough space for our custom legend
            // var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "90%", 10, 10);
            //
            // var googleChartContainerID = chartTitle.Replace(" ", "").Replace("&", "");
            // var googlePieChartSlices = performanceMeasure.GetProgressDashboardPieChartSlices(values);
            // var googleChartDataTable = PerformanceMeasureModelExtensions.GetProgressDashboardPieChartDataTable(googlePieChartSlices);
            // var googlePieChartConfiguration = new GooglePieChartConfiguration(
            //         chartTitle, MeasurementUnitTypeEnum.Acres, googlePieChartSlices,
            //         GoogleChartType.PieChart, googleChartDataTable, pieSliceTextStyle, googleChartConfigurationArea)
            //     { PieSliceText = "value", PieHole = 0.4 };
            // googlePieChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            // return new GoogleChartJson(chartTitle, googleChartContainerID, googlePieChartConfiguration, GoogleChartType.PieChart, googleChartDataTable, null);


            var chartTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} by Underserved Community Status";
            var pieChartContainerID = chartTitle.Replace(" ", "");

            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();
            googlePieChartSlices.Add(new GooglePieChartSlice("Not in a Disadvantaged Community", projects.Count - projectsInUnderservedCommunities.Count, sortOrder++, "#FFE196"));
            googlePieChartSlices.Add(new GooglePieChartSlice("Disadvantaged Community", projectsInUnderservedCommunities.Count(x => x.ProjectGeospatialAreas.Any(y => y.GeospatialArea.GeospatialAreaName == "Disadvantaged Community")), sortOrder++, "#FF7142"));
            googlePieChartSlices.Add(new GooglePieChartSlice("Severely Disadvantaged Community", projectsInUnderservedCommunities.Count(x => x.ProjectGeospatialAreas.Any(y => y.GeospatialArea.GeospatialAreaName == "Severely Disadvantaged Community")), sortOrder, "#A53FFF"));


            var googleChartColumns = new List<GoogleChartColumn>
            {
                new GoogleChartColumn($"Underserved Community Status", GoogleChartColumnDataType.String, GoogleChartType.PieChart),
                new GoogleChartColumn($"Count", GoogleChartColumnDataType.Number, GoogleChartType.PieChart)

            };

            var chartRowCs = googlePieChartSlices.Select(x =>
            {
                var fundingTypeRowV = new GoogleChartRowV(x.Label);
                var formattedValue = x.Value.ToGroupedNumeric();
                var amountRowV = new GoogleChartRowV(x.Value, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> { fundingTypeRowV, amountRowV });
            });
            var googleChartRowCs = new List<GoogleChartRowC>(chartRowCs);

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);

            var pieSliceTextStyle = new GoogleChartTextStyle("#1c2329") { IsBold = true, FontSize = 20 };
            var googleChartConfigurationArea = new GoogleChartConfigurationArea("100%", "80%", 10, 10);

            var pieChartConfiguration = new GooglePieChartConfiguration(chartTitle, MeasurementUnitTypeEnum.Number, googlePieChartSlices, GoogleChartType.PieChart, googleChartDataTable, pieSliceTextStyle, googleChartConfigurationArea) { PieSliceText = "value" };
            //pieChartConfiguration.ChartArea.Top = 60;

            pieChartConfiguration.Legend.SetLegendPosition(GoogleChartLegendPosition.Right);

            var pieChart = new GoogleChartJson(chartTitle, pieChartContainerID, pieChartConfiguration,
                GoogleChartType.PieChart, googleChartDataTable, null);
            pieChart.CanConfigureChart = false;
            return pieChart;

        }

        [FirmaAdminFeature]
        public PartialViewResult ProjectDashboardCharts()
        {
            Check.RequireTrueThrowNotFound(MultiTenantHelpers.UsesCustomProjectDashboardPage(CurrentFirmaSession), "This page is not available for this tenant.");
            GetProjectSummaryData(out var projects, out var partners, out var projectsInUnderservedCommunities);
            var underservedCommunitiesGoogleChart = GetUndersercedCommunitiesPieChartForProjectDashboard(projects, projectsInUnderservedCommunities);
            var viewData = new ProjectDashboardChartsViewData(underservedCommunitiesGoogleChart);
            return RazorPartialView<ProjectDashboardCharts, ProjectDashboardChartsViewData>(viewData);
        }

        private List<Project> GetProjectsForProjectDashboard()
        {
            var projectStages = GetProjectStagesForProjectDashboard();
            var solutions = GetSolutionsForProjectDashboard();

            var projects = GetProjectEnumerableWithIncludesForPerformance()
                .Where(x => projectStages.Contains(x.ProjectStageID)).ToList();
            if (solutions.Count > 0)
            {
                projects = projects.Where(x => x.ProjectCustomAttributes.Any(y =>
                    y.ProjectCustomAttributeTypeID == 121
                    && y.ProjectCustomAttributeValues.Any(z => solutions.Contains(z.AttributeValue)))).ToList();
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

        private List<string> GetSolutionsForProjectDashboard()
        {
            var solutionTempIDs = new List<int>();
            if (!string.IsNullOrEmpty(Request.QueryString[ProjectDashboardViewData.SolutionsQueryStringParameter]))
            {
                var filterValuesAsString = Request.QueryString[ProjectDashboardViewData.SolutionsQueryStringParameter]
                    .Split(',');
                solutionTempIDs = filterValuesAsString.Select(int.Parse).ToList();
            }
            var tempIDToSolutionValue = GetSolutionsDictionaryForProjectDashboard();
            var solutions = tempIDToSolutionValue.Where(x => solutionTempIDs.Contains(x.Key)).Select(x => x.Value).ToList();
            return solutions;
        }

        private Dictionary<int, string> GetSolutionsDictionaryForProjectDashboard()
        {
            var tempIDToSolutionValue = new Dictionary<int, string>();
            var solutionCustomAttribute = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.SingleOrDefault(x => x.ProjectCustomAttributeTypeID == 121);
            
            if (solutionCustomAttribute != null && solutionCustomAttribute.ProjectCustomAttributeTypeOptionsSchema != null)
            {
                var solutions = JsonConvert.DeserializeObject<List<string>>(solutionCustomAttribute.ProjectCustomAttributeTypeOptionsSchema);
                if (solutions == null)
                {
                    return tempIDToSolutionValue;
                }
                var orderedSolutions = solutions.OrderBy(x => x).ToList();
                for (int i = 0;  i < orderedSolutions.Count; i++)
                {
                    // make tempID start at 1 instead of 0
                    tempIDToSolutionValue[i + 1] = solutions[i];
                }
            }

            return tempIDToSolutionValue;

        }
    }
}
