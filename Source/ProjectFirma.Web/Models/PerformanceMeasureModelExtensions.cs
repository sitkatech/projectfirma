/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureModelExtensions.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this PerformanceMeasure performanceMeasure)
        {
            return UrlTemplate.MakeHrefString(performanceMeasure.GetSummaryUrl(), performanceMeasure.PerformanceMeasureDisplayName);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int, null)));
        public static string GetSummaryUrl(this PerformanceMeasure performanceMeasure)
        {
            return SummaryUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static readonly UrlTemplate<int> DetailReportingGuidanceTabUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int, Views.PerformanceMeasure.DetailViewData.PerformanceMeasureDetailTab.ReportingGuidance)));
        public static string GetDetailReportingGuidanceTabUrl(this PerformanceMeasure performanceMeasure)
        {
            return DetailReportingGuidanceTabUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static readonly UrlTemplate<int> DetailTargetsTabUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int, Views.PerformanceMeasure.DetailViewData.PerformanceMeasureDetailTab.Targets)));
        public static string GetDetailTargetsTabUrl(this PerformanceMeasure performanceMeasure)
        {
            return DetailTargetsTabUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        private static readonly UrlTemplate<int> DefinitionAndGuidanceUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.DefinitionAndGuidance(UrlTemplate.Parameter1Int)));
        public static string GetDefinitionAndGuidanceUrl(this PerformanceMeasure performanceMeasure)
        {
            return DefinitionAndGuidanceUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static string GetEditReportedValuesUrl(this PerformanceMeasure performanceMeasure)
        {
            if (performanceMeasure != null)
            {
                return null;
            }
            throw new NotImplementedException($"PerformanceMeasure {0} is not reported in the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Tracker!  No way to edit {FieldDefinitionEnum.ReportedValue.ToType().GetFieldDefinitionLabel()}!");
        }

        public static bool IsPerformanceMeasureDisplayNameUnique(IEnumerable<PerformanceMeasure> performanceMeasures, string performanceMeasureDisplayName, int currentPerformanceMeasureID)
        {
            var performanceMeasure =
                performanceMeasures.SingleOrDefault(
                    x => x.PerformanceMeasureID != currentPerformanceMeasureID && String.Equals(x.PerformanceMeasureDisplayName, performanceMeasureDisplayName, StringComparison.InvariantCultureIgnoreCase));
            return performanceMeasure == null;
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.DeletePerformanceMeasure(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this PerformanceMeasure performanceMeasure)
        {
            return DeleteUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
        }

        public static string GetJavascriptSafeChartUniqueName(this PerformanceMeasure performanceMeasure)
        {
            return $"PerformanceMeasure{performanceMeasure.PerformanceMeasureID}";
        }

        public static GoogleChartConfiguration GetDefaultPerformanceMeasureChartConfigurationJson(this PerformanceMeasure performanceMeasure)
        {
            //override to catch any config setups for performance measures with targets
            if (performanceMeasure.HasTargets())
            {
                return GetTargetsPerformanceMeasureChartConfigurationJson(performanceMeasure);
            }
            var googleChartType = GoogleChartType.ColumnChart;
            var googleChartAxisHorizontal =
                new GoogleChartAxis("Year", null, null) {Gridlines = new GoogleChartGridlinesOptions(-1, "transparent")};
            var googleChartAxisVerticals = new List<GoogleChartAxis>();
            var defaultSubcategoryChartConfigurationJson = new GoogleChartConfiguration(
                performanceMeasure.PerformanceMeasureDisplayName, true, googleChartType, googleChartAxisHorizontal,
                googleChartAxisVerticals);
            return defaultSubcategoryChartConfigurationJson;
        }

        public static GoogleChartConfiguration GetTargetsPerformanceMeasureChartConfigurationJson(this PerformanceMeasure performanceMeasure)
        {
            var googleChartType = GoogleChartType.ColumnChart;
            var googleChartAxisHorizontal =
                new GoogleChartAxis("Year", null, null) { Gridlines = new GoogleChartGridlinesOptions(-1, "transparent") };
            var googleChartAxisVerticals = new List<GoogleChartAxis>();
            var chartSeries = GoogleChartSeries.GetDefaultGoogleChartSeriesForChartsWithTargets();
            var defaultSubcategoryChartConfigurationJson = new GoogleChartConfiguration(
                performanceMeasure.PerformanceMeasureDisplayName, true, googleChartType, googleChartAxisHorizontal,
                googleChartAxisVerticals, "bars", chartSeries);
            return defaultSubcategoryChartConfigurationJson;
        }

        public static IEnumerable<PerformanceMeasure> GetReportablePerformanceMeasures()
        {
            return HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList().Where(x => !x.PerformanceMeasureDataSourceType.IsCustomCalculation);
        }

        public static IEnumerable<IGrouping<TaxonomyTier, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTiers(this PerformanceMeasure performanceMeasure)
        {
            Func<TaxonomyLeafPerformanceMeasure, TaxonomyTier> groupingFunc;
            switch (MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel().ToEnum)
            {
                case TaxonomyLevelEnum.Trunk:
                    groupingFunc = x => new TaxonomyTier(x.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk);
                    break;
                case TaxonomyLevelEnum.Branch:
                    groupingFunc = x => new TaxonomyTier(x.TaxonomyLeaf.TaxonomyBranch);
                    break;
                case TaxonomyLevelEnum.Leaf:
                    groupingFunc = x => new TaxonomyTier(x.TaxonomyLeaf);
                    break;
                default:
                    throw new ArgumentException();
            }

            var taxonomyBranchPerformanceMeasureGroupedByLevel = performanceMeasure.TaxonomyLeafPerformanceMeasures.GroupBy(groupingFunc, new HavePrimaryKeyComparer<TaxonomyTier>());
            return taxonomyBranchPerformanceMeasureGroupedByLevel;
        }

        public static List<PerformanceMeasureSubcategoriesTotalReportedValue> SubcategoriesTotalReportedValues(FirmaSession currentFirmaSession, PerformanceMeasure performanceMeasure)
        {
            var groupByProjectAndSubcategory =
                performanceMeasure.GetReportedPerformanceMeasureValues(currentFirmaSession)
                    .Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                    .GroupBy(x => new {x.Project, PerformanceMeasureSubcategoriesAsString = x.GetPerformanceMeasureSubcategoriesAsString()})
                    .ToList();

            return
                groupByProjectAndSubcategory.Select(
                    reportedValuesGroup =>
                        new PerformanceMeasureSubcategoriesTotalReportedValue(reportedValuesGroup.Key.Project,
                            reportedValuesGroup.First().GetPerformanceMeasureSubcategoryOptions(),
                            performanceMeasure,
                            reportedValuesGroup.Sum(x => x.GetReportedValue()))).ToList();
        }

        public static List<GoogleChartJson> GetGoogleChartJsonDictionary(this PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea, List<Project> projects, string chartUniqueName, bool projectsIntentionallyEmpty)
        {
            var reportedValues = performanceMeasure.GetProjectPerformanceMeasureSubcategoryOptionReportedValues(projects, projectsIntentionallyEmpty);
            return PerformanceMeasureSubcategoryModelExtensions.MakeGoogleChartJsons(performanceMeasure, geospatialArea, reportedValues);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            var projects = performanceMeasure.GetAssociatedProjectsWithReportedValues(currentFirmaSession);
            return performanceMeasure.GetReportedPerformanceMeasureValues(projects, false);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, Project project)
        {
            return performanceMeasure.GetReportedPerformanceMeasureValues(new List<Project> { project }, false);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, ProjectUpdateBatch projectUpdateBatch)
        {
            return performanceMeasure.GetReportedPerformanceMeasureValues(new List<ProjectUpdateBatch> { projectUpdateBatch });
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, List<Project> projects, bool projectsIntentionallyEmpty)
        {
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects, projectsIntentionallyEmpty);
            return performanceMeasureReportedValues;
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, List<ProjectUpdateBatch> projectUpdateBatches)
        {
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projectUpdateBatches);
            return performanceMeasureReportedValues;
        }

        public static List<PerformanceMeasureExpected> GetExpectedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            var projectIDs = performanceMeasure.GetAssociatedProjectsWithExpectedValues(currentFirmaSession).Select(x => x.ProjectID);
            return performanceMeasure.PerformanceMeasureExpecteds.Where(x => projectIDs.Contains(x.ProjectID)).ToList();
        }

        public static List<ProjectPerformanceMeasureReportingPeriodValue> GetProjectPerformanceMeasureSubcategoryOptionReportedValues(this PerformanceMeasure performanceMeasure, List<Project> projects, bool projectsIntentionallyEmpty)
        {
            var performanceMeasureValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects, projectsIntentionallyEmpty);

            var performanceMeasureActualsFiltered = projects?.Any() == true
                ? performanceMeasureValues.Where(pmav => projects.Contains(pmav.Project)).ToList()
                : performanceMeasureValues;

            var groupByProjectAndSubcategory = performanceMeasureActualsFiltered.GroupBy(pirv => new { pirv.Project, PerformanceMeasureSubcategoriesAsString = pirv.GetPerformanceMeasureSubcategoriesAsString(), pirv.PerformanceMeasureReportingPeriod }).OrderBy(x => x.Key.PerformanceMeasureSubcategoriesAsString).ToList();

            var projectPerformanceMeasureReportingPeriodValues = groupByProjectAndSubcategory.Select(reportedValuesGroup =>
            {
                var project = reportedValuesGroup.Key.Project;
                var performanceMeasureReportingPeriodSubcategoryOptionReportedValues = reportedValuesGroup.First().GetPerformanceMeasureSubcategoryOptions().OrderBy(y =>
                    y.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).Select(
                    (y, index) =>
                    {
                        if (y.PerformanceMeasureSubcategoryOption != null)
                        {
                            return new
                                PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(
                                    reportedValuesGroup.Key.PerformanceMeasureReportingPeriod, y.PerformanceMeasureSubcategoryOption,
                                    reportedValuesGroup.Sum(x => x.GetReportedValue() ?? 0));
                        }
                        else
                        {
                            return new
                                PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(
                                    reportedValuesGroup.Key.PerformanceMeasureReportingPeriod,
                                    reportedValuesGroup.Sum(x => x.GetReportedValue() ?? 0), y.PerformanceMeasureSubcategory, y.GetPerformanceMeasureSubcategoryOptionName());
                        }
                    }).ToList();

                return new ProjectPerformanceMeasureReportingPeriodValue(project, performanceMeasureReportingPeriodSubcategoryOptionReportedValues);
            }).ToList();

            return projectPerformanceMeasureReportingPeriodValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.Project.ProjectName).ToList();
        }

        public static List<Project> GetAssociatedProjectsWithReportedValues(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return performanceMeasure.PerformanceMeasureActuals.Select(ptc => ptc.Project).Distinct().ToList().GetActiveProjectsAndProposals(currentFirmaSession.CanViewProposals(), currentFirmaSession);
        }

        public static int ReportedProjectsCount(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return performanceMeasure.GetAssociatedProjectsWithReportedValues(currentFirmaSession).Count;
        }

        public static List<Project> GetAssociatedProjectsWithExpectedValues(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return performanceMeasure.PerformanceMeasureExpecteds.Select(pme => pme.Project).Distinct().ToList().GetActiveProjectsAndProposals(currentFirmaSession.CanViewProposals(), currentFirmaSession);
        }

        public static int ExpectedProjectsCount(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return performanceMeasure.GetAssociatedProjectsWithExpectedValues(currentFirmaSession).Count;
        }

        public static List<PerformanceMeasureSubcategory> GetPerformanceMeasureSubcategories(this PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.PerformanceMeasureSubcategories.Any()
                ? performanceMeasure.PerformanceMeasureSubcategories.Select(x => x).OrderBy(x => x.PerformanceMeasureSubcategoryDisplayName).ToList()
                : new List<PerformanceMeasureSubcategory>();
        }

        public static IEnumerable<PerformanceMeasureSubcategoryOption> GetPerformanceMeasureSubcategoryOptions(this PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.GetPerformanceMeasureSubcategories()
                .SelectMany(x => x.PerformanceMeasureSubcategoryOptions).OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName).ThenBy(x => x.SortOrder);
        }

        public static decimal? TotalExpenditure(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return SubcategoriesTotalReportedValues(currentFirmaSession, performanceMeasure).Sum(x => x.CalculateWeightedTotalExpenditure());
        }

        public static decimal? TotalExpenditurePerPerformanceMeasureUnit(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            var totalReportedValues = SubcategoriesTotalReportedValues(currentFirmaSession, performanceMeasure).Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue ?? 0);
            if (Math.Abs(totalReportedValues) < Double.Epsilon)
            {
                return null;
            }
            return performanceMeasure.TotalExpenditure(currentFirmaSession) / (decimal)totalReportedValues;
        }

        public static double? TotalReportedValueWithNonZeroExpenditures(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return SubcategoriesTotalReportedValues(currentFirmaSession, performanceMeasure).Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue);
        }

        /// <summary>
        /// Returns all PerformanceMeasureReportingPeriods from the PerformanceMeasureTarget and PerformanceMeasureActuals connected to this performance measure (excludes PerformanceMeasureActualUpdates and GeospatialAreaPerformanceMeasureTargets)
        /// </summary>
        /// <param name="performanceMeasure"></param>
        /// <returns></returns>
        public static List<PerformanceMeasureReportingPeriod> GetPerformanceMeasureReportingPeriodsFromTargetsAndActuals(this PerformanceMeasure performanceMeasure)
        {
            List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods = new List<PerformanceMeasureReportingPeriod>();

            performanceMeasureReportingPeriods.AddRange(performanceMeasure.GetPerformanceMeasureReportingPeriodsFromActuals());
            performanceMeasureReportingPeriods.AddRange(performanceMeasure.PerformanceMeasureReportingPeriodTargets.Select(x => x.PerformanceMeasureReportingPeriod));

            return performanceMeasureReportingPeriods.Distinct().ToList();
        }

        /// <summary>
        /// Returns all PerformanceMeasureReportingPeriods from the PerformanceMeasureTarget and PerformanceMeasureActuals connected to this performance measure (excludes PerformanceMeasureActualUpdates and GeospatialAreaPerformanceMeasureTargets)
        /// </summary>
        /// <param name="performanceMeasure"></param>
        /// <returns></returns>
        public static List<PerformanceMeasureReportingPeriod> GetPerformanceMeasureReportingPeriodsFromActuals(this PerformanceMeasure performanceMeasure)
        {
            List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods = new List<PerformanceMeasureReportingPeriod>();

            performanceMeasureReportingPeriods.AddRange(performanceMeasure.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureReportingPeriod));

            return performanceMeasureReportingPeriods.Distinct().ToList();
        }

        /// <summary>
        /// This overload includes the PerformanceMeasureReportingPeriods tied to GeospatialArea Targets
        /// </summary>
        /// <param name="performanceMeasure"></param>
        /// <returns></returns>
        public static List<PerformanceMeasureReportingPeriod> GetPerformanceMeasureReportingPeriodsFromTargetsAndActualsAndGeospatialAreaTargets(this PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods = new List<PerformanceMeasureReportingPeriod>();

            performanceMeasureReportingPeriods.AddRange(performanceMeasure.GetPerformanceMeasureReportingPeriodsFromTargetsAndActuals());
            performanceMeasureReportingPeriods.AddRange(performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).Select(x => x.PerformanceMeasureReportingPeriod));

            return performanceMeasureReportingPeriods.Distinct().ToList();
        }

        public static PerformanceMeasureTargetValueType GetTargetValueType(this PerformanceMeasure performanceMeasure)
        {
            if (performanceMeasure.PerformanceMeasureReportingPeriodTargets.Any())
            {
                return PerformanceMeasureTargetValueType.TargetPerYear;
                
            }
            if (performanceMeasure.PerformanceMeasureFixedTargets.Any())
            {
                return PerformanceMeasureTargetValueType.FixedTarget;
            }
            return PerformanceMeasureTargetValueType.NoTarget;
        }

        public static PerformanceMeasureTargetValueType GetGeospatialAreaTargetValueType(this PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            if (performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.Any(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID))
            {
                return PerformanceMeasureTargetValueType.FixedTarget;
            }

            if (performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any(x =>
                x.GeospatialAreaID == geospatialArea.GeospatialAreaID))
            {
                return PerformanceMeasureTargetValueType.TargetPerYear;
            }
            return PerformanceMeasureTargetValueType.NoTarget;
        }

        public static bool HasTargets(this PerformanceMeasure performanceMeasure)
        {
            bool hasTargets = performanceMeasure.PerformanceMeasureReportingPeriodTargets.Any() || performanceMeasure.PerformanceMeasureFixedTargets.Any();
            return hasTargets;
        }

        public static bool HasGeospatialAreaTargets(this PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            if (geospatialArea == null)
            {
                return false;
            }
            bool hasTargets = performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID) || performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.Any(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            return hasTargets;
        }

        public static List<GooglePieChartSlice> GetProgressDashboardPieChartSlices(this PerformanceMeasure performanceMeasure, List<double> progressDashboardPieChartValues)
        {
            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();

            var blues = new List<string> { "#0075A4", "#72ADCF", "#BFE8FF" };
            var teals = new List<string> { "#00849C", "#30ACBB", "#A3D6D7" };
            var multi = new List<string> { "#0E3F77", "#FEC51F", "#666FAF" };

            var colorsToUse = multi;
            var pieSliceTextStyleAcresInConstruction= new GoogleChartTextStyle("#1c2329") { IsBold = true, FontSize = 20 };
            googlePieChartSlices.Add(new GooglePieChartSlice("Acres Completed", progressDashboardPieChartValues[0], sortOrder++, colorsToUse[0]));
            googlePieChartSlices.Add(new GooglePieChartSlice("Acres In Construction", progressDashboardPieChartValues[1], sortOrder++, colorsToUse[1], pieSliceTextStyleAcresInConstruction));
            googlePieChartSlices.Add(new GooglePieChartSlice("Acres In Planning", progressDashboardPieChartValues[2], sortOrder, colorsToUse[2]));
            return googlePieChartSlices;
        }

        public static List<double> GetProgressDashboardValues(this PerformanceMeasure performanceMeasure, double? convertedAcresToRemoveFromCompleted = null)
        {
            var acresCompleted = performanceMeasure.GetTotalActualsForActiveProjectsForPerformanceMeasure();
            acresCompleted = convertedAcresToRemoveFromCompleted.HasValue ? acresCompleted - convertedAcresToRemoveFromCompleted.Value : acresCompleted;
            var acresInConstruction = GetTotalExpectedsForActiveProjectsForPerformanceMeasure(performanceMeasure, ProjectStage.Implementation) - acresCompleted;
            var acresPlanned = GetTotalExpectedsForActiveProjectsForPerformanceMeasure(performanceMeasure, ProjectStage.PlanningDesign);
            acresPlanned = acresPlanned < 0 ? 0 : acresPlanned;
            acresInConstruction = acresInConstruction < 0 ? 0 : acresInConstruction;
            acresCompleted = acresCompleted < 0 ? 0 : acresCompleted;
            return new List<double> { acresCompleted, acresInConstruction, acresPlanned };
        }

        public static double GetTotalActualsForPerformanceMeasureSubcategoryOption(this PerformanceMeasure performanceMeasure, int subcategoryOptionID)
        {
            return performanceMeasure.PerformanceMeasureActualSubcategoryOptions.Any(x =>
                x.PerformanceMeasureSubcategoryOptionID == subcategoryOptionID)
                ? performanceMeasure.PerformanceMeasureActualSubcategoryOptions
                    .Where(x => x.PerformanceMeasureSubcategoryOptionID == subcategoryOptionID)
                    .Sum(x => x.PerformanceMeasureActual.ActualValue)
                : 0;
        }

        private static double GetTotalActualsForActiveProjectsForPerformanceMeasure(this PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.PerformanceMeasureActuals.Any(x => x.Project.IsActiveProject())
                ? performanceMeasure.PerformanceMeasureActuals.Where(x => x.Project.IsActiveProject()).Sum(x => x.ActualValue)
                : 0;
        }


        private static double GetTotalExpectedsForActiveProjectsForPerformanceMeasure(PerformanceMeasure performanceMeasure, ProjectStage projectStage)
        {
            return performanceMeasure.PerformanceMeasureExpecteds.Any(x => x.Project.IsActiveProject() && x.Project.ProjectStageID == projectStage.ProjectStageID)
                ? performanceMeasure.PerformanceMeasureExpecteds.Where(x => x.Project.IsActiveProject() && x.Project.ProjectStageID == projectStage.ProjectStageID).Sum(x => x.ExpectedValue ?? 0)
                : 0;
        }

        public static GoogleChartDataTable GetProgressDashboardPieChartDataTable(List<GooglePieChartSlice> googlePieChartSlices)
        {
            var googleChartColumns = new List<GoogleChartColumn>
            {
                new GoogleChartColumn($"Completion Status", GoogleChartColumnDataType.String, GoogleChartType.PieChart),
                new GoogleChartColumn($"Amount", GoogleChartColumnDataType.Number, GoogleChartType.PieChart)

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
            return googleChartDataTable;
        }

        public static Tuple<GoogleChartDataTable, Dictionary<string, string>> GetProgressDashboardGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(this PerformanceMeasure performanceMeasure,
                                          ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods,
                                          List<IGrouping<Project, PerformanceMeasureActual>> groupedByProject,
                                          List<string> chartColumns,
                                          bool showCumulativeResults,
                                          int convertedAcresPerformanceMeasureSubcategoryOptionID)
        {
            var googleChartRowCs = new List<GoogleChartRowC>();

            foreach (var performanceMeasureReportingPeriod in performanceMeasureReportingPeriods.OrderBy(x => x.PerformanceMeasureReportingPeriodCalendarYear))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel) };

                googleChartRowVs.AddRange(groupedByProject.OrderBy(x => x.Key.ProjectName).Select(x =>
                {
                    double calendarYearReportedValue;
                    if (showCumulativeResults)
                    {
                        calendarYearReportedValue = x.Any(pmrv =>
                            pmrv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear <=
                            performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear) ?
                            x.Where(pmrv =>
                                pmrv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear <=
                                performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                            .Sum(pmrv => pmrv.ActualValue) : 0;
                    }
                    else
                    {
                        calendarYearReportedValue = x.Where(pmsorv =>
                                pmsorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear ==
                                performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                            .Sum(pmrv => pmrv.ActualValue);
                    }

                    var projectHasConvertedAcresForSubcategoryOption = x.Key.PerformanceMeasureActuals.Any(pmrv =>
                        pmrv.PerformanceMeasureActualSubcategoryOptions.Any(z =>
                            z.PerformanceMeasureSubcategoryOptionID ==
                            convertedAcresPerformanceMeasureSubcategoryOptionID));

                    var formattedValue = $"{GoogleChartJson.GetFormattedValue(calendarYearReportedValue, performanceMeasure.MeasurementUnitType)}{(projectHasConvertedAcresForSubcategoryOption ? " *" : string.Empty)}";
                    return new GoogleChartRowV(calendarYearReportedValue, formattedValue);
                }));

                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            // reporting period is going to be the first column and it will be our horizontal axis
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Reporting Period", GoogleChartColumnDataType.String) };

            // all the project values are individual columns and series and they will be on the vertical axis
            var projectToColorDictionary = new Dictionary<string, string>();
            for (int i = 0; i < chartColumns.Count; i++)
            {
                projectToColorDictionary.Add(chartColumns[i], ColorSeriesForProgressDashboard[i % 36]);
                googleChartColumns.Add(new GoogleChartColumn(chartColumns[i], chartColumns[i], GoogleChartColumnDataType.Number.ToString(), new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary, ColorSeriesForProgressDashboard[i % 36], null, null)));
            }

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return new Tuple<GoogleChartDataTable, Dictionary<string, string>>(googleChartDataTable, projectToColorDictionary) ;
        }
        public static List<string> ColorSeriesForProgressDashboard = new List<string>()
        {
            "#3366CC",
            "#DC3912",
            "#FF9900",
            "#109618",
            "#990099",
            "#0099C6",
            "#DD4477",
            "#66AA00",
            "#B82E2E",
            "#316395",
            "#994499",
            "#22AA99",
            "#AAAA11",
            "#6633CC",
            "#E67300",
            "#8B0707",
            "#651067",
            "#329262",
            "#5574A6",
            "#3B3EAC",
            "#B77322",
            "#16D620",
            "#B91383",
            "#F4359E",
            "#9C5935",
            "#A9C413",
            "#2A778D",
            "#668D1C",
            "#BEA413",
            "#0C5922",
            "#743411",
            "#B322F7",
            "#59E59A",
            "#E582B5",
            "#8080FC",
            "#FF8282"
        };
    }


}
