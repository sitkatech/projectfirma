


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