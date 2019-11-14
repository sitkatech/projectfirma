using System;
using System.Collections.Generic;
using ProjectFirmaModels.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartSeries
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "targetAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int? TargetAxisIndex { get; set; }

        [JsonProperty(PropertyName = "lineWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int? LineWidth { get; set; }
        [JsonProperty(PropertyName = "pointSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? PointSize { get; set; }

        [JsonProperty(PropertyName = "enableInteractivity", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableInteractivity { get; set; }

        //default constructor for serialization, otherwise it will get "creative" with default values...
        public GoogleChartSeries()
        {            
            TargetAxisIndex = null;
        }

        public GoogleChartSeries(GoogleChartType googleChartType, GoogleChartAxisType googleChartAxisType, string color, int? lineWidth, int? pointSize) 
        {
            Type = googleChartType.SeriesDataDisplayType;
            GetTargetAxisIndex(googleChartAxisType);
            Color = color;
            LineWidth = lineWidth;
            PointSize = pointSize;
        }


        public GoogleChartSeries(GoogleChartType googleChartType, GoogleChartAxisType googleChartAxisType)
        {
            Type = googleChartType.SeriesDataDisplayType;
            GetTargetAxisIndex(googleChartAxisType);
            LineWidth = 2;
        }

        private void GetTargetAxisIndex(GoogleChartAxisType googleChartAxisType)
        {
            switch (googleChartAxisType)
            {
                case GoogleChartAxisType.Primary:
                    TargetAxisIndex = null;
                    break;
                case GoogleChartAxisType.Secondary:
                    TargetAxisIndex = 1;
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(googleChartAxisType), googleChartAxisType, null);
            }
        }

        public static List<GoogleChartSeries> GetGoogleChartSeriesForChartsWithTargets()
        {
            var chartSeries = new List<GoogleChartSeries>
            {
                new GoogleChartSeries(GoogleChartType.LineChart, GoogleChartAxisType.Primary),
                new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary)
            };
            return chartSeries;
        }
    }
}