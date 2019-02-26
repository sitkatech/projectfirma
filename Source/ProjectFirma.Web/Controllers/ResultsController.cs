﻿/*-----------------------------------------------------------------------
<copyright file="ResultsController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
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
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Controllers
{
    public class ResultsController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult AccomplishmentsDashboard()
        {
            var firmaPage = FirmaPageTypeEnum.ProjectResults.GetFirmaPage();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();

            List<Organization> organizations;
            // default to Funding Organizations if no relationship type is selected to report in the dashboard.
            var relationshipTypeToReportInAccomplishmentsDashboard = MultiTenantHelpers.GetRelationshipTypeToReportInAccomplishmentsDashboard();
            if (relationshipTypeToReportInAccomplishmentsDashboard == null)
            {
                var expectedFundingOrganizations = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceRequests
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
                        y.RelationshipType == relationshipTypeToReportInAccomplishmentsDashboard).Select(z => z.Organization)).ToList().Distinct(new HavePrimaryKeyComparer<Organization>()).OrderBy(x => x.OrganizationName).ToList();              
            }

            var defaultEndYear = FirmaDateUtilities.CalculateCurrentYearToUseForRequiredReporting();
            var defaultBeginYear = defaultEndYear -(defaultEndYear - MultiTenantHelpers.GetMinimumYear());
            var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            var taxonomyTiers = associatePerformanceMeasureTaxonomyLevel.GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder).ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase).ToList();
            var viewData = new AccomplishmentsDashboardViewData(CurrentPerson, firmaPage, tenantAttribute,
                organizations, FirmaDateUtilities.GetRangeOfYearsForReporting(), defaultBeginYear,
                defaultEndYear, taxonomyTiers, associatePerformanceMeasureTaxonomyLevel);
            return RazorView<AccomplishmentsDashboard, AccomplishmentsDashboardViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult SpendingByOrganizationTypeByOrganization(int organizationID, int beginYear, int endYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(organizationID, beginYear, endYear);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.Where(x => x.IsFundingType).OrderBy(x => x.OrganizationTypeName == "Other").ThenBy(x => x.OrganizationTypeName).ToList();

            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
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
                projects = organization.GetAllActiveProjectsWhereOrganizationReportsInAccomplishmentsDashboard();
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic()).ToList();
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
                projects = organization.GetAllActiveProjectsAndProposals(CurrentPerson);
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic()).ToList();
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
            var primaryPerformanceMeasuresForTaxonomyTier = taxonomyTier.TaxonomyTierPerformanceMeasures.Where(x => x.Any(y => y.IsPrimaryTaxonomyLeaf)).Select(x => x.Key).ToList();
            var performanceMeasures = primaryPerformanceMeasuresForTaxonomyTier.SelectMany(x => x.PerformanceMeasureActuals.Where(y => projectIDs.Contains(y.ProjectID))).Select(x => x.PerformanceMeasure).Distinct().OrderBy(x => x.PerformanceMeasureDisplayName).ToList();
            var performanceMeasureChartViewDatas = performanceMeasures.Select(x => new PerformanceMeasureChartViewData(x, CurrentPerson, false, projects)).ToList();

            var viewData = new OrganizationAccomplishmentsViewData(performanceMeasureChartViewDatas, taxonomyTier, associatePerformanceMeasureTaxonomyLevel);
            return RazorPartialView<OrganizationAccomplishments, OrganizationAccomplishmentsViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult ParticipatingOrganizations(int organizationID)
        {
            var partnerOrganizations = GetPartnerOrganizations(organizationID);

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
                    .GetAllActiveProjectsWhereOrganizationReportsInAccomplishmentsDashboard()
                    .SelectMany(x => x.GetAssociatedOrganizationRelationships().Where(y => y.Organization.OrganizationID != organizationID && 
                                                                               y.Organization.OrganizationType.IsFundingType && //filter by only orgs that can be funders to remove state senate and assembly districts 
                                                                               y.Organization.IsActive))
                    .GroupBy(x => x.Organization, new HavePrimaryKeyComparer<Organization>())
                    .ToList();
            }
            else
            {
                var activeProjectsAndProposals = HttpRequestStorage.DatabaseEntities.Projects.ToList()
                    .GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic());
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

            var currentPersonCanViewProposals = CurrentPerson.CanViewProposals();
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
                filterValues = ProjectMapCustomization.GetDefaultLocationFilterValues(currentPersonCanViewProposals);
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

            var projectsToShow = ProjectMapCustomization.ProjectsForMap(currentPersonCanViewProposals);

            var initialCustomization =
                new ProjectMapCustomization(projectLocationFilterType, filterValues, colorByValue);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    projectsToShow.MappedPointsToGeoJsonFeatureCollection(true, true), "red", 1,
                    LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                initialCustomization, "ProjectLocationsMap");

            projectLocationsMapInitJson.Layers.AddRange(HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson());

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, colorByValue.GetDisplayName(), MultiTenantHelpers.GetTopLevelTaxonomyTiers(), currentPersonCanViewProposals);

            
            var projectLocationFilterTypesAndValues = CreateProjectLocationFilterTypesAndValuesDictionary(currentPersonCanViewProposals);
            var projectLocationsUrl = SitkaRoute<ResultsController>.BuildAbsoluteUrlHttpsFromExpression(x => x.ProjectMap());

            var filteredProjectsWithLocationAreasUrl =
                SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.FilteredProjectsWithLocationAreas(null));

            var projectColorByTypes = new List<ProjectColorByType> {ProjectColorByType.ProjectStage};
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                projectColorByTypes.Add(ProjectColorByType.TaxonomyTrunk);
                projectColorByTypes.Add(ProjectColorByType.TaxonomyBranch);
            }
            else if (MultiTenantHelpers.IsTaxonomyLevelBranch())
            {
                projectColorByTypes.Add(ProjectColorByType.TaxonomyBranch);
            }
            var viewData = new ProjectMapViewData(CurrentPerson,
                firmaPage,
                projectLocationsMapInitJson,
                projectLocationsMapViewData,
                projectLocationFilterTypesAndValues,
                projectLocationsUrl, filteredProjectsWithLocationAreasUrl, projectColorByTypes);
            return RazorView<ProjectMap, ProjectMapViewData>(viewData);
        }

        private static Dictionary<ProjectLocationFilterTypeSimple, IEnumerable<SelectListItem>> CreateProjectLocationFilterTypesAndValuesDictionary(bool showProposals)
        {
            var projectLocationFilterTypesAndValues =
                new Dictionary<ProjectLocationFilterTypeSimple, IEnumerable<SelectListItem>>();

            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                var taxonomyTrunksAsSelectListItems =
                    HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.AsEnumerable().ToSelectList(
                        x => x.TaxonomyTrunkID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
                projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.TaxonomyTrunk),
                    taxonomyTrunksAsSelectListItems);
            }

            if (!MultiTenantHelpers.IsTaxonomyLevelLeaf())
            {
                var taxonomyBranchesAsSelectListItems =
                    HttpRequestStorage.DatabaseEntities.TaxonomyBranches.AsEnumerable().ToSelectList(
                        x => x.TaxonomyBranchID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
                projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.TaxonomyBranch),
                    taxonomyBranchesAsSelectListItems);
            }

            var taxonomyLeafsAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.AsEnumerable().ToSelectList(
                    x => x.TaxonomyLeafID.ToString(CultureInfo.InvariantCulture), x => x.GetDisplayName());
            projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.TaxonomyLeaf),
                taxonomyLeafsAsSelectListItems);

            var classificationsAsSelectList = MultiTenantHelpers.GetClassificationSystems().SelectMany(x => x.Classifications).ToSelectList(x => x.ClassificationID.ToString(CultureInfo.InvariantCulture), x => MultiTenantHelpers.GetClassificationSystems().Count > 1 ? $"{x.ClassificationSystem.ClassificationSystemName} - {x.GetDisplayName()}" : x.GetDisplayName());
            projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.Classification, string.Join(" & ", MultiTenantHelpers.GetClassificationSystems().Select(x => x.ClassificationSystemName).ToList())), classificationsAsSelectList);

            var projectStagesAsSelectListItems = ProjectMapCustomization.GetProjectStagesForMap(showProposals).ToSelectList(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), x => x.ProjectStageDisplayName);
            projectLocationFilterTypesAndValues.Add(new ProjectLocationFilterTypeSimple(ProjectLocationFilterType.ProjectStage), projectStagesAsSelectListItems);

            return projectLocationFilterTypesAndValues;
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
            var allProjectsForMap = ProjectMapCustomization.ProjectsForMap(CurrentPerson.CanViewProposals());
            var filteredProjects = allProjectsForMap.Where(filterFunction.Compile())
                .ToList();

            var filteredProjectsWithLocationAreas = filteredProjects.Where(x => !x.HasProjectLocationPoint()).ToList();

            var taxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            var taxonomyTiersAsFancyTreeNodes = taxonomyLevel
                .GetTaxonomyTiers(HttpRequestStorage.DatabaseEntities).OrderBy(x => x.SortOrder)
                .ThenBy(x => x.DisplayName, StringComparer.InvariantCultureIgnoreCase)
                .Select(x => x.ToFancyTreeNode(CurrentPerson))
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
                new PerformanceMeasureChartViewData(selectedPerformanceMeasure, CurrentPerson, false, new List<Project>());

            var viewData = new SpendingByPerformanceMeasureByProjectViewData(CurrentPerson, firmaPage,
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
                GetSpendingByPerformanceMeasureByProjectAndGridSpec(out var gridSpec, performanceMeasure, CurrentPerson);
            var gridJsonNetJObjectResult =
                new GridJsonNetJObjectResult<PerformanceMeasureSubcategoriesTotalReportedValue>(
                    performanceMeasureSubcategoriesTotalReportedValues, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureSubcategoriesTotalReportedValue> GetSpendingByPerformanceMeasureByProjectAndGridSpec(
                out SpendingByPerformanceMeasureByProjectGridSpec gridSpec,
                PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            gridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(performanceMeasure);
            return PerformanceMeasureModelExtensions.SubcategoriesTotalReportedValues(currentPerson, performanceMeasure);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult ConfigureAccomplishmentsDashboard()
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttribute();
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

            var relationshipTypes = HttpRequestStorage.DatabaseEntities.RelationshipTypes;

            viewModel.UpdateModel(relationshipTypes);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewConfigureAccomplishmentsDashboard(ConfigureAccomplishmentsDashboardViewModel viewModel)
        {
            IEnumerable<SelectListItem> relationshipTypes = HttpRequestStorage.DatabaseEntities.RelationshipTypes
                .ToList().ToSelectListWithEmptyFirstRow(
                    x => x.RelationshipTypeID.ToString(CultureInfo.InvariantCulture),
                    x => x.RelationshipTypeName.ToString(CultureInfo.InvariantCulture), "Funding Organization (Default)");
            var viewData = new ConfigureAccomplishmentsDashboardViewData(relationshipTypes);
            return RazorPartialView<ConfigureAccomplishmentsDashboard, ConfigureAccomplishmentsDashboardViewData,
                ConfigureAccomplishmentsDashboardViewModel>(viewData, viewModel);
        }
    }
}
