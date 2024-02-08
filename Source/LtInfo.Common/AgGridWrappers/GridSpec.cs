/*-----------------------------------------------------------------------
<copyright file="GridSpec.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Web;
using LtInfo.Common.ModalDialog;

namespace LtInfo.Common.AgGridWrappers
{
    public class GridSpec<T> : List<ColumnSpec<T>>
    {
        public GridSpec()
        {
            ShowFilterBar = true;
            GridInstructionsWhenEmpty = "No records available"; // default no records available message
            InitWidthsByPercentage = false;
            SkinRowHeight = AgGridHtmlHelpers.SkinRowHeight;
        }

        public bool InitWidthsByPercentage { get; set; }
        public int SkinRowHeight { get; set; }
        public string LoadingBarHtml { get; set; }
        public string ObjectNameSingular { get; set; }
        public string ObjectNamePlural { get; set; }
        public string CreateEntityActionPhrase { get; set; }
        public string CreateEntityUrl { get; set; }
        public string CreateEntityUrlClass { get; set; }
        /// <summary>
        /// ONly in Armstrong; Corral, Toad do not use this because we use the built-in dhtmlxgrid excel functionality. Can delete if/when Armstrong is updated.
        /// </summary>
        public string CsvDownloadUrl { get; set; }
        /// <summary>
        /// This download URL is in addition to the built-in automatically generated dhtmlxgrid download of the table
        /// If this field is set to a value, the custom download button is automatically created when the table is rendered
        /// </summary>
        public string CustomExcelDownloadUrl { get; set; }
        public string CustomExcelDownloadLinkText { get; set; }

        public List<String> ArbitraryHtml { get; set; }
        public bool? SaveFiltersInCookie { get; set; }
        public string GridInstructionsWhenEmpty { get; set; }
        public ModalDialogForm CreateEntityModalDialogForm { get; set; }
        public BulkTagModalDialogForm BulkTagModalDialogForm { get; set; }
        public SelectProjectsModalDialogForm GenerateReportModalDialogForm { get; set; }

        public bool ShowFilterBar { get; set; }

        public string ColumnFilterListForJavascript
        {
            get { return ShowFilterBar ? String.Join(",", this.Select(x => x.AgGridColumnFilterType.ToString())) : "null"; }
        }

        public string GetColumnTotals(string gridName)
        {
            if (!HasColumnTotals)
            {
                return string.Empty;
            }
            return string.Format("Sitka.{0}.grid.attachFooter(\"{1}\", [{2}]);",
                gridName,
                string.Join(",",
                    this.Select(x => (x.GridColumnAggregationType != AgGridColumnAggregationType.None) ? x.GridColumnAggregationType.ToString() : string.Empty)),
                string.Join(",",
                    this.Select(x => (x.GridColumnAggregationType != AgGridColumnAggregationType.None) ? x.GetAlignmentForFooterRow() : "\"\""))
                );
        }

        public bool HasColumnTotals
        {
            get { return this.Any(x => x.GridColumnAggregationType != AgGridColumnAggregationType.None); }
        }

        public List<string> ColumnNames
        {
            get { return this.Select(colSpec => colSpec.ColumnNameInnerText).ToList(); }
        }

        public int CalculateTotalColumnWidth()
        {
            return this.Sum(x => x.GridWidth);
        }

        public string GroupingHeader { get; set; }

        public string BuildGroupingHeader(ColumnHeaderGroupingList groupHeaderTitleAndColSpanTuple)
        {
            return string.Join(",",
                groupHeaderTitleAndColSpanTuple.Select(x =>
                {
                    var groupTitle = string.IsNullOrWhiteSpace(x.Item1) ? "&nbsp" : x.Item1;
                    var colSpanPadding = string.Join("", Enumerable.Repeat(",#cspan", x.Item2 - 1));
                    return string.Format("<div style='text-align:center'>{0}</div>{1}", groupTitle, colSpanPadding);
                }));
        }

        #region string
        public ColumnSpec<T> Add(string columnName, Func<T, string> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFilterType.Text);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, string> valueFunction, int gridWidth, AgGridColumnFilterType agGridColumnFilterType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFilterType, AgGridColumnAlignType.Left);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, string> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyText, AgGridColumnFormatType.None, agGridColumnAlignType, new AgGridColumnSortType("str"), agGridColumnFilterType, AgGridColumnAggregationType.None, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region HtmlString
        public ColumnSpec<T> Add(string columnName, Func<T, HtmlString> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFilterType.SelectFilterHtmlStrict);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, HtmlString> valueFunction, int gridWidth, AgGridColumnFilterType agGridColumnFilterType, int gridWidthFlex = 0)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFilterType, AgGridColumnAggregationType.None, AgGridColumnAlignType.Left, gridWidthFlex);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, HtmlString> valueFunction, int gridWidth, AgGridColumnFilterType agGridColumnFilterType, AgGridColumnAlignType agGridColumnAlignType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFilterType, AgGridColumnAggregationType.None, agGridColumnAlignType);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, HtmlString> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            AgGridColumnFilterType agGridColumnFilterType,
            AgGridColumnAggregationType agGridColumnAggregationType,
            AgGridColumnAlignType agGridColumnAlignType,
            int gridWidthFlex = 0)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyHtmlText, AgGridColumnFormatType.None,
                agGridColumnAlignType, new AgGridColumnSortType("htmlstring"), agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction, titleFunction, gridWidthFlex);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region int
        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.Integer, agGridColumnAggregationType);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnFilterType agGridColumnFilterType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, agGridColumnFilterType, AgGridColumnAggregationType.None, AgGridColumnAlignType.Right);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, AgGridColumnFilterType.Numeric, agGridColumnAggregationType, AgGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnFilterType agGridColumnFilterType, AgGridColumnAggregationType agGridColumnAggregationType,
            AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyNumber, agGridColumnFormatType,
                agGridColumnAlignType, new AgGridColumnSortType("num"), agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region int?
        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.Integer, agGridColumnAggregationType);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, agGridColumnFormatType, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, AgGridColumnFilterType.Numeric, agGridColumnAggregationType, AgGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnFilterType agGridColumnFilterType, AgGridColumnAggregationType agGridColumnAggregationType,
            AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyNumber, agGridColumnFormatType,
                agGridColumnAlignType, new AgGridColumnSortType("num"), agGridColumnFilterType, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region decimal
        public ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, agGridColumnFormatType, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, agGridColumnAggregationType, AgGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAggregationType agGridColumnAggregationType, AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyNumber, agGridColumnFormatType,
                agGridColumnAlignType, new AgGridColumnSortType("num"), AgGridColumnFilterType.Numeric, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region decimal?
        public ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, agGridColumnFormatType, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, agGridColumnAggregationType, AgGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAggregationType agGridColumnAggregationType, AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyNumber, agGridColumnFormatType,
                agGridColumnAlignType, new AgGridColumnSortType("num"), AgGridColumnFilterType.Numeric, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region double
        public ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, agGridColumnFormatType, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, agGridColumnAggregationType, AgGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAggregationType agGridColumnAggregationType, AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyNumber, agGridColumnFormatType,
                agGridColumnAlignType, new AgGridColumnSortType("num"), AgGridColumnFilterType.Numeric, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region double?
        public ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, agGridColumnFormatType, AgGridColumnAggregationType.None);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType, AgGridColumnAggregationType agGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, agGridColumnFormatType, agGridColumnAggregationType, AgGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, AgGridColumnFormatType agGridColumnFormatType,
            AgGridColumnAggregationType agGridColumnAggregationType, AgGridColumnAlignType agGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                AgGridColumnDataType.ReadOnlyNumber, agGridColumnFormatType,
                agGridColumnAlignType, new AgGridColumnSortType("num"), AgGridColumnFilterType.Numeric, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region DateTime
        public ColumnSpec<T> Add(string columnName, Func<T, DateTime> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.DateTime);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, DateTime> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, AgGridColumnAggregationType.None, AgGridColumnAlignType.Right, agGridColumnFormatType);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, DateTime> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            AgGridColumnAggregationType agGridColumnAggregationType, AgGridColumnAlignType agGridColumnAlignType, AgGridColumnFormatType agGridColumnFormatType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth, AgGridColumnDataType.ReadOnlyText, agGridColumnFormatType, agGridColumnAlignType, new AgGridColumnSortType("date"),  AgGridColumnFilterType.DateRange, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion
        
        #region DateTime?
        public ColumnSpec<T> Add(string columnName, Func<T, DateTime?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, AgGridColumnFormatType.DateTime);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, DateTime?> valueFunction, int gridWidth, AgGridColumnFormatType agGridColumnFormatType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, AgGridColumnAggregationType.None, AgGridColumnAlignType.Right, agGridColumnFormatType);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, DateTime?> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            AgGridColumnAggregationType agGridColumnAggregationType, AgGridColumnAlignType agGridColumnAlignType, AgGridColumnFormatType agGridColumnFormatType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth, AgGridColumnDataType.ReadOnlyText, agGridColumnFormatType, agGridColumnAlignType, new AgGridColumnSortType("date"), AgGridColumnFilterType.DateRange, agGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region CheckBox column

        public ColumnSpec<T> AddCheckBoxColumn()
        {
            var columnSpec = new ColumnSpec<T>("#master_checkbox", x => 0.ToString(), 28, AgGridColumnDataType.Checkbox,
                AgGridColumnFormatType.None, AgGridColumnAlignType.Center, new AgGridColumnSortType("ch"), AgGridColumnFilterType.None, AgGridColumnAggregationType.None, null, null);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion
    }

    public class ColumnHeaderGroupingList : List<Tuple<string, int>>
    {
        public void Add(string item, int item2)
        {
            Add(new Tuple<string, int>(item, item2));
        }
    }
}
