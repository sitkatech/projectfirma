﻿


function currencyFormatter(params) {
    if (params.value === null || params.value === undefined) {
        return null;
    }
    var floatValue = Number.parseFloat(params.value).toFixed(2);
    return "$" + formatNumber(floatValue);
}

function integerFormatter(params) {
    if (params.value === null || params.value === undefined) {
        return null;
    }
    var integerValue = Number.parseInt(params.value);
    return formatNumber(integerValue);
}

function decimalFormatter(params) {
    if (params.value === null || params.value === undefined) {
        return null;
    }
    var floatValue = Number.parseFloat(params.value);
    return formatNumber(floatValue); //formatNumber(integerValue);
}

function formatNumber(number) {
    // this puts commas into the number eg 1000 goes to 1,000
    return number.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
}

function removeHtmlFromColumnForCVSDownload(column, value) {
    return removeHtmlFromString(column.value);
}

function removeHtmlFromString(value) {
    let txt = new DOMParser().parseFromString(value, "text/html");
    return txt.documentElement.innerText ? txt.documentElement.innerText.trim() : txt.documentElement.innerText;
}

function getOffsetTop(element) {
    var offsetTop = 0;
    while (element) {
            
        offsetTop += element.offsetTop;
        element = element.offsetParent;
            
    }
    return offsetTop;
}

function getGridHeight(top) {
    var heightOffset = top + 50;
    var windowHeight = window.innerHeight;
    var gridHeight = windowHeight - heightOffset;
    gridHeight = Math.max(gridHeight, 500); //Enforce minimum height
    return gridHeight;
}

function getDateStringDataTypeDefinition() {

    return {
        baseDataType: 'dateString',
        extendsDataType: 'dateString',
        valueFormatter: (params) => (params.value == null ? '' : params.value),
        dataTypeMatcher: (value) =>
            typeof value === 'string' && (!!value.match('\\d{2}/\\d{2}/\\d{4} \\d+:\\d{2} (AM)?(PM)?') || !!value.match('\\d{2}/\\d{2}/\\d{4}')),
        dateParser: (value) => {
            if (value == null || value === '') {
                return undefined;
            }
            const dateAsTime = Date.parse(value);
            if (dateAsTime) {
                return new Date(dateAsTime);
            }
            return undefined;
        },
        dateFormatter: (value) =>
            value == null
            ? undefined
            : value.toLocaleString().split(',')[0] + value.toLocaleString().split(',')[1]
    };
}

function dateStringComparator(date1, date2) {
    var date1Number = Date.parse(date1);
    var date2Number = Date.parse(date2);

    if (date1Number === null && date2Number === null) {
        return 0;
    }
    if (date1Number === null) {
        return -1;
    }
    if (date2Number === null) {
        return 1;
    }

    return date1Number - date2Number;
}

function htmlFilterTextMatcher( filterOption, value, filterText) {
    if (filterText == null) {
        return false;
    }
    value = removeHtmlFromString(value);
    switch (filterOption) {
        case 'contains':
            return value.indexOf(filterText) >= 0;
        case 'notContains':
            return value.indexOf(filterText) < 0;
        case 'equals':
            return value === filterText;
        case 'notEqual':
            return value != filterText;
        case 'startsWith':
            return value.indexOf(filterText) === 0;
        case 'endsWith':
            const index = value.lastIndexOf(filterText);
            return index >= 0 && index === (value.length - filterText.length);
        default:
            // should never happen
            console.warn('invalid filter type ' + filter);
            return false;
    }
}

function htmlLinkJsonFilterTextMatcher(filterOption, value, filterText) {
    if (filterText == null) {
        return false;
    }

    if (!value) {
        return false;
    }

    var jsonObj = JSON.parse(value);
    var textToCompare = jsonObj.displaytext;
    switch (filterOption) {
    case 'contains':
        return textToCompare.indexOf(filterText) >= 0;
    case 'notContains':
        return textToCompare.indexOf(filterText) < 0;
    case 'equals':
        return textToCompare === filterText;
    case 'notEqual':
        return textToCompare != filterText;
    case 'startsWith':
        return textToCompare.indexOf(filterText) === 0;
    case 'endsWith':
        const index = textToCompare.lastIndexOf(filterText);
        return index >= 0 && index === (textToCompare.length - filterText.length);
    default:
        // should never happen
        console.warn('invalid filter type ' + filter);
        return false;
    }
}

function JsonDisplayTextSorting(valueA, valueB, nodeA, nodeB, isDescending) {

    var displayTextA = "";
    var displayTextB = "";


    if (valueA) {
        var jsonObjectA = JSON.parse(valueA);
        if (jsonObjectA.DisplayText) {
            displayTextA = jsonObjectA.DisplayText.toLowerCase();
        }
    }

    if (valueB) {
        var jsonObjectB = JSON.parse(valueB);
        if (jsonObjectB.DisplayText) {
            displayTextB = jsonObjectB.DisplayText.toLowerCase();
        }
    }

    if (displayTextA == displayTextB) return 0;
    return (displayTextA > displayTextB) ? 1 : -1;
}


function HtmlRemovalSorting(valueA, valueB, nodeA, nodeB, isDescending) {
    var noHtmlValueA = removeHtmlFromString(valueA).toLowerCase();
    var noHtmlValueB = removeHtmlFromString(valueB).toLowerCase();
    if (noHtmlValueA == noHtmlValueB) return 0;
    return (noHtmlValueA > noHtmlValueB) ? 1 : -1;
}

function HtmlRemovalFormatter(params) {

    if (!params.value) {
        return "";
    }

    return removeHtmlFromString(params.value);

}

//called from  AgGridHtmlHelpers.CreateGridSettingsButtonsHtml
function saveGridState(gridOptionsApi, gridName) {
    var currentColState = gridOptionsApi.getColumnState();
    var currentFilterModel = gridOptionsApi.getFilterModel();


    var postData = new Object();
    postData.FilterState = JSON.stringify(currentFilterModel);
    postData.ColumnState = JSON.stringify(currentColState);
    postData.GridName = gridName;

    SitkaAjax.ajax({
        type: "POST",
        url: "/GridSettings/SaveGridSettings",
        data: postData,
        dataType: "json",
        async: false
    }, function (data) {
        console.log("successfully saved grid settings")
        var messageToDisplay = document.getElementById(gridName + "GridSettingsSavedMessage").innerHTML;
        document.getElementById(gridName + "GridSettingsMessageContainer").innerHTML = messageToDisplay;
        
    }, function () {
        //GridSettingsSavedError
        console.log("There was an error saving your grid settings.");
        var messageToDisplay = document.getElementById(gridName + "GridSettingsSavedError").innerHTML;
        document.getElementById(gridName + "GridSettingsMessageContainer").innerHTML = messageToDisplay;
    });

}

//called from  AgGridHtmlHelpers.CreateGridSettingsButtonsHtml
function loadGridState(gridOptionsApi, gridName, showErrors) {

    var postData = new Object();
    postData.GridName = gridName;

    SitkaAjax.ajax({
        type: "POST",
        url: "/GridSettings/LoadGridSettings",
        data: postData,
        dataType: "json",
        async: false
    }, function (data) {
        gridOptionsApi.applyColumnState({
            state: JSON.parse(data.ColumnState),
            applyOrder: true,
        });

        gridOptionsApi.setFilterModel(JSON.parse(data.FilterState));
    }, function () {
        console.log("There are no grid settings to be applied");
        //on intial page load we trigger this function to load the users grid settings, we do not want to show the error message in this case
        if (showErrors) {
            var messageToDisplay = document.getElementById(gridName + "GridSettingsLoadedError").innerHTML;
            document.getElementById(gridName + "GridSettingsMessageContainer").innerHTML = messageToDisplay;
        }        
    });



}

//called from  AgGridHtmlHelpers.CreateGridSettingsButtonsHtml
function resetGridState(gridOptionsApi) {
    gridOptionsApi.resetColumnState();
    gridOptionsApi.setFilterModel(null);

    console.log("column state and filter model reset");
}