/*-----------------------------------------------------------------------
<copyright file="DhtmlxGridHtmlHelpers.cs" company="Environmental Science Associates">
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.ModalDialog;

namespace LtInfo.Common.AgGridWrappers
{
    /// <summary>
    ///     Helper class for DhtmlxGrid expects following content to be set up in local project
    ///     /Content/css/dhtmlxgrid_skin.css
    ///     /Content/img/bg-edit-single.png
    ///     /Content/img/bg-delete-single.png
    /// </summary>
    public static class AgGridHtmlHelpers
    {
        public static readonly HtmlString PlusIconBootstrap = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus-sign gi-1x blue");
        public static readonly HtmlString UndoIconBootstrap = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-regular undo gi-1x blue");
        public static readonly HtmlString EditIconBootstrap = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-edit gi-1x blue");
        public static readonly HtmlString DeleteIconBootstrap = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-trash gi-1x blue");
        public static readonly HtmlString OkCircleIconBootstrap = BootstrapHtmlHelpers.MakeGlyphIconWithHiddenText("glyphicon-ok-circle gi-1x blue", "Yes");

        public const string EditIcon = "<img src=\"/Content/img/bg-edit-single.png\" />";
        public const string DeleteIcon = "<img src=\"/Content/img/bg-delete-single.png\" />";
        public const string DeleteIconGrey = "<img src=\"/Content/img/bg-delete-single-grey.png\" />";

        public const string Skin = "mm";
        public const int SkinRowHeight = 30;

        /// <summary>
        /// Only public for unit testing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridSpec"></param>
        /// <param name="gridName"></param>
        /// <param name="optionalGridDataUrl"></param>
        /// <param name="styleString"></param>
        /// <returns></returns>
        public static HtmlString AgGrid<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString)
        {
            return new HtmlString(AgGridImpl(gridSpec, gridName, optionalGridDataUrl, styleString, null, string.Empty, AgGridResizeType.None, ""));
        }

        public static string AgGridImpl<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString, int? splitAtColumn)
        {
            return AgGridImpl(gridSpec, gridName, optionalGridDataUrl, styleString, splitAtColumn, string.Empty, AgGridResizeType.None,"");
        }

        public static string AgGridImpl<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl,
            string styleString, int? splitAtColumn, string metaDivHtml, AgGridResizeType agGridResizeType,
            string saveGridSettingsUrl)
        {
//            const string template =
//                @"
//<div id =""{0}ContainerDivID"" style=""position:relative;"">
//    <div id=""{0}LoadingBar"" class=""project-firma-loading-bar"" style=""display:none"">{1}</div>
//    <div id=""{0}MetaDivID"" class=""DhtmlxGridMeta"">{2}</div>
//    <div id=""{0}DivID"" style=""{3}""></div>
//    <script type=""text/javascript"">
//    // <![CDATA[
//        {4}
//    // ]]>
//    </script>
//</div>";

            const string template = @"    <!-- The div that will host the grid. ag-theme-alpine is the theme. -->
    <!-- The grid will be the size that this element is given. -->
    <div>
        <div ><span id=""{0}RowCountText""></span> <a id=""{0}ClearFilters"" style=""display: none"" href=""javascript: void(0);"" onclick=""{0}ClearFilters()"">(clear filters)</a></div>
      </div>
    <div id=""{0}DivID"" class=""ag-theme-alpine"" style=""{6}""></div>
    <script type=""text/javascript"">

            function {0}ClearFilters(){{
                {0}GridOptions.api.setFilterModel(null);
                document.getElementById(""{0}ClearFilters"").style.display = ""none"";
            }}



            function {0}ResizeGridWithVerticalFill(){{
                var top = getOffsetTop(document.getElementById(""{0}DivID""));
                gridHeight =getGridHeight(top);
                document.getElementById(""{0}DivID"").style.height = gridHeight+""px"";
            }}
            addEventListener(""resize"", (event) => {{ {4} }}); ; // insert method to resize grid vertically if grid resize type is VerticalResizableHorizontalAutoFit

            function {0}MakeGridVerticallyResizable() {{
                document.getElementById(""{0}DivID"").style.resize = ""vertical"";
                document.getElementById(""{0}DivID"").style.overflow = ""auto"";
            }}
            {5} // insert method to make grid vertically resizable if the grid resize type is VerticalResizableHorizontalAutoFit

            function {0}GeneratePinnedBottomData(){{
                // generate a row-data with null values
                var result = {{}};

                {0}GridOptions.columnApi.getAllGridColumns().forEach(item => {{
                    result[item.colId] = null;
                    if(item.colDef.aggregationType === ""total"") {{
                        columnsWithAggregation.push(item.colId);
                    }}
                }});
                var columnsWithAggregation = [{7}];
                if(columnsWithAggregation.length === 0){{ return false;}}
                return {0}CalculatePinnedBottomData(result, columnsWithAggregation);
            }}
            function {0}CalculatePinnedBottomData(target, columnsWithAggregation){{
                //console.log(target);
                
                columnsWithAggregation.forEach(element => {{
                  //console.log('element', element);
                    {0}GridOptions.api.forEachNodeAfterFilter((rowNode) => {{
                        if (rowNode.data[element]){{
                            if(target[element]){{
                                target[element] = (Number.parseFloat(target[element]) + Number.parseFloat(rowNode.data[element])).toFixed(2);
                            }}else{{
                                target[element] = Number.parseFloat(rowNode.data[element]).toFixed(2);
                            }}
                            
                        }}
                    }});
                    if (target[element]){{
                        target[element] = target[element];//.toFixed(2);
                    }}
                }})

                return target;
            }}


        // Function to demonstrate calling grid's API
        function deselect(){{
            {0}GridOptions.api.deselectAll()
        }}

        // Grid Options are properties passed to the grid
        const {0}GridOptions = {{

          // each entry here represents one column
          columnDefs: [
            {2}
          ],

          // default col def properties get applied to all columns
          defaultColDef: {{sortable: true, filter: true, floatingFilter:true, wrapHeaderText: true, autoHeaderHeight: true, }},
          rowSelection: 'multiple', // allow rows to be selected
          animateRows: true, // have rows animate to new positions when sorted

          dataTypeDefinitions: {{
            dateString: getDateStringDataTypeDefinition()
          }},


          onFilterChanged: function() {{
            document.getElementById(""{0}RowCountText"").innerText=""Currently Viewing ""+{0}GridOptions.api.getDisplayedRowCount()+ "" out of "" + {0}TotalRowCount + "" {3}"";
            if(Object.keys({0}GridOptions.api.getFilterModel()).length !== 0){{
                document.getElementById(""{0}ClearFilters"").style.display = ""inline-block"";
            }}
          }},

          // example event handler
          onCellClicked: params => {{
            //debugger;
            console.log('cell was clicked', params)

          }}
        }};

        // get div to host the grid
        const {0}GridDiv = document.getElementById(""{0}DivID"");
        // new grid instance, passing in the hosting DIV and Grid Options
        new agGrid.Grid({0}GridDiv, {0}GridOptions);
        var {0}TotalRowCount = 0;
        // Fetch data from server
        fetch(""{1}"")
        .then(response => response.json())
        .then(data => {{
            // load fetched data into grid
            {0}GridOptions.api.setRowData(data);
            {0}TotalRowCount = data.length;
            document.getElementById(""{0}RowCountText"").innerText=""Currently Viewing ""+{0}GridOptions.api.getDisplayedRowCount()+ "" out of "" + {0}TotalRowCount + "" {3}""; 
            {4}; // insert method to resize grid vertically if grid resize type is VerticalResizableHorizontalAutoFit
            var {0}PinnedBottomData = {0}GeneratePinnedBottomData();
            if({0}PinnedBottomData){{
                {0}GridOptions.api.setPinnedBottomRowData([{0}PinnedBottomData]);
            }}
        }});
    </script>";


            //var javascriptDocumentReadyHtml = RenderGridJavascriptDocumentReady(gridSpec, gridName, optionalGridDataUrl,
            //    splitAtColumn, dhtmlxGridResizeType, saveGridSettingsUrl);

            //{{ field: ""Watershed"" }},
            //{{ field: ""NumofProjects"" }}
            var columnDefinitionStringBuilder = new StringBuilder();
            var columnsWithAggregationStringBuilder = new StringBuilder();
            var isFirstLoop = true;
            foreach (var columnSpec in gridSpec)
            {
                if (isFirstLoop)
                {
                    isFirstLoop = false;
                }
                else
                {
                    columnDefinitionStringBuilder.Append(",");
                }

                columnDefinitionStringBuilder.Append("{ ");//open this column spec
                columnDefinitionStringBuilder.AppendFormat("\"field\": \"{0}\"", columnSpec.ColumnNameForJavascript);
                
                columnDefinitionStringBuilder.AppendFormat(", \"headerName\": \"{0}\"", columnSpec.ColumnNameInnerText);

                columnDefinitionStringBuilder.Append(", \"headerComponentParams\": { \"template\": \"<div class=\\\"ag-cell-label-container\\\" role=\\\"presentation\\\">");
                columnDefinitionStringBuilder.Append("<span ref=\\\"eMenu\\\" class=\\\"ag-header-icon ag-header-cell-menu-button\\\"></span>");
                columnDefinitionStringBuilder.Append("<div ref=\\\"eLabel\\\" class=\\\"ag-header-cell-label\\\" role=\\\"presentation\\\">");
                columnDefinitionStringBuilder.Append("<span ref=\\\"eSortOrder\\\" class=\\\"ag-header-icon ag-sort-order\\\" ></span>");
                columnDefinitionStringBuilder.Append("<span ref=\\\"eSortAsc\\\" class=\\\"ag-header-icon ag-sort-ascending-icon\\\" ></span>");
                columnDefinitionStringBuilder.Append("<span ref=\\\"eSortDesc\\\" class=\\\"ag-header-icon ag-sort-descending-icon\\\" ></span>");
                columnDefinitionStringBuilder.Append("<span ref=\\\"eSortNone\\\" class=\\\"ag-header-icon ag-sort-none-icon\\\" ></span>");
                columnDefinitionStringBuilder.Append("<span ref=\\\"eText2\\\" class=\\\"ag-header-cell-text\\\" role=\\\"columnheader\\\">");
                // 7/31/2023 TK - Not sure if I like this, it works with the current setup of helpers but feels a bit hacky
                //todo: come up with a better method to get field definition popups in header cells
                columnDefinitionStringBuilder.AppendFormat("{0}</span>", columnSpec.ColumnName.ToJSON());
                columnDefinitionStringBuilder.Append("<span ref=\\\"eFilter\\\" class=\\\"ag-header-icon ag-filter-icon\\\"></span>");
                columnDefinitionStringBuilder.Append("</div></div>\" }");//close headerComponentParams object

                bool resizable = !(columnSpec.GridWidth < 35);// most cols with a width < 35px are icon buttons (like edit, delete, download fact sheet)  
                columnDefinitionStringBuilder.AppendFormat(", \"resizable\": {0}", resizable.ToString().ToLower());

                if (!resizable)
                {
                    // hide the ellipsis 
                    columnDefinitionStringBuilder.Append(", \"cellStyle\": { \"text-overflow\" : \"clip\"}");
                }

                //hide column or set grid width
                if (columnSpec.GridWidth == 0)
                {
                    columnDefinitionStringBuilder.Append(", \"hide\": true");

                }
                else if (columnSpec.GridWidth < 35)
                {
                    columnDefinitionStringBuilder.AppendFormat(", \"initialWidth\": {0}", columnSpec.GridWidth);
                }
                else
                {
                    columnDefinitionStringBuilder.AppendFormat(", \"initialWidth\": {0}", columnSpec.GridWidth + 30); // 8/8/2023 SB add to the width instead of editing every hard coded column in every GridSpec class
                }



                switch (columnSpec.AgGridColumnFilterType)
                {
                    case AgGridColumnFilterType.None:
                        columnDefinitionStringBuilder.Append(", \"filter\": false");
                        break;
                    case AgGridColumnFilterType.FormattedNumeric:
                    case AgGridColumnFilterType.Numeric:
                        columnDefinitionStringBuilder.Append(", \"filter\": \"agNumberColumnFilter\"");
                        break;
                    case AgGridColumnFilterType.DateRange:
                        columnDefinitionStringBuilder.Append(", \"filter\": \"agDateColumnFilter\"");
                        columnDefinitionStringBuilder.Append(", \"comparator\": dateStringComparator");//comparator: dateComparator
                        // columnDefinitionStringBuilder.Append(", \"cellDataType\": \"dateString\"");
                        break;
                    case AgGridColumnFilterType.Html:
                    case AgGridColumnFilterType.Text:
                        columnDefinitionStringBuilder.Append(", \"filter\": \"agTextColumnFilter\"");
                        break;
                    default:
                        break;
                }

                switch (columnSpec.AgGridColumnFormatType)
                {
                    case AgGridColumnFormatType.Currency:
                        columnDefinitionStringBuilder.Append(", \"valueFormatter\": currencyFormatter");
                        break;
                    case AgGridColumnFormatType.Integer:
                        // columnDefinitionStringBuilder.Append(", \"valueFormatter\": integerFormatter");
                        // columnDefinitionStringBuilder.Append(", \"cellDataType\": \"number\"");
                        break;
                    default:
                        break;
                }

                switch (columnSpec.GridColumnAggregationType)
                {
                    case AgGridColumnAggregationType.Total:
                        columnsWithAggregationStringBuilder.Append(columnsWithAggregationStringBuilder.Length > 0 ? ", " : string.Empty); 
                        columnsWithAggregationStringBuilder.AppendFormat("\"{0}\"",columnSpec.ColumnNameForJavascript); 
                        break;
                    default:
                        break;
                }

                switch (columnSpec.AgGridColumnAlignType)
                {
                    case AgGridColumnAlignType.Right:
                        columnDefinitionStringBuilder.Append(", \"cellClass\": \"ag-right-aligned-cell\"");
                        break;
                    default:
                        break;
                }

                if (columnSpec.AgGridColumnDataType == AgGridColumnDataType.ReadOnlyHtmlText)
                {
                    columnDefinitionStringBuilder.Append(", \"cellRenderer\": function(params) { return params.value ? params.value: ''; } ");
                }

                if (columnSpec.AgGridColumnDataType == AgGridColumnDataType.Checkbox)
                {
                    columnDefinitionStringBuilder.Append(", \"checkboxSelection\": true");
                }


                columnDefinitionStringBuilder.Append(" }");//close this column spec
            }

            var resizeGridFunction = agGridResizeType == AgGridResizeType.VerticalFillHorizontalAutoFit
                ? $"{gridName}ResizeGridWithVerticalFill()"
                : string.Empty;

            var makeVerticalResizable = agGridResizeType == AgGridResizeType.VerticalResizableHorizontalAutoFit
                ? $"{gridName}MakeGridVerticallyResizable()"
                : string.Empty;

            if (string.IsNullOrWhiteSpace(styleString) || !styleString.ToLower().Contains("height"))
            {
                styleString = styleString == null ? "height: 500px;" : styleString + "; height: 500px";
            }

            return String.Format(template, gridName, optionalGridDataUrl, columnDefinitionStringBuilder, gridSpec.ObjectNamePlural, resizeGridFunction, makeVerticalResizable, styleString, columnsWithAggregationStringBuilder);//, gridSpec.LoadingBarHtml, metaDivHtml, styleString, javascriptDocumentReadyHtml);
        }

        /// <summary>
        /// Template for <see cref="RenderGridJavascriptDocumentReady{T}"/>
        /// </summary>
        private const string GridJavascriptDocumentReady = @"
    jQuery(document).ready(function ()
    {{
        // Initialize Grid
        Sitka.{0} = new Sitka.Grid.Class.Grid(""{0}"", ""{0}DivID"", null, ""scrollToFirst"", ""{1}"", {2}, ""{14}"");
        // Initialize Grid Columns
        Sitka.{0}.setGridColumns(
        [
{3}
        ]);

        var columnFilterList = ""{4}"";
        {5}
        
        Sitka.{0}.buildWithArguments(null, {6}, columnFilterList, {7}, {8}, {9}, {15});

        // Show loading bar
        jQuery(""#{0}LoadingBar"").show();
        var showFilterBar = {10};
        if(showFilterBar)
        {{
            Sitka.{0}.setupServerFilterSaving();
            Sitka.{0}.setupFilterCountElement(""{0}FilteredRowCount"");
            Sitka.{0}.setFilteringButtonTagName(""{0}FilteredButton"");
        }}
        Sitka.{0}.grid.attachEvent(""onXLE"", function (gridObj, count){{
            Sitka.{0}.unfilteredRowCount = Sitka.{0}.grid.getRowsNum();
            jQuery(""#{0}FilteredRowCount"").text(Sitka.{0}.unfilteredRowCount);
            jQuery(""#{0}UnfilteredRowCount"").text(Sitka.{0}.unfilteredRowCount);
            jQuery(""#{0}LoadingBar"").hide();
            jQuery(""#{0}DivID"").show();
            // if there are no rows, don't show grid and show a ""No records available"" message
            if(Sitka.{0}.unfilteredRowCount > 0)
            {{
                Sitka.{0}.showHideFilterRow(showFilterBar);
                Sitka.{0}.hideGridInstructions();
            }}
            else
            {{
                Sitka.{0}.showHideFilterRow(false);
                Sitka.{0}.setGridInstructions(""<div style=\""padding:10px; font-weight:bold\"">{11}</div>"", true);
            }}
        }});
    
        Sitka.{0}.grid.attachEvent(""onCheckbox"", function(rId,cInd,state) {{
            Sitka.{0}.updateSelectedCheckboxCount();
        }});
        
        Sitka.{0}.grid.attachEvent(""onFilterEnd"", function() {{
            Sitka.{0}.updateSelectedCheckboxCount();
        }});

        {12}
        {13}
    }});";

        /// <summary>
        /// Renders the jQuery(document).ready part of the grid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridSpec"></param>
        /// <param name="gridName"></param>
        /// <param name="optionalGridDataUrl"></param>
        /// <param name="splitAtColumn"></param>
        /// <param name="agGridResizeType"></param>
        /// <param name="saveGridSettingsUrl"></param>
        /// <returns></returns>
        private static string RenderGridJavascriptDocumentReady<T>(GridSpec<T> gridSpec, string gridName,
            string optionalGridDataUrl, int? splitAtColumn, AgGridResizeType agGridResizeType,
            string saveGridSettingsUrl)
        {
            const string indent = "            ";
            var gridColumnsJavascriptFunctions = BuildGridColumns(gridSpec, indent);
            var dataUrlReadyForJavascript = String.IsNullOrWhiteSpace(optionalGridDataUrl) ? "null" : $"\"{optionalGridDataUrl}\"";
            var useSmartRendering = IsUsingSmartRendering(gridSpec);
            var splitAtColumnJavascriptVariable = (splitAtColumn != null) ? splitAtColumn.ToString() : "null";
            
            var resizeGridFunction = agGridResizeType == AgGridResizeType.VerticalFillHorizontalAutoFit
                ? GenerateVerticalFillResizeGridFunction(gridName)
                : string.Empty;

            var verticalResizeFunction = agGridResizeType == AgGridResizeType.VerticalResizableHorizontalAutoFit 
                ? GenerateVerticallyResizableFunction(gridName) 
                : string.Empty;

            var result = String.Format(GridJavascriptDocumentReady,
                gridName,
                Skin,
                gridSpec.SkinRowHeight,
                gridColumnsJavascriptFunctions,
                gridSpec.ColumnFilterListForJavascript,
                gridSpec.GetColumnTotals(gridName),
                string.IsNullOrWhiteSpace(gridSpec.GroupingHeader) ? "null" : $"\"{gridSpec.GroupingHeader}\"",
                dataUrlReadyForJavascript,
                useSmartRendering.ToString().ToLower(),
                splitAtColumnJavascriptVariable,
                gridSpec.ShowFilterBar.ToString().ToLower(),
                gridSpec.GridInstructionsWhenEmpty,
                verticalResizeFunction,
                resizeGridFunction, 
                saveGridSettingsUrl,
                gridSpec.InitWidthsByPercentage.ToString().ToLower());

            return result;
        }

        private static string GenerateVerticallyResizableFunction(string gridName)
        {
            return string.Format(@"
            var gridDiv = jQuery(""#{0}DivID"");
            var parentDiv = gridDiv.parent();
            gridDiv.resizable({{
                handles: ""s"",
                stop: function()
                {{
                    Sitka.{0}.grid.setSizes();
                }},
                resize: function(event, ui)
                {{
                    ui.size.width = ui.originalSize.width;
                }}
            }});
            jQuery(window).resize(function()
            {{
                Sitka.{0}.resizeGridWidths(); 
            }});
            Sitka.{0}.resizeGridWidths();", gridName);
        }

        private static string GenerateVerticalFillResizeGridFunction(string gridName)
        {
            const string template = @"
        Sitka.{0}.resizeGridWithVerticalFill();
        jQuery(window).resize(function()
        {{
            Sitka.{0}.resizeGridWithVerticalFill();
        }});";
            return string.Format(template, gridName);
        }

        public static string BuildDhtmlxGridHeader<T>(GridSpec<T> gridSpec, string gridName, UrlTemplate<string> excelDownloadUrl)
        {
            var filteredStateHtml = CreateFilteredStateHtml(gridName, gridSpec.ShowFilterBar);
            var gridHeaderIconsHtml = CreateGridHeaderIconsHtml(gridSpec, gridName, excelDownloadUrl);

            return $@"
    <span class=""record-count"">
        {CreateViewingRowCountGridHeaderHtml(gridName, gridSpec.ObjectNamePlural)}
        {filteredStateHtml}
    </span>
    <span class=""checked-checkboxes"" style=""display:none;margin-left:20px;"">
        {CreateViewingCheckedCheckboxesCountGridHeaderHtml(gridName, gridSpec.ObjectNamePlural)}
    </span>
    <span class=""actions pull-right"">
    {gridHeaderIconsHtml}
    </span>";
        }

        private static string CreateGridHeaderIconsHtml<T>(GridSpec<T> gridSpec, string gridName, UrlTemplate<string> excelDownloadUrl)
        {
            var filteredExcelDownloadIconHtml = CreateFilteredExcelDownloadIconHtml(gridName, excelDownloadUrl);
            var customExcelDownloadIconHtml = CreateFullDatabaseExcelDownloadIconHtml(gridName, gridSpec.CustomExcelDownloadUrl, gridSpec.CustomExcelDownloadLinkText ?? "Download Full Database");
            var createIconHtml = CreateCreateUrlHtml(gridSpec.CreateEntityUrl, gridSpec.CreateEntityUrlClass, gridSpec.CreateEntityModalDialogForm, gridSpec.CreateEntityActionPhrase, gridSpec.ObjectNameSingular);
            var tagIconHtml = CreateTagUrlHtml(gridName, gridSpec.BulkTagModalDialogForm);
            var generateReportsIconHtml = (gridSpec.GenerateReportModalDialogForm != null) ? CreateGenerateReportUrlHtml(gridName, gridSpec.GenerateReportModalDialogForm) : null;
            var arbitraryHtml = CreateArbitraryHtml(gridSpec.ArbitraryHtml, "    ");
            return $@"
            {
                    (!string.IsNullOrWhiteSpace(arbitraryHtml)
                        ? $"<span>{arbitraryHtml}</span>"
                        : string.Empty)
                }
            {
                    (!string.IsNullOrWhiteSpace(createIconHtml)
                        ? $"<span>{createIconHtml}</span>"
                        : string.Empty)
                }
            {(!string.IsNullOrWhiteSpace(generateReportsIconHtml) ? $"<span>{generateReportsIconHtml}</span>" : string.Empty)}
            {(!string.IsNullOrWhiteSpace(tagIconHtml) ? $"<span>{tagIconHtml}</span>" : string.Empty)}
            {
                    (!string.IsNullOrWhiteSpace(filteredExcelDownloadIconHtml)
                        ? $"<span>{filteredExcelDownloadIconHtml}</span>"
                        : string.Empty)
                }
            {
                    (!string.IsNullOrWhiteSpace(customExcelDownloadIconHtml)
                        ? $"<span>{customExcelDownloadIconHtml}</span>"
                        : string.Empty)
                }";
        }

        public static string CreateTagUrlHtml(string gridName, BulkTagModalDialogForm bulkTagModalDialogForm)
        {
            if (bulkTagModalDialogForm == null)
                return string.Empty;

            var tagIconHtml =
                $"<span style=\"margin-right:5px\">{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-tag")}</span>";

            var getProjectIDFunctionString =
                $"function() {{ return Sitka.{gridName}.getValuesFromCheckedGridRows({bulkTagModalDialogForm.CheckboxColumnIndex}, '{bulkTagModalDialogForm.ValueColumnName}', '{bulkTagModalDialogForm.ReturnListName}'); }}";

            return
                ModalDialogFormHelper.ModalDialogFormLink($"{tagIconHtml}{bulkTagModalDialogForm.DialogLinkText}",
                    bulkTagModalDialogForm.DialogUrl,
                    bulkTagModalDialogForm.DialogTitle,
                    ModalDialogFormHelper.DefaultDialogWidth,
                    "Save",
                    "Cancel",
                    new List<string>(),
                    null,
                    getProjectIDFunctionString).ToString();
        }

        public static string CreateGenerateReportUrlHtml(string gridName, SelectProjectsModalDialogForm modalDialogForm)
        {
            var tagIconHtml =
                $"<span style=\"margin-right:5px\">{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-file")}</span>";
            var getProjectIDFunctionString =
                $"function() {{ return Sitka.{gridName}.getValuesFromCheckedGridRows({modalDialogForm.CheckboxColumnIndex}, '{modalDialogForm.ValueColumnName}', '{modalDialogForm.ReturnListName}'); }}";

            return ModalDialogFormHelper.ModalDialogFormLink($"{tagIconHtml} Generate Reports",
                modalDialogForm.DialogUrl,
                modalDialogForm.DialogTitle,
                ModalDialogFormHelper.DefaultDialogWidth,
                "Generate",
                "Close",
                new List<string>(),
                null,
                getProjectIDFunctionString,
                true).ToString();

        }

        /// <summary>
        /// Renders the filtered state on the grid header; will not show up if ShowFilterBar is false
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="showFilterBar"></param>
        /// <returns></returns>
        public static string CreateFilteredStateHtml(string gridName, bool showFilterBar)
        {
            if (showFilterBar)
            {
                var filteredStateText =
                    String.Format(@"<span id=""{0}FilteredButton"" style=""display:none"">(<a href=""javascript:void(0);"" onclick=""Sitka.{0}.clearGridFilters()"">clear filters</a>)</span>", gridName);
                return filteredStateText;
            }
            return String.Empty;
        }

        /// <summary>
        /// Arbitraty html that goes up in the grid header
        /// </summary>
        /// <param name="arbitraryHtml"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        public static string CreateArbitraryHtml(IEnumerable<string> arbitraryHtml, string indent)
        {
            return arbitraryHtml != null ? String.Join("\r\n", arbitraryHtml.Select(x => $"{indent}{x}")) : String.Empty;
        }

        /// <summary>
        /// Typically, we either have a create new button that goes to a new page
        /// or a modal dialog version of the create new record
        /// </summary>
        /// <param name="createUrl"></param>
        /// <param name="createUrlClass"></param>
        /// <param name="createPopupForm"></param>
        /// <param name="createActionPhrase"></param>
        /// <param name="objectNameSingular"></param>
        /// <returns></returns>
        public static string CreateCreateUrlHtml(string createUrl, string createUrlClass, ModalDialogForm createPopupForm, string createActionPhrase, string objectNameSingular)
        {
            var createString = !string.IsNullOrEmpty(createActionPhrase) ? createActionPhrase : $"Create New {objectNameSingular}";
            var createUrlHtml = String.Empty;
            if (!String.IsNullOrWhiteSpace(createUrl))
            {
                createUrlHtml = String.Format(@"<a class=""process create {0}"" href=""{1}"" title=""{2}"">{2}</a>",
                    String.IsNullOrEmpty(createUrlClass) ? String.Empty : createUrlClass,
                    createUrl,
                    createString);
            }
            else if (createPopupForm != null)
            {
                createUrlHtml = MakeModalDialogLink($"{PlusIconBootstrap} {createString}",
                    createPopupForm.ContentUrl,
                    createPopupForm.DialogWidth,
                    createPopupForm.DialogTitle,
                    true,
                    createPopupForm.SaveButtonText,
                    createPopupForm.CancelButtonText,
                    null,
                    createPopupForm.OnJavascriptReadyFunction,
                    null).ToString();
            }
            return createUrlHtml;
        }
        
        /// <summary>
        /// Creates the filter icon
        /// If ShowFilterBar is false, it will return empty string
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="showFilterBar"></param>
        /// <returns></returns>
        public static string CreateFilterIconHtml(string gridName, bool showFilterBar)
        {
            if (showFilterBar)
            {
                return $@"<a class=""filter"" href=""javascript:void(0);"" onclick=""Sitka.{
                        gridName
                    }.showHideFilterRow()"" title=""Show/hide filters"">Show/hide filters</a>&nbsp;";
            }
            return String.Empty;
        }

        /// <summary>
        /// Creates the download to excel icon, using the filtered grid results
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="excelDownloadUrl"></param>
        /// <returns></returns>
        public static string CreateFilteredExcelDownloadIconHtml(string gridName, UrlTemplate<string> excelDownloadUrl)
        {
            if (excelDownloadUrl == null) return string.Empty;

            return
                String.Format(
                    @"<a class=""excelbutton"" id=""{0}DownloadLink"" href=""javascript:void(0)"" onclick=""Sitka.{0}.sitkaGridToExcel({1})"" title=""Download this table as an Excel file"">Download Table</a>",
                    gridName,
                    excelDownloadUrl.ParameterReplace(gridName).ToJS());
        }

        /// <summary>
        /// Creates the download to excel icon
        /// If exceldownloadurl is null or empty, will return empty string
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="excelDownloadUrl"></param>
        /// <param name="linkText"></param>
        /// <param name="hoverText"></param>
        /// <returns></returns>
        public static string CreateCustomExcelDownloadIconHtml(string gridName, string excelDownloadUrl, string linkText, string hoverText)
        {
            if (!String.IsNullOrWhiteSpace(excelDownloadUrl))
            {
                return $@"<a class=""excelbutton"" id=""{
                        gridName
                    }ExcelDownloadLink"" href=""{excelDownloadUrl}"" title=""{hoverText}"">{linkText}</a>";
            }
            return String.Empty;
        }

        /// <summary>
        /// Creates the download to csv icon
        /// If exceldownloadurl is null or empty, will return empty string
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="csvDownloadUrl"></param>
        /// <returns></returns>
        public static string CreateCsvDownloadIconHtml(string gridName, string csvDownloadUrl)
        {
            if (!String.IsNullOrWhiteSpace(csvDownloadUrl))
            {
                return $@"<a class=""process download"" id=""{gridName}DownloadLink"" href=""{
                        csvDownloadUrl
                    }"" title=""Download this grid as a CSV file"">Download</a>";
            }
            return String.Empty;
        }

        public static string CreateFullDatabaseExcelDownloadIconHtml(string gridName, string excelDownloadUrl, string excelDownloadLinkText)
        {
            return CreateCustomExcelDownloadIconHtml(gridName, excelDownloadUrl, excelDownloadLinkText, "Download the full database as an Excel file");
        }

        /// <summary>
        /// Html that shows the grid row count "Viewing ..."
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="objectNamePlural"></param>
        /// <returns></returns>
        public static string CreateViewingRowCountGridHeaderHtml(string gridName, string objectNamePlural)
        {
            return String.Format("Currently viewing <span id=\"{0}FilteredRowCount\"></span> of <span id=\"{0}UnfilteredRowCount\"></span> {1}", gridName, objectNamePlural);
        }

        /// <summary>
        /// Html that shows the count of checked checkboxes "Number of selected rows ..."
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="objectNamePlural"></param>
        /// <returns></returns>
        public static string CreateViewingCheckedCheckboxesCountGridHeaderHtml(string gridName, string objectNamePlural)
        {
            return String.Format("Selected rows: <span id=\"{0}CheckedCheckboxCount\"></span> ", gridName);
        }

        /// <summary>
        /// Determines if the grid should be using smart rendering
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridSpec"></param>
        /// <returns></returns>
        public static bool IsUsingSmartRendering<T>(GridSpec<T> gridSpec)
        {
            return !gridSpec.HasColumnTotals;
        }

        /// <summary>
        /// Builds the javascript for adding the columns to the sitkaGrid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridSpec"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        public static string BuildGridColumns<T>(IEnumerable<ColumnSpec<T>> gridSpec, string indent)
        {
            return String.Join(",\r\n",
                gridSpec.Select(
                    (column, i) =>
                        $@"{indent}new Sitka.Grid.Class.GridColumn(""{
                                (String.IsNullOrWhiteSpace(column.ColumnNameForJavascript)
                                    ? $"Column{i}"
                                    : column.ColumnNameForJavascript)
                            }"", {
                                (string.IsNullOrWhiteSpace(column.ColumnName) ? "\"\"" : column.ColumnName.ToJS())
                            }, ""{
                                column.GridWidth.ToString(CultureInfo.InvariantCulture)
                            }"", ""{column.AgGridColumnAlignType.ToString().ToLower()}"", ""{
                                column.AgGridColumnDataType
                            }"", ""{column.AgGridColumnSortType.SortingType}"", ""{
                                column.AgGridColumnFilterType
                            }"", {$"\"{column.AgGridColumnFormatType}\""})"));
        }

        /// <summary>
        /// For making an edit icon on the grid that goes to a new page
        /// If insufficient permissions, returns empty string
        /// </summary>
        /// <param name="editUrl"></param>
        /// <param name="hasPermission"></param>
        /// <returns></returns>
        public static HtmlString MakeEditIconAsHyperlink(string editUrl, bool hasPermission)
        {
            return hasPermission ? UrlTemplate.MakeHrefString(editUrl,
                $"{EditIcon}<span style=\"display:none\">Edit</span>") : new HtmlString(string.Empty);
        }

        /// <summary>
        /// For making an edit icon on the grid that goes to a new page
        /// </summary>
        /// <param name="editUrl"></param>
        /// <returns></returns>
        public static HtmlString MakeEditIconAsHyperlink(string editUrl)
        {
            return MakeEditIconAsHyperlink(editUrl, true);
        }

        /// <summary>
        /// For making an edit icon on the grid that goes to a new page
        /// If insufficient permissions, returns empty string
        /// </summary>
        /// <param name="editUrl"></param>
        /// <param name="hasPermission"></param>
        /// <returns></returns>
        public static HtmlString MakeEditIconAsHyperlinkBootstrap(string editUrl, bool hasPermission)
        {
            return hasPermission ? UrlTemplate.MakeHrefString(editUrl,
                $"{EditIconBootstrap}<span style=\"display:none\">Edit</span>") : new HtmlString(string.Empty);
        }

        /// <summary>
        /// For making an edit icon on the grid that goes to a new page
        /// </summary>
        /// <param name="editUrl"></param>
        /// <returns></returns>
        public static HtmlString MakeEditIconAsHyperlinkBootstrap(string editUrl)
        {
            return MakeEditIconAsHyperlinkBootstrap(editUrl, true);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// If insufficient permissions, returns empty string
        /// </summary>
        public static HtmlString MakeModalDialogLink(string linkHtml, string dialogContentUrl, int dialogWidth, string dialogTitle, bool hasPermission, string saveButtonText, string cancelButtonText, List<string> extraCssClasses, string onJavascriptReadyFunction, string postData)
        {
            if (hasPermission)
            {
                return ModalDialogFormHelper.ModalDialogFormLink(linkHtml, dialogContentUrl, dialogTitle, dialogWidth, saveButtonText, cancelButtonText, extraCssClasses, onJavascriptReadyFunction, postData);
            }
            return new HtmlString(String.Empty);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeModalDialogLink(string linkHtml, string dialogContentUrl, int dialogWidth, string dialogTitle, string onJavascriptReadyFunction)
        {
            return MakeModalDialogLink(linkHtml, dialogContentUrl, dialogWidth, dialogTitle, true, "Save", "Cancel", new List<string>(), onJavascriptReadyFunction, null);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeEditIconAsModalDialogLink(ModalDialogForm modalDialogForm)
        {
            return MakeModalDialogLink($"{EditIcon}<span style=\"display:none\">Edit</span>", modalDialogForm.ContentUrl, modalDialogForm.DialogWidth, modalDialogForm.DialogTitle, modalDialogForm.OnJavascriptReadyFunction);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeEditIconAsModalDialogLinkBootstrap(ModalDialogForm modalDialogForm)
        {
            return MakeModalDialogLink($"{EditIconBootstrap}<span style=\"display:none\">Edit</span>", modalDialogForm.ContentUrl, modalDialogForm.DialogWidth, modalDialogForm.DialogTitle, modalDialogForm.OnJavascriptReadyFunction);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeEditIconAsModalDialogLinkBootstrap(string editDialogUrl, string formTitle)
        {
            return MakeModalDialogLink($"{EditIconBootstrap}<span style=\"display:none\">Edit</span>", editDialogUrl, ModalDialogFormHelper.DefaultDialogWidth, formTitle, null);
        }

        /// <summary>
        /// For making an edit icon on the grid with an edit jquery ui dialog confirm.
        /// Will make a grey edit icon if edit is not possible. *** WILL NOT PREVENT AN EDIT FROM HAPPENING! YOU MUST ENFORCE AT THE CONTROLLER LEVEL ***
        /// </summary>
        /// <param name="editDialogUrl"></param>
        /// <param name="formTitle"></param>
        /// <param name="editPossibleForObject">Is an edit possible for the given object?</param>
        /// <returns></returns>
        public static HtmlString MakeEditIconAsModalDialogLinkBootstrap(string editDialogUrl, string formTitle, bool editPossibleForObject)
        {
            var editIcon = editPossibleForObject ? $"{EditIconBootstrap}<span style=\"display:none\">Edit</span>"
                : BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-edit gi-1x disabled").ToString();
            return MakeModalDialogLink(editIcon, editDialogUrl, ModalDialogFormHelper.DefaultDialogWidth, formTitle, null);
        }

        /// <summary>
        /// For making a plus icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakePlusIconAsModalDialogLinkBootstrap(string editDialogUrl, string formTitle)
        {
            return MakeModalDialogLink($"{PlusIconBootstrap}", editDialogUrl, ModalDialogFormHelper.DefaultDialogWidth, formTitle, null);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeLtInfoEditIconAsModalDialogLinkBootstrap(ModalDialogForm modalDialogForm)
        {
            string linkText = $"{EditIconBootstrap}<span style=\"display:none\">Edit</span>";
            List<string> extraCssClasses = new List<string>();
            return ModalDialogFormHelper.ModalDialogFormLink(null,
                linkText,
                modalDialogForm.ContentUrl,
                modalDialogForm.DialogTitle,
                modalDialogForm.DialogWidth,
                ModalDialogFormHelper.SaveButtonID,
                "Save",
                "Cancel",
                extraCssClasses,
                modalDialogForm.OnJavascriptReadyFunction,
                null,
                null);
        }

        /// <summary>
        /// For making a delete icon on the grid with a delete jquery ui dialog confirm
        /// </summary>
        /// <param name="deleteDialogUrl"></param>
        /// <param name="userHasDeletePermission"></param>
        /// <returns></returns>
        public static HtmlString MakeDeleteIconAndLink(string deleteDialogUrl, bool userHasDeletePermission)
        {
            return MakeDeleteIconAndLink(deleteDialogUrl, userHasDeletePermission, true);
        }

        /// <summary>
        /// For making a delete icon on the grid with a delete jquery ui dialog confirm.
        /// Will make a grey trash can icon if delete is not possible.
        /// </summary>
        /// <param name="deleteDialogUrl"></param>
        /// <param name="userHasDeletePermission">Does the given user have permission to perform a delete?</param>
        /// <param name="deletePossibleForObject">Is a delete possible for the given object?</param>
        /// <returns></returns>
        public static HtmlString MakeDeleteIconAndLink(string deleteDialogUrl, bool userHasDeletePermission, bool deletePossibleForObject)
        {
            var deleteIcon = deletePossibleForObject ? DeleteIcon : DeleteIconGrey;
            return ModalDialogFormHelper.MakeDeleteLink($"{deleteIcon}<span style=\"display:none\">Delete</span>", deleteDialogUrl, new List<string>(), userHasDeletePermission);
        }

        /// <summary>
        /// For making a delete icon on the grid with a delete jquery ui dialog confirm
        /// </summary>
        /// <param name="deleteDialogUrl"></param>
        /// <param name="userHasDeletePermission"></param>
        /// <returns></returns>
        public static HtmlString MakeDeleteIconAndLinkBootstrap(string deleteDialogUrl, bool userHasDeletePermission)
        {
            return MakeDeleteIconAndLinkBootstrap(deleteDialogUrl, userHasDeletePermission, true);
        }

        /// <summary>
        /// For making a delete icon on the grid with a delete jquery ui dialog confirm.
        /// Will make a grey trash can icon if delete is not possible. *** WILL NOT PREVENT A DELETE FROM HAPPENING! YOU MUST ENFORCE AT THE CONTROLLER LEVEL ***
        /// </summary>
        /// <param name="deleteDialogUrl"></param>
        /// <param name="userHasDeletePermission">Does the given user have permission to perform a delete?</param>
        /// <param name="deletePossibleForObject">Is a delete possible for the given object?</param>
        /// <returns></returns>
        public static HtmlString MakeDeleteIconAndLinkBootstrap(string deleteDialogUrl, bool userHasDeletePermission, bool deletePossibleForObject)
        {
            var deleteIcon = deletePossibleForObject ? $"{DeleteIconBootstrap}<span style=\"display:none\">Delete</span>"
                : BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-trash gi-1x disabled").ToString();
            return ModalDialogFormHelper.MakeDeleteLink(deleteIcon, deleteDialogUrl, new List<string>(), userHasDeletePermission);
        }
    }
}
