/*-----------------------------------------------------------------------
<copyright file="DhtmlxGridHtmlHelpers.cs" company="Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.ModalDialog;

namespace LtInfo.Common.DhtmlWrappers
{
    /// <summary>
    ///     Helper class for DhtmlxGrid expects following content to be set up in local project
    ///     /Content/css/dhtmlxgrid_skin.css
    ///     /Content/img/bg-edit-single.png
    ///     /Content/img/bg-delete-single.png
    /// </summary>
    public static class DhtmlxGridHtmlHelpers
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
        public static HtmlString DhtmlxGrid<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString)
        {
            return new HtmlString(DhtmlxGridImpl(gridSpec, gridName, optionalGridDataUrl, styleString, null, string.Empty, DhtmlxGridResizeType.None));
        }

        public static string DhtmlxGridImpl<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString, int? splitAtColumn)
        {
            return DhtmlxGridImpl(gridSpec, gridName, optionalGridDataUrl, styleString, splitAtColumn, string.Empty, DhtmlxGridResizeType.None);
        }

        public static string DhtmlxGridImpl<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString, int? splitAtColumn, string metaDivHtml, DhtmlxGridResizeType dhtmlxGridResizeType)
        {
            const string template =
                @"
<div id =""{0}ContainerDivID"">
    <div id=""{0}LoadingBar"" style=""display:none"">{1}</div>
    <div id=""{0}MetaDivID"" class=""DhtmlxGridMeta"">{2}</div>
    <div id=""{0}DivID"" style=""{3}""></div>
    <script type=""text/javascript"">
    // <![CDATA[
        {4}
    // ]]>
    </script>
</div>";
            var javascriptDocumentReadyHtml = RenderGridJavascriptDocumentReady(gridSpec, gridName, optionalGridDataUrl,
                splitAtColumn, dhtmlxGridResizeType);

            return String.Format(template, gridName, gridSpec.LoadingBarHtml, metaDivHtml, styleString, javascriptDocumentReadyHtml);
        }

        /// <summary>
        /// Template for <see cref="RenderGridJavascriptDocumentReady{T}"/>
        /// </summary>
        private const string GridJavascriptDocumentReady = @"
    jQuery(document).ready(function ()
    {{
        // Initialize Grid
        Sitka.{0} = new Sitka.Grid.Class.Grid(""{0}"", ""{0}DivID"", null, ""scrollToFirst"", ""{1}"", {2});
        // Initialize Grid Columns
        Sitka.{0}.setGridColumns(
        [
{3}
        ]);

        var columnFilterList = ""{4}"";
        {5}
        
        Sitka.{0}.buildWithArguments(null, {6}, columnFilterList, {7}, {8}, {9});

        // Show loading bar
        jQuery(""#{0}LoadingBar"").show();

        Sitka.{0}.grid.attachEvent(""onXLE"", function (gridObj, count){{
            var showFilterBar = {10};
            Sitka.{0}.unfilteredRowCount = Sitka.{0}.grid.getRowsNum();
            if(showFilterBar)
            {{
                Sitka.{0}.setupCookieFiltering(""{0}FilteredButton"");
                Sitka.{0}.setupFilterCountElement(""{0}FilteredRowCount"");
                Sitka.{0}.setFilteringButtonTagName(""{0}FilteredButton"");
            }}
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
        /// <param name="dhtmlxGridResizeType"></param>
        /// <returns></returns>
        private static string RenderGridJavascriptDocumentReady<T>(GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, int? splitAtColumn, DhtmlxGridResizeType dhtmlxGridResizeType)
        {
            const string indent = "            ";
            var gridColumnsJavascriptFunctions = BuildGridColumns(gridSpec, indent);
            var dataUrlReadyForJavascript = String.IsNullOrWhiteSpace(optionalGridDataUrl) ? "null" : String.Format("\"{0}\"", optionalGridDataUrl);
            var useSmartRendering = IsUsingSmartRendering(gridSpec);
            var splitAtColumnJavascriptVariable = (splitAtColumn != null) ? splitAtColumn.ToString() : "null";
            
            var resizeGridFunction = dhtmlxGridResizeType == DhtmlxGridResizeType.VerticalFillHorizontalAutoFit
                ? GenerateVerticalFillResizeGridFunction(gridName)
                : string.Empty;

            var verticalResizeFunction = dhtmlxGridResizeType == DhtmlxGridResizeType.VerticalResizableHorizontalAutoFit 
                ? GenerateVerticallyResizableFunction(gridName) 
                : string.Empty;

            var result = String.Format(GridJavascriptDocumentReady,
                gridName,
                Skin,
                SkinRowHeight,
                gridColumnsJavascriptFunctions,
                gridSpec.ColumnFilterListForJavascript,
                gridSpec.GetColumnTotals(gridName),
                string.IsNullOrWhiteSpace(gridSpec.GroupingHeader) ? "null" : string.Format("\"{0}\"", gridSpec.GroupingHeader),
                dataUrlReadyForJavascript,
                useSmartRendering.ToString().ToLower(),
                splitAtColumnJavascriptVariable,
                gridSpec.ShowFilterBar.ToString().ToLower(),
                gridSpec.GridInstructionsWhenEmpty,
                verticalResizeFunction,
                resizeGridFunction);

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

        public static string BuildDhtmlxGridHeader<T>(GridSpec<T> gridSpec, string gridName, UrlTemplate<string> excelDownloadWithFooterUrl, UrlTemplate<string> excelDownloadWithoutFooterUrl)
        {
            var filteredStateHtml = CreateFilteredStateHtml(gridName, gridSpec.ShowFilterBar);
            var gridHeaderIconsHtml = CreateGridHeaderIconsHtml(gridSpec, gridName, excelDownloadWithFooterUrl, excelDownloadWithoutFooterUrl);

            return String.Format(@"
    <span class=""record-count"">
        {0}
        {1}
    </span>
    <span class=""actions pull-right"">
    {2}
    </span>", CreateViewingRowCountGridHeaderHtml(gridName, gridSpec.ObjectNamePlural), filteredStateHtml, gridHeaderIconsHtml);
        }

        private static string CreateGridHeaderIconsHtml<T>(GridSpec<T> gridSpec, string gridName, UrlTemplate<string> excelDownloadWithFooterUrl, UrlTemplate<string> excelDownloadWithoutFooterUrl)
        {
            var clearCookiesIconHtml = CreateClearAllCookiesIconHtml(gridName);
            var filteredExcelDownloadIconHtml = CreateFilteredExcelDownloadIconHtml(gridName, gridSpec.HasColumnTotals, excelDownloadWithFooterUrl, excelDownloadWithoutFooterUrl);
            var customExcelDownloadIconHtml = CreateFullDatabaseExcelDownloadIconHtml(gridName, gridSpec.CustomExcelDownloadUrl);
            var createIconHtml = CreateCreateUrlHtml(gridSpec.CreateEntityUrl, gridSpec.CreateEntityUrlClass, gridSpec.CreateEntityModalDialogForm, gridSpec.CreateEntityActionPhrase, gridSpec.ObjectNameSingular);
            var tagIconHtml = CreateTagUrlHtml(gridName, gridSpec.BulkTagModalDialogForm);
            var arbitraryHtml = CreateArbitraryHtml(gridSpec.ArbitraryHtml, "    ");
            return String.Format(@"
            {0}
            {1}
            {2}
            {3}
            {4}
            {5}", !string.IsNullOrWhiteSpace(arbitraryHtml) ? string.Format("<span>{0}</span>", arbitraryHtml) : string.Empty,
                !string.IsNullOrWhiteSpace(createIconHtml) ? string.Format("<span>{0}</span>", createIconHtml) : string.Empty,
                !string.IsNullOrWhiteSpace(tagIconHtml) ? string.Format("<span>{0}</span>", tagIconHtml) : string.Empty,
                !string.IsNullOrWhiteSpace(clearCookiesIconHtml) ? string.Format("<span>{0}</span>", clearCookiesIconHtml) : string.Empty,
                !string.IsNullOrWhiteSpace(filteredExcelDownloadIconHtml) ? string.Format("<span>{0}</span>", filteredExcelDownloadIconHtml) : string.Empty,
                !string.IsNullOrWhiteSpace(customExcelDownloadIconHtml) ? string.Format("<span>{0}</span>", customExcelDownloadIconHtml) : string.Empty);
        }

        public static string CreateTagUrlHtml(string gridName, BulkTagModalDialogForm bulkTagModalDialogForm)
        {
            if (bulkTagModalDialogForm == null)
                return string.Empty;

            var tagIconHtml = string.Format("<span style=\"margin-right:5px\">{0}</span>", BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-tag"));

            var getProjectIDFunctionString = string.Format("function() {{ return Sitka.{0}.getValuesFromCheckedGridRows({1}, '{2}', '{3}'); }}",
                gridName,
                bulkTagModalDialogForm.CheckboxColumnIndex,
                bulkTagModalDialogForm.ValueColumnName,
                bulkTagModalDialogForm.ReturnListName);

            return
                ModalDialogFormHelper.ModalDialogFormLink(string.Format("{0}{1}", tagIconHtml, bulkTagModalDialogForm.DialogLinkText),
                    bulkTagModalDialogForm.DialogUrl,
                    bulkTagModalDialogForm.DialogTitle,
                    ModalDialogFormHelper.DefaultDialogWidth,
                    "Save",
                    "Cancel",
                    new List<string>(),
                    null,
                    getProjectIDFunctionString).ToString();
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
            return arbitraryHtml != null ? String.Join("\r\n", arbitraryHtml.Select(x => String.Format("{0}{1}", indent, x))) : String.Empty;
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
            var createString = !string.IsNullOrEmpty(createActionPhrase) ? createActionPhrase : String.Format("Create New {0}", objectNameSingular);
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
                createUrlHtml = MakeModalDialogLink(string.Format("{0} {1}", PlusIconBootstrap, createString),
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
        /// Creates the clear all cookies icon
        /// </summary>
        /// <param name="gridName"></param>
        /// <returns></returns>
        public static string CreateClearAllCookiesIconHtml(string gridName)
        {
            return
                String.Format(
                    @"<a href=""javascript:void(0);"" onclick=""Sitka.{0}.clearAllCookies()"" title=""Reset this grid to default column widths and filters"">{1} Reset</a>&nbsp;",
                    gridName, UndoIconBootstrap);
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
                return String.Format(@"<a class=""filter"" href=""javascript:void(0);"" onclick=""Sitka.{0}.showHideFilterRow()"" title=""Show/hide filters"">Show/hide filters</a>&nbsp;", gridName);
            }
            return String.Empty;
        }

        /// <summary>
        /// Creates the download to excel icon, using the filtered grid results
        /// </summary>
        /// <param name="gridName"></param>
        /// <param name="printFooter"></param>
        /// <param name="excelDownloadWithFooterUrl"></param>
        /// <param name="excelDownloadWithoutFooterUrl"></param>
        /// <returns></returns>
        public static string CreateFilteredExcelDownloadIconHtml(string gridName, bool printFooter, UrlTemplate<string> excelDownloadWithFooterUrl, UrlTemplate<string> excelDownloadWithoutFooterUrl)
        {
            if (excelDownloadWithFooterUrl == null || excelDownloadWithoutFooterUrl == null) return string.Empty;

            return
                String.Format(
                    @"<a class=""excelbutton"" id=""{0}DownloadLink"" href=""javascript:void(0)"" onclick=""Sitka.{0}.grid.toExcel({1})"" title=""Download this table as an Excel file"">Download Table</a>",
                    gridName,
                    printFooter ? excelDownloadWithFooterUrl.ParameterReplace(gridName).ToJS() : excelDownloadWithoutFooterUrl.ParameterReplace(gridName).ToJS());
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
                return String.Format(@"<a class=""excelbutton"" id=""{0}ExcelDownloadLink"" href=""{1}"" title=""{2}"">{3}</a>",
                    gridName,
                    excelDownloadUrl,
                    hoverText,
                    linkText);
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
                return String.Format(@"<a class=""process download"" id=""{0}DownloadLink"" href=""{1}"" title=""Download this grid as a CSV file"">Download</a>", gridName, csvDownloadUrl);
            }
            return String.Empty;
        }

        public static string CreateFullDatabaseExcelDownloadIconHtml(string gridName, string excelDownloadUrl)
        {
            return CreateCustomExcelDownloadIconHtml(gridName, excelDownloadUrl, "Download Full Database", "Download the full database as an Excel file");
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
                        String.Format(
                            @"{0}new Sitka.Grid.Class.GridColumn(""{1}"", {2}, ""{3}"", ""{4}"", ""{5}"", ""{6}"", ""{7}"", {8})",
                            indent,
                            String.IsNullOrWhiteSpace(column.ColumnNameForJavascript)
                                ? String.Format("Column{0}", i)
                                : column.ColumnNameForJavascript,
                            string.IsNullOrWhiteSpace(column.ColumnName) ? "\"\"" : column.ColumnName.ToJS(),
                            column.GridWidth.ToString(CultureInfo.InvariantCulture),
                            column.DhtmlxGridColumnAlignType.ToString().ToLower(), column.DhtmlxGridColumnDataType,
                            column.DhtmlxGridColumnSortType.SortingType, column.DhtmlxGridColumnFilterType,
                            string.Format("\"{0}\"", column.DhtmlxGridColumnFormatType.ColumnFormatType))));
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
            return hasPermission ? UrlTemplate.MakeHrefString(editUrl, String.Format("{0}<span style=\"display:none\">Edit</span>", EditIcon)) : new HtmlString(string.Empty);
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
            return hasPermission ? UrlTemplate.MakeHrefString(editUrl, String.Format("{0}<span style=\"display:none\">Edit</span>", EditIconBootstrap)) : new HtmlString(string.Empty);
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
            return MakeModalDialogLink(String.Format("{0}<span style=\"display:none\">Edit</span>", EditIcon), modalDialogForm.ContentUrl, modalDialogForm.DialogWidth, modalDialogForm.DialogTitle, modalDialogForm.OnJavascriptReadyFunction);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeEditIconAsModalDialogLinkBootstrap(ModalDialogForm modalDialogForm)
        {
            return MakeModalDialogLink(String.Format("{0}<span style=\"display:none\">Edit</span>", EditIconBootstrap), modalDialogForm.ContentUrl, modalDialogForm.DialogWidth, modalDialogForm.DialogTitle, modalDialogForm.OnJavascriptReadyFunction);
        }

        /// <summary>
        /// For making an edit icon on the grid with an editor in a jquery ui dialog
        /// </summary>
        public static HtmlString MakeLtInfoEditIconAsModalDialogLinkBootstrap(ModalDialogForm modalDialogForm)
        {
            string linkText = String.Format("{0}<span style=\"display:none\">Edit</span>", EditIconBootstrap);
            List<string> extraCssClasses = new List<string>();
            return ModalDialogFormHelper.ModalDialogFormLink(null,
                linkText,
                modalDialogForm.ContentUrl,
                modalDialogForm.DialogTitle,
                modalDialogForm.DialogWidth,
                ModalDialogFormHelper.SaveButtonId,
                "Save",
                ModalDialogFormHelper.CancelButtonId,
                "Cancel",
                extraCssClasses,
                modalDialogForm.OnJavascriptReadyFunction,
                null,
                null,
                new List<string>(){"btn-firma"});
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
            return ModalDialogFormHelper.MakeDeleteLink(String.Format("{0}<span style=\"display:none\">Delete</span>", deleteIcon), deleteDialogUrl, new List<string>(), userHasDeletePermission);
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
        /// Will make a grey trash can icon if delete is not possible.
        /// </summary>
        /// <param name="deleteDialogUrl"></param>
        /// <param name="userHasDeletePermission">Does the given user have permission to perform a delete?</param>
        /// <param name="deletePossibleForObject">Is a delete possible for the given object?</param>
        /// <returns></returns>
        public static HtmlString MakeDeleteIconAndLinkBootstrap(string deleteDialogUrl, bool userHasDeletePermission, bool deletePossibleForObject)
        {
            var deleteIcon = deletePossibleForObject ? string.Format("{0}<span style=\"display:none\">Delete</span>", DeleteIconBootstrap) : BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-trash gi-1x disabled").ToString();
            return ModalDialogFormHelper.MakeDeleteLink(deleteIcon, deleteDialogUrl, new List<string>(), userHasDeletePermission);
        }
    }

    public enum DhtmlxGridResizeType
    {
        VerticalResizableHorizontalAutoFit,
        VerticalFillHorizontalAutoFit,
        None
    }
}
