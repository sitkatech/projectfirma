


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