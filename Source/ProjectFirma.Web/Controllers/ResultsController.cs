/*-----------------------------------------------------------------------
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Views.PerformanceMeasure;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class ResultsController : FirmaBaseController
    {
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public ViewResult AccomplishmentsDashboard()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ProjectResults);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => x.CanBeAnApprovingOrganization()).OrderBy(x => x.OrganizationName).ToList();
            var defaultEndYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var defaultBeginYear = defaultEndYear -(defaultEndYear - MultiTenantHelpers.GetMinimumYear());
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.OrderBy(x => x.TaxonomyTierTwoName).ToList();
            var viewData = new AccomplishmentsDashboardViewData(CurrentPerson, firmaPage, organizations, FirmaDateUtilities.GetRangeOfYearsForReportingExpenditures(), defaultBeginYear, defaultEndYear, taxonomyTierTwos);
            return RazorView<AccomplishmentsDashboard, AccomplishmentsDashboardViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult SpendingByOrganizationTypeByOrganization(int organizationID, int beginYear, int endYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(organizationID, beginYear, endYear);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.Where(x => x.IsFundingType).OrderBy(x => x.OrganizationTypeName == "Other").ThenBy(x => x.OrganizationTypeName).ToList();
            var taxonomyTierTwos = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.OrderBy(x => x.TaxonomyTierTwoName).ToList();
            var viewData = new SpendingByOrganizationTypeByOrganizationViewData(organizationTypes, projectFundingSourceExpenditures, taxonomyTierTwos);
            return RazorPartialView<SpendingByOrganizationTypeByOrganization,
                SpendingByOrganizationTypeByOrganizationViewData>(viewData);
        }

        private static List<ProjectFundingSourceExpenditure> GetProjectExpendituresByOrganizationType(int organizationID, int beginYear, int endYear)
        {
            var projectFundingSourceExpenditures = HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.Where(x => x.CalendarYear >= beginYear && x.CalendarYear <= endYear).ToList();
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) && MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                return projectFundingSourceExpenditures.Where(x => x.Project.GetCanStewardProjectsOrganization().OrganizationID == organizationID).OrderBy(x => x.Project.ProjectName).ToList();
            }

            return projectFundingSourceExpenditures.OrderBy(x => x.Project.ProjectName).ToList();
        }

        [AnonymousUnclassifiedFeature]
        public JsonNetJObjectResult OrganizationDashboardSummary(int organizationID)
        {
            List<Project> projects;
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) &&
                MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
                projects = organization.GetAllActiveProjectsAndProposals(CurrentPerson);
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic()).ToList();
            }

            return new JsonNetJObjectResult(new
            {
                ProjectCount = projects.Count.ToGroupedNumeric(),
                PartnerCount = projects.SelectMany(x => x.ProjectOrganizations.Select(y => y.OrganizationID)).Distinct().Count().ToGroupedNumeric(),
                TotalInvestment = projects.SelectMany(x => x.ProjectFundingSourceExpenditures).Sum(x => x.ExpenditureAmount).ToGroupedNumeric()
            });
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult OrganizationAccomplishments(int organizationID, int taxonomyTierTwoID)
        {
            List<Project> projects;
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) &&
                MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
                projects = organization.GetAllActiveProjectsAndProposals(CurrentPerson);
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic()).ToList();
            }

            var performanceMeasures = projects
                .Where(x => x.TaxonomyTierOne.TaxonomyTierTwoID == taxonomyTierTwoID)
                .SelectMany(x => x.PerformanceMeasureActuals)
                .Select(x => x.PerformanceMeasure).Distinct()
                .OrderBy(x => x.PerformanceMeasureDisplayName)
                .ToList();
            var projectIDs = projects.Select(x => x.ProjectID).Distinct().ToList();
            var projectStewardOrLeadImplementorFieldDefinitionName = MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship()
                ? FieldDefinition.ProjectsStewardOrganizationRelationshipToProject.GetFieldDefinitionLabel()
                : "Lead Implementer";
            var performanceMeasureChartViewDatas = performanceMeasures.Select(x => new PerformanceMeasureChartViewData(x, projectIDs, CurrentPerson, false)).ToList();

            var taxonomyTierTwo =
                HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.GetTaxonomyTierTwo(taxonomyTierTwoID);
            var viewData = new OrganizationAccomplishmentsViewData(projectStewardOrLeadImplementorFieldDefinitionName, performanceMeasureChartViewDatas, taxonomyTierTwo);
            return RazorPartialView<OrganizationAccomplishments, OrganizationAccomplishmentsViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public PartialViewResult ParticipatingOrganizations(int organizationID)
        {
            List<Project> projects;
            List<IGrouping<Organization, ProjectOrganization>> organizations;
            if (ModelObjectHelpers.IsRealPrimaryKeyValue(organizationID) &&
                MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganization(organizationID);
                projects = organization.GetAllActiveProjectsAndProposalsWhereOrganizationIsStewardOrLeadImplementer(CurrentPerson);
                organizations = projects.SelectMany(x => x.ProjectOrganizations.Where(y => y.OrganizationID != organizationID && y.Organization.OrganizationType.IsFundingType)).GroupBy(x => x.Organization, new HavePrimaryKeyComparer<Organization>()).ToList();
            }
            else
            {
                projects = HttpRequestStorage.DatabaseEntities.Projects.ToList().GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic()).ToList();
                organizations = projects.SelectMany(x => x.ProjectOrganizations.Where(y => y.Organization.OrganizationType.IsFundingType)).GroupBy(x => x.Organization, new HavePrimaryKeyComparer<Organization>()).ToList();
            }

            var viewData = new ParticipatingOrganizationsViewData(organizations.Take(9).ToList());
            return RazorPartialView<ParticipatingOrganizations, ParticipatingOrganizationsViewData>(viewData);
        }

        [ProjectLocationsViewFeature]
        public ViewResult ProjectMap()
        {
            List<int> filterValues;
            ProjectLocationFilterType projectLocationFilterType;
            ProjectColorByType colorByValue;

            var currentPersonCanViewProposals = CurrentPerson.CanViewProposals;
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

            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ProjectMap);

            var projectsToShow = ProjectMapCustomization.ProjectsForMap(currentPersonCanViewProposals);

            var initialCustomization =
                new ProjectMapCustomization(projectLocationFilterType, filterValues, colorByValue);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()}",
                    Project.MappedPointsToGeoJsonFeatureCollection(projectsToShow, true), "red", 1,
                    LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson,
                initialCustomization, "ProjectLocationsMap")
            {
                Layers = HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson()
            };

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, colorByValue.DisplayName, MultiTenantHelpers.GetTopLevelTaxonomyTiers(), currentPersonCanViewProposals);

            
            var projectLocationFilterTypesAndValues = CreateProjectLocationFilterTypesAndValuesDictionary(currentPersonCanViewProposals);
            var projectLocationsUrl = SitkaRoute<ResultsController>.BuildAbsoluteUrlHttpsFromExpression(x => x.ProjectMap());

            var filteredProjectsWithLocationAreasUrl =
                SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.FilteredProjectsWithLocationAreas(null));

            var viewData = new ProjectMapViewData(CurrentPerson,
                firmaPage,
                projectLocationsMapInitJson,
                projectLocationsMapViewData,
                projectLocationFilterTypesAndValues,
                projectLocationsUrl, filteredProjectsWithLocationAreasUrl);
            return RazorView<ProjectMap, ProjectMapViewData>(viewData);
        }

        private static Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> CreateProjectLocationFilterTypesAndValuesDictionary(bool showProposals)
        {
            var projectLocationFilterTypesAndValues =
                new Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>>();

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                var taxonomyTierThreesAsSelectListItems =
                    HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.AsEnumerable().ToSelectList(
                        x => x.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
                projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.TaxonomyTierThree,
                    taxonomyTierThreesAsSelectListItems);
            }

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() >= 2)
            {
                var taxonomyTierTwosAsSelectListItems =
                    HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.AsEnumerable().ToSelectList(
                        x => x.TaxonomyTierTwoID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
                projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.TaxonomyTierTwo,
                    taxonomyTierTwosAsSelectListItems);
            }

            var taxonomyTierOnesAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.AsEnumerable().ToSelectList(
                    x => x.TaxonomyTierOneID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.TaxonomyTierOne,
                taxonomyTierOnesAsSelectListItems);

            var classificationsAsSelectListItems =
                HttpRequestStorage.DatabaseEntities.Classifications.AsEnumerable().ToSelectList(
                    x => x.ClassificationID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.Classification,
                classificationsAsSelectListItems);


            var projectStagesAsSelectListItems = ProjectMapCustomization.GetProjectStagesForMap(showProposals).ToSelectList(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), x => x.ProjectStageDisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.ProjectStage, projectStagesAsSelectListItems);

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
            var projectLocationGroupsAsFancyTreeNodes = HttpRequestStorage.DatabaseEntities.Watersheds
                .ToList()
                .Where(x => x.ProjectWatersheds.Any())
                .Select(x => x.ToFancyTreeNode())
                .ToList();

            var projectLocationFilterTypeFromFilterPropertyName = projectMapCustomization
                .GetProjectLocationFilterTypeFromFilterPropertyName();
            var filterFunction =
                projectLocationFilterTypeFromFilterPropertyName.GetFilterFunction(projectMapCustomization
                    .FilterPropertyValues);
            var allProjectsForMap = ProjectMapCustomization.ProjectsForMap(CurrentPerson.CanViewProposals);
            var filteredProjects = allProjectsForMap.Where(filterFunction.Compile())
                .ToList();

            var filteredProjectsWithLocationAreas = filteredProjects
                .Where(x => !x.HasProjectLocationPoint && x.HasProjectWatersheds)
                .ToList();

            projectLocationGroupsAsFancyTreeNodes.RemoveAll(
                areaNameNode =>
                    areaNameNode.Children.Count ==
                    areaNameNode.Children.RemoveAll(projectNode =>
                    {
                        return !filteredProjectsWithLocationAreas
                            .Select(project => project.FancyTreeNodeKey.ToString())
                            .Contains(projectNode.Key);
                    }));

            return new JsonNetJArrayResult(projectLocationGroupsAsFancyTreeNodes);
        }

        [ResultsByTaxonomyTierTwoViewFeature]
        public ViewResult ResultsByTaxonomyTierTwo(int? taxonomyTierTwoID)
        {
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees
                .OrderBy(x => x.TaxonomyTierThreeName).ToList();
            var selectedTaxonomyTierTwo = taxonomyTierTwoID.HasValue
                ? HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.GetTaxonomyTierTwo(taxonomyTierTwoID.Value)
                : taxonomyTierThrees.First().TaxonomyTierTwos.First();
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ResultsByTaxonomyTierTwo);
            var performanceMeasureChartViewDatas = selectedTaxonomyTierTwo.GetPerformanceMeasures().ToList()
                .OrderBy(x => x.PerformanceMeasureDisplayName).Select(x =>
                    new PerformanceMeasureChartViewData(x,
                        new List<int>(),
                        CurrentPerson,
                        false)).ToList();
            var viewData = new ResultsByTaxonomyTierTwoViewData(CurrentPerson, firmaPage, taxonomyTierThrees,
                selectedTaxonomyTierTwo, performanceMeasureChartViewDatas);
            return RazorView<ResultsByTaxonomyTierTwo, ResultsByTaxonomyTierTwoViewData>(viewData);
        }

        [SpendingByPerformanceMeasureByProjectViewFeature]
        public ViewResult SpendingByPerformanceMeasureByProject(int? performanceMeasureID)
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.SpendingByPerformanceMeasureByProject);
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var selectedPerformanceMeasure = performanceMeasureID.HasValue
                ? performanceMeasures.Single(x => x.PerformanceMeasureID == performanceMeasureID)
                : performanceMeasures.First();
            var accomplishmentsChartViewData =
                new PerformanceMeasureChartViewData(selectedPerformanceMeasure, null, CurrentPerson, false);

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
                GetSpendingByPerformanceMeasureByProjectAndGridSpec(out var gridSpec, performanceMeasure);
            var gridJsonNetJObjectResult =
                new GridJsonNetJObjectResult<PerformanceMeasureSubcategoriesTotalReportedValue>(
                    performanceMeasureSubcategoriesTotalReportedValues, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureSubcategoriesTotalReportedValue>
            GetSpendingByPerformanceMeasureByProjectAndGridSpec(
                out SpendingByPerformanceMeasureByProjectGridSpec gridSpec,
                PerformanceMeasure performanceMeasure)
        {
            gridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(performanceMeasure);
            return performanceMeasure.SubcategoriesTotalReportedValues();
        }
    }
}
