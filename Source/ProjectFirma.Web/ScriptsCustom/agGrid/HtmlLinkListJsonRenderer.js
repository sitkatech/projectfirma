


function HtmlLinkListJsonRenderer(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    var returnString = "";
    for (var i = 0; i < jsonObj.links.length; i++) {
        if (i > 0) {
            returnString += ", ";
        }
        var item = jsonObj.links[i];
        if (item.link && item.displayText) {
            returnString += `<a href="${item.link}">${item.displayText}</a>`;
        } else if (item.displayText) {
            returnString += item.displayText;
        }
    }


    return returnString;
}


function HtmlLinkListJsonFormatter(params) {

    if (!params.value) {
        return "";
    }

    var jsonObj = JSON.parse(params.value);
    var returnString = "";
    for (var i = 0; i < jsonObj.links.length; i++) {
        if (i > 0) {
            returnString += ", ";
        }
        var item = jsonObj.links[i];
        if (item.displayText) {
            returnString += item.displayText;
        }
    }

    return returnString;
}
