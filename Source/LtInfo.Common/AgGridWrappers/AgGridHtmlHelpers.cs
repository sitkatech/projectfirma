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
            return new HtmlString(AgGridImpl(gridSpec, gridName, optionalGridDataUrl, styleString, AgGridResizeType.None));
        }

        public static string AgGridImpl<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString)
        {
            return AgGridImpl(gridSpec, gridName, optionalGridDataUrl, styleString, AgGridResizeType.None);
        }

        public static string AgGridImpl<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString,  AgGridResizeType agGridResizeType)
        {


            const string template = @"    <!-- The div that will host the grid. ag-theme-alpine is the theme. -->
    <!-- The grid will be the size that this element is given. -->
    <div class=""row"">
        <div class=""col-md-6""><span id=""{0}RowCountText""></span> <a id=""{0}ClearFilters"" style=""display: none"" href=""javascript: void(0);"" onclick=""{0}ClearFilters()"">(clear filters)</a></div>
        <div class=""col-md-6 text-right gridDownloadContainer""><button onclick=""onBtnExport()"">Download grid as CSV file</button>{8}</div>
    </div>
    <div id=""{0}DivID"" class=""ag-theme-alpine"" style=""{6}""></div>
    <script type=""text/javascript"">

            function {0}ClearFilters(){{
                {0}GridOptions.api.setFilterModel(null);
                document.getElementById(""{0}ClearFilters"").style.display = ""none"";
            }}

            function onBtnExport() {{
                {0}GridOptions.api.exportDataAsCsv({{ fileName: '{0}' + 'Export' }});
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
                    case AgGridColumnFilterType.SelectFilterStrict:
                    case AgGridColumnFilterType.SelectFilterHtmlStrict:
                        //columnDefinitionStringBuilder.Append(", \"floatingFilterComponent\": DropdownFloatingFilterComponent");
                        //columnDefinitionStringBuilder.AppendFormat(", \"floatingFilterComponentParams\": {{suppressFilterButton: false, field: \"{0}\"}}", columnSpec.ColumnNameForJavascript);
                        columnDefinitionStringBuilder.Append(", \"filter\": DropdownFilterComponent");
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
                        columnDefinitionStringBuilder.Append(", \"floatingFilterComponent\": HtmlFloatingFilterComponent");
                        columnDefinitionStringBuilder.Append(", \"floatingFilterComponentParams\": {suppressFilterButton: true,}");
                        columnDefinitionStringBuilder.Append(", \"filter\": HtmlFilterComponent");
                        break;
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

            var customDownloadLink = CreateFullDatabaseExcelDownloadIconHtml(gridName, gridSpec.CustomExcelDownloadUrl, gridSpec.CustomExcelDownloadLinkText ?? "Download Full Database");

            return String.Format(template, gridName, optionalGridDataUrl, columnDefinitionStringBuilder, gridSpec.ObjectNamePlural, resizeGridFunction, makeVerticalResizable, styleString, columnsWithAggregationStringBuilder, customDownloadLink);//, gridSpec.LoadingBarHtml, metaDivHtml, styleString, javascriptDocumentReadyHtml);
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

        public static string CreateFullDatabaseExcelDownloadIconHtml(string gridName, string excelDownloadUrl, string excelDownloadLinkText)
        {
            return CreateCustomExcelDownloadIconHtml(gridName, excelDownloadUrl, excelDownloadLinkText, "Download the full database as an Excel file");
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
