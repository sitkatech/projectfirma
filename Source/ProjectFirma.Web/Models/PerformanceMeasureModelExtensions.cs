﻿/*-----------------------------------------------------------------------
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
        public const int TechnicalAssistanceProvidedPMID = 2147;
        public const int ProvidedSubcategoryOptionID = 2935;
        public const int EngineeringAssistanceSubcategoryOptionID = 2938;
        public const int ProvidedToConservationDistrictionsSubcategoryOptionID = 2994;

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

        public static GoogleChartConfiguration GetDefaultPerformanceMeasureChartConfigurationJson(
            PerformanceMeasure performanceMeasure)
        {
            var googleChartType = GoogleChartType.ColumnChart;
            var googleChartAxisHorizontal =
                new GoogleChartAxis("Reporting Year", null, null) {Gridlines = new GoogleChartGridlinesOptions(-1, "transparent")};
            var googleChartAxisVerticals = new List<GoogleChartAxis>();
            var defaultSubcategoryChartConfigurationJson = new GoogleChartConfiguration(
                performanceMeasure.PerformanceMeasureDisplayName, true, googleChartType, googleChartAxisHorizontal,
                googleChartAxisVerticals);
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

        public static List<PerformanceMeasureSubcategoriesTotalReportedValue> SubcategoriesTotalReportedValues(Person currentPerson, PerformanceMeasure performanceMeasure)
        {
            var groupByProjectAndSubcategory =
                performanceMeasure.GetReportedPerformanceMeasureValues(currentPerson)
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

        public static List<GoogleChartJson> GetGoogleChartJsonDictionary(this PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            var reportedValues = performanceMeasure.GetProjectPerformanceMeasureSubcategoryOptionReportedValues(projects);
            return PerformanceMeasureSubcategoryModelExtensions.MakeGoogleChartJsons(performanceMeasure, reportedValues);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            var projects = performanceMeasure.GetAssociatedProjectsWithReportedValues(currentPerson);
            return performanceMeasure.GetReportedPerformanceMeasureValues(projects);
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, Project project)
        {
            return performanceMeasure.GetReportedPerformanceMeasureValues(new List<Project> { project });
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(this PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            var performanceMeasureReportedValues = performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects);
            return GetPerformanceMeasureReportedValuesImpl(HttpRequestStorage.DatabaseEntities, performanceMeasure, performanceMeasureReportedValues);
        }

        private static List<PerformanceMeasureReportedValue> GetPerformanceMeasureReportedValuesImpl(DatabaseEntities databaseEntities, PerformanceMeasure performanceMeasure, List<PerformanceMeasureReportedValue> performanceMeasureReportedValues)
        {
            if (performanceMeasure.PerformanceMeasureDataSourceType == PerformanceMeasureDataSourceType.TechnicalAssistanceValue)
            {
                // the source for this PM is "Technical Assistance Provided to Conservation Districts"
                if (performanceMeasure.PerformanceMeasureID != TechnicalAssistanceProvidedPMID)
                {
                    // should not be calling this from a context where that PM doesn't exist anyway, but let's not die if we do.
                    return new List<PerformanceMeasureReportedValue>();
                }

                var performanceMeasureReportedValuesForTechnicalAssistancePM = performanceMeasureReportedValues.Where(x =>
                {
                    var performanceMeasureValueSubcategoryOptionIDs = x.PerformanceMeasureActualSubcategoryOptions
                        .Select(y => y.PerformanceMeasureSubcategoryOptionID).ToList();
                    return performanceMeasureValueSubcategoryOptionIDs
                               .Contains(ProvidedSubcategoryOptionID) && performanceMeasureValueSubcategoryOptionIDs
                               .Contains(ProvidedToConservationDistrictionsSubcategoryOptionID);
                }); // Should only be counting "Provided" to "Conservation District" Technical Assistance Hours

                // get these now to prepare for the main calculation
                var technicalAssistanceParameters = databaseEntities.TechnicalAssistanceParameters.ToList();
                var performanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>
                {
                    new VirtualPerformanceMeasureValueSubcategoryOption(performanceMeasure
                        .PerformanceMeasureSubcategories
                        .Single())
                };

                return performanceMeasureReportedValuesForTechnicalAssistancePM.Select(performanceMeasureReportedValue =>
                {
                    var year = performanceMeasureReportedValue.CalendarYear;
                    var project = performanceMeasureReportedValue.Project;
                    var technicalAssistanceParameter =
                        technicalAssistanceParameters.SingleOrDefault(y => y.Year == year);
                    var engineeringHourlyCost = technicalAssistanceParameter?.EngineeringHourlyCost;
                    var otherAssistanceHourlyCost = technicalAssistanceParameter?.OtherAssistanceHourlyCost;

                    var technicalAssistanceValueInYear = performanceMeasureReportedValue
                        .PerformanceMeasureActualSubcategoryOptions
                        .Select(y => y.PerformanceMeasureSubcategoryOptionID)
                        .Contains(
                            EngineeringAssistanceSubcategoryOptionID) // "Engineering Assistance" is treated differently from other kinds of technical assistance.
                        ? performanceMeasureReportedValue.GetReportedValue().GetValueOrDefault() *
                          (double) engineeringHourlyCost.GetValueOrDefault()
                        : performanceMeasureReportedValue.GetReportedValue().GetValueOrDefault() *
                          (double) otherAssistanceHourlyCost.GetValueOrDefault();
                    return new PerformanceMeasureReportedValue(performanceMeasure, project, year,
                        technicalAssistanceValueInYear)
                    {
                        PerformanceMeasureActualSubcategoryOptions = performanceMeasureActualSubcategoryOptions
                    };
                }).ToList();
            }

            return performanceMeasureReportedValues;
        }

        public static List<ProjectPerformanceMeasureReportingPeriodValue> GetProjectPerformanceMeasureSubcategoryOptionReportedValues(this PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            var performanceMeasureValues = GetPerformanceMeasureReportedValuesImpl(HttpRequestStorage.DatabaseEntities, performanceMeasure, performanceMeasure.PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues(performanceMeasure, projects));

            var performanceMeasureActualsFiltered =
                projects?.Any() == true ? performanceMeasureValues.Where(pmav => projects.Contains(pmav.Project)).ToList() : performanceMeasureValues;

            var groupByProjectAndSubcategory = performanceMeasureActualsFiltered.GroupBy(pirv => new { pirv.Project, PerformanceMeasureSubcategoriesAsString = pirv.GetPerformanceMeasureSubcategoriesAsString(), pirv.CalendarYear }).OrderBy(x => x.Key.PerformanceMeasureSubcategoriesAsString).ToList();

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
                                    reportedValuesGroup.Key.CalendarYear, y.PerformanceMeasureSubcategoryOption,
                                    reportedValuesGroup.Sum(x => x.GetReportedValue() ?? 0));
                        }
                        else
                        {
                            return new
                                PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue(
                                    reportedValuesGroup.Key.CalendarYear,
                                    reportedValuesGroup.Sum(x => x.GetReportedValue() ?? 0), y.PerformanceMeasureSubcategory, y.GetPerformanceMeasureSubcategoryOptionName());
                        }
                    }).ToList();

                return new ProjectPerformanceMeasureReportingPeriodValue(project, performanceMeasureReportingPeriodSubcategoryOptionReportedValues);
            }).ToList();

            return projectPerformanceMeasureReportingPeriodValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.Project.ProjectName).ToList();
        }

        public static List<Project> GetAssociatedProjectsWithReportedValues(this PerformanceMeasure performanceMeasure, Person person)
        {
            return performanceMeasure.PerformanceMeasureActuals.Select(ptc => ptc.Project).ToList().GetActiveProjectsAndProposals(person.CanViewProposals());
        }

        public static int ReportedProjectsCount(this PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            return performanceMeasure.GetAssociatedProjectsWithReportedValues(currentPerson).Distinct().Count();
        }

        public static TaxonomyTier GetPrimaryTaxonomyTier(this PerformanceMeasure performanceMeasure)
        {
            var taxonomyBranchPerformanceMeasureGroupedByLevel = performanceMeasure.GetTaxonomyTiers();
            return taxonomyBranchPerformanceMeasureGroupedByLevel
                .Where(group => group.Any(x => x.IsPrimaryTaxonomyLeaf))
                .Select(group => group.Key).FirstOrDefault();
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

        public static decimal? TotalExpenditure(this PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            return SubcategoriesTotalReportedValues(currentPerson, performanceMeasure).Sum(x => x.CalculateWeightedTotalExpenditure());
        }

        public static decimal? TotalExpenditurePerPerformanceMeasureUnit(this PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            var totalReportedValues = SubcategoriesTotalReportedValues(currentPerson, performanceMeasure).Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue ?? 0);
            if (Math.Abs(totalReportedValues) < Double.Epsilon)
            {
                return null;
            }
            return performanceMeasure.TotalExpenditure(currentPerson) / (decimal)totalReportedValues;
        }

        public static double? TotalReportedValueWithNonZeroExpenditures(this PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            return SubcategoriesTotalReportedValues(currentPerson, performanceMeasure).Where(x => x.CalculateWeightedTotalExpenditure() > 0).Sum(x => x.TotalReportedValue);
        }
    }
}
