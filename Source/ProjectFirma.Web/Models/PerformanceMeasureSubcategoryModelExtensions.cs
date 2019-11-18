using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using MoreLinq;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureSubcategoryModelExtensions
    {
        public static List<GoogleChartJson> MakeGoogleChartJsons(PerformanceMeasure performanceMeasure, List<ProjectPerformanceMeasureReportingPeriodValue> projectPerformanceMeasureReportingPeriodValues)
        {
            var performanceMeasureSubcategoryOptionReportedValues = projectPerformanceMeasureReportingPeriodValues.SelectMany(x => x.PerformanceMeasureSubcategoryOptionReportedValues).GroupBy(x => x.PerformanceMeasureSubcategory);
            var performanceMeasureReportingPeriods = performanceMeasure.PerformanceMeasureReportingPeriods.Where(x => x.PerformanceMeasureActuals.Any() || x.TargetValue.HasValue).ToList();
            var googleChartJsons = new List<GoogleChartJson>();

            if (performanceMeasureSubcategoryOptionReportedValues.Any())
            { 
                foreach (var groupedBySubcategory in performanceMeasureSubcategoryOptionReportedValues.Where(x => x.Key.ShowOnChart()))
                {
                    var performanceMeasureSubcategory = groupedBySubcategory.Key;
                    Check.RequireNotNull(performanceMeasureSubcategory.ChartConfigurationJson, "All PerformanceMeasure Subcategories need to have a Google Chart Configuration Json");
                    var groupedBySubcategoryOption = groupedBySubcategory.GroupBy(c => new Tuple<string, int>(c.ChartName, c.SortOrder)).ToList(); // Item1 is ChartName, Item2 is SortOrder
                    var chartColumns = performanceMeasure.HasRealSubcategories() ? groupedBySubcategoryOption.OrderBy(x => x.Key.Item2).Select(x => x.Key.Item1).ToList() : new List<string> { performanceMeasure.GetDisplayName() };
                    var hasTargets = GetTargetValueType(performanceMeasureReportingPeriods) != PerformanceMeasureTargetValueType.NoTarget;
                    var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;

                    var googleChartDataTable = GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasure, performanceMeasureReportingPeriods, hasTargets, groupedBySubcategoryOption, chartColumns, performanceMeasure.IsSummable, reverseTooltipOrder, false);
                    var legendTitle = performanceMeasure.HasRealSubcategories() ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : performanceMeasure.GetDisplayName();
                    var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}";
                    var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x =>
                        x.SaveChartConfiguration(performanceMeasure,
                            performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, false));
                    var resetConfigurationUrl =
                        SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x =>
                            x.ResetChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, false));
                    var chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.ChartConfigurationJson);
                    if (performanceMeasureSubcategory.PerformanceMeasure.IsSummable)
                    {
                        chartConfiguration.Tooltip = new GoogleChartTooltip(true);
                    }
                    
                    var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration,
                        performanceMeasureSubcategory.GoogleChartType, googleChartDataTable,
                        chartColumns, saveConfigurationUrl, resetConfigurationUrl, false);
                    googleChartJsons.Add(googleChartJson);
                }

                // Add Cumulative charts if appropriate
                if (performanceMeasure.CanBeChartedCumulatively)
                {
                    foreach (var groupedBySubcategory in performanceMeasureSubcategoryOptionReportedValues.Where(x => x.Key.ShowOnCumulativeChart()))
                    {
                        var performanceMeasureSubcategory = groupedBySubcategory.Key;
                        var groupedBySubcategoryOption = groupedBySubcategory.GroupBy(c => new Tuple<string, int>(c.ChartName, c.SortOrder)).ToList(); // Item1 is ChartName, Item2 is SortOrder
                        var chartColumns = performanceMeasure.HasRealSubcategories() ? groupedBySubcategoryOption.OrderBy(x => x.Key.Item2).Select(x => x.Key.Item1).ToList() : new List<string> { performanceMeasure.GetDisplayName() };
                        var hasTargets = GetTargetValueType(performanceMeasureReportingPeriods) != PerformanceMeasureTargetValueType.NoTarget;
                        var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;
                        var googleChartDataTable = GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasure, performanceMeasureReportingPeriods, hasTargets, groupedBySubcategoryOption, chartColumns, performanceMeasure.IsSummable, reverseTooltipOrder, true);
                        var legendTitle = performanceMeasure.HasRealSubcategories() ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : performanceMeasure.GetDisplayName();
                        var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}Cumulative";
                        var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, true));
                        var resetConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.ResetChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, true));
                        var chartConfiguration = !string.IsNullOrEmpty(performanceMeasureSubcategory.CumulativeChartConfigurationJson) ? JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.CumulativeChartConfigurationJson) : GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(performanceMeasureSubcategory.ChartConfigurationJson);

                        if (performanceMeasureSubcategory.PerformanceMeasure.IsSummable)
                        {
                            chartConfiguration.Tooltip = new GoogleChartTooltip(true);
                        }

                        var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, performanceMeasureSubcategory.CumulativeGoogleChartType ?? GoogleChartType.ColumnChart, googleChartDataTable, chartColumns, saveConfigurationUrl, resetConfigurationUrl, true);
                        googleChartJsons.Add(googleChartJson);
                    }
                }
            }
            else if(performanceMeasure.PerformanceMeasureReportingPeriods.Any(x => x.TargetValue.HasValue))
            {
                //build chart for just for targets if there is no project data
                var performanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.First();
                var legendTitle = performanceMeasure.GetDisplayName();
                var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}";
                var chartConfiguration = performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson();
                var chartColumns = new List<string> { performanceMeasure.GetDisplayName() };
                var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;
                var googleChartDataTable = GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasure, performanceMeasureReportingPeriods, true, new List<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>>(), chartColumns, false, reverseTooltipOrder, false);
                var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, true));
                var resetConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.ResetChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, true));

                var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, GoogleChartType.LineChart, googleChartDataTable, chartColumns, saveConfigurationUrl, resetConfigurationUrl, false);
                googleChartJsons.Add(googleChartJson);
            }




            return googleChartJsons;
        }

        public static GoogleChartDataTable GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(PerformanceMeasure performanceMeasure,
                                           ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods,
                                           bool hasTargets,
                                           IReadOnlyCollection<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>> groupedBySubcategoryOption,
                                           IEnumerable<string> chartColumns,
                                           bool hasToolTipWithTotal,
                                           bool reverseTooltipOrder,
                                           bool showCumulativeResults)
        {
            var googleChartRowCs = new List<GoogleChartRowC>();
            foreach (var performanceMeasureReportingPeriod in performanceMeasureReportingPeriods.OrderBy(x => x.PerformanceMeasureReportingPeriodCalendarYear))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel) };
                var firstReportingPeriod = performanceMeasureReportingPeriods.OrderBy(x => x.PerformanceMeasureReportingPeriodCalendarYear).First();
                if (hasToolTipWithTotal)
                {
                    var formattedDataTooltip = FormattedDataTooltip(groupedBySubcategoryOption, performanceMeasureReportingPeriod, performanceMeasure.MeasurementUnitType, reverseTooltipOrder, performanceMeasureReportingPeriod.TargetValue, performanceMeasureReportingPeriod.TargetValueLabel, showCumulativeResults, firstReportingPeriod);
                    googleChartRowVs.Add(new GoogleChartRowV(null, formattedDataTooltip));
                }
                if (hasTargets)
                {
                    googleChartRowVs.Add(new GoogleChartRowV(performanceMeasureReportingPeriod.TargetValue, GetFormattedTargetValue(performanceMeasureReportingPeriod, performanceMeasure)));
                }

                googleChartRowVs.AddRange(groupedBySubcategoryOption.OrderBy(x => x.Key.Item2).Select(x =>
                {
                    double calendarYearReportedValue;
                    if (showCumulativeResults)
                    {
                        calendarYearReportedValue = x.Where(pmsorv =>
                                                            pmsorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear <=
                                                            performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                                                        .Sum(pmsorv => pmsorv.ReportedValue) ?? 0;
                    }
                    else
                    {
                        calendarYearReportedValue = x.Where(pmsorv =>
                                                            pmsorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear ==
                                                            performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                                                        .Sum(pmsorv => pmsorv.ReportedValue) ?? 0;
                    }

                    return new GoogleChartRowV(calendarYearReportedValue, GoogleChartJson.GetFormattedValue(calendarYearReportedValue, performanceMeasure.MeasurementUnitType));
                }));

                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            // reporting period is going to be the first column and it will be our horizontal axis
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Reporting Period", GoogleChartColumnDataType.String) };

            // add column with row tooltip
            if (hasToolTipWithTotal)
            {
                googleChartColumns.Add(new GoogleChartColumn(GoogleChartColumnDataType.String.ColumnDataType, "tooltip", new GoogleChartProperty()));
            }
            if (hasTargets)
            {
                // GoogleChartType for targets is always LINE; we also always render the target line first to stay consistent
                googleChartColumns.Add(new GoogleChartColumn(GetTargetColumnLabel(performanceMeasureReportingPeriods), GoogleChartColumnDataType.Number));
            }
            // all the subcategory option values are individual columns and series and they will be on the vertical axis
            googleChartColumns.AddRange(chartColumns.Select(x => new GoogleChartColumn(x, GoogleChartColumnDataType.Number)));

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        private static string GetTargetColumnLabel(ICollection<PerformanceMeasureReportingPeriod> performanceMeasurePerformanceMeasureReportingPeriods)
        {
            return GetTargetValueType(performanceMeasurePerformanceMeasureReportingPeriods) == PerformanceMeasureTargetValueType.OverallTarget ? performanceMeasurePerformanceMeasureReportingPeriods.First().TargetValueLabel : "Target";
        }

        private static string GetFormattedTargetValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return $"{GoogleChartJson.GetFormattedValue(performanceMeasureReportingPeriod.TargetValue, performanceMeasure.MeasurementUnitType)} ({performanceMeasureReportingPeriod.TargetValueLabel})";
        }

        public static PerformanceMeasureTargetValueType GetTargetValueType(this ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods)
        {
            if (!performanceMeasureReportingPeriods.Any(x => x.TargetValue.HasValue))
            {
                return PerformanceMeasureTargetValueType.NoTarget;
            }

            if (performanceMeasureReportingPeriods.Select(x => $"{x.TargetValue}{x.TargetValueLabel}").Distinct().Count() == 1)
            {
                return PerformanceMeasureTargetValueType.OverallTarget;
            }
            return PerformanceMeasureTargetValueType.TargetPerYear;
        }

        public static string FormattedDataTooltip(IReadOnlyCollection<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>> groupedBySubcategoryOption, 
                                                  PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, 
                                                  MeasurementUnitType performanceMeasureMeasurementUnitType, 
                                                  bool reverseTooltipOrder,
                                                  double? targetValue,
                                                  string targetValueDescription,
                                                  bool showCumulativeResults,
                                                  PerformanceMeasureReportingPeriod initialPerformanceMeasureReportingPeriod)
        {
            // shape data
            var calendarReportedYearValuesDictionary = new Dictionary<string, double>();
            var orderedSubCategoryOptions = reverseTooltipOrder
                ? groupedBySubcategoryOption.OrderByDescending(x => x.Key.Item2)
                : groupedBySubcategoryOption.OrderBy(x => x.Key.Item2);

            orderedSubCategoryOptions.ForEach(x =>
            {
                double calendarYearReportedValue;
                if (showCumulativeResults)
                {
                    calendarYearReportedValue =
                    x.Where<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>(isorv => isorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear <=
                                     performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                        .Sum(isorv => isorv.ReportedValue) ?? 0;
                } else
                {
                    calendarYearReportedValue =
                        x.Where<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>(isorv => isorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear ==
                                         performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                            .Sum(isorv => isorv.ReportedValue) ?? 0;
                }
                calendarReportedYearValuesDictionary.Add(x.Key.Item1, calendarYearReportedValue);
            });

            var stringPrecision = new String('0', performanceMeasureMeasurementUnitType.NumberOfSignificantDigits);
            var prefix = performanceMeasureMeasurementUnitType == MeasurementUnitType.Dollars ? "$" : null;

            // build html for tooltip
            var html = "<div class='googleTooltipDiv'>";
            html += $"<p><b>{performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel}</b></p>";
            html += "<table class='table table-striped googleTooltipTable'>";
            foreach (KeyValuePair<string, double> calendarReportedYearValue in calendarReportedYearValuesDictionary)
            {
                var formattedValue = calendarReportedYearValue.Value.ToString($"#,###,###,##0.{stringPrecision}");


                html += $"<tr><td>{calendarReportedYearValue.Key}</td><td style='text-align: right'><b>{prefix ?? String.Empty}{formattedValue} {performanceMeasureMeasurementUnitType.LegendDisplayName ?? String.Empty}</b></td></tr>";
            }

            var formattedTotal = calendarReportedYearValuesDictionary.Sum(x => x.Value).ToString($"#,###,###,##0.{stringPrecision}");
            html += $"<tr class='googleTooltipTableTotalRow'><td>Total</td><td style='text-align: right'><b>{prefix ?? String.Empty}{formattedTotal} {performanceMeasureMeasurementUnitType.LegendDisplayName ?? String.Empty}</b></td></tr>";
            if (targetValue.HasValue && !string.IsNullOrWhiteSpace(targetValueDescription))
            {
                var formattedTarget = targetValue.Value.ToString($"#,###,###,##0.{stringPrecision}");
                html += $"<tr class='googleTooltipTableTotalRow'><td>{targetValueDescription}</td><td style='text-align: right'><b>{prefix ?? String.Empty}{formattedTarget} {performanceMeasureMeasurementUnitType.LegendDisplayName ?? String.Empty}</b></td></tr>";
            }
            html += "</table></div>";

            return html;
        }
    }
}