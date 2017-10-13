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
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ResultsController : FirmaBaseController
    {
        [InvestmentByFundingSourceViewFeature]
        public ViewResult InvestmentByOrganizationType(int? calendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(null, null);
            var fundingOrganizationTypeExpenditures = GetOrganizationTypeExpendituresForInvestmentByOrganizationTypeReport(calendarYear, projectFundingSourceExpenditures);
            var calendarYears = GetCalendarYearsDropdownForInvestmentByOrganizationTypeAndSpendingByOrganizationTypeAndTaxonomyTierThreeReports(projectFundingSourceExpenditures);
            var reportingYearRangeTitle = YearDisplayName(calendarYear);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.InvestmentByOrganizationType);
            var viewData = new InvestmentByOrganizationTypeViewData(CurrentPerson, firmaPage, fundingOrganizationTypeExpenditures, calendarYear, calendarYears, reportingYearRangeTitle);
            var viewModel = new InvestmentByOrganizationTypeViewModel(calendarYear);
            return RazorView<InvestmentByOrganizationType, InvestmentByOrganizationTypeViewData, InvestmentByOrganizationTypeViewModel>(viewData, viewModel);
        }

        private static string YearDisplayName(int? year)
        {
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            if (!year.HasValue)
            {
                return
                    $"Recent Years ({FirmaDateUtilities.GetMinimumYearForReportingExpenditures()} - {currentYearToUseForReporting})";
            }
            if (year.Value == FirmaDateUtilities.MinimumYear)
            {
                return $"All Years ({FirmaDateUtilities.MinimumYear} - {currentYearToUseForReporting})";
            }
            return year.Value.ToString(CultureInfo.InvariantCulture);
        }

        private static IEnumerable<SelectListItem> GetCalendarYearsDropdownForInvestmentByOrganizationTypeAndSpendingByOrganizationTypeAndTaxonomyTierThreeReports(
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var allYearsWithValues = projectFundingSourceExpenditures.Select(x => x.CalendarYear).Distinct().ToList();
            var calendarYears =
                allYearsWithValues.OrderByDescending(x => x).ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture), x => YearDisplayName(x), YearDisplayName(null)).ToList();
            return calendarYears;
        }

        private static List<OrganizationTypeExpenditure> GetOrganizationTypeExpendituresForInvestmentByOrganizationTypeReport(int? calendarYear,
            IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            List<OrganizationTypeExpenditure> fundingOrganizationTypeExpenditures;
            if (!calendarYear.HasValue)
            {
                fundingOrganizationTypeExpenditures = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().Select(organizationType => new OrganizationTypeExpenditure(organizationType, projectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationTypeID == organizationType.OrganizationTypeID).ToList(), null))
                        .ToList();
            }
            else
            {
                if (calendarYear.Value == FirmaDateUtilities.MinimumYear)
                {
                    fundingOrganizationTypeExpenditures = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().Select(organizationType =>
                    {
                        var fundingSourceExpendituresForThisOrganizationType = projectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationTypeID == organizationType.OrganizationTypeID).ToList();
                        return new OrganizationTypeExpenditure(organizationType,
                            fundingSourceExpendituresForThisOrganizationType.Sum(y => y.ExpenditureAmount),
                            fundingSourceExpendituresForThisOrganizationType.Select(y => y.FundingSourceID).Distinct().Count(),
                            fundingSourceExpendituresForThisOrganizationType.Select(y => y.FundingSource.OrganizationID).Distinct().Count(),
                            null);
                    }).ToList();
                }
                else
                {
                    fundingOrganizationTypeExpenditures =
                        HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList().Select(
                            organizationType =>
                                new OrganizationTypeExpenditure(organizationType,
                                    projectFundingSourceExpenditures.Where(y => y.FundingSource.Organization.OrganizationTypeID == organizationType.OrganizationTypeID && y.CalendarYear == calendarYear.Value).ToList(),
                                    calendarYear)).ToList();
                }
            }
            return fundingOrganizationTypeExpenditures;
        }

        [InvestmentByFundingSourceViewFeature]
        public PartialViewResult ProjectFundingSourceExpendituresByOrganizationType(int? organizationTypeID, int? calendarYear)
        {
            var viewData = new ProjectFundingSourceExpendituresByOrganizationTypeViewData(organizationTypeID, calendarYear);
            return RazorPartialView<ProjectFundingSourceExpendituresByOrganizationType, ProjectFundingSourceExpendituresByOrganizationTypeViewData>(viewData);
        }

        [InvestmentByFundingSourceViewFeature]
        public GridJsonNetJObjectResult<ProjectFundingSourceOrganizationTypeExpenditure> ProjectExpendituresByOrganizationTypeGridJsonData(int? organizationTypeID, int? calendarYear)
        {
            ProjectFundingSourceExpendituresByOrganizationTypeGridSpec gridSpec;
            var projectFundingSourceOrganizationTypeExpenditures = GetProjectExpendituresByOrganizationTypeAndGridSpec(out gridSpec, organizationTypeID, calendarYear);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectFundingSourceOrganizationTypeExpenditure>(projectFundingSourceOrganizationTypeExpenditures, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<ProjectFundingSourceOrganizationTypeExpenditure> GetProjectExpendituresByOrganizationTypeAndGridSpec(out ProjectFundingSourceExpendituresByOrganizationTypeGridSpec gridSpec,
            int? organizationTypeID,
            int? calendarYear)
        {
            gridSpec = new ProjectFundingSourceExpendituresByOrganizationTypeGridSpec(calendarYear);
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(organizationTypeID, calendarYear);
            var projectFundingSourceOrganizationTypeExpenditures = ProjectFundingSourceOrganizationTypeExpenditure.MakeFromProjectFundingSourceExpenditures(projectFundingSourceExpenditures);
            return projectFundingSourceOrganizationTypeExpenditures;
        }

        private static List<ProjectFundingSourceExpenditure> GetProjectExpendituresByOrganizationType(int? organizationTypeID, int? calendarYear)
        {
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            OrganizationType organizationType;
            if (organizationTypeID.HasValue)
            {
                organizationType =
                    HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetOrganizationType(organizationTypeID.Value);
                return HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures.GetExpendituresFromMininumYearForReportingOnward()
                    .Where(x => (!calendarYear.HasValue && x.CalendarYear <= currentYearToUseForReporting) || x.CalendarYear == calendarYear)
                    .ToList()
                    .Where(x => x.FundingSource.Organization.OrganizationTypeID.HasValue && x.FundingSource.Organization.OrganizationTypeID == organizationType.OrganizationTypeID)
                    .OrderBy(x => x.Project.DisplayName)
                    .ToList();
            }

            return HttpRequestStorage.DatabaseEntities.ProjectFundingSourceExpenditures
                .GetExpendituresFromMininumYearForReportingOnward()
                .Where(x => (!calendarYear.HasValue && x.CalendarYear <= currentYearToUseForReporting) ||
                            x.CalendarYear == calendarYear)
                .OrderBy(x => x.Project.ProjectName)
                .ToList();
        }

        [SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewFeature]
        public ViewResult SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwo(int? calendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(null, null);
            var taxonomyTierTwoOrganizationTypeExpenditures = GetTaxonomyTierTwoOrganizationTypeExpenditures(calendarYear, projectFundingSourceExpenditures);
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.SpendingByOrganizationTypeByTaxonomyTier);
            var calendarYears = GetCalendarYearsDropdownForInvestmentByOrganizationTypeAndSpendingByOrganizationTypeAndTaxonomyTierThreeReports(projectFundingSourceExpenditures);
            var organizationTypes = HttpRequestStorage.DatabaseEntities.OrganizationTypes.ToList();
            var viewData = new SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewData(CurrentPerson, firmaPage, taxonomyTierTwoOrganizationTypeExpenditures, organizationTypes, calendarYear, calendarYears);
            var viewModel = new SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewModel(calendarYear);
            return RazorView<SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwo, SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewData, SpendingByOrganizationTypeByTaxonomyTierThreeByTaxonomyTierTwoViewModel>(viewData, viewModel);
        }

        private static List<TaxonomyTierTwoOrganizationTypeExpenditure> GetTaxonomyTierTwoOrganizationTypeExpenditures(int? calendarYear, IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            List<TaxonomyTierTwoOrganizationTypeExpenditure> taxonomyTierTwoOrganizationTypeExpenditures;
            if (!calendarYear.HasValue)
            {
                taxonomyTierTwoOrganizationTypeExpenditures =
                    projectFundingSourceExpenditures.GroupBy(y => new {y.Project.TaxonomyTierOne.TaxonomyTierTwo, y.FundingSource.Organization.OrganizationType})
                        .Select(x => new TaxonomyTierTwoOrganizationTypeExpenditure(x.Key.OrganizationType, x.Key.TaxonomyTierTwo, x.Sum(y => y.ExpenditureAmount)))
                        .ToList();
            }
            else
            {
                taxonomyTierTwoOrganizationTypeExpenditures =
                    projectFundingSourceExpenditures.Where(x => x.CalendarYear == calendarYear.Value)
                        .GroupBy(y => new {y.Project.TaxonomyTierOne.TaxonomyTierTwo, y.FundingSource.Organization.OrganizationType})
                        .Select(x => new TaxonomyTierTwoOrganizationTypeExpenditure(x.Key.OrganizationType, x.Key.TaxonomyTierTwo, x.Sum(y => y.ExpenditureAmount)))
                        .ToList();

            }
            return taxonomyTierTwoOrganizationTypeExpenditures;
        }

        [ProjectLocationsViewFeature]
        public ViewResult ProjectMap()
        {
            List<int> filterValues;
            ProjectLocationFilterType projectLocationFilterType;
            ProjectColorByType colorByValue;

            var includeProposedProjectsOnMap = CurrentTenant.GetTenantAttribute().IncludeProposedProjectsOnMap;

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
                filterValues = ProjectMapCustomization.GetDefaultLocationFilterValues();
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

            var allProjectsForMap = new List<IProject>(HttpRequestStorage.DatabaseEntities.Projects);
            if (includeProposedProjectsOnMap)
            {
                allProjectsForMap.AddRange(new List<IProject>(HttpRequestStorage.DatabaseEntities.ProposedProjects));
            }
            var projectsToShow = allProjectsForMap.Where(p => p.IsVisibleToThisPerson(CurrentPerson)).OrderBy(x => x.ProjectStage.ProjectStageID).ToList();

            var initialCustomization = new ProjectMapCustomization(projectLocationFilterType, filterValues, colorByValue);
            var projectLocationsLayerGeoJson = new LayerGeoJson($"{FieldDefinition.ProjectLocation.GetFieldDefinitionLabel()}", Project.MappedPointsToGeoJsonFeatureCollection(projectsToShow, true), "red", 1, LayerInitialVisibility.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, initialCustomization, "ProjectLocationsMap")
            {
                Layers = HttpRequestStorage.DatabaseEntities.Organizations.GetBoundaryLayerGeoJson()
            };

            var projectLocationsMapViewData = new ProjectLocationsMapViewData(projectLocationsMapInitJson.MapDivID, colorByValue.DisplayName, MultiTenantHelpers.GetTopLevelTaxonomyTiers());

            
            var projectLocationFilterTypesAndValues = CreateProjectLocationFilterTypesAndValuesDictionary(includeProposedProjectsOnMap);
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

        private static Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> CreateProjectLocationFilterTypesAndValuesDictionary(bool includeProposedProjectsOnMap)
        {
            var projectLocationFilterTypesAndValues = new Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>>();

            if (MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3)
            {
                var taxonomyTierThreesAsSelectListItems = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToSelectList(x => x.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture), x => x.DisplayName);
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

            var projectStagesAsSelectListItems = ProjectMapCustomization.GetProjectStagesForMap().ToSelectList(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), x => x.ProjectStageDisplayName);
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
            var filteredProjects = HttpRequestStorage.DatabaseEntities.Projects.Where(filterFunction.Compile())
                .ToList();

            var projects = IsCurrentUserAnonymous()
                ? filteredProjects.Where(p => p.IsVisibleToEveryone()).ToList()
                : filteredProjects;
            var filteredProjectsWithLocationAreas = projects
                .Where(x => !x.HasProjectLocationPoint && x.ProjectWatersheds.Any())
                .ToList();

            projectLocationGroupsAsFancyTreeNodes.RemoveAll(                
                        areaNameNode =>
                            areaNameNode.Children.Count ==
                            areaNameNode.Children.RemoveAll(projectNode => !filteredProjectsWithLocationAreas
                                .Select(project => project.ProjectID.ToString())
                                .Contains(projectNode.Key)));

            return new JsonNetJArrayResult(projectLocationGroupsAsFancyTreeNodes);
        }


        [SpendingByOrganizationTypeByOrganizationViewFeature]
        public PartialViewResult SpendingByOrganizationTypeByOrganization(int organizationTypeID, int? calendarYear)
        {
            var viewData = GetSpendingByOrganizationTypeByOrganizationViewData(organizationTypeID, calendarYear);
            return RazorPartialView<SpendingByOrganizationTypeByOrganization, SpendingByOrganizationTypeByOrganizationViewData>(viewData);
        }

        private static SpendingByOrganizationTypeByOrganizationViewData GetSpendingByOrganizationTypeByOrganizationViewData(int organizationTypeID, int? calendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(organizationTypeID, null);
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
            var excelUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingByOrganizationTypeByOrganizationExcelDownload(organizationTypeID, calendarYear));
            var viewData = new SpendingByOrganizationTypeByOrganizationViewData(fundingSourceCalendarYearExpenditures, calendarYears, excelUrl);
            return viewData;
        }

        [SpendingByOrganizationTypeByOrganizationViewFeature]
        public ExcelResult SpendingByOrganizationTypeByOrganizationExcelDownload(int organizationTypeID, int? calendarYear)
        {
            var organizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetOrganizationType(organizationTypeID);
            var viewData = GetSpendingByOrganizationTypeByOrganizationViewData(organizationTypeID, calendarYear);

            var excelSpec = new FundingSourceCalendarYearExpenditureExcelSpec(viewData.CalendarYears);
            var wsFundingSources = ExcelWorkbookSheetDescriptorFactory.MakeWorksheet($"{FieldDefinition.FundingSource.GetFieldDefinitionLabelPluralized()}",
                excelSpec,
                viewData.FundingSourceCalendarYearExpenditures.OrderBy(x => x.OrganizationName).ThenBy(x => x.FundingSourceName).ToList());
            var workSheets = new List<IExcelWorkbookSheetDescriptor> {wsFundingSources};

            var wbm = new ExcelWorkbookMaker(workSheets);
            var excelWorkbook = wbm.ToXLWorkbook();
            return new ExcelResult(excelWorkbook,
                $"{FieldDefinition.FundingSource.GetFieldDefinitionLabel()} Spending for {organizationType.OrganizationTypeName}");
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
        public PartialViewResult InvestmentByOrganizationTypeGoogleChartPopup(int? selectedCalendarYear)
        {
            var projectFundingSourceExpenditures = GetProjectExpendituresByOrganizationType(null, null);
            var fundingOrganizationTypeExpenditures = GetOrganizationTypeExpendituresForInvestmentByOrganizationTypeReport(selectedCalendarYear, projectFundingSourceExpenditures);

            var googleChart = GetInvestmentByOrganizationTypeGoogleChart(fundingOrganizationTypeExpenditures, selectedCalendarYear);
            var viewData = new GoogleChartPopupViewData(googleChart);
            return RazorPartialView<GoogleChartPopup, GoogleChartPopupViewData>(viewData);
        }

        public static GoogleChartJson GetInvestmentByOrganizationTypeGoogleChart(List<OrganizationTypeExpenditure> fundingOrganizationTypeExpenditures, int? selectedCalendarYear)
        {
            const int chartSize = 350;
            var chartName = $"InvestmentByOrganizationType{selectedCalendarYear}PieChart";

            var googleChartDataTable = GetInvestmentByOrganizationTypeGoogleChartDataTable(fundingOrganizationTypeExpenditures);
            var googleChartTitle = "Investment by Funding OrganizationType for: " + YearDisplayName(selectedCalendarYear);
            var googleChartConfiguration = new GooglePieChartConfiguration(googleChartTitle, MeasurementUnitType.Dollars, chartSize, chartSize) {Background = {Color = "transparent"}};

            var enumerable = fundingOrganizationTypeExpenditures.Select(x => x.LegendColor).Select((value, index) => new {value, index});
            var googlePieChartSlices = enumerable.ToDictionary(x => x.index, x => new GooglePieChartSlice(){Color = x.value});
            googleChartConfiguration.Slices = googlePieChartSlices;
            
            var chartPopupUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.InvestmentByOrganizationTypeGoogleChartPopup(selectedCalendarYear));
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

        public static GoogleChartDataTable GetInvestmentByOrganizationTypeGoogleChartDataTable(List<OrganizationTypeExpenditure> fundingOrganizationTypeExpenditures)
        {
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Funding OrganizationType", GoogleChartColumnDataType.String, GoogleChartType.PieChart), new GoogleChartColumn("Expenditures", GoogleChartColumnDataType.Number, GoogleChartType.PieChart) };

            var googleChartRowCs = fundingOrganizationTypeExpenditures.Select(x =>
            {
                var organizationTypeRowV = new GoogleChartRowV(x.OrganizationTypeName);
                var formattedValue = GoogleChartJson.GetFormattedValue((double) x.CalendarYearExpenditureAmount, MeasurementUnitType.Dollars);
                var expenditureRowV = new GoogleChartRowV(x.CalendarYearExpenditureAmount, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> {organizationTypeRowV, expenditureRowV});
            }).ToList();

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }
    }
}
