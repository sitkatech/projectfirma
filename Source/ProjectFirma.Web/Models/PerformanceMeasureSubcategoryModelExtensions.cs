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
        public static List<GoogleChartJson> MakeGoogleChartJsons(PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea, List<ProjectPerformanceMeasureReportingPeriodValue> projectPerformanceMeasureReportingPeriodValues)
        {
            var performanceMeasureSubcategoryOptionReportedValues = projectPerformanceMeasureReportingPeriodValues.SelectMany(x => x.PerformanceMeasureSubcategoryOptionReportedValues).GroupBy(x => x.PerformanceMeasureSubcategory);
            // This was changed to only use the performance measure reporting period from the actuals. Requested in PF#1901: https://projects.sitkatech.com/projects/projectfirma/cards/1901
            var performanceMeasureReportingPeriods = performanceMeasure.GetPerformanceMeasureReportingPeriodsFromActuals();
            var googleChartJsons = new List<GoogleChartJson>();

            bool hasTargets = performanceMeasure.HasTargets();
            bool hasGeospatialAreaTargets = false;
            if (geospatialArea != null)
            {
                hasGeospatialAreaTargets = performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea) != PerformanceMeasureTargetValueType.NoTarget;
            }

            if (performanceMeasureSubcategoryOptionReportedValues.Any())
            { 
                foreach (var groupedBySubcategory in performanceMeasureSubcategoryOptionReportedValues.Where(x => x.Key.ShowOnChart()))
                {
                    var performanceMeasureSubcategory = groupedBySubcategory.Key;
                    Check.RequireNotNull(performanceMeasureSubcategory.ChartConfigurationJson, "All PerformanceMeasure Subcategories need to have a Google Chart Configuration Json");
                    var groupedBySubcategoryOption = groupedBySubcategory.GroupBy(c => new Tuple<string, int>(c.ChartName, c.SortOrder)).ToList(); // Item1 is ChartName, Item2 is SortOrder
                    var chartColumns = performanceMeasure.HasRealSubcategories() ? groupedBySubcategoryOption.OrderBy(x => x.Key.Item2).Select(x => x.Key.Item1).ToList() : new List<string> { performanceMeasure.GetDisplayName() };
                    
                    var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;

                    var googleChartDataTable = GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasure, performanceMeasureReportingPeriods, hasTargets, hasGeospatialAreaTargets, geospatialArea, groupedBySubcategoryOption, chartColumns, performanceMeasure.IsSummable, reverseTooltipOrder, false);
                    var legendTitle = performanceMeasure.HasRealSubcategories() ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : performanceMeasure.GetDisplayName();
                    var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}";
                    var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x =>
                        x.SaveChartConfiguration(performanceMeasure,
                            performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration.ChartConfiguration));
                    var resetConfigurationUrl =
                        SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x =>
                            x.ResetChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration.ChartConfiguration));
                    GoogleChartConfiguration chartConfiguration;
                    GoogleChartType chartType;
                    if (hasGeospatialAreaTargets)
                    {
                        chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.GeospatialAreaTargetChartConfigurationJson);
                        chartType = performanceMeasureSubcategory.GeospatialAreaTargetGoogleChartType;
                    }
                    else
                    {
                        chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.ChartConfigurationJson);
                        chartType = performanceMeasureSubcategory.GoogleChartType;
                    }
                    if (performanceMeasureSubcategory.PerformanceMeasure.IsSummable)
                    {
                        chartConfiguration.Tooltip = new GoogleChartTooltip(true);
                    }

                    chartConfiguration.Series =
                        GoogleChartSeries.CalculateChartSeriesFromCurrentChartSeries(chartConfiguration.Series,
                            performanceMeasure, geospatialArea);

                    var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration,
                        chartType, googleChartDataTable,
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

                        var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;
                        var googleChartDataTable = GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasure, performanceMeasureReportingPeriods, hasTargets, hasGeospatialAreaTargets, geospatialArea, groupedBySubcategoryOption, chartColumns, performanceMeasure.IsSummable, reverseTooltipOrder, true);
                        var legendTitle = performanceMeasure.HasRealSubcategories() ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : performanceMeasure.GetDisplayName();
                        var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}Cumulative";
                        var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration.CumulativeConfiguration));
                        var resetConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.ResetChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration.CumulativeConfiguration));
                        var chartConfiguration = !string.IsNullOrEmpty(performanceMeasureSubcategory.CumulativeChartConfigurationJson) ? JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.CumulativeChartConfigurationJson) : GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(performanceMeasureSubcategory.ChartConfigurationJson);

                        if (performanceMeasureSubcategory.PerformanceMeasure.IsSummable)
                        {
                            chartConfiguration.Tooltip = new GoogleChartTooltip(true);
                        }

                        chartConfiguration.Series =
                            GoogleChartSeries.CalculateChartSeriesFromCurrentChartSeries(chartConfiguration.Series,
                                performanceMeasure, geospatialArea);
                        
                        var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, performanceMeasureSubcategory.CumulativeGoogleChartType ?? GoogleChartType.ColumnChart, googleChartDataTable, chartColumns, saveConfigurationUrl, resetConfigurationUrl, true);
                        googleChartJsons.Add(googleChartJson);
                    }
                }
            }
            else if(performanceMeasure.HasTargets())
            {
                //build chart for just for targets if there is no project data
                var performanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.First();
                var legendTitle = performanceMeasure.GetDisplayName();
                var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}";
                var chartConfiguration = performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson();
                chartConfiguration.Series =
                    GoogleChartSeries.CalculateChartSeriesFromCurrentChartSeries(chartConfiguration.Series,
                        performanceMeasure, geospatialArea);
                var chartColumns = new List<string> { performanceMeasure.GetDisplayName() };
                var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;
                var googleChartDataTable = GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(performanceMeasure, performanceMeasureReportingPeriods, true, false, null, new List<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>>(), chartColumns, false, reverseTooltipOrder, false);
                var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration.CumulativeConfiguration));
                var resetConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.ResetChartConfiguration(performanceMeasure, performanceMeasureSubcategory.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration.CumulativeConfiguration));

                var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, GoogleChartType.LineChart, googleChartDataTable, chartColumns, saveConfigurationUrl, resetConfigurationUrl, false);
                googleChartJsons.Add(googleChartJson);
            }

            return googleChartJsons;
        }

        public static GoogleChartDataTable GetGoogleChartDataTableWithReportingPeriodsAsHorizontalAxis(PerformanceMeasure performanceMeasure,
                                           ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods,
                                           bool hasTargets,
                                           bool hasGeospatialAreaTargets,
                                           GeospatialArea geospatialArea,
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
                var targetValue = performanceMeasureReportingPeriod.GetTargetValue(performanceMeasure);
                var geospatialAreaTargetValue = hasGeospatialAreaTargets ? performanceMeasureReportingPeriod.GetGeospatialAreaTargetValue(performanceMeasure, geospatialArea) : null;

                if (hasToolTipWithTotal)
                {
                    var targetValueDescription = performanceMeasureReportingPeriod.GetTargetValueLabel(performanceMeasure);
                    var geospatialAreaTargetValueDescription = hasGeospatialAreaTargets ? performanceMeasureReportingPeriod.GetGeospatialAreaTargetValueLabel(performanceMeasure, geospatialArea) : string.Empty;

                    var formattedDataTooltip = FormattedDataTooltip(groupedBySubcategoryOption, performanceMeasureReportingPeriod, performanceMeasure.MeasurementUnitType, reverseTooltipOrder, targetValue, targetValueDescription, geospatialAreaTargetValue, geospatialAreaTargetValueDescription, showCumulativeResults, firstReportingPeriod);

                    googleChartRowVs.Add(new GoogleChartRowV(null, formattedDataTooltip));
                }
                if (hasTargets)
                {
                    googleChartRowVs.Add(new GoogleChartRowV(targetValue, GetFormattedTargetValue(performanceMeasureReportingPeriod, performanceMeasure)));
                }

                if (hasGeospatialAreaTargets)
                {
                    
                    googleChartRowVs.Add(new GoogleChartRowV(geospatialAreaTargetValue, GetFormattedGeospatialAreaTargetValue(performanceMeasureReportingPeriod, performanceMeasure, geospatialArea)));
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
                googleChartColumns.Add(new GoogleChartColumn(GetTargetColumnLabel(performanceMeasure), GoogleChartColumnDataType.Number));
            }
            if (hasGeospatialAreaTargets)
            {
                // GoogleChartType for targets is always LINE; we also always render the target line first to stay consistent
                googleChartColumns.Add(new GoogleChartColumn(GetGeospatialAreaTargetColumnLabel(performanceMeasure, geospatialArea), GoogleChartColumnDataType.Number));
            }
            // all the subcategory option values are individual columns and series and they will be on the vertical axis
            googleChartColumns.AddRange(chartColumns.Select(x => new GoogleChartColumn(x, GoogleChartColumnDataType.Number)));

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        private static string GetTargetColumnLabel(PerformanceMeasure performanceMeasure)
        {
            var isOverallTarget = performanceMeasure.GetTargetValueType() ==
                                  PerformanceMeasureTargetValueType.OverallTarget;
            return isOverallTarget ? performanceMeasure.PerformanceMeasureOverallTargets.First().PerformanceMeasureTargetValueLabel : "Target";
        }

        private static string GetGeospatialAreaTargetColumnLabel(PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            var isOverallTarget = performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea) == PerformanceMeasureTargetValueType.OverallTarget;
            string response = isOverallTarget ? performanceMeasure.GeospatialAreaPerformanceMeasureOverallTargets.First(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).GeospatialAreaPerformanceMeasureTargetValueLabel : "Geospatial Area Target";
            return response;
        }

        private static string GetFormattedTargetValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return $"{GoogleChartJson.GetFormattedValue(performanceMeasureReportingPeriod.GetTargetValue(performanceMeasure), performanceMeasure.MeasurementUnitType)} ({performanceMeasureReportingPeriod.GetTargetValueLabel(performanceMeasure)})";
        }

        private static string GetFormattedGeospatialAreaTargetValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea)
        {
            return $"{GoogleChartJson.GetFormattedValue(performanceMeasureReportingPeriod.GetGeospatialAreaTargetValue(performanceMeasure, geospatialArea), performanceMeasure.MeasurementUnitType)} ({performanceMeasureReportingPeriod.GetGeospatialAreaTargetValueLabel(performanceMeasure, geospatialArea)})";
        }

        public static string FormattedDataTooltip(IReadOnlyCollection<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>> groupedBySubcategoryOption, 
                                                  PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, 
                                                  MeasurementUnitType performanceMeasureMeasurementUnitType, 
                                                  bool reverseTooltipOrder,
                                                  double? targetValue,
                                                  string targetValueDescription,
                                                  double? geospatialAreaTargetValue,
                                                  string geospatialAreaTargetValueDescription,
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
                    x.Where<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>(pmrp => pmrp.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear <=
                                     performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                        .Sum(pmrp => pmrp.ReportedValue) ?? 0;
                } else
                {
                    calendarYearReportedValue =
                        x.Where<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>(pmrp => pmrp.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear ==
                                         performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                            .Sum(pmrp => pmrp.ReportedValue) ?? 0;
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
            if (geospatialAreaTargetValue.HasValue && !string.IsNullOrWhiteSpace(geospatialAreaTargetValueDescription))
            {
                var formattedTarget = geospatialAreaTargetValue.Value.ToString($"#,###,###,##0.{stringPrecision}");
                html += $"<tr class='googleTooltipTableTotalRow'><td>{geospatialAreaTargetValueDescription}</td><td style='text-align: right'><b>{prefix ?? String.Empty}{formattedTarget} {performanceMeasureMeasurementUnitType.LegendDisplayName ?? String.Empty}</b></td></tr>";
            }
            html += "</table></div>";

            return html;
        }
    }
}