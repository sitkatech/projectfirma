//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GoogleChartType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class GoogleChartType : IHavePrimaryKey
    {
        public static readonly GoogleChartTypeColumnChart ColumnChart = GoogleChartTypeColumnChart.Instance;
        public static readonly GoogleChartTypeLineChart LineChart = GoogleChartTypeLineChart.Instance;
        public static readonly GoogleChartTypeComboChart ComboChart = GoogleChartTypeComboChart.Instance;
        public static readonly GoogleChartTypeAreaChart AreaChart = GoogleChartTypeAreaChart.Instance;
        public static readonly GoogleChartTypePieChart PieChart = GoogleChartTypePieChart.Instance;
        public static readonly GoogleChartTypeImageChart ImageChart = GoogleChartTypeImageChart.Instance;
        public static readonly GoogleChartTypeBarChart BarChart = GoogleChartTypeBarChart.Instance;
        public static readonly GoogleChartTypeHistogram Histogram = GoogleChartTypeHistogram.Instance;
        public static readonly GoogleChartTypeBubbleChart BubbleChart = GoogleChartTypeBubbleChart.Instance;
        public static readonly GoogleChartTypeScatterChart ScatterChart = GoogleChartTypeScatterChart.Instance;
        public static readonly GoogleChartTypeSteppedAreaChart SteppedAreaChart = GoogleChartTypeSteppedAreaChart.Instance;

        public static readonly List<GoogleChartType> All;
        public static readonly ReadOnlyDictionary<int, GoogleChartType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static GoogleChartType()
        {
            All = new List<GoogleChartType> { ColumnChart, LineChart, ComboChart, AreaChart, PieChart, ImageChart, BarChart, Histogram, BubbleChart, ScatterChart, SteppedAreaChart };
            AllLookupDictionary = new ReadOnlyDictionary<int, GoogleChartType>(All.ToDictionary(x => x.GoogleChartTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected GoogleChartType(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType)
        {
            GoogleChartTypeID = googleChartTypeID;
            GoogleChartTypeName = googleChartTypeName;
            GoogleChartTypeDisplayName = googleChartTypeDisplayName;
            SeriesDataDisplayType = seriesDataDisplayType;
        }

        [Key]
        public int GoogleChartTypeID { get; private set; }
        public string GoogleChartTypeName { get; private set; }
        public string GoogleChartTypeDisplayName { get; private set; }
        public string SeriesDataDisplayType { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return GoogleChartTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(GoogleChartType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.GoogleChartTypeID == GoogleChartTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as GoogleChartType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return GoogleChartTypeID;
        }

        public static bool operator ==(GoogleChartType left, GoogleChartType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GoogleChartType left, GoogleChartType right)
        {
            return !Equals(left, right);
        }

        public GoogleChartTypeEnum ToEnum { get { return (GoogleChartTypeEnum)GetHashCode(); } }

        public static GoogleChartType ToType(int enumValue)
        {
            return ToType((GoogleChartTypeEnum)enumValue);
        }

        public static GoogleChartType ToType(GoogleChartTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case GoogleChartTypeEnum.AreaChart:
                    return AreaChart;
                case GoogleChartTypeEnum.BarChart:
                    return BarChart;
                case GoogleChartTypeEnum.BubbleChart:
                    return BubbleChart;
                case GoogleChartTypeEnum.ColumnChart:
                    return ColumnChart;
                case GoogleChartTypeEnum.ComboChart:
                    return ComboChart;
                case GoogleChartTypeEnum.Histogram:
                    return Histogram;
                case GoogleChartTypeEnum.ImageChart:
                    return ImageChart;
                case GoogleChartTypeEnum.LineChart:
                    return LineChart;
                case GoogleChartTypeEnum.PieChart:
                    return PieChart;
                case GoogleChartTypeEnum.ScatterChart:
                    return ScatterChart;
                case GoogleChartTypeEnum.SteppedAreaChart:
                    return SteppedAreaChart;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum GoogleChartTypeEnum
    {
        ColumnChart = 1,
        LineChart = 2,
        ComboChart = 3,
        AreaChart = 4,
        PieChart = 5,
        ImageChart = 6,
        BarChart = 7,
        Histogram = 8,
        BubbleChart = 9,
        ScatterChart = 10,
        SteppedAreaChart = 11
    }

    public partial class GoogleChartTypeColumnChart : GoogleChartType
    {
        private GoogleChartTypeColumnChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeColumnChart Instance = new GoogleChartTypeColumnChart(1, @"ColumnChart", @"ColumnChart", @"bars");
    }

    public partial class GoogleChartTypeLineChart : GoogleChartType
    {
        private GoogleChartTypeLineChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeLineChart Instance = new GoogleChartTypeLineChart(2, @"LineChart", @"LineChart", @"line");
    }

    public partial class GoogleChartTypeComboChart : GoogleChartType
    {
        private GoogleChartTypeComboChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeComboChart Instance = new GoogleChartTypeComboChart(3, @"ComboChart", @"ComboChart", null);
    }

    public partial class GoogleChartTypeAreaChart : GoogleChartType
    {
        private GoogleChartTypeAreaChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeAreaChart Instance = new GoogleChartTypeAreaChart(4, @"AreaChart", @"AreaChart", @"area");
    }

    public partial class GoogleChartTypePieChart : GoogleChartType
    {
        private GoogleChartTypePieChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypePieChart Instance = new GoogleChartTypePieChart(5, @"PieChart", @"PieChart", @"pie");
    }

    public partial class GoogleChartTypeImageChart : GoogleChartType
    {
        private GoogleChartTypeImageChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeImageChart Instance = new GoogleChartTypeImageChart(6, @"ImageChart", @"ImageChart", null);
    }

    public partial class GoogleChartTypeBarChart : GoogleChartType
    {
        private GoogleChartTypeBarChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeBarChart Instance = new GoogleChartTypeBarChart(7, @"BarChart", @"BarChart", @"bars");
    }

    public partial class GoogleChartTypeHistogram : GoogleChartType
    {
        private GoogleChartTypeHistogram(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeHistogram Instance = new GoogleChartTypeHistogram(8, @"Histogram", @"Histogram", @"histogram");
    }

    public partial class GoogleChartTypeBubbleChart : GoogleChartType
    {
        private GoogleChartTypeBubbleChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeBubbleChart Instance = new GoogleChartTypeBubbleChart(9, @"BubbleChart", @"BubbleChart", null);
    }

    public partial class GoogleChartTypeScatterChart : GoogleChartType
    {
        private GoogleChartTypeScatterChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeScatterChart Instance = new GoogleChartTypeScatterChart(10, @"ScatterChart", @"ScatterChart", null);
    }

    public partial class GoogleChartTypeSteppedAreaChart : GoogleChartType
    {
        private GoogleChartTypeSteppedAreaChart(int googleChartTypeID, string googleChartTypeName, string googleChartTypeDisplayName, string seriesDataDisplayType) : base(googleChartTypeID, googleChartTypeName, googleChartTypeDisplayName, seriesDataDisplayType) {}
        public static readonly GoogleChartTypeSteppedAreaChart Instance = new GoogleChartTypeSteppedAreaChart(11, @"SteppedAreaChart", @"SteppedAreaChart", @"steppedArea");
    }
}