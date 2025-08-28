function HtmlLinkJsonRenderer(params) {
    if (!params.value) {
        return "";
    }
    var jsonObj = JSON.parse(params.value);
    if (jsonObj.Link && jsonObj.DisplayText) {
        // Return an HTML string for accessibility and keyboard navigation
        return `<a href="${jsonObj.Link}" tabindex="0" aria-label="${jsonObj.DisplayText}" class="ag-grid-link">${jsonObj.DisplayText}</a>`;
    } else if (jsonObj.DisplayText) {
        return jsonObj.DisplayText;
    }
    return "";
}


function HtmlLinkJsonFormatter(params) {
    if (!params.value) {
        return "";
    }
    var jsonObj = JSON.parse(params.value);
    if (jsonObj.DisplayText) {
        return jsonObj.DisplayText;
    }
    return "";
}
