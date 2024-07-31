


function HtmlLinkListJsonRenderer(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    var returnString = "";
    for (var i = 0; i < jsonObj.length; i++) {
        if (i > 0) {
            returnString += ", ";
        }
        var item = jsonObj[i];
        if (item.Link && item.DisplayText) {
            returnString += `<a href="${item.Link}">${item.DisplayText}</a>`;
        } else if (item.DisplayText) {
            returnString += item.DisplayText;
        }
    }


    return returnString;
}


function HtmlLinkListJsonFormatter(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    //console.log(jsonObj);
    var returnString = "";
    for (var i = 0; i < jsonObj.length; i++) {
        if (i > 0) {
            returnString += ", ";
        }
        var item = jsonObj[i];
        if (item.DisplayText) {
            returnString += item.DisplayText;
        }
    }

    return returnString;
}
