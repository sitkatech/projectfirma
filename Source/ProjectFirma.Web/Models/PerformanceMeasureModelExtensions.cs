/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetSummaryUrl(this PerformanceMeasure performanceMeasure)
        {
            return SummaryUrlTemplate.ParameterReplace(performanceMeasure.PerformanceMeasureID);
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

        public static List<GoogleChartJson> GetGoogleChartJsonDictionary(this PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea, List<Project> projects, string chartUniqueName)
        {
            var reportedValues = performanceMeasure.GetProjectPerformanceMeasureSubcategoryOptionReportedValues(projects);
            return PerformanceMeasureSubcategoryModelExtensions.MakeGoogleChartJsons(performanceMeasure, geospatialArea, reportedValues);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            var projects = performanceMeasure.GetAssociatedProjectsWithReportedValues(currentFirmaSession);
            return performanceMeasure.GetReportedPerformanceMeasureValues(projects);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, Project project)
        {
            return performanceMeasure.GetReportedPerformanceMeasureValues(new List<Project> { project });
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, ProjectUpdateBatch projectUpdateBatch)
        {
            return performanceMeasure.GetReportedPerformanceMeasureValues(new List<ProjectUpdateBatch> { projectUpdateBatch });
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects);
            return performanceMeasureReportedValues;
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, List<ProjectUpdateBatch> projectUpdateBatches)
        {
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projectUpdateBatches);
            return performanceMeasureReportedValues;
        }


        public static List<ProjectPerformanceMeasureReportingPeriodValue> GetProjectPerformanceMeasureSubcategoryOptionReportedValues(this PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            var performanceMeasureValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects);

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
            return performanceMeasure.PerformanceMeasureActuals.Select(ptc => ptc.Project).ToList().GetActiveProjectsAndProposals(currentFirmaSession.Person.CanViewProposals());
        }

        public static int ReportedProjectsCount(this PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession)
        {
            return performanceMeasure.GetAssociatedProjectsWithReportedValues(currentFirmaSession).Count;
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
    }
}
