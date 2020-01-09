/*-----------------------------------------------------------------------
<copyright file="GridSpec.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.Web;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;

namespace LtInfo.Common.DhtmlWrappers
{
    public class GridSpec<T> : List<ColumnSpec<T>>
    {
        public GridSpec()
        {
            ShowFilterBar = true;
            GridInstructionsWhenEmpty = "No records available"; // default no records available message
        }

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
            get { return ShowFilterBar ? String.Join(",", this.Select(x => x.DhtmlxGridColumnFilterType.ToString())) : "null"; }
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
                    this.Select(x => (x.GridColumnAggregationType != null) ? x.GridColumnAggregationType.ToString() : string.Empty)),
                string.Join(",",
                    this.Select(x => (x.GridColumnAggregationType != null) ? x.GetAlignmentForFooterRow() : "\"\""))
                );
        }

        public bool HasColumnTotals
        {
            get { return this.Any(x => x.GridColumnAggregationType != null); }
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
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFilterType.Text);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, string> valueFunction, int gridWidth, DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFilterType, DhtmlxGridColumnAlignType.Left);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, string> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyText, DhtmlxGridColumnFormatType.None, dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("str"), dhtmlxGridColumnFilterType, null, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region HtmlString
        public ColumnSpec<T> Add(string columnName, Func<T, HtmlString> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, HtmlString> valueFunction, int gridWidth, DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFilterType, null, DhtmlxGridColumnAlignType.Left);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, HtmlString> valueFunction, int gridWidth, DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFilterType, null, dhtmlxGridColumnAlignType);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, HtmlString> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyHtmlText, DhtmlxGridColumnFormatType.None,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("htmlstring"), dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region int
        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.Integer, dhtmlxGridColumnAggregationType);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, dhtmlxGridColumnFilterType, null, DhtmlxGridColumnAlignType.Right);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, DhtmlxGridColumnFilterType.Numeric, dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, int> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyNumber, dhtmlxGridColumnFormatType,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("num"), dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region int?
        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, (DhtmlxGridColumnAggregationType) null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.Integer, dhtmlxGridColumnAggregationType);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, dhtmlxGridColumnFormatType, null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, DhtmlxGridColumnFilterType.Numeric, dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, int?> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnFilterType dhtmlxGridColumnFilterType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType,
            DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyNumber, dhtmlxGridColumnFormatType,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("num"), dhtmlxGridColumnFilterType, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region decimal
        public ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, dhtmlxGridColumnFormatType, null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, decimal> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyNumber, dhtmlxGridColumnFormatType,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("num"), DhtmlxGridColumnFilterType.Numeric, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region decimal?
        public ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, dhtmlxGridColumnFormatType, null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, decimal?> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyNumber, dhtmlxGridColumnFormatType,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("num"), DhtmlxGridColumnFilterType.Numeric, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region double
        public ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, dhtmlxGridColumnFormatType, null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, double> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyNumber, dhtmlxGridColumnFormatType,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("num"), DhtmlxGridColumnFilterType.Numeric, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region double?
        public ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.Decimal);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, gridWidth, dhtmlxGridColumnFormatType, null);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType, DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, dhtmlxGridColumnFormatType, dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType.Right);
        }

        private ColumnSpec<T> Add(string columnName, Func<T, double?> valueFunction, Func<T, string> cssClassFunction,
            int gridWidth, Func<T, string> titleFunction, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth,
                DhtmlxGridColumnDataType.ReadOnlyNumber, dhtmlxGridColumnFormatType,
                dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("num"), DhtmlxGridColumnFilterType.Numeric, dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region DateTime
        public ColumnSpec<T> Add(string columnName, Func<T, DateTime> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.DateTime);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, DateTime> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, null, DhtmlxGridColumnAlignType.Right, dhtmlxGridColumnFormatType);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, DateTime> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth, DhtmlxGridColumnDataType.ReadOnlyText, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("date"), new DhtmlxGridColumnFilterType("#date_range_filter"), dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion
        
        #region DateTime?
        public ColumnSpec<T> Add(string columnName, Func<T, DateTime?> valueFunction, int gridWidth)
        {
            return Add(columnName, valueFunction, gridWidth, DhtmlxGridColumnFormatType.DateTime);
        }

        public ColumnSpec<T> Add(string columnName, Func<T, DateTime?> valueFunction, int gridWidth, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            return Add(columnName, valueFunction, null, gridWidth, null, null, DhtmlxGridColumnAlignType.Right, dhtmlxGridColumnFormatType);
        }

        private ColumnSpec<T> Add(string columnName,
            Func<T, DateTime?> valueFunction,
            Func<T, string> cssClassFunction,
            int gridWidth,
            Func<T, string> titleFunction,
            DhtmlxGridColumnAggregationType dhtmlxGridColumnAggregationType, DhtmlxGridColumnAlignType dhtmlxGridColumnAlignType, DhtmlxGridColumnFormatType dhtmlxGridColumnFormatType)
        {
            var columnSpec = new ColumnSpec<T>(columnName, valueFunction, gridWidth, DhtmlxGridColumnDataType.ReadOnlyText, dhtmlxGridColumnFormatType, dhtmlxGridColumnAlignType, new DhtmlxGridColumnSortType("date"), new DhtmlxGridColumnFilterType("#date_range_filter"), dhtmlxGridColumnAggregationType, cssClassFunction, titleFunction);
            Add(columnSpec);
            return columnSpec;
        }
        #endregion

        #region CheckBox column

        public ColumnSpec<T> AddCheckBoxColumn()
        {
            var columnSpec = new ColumnSpec<T>("#master_checkbox", x => 0.ToString(), 28, DhtmlxGridColumnDataType.Checkbox,
                DhtmlxGridColumnFormatType.None, DhtmlxGridColumnAlignType.Center, new DhtmlxGridColumnSortType("ch"), DhtmlxGridColumnFilterType.None, null, null, null);
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
