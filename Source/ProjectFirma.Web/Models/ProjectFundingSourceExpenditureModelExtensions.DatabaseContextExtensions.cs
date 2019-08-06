/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditure.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectFundingSourceExpenditureModelExtensions
    {
        public static List<int> CalculateCalendarYearRangeForExpenditures(this IList<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, Project project)
        {
            var existingYears = projectFundingSourceExpenditures.Select(x => x.CalendarYear).ToList();
            return FirmaDateUtilities.CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(existingYears, project, DateTime.Today.Year);
        }

        public static List<int> CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears(this Project project)
        {
            return FirmaDateUtilities.CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(new List<int>(), project, DateTime.Today.Year);
        }

        public static List<int> CalculateCalendarYearRangeForExpenditures(this IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, FundingSource fundingSource)
        {
            var existingYears = projectFundingSourceExpenditures.Select(x => x.CalendarYear).ToList();
            return FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(existingYears,
                fundingSource.GetProjectsWhereYouAreTheFundingSourceMinCalendarYear(),
                fundingSource.GetProjectsWhereYouAreTheFundingSourceMaxCalendarYear(),
                DateTime.Today.Year,
                MultiTenantHelpers.GetMinimumYear(),
                null);
        }

        public static GoogleChartJson ToGoogleChart(this IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            Func<ProjectFundingSourceExpenditure, string> filterFunction,
            List<string> filterValues,
            Func<ProjectFundingSourceExpenditure, IComparable> sortFunction,
            string chartContainerID,
            string chartTitle)
        {
            var projectFundingSourceExpenditureList = projectFundingSourceExpenditures.ToList();
            if (!projectFundingSourceExpenditureList.Any())
            {
                return null;
            }
            var beginCalendarYear = projectFundingSourceExpenditureList.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditureList.Max(x => x.CalendarYear);
            var rangeOfYears = FirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            return projectFundingSourceExpenditureList.ToGoogleChart(filterFunction, filterValues, sortFunction, rangeOfYears, chartContainerID, chartTitle, GoogleChartType.AreaChart, true);
        }

        //TODO: The GetFullCategoryYearDictionary and GetGoogleChartDataTable functions are probably fine in this Extension class, but the ToGoogleChart functions are more about display and probably could be in a better location
        public static GoogleChartJson ToGoogleChart(this IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            Func<ProjectFundingSourceExpenditure, string> filterFunction,
            List<string> filterValues,
            Func<ProjectFundingSourceExpenditure, IComparable> sortFunction,
            List<int> rangeOfYears,
            string chartContainerID,
            string chartTitle,
            GoogleChartType googleChartType,
            bool isStacked)
        {
            var fullCategoryYearDictionary = GetFullCategoryYearDictionary(projectFundingSourceExpenditures, filterFunction, filterValues, sortFunction, rangeOfYears);
            var googleChartDataTable = GetGoogleChartDataTable(fullCategoryYearDictionary, rangeOfYears, googleChartType);
            var googleChartAxis = new GoogleChartAxis("Annual Expenditures", MeasurementUnitTypeEnum.Dollars, GoogleChartAxisLabelFormat.Short);
            var googleChartConfiguration = new GoogleChartConfiguration(chartTitle,
                isStacked,
                googleChartType,
                googleChartDataTable,
                new GoogleChartAxis(FieldDefinitionEnum.ReportingYear.ToType().GetFieldDefinitionLabel(), null, null),
                new List<GoogleChartAxis> { googleChartAxis });
            var googleChart = new GoogleChartJson(chartTitle, chartContainerID, googleChartConfiguration,
                googleChartType, googleChartDataTable, null);
            return googleChart;
        }

        public static Dictionary<string, Dictionary<int, decimal>> GetFullCategoryYearDictionary(this IEnumerable<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures,
            Func<ProjectFundingSourceExpenditure, string> filterFunction,
            List<string> filterValues,
            Func<ProjectFundingSourceExpenditure, IComparable> sortFunction,
            List<int> rangeOfYears)
        {
            var fullCategoryYearDictionary = filterValues.ToDictionary(x => x, x => rangeOfYears.ToDictionary(y => y, y => 0m));
            projectFundingSourceExpenditures.OrderBy(sortFunction.Invoke).Where(x => rangeOfYears.Contains(x.CalendarYear)).GroupBy(x => x.CalendarYear).ToList().ForEach(x =>
            {
                filterValues.ForEach(s =>
                {
                    var expenditures = x.Where(y => filterFunction.Invoke(y) == s).ToList();
                    fullCategoryYearDictionary[s][x.Key] = expenditures.Sum(y => y.GetMonetaryAmount() ?? 0);
                });
            });
            return fullCategoryYearDictionary;
        }

        private static GoogleChartDataTable GetGoogleChartDataTable(Dictionary<string, Dictionary<int, decimal>> fullCategoryYearDictionary, List<int> rangeOfYears, GoogleChartType columnDisplayType)
        {
            var googleChartRowCs = new List<GoogleChartRowC>();
            var sortedYearCategoryDictionary =
                fullCategoryYearDictionary.OrderBy(x => x.Value.Sum(y => y.Value)).ThenBy(x => x.Key).ToList();

            foreach (var year in rangeOfYears.OrderBy(x => x))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(year, year.ToString()) };
                googleChartRowVs.AddRange(
                    sortedYearCategoryDictionary
                        .Select(x => x.Key)
                        .Select(category => fullCategoryYearDictionary[category][year])
                        .Select(value => new GoogleChartRowV(value, GoogleChartJson.GetFormattedValue((double)value, MeasurementUnitType.Dollars))));

                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var columnLabel = FieldDefinitionEnum.ReportingYear.ToType().GetFieldDefinitionLabel();
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn(columnLabel, columnLabel, "string") };
            googleChartColumns.AddRange(
                sortedYearCategoryDictionary.Select(
                        x => new GoogleChartColumn(x.Key, x.Key, "number", new GoogleChartSeries(columnDisplayType, GoogleChartAxisType.Primary), null, null)));

            return new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
        }

        public static string GetFundingSourceCustomAttributesValue(this ProjectFundingSourceExpenditure projectFundingSourceExpenditure, FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            var fundingSourceCustomAttribute = projectFundingSourceExpenditure.FundingSource.FundingSourceCustomAttributes.SingleOrDefault(x => x.FundingSourceCustomAttributeTypeID == fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
            if (fundingSourceCustomAttribute != null)
            {
                if (fundingSourceCustomAttributeType.FundingSourceCustomAttributeDataType == FundingSourceCustomAttributeDataType.DateTime)
                {
                    return DateTime.TryParse(fundingSourceCustomAttribute.GetCustomAttributeValues().Single().AttributeValue, out var date) ? date.ToShortDateString() : null;
                }
                else
                {
                    return string.Join(", ",
                        fundingSourceCustomAttribute.FundingSourceCustomAttributeValues.Select(x => x.AttributeValue));
                }
            }
            else
            {
                return "None";
            }
        }
    }
}
