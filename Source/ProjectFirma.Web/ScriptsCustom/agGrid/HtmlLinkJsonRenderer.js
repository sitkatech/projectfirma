function HtmlLinkJsonRenderer(params) {
    if (!params.value) {
        return "";
    }
    var jsonObj = JSON.parse(params.value);
    if (jsonObj.Link && jsonObj.DisplayText) {
        // Derive a plain-text aria-label from the DisplayText (strip any HTML such as leading <span>)
        var tmp = document.createElement('div');
        tmp.innerHTML = jsonObj.DisplayText;
        var ariaText = tmp.textContent || tmp.innerText || '';

        // HTML-escape the ariaText so it is safe to use inside an attribute
        function escapeAttribute(str) {
            return String(str)
                .replace(/&/g, '&amp;')
                .replace(/"/g, '&quot;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;');
        }

        var ariaLabelValue = escapeAttribute(ariaText);

        // Return an HTML string for accessibility and keyboard navigation. Use the original DisplayText as the link innerHTML
        return `<a href="${jsonObj.Link}" tabindex="0" aria-label="${ariaLabelValue}" class="ag-grid-link">${jsonObj.DisplayText}</a>`;
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
