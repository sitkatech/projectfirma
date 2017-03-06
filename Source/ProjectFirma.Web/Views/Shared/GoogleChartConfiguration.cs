/*-----------------------------------------------------------------------
<copyright file="GoogleChartConfiguration.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared
{
    public enum GoogleChartType
    {
        ColumnChart,
        LineChart,
        ComboChart,
        AreaChart,
        PieChart,
        ImageChart,
        BarChart,
        Histogram,
        BubbleChart,
        ScatterChart
    }

    public enum GoogleChartAxisType
    {
        Primary,
        Secondary
    }

    public enum GoogleChartLegendPosition
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    public enum GoogleChartScaleFactor
    {
        None,
        Thousands,
        Millions
    }

    public class GooglePieChartConfiguration : GoogleChartConfiguration
    {
        [JsonProperty(PropertyName = "slices")]
        public Dictionary<int, GooglePieChartSlice> Slices { get; set; }
        [JsonProperty(PropertyName = "pieSliceTextStyle")]
        public GoogleChartTextStyle PieSliceTextStyle { get; set; }
        [JsonProperty(PropertyName = "pieSliceText")]
        public string PieSliceText { get; set; }

        public GooglePieChartConfiguration(string chartTitle, MeasurementUnitType measurementUnitType, int height, int width)
            : base(chartTitle, string.Empty, measurementUnitType)
        {
            PieSliceTextStyle = new GoogleChartTextStyle("black");
            SetSize(height, width);
        }
    }

    public class GooglePieChartSlice
    {
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        public string ValueKey { get; set; }
    }

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
        public List<GoogleChartSeries> Series { get; set; }
        [JsonProperty(PropertyName = "backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartBackground Background { get; set; }
        [JsonProperty(PropertyName = "domainAxis", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartDomainAxis ChartDirection { get; set; }

        [JsonProperty(PropertyName = "legendTextStyle")]
        public GoogleChartTextStyle LegendTextStyle { get; set; }
        [JsonProperty(PropertyName = "titleTextStyle")]
        public GoogleChartTextStyle TitleTextStyle { get; set; }

        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; private set; }
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; private set; }

        [JsonProperty(PropertyName = "isStacked")]
        public bool IsStacked { get; set; }
        [JsonProperty(PropertyName = "focusTarget")]
        public string FocusTarget { get; set; }
        [JsonProperty(PropertyName = "curveType")]
        public string CurveType { get; set; }
        [JsonProperty(PropertyName = "lineWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int LineWidth { get; set; }

        [JsonIgnore]
        protected GoogleChartDataTable DataTable { get; set; }
        [JsonIgnore]
        protected GoogleChartType ChartType { get; set; }

        //For Deserialization
        public GoogleChartConfiguration()
        {
        }

        public GoogleChartConfiguration(string chartTitle, string axisTitle, MeasurementUnitType measurementUnitType)
        {
            Title = string.IsNullOrWhiteSpace(chartTitle) ? "[MISSING CHART TITLE]" : chartTitle;

            //Create objects
            Legend = new GoogleChartLegend();
            HorizontalAxis = new GoogleChartAxis("Year", null);
            VerticalAxes = new List<GoogleChartAxis>() { new GoogleChartAxis(axisTitle, measurementUnitType) };

            //Default behviors
            Background = new GoogleChartBackground("white");
            IsStacked = true;
            LineWidth = 2;
        }

        public void LoadDataAndFormat(GoogleChartType chartType, GoogleChartDataTable googleChartDataTable)
        {
            if (googleChartDataTable == null)
            {
                throw new ArgumentException("DataTable cannot be null");
            }

            ChartType = chartType; //This must come before LoadDataTableAndCreateSeries
            DataTable = googleChartDataTable;

            //Ensure Series object exists, and populate any missing series (seems safe to assume that in the rare cases we are missing series, the existing ones are in order)
            if (Series == null)
            {
                Series = new List<GoogleChartSeries>();
            }
            if (Series.Count != DataTable.GoogleChartColumns.Count - 1)
            {
                var existingSeriesCount = Series.Count;
                foreach (var x in DataTable.GoogleChartColumns.Skip(1 + existingSeriesCount))
                {
                    Series.Add(new GoogleChartSeries(x.ColumnDisplayType, x.AxisType));
                }
            }

            //Clear series types for non-ComboChart views (otherwise the ChartEditor won't preview type changes)
            if (ChartType != GoogleChartType.ComboChart)
            {
                foreach (var series in Series)
                {
                    series.Type = null;
                }
            }
            else
            {
                foreach (var series in Series)
                {
                    //for ComboCharts, we have to have an explicit type, and it will often be null due to the previous branch
                    if (series.Type == null)
                    {
                        series.Type = "line";
                    }

                    if (series.LineWidth == null)
                    {
                        series.LineWidth = 2;
                    }
                }
            }

            //Never show title
            TitlePosition = "none";

            if (Legend == null)
            {
                Legend = new GoogleChartLegend();
            }

            if (DataTable.GoogleChartColumns.Count < 3)
                Legend.SetLegendPosition(GoogleChartLegendPosition.None);
            else
            {
                Legend.SetLegendPosition(GoogleChartLegendPosition.Top);
                Legend.MaxLines = 3;
            }

            //Manually adjust fonts
            LegendTextStyle = new GoogleChartTextStyle();
            LegendTextStyle.FontSize = 11;
            TitleTextStyle = new GoogleChartTextStyle();
            TitleTextStyle.FontSize = 16;

            //Makes it so that the tooltip shows all items, not just the selected one
            FocusTarget = "category";

            //Null checking since pie charts can lack axes
            if (VerticalAxes != null)
            {
                foreach (var vaxis in VerticalAxes)
                {
                    vaxis.FormatOptions.SetScaleFactor(GetMaximumValue());
                }
            }
        }

        public void MakeBig()
        {
            var fontSizeIncrease = 8;

            Height = 670;
            Width = 1100;

            TitlePosition = "top";

            //Enlarge font, and bold axis text
            LegendTextStyle.FontSize += fontSizeIncrease;
            TitleTextStyle.FontSize += fontSizeIncrease;
            HorizontalAxis.TextStyle.FontSize += fontSizeIncrease;
            HorizontalAxis.TextStyle.MakeBold();

            //Can be null for pie charts
            if (VerticalAxes != null)
            {
                foreach (var vaxis in VerticalAxes)
                {
                    vaxis.TextStyle.FontSize += fontSizeIncrease;
                    vaxis.TextStyle.MakeBold();
                }
            }

            //Make lines thicker on Line and Combo charts (but NOT on area charts)
            if (ChartType != GoogleChartType.AreaChart)
            {
                LineWidth = 6;
            }

            //Since PieCharts are square, we have plenty of side area and this will always be the ideal legend placement
            if (ChartType == GoogleChartType.PieChart)
            {
                Legend.Position = "labeled";
            }

            CalculateMargins(true);
        }

        public void SetSize(int height, int width)
        {
            Height = height;
            Width = width;
            CalculateMargins(false);
        }

        public void SanitizeForSaving()
        {
            Height = null;
            Width = null;
            ChartArea = null;
        }

        protected void CalculateMargins(bool isBig)
        {
            if (Height == null || Width == null || DataTable == null)
            {
                return;
            }

            var left = (isBig) ? 60 : 10;
            var right = HasSecondVaxis() ? GetVaxisLength() * LegendTextStyle.FontSize : 20;
            var top = (isBig) ? 60 : 10;
            var bottom = (Legend.Position == "none") ? 60 : (int)(LegendTextStyle.FontSize * GetHaxisLength() * 0.33);

            if (ChartType != GoogleChartType.PieChart)
            {
                left += (int)(LegendTextStyle.FontSize * Math.Max(GetVaxisLength(), GetHaxisLength() * 0.4));
            }

            //Enforce minimum values for algorithmic sizes
            if (isBig)
            {
                right = Math.Max(right, 60);
                bottom = Math.Max(bottom, 60);
            }
            else
            {
                bottom = Math.Max(bottom, 60);
            }

            //Add space for legend
            switch (Legend.Position)
            {
                case "top":
                    Legend.MaxLines = 3;
                    top += 50;
                    break;
                case "bottom":
                    bottom += 50;
                    break;
                case "left":
                    throw new ArgumentException("Legend.Position = Left is not yet supported");
                case "right":
                    right += ((GetLegendLength() + 1) * LegendTextStyle.FontSize); //Add area for legend, as needed
                    right = (int)Math.Min(right, Width.Value * 0.33); //NEVER let the right side take up more than 33% (mostly occurs w/ long labels)
                    break;
                case "none":
                    break;
                case "labeled":
                    //Special: this overrides our minimums (above) since it only applies to Pie Charts and we don't have to worry about space for axes
                    left = 10;
                    right = 10;
                    break;
            }

            //Special cases which ignore minimums
            if (ChartType == GoogleChartType.PieChart && (Legend.Position == "labeled" || Legend.Position == "none"))
            {
                bottom = 10;
            }

            ChartArea = new GoogleChartConfigurationArea();
            ChartArea.Height = Height.Value - (top + bottom);
            ChartArea.Width = Width.Value - (left + right);
            ChartArea.Left = left;
            ChartArea.Top = top;
        }

        protected int GetHaxisLength()
        {
            //First column is the horizontal axis label
            return DataTable.GoogleChartRowCs.Select(row => row.GoogleChartRowVs.First().Value.ToString().Length).Concat(new[] { 0 }).Max();
        }

        protected int GetVaxisLength()
        {
            if (IsStacked)
            {
                var maximumValue = GetMaximumValue();
                if (VerticalAxes[0].FormatOptions.ScaleFactor != null)
                {
                    maximumValue /= VerticalAxes[0].FormatOptions.ScaleFactor.Value;
                }
                var vaxisLength = maximumValue.ToString().Length;

                //Especially small values need extra space ("0" will display as "0.0", which adds two characters)
                if (maximumValue < 10)
                {
                    vaxisLength += 2;
                }

                //If there's a scale prefix or suffice, we need to make space for those
                if (VerticalAxes[0].FormatOptions.Prefix != null)
                {
                    vaxisLength += VerticalAxes[0].FormatOptions.Prefix.Length;
                }
                if (VerticalAxes[0].FormatOptions.Suffix != null)
                {
                    vaxisLength += VerticalAxes[0].FormatOptions.Suffix.Length;
                }

                return vaxisLength + 2; //+1 to account for scale rounding up to next order of magnitude. The other +1 handles any unexpected edge cases
            }
            else
            {
                //Skip(1) because first column is the horizontal axis label
                return DataTable.GoogleChartRowCs.SelectMany(row => row.GoogleChartRowVs.Skip(1), (row, col) => col.Value.ToString().Length).Concat(new[] { 0 }).Max();
            }
        }

        protected Int64 GetMaximumValue()
        {
            //Skip(1) because first column is the horizontal axis label
            var largestRowTotal = DataTable.GoogleChartRowCs.Select(row => row.GoogleChartRowVs.Skip(1).Sum(col => Convert.ToInt64(col.Value))).Concat(new[] { (Int64)0 }).Max();
            return largestRowTotal;
        }

        protected int GetLegendLength()
        {
            //Skip(1) because first column is the horizontal axis label
            return DataTable.GoogleChartColumns.Skip(1).Select(col => col.ColumnLabel.Length).Concat(new[] { 0 }).Max();
        }

        protected bool HasSecondVaxis()
        {
            //Must have a second axis with a title (if there is a second axis WITHOUT a title, it just means "Swap Axes" was checked)
            if (VerticalAxes.Count > 1)
            {
                if (VerticalAxes[1].Title != null)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class GoogleChartBackground
    {
        [JsonProperty(PropertyName = "fill")]
        public string Color { get; set; }

        public GoogleChartBackground(string color)
        {
            Color = color;
        }
    }

    public class GoogleChartLegend
    {
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
        [JsonProperty(PropertyName = "maxLines", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxLines { get; set; }

        public void SetLegendPosition(GoogleChartLegendPosition? legendPosition)
        {
            switch (legendPosition)
            {
                case GoogleChartLegendPosition.Top:
                    Position = "top";
                    break;
                case GoogleChartLegendPosition.Bottom:
                    Position = "bottom";
                    break;
                case GoogleChartLegendPosition.Left:
                    Position = "left";
                    break;
                case GoogleChartLegendPosition.Right:
                    Position = "right";
                    break;
                case GoogleChartLegendPosition.None:
                    Position = "none";
                    break;
                default:
                    Position = null;
                    break;
            }
        }

        public static implicit operator string(GoogleChartLegend legend)
        {
            return legend.Position;
        }

        public static implicit operator GoogleChartLegend(string legend)
        {
            return new GoogleChartLegend() { Position = legend };
        }
    }

    public class GoogleChartConfigurationArea
    {
        [JsonProperty(PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "left", NullValueHandling = NullValueHandling.Ignore)]
        public int Left { get; set; }
        [JsonProperty(PropertyName = "top", NullValueHandling = NullValueHandling.Ignore)]
        public int Top { get; set; }
    }

    public class GoogleChartAxis
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "titleTextStyle")]
        public GoogleChartTextStyle TextStyle { get; set; }
        [JsonProperty(PropertyName = "useFormatFromData")]
        public bool UseFormatFromData { get; set; }
        [JsonProperty(PropertyName = "formatOptions", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartFormatOptions FormatOptions { get; set; }
        [JsonProperty(PropertyName = "viewWindow", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleChartViewWindow ViewWindow { get; set; }

        public GoogleChartAxis(string title, MeasurementUnitType unitType)
        {
            Title = title;
            TextStyle = new GoogleChartTextStyle();
            UseFormatFromData = true;
            FormatOptions = new GoogleChartFormatOptions(unitType);
            ViewWindow = new GoogleChartViewWindow();
        }
    }

    public class GoogleChartViewWindow
    {
        [JsonProperty(PropertyName = "min", NullValueHandling = NullValueHandling.Ignore)]
        public int MinValue { get; set; }
    }

    public class GoogleChartFormatOptions
    {
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }
        [JsonProperty(PropertyName = "prefix", NullValueHandling = NullValueHandling.Ignore)]
        public string Prefix { get; set; }
        [JsonProperty(PropertyName = "suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }
        [JsonProperty(PropertyName = "scaleFactor", NullValueHandling = NullValueHandling.Ignore)]
        public int? ScaleFactor { get; set; }

        public GoogleChartFormatOptions(MeasurementUnitType unitType)
        {
            if (unitType != null)
                Source = "inline";

            if (unitType == MeasurementUnitType.Dollars)
                Prefix = "$";
            else if (unitType == MeasurementUnitType.Percent)
                Suffix = "%";

            ScaleFactor = null;
        }

        public void SetScaleFactor(GoogleChartScaleFactor? scaleFactor)
        {
            switch (scaleFactor)
            {
                case GoogleChartScaleFactor.Thousands:
                    ScaleFactor = 1000;
                    Suffix = "K";
                    break;
                case GoogleChartScaleFactor.Millions:
                    ScaleFactor = 1000000;
                    Suffix = "M";
                    break;
                case GoogleChartScaleFactor.None:
                case null:
                default:
                    ScaleFactor = null;
                    break;
            }
        }

        public void SetScaleFactor(double maxValue)
        {
            if (maxValue > 1000 * 1000)
                SetScaleFactor(GoogleChartScaleFactor.Millions);
            else if (maxValue > 1000)
            {
                SetScaleFactor(GoogleChartScaleFactor.Thousands);
            }
            else
            {
                SetScaleFactor(GoogleChartScaleFactor.None);
            }
        }
    }

    public class GoogleChartTextStyle
    {
        [JsonProperty(PropertyName = "italic")]
        public bool IsItalic { get; set; }
        [JsonProperty(PropertyName = "color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }
        [JsonProperty(PropertyName = "fontName", NullValueHandling = NullValueHandling.Ignore)]
        public string FontName { get; set; }
        [JsonProperty(PropertyName = "fontSize")]
        public int FontSize { get; set; }
        [JsonProperty(PropertyName = "fontWidth")]
        public string FontWidth { get; set; }
        [JsonProperty(PropertyName = " fontWeight", NullValueHandling = NullValueHandling.Ignore)]
        public string FontWeight { get; set; }

        public GoogleChartTextStyle()
        {
            IsItalic = false;
            FontSize = 12;
            FontWidth = "normal";
        }

        public GoogleChartTextStyle(string color)
            : this()
        {
            Color = color;
        }

        public void MakeBold()
        {
            FontWeight = "bold";
        }
    }

    public class GoogleChartErrorBars
    {
        [JsonProperty(PropertyName = "errorType")]
        public string ErrorType { get; set; }
        [JsonProperty(PropertyName = "magnitude")]
        public int Magnitude { get; set; }
    }

    public class GoogleChartDomainAxis
    {
        [JsonProperty(PropertyName = "direction")]
        public int Direction { get; set; }

        public void SetToReversed()
        {
            Direction = -1;
        }

        public void SetToNormal()
        {
            Direction = 1;
        }
    }

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

        //default constructor for serialization, otherwise it will get "creative" with default values...
        public GoogleChartSeries()
        {
            TargetAxisIndex = null;
        }

        public GoogleChartSeries(GoogleChartType displayType, GoogleChartAxisType axisType)
        {
            Type = GoogleChartEnumConverter.GoogleChartTypeToString(displayType);

            switch (axisType)
            {
                case GoogleChartAxisType.Primary:
                    TargetAxisIndex = null;
                    break;
                case GoogleChartAxisType.Secondary:
                    TargetAxisIndex = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("axisType", axisType, null);
            }

            LineWidth = 2;
        }
    }

    public static class GoogleChartEnumConverter
    {
        public static string GoogleChartTypeToString(GoogleChartType googleChartType)
        {
            switch (googleChartType)
            {
                case GoogleChartType.ColumnChart:
                    return "bars";
                case GoogleChartType.LineChart:
                    return "line";
                case GoogleChartType.PieChart:
                    return "pie";
                case GoogleChartType.ComboChart:
                    return "line";
                case GoogleChartType.AreaChart:
                    return "area";
                case GoogleChartType.BarChart:
                    return "bars";
                //case GoogleChartType.ImageChart:
                //    break;
                //case GoogleChartType.Histogram:
                //    break;
                //case GoogleChartType.BubbleChart:
                //    break;
                //case GoogleChartType.ScatterChart:
                //    break;
                default:
                    throw new ArgumentOutOfRangeException("googleChartType", googleChartType, null);
            }
        }
    }

    public static class GoogleChartTypeExtension
    {
        public static GoogleChartType ParseOrDefault(string googleChartTypeString)
        {
            return string.IsNullOrEmpty(googleChartTypeString) ? GoogleChartType.LineChart : (GoogleChartType)Enum.Parse(typeof(GoogleChartType), googleChartTypeString);
        }
    }
} //End of namespace
