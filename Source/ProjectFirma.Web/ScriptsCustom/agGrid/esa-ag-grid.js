


function currencyFormatter(params) {
    var floatValue = Number.parseFloat(params.value).toFixed(2);
    return "$" + formatNumber(floatValue);
}

function integerFormatter(params) {
    var integerValue = Number.parseInt(params.value);
    return integerValue; //formatNumber(integerValue);
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
    return txt.documentElement.innerText;
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
    gridHeight = Math.max(gridHeight, 300); //Enforce minimum height
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