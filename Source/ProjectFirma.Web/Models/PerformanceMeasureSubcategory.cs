/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategory.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureSubcategory : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return PerformanceMeasureSubcategoryDisplayName; }
        }

        public bool ShowOnChart
        {
            get { return true; }
        }

        public static List<GoogleChartJson> MakeGoogleChartJsonsForSubcategories(PerformanceMeasure performanceMeasure,
            IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues,
            IEnumerable<int> yearRange)
        {
            return
                performanceMeasure.PerformanceMeasureSubcategories.Where(x => x.ShowOnChart)
                    .Select(x => MakeGoogleChartJson(performanceMeasure, x, performanceMeasureReportedValues, yearRange))
                    .ToList();
        }

        private static GoogleChartJson MakeGoogleChartJson(PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory, IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues, IEnumerable<int> yearRange)
        {
            var performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.OrderBy(x => x.SortOrder).ToDictionary(x => x, x =>
            {
                var calendarYearReportedValuesDict =
                    performanceMeasureReportedValues.SelectMany(pmav => pmav.PerformanceMeasureActualSubcategoryOptions)
                        .Where(pmavsco => performanceMeasureSubcategory.PerformanceMeasureSubcategoryID == pmavsco.PerformanceMeasureSubcategoryID && pmavsco.PerformanceMeasureSubcategoryOptionID == x.PerformanceMeasureSubcategoryOptionID)
                        .GroupBy(pmavsco => pmavsco.PerformanceMeasureActual.CalendarYear)
                        .ToDictionary(cy => cy.Key, cy => cy.Sum(exp => exp.PerformanceMeasureActual.ActualValue));

                var calendarYearReportedValues =
                    yearRange.OrderBy(year => year).Select(year => new CalendarYearReportedValue(year, calendarYearReportedValuesDict.ContainsKey(year) ? calendarYearReportedValuesDict[year] : 0));
                return calendarYearReportedValues;
            });

            var googleChartJson = MakeGoogleChartJsonForPerformanceMeasureSubcategory(performanceMeasure,
                yearRange,
                performanceMeasureSubcategory,
                performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues);
            return googleChartJson;
        }

        private static GoogleChartJson MakeGoogleChartJsonForPerformanceMeasureSubcategory(PerformanceMeasure performanceMeasure,
            IEnumerable<int> yearRange,
            PerformanceMeasureSubcategory performanceMeasureSubcategory,
            Dictionary<PerformanceMeasureSubcategoryOption, IEnumerable<CalendarYearReportedValue>> performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues)
        {

            var googleChartType = GoogleChartTypeExtension.ParseOrDefault(performanceMeasureSubcategory.ChartType);
            var googleChartDataTable = GetGoogleChartDataTableForPerformanceMeasure(yearRange,
                performanceMeasure.MeasurementUnitType,
                googleChartType,
                performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues);
            var legendTitle = performanceMeasure.HasRealSubcategories
                ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName
                : performanceMeasure.PerformanceMeasureDisplayName;
            var googleChartJson = MakeGoogleChartJsonForPerformanceMeasureSubcategory(performanceMeasureSubcategory,
                googleChartDataTable,
                legendTitle);
            return googleChartJson;
        }

        public static GoogleChartJson MakeGoogleChartJsonForPerformanceMeasureSubcategory(PerformanceMeasureSubcategory performanceMeasureSubcategory, GoogleChartDataTable googleChartDataTable, string legendTitle)
        {
            var performanceMeasure = performanceMeasureSubcategory.PerformanceMeasure;

            var chartConfiguration = performanceMeasureSubcategory.ChartConfigurationJson != null
                ? JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.ChartConfigurationJson)
                : new GoogleChartConfiguration(performanceMeasure.PerformanceMeasureDisplayName, performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName.ToProperCase(), performanceMeasure.MeasurementUnitType);

            var performanceMeasureID = performanceMeasure.PerformanceMeasureID;
            var performanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            var chartName = string.Format("PerformanceMeasure{0}PerformanceMeasureSubcategory{1}", performanceMeasureID, performanceMeasureSubcategoryID);
            var chartPopupUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.PerformanceMeasureChartPopup(performanceMeasureID));
            var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(performanceMeasureID, performanceMeasureSubcategoryID));
            var chartGroupID = performanceMeasureID.ToString();
            var googleChartType = GoogleChartTypeExtension.ParseOrDefault(performanceMeasureSubcategory.ChartType);
            var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, googleChartType, googleChartDataTable, chartPopupUrl, chartGroupID, saveConfigurationUrl);
            return googleChartJson;
        }

        private static GoogleChartDataTable GetGoogleChartDataTableForPerformanceMeasure(IEnumerable<int> yearRange, MeasurementUnitType measurementUnitType, GoogleChartType googleChartType, Dictionary<PerformanceMeasureSubcategoryOption, IEnumerable<CalendarYearReportedValue>> performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues)
        {
            var seriesChartType = googleChartType == GoogleChartType.ComboChart ? GoogleChartType.LineChart : googleChartType;

            var googleChartRowCs = new List<GoogleChartRowC>();

            foreach (var year in yearRange.OrderBy(x => x))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(year, year.ToString()) };
                googleChartRowVs.AddRange(
                    performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues.OrderBy(x => x.Key.SortOrder)
                        .Select(x =>
                        {
                            //calendarYearReportedValue used to never be null, but commit 124877 changed flow so it can be null now, so catch null and return 0.
                            var calendarYearReportedValue = x.Value.SingleOrDefault(y => y.CalendarYear == year);
                            var reportedValue = calendarYearReportedValue == null ? 0 : calendarYearReportedValue.ReportedValue;
                            return new GoogleChartRowV(reportedValue, GoogleChartJson.GetFormattedValue(reportedValue, measurementUnitType));
                        }));

                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Year", GoogleChartColumnDataType.String, seriesChartType) };
            googleChartColumns.AddRange(performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues.OrderBy(x => x.Key.SortOrder).Select(x => new GoogleChartColumn(x.Key.PerformanceMeasureSubcategory.PerformanceMeasure.HasRealSubcategories ? x.Key.ChartName : x.Key.PerformanceMeasureSubcategory.PerformanceMeasure.PerformanceMeasureDisplayName, GoogleChartColumnDataType.Number, seriesChartType)));

            return new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
        }

        public static PerformanceMeasureTargetValueType GetTargetValueType(IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory)
        {
            var performanceMeasureReportingPeriods = performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportingPeriods();
            if (!performanceMeasureReportingPeriods.Any(x => x.TargetValue.HasValue))
            {
                return PerformanceMeasureTargetValueType.NoTarget;
            }

            if (performanceMeasureReportingPeriods.Select(x => String.Format("{0}{1}", x.TargetValue, x.TargetValueDescription)).Distinct().Count() == 1)
            {
                return PerformanceMeasureTargetValueType.OverallTarget;
            }
            return PerformanceMeasureTargetValueType.TargetPerReportingPeriod;
        }
    }
}
