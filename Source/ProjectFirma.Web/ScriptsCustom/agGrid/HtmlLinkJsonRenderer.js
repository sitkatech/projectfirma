


function HtmlLinkJsonRenderer(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    if (jsonObj.Link && jsonObj.DisplayText) {
        return `<a href="${jsonObj.Link}">${jsonObj.DisplayText}</a>`;
    }else if (jsonObj.DisplayText) {
        return jsonObj.DisplayText;
    }

    return "";
}


function HtmlLinkJsonFormatter(params) {

    if (!params.value) {
        return "";
    }
    //console.log(params.value);
    var jsonObj = JSON.parse(params.value);
    if (jsonObj.DisplayText) {
        return jsonObj.DisplayText;
    }

    return "";
}
