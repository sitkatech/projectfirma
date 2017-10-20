/*-----------------------------------------------------------------------
<copyright file="GoogleChartJson.cs" company="Tahoe Regional Planning Agency">
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
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartJson
    {
        [JsonProperty(PropertyName = "legendTitle")]
        public string LegendTitle { get; set; }
        [JsonProperty(PropertyName = "containerId")]
        // ReSharper disable once InconsistentNaming
        public string ChartContainerID { get; set; }
        [JsonProperty(PropertyName = "options")]
        public GoogleChartConfiguration GoogleChartConfiguration { get; set; }
        [JsonProperty(PropertyName = "chartType")]
        public string ChartType { get; set; }
        [JsonProperty(PropertyName = "dataTable")]
        public GoogleChartDataTable GoogleChartDataTable { get; set; }

        public string SaveConfigurationUrl { get; set; }

        public List<string> ChartColumns { get; set; }

        public bool HasData()
        {
            return GoogleChartDataTable?.GoogleChartColumns != null && GoogleChartDataTable.GoogleChartColumns.Count > 1 && GoogleChartDataTable.GoogleChartRowCs != null && GoogleChartDataTable.GoogleChartRowCs.Any();
        }

        public GoogleChartJson()
        {
        }

        //Used where chartConfiguration comes as a GoogleChartConfiguration object
        public GoogleChartJson(string legendTitle,
            string chartContainerID,
            GoogleChartConfiguration googleChartConfiguration,
            GoogleChartType googleChartType,
            GoogleChartDataTable googleChartDataTable,
            string optionalSaveConfigurationUrl,
            List<string> chartColumns)
        {
            LegendTitle = legendTitle;
            ChartContainerID = chartContainerID;
            GoogleChartConfiguration = googleChartConfiguration;
            ChartColumns = chartColumns;

            ChartType = googleChartType.GoogleChartTypeDisplayName;
            GoogleChartDataTable = googleChartDataTable;
            SaveConfigurationUrl = optionalSaveConfigurationUrl;
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
                return $"{actualValue:F2}%";
            }
            if (measurementUnitType == MeasurementUnitType.Dollars)
            {
                return actualValue.ToString("C0");
            }
            var unitLabel = measurementUnitType.LegendDisplayName == null ? String.Empty : $" {measurementUnitType.LegendDisplayName}";
            return $"{actualValue.ToString(CultureInfo.InvariantCulture)}{unitLabel}";
        }
    }
}
