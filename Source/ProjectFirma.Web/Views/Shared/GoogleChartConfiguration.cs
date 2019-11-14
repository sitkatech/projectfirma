/*-----------------------------------------------------------------------
<copyright file="GoogleChartConfiguration.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartConfiguration
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "titlePosition")]
        public string TitlePosition { get; set; }

        [JsonProperty(PropertyName = "legend")]
        public GoogleChartLegend Legend { get; set; }

        [JsonProperty(PropertyName = "chartArea", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartConfigurationArea ChartArea { get; set; }

        [JsonProperty(PropertyName = "hAxis")]
        public GoogleChartAxis HorizontalAxis { get; set; }

        [JsonProperty(PropertyName = "vAxes")]
        public List<GoogleChartAxis> VerticalAxes { get; set; }

        [JsonProperty(PropertyName = "series")]
        public object Series { get; set; } // if it's combo chart, we have List<GoogleChartSeries>; if non combochart, we have Dictionary<string, GoogleChartSeries>

        [JsonProperty(PropertyName = "backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartBackground BackgroundColor { get; set; }

        [JsonProperty(PropertyName = "domainAxis", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartDomainAxis ChartDirection { get; set; }

        [JsonProperty(PropertyName = "legendTextStyle")]
        public GoogleChartTextStyle LegendTextStyle { get; set; }

        [JsonProperty(PropertyName = "titleTextStyle")]
        public GoogleChartTextStyle TitleTextStyle { get; set; }

        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }

        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }

        [JsonProperty(PropertyName = "isStacked")]
        public bool IsStacked { get; set; }

        [JsonProperty(PropertyName = "focusTarget")]
        public string FocusTarget { get; set; }

        [JsonProperty(PropertyName = "tooltip")]
        public GoogleChartTooltip Tooltip { get; set; }

        [JsonProperty(PropertyName = "curveType")]
        public string CurveType { get; set; }

        [JsonProperty(PropertyName = "lineWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int LineWidth { get; set; }

        [JsonProperty(PropertyName = "annotations", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartAnnotations Annotations { get; set; }

        [JsonProperty(PropertyName = "seriesType")]
        public string SeriesType { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string GoogleChartType { get; set; }

        [JsonProperty(PropertyName = "connectSteps")]
        public bool ConnectSteps { get; set; }

        [JsonProperty(PropertyName = "theme")]
        public string Theme { get; set; }

        [JsonProperty(PropertyName = "areaOpacity", NullValueHandling = NullValueHandling.Ignore)]
        public double? AreaOpacity { get; set; }

        [JsonProperty(PropertyName = "enableInteractivity", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableInteractivity { get; set; }

        //For Deserialization
        public GoogleChartConfiguration()
        {
        }

        /// <summary>
        /// This is the constructor used by non-database-persisted charts <see cref="MonitoringStation.AverageDailyFlowAndCumulativePrecipitationSummaryGoogleChart()"/>
        /// </summary>
        public GoogleChartConfiguration(string chartTitle, bool isStacked, GoogleChartType googleChartType, GoogleChartDataTable googleChartDataTable, GoogleChartAxis googleChartAxisHorizontal, List<GoogleChartAxis> googleChartAxisVerticals)
        {
            Title = string.IsNullOrWhiteSpace(chartTitle) ? "[MISSING CHART TITLE]" : chartTitle;
            
            Legend = new GoogleChartLegend();
            HorizontalAxis = googleChartAxisHorizontal;
            VerticalAxes = googleChartAxisVerticals;

            BackgroundColor = new GoogleChartBackground("white");
            IsStacked = isStacked;
            LineWidth = 2;

            SetChartMetaData(googleChartType);
            var dictionary = new Dictionary<string, GoogleChartSeries>();
            var googleChartSeries = googleChartDataTable.GoogleChartColumns.Select(x => x.GoogleChartSeries).ToList();
            for (var i = 0; i < googleChartSeries.Count; i++)
            {
                dictionary.Add(i.ToString(), googleChartSeries[i]);
            }

            Series = dictionary;

            Annotations = new GoogleChartAnnotations();
        }

        /// <summary>
        /// This is the constructor used by <see cref="PerformanceMeasureModelExtensions.GetDefaultPerformanceMeasureChartConfigurationJson()"/> for creating a default google chart configuration json for new performance measures
        /// </summary>
        public GoogleChartConfiguration(string chartTitle, bool isStacked, GoogleChartType googleChartType, GoogleChartAxis googleChartAxisHorizontal, List<GoogleChartAxis> googleChartAxisVerticals)
        {
            Title = string.IsNullOrWhiteSpace(chartTitle) ? "[MISSING CHART TITLE]" : chartTitle;

            Legend = new GoogleChartLegend();
            HorizontalAxis = googleChartAxisHorizontal;
            VerticalAxes = googleChartAxisVerticals;

            BackgroundColor = new GoogleChartBackground("white");
            IsStacked = isStacked;
            LineWidth = 2;

            SetChartMetaData(googleChartType);

            Annotations = new GoogleChartAnnotations();
        }

        /// <summary>
        /// This is the constructor used by <see cref="PerformanceMeasureModelExtensions.GetTargetsPerformanceMeasureChartConfigurationJson()"/> for creating a default google chart configuration json for new performance measures with targets
        /// </summary>
        public GoogleChartConfiguration(string chartTitle, bool isStacked, GoogleChartType googleChartType, GoogleChartAxis googleChartAxisHorizontal, List<GoogleChartAxis> googleChartAxisVerticals, string seriesType, object series)
        {
            Title = string.IsNullOrWhiteSpace(chartTitle) ? "[MISSING CHART TITLE]" : chartTitle;

            Legend = new GoogleChartLegend();
            HorizontalAxis = googleChartAxisHorizontal;
            VerticalAxes = googleChartAxisVerticals;

            BackgroundColor = new GoogleChartBackground("white");
            IsStacked = isStacked;
            LineWidth = 2;

            SeriesType = seriesType;
            Series = series;

            SetChartMetaData(googleChartType);

            Annotations = new GoogleChartAnnotations();
        }

        /// <summary>
        /// static method for creating a GoogleChartConfiguration from a json object
        /// </summary>
        /// <param name="json">JSON object that stores a GoogleChartConfiguration</param>
        public static GoogleChartConfiguration GetGoogleChartConfigurationFromJsonObject(string json)
        {
            return JsonConvert.DeserializeObject<GoogleChartConfiguration>(json);
        }

        private void SetChartMetaData(GoogleChartType googleChartType)
        {
            //Never show title
            TitlePosition = "none";

            if (googleChartType == ProjectFirmaModels.Models.GoogleChartType.PieChart)
            {
                Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            }
            else
            {
                Legend.SetLegendPosition(GoogleChartLegendPosition.Top);
                Legend.MaxLines = 3;
            }

            //Makes it so that the tooltip shows all items, not just the selected one
            FocusTarget = "category";
        }

        public void SanitizeForSaving()
        {
            ChartArea = null;
        }

        public void SetSeriesIgnoringNullGoogleChartSeries(GoogleChartDataTable googleChartDataTable)
        {
            var dictionary = new Dictionary<string, GoogleChartSeries>();
            var googleChartSeries = googleChartDataTable.GoogleChartColumns.Where(x => x.GoogleChartSeries != null).Select(x => x.GoogleChartSeries).ToList();
            for (var i = 0; i < googleChartSeries.Count; i++)
            {
                dictionary.Add(i.ToString(), googleChartSeries[i]);
            }
            Series = dictionary;
        }
    }
}
