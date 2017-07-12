/*-----------------------------------------------------------------------
<copyright file="ResultsController.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ResultsController : FirmaBaseController
    {
        [InvestmentByFundingSourceViewFeature]
        public ViewResult InvestmentByFundingSector(int? calendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByFundingSector(null, null);
            var fundingSectorExpenditures = GetFundingSectorExpendituresForInvestmentByFundingSectorReport(calendarYear, projectFundingSourceExpenditures);
            var calendarYears = GetCalendarYearsDropdownForInvestmentByFundingSectorAndSpendingBySectorAndTaxonomyTierThreeReports(projectFundingSourceExpenditures);
            var reportingYearRangeTitle = YearDisplayName(calendarYear);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.InvestmentByFundingSector);
            var viewData = new InvestmentByFundingSectorViewData(CurrentPerson, firmaPage, fundingSectorExpenditures, calendarYear, calendarYears, reportingYearRangeTitle);
            var viewModel = new InvestmentByFundingSectorViewModel(calendarYear);
            return RazorView<InvestmentByFundingSector, InvestmentByFundingSectorViewData, InvestmentByFundingSectorViewModel>(viewData, viewModel);
        }

        private static string YearDisplayName(int? year)
        {
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            if (!year.HasValue)
            {
                return String.Format("Recent Years ({0} - {1})", FirmaDateUtilities.GetMinimumYearForReportingExpenditures(), currentYearToUseForReporting);
            }
            if (year.Value == FirmaDateUtilities.MinimumYear)
            {
                return String.Format("All Years ({0} - {1})", FirmaDateUtilities.MinimumYear, currentYearToUseForReporting);
            }
            return year.Value.ToString(CultureInfo.InvariantCulture);
        }

        private static IEnumerable<SelectListItem> GetCalendarYearsDropdownForInvestmentByFundingSectorAndSpendingBySectorAndTaxonomyTierThreeReports(
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var allYearsWithValues = projectFundingSourceExpenditures.Select(x => x.CalendarYear).Distinct().ToList();
            var calendarYears =
                allYearsWithValues.OrderByDescending(x => x).ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture), x => YearDisplayName(x), YearDisplayName(null)).ToList();
            return calendarYears;
        }

        private static List<FundingSectorExpenditure> GetFundingSectorExpendituresForInvestmentByFundingSectorReport(int? calendarYear,
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            List<FundingSectorExpenditure> fundingSectorExpenditures;
            if (!calendarYear.HasValue)
            {
                fundingSectorExpenditures = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().Select(organizationType => new FundingSectorExpenditure(organizationType, projectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationType == organizationType).ToList(), null))
                        .ToList();
            }
            else
            {
                if (calendarYear.Value == FirmaDateUtilities.MinimumYear)
                {
                    fundingSectorExpenditures = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().Select(organizationType =>
                    {
                        var fundingSourceExpendituresForThisSector = projectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationType == organizationType).ToList();
                        return new FundingSectorExpenditure(organizationType,
                            fundingSourceExpendituresForThisSector.Sum(y => y.ExpenditureAmount),
                            fundingSourceExpendituresForThisSector.Select(y => y.FundingSourceID).Distinct().Count(),
                            fundingSourceExpendituresForThisSector.Select(y => y.FundingSource.OrganizationID).Distinct().Count(),
                            null);
                    }).ToList();
                }
                else
                {
                    fundingSectorExpenditures =
                        HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().Select(
                            organizationType =>
                                new FundingSectorExpenditure(organizationType,
                                    projectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationType == organizationType && y.CalendarYear == calendarYear.Value).ToList(),
                                    calendarYear)).ToList();
                }
            }
            return fundingSectorExpenditures;
        }

        [InvestmentByFundingSourceViewFeature]
        public PartialViewResult ProjectFundingSourceExpendituresBySector(int? organizationTypeID, int? calendarYear)
        {
            var viewData = new ProjectFundingSourceExpendituresBySectorViewData(organizationTypeID, calendarYear);
            return RazorPartialView<ProjectFundingSourceExpendituresBySector, ProjectFundingSourceExpendituresBySectorViewData>(viewData);
        }

        [InvestmentByFundingSourceViewFeature]
        public GridJsonNetJObjectResult<ProjectFundingSourceSectorExpenditure> ProjectExpendituresByFundingSectorGridJsonData(int? organizationTypeID, int? calendarYear)
        {
            ProjectFundingSourceExpendituresBySectorGridSpec gridSpec;
            var projectFundingSourceSectorExpenditures = GetProjectExpendituresByFundingSectorAndGridSpec(out gridSpec, organizationTypeID, calendarYear);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectFundingSourceSectorExpenditure>(projectFundingSourceSectorExpenditures, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProjectFundingSourceSectorExpenditure> GetProjectExpendituresByFundingSectorAndGridSpec(out ProjectFundingSourceExpendituresBySectorGridSpec gridSpec,
            int? organizationTypeID,
            int? calendarYear)
        {
            gridSpec = new ProjectFundingSourceExpendituresBySectorGridSpec(calendarYear);
            var projectFundingSourceExpenditures = GetProjectExpendituresByFundingSector(organizationTypeID, calendarYear);
            var projectFundingSourceSectorExpenditures = ProjectFundingSourceSectorExpenditure.MakeFromProjectFundingSourceExpenditures(projectFundingSourceExpenditures);
            return projectFundingSourceSectorExpenditures;
        }

        private static List<ProjectFundingSourceExpenditure> GetProjectExpendituresByFundingSector(int? organizationTypeID, int? calendarYear)
        {
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var organizationType = organizationTypeID.HasValue ? HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetOrganizationType(organizationTypeID.Value) : null;
            return HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward()
                    .Where(x => (!calendarYear.HasValue && x.CalendarYear <= currentYearToUseForReporting) || x.CalendarYear == calendarYear)
                    .ToList()
                    .Where(x => !organizationTypeID.HasValue ||
                                (x.FundingSource.Organization.OrganizationType == organizationType))
                                .OrderBy(x => x.Project.DisplayName)
                                .ToList();
        }

        [SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewFeature]
        public ViewResult SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwo(int? calendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByFundingSector(null, null);
            var taxonomyTierTwoSectorExpenditures = GetTaxonomyTierTwoSectorExpenditures(calendarYear, projectFundingSourceExpenditures);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.SpendingBySectorByTaxonomyTier);
            var calendarYears = GetCalendarYearsDropdownForInvestmentByFundingSectorAndSpendingBySectorAndTaxonomyTierThreeReports(projectFundingSourceExpenditures);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();
            var viewData = new SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData(CurrentPerson, firmaPage, taxonomyTierTwoSectorExpenditures, organizationTypes, calendarYear, calendarYears);
            var viewModel = new SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewModel(calendarYear);
            return RazorView<SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwo, SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewData, SpendingBySectorByTaxonomyTierThreeByTaxonomyTierTwoViewModel>(viewData, viewModel);
        }

        private static List<TaxonomyTierTwoSectorExpenditure> GetTaxonomyTierTwoSectorExpenditures(int? calendarYear, IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            List<TaxonomyTierTwoSectorExpenditure> taxonomyTierTwoSectorExpenditures;
            if (!calendarYear.HasValue)
            {
                taxonomyTierTwoSectorExpenditures =
                    projectFundingSourceExpenditures.GroupBy(y => new {y.Project.TaxonomyTierOne.TaxonomyTierTwo, y.FundingSource.Organization.OrganizationType})
                        .Select(x => new TaxonomyTierTwoSectorExpenditure(x.Key.OrganizationType, x.Key.TaxonomyTierTwo, x.Sum(y => y.ExpenditureAmount)))
                        .ToList();
            }
            else
            {
                taxonomyTierTwoSectorExpenditures =
                    projectFundingSourceExpenditures.Where(x => x.CalendarYear == calendarYear.Value)
                        .GroupBy(y => new {y.Project.TaxonomyTierOne.TaxonomyTierTwo, y.FundingSource.Organization.OrganizationType})
                        .Select(x => new TaxonomyTierTwoSectorExpenditure(x.Key.OrganizationType, x.Key.TaxonomyTierTwo, x.Sum(y => y.ExpenditureAmount)))
                        .ToList();

            }
            return taxonomyTierTwoSectorExpenditures;
        }

        [ProjectLocationsViewFeature]
        public ViewResult ProjectMap()
        {
            List<int> filterValues;
            ProjectLocationFilterType projectLocationFilterType;
            ProjectColorByType colorByValue;

            if (!String.IsNullOrEmpty(Request.QueryString[ProjectMapCustomization.FilterByQueryStringParameter]))
            {
                projectLocationFilterType = ProjectLocationFilterType.ToType(Request.QueryString[ProjectMapCustomization.FilterByQueryStringParameter].ParseAsEnum<ProjectLocationFilterTypeEnum>());
            }
            else
            {
                projectLocationFilterType = ProjectMapCustomization.DefaultLocationFilterType;
            }

            if (!String.IsNullOrEmpty(Request.QueryString[ProjectMapCustomization.FilterValuesQueryStringParameter]))
            {
                var filterValuesAsString = Request.QueryString[ProjectMapCustomization.FilterValuesQueryStringParameter].Split(',');
                filterValues = filterValuesAsString.Select(Int32.Parse).ToList();
            }
            else
            {
                filterValues = ProjectMapCustomization.DefaultLocationFilterValues;
            }

            if (!String.IsNullOrEmpty(Request.QueryString[ProjectMapCustomization.ColorByQueryStringParameter]))
            {
                colorByValue = ProjectColorByType.ToType(Request.QueryString[ProjectMapCustomization.ColorByQueryStringParameter].ParseAsEnum<ProjectColorByTypeEnum>());
            }
            else
            {
                colorByValue = ProjectMapCustomization.DefaultColorByType;
            }

            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ProjectMap);

            var allProjects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            var projects = allProjects.Where(p => p.IsVisibleToThisPerson(CurrentPerson)).ToList();

            var initialCustomization = new ProjectMapCustomization(projectLocationFilterType, filterValues, colorByValue);
            var projectLocationsLayerGeoJson = new LayerGeoJson("Project Locations", Project.MappedPointsToGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Show);
            var namedAreasAsPointsLayerGeoJson = new LayerGeoJson("Named Areas", Project.NamedAreasToPointGeoJsonFeatureCollection(projects, true), "red", 1, LayerInitialVisibility.Hide);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, namedAreasAsPointsLayerGeoJson, initialCustomization, "ProjectLocationsMap");

            var projectStages = (ProjectStage.All.Where(x => x.ShouldShowOnMap())).OrderBy(x => x.SortOrder).ToList();
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList();
            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, colorByValue.DisplayName, HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList());

            var projectLocationFilterTypesAndValues = CreateProjectLocationFilterTypesAndValuesDictionary(taxonomyTierThrees, projects, projectStages);
            var projectLocationsUrl = SitkaRoute<ResultsController>.BuildAbsoluteUrlHttpsFromExpression(x => x.ProjectMap());
            var filteredProjectsWithLocationAreasUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.FilteredProjectsWithLocationAreas(null));

            var viewData = new ProjectMapViewData(CurrentPerson,
                firmaPage,
                projectLocationsMapInitJson,
                projectLocationsMapViewData,
                projectLocationFilterTypesAndValues,
                projectLocationsUrl, filteredProjectsWithLocationAreasUrl);
            return RazorView<ProjectMap, ProjectMapViewData>(viewData);
        }

        private static Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> CreateProjectLocationFilterTypesAndValuesDictionary(List<TaxonomyTierThree> taxonomyTierThrees,
            List<Project> projects,
            List<ProjectStage> projectStages)
        {
            var projectLocationFilterTypesAndValues = new Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>>();

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                var taxonomyTierThreesAsSelectListItems = taxonomyTierThrees.ToSelectList(x => x.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
                projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.TaxonomyTierThree, taxonomyTierThreesAsSelectListItems);    
            }

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() >= 2)
            {
                var taxonomyTierTwosAsSelectListItems = HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.ToSelectList(x => x.TaxonomyTierTwoID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
                projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.TaxonomyTierTwo, taxonomyTierTwosAsSelectListItems);    
            }           

            var taxonomyTierOnesAsSelectListItems = HttpRequestStorage.DatabaseEntities.TaxonomyTierOnes.ToSelectList(x => x.TaxonomyTierOneID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.TaxonomyTierOne, taxonomyTierOnesAsSelectListItems);

            var classificationsAsSelectListItems = HttpRequestStorage.DatabaseEntities.Classifications.ToSelectList(x => x.ClassificationID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.Classification, classificationsAsSelectListItems);

            var implementingOrganizationsAsSelectListItems =
                projects.SelectMany(x => x.ProjectImplementingOrganizations)
                    .Select(x => x.Organization)
                    .Distinct(new HavePrimaryKeyComparer<Organization>())
                    .OrderBy(x => x.DisplayName)
                    .ToSelectList(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.ImplementingOrganization, implementingOrganizationsAsSelectListItems);

            var fundingOrganizationsAsSelectListItems =
                projects.SelectMany(x => x.ProjectFundingOrganizations)
                    .Select(x => x.Organization)
                    .Distinct(new HavePrimaryKeyComparer<Organization>())
                    .OrderBy(x => x.DisplayName)
                    .ToSelectList(x => x.OrganizationID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
            projectLocationFilterTypesAndValues.Add(ProjectLocationFilterType.FundingOrganization, fundingOrganizationsAsSelectListItems);

            var projectStagesAsSelectListItems = projectStages.ToSelectList(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), x => x.ProjectStageDisplayName);
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
            if (projectMapCustomization.FilterPropertyValues == null || !projectMapCustomization.FilterPropertyValues.Any())
            {
                return new JsonNetJArrayResult(new List<object>());
            }
            var projectLocationGroupsAsFancyTreeNodes = HttpRequestStorage.DatabaseEntities.ProjectLocationAreaGroups.ToList().Select(x => x.ToFancyTreeNode()).ToList();

            var projectLocationFilterTypeFromFilterPropertyName = projectMapCustomization.GetProjectLocationFilterTypeFromFilterPropertyName();
            var filterFunction = projectLocationFilterTypeFromFilterPropertyName.GetFilterFunction(projectMapCustomization.FilterPropertyValues);
            var filteredProjects =
                HttpRequestStorage.DatabaseEntities.Projects.Where(filterFunction.Compile()).ToList();

            var projects = IsCurrentUserAnonymous() ? filteredProjects.Where(p => p.IsVisibleToEveryone()).ToList() : filteredProjects;
            var filteredProjectsWithLocationAreas = projects.Where(x => !x.HasProjectLocationPoint && x.ProjectLocationAreaID.HasValue).ToList();

            projectLocationGroupsAsFancyTreeNodes.RemoveAll(
                typeNode =>
                    typeNode.Children.Count ==
                    typeNode.Children.RemoveAll(
                        areaNameNode =>
                            areaNameNode.Children.Count ==
                            areaNameNode.Children.RemoveAll(projectNode => !filteredProjectsWithLocationAreas.Select(project => project.ProjectID.ToString()).Contains(projectNode.Key))));

            return new JsonNetJArrayResult(projectLocationGroupsAsFancyTreeNodes);
        }

        [SpendingBySectorByOrganizationViewFeature]
        public PartialViewResult SpendingBySectorByOrganization(int organizationTypeID, int? calendarYear)
        {
            var viewData = GetSpendingBySectorByOrganizationViewData(organizationTypeID, calendarYear);
            return RazorPartialView<SpendingBySectorByOrganization, SpendingBySectorByOrganizationViewData>(viewData);
        }

        private static SpendingBySectorByOrganizationViewData GetSpendingBySectorByOrganizationViewData(int organizationTypeID, int? calendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByFundingSector(organizationTypeID, null);
            List<int> calendarYearRange;
            List<FundingSourceCalendarYearExpenditure> fundingSourceCalendarYearExpenditures;
            if (!calendarYear.HasValue)
            {
                calendarYearRange = FirmaDateUtilities.GetRangeOfYearsForReportingExpenditures();
                fundingSourceCalendarYearExpenditures =
                    FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures), calendarYearRange);
            }
            else
            {
                calendarYearRange = new List<int> {calendarYear.Value};
                fundingSourceCalendarYearExpenditures =
                    FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(
                        new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures.Where(x => x.CalendarYear == calendarYear.Value)),
                        calendarYearRange);
            }
            var calendarYears = calendarYearRange.ToDictionary(x => x,
                year => year.ToString(CultureInfo.InvariantCulture));
            var excelUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByOrganizationExcelDownload(organizationTypeID, calendarYear));
            var viewData = new SpendingBySectorByOrganizationViewData(fundingSourceCalendarYearExpenditures, calendarYears, excelUrl);
            return viewData;
        }

        [SpendingBySectorByOrganizationViewFeature]
        public ExcelResult SpendingBySectorByOrganizationExcelDownload(int organizationTypeID, int? calendarYear)
        {
            var organizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetOrganizationType(organizationTypeID);
            var viewData = GetSpendingBySectorByOrganizationViewData(organizationTypeID, calendarYear);

            var excelSpec = new FundingSourceCalendarYearExpenditureExcelSpec(viewData.CalendarYears);
            var wsFundingSources = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet("Funding Sources",
                excelSpec,
                viewData.FundingSourceCalendarYearExpenditures.OrderBy(x => x.OrganizationName).ThenBy(x => x.FundingSourceName).ToList());
            var workSheets = new List<IExcelWorkbookSheetDescriptor> {wsFundingSources};

            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();
            return new ExcelResult(excelWorkbook, String.Format("Funding Source Spending for {0}", organizationType.OrganizationTypeName));
        }

        [ResultsByTaxonomyTierTwoViewFeature]
        public ViewResult ResultsByTaxonomyTierTwo(int? taxonomyTierTwoID)
        {
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.OrderBy(x => x.TaxonomyTierThreeName).ToList();
            var selectedTaxonomyTierTwo = taxonomyTierTwoID.HasValue ? HttpRequestStorage.DatabaseEntities.TaxonomyTierTwos.GetTaxonomyTierTwo(taxonomyTierTwoID.Value) : taxonomyTierThrees.First().TaxonomyTierTwos.First();
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ResultsByTaxonomyTierTwo);
            var viewData = new ResultsByTaxonomyTierTwoViewData(CurrentPerson, firmaPage, taxonomyTierThrees, selectedTaxonomyTierTwo);
            return RazorView<ResultsByTaxonomyTierTwo, ResultsByTaxonomyTierTwoViewData>(viewData);
        }

        [SpendingByPerformanceMeasureByProjectViewFeature]
        public ViewResult SpendingByPerformanceMeasureByProject(int? performanceMeasureID)
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.SpendingByPerformanceMeasureByProject);
            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            var selectedPerformanceMeasure = performanceMeasureID.HasValue ? performanceMeasures.Single(x => x.PerformanceMeasureID == performanceMeasureID) : performanceMeasures.First();
            var accomplishmentsChartViewData = new PerformanceMeasureChartViewData(selectedPerformanceMeasure, false, ChartViewMode.Small, null);

            var viewData = new SpendingByPerformanceMeasureByProjectViewData(CurrentPerson, firmaPage, performanceMeasures, selectedPerformanceMeasure, accomplishmentsChartViewData);
            var viewModel = new SpendingByPerformanceMeasureByProjectViewModel();
            return RazorView<SpendingByPerformanceMeasureByProject, SpendingByPerformanceMeasureByProjectViewData, SpendingByPerformanceMeasureByProjectViewModel>(viewData, viewModel);
        }

        [SpendingByPerformanceMeasureByProjectViewFeature]
        public GridJsonNetJObjectResult<PerformanceMeasureSubcategoriesTotalReportedValue> SpendingByPerformanceMeasureByProjectGridJsonData(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            SpendingByPerformanceMeasureByProjectGridSpec gridSpec;
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var performanceMeasureSubcategoriesTotalReportedValues = GetSpendingByPerformanceMeasureByProjectAndGridSpec(out gridSpec, performanceMeasure);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PerformanceMeasureSubcategoriesTotalReportedValue>(performanceMeasureSubcategoriesTotalReportedValues, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<PerformanceMeasureSubcategoriesTotalReportedValue> GetSpendingByPerformanceMeasureByProjectAndGridSpec(out SpendingByPerformanceMeasureByProjectGridSpec gridSpec,
            PerformanceMeasure performanceMeasure)
        {
            gridSpec = new SpendingByPerformanceMeasureByProjectGridSpec(performanceMeasure);
            return performanceMeasure.SubcategoriesTotalReportedValues();
        }



        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public PartialViewResult InvestmentByFundingSectorGoogleChartPopup(int? selectedCalendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByFundingSector(null, null);
            var fundingSectorExpenditures = GetFundingSectorExpendituresForInvestmentByFundingSectorReport(selectedCalendarYear, projectFundingSourceExpenditures);

            var googleChart = GetInvestmentByFundingSectorGoogleChart(fundingSectorExpenditures, selectedCalendarYear);
            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }

        public static GoogleChartJson GetInvestmentByFundingSectorGoogleChart(List<FundingSectorExpenditure> fundingSectorExpenditures, int? selectedCalendarYear)
        {
            const int chartSize = 350;
            var chartName = string.Format("InvestmentByFundingSector{0}PieChart", selectedCalendarYear);

            var googleChartDataTable = GetInvestmentByFundingSectorGoogleChartDataTable(fundingSectorExpenditures);
            var googleChartTitle = "Investment by Funding Sector for: " + YearDisplayName(selectedCalendarYear);
            var googleChartConfiguration = new GooglePieChartConfiguration(googleChartTitle, MeasurementUnitType.Dollars, chartSize, chartSize) {Background = {Color = "transparent"}};

            var enumerable = fundingSectorExpenditures.Select(x => x.LegendColor).Select((value, index) => new {value, index});
            var googlePieChartSlices = enumerable.ToDictionary(x => x.index, x => new GooglePieChartSlice(){Color = x.value});
            googleChartConfiguration.Slices = googlePieChartSlices;
            
            var chartPopupUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.InvestmentByFundingSectorGoogleChartPopup(selectedCalendarYear));
            var googleChart = new GoogleChartJson(string.Empty,
                chartName,
                googleChartConfiguration,
                GoogleChartType.PieChart,
                googleChartDataTable,
                chartPopupUrl,
                string.Empty,
                string.Empty);
            return googleChart;
        }

        public static GoogleChartDataTable GetInvestmentByFundingSectorGoogleChartDataTable(List<FundingSectorExpenditure> fundingSectorExpenditures)
        {
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Funding Sector", GoogleChartColumnDataType.String, GoogleChartType.PieChart), new GoogleChartColumn("Expenditures", GoogleChartColumnDataType.Number, GoogleChartType.PieChart) };

            var googleChartRowCs = fundingSectorExpenditures.Select(x =>
            {
                var sectorRowV = new GoogleChartRowV(x.OrganizationTypeName);
                var formattedValue = GoogleChartJson.GetFormattedValue((double) x.CalendarYearExpenditureAmount, MeasurementUnitType.Dollars);
                var expenditureRowV = new GoogleChartRowV(x.CalendarYearExpenditureAmount, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> {sectorRowV, expenditureRowV});
            }).ToList();

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }
    }
}
