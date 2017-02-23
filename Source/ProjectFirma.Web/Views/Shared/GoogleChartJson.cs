/*-----------------------------------------------------------------------
<copyright file="GoogleChartJson.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Globalization;
using System.Linq;
using ProjectFirma.Web.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartJson
    {
        [JsonProperty(PropertyName = "legendTitle")]
        public string LegendTitle { get; set; }
        public string ChartName { get; set; }
        [JsonProperty(PropertyName = "containerId")]
        private string _containerID { get; set; } //Must be the same as ChartName
        [JsonProperty(PropertyName = "options")]
        public GoogleChartConfiguration GoogleChartConfiguration { get; set; }
        [JsonProperty(PropertyName = "chartType")]
        public string ChartType { get; set; }
        [JsonProperty(PropertyName = "dataTable")]
        public GoogleChartDataTable GoogleChartDataTable { get; set; }
        [JsonProperty(PropertyName = "groupId")]
        public string ChartGroupID;

        public string ChartPopupUrl { get; set; }
        public string SaveConfigurationUrl { get; set; }

        public bool HasData()
        {
            return GoogleChartDataTable != null && GoogleChartDataTable.GoogleChartColumns != null && GoogleChartDataTable.GoogleChartColumns.Count > 1 && GoogleChartDataTable.GoogleChartRowCs != null &&
                   GoogleChartDataTable.GoogleChartRowCs.Count > 0;
        }

        public GoogleChartJson()
        {
        }

        //Used where chartConfiguration comes as a GoogleChartConfiguration object
        public GoogleChartJson(string legendTitle,
            string chartName,
            GoogleChartConfiguration googleChartConfiguration,
            GoogleChartType googleChartType,
            GoogleChartDataTable googleChartDataTable,
            string chartPopupUrl,
            string chartGroupID,
            string optionalSaveConfigurationUrl)
        {
            LegendTitle = legendTitle;
            ChartName = chartName;
            _containerID = chartName;
            GoogleChartConfiguration = googleChartConfiguration;
            GoogleChartConfiguration.LoadDataAndFormat(googleChartType, googleChartDataTable);
            switch (googleChartType)
            {
                case GoogleChartType.ColumnChart:
                    ChartType = googleChartDataTable.GoogleChartColumns.Any(x => x.ColumnDisplayType != GoogleChartType.ColumnChart) ? "ComboChart" : "ColumnChart";
                    break;
                case GoogleChartType.LineChart:
                    ChartType = googleChartDataTable.GoogleChartColumns.Any(x => x.ColumnDisplayType != GoogleChartType.LineChart) ? "ComboChart" : "LineChart";
                    break;
                case GoogleChartType.AreaChart:
                    ChartType = "AreaChart";
                    break;
                case GoogleChartType.ComboChart:
                    ChartType = "ComboChart";
                    break;
                case GoogleChartType.PieChart:
                    ChartType = "PieChart";
                    break;
                case GoogleChartType.ImageChart:
                    ChartType = "ImageChart";
                    break;
                case GoogleChartType.BarChart:
                    ChartType = "BarChart";
                    break;
                case GoogleChartType.Histogram:
                    ChartType = "Histogram";
                    break;
                case GoogleChartType.BubbleChart:
                    ChartType = "BubbleChart";
                    break;
                //case GoogleChartType.ScatterChart:
                //    ChartType = "ScatterChart";
                //    break;
                default:
                    throw new ArgumentOutOfRangeException("googleChartType", googleChartType, null);
            }
            GoogleChartDataTable = googleChartDataTable;
            ChartPopupUrl = chartPopupUrl;
            SaveConfigurationUrl = optionalSaveConfigurationUrl;
            ChartGroupID = chartGroupID;
        }

        public static string GetFormattedValue(double? value, MeasurementUnitType measurementUnitType)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var actualValue = value.Value;
            if (measurementUnitType == MeasurementUnitType.Percent)
            {
                return string.Format("{0}%", actualValue.ToString("F2"));
            }
            if (measurementUnitType == MeasurementUnitType.Dollars)
            {
                return actualValue.ToString("C0");
            }
            var unitLabel = measurementUnitType.LegendDisplayName == null ? String.Empty : String.Format(" {0}", measurementUnitType.LegendDisplayName);
            return string.Format("{0}{1}", actualValue.ToString(CultureInfo.InvariantCulture), unitLabel);
        }
    }
}
