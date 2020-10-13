/*-----------------------------------------------------------------------
<copyright file="sitka.grid.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
function htmlstring(a, b, order) {

    // Turn HTML into an element, then get text representations of them.
    // The DIV wrapping is intended to force JQuery to use the HTML constructor
    // versus an element selector. Otherwise we run the very real risk of something
    // in a string triggering a jQuery selector (like, "body" or "#element", etc.).
    //
    // It may not be 100% reliable, but it is definitely OK for our usual <a href..> happy
    // path, and will be more flexible than the last regex approach that ONLY worked
    // on <a href..>.
    //
    // -- MF & SLG

    //Added 'toLowerCase()' on these lines.  These creates consistent ordering behaviour on all browsers. 
    //The only impact this should have is if a project depends on the strict ordering behaviour in a specific browser, 
    //but I wouldn't suggest we rely on it since it could change at any moment per the browser spec/version.
    //      --Stryder 1/16/12
    var text1 = jQuery("<div>" + a + "</div>").text().toLowerCase();
    var text2 = jQuery("<div>" + b + "</div>").text().toLowerCase();


    //So, the following is no longer true:  --Stryder 1/16/12
    // This order will be consistent on a particular browser, but it does differ slightly between
    // Firefox & IE depending on case. The outlier is Chrome, which does something quite different
    // from the others, but is consistent and is a minority case.
    if (order == "asc")
        return text1.localeCompare(text2);
    else
        return text2.localeCompare(text1);
}
//because IE doesn't have 'indexOf'.
if (!Array.indexOf) {
    Array.prototype.indexOf = function (obj) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == obj) {
                return i;
            }
        }
        return -1;
    };
}


dhtmlXGridObject.prototype._in_header_formatted_numeric_filter_box = function (a, b) {
    a.innerHTML = "<input type=\"text\" style=\"width:90%; font-size:8pt; font-family:Tahoma; -moz-user-select:text; \">";
    a.onclick = a.onmousedown = function (a) { return (a || event).cancelBubble = !0; };
    a.onselectstart = function () { return event.cancelBubble = !0; };
    this.makeFilter(a.firstChild, b);
};

dhtmlXGridObject.prototype._in_header_date_range_filter = function (a, b) {
    var self = this;
    var dhtmlxGrid = this.SitkaGridContainer.grid;
    a.innerHTML = "<div style='width:100%; margin:0 auto; text-align: left;'>From: <input type='text' id='datefrom' style='width:60px;font-size:8pt;-moz-user-select:text; color:#000'><br />To: <input type='text' id='dateto' style='width:60px;font-size:8pt;-moz-user-select:text;color:#000;margin-left:16px'></div>";

    a.onclick = a.onmousedown = function (a) { return (a || event).cancelBubble = !0; };

    a.onselectstart = function () { return event.cancelBubble = !0; };

    var datefrom = this.getChildElement(a.firstChild, "datefrom");
    var dateto = this.getChildElement(a.firstChild, "dateto");

    var myCalendar = new dhtmlXCalendarObject([datefrom, dateto]);
    myCalendar.setDateFormat("%m/%d/%Y");      //Date format MM/DD/YYY
    myCalendar.attachEvent("onClick", function (date) { dhtmlxGrid.filterByAll(); });

    this.makeFilter(datefrom, b);
    this.makeFilter(dateto, b);

    datefrom._filter = function () {
        var a = this.value;
        return a == "" ? "" : function (b) {
            var aDate = new Date(Date.parse(a));
            var bDate = new Date(Date.parse(b));
            return aDate <= bDate;
        }
    }

    dateto._filter = function () {

        var a = this.value;
        return a == "" ? "" : function (b) {
            var aDate = new Date(Date.parse(a));
            var bDate = new Date(Date.parse(b));
            return aDate >= bDate;
        }
    }

    this._filters_ready();
};

//JHB 12/4/15: Replaced existing sort function with one that does a case-insentive string sort
dhtmlXGridObject.prototype._sortCore = function (col, type, order, arrTS, s) {
    var sort = "sort";

    if (this._sst) {
        s["stablesort"] = this.rowsCol.stablesort;
        sort = "stablesort";
    }
    //#__pro_feature:21092006{	
    //#custom_sort:21092006{
    if (type.length > 4)
        type = window[type];

    if (type == 'cus') {
        var cstr = this._customSorts[col];
        s[sort](function (a, b) {
            return cstr(arrTS[a.idd], arrTS[b.idd], order, a.idd, b.idd);
        });
    }
    else if (typeof (type) == 'function') {
        s[sort](function (a, b) {
            return type(arrTS[a.idd], arrTS[b.idd], order, a.idd, b.idd);
        });
    }
    else
        //#}
        //#}
        if (type == 'str') {
            s[sort](function (a, b) {
                var compA = arrTS[a.idd].toString().toLowerCase();
                var compB = arrTS[b.idd].toString().toLowerCase();
                if (order == "asc")
                    return compA > compB ? 1 : (compA < compB ? -1 : 0);
                else
                    return compA < compB ? 1 : (compA > compB ? -1 : 0);
            });
        }
        else if (type == 'num') {
            s[sort](function (a, b) {
                var aVal = parseFloat(arrTS[a.idd]);
                aVal = isNaN(aVal) ? -99999999999999 : aVal;
                var bVal = parseFloat(arrTS[b.idd]);
                bVal = isNaN(bVal) ? -99999999999999 : bVal;

                if (order == "asc")
                    return aVal - bVal;
                else
                    return bVal - aVal;
            });
        }
        else if (type == 'date') {
            s[sort](function (a, b) {
                var aVal = Date.parse(arrTS[a.idd]) || (Date.parse("01/01/1900"));
                var bVal = Date.parse(arrTS[b.idd]) || (Date.parse("01/01/1900"));

                if (order == "asc")
                    return aVal - bVal;
                else
                    return bVal - aVal;
            });
        }
};

dhtmlXGridObject.prototype.getChildElement = function (element, id) {
    for (var i = 0; i < element.childNodes.length; i++) {
        if (element.childNodes[i].id == id)
            return element.childNodes[i];
    }
    return null;
};

//this is pretty much the same thing as dhtmlxGridObjects Numeric_filter but with a stripNonNumeric function when evaluating cell content.
dhtmlXGridObject.prototype._in_header_formatted_numeric_filter = function (a, b) {
    this._in_header_html_filter.call(this, a, b);   //reuse the same input box construction
    a.firstChild._filter = function () {
        var a = this.value, b, e = "==", f = parseFloat(a.replace("=", "")), g = null;
        if (a) {
            if (a.indexOf("..") != -1)
                return a = a.split(".."), f = parseFloat(a[0]), g = parseFloat(a[1]),
                function (a) {
                    a = stripNonNumeric(a);
                    return a >= f && a <= g ? !0 : !1;
                };
            if (b = a.match(/>=|<=|>|</))
                e = b[0], f = parseFloat(a.replace(e, ""));
            return Function("v", " if (stripNonNumeric(v) " + e + " " + f + " ) return true; return false;");
        }
        return "";
    };
};

function getCheckboxCellValue(a) {
    var elem = jQuery(jQuery(a).find("[type='checkbox']")[0]).attr('selected');

    var result = 2;
    if (elem != 'undefined') {
        result = elem ? 1 : 0;
    }
    return result;
}

function htmlcheckbox(a, b, order) {
    // Turn HTML into an element, then get text representations of them.
    // The DIV wrapping is intended to force JQuery to use the HTML constructor
    // versus an element selector. Otherwise we run the very real risk of something
    // in a string triggering a jQuery selector (like, "body" or "#element", etc.).
    //
    // It may not be 100% reliable, but it is definitely OK for our usual <a href..> happy
    // path, and will be more flexible than the last regex approach that ONLY worked
    // on <a href..>.
    //
    // -- MF & SLG

    var val1 = getCheckboxCellValue(a);
    var val2 = getCheckboxCellValue(b);

    var result = val1 >= val2;

    if (order == "asc")
        return val1 > val2;
    else
        return val2 > val1;
}

function stripNonNumeric(str) {
    str += '';
    var rgx = /^\d|\.|-$/;
    var out = '';

    for (var i = 0; i < str.length; i++) {

        if (rgx.test(str.charAt(i))) {

            if (!((str.charAt(i) == '.' && out.indexOf('.') != -1) ||
                (str.charAt(i) == '-' && out.length != 0))) {
                out += str.charAt(i);
            }
        }
    }
    return out;
}

function fmtint(a, b, c) {
    a = stripNonNumeric(a);
    b = stripNonNumeric(b);
    var e = parseFloat(a), e = isNaN(e) ? -99999999999999 : e, j = parseFloat(b), j = isNaN(j) ? -99999999999999 : j;
    return c == "asc" ? e - j : j - e;
}

function htmlinteger(a, b, order) {
    // Parse ID out of link and sort numerically
    // Assumes that the argument is a RESTful link where the text is a numeric ID
    var text1 = jQuery("<div>" + a + "</div>").text();
    var text2 = jQuery("<div>" + b + "</div>").text();

    var greaterThan = parseInt(text1) > parseInt(text2);

    if (order == "asc")
        return (greaterThan ? 1 : -1);
    else
        return (greaterThan ? -1 : 1);
}

Sitka.Grid =
{
    CellEditStage:
    {
        BeforeStart: 0,
        EditorOpened: 1,
        EditorClosed: 2
    }
};

Sitka.Grid.Class = {
    GridColumn: function (columnName, title, width, align, type, sorting, filtertype, formatType) {
        this.columnName = columnName;
        this.title = title;
        this.width = width;
        this.align = align;
        this.type = type;
        this.sorting = sorting;
        this.filtertype = filtertype;
        this.formatType = formatType;
    },
    Grid: function (gridName, gridElement, dataElement, scrollPosition, skin, skinRowHeight, saveGridSettingsUrl) {
        if (arguments.length != 7) {
            throw new Error("Expects exactly 7 arguments Sitka.Grid.Grid constructor but got " + arguments.length);
        }
        if (Sitka.Methods.isUndefinedNullOrEmpty(gridName)) {
            throw new Error("Required parameter gridName invalid. Must be unique to a particular grid on particular page.");
        }
        if (gridElement === undefined || gridElement === null) {
            throw new Error("Required parameter gridElement not provided Sitka.Grid.Grid constructor.");
        }
        if (dataElement === undefined) {
            // OK if this one is null
            throw new Error("Required parameter dataElement not provided Sitka.Grid.Grid constructor.");
        }
        if (scrollPosition === undefined || scrollPosition === null) {
            throw new Error("Required parameter scrollPosition not provided Sitka.Grid.Grid constructor.");
        }
        if (skin === undefined || skin === null) {
            throw new Error("Required parameter skin not provided Sitka.Grid.Grid constructor.");
        }
        if (skinRowHeight === undefined || skinRowHeight === null) {
            throw new Error("Required parameter skinRowHeight not provided Sitka.Grid.Grid constructor.");
        }

        this.gridName = gridName;
        this.uniqueGridName = "dhtml" + gridName;
        this.gridElement = gridElement;
        this.dataElement = null;
        this.filterCountElement = null;
        this.filterDownloadElement = null;
        this.saveGridSettingsUrl = saveGridSettingsUrl;

        if (dataElement) {
            this.dataElement = jQuery(dataElement);
            if (!this.dataElement) {
                throw new Error("Could not locate DOM element " + dataElement);
            }
        }

        this.skin = skin;
        this.awaitedRowHeight = skinRowHeight;

        this._columns = [];
        this.grid = null;
        this.grid = new dhtmlXGridObject(this.gridElement);

        this.grid.setImagePath("/content/dhtmlx/dhtmlxGrid/codebase/imgs/");

        this.htmlFilter.prototype = dhtmlXGridObject.prototype._in_header_text_filter.prototype;
        this.grid._in_header_html_filter = this.htmlFilter; // defines #html_filter shortcut in the header

        this.formattedNumericFilter.prototype = dhtmlXGridObject.prototype._in_header_formatted_numeric_filter.prototype;
        this.grid._in_header_formatted_numeric_filter.prototype = this.formattedNumericFilter;

        this.textWithDashesFilter.prototype = dhtmlXGridObject.prototype._in_header_text_filter.prototype;
        this.grid._in_header_text_withdashes_filter = this.textWithDashesFilter; // defines #text_withdashes_filter shortcut in the header

        this.strictHtmlFilter.prototype = dhtmlXGridObject.prototype._in_header_select_filter_strict.prototype;
        this.grid._in_header_select_filter_html_strict = this.strictHtmlFilter; // defines #select_filter_html_strict shortcut in the header

        this.grid.SitkaGridContainer = this; // give the grid a pointer back to us (this) for event handling

        this.attachedStatReady = false;

        this.SCROLL_TO_FIRST = "scrollToFirst";
        this.SCROLL_TO_LAST = "scrollToLast";

        this.scrollPosition = scrollPosition;
        if (this.scrollPosition != this.SCROLL_TO_FIRST && this.scrollPosition != this.SCROLL_TO_LAST) {
            throw new Error("Unknown scrollPosition " + scrollPosition);
        }
        this.footerFormatters = new Array();
    }
};
Sitka.Grid.Class.Grid.prototype.setGridColumns = function (gridColumns) {
    this._columns = _(gridColumns);
};

Sitka.Grid.Class.Grid.prototype.getColumnIndexByName = function (columnName) {
    return this._columns.pluck("columnName").indexOf(columnName);
};

Sitka.Grid.Class.Grid.prototype.htmlFilter = function (t, i) {
    dhtmlXGridObject.prototype._in_header_text_filter.call(this, t, i);
    t.firstChild._filter = function () {
        return function (value) {
            var filterData = t.firstChild.value;
            var textToSearch = value.toString().replace(/<[^>]*>/g, "");
            var foundInText = (textToSearch.toLowerCase().indexOf(filterData.toLowerCase()) != -1);
            if (!foundInText) {
                // strip out dashes on both filter criteria and data so if it's a project number, it'll match...
                // TODO: this is Taurus-specific!
                foundInText = (textToSearch.replace(/-/g, "").indexOf(filterData.replace(/-/g, "")) != -1);
            }
            return foundInText;
        };
    };
};
Sitka.Grid.Class.Grid.prototype.formattedNumericFilter = function (t, i) { var g = t; };

//TODO: Develop tests and handle error cases
Sitka.Grid.Class.Grid.prototype.getValuesFromCheckedGridRows = function (checkBoxColumnIndex, valueColumnName, returnListName) {
    var checkedRows = this.grid.getCheckedRows(checkBoxColumnIndex);
    var self = this;
    var values = Sitka.Methods.isUndefinedNullOrEmpty(checkedRows) ? [] : _.map(checkedRows.split(","), function (m) { return self.grid.cells(m, self.getColumnIndexByName(valueColumnName)).getValue(); });
    var returnList = new Object();
    returnList[returnListName] = values;
    return returnList;
};

var sitkaGridFilterSelectpickerOptions = {
    container: "body",
    width: "100%",
    noneSelectedText: "",
    actionsBox: true,
    selectedTextFormat: "count > 1"
}

// we want to intercept the call when dhtmlx builds up the list of select option items, to transform it into a multiselect
var sitkaGridOriginalLoadSelectOptions = dhtmlXGridObject.prototype._loadSelectOptins;
var sitkaGridLocallyDefinedMultiSelectLoadOptions = function (t, c) {
    // invoke original
    sitkaGridOriginalLoadSelectOptions.call(this, t, c);
    var selectObj = jQuery(t);
    // get rid of the empty option added in sitkaGridOriginalLoadSelectOptions, seems to confuse the multiselect
    selectObj.find("option[value='']").remove();
    selectObj.selectpicker(sitkaGridFilterSelectpickerOptions).selectpicker('refresh');
};
dhtmlXGridObject.prototype._loadSelectOptins = sitkaGridLocallyDefinedMultiSelectLoadOptions;

Sitka.Grid.Class.Grid.prototype.strictHtmlFilter = function (t, i) {
    dhtmlXGridObject.prototype._in_header_select_filter_strict.call(this, t, i);
    // override collectValues() - NB. this replaces it for *all* _select_filter_string filters in the current grid
    this.collectValues = function (column) {
        var value = this.callEvent("onCollectValues", [column]);
        if (value !== true)
            return value;

        if (this.isTreeGrid())
            return this.collectTreeValues(column);
        this.dma(true);
        column = this._m_order ? this._m_order[column] : column;
        var c = {};
        var f = [];
        this._build_m_order();
        var col = this._f_rowsBuffer || this.rowsBuffer;
        var currentColumn = this.hdr.grid.SitkaGridContainer._columns.value()[column];
        for (var i = 0; i < col.length; i++) {
            var val = this._get_cell_value(col[i], column);
            var isOptions = val.indexOf("<select") > -1;
            if ((typeof (val) == "string")                                                                              // sitka mods
                && (typeof (currentColumn.filtertype) !== "undefined")            // sitka mods
                && (currentColumn.filtertype == "#select_filter_html_strict")    // sitka mods
            ) {
                if (isOptions) {
                    var valueOptions = jQuery(val).children("option");
                    valueOptions.each(function () {
                        var valToAdd = jQuery(this).text();
                        if (valToAdd && (!col[i]._childIndexes || col[i]._childIndexes[column] != col[i]._childIndexes[column - 1])) {
                            c[decodeHtml(valToAdd)] = true;
                        }
                    });
                    val = jQuery(val).children("option:selected").text();
                }
                else {
                    val = val.toString().replace(/<[^>]*>/g, "");
                }
            }
            if (val && (!col[i]._childIndexes || col[i]._childIndexes[column] != col[i]._childIndexes[column - 1])) {
                c[decodeHtml(val)] = true;
            }
        }
        ;
        this.dma(false);

        var vals = this.combos[column];
        for (d in c)
            if (c[d] === true)
                f.push(vals ? (vals.get(d) || d) : d);
        return f.sort();
    };

    var tObj = jQuery(t);
    var jSelect = tObj.find("select.dhtmlx-grid-bootstrap-multiselect-filter");
    var jSelectElement = tObj.find("select.dhtmlx-grid-bootstrap-multiselect-filter").get()[0];
    jSelectElement._filter = function () {
        return function (value) {
            var allVals = jSelect.val();
            if (allVals == null) {
                return true;
            }
            var textToSearch = decodeHtml((value.toString().replace(/<[^>]*>/g, "")));
            var isOptionList = value.indexOf("<select") > -1;

            if (isOptionList) {
                textToSearch = jQuery(value).children("option:selected").text();
            }
            function insensitiveEqualHtml(element, index, array) {

                return element.toString().toLowerCase() === textToSearch.toString().toLowerCase();
            }
            return allVals.some(insensitiveEqualHtml);
        };
    };
};

// This is an edited version of _in_header_select_filter_strict found in dhtmlxgrid_filter.js, it adds multiselect attributes to the select element and creates a multiselect object, importantly it omits click handler for parent cell onclick
var sitkaGridLocallyDefinedMultiSelectFilter = function (t, i) {
    t.innerHTML = "<select style='width:90%; font-size:8pt; font-family:Tahoma;' class='dhtmlx-grid-bootstrap-multiselect-filter' multiple='multiple'></select>";
    var tObj = jQuery(t);
    tObj.addClass("dhtmlx-grid-bootstrap-multiselect-filter-container");
    var jSelect = tObj.find(".dhtmlx-grid-bootstrap-multiselect-filter");
    jSelect.selectpicker(sitkaGridFilterSelectpickerOptions);

    // we turn off the click event to prevent sorting the table when clicking in the multi's container td, this is for the thin area around the button
    tObj.click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        return false;
    });

    var selectElement = jQuery(t).find('select').get()[0];

    this.makeFilter(selectElement, i);
    var combos = this.combos;

    selectElement._filter = function () {
        return function (val) {
            var allVals = jSelect.val();
            if (allVals == null) {
                return true;
            }
            function insensitiveEqual(element, index, array) {
                return element.toString().toLowerCase() === val.toString().toLowerCase();
            }
            return allVals.some(insensitiveEqual);
        }
    }

    this._filters_ready();

    var firstTimeMultiselectClicked = true;
    var toggleBtn = tObj.find("button.dropdown-toggle");
    toggleBtn.css("padding", "2px");
    toggleBtn.click(function (e) {
        // stop propagation so will not trigger column sort
        e.stopPropagation();
        // There is some jack-assery wrt the grid and multiselect click events, you need to manually toggle the multi drop down once then it seems good.  Not sure what tragic comedy causes this junk.
        if (firstTimeMultiselectClicked) {
            toggleBtn.dropdown("toggle");
        }
        firstTimeMultiselectClicked = false;
    });
}

// we want to redefine everything from dhtmlx that renders a select to use our multi-select for a consistent appearance:
dhtmlXGridObject.prototype._in_header_select_filter_strict = sitkaGridLocallyDefinedMultiSelectFilter;
dhtmlXGridObject.prototype._in_header_select_filter = sitkaGridLocallyDefinedMultiSelectFilter;

Sitka.Grid.Class.Grid.prototype.textWithDashesFilter = function (t, i) {
    dhtmlXGridObject.prototype._in_header_text_filter.call(this, t, i);
    t.firstChild._filter = function () {
        return function (value) {
            var filterData = t.firstChild.value;
            var textToSearch = value.toString();
            var foundInText = (textToSearch.toLowerCase().indexOf(filterData.toLowerCase()) != -1);
            if (!foundInText) {
                // strip out dashes on both filter criteria and data so if it's a project number, it'll match...
                foundInText = (textToSearch.replace(/-/g, "").indexOf(filterData.replace(/-/g, "")) != -1);
            }
            return foundInText;
        };
    };
};

// Column index is zero based
Sitka.Grid.Class.Grid.prototype.sortOnOtherColumn = function (originalColumn, sortColumn) {
    this.grid.attachEvent("onBeforeSorting", function (ind, type, direction) {
        if (ind == originalColumn) {
            //passing in null so that the grid will look up the sort type of the targeted column.  SNC 5-30-12
            this.sortRows(sortColumn, null, direction);
            this.setSortImgState(true, ind, direction);
            return false;
        }
        return true;
    });
};

Sitka.Grid.Class.Grid.prototype.filterOnOtherColumn = function (originalColumn, filterColumn) {
    this.grid.attachEvent("onFilterStart", function (indexes, values) {
        var indexOfOriginalColumn = jQuery.inArray(originalColumn, indexes);
        if (indexOfOriginalColumn != -1) {
            for (var i = 0; i < indexes.length; ++i) {
                this.filterBy(indexes[i] == originalColumn ? filterColumn : indexes[i], values[i], i == 0 ? false : true);
            }
            this.callEvent("onFilterEnd", []);
            return false;
        }

        return true;
    });
};

Sitka.Grid.Class.Grid.prototype.showHideFilterRow = function (setToState) {
    var xhdrId = '#' + this.gridElement + ' div.xhdr';
    var objboxId = '#' + this.gridElement + ' div.objbox';
    var xhdr = jQuery(xhdrId);
    var objbox = jQuery(objboxId);
    var filterRow = this.grid.hdr.rows[2];
    var currentState = (filterRow.style.display == "none") ? 0 : 1;
    if (setToState == undefined) {
        setToState = !currentState;
    }
    if (currentState != setToState) {
        if (currentState) {
            this.clearGridFilters();
            filterRow.style.display = "none";
            xhdr.height(xhdr.height() - this.awaitedRowHeight);
            objbox.height(objbox.height() + this.awaitedRowHeight);
            //Sitka.Methods.createCookie(this.getGridCookieName() + "filterVisible", "0", null);
        }
        else {
            if (navigator.userAgent.indexOf("MSIE 7.0") >= 0) {
                filterRow.style.display = "inline";
            }
            else {
                filterRow.style.display = "table-row";
            }
            xhdr.height(xhdr.height() + this.awaitedRowHeight);
            objbox.height(objbox.height() - this.awaitedRowHeight);
            //Sitka.Methods.createCookie(this.getGridCookieName() + "filterVisible", "1", null);
        }
    }
};

Sitka.Grid.Class.Grid.prototype.showHideFilterInstructions = function () {
    var divName = '#' + this.gridElement + 'filterBox';
    var filterInstructions = jQuery(divName);
    (filterInstructions.is(":visible")) ? filterInstructions.hide() : filterInstructions.show();
};

// This is commented out because it is not currently being used. Leaving it here as a reminder when we might
// implement a separate feature to load saved values from the database.

//Sitka.Grid.Class.Grid.prototype.loadFilterRowState = function () {
//    var filterCookieString = Sitka.Methods.readCookie(this.getGridCookieName() + "filterVisible");
//    if ((filterCookieString) && (filterCookieString != "")) {
//        // Only try to restore grid values if there's a cookie saved
//        try {
//            this.showHideFilterRow(filterCookieString);
//        }
//        catch (ex) {
//            // erase cookie since something must be borked out with it...
//            Sitka.Methods.eraseCookie(this.getGridCookieName() + "filterVisible");
//        }
//    }
//};

Sitka.Grid.Class.Grid.prototype.setColumnNumberFormats = function (columnFormatTypes, formatTypeToMatch, numberFormat) {
    var match, fromIndex = 0;
    while ((match = columnFormatTypes.indexOf(formatTypeToMatch, fromIndex)) > -1) {
        this.grid.setNumberFormat(numberFormat, match, ".", ",");
        fromIndex = match + 1;
    }
};

Sitka.Grid.Class.Grid.prototype.buildWithArguments = function (hideHeader, groupingHeader, filterHeader, dataUrl, useSmartRendering, splitAtColumn) {
    this.dataUrl = dataUrl;
    if (dataUrl == null) {
        this.grid.startFastOperations();
    }
    var columnTitles = this._columns.pluck("title").value();

    if (groupingHeader) {
        this.grid.setHeader(groupingHeader);
        this.grid.attachHeader(columnTitles);
    }
    else {
        this.grid.setHeader(columnTitles);
    }

    if (filterHeader) {
        this.grid.attachHeader(filterHeader);
    }

    this.grid.setInitWidths(this._columns.pluck("width").join());
    this.grid.setColAlign(this._columns.pluck("align").join());
    var columnTypes = this._columns.pluck("type");
    this.grid.setColTypes(columnTypes.join());

    // set the number formats for each column
    var columnFormatTypes = this._columns.pluck("formatType");
    this.setColumnNumberFormats(columnFormatTypes, "integerSitka", "0,000");
    this.setColumnNumberFormats(columnFormatTypes, "percentSitka", "0.00%");
    this.setColumnNumberFormats(columnFormatTypes, "currencySitka", "$0,000");
    this.setColumnNumberFormats(columnFormatTypes, "decimalSitka", "0,000.00");
    this.setColumnNumberFormats(columnFormatTypes, "latLongSitka", "000.000");

    this.grid.setColSorting(this._columns.pluck("sorting").join());
    this.grid.setSkin(this.skin);
    this.grid.setNoHeader(hideHeader);

    var theGridElement = this.gridElement;
    var setHourGlassCursor = function () {
        // Wait cursor over grid elements
        jQuery('#' + theGridElement).css('cursor', 'wait');
        // Disable grid selectors
        var selector = "#" + theGridElement + " input";
        jQuery(selector).each(function (i, item) { jQuery(item).attr("disabled", "disabled"); });
        return true;
    };
    var setDefaultCursor = function () {
        // Wait cursor over grid elements
        jQuery('#' + theGridElement).css('cursor', 'default');
        var selector = "#" + theGridElement + " input";
        // Re-enable grid selectors
        jQuery(selector).each(function (i, item) { jQuery(item).removeAttr("disabled"); });
        return true;
    };

    var closeAllOpenMultiSelectsInGrid = function () {
        jQuery("#" + theGridElement).find(".dhtmlx-grid-bootstrap-multiselect-filter-container").find(".btn-group.open .dropdown-toggle").dropdown("toggle");
    };

    this.grid.entBox.onselectstart = function () { return true; }; // allows selection in IE & copying/pasting
    this.grid.attachEvent("onBeforeSorting", setHourGlassCursor);
    this.grid.attachEvent("onAfterSorting", setDefaultCursor);
    this.grid.attachEvent("onXLS", setHourGlassCursor);
    this.grid.attachEvent("onXLE", setDefaultCursor);

    // dhtmlx wants to take over all the click events so you have to sneak in an event handler where its not looking
    // this closes the dropdown if you click over to a different filter
    this.grid.attachEvent("onXLE", function () {
        jQuery("#" + theGridElement).find("table.hdr tbody tr td").click(function (e) {
            if (jQuery(e.target).hasClass("dropdown-toggle") === false) {
                closeAllOpenMultiSelectsInGrid();
            }
        });
    });

    // dhtmlx wants to take over all the click events so you have to sneak in an event handler where its not looking
    // this closes any open multiselect filters if you click in an empty space in the grid. This empty click doesn't
    // encompass clicks on the actual table data. https://docs.dhtmlx.com/api__dhtmlxgrid_onemptyclick_event.html
    this.grid.attachEvent("onEmptyClick", function (e) {
        // looks up the DOM tree and gets the closest parent '.dropdown-toggle'. If it doesn't find any
        // it should be safe to close the multiselects
        if (jQuery(e.target).closest(".dropdown-toggle").length < 1) {
            closeAllOpenMultiSelectsInGrid();
        }
    });

    // Again, dhtmlx wants to take over so many click events. Because the above onEmptyClick doesn't do anything when clicking on the table data
    // When a row is selected(or a user clicks on the table content) we want to close all multiselects
    this.grid.attachEvent("onRowSelect", function (e) {
        closeAllOpenMultiSelectsInGrid();
    });

    this.grid.init();
    this.grid.enableEditEvents(true, false, true);
    this.grid.enableDistributedParsing((this.scrollPosition == this.SCROLL_TO_FIRST), 200, 100);

    if (this.dataElement) {
        if (typeof (this.dataElement.html) === "function") {
            this.grid.parse(this.dataElement.html().replace(/&nbsp;/g, " ")); // some browser's (Mozilla) innterHTML adds &nbsp; to some elements for some reason (they possibly detect other html in the element and replace spaces w/ &nbsp;
        }
        else {
            this.grid.parse(this.dataElement.replace(/&nbsp;/g, " ")); // some browser's (Mozilla) innterHTML adds &nbsp; to some elements for some reason (they possibly detect other html in the element and replace spaces w/ &nbsp;                
        }
    }
    else if (dataUrl) {

        if (true) {
            this.grid.enableSmartRendering(true);

            //  For dhtmlxgrid smart rendering height has to be the same between row content (image heights), sitka_dhtmlxgrid_skins.css (.ev_sitkaskin, .odd_sitkaskin), and sitka.js (grid.setAwaitedRowHeight) or paged grids scrolling will be off in dhtmlxgrid smart rendering mode
            var rowHeightInPxThatMatchesSkin = this.awaitedRowHeight;

            if (rowHeightInPxThatMatchesSkin != null) {
                // Only call grid.setAwaitedRowHeight() after grid.enableSmartRendering() or you'll get function undefined
                this.grid.setAwaitedRowHeight(rowHeightInPxThatMatchesSkin);
            }
        }
        if (splitAtColumn != null) {
            this.grid.splitAt(splitAtColumn);
        }
        this.load(dataUrl);
    }

    if (dataUrl == null) {
        this.grid.stopFastOperations();
    }

    if (this.scrollPosition == this.SCROLL_TO_LAST) {
        var lastRowIndex = this.grid.getRowsNum() - 1;
        if (lastRowIndex >= 0) {
            var rowId = this.grid.getRowId(lastRowIndex);
            this.grid.showRow(rowId);
        }
    }

    this.grid.enableAutoSizeSaving(null, "path=/");
    this.grid.enableOrderSaving(null, "path=/");
    this.grid.enableSortingSaving(null, "path=/");

    return this.grid;
};

Sitka.Grid.Class.Grid.prototype.buildWithDataUrl = function (hideHeader, groupingHeader, dataUrl) { this.buildWithArguments(hideHeader, groupingHeader, null, dataUrl); };

Sitka.Grid.Class.Grid.prototype.load = function (dataUrl) {
    window.dhx4.attachEvent("onLoadXMLError", function (request, object) {
        // status of 0 is a click away from grid (firefox errors on this, but we don't care), 200 is a-okay.
        if (object.status !== 200 && object.status !== 0) {
            SitkaAjax.errorHandler(object, object.status);
        }
        return false;
    });
    this.grid.clearAll();
    this.grid.load(dataUrl, "json");
};

Sitka.Grid.Class.Grid.prototype.setGridInstructions = function (instructionHtml, show) {
    var objbox = jQuery(this.grid.objBox);
    objbox.append(instructionHtml).addClass("gridInstruction");
    if (show)
        this.showGridInstructions();
    else
        this.hideGridInstructions();
};

Sitka.Grid.Class.Grid.prototype.showGridInstructions = function () {
    var objbox = jQuery(this.grid.objBox);
    jQuery(".gridInstruction", objbox).show();
    objbox.addClass("gridInstructionPane");
};

Sitka.Grid.Class.Grid.prototype.hideGridInstructions = function () {
    var objbox = jQuery(this.grid.objBox);
    jQuery(".gridInstruction", objbox).hide();
    objbox.removeClass("gridInstructionPane");
};

Sitka.Grid.Class.Grid.prototype.build = function (hideHeader, groupingHeader, filterHeader) { this.buildWithArguments(hideHeader, groupingHeader, filterHeader, null); };

Sitka.Grid.Class.Grid.prototype.formatEdit = function (rowId, columnIndex) { this.grid.rowsAr[rowId].cells[columnIndex].className += " sitkaGridEditable"; };

Sitka.Grid.Class.Grid.prototype.getFilterValuesFromGrid = function () {
    var filterValues = [];
    for (var colIndex = 0; colIndex < this.grid.getColumnsNum() ; colIndex++) {
        if (this.grid.getFilterElement(colIndex) !== null) {
            filterValues[colIndex] = this.grid.getFilterElement(colIndex).value;
        }
        else {
            filterValues[colIndex] = null;
        }
    }
    return filterValues;
};



Sitka.Grid.Class.Grid.prototype.hasSavedFilters = function () {
    // Do we have any filters with any length at all?
    // Here we just staple them all together and see if they add up to anything. If they are non-zero length,
    // one of the filters is set to something.
    var filterValues = this.getFilterValuesFromGrid();
    var filterString = filterValues.join('');
    var filterTrimmed = jQuery.trim(filterString);

    return filterTrimmed.length > 0;
};

Sitka.Grid.Class.Grid.prototype.setFilteringButtonTagName = function (filterTagName) { this.filterTagName = "#" + filterTagName; };

Sitka.Grid.Class.Grid.prototype.showOrHideFilteringButton = function () {
    // If they haven't set this, they are indicating there is no such button to set.
    if (!this.filterTagName)
        return;
    if (this.hasSavedFilters())
        jQuery(this.filterTagName).show();
    else
        jQuery(this.filterTagName).hide();
};

Sitka.Grid.Class.Grid.prototype.resetMultiSelectFilters = function () {
    var g = this.grid.multiSelectFilters;
    if (g != undefined) {
        jQuery.each(g, function (i, idx) {
            idx.toggleAllLabelsAndCheckboxes(true, true);
            idx.updateSelectTitle();
            jQuery.each(jQuery(idx.selectElem).find("option"), function (ix, idxx) { jQuery(idxx).attr("selected", "selected"); });
        });
    }
};

Sitka.Grid.Class.Grid.prototype.clearGridFilters = function () {
    if (this.grid.filters) {
        for (var colIndex = 0; colIndex < this.grid.filters.length; colIndex++) {
            var filterObj = this.grid.filters[colIndex];
            if (filterObj) {
                filterObj[0].value = "";
            }
        }
        //its important that we call refresh filters before we call resetMultiSelectFilters. grid.refresh sets the value of all dropdowns to "" which breaks the multiselect since no options will be selected. 
        //When you filter again, you'll have no options in the list selected and the grid will clear out.
        this.grid.refreshFilters();
        this.resetMultiSelectFilters();

        this.grid.filterBy(0, "");


        this.saveFiltersToServer();
        this.showOrHideFilteringButton();
        this.updateFilterCountElement();
        this.updateFilterDownloadElement();

        this.grid.callEvent("onFilterEnd", []);
    }
};

Sitka.Grid.Class.Grid.prototype.setGridFromSavedValues = function (filterValuesArray) {
    this.grid.refreshFilters();
    for (var colIndex = 0; colIndex < filterValuesArray.length; colIndex++) {
        // Sanity check to make sure we don't walk off the end, 
        // if the saved values didn't correspond to the real-world columns.
        if (colIndex > this.grid.getColumnsNum()) {
            break;
        }

        if ((filterValuesArray[colIndex] !== null) && (this.grid.getFilterElement(colIndex) !== null)) {
            this.grid.getFilterElement(colIndex).value = filterValuesArray[colIndex];
        }
    }
    this.grid.filterByAll();
    this.showOrHideFilteringButton();
};

Sitka.Grid.Class.Grid.prototype.setupFilterCountElement = function (filterCountElementId) {
    var self = this;
    this.filterCountElement = jQuery("#" + filterCountElementId);
    this.grid.attachEvent("onFilterEnd", function () {
        self.updateFilterCountElement();
        self.showOrHideFilteringButton();
    });
};

Sitka.Grid.Class.Grid.prototype.setupFilterDownloadElement = function (filterDownloadElementId) {
    var self = this;
    this.filterDownloadElement = jQuery("#" + filterDownloadElementId);
    this.filterDownloadElement.parent().show();
    this.grid.attachEvent("onFilterEnd", function () {
        self.updateFilterDownloadElement();
        self.showOrHideFilteringButton();
    });
};

Sitka.Grid.Class.Grid.prototype.updateFilterCountElement = function () {
    if (this.filterCountElement) {
        this.filterCountElement.html(this.grid.getRowsNum());
    }
};

Sitka.Grid.Class.Grid.prototype.updateSelectedCheckboxCount = _.debounce(function () {
    var checkedCheckboxSpan = jQuery("#" + this.gridName + "MetaDivID .checked-checkboxes");
    var checkedCheckboxSpanNumber = jQuery("#" + this.gridName + "MetaDivID span#" + this.gridName + "CheckedCheckboxCount");

    // if the first column in the grid is not a checkbox column
    // note that this functionality will only work if checkboxes are in the first column for now
    if (this.grid.getColType(0) !== "ch") {
        return;
    }

    var checkedRows = this.grid.getCheckedRows(0);
    var checkedRowsArray = checkedRows.split(",");
    var checkedRowsArrayLength = checkedRowsArray.length;

    var checkedRowsCount = (checkedRows === "") ? 0 : checkedRowsArrayLength;

    checkedCheckboxSpanNumber.html(checkedRowsCount);
    if (checkedRowsCount > 0) {
        checkedCheckboxSpan.show();
    } else {
        checkedCheckboxSpan.hide();
    }
}, 200);

Sitka.Grid.Class.Grid.prototype.updateFilterDownloadElement = function () {
    if (this.filterDownloadElement) {
        var msg = "all rows";
        var rowCount = this.grid.getRowsNum();
        if (rowCount != this.unfilteredRowCount) {
            msg = rowCount + " rows";
        }
        this.filterDownloadElement.html(msg);
    }
};

Sitka.Grid.Class.Grid.prototype.retrieveValuesFromColumn = function (columnName) {
    var columnIndex = this.getColumnIndexByName(columnName);
    if (typeof columnIndex === 'undefined') {
        // This is definitely better than crashing and, I'd argue, better than quietly swallowing the error. 
        // A better solution would be to submit an error via ajax to a controller action to alert support. -- SLG
        alert(columnName + " column not defined, so cannot email Persons. Please contact support@sitkatech.com for assistance.");
        return "";
    }

    var columnValues = [];
    var visibleRowCount = this.grid.getRowsNum();
    // Go through all the rows by index
    for (var rowIndex = 0; rowIndex < visibleRowCount; rowIndex++) {
        var currentValue = this.grid.cellByIndex(rowIndex, columnIndex).getValue();
        if (!Sitka.Methods.isUndefinedNullOrEmpty(currentValue)) {
            var split = currentValue.split(",");
            for (var i = 0; i < split.length; ++i) {
                columnValues.push(parseInt(split[i]));
            }
        }
    }
    // Returns a distinct array
    var uniqueItems = _.uniq(columnValues);
    return uniqueItems;
};

Sitka.Grid.Class.Grid.prototype.resizeGridWithVerticalFill = function ()
{
    var gridDiv = jQuery("#" + this.gridElement);
    var top = gridDiv.offset().top;
    var heightOffset = top + 50;
    var windowHeight = jQuery(window).height();
    var gridHeight = windowHeight - heightOffset;
    gridHeight = Math.max(gridHeight, 300); //Enforce minimum height
    this.grid.enableAutoHeight(true, gridHeight, true);
    this.grid.enableAutoWidth(true, gridDiv.parent().width(), 100);
    this.grid.setSizes();
    jQuery("#" + this.gridName + "MetaDivID").width(gridDiv.width());
};

Sitka.Grid.Class.Grid.prototype.resizeGridWidths = function ()
{
    var gridDiv = jQuery("#" + this.gridElement);
    var parentDiv = gridDiv.parent();
    this.grid.enableAutoWidth(true, parentDiv.width(), 100);
    this.grid.setSizes();
    jQuery("#" + this.gridName + "MetaDivID").width(gridDiv.width());
};

Sitka.Grid.Class.Grid.prototype.setupServerFilterSaving = function (filterElementId) {
    var self = this;
    this.grid.attachEvent("onFilterStart", function () {
        self.saveFiltersToServer();
        self.showOrHideFilteringButton();
        return true;
    });
};


Sitka.Grid.Class.Grid.prototype.getColumnSortTypeByIndex = function (columnIndex) {
    return this._columns.pluck("sorting").value()[columnIndex];
};


Sitka.Grid.Class.Grid.prototype.asGridTableForSettings = function () {
    var sortInfo = this.SortInfo;
    var tableToPost = new GridTable.GridTable(this.gridName);
    // the meaning of "this" changes in the anonymous function in the loop
    var sitkaGrid = this;

    // Add all columns
    sitkaGrid._columns.forEach(function (col) {
        var colName = col.columnName;
        var idx = sitkaGrid.getColumnIndexByName(colName);
        var width = sitkaGrid.grid.getColWidth(idx);
        var filterTextArray = [];
        var filterElem = sitkaGrid.grid.getFilterElement(idx);
        if (filterElem !== null && typeof (filterElem) !== "undefined") {
            var filterMaybeArr = jQuery(filterElem).val();
            if (filterMaybeArr instanceof Array) {
                filterTextArray = filterMaybeArr;
            }
            else {
                filterTextArray = [filterMaybeArr];
            }
        }

        var isSorted = null;
        var sortDirection = null;
        var sortType = null;

        if (sortInfo != null && sortInfo !== undefined) {
            if (idx === sortInfo.Index) {
                isSorted = true;
                sortDirection = sortInfo.Direction;
                sortType = sortInfo.Type;
            }
        }
        tableToPost.addColumn(colName, filterTextArray, width, idx, isSorted, sortDirection, sortType);
    }).value();

    return tableToPost;
}
Sitka.Grid.Class.Grid.prototype.sitkaGridToExcel = function (url) {
    var self = this;
    
    
    this.saveFiltersToServer(this.grid.toExcel(url));

};
Sitka.Grid.Class.Grid.prototype.saveFiltersToServer = function (callbackFunction) {
    
    // Retrieve the values from the grid in our own format
    var filterValues = this.asGridTableForSettings();
    // url, postData, callback, errorHandler
    SitkaAjax.post(this.saveGridSettingsUrl,
        { Data: JSON.stringify(filterValues) },
        callbackFunction,
        function() {

        });

};