


function HtmlLinkJsonRenderer(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    if (jsonObj.link && jsonObj.displayText) {
        return `<a href="${jsonObj.link}">${jsonObj.displayText}</a>`;
    }

    return "";
}


function HtmlLinkJsonFormatter(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    if (jsonObj.displayText) {
        return jsonObj.displayText;
    }

    return "";
}
