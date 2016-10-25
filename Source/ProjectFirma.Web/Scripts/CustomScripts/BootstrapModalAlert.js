function createBootstrapAlert(alertText, alertTitle, closeButtonText)
{         
    var alertHtml =
        "<div class='modal ltinfo-modal'>" +
            "<div class='modal-dialog ltinfo-modal-dialog'>" +
                "<div class='modal-content'>" +
                    "<div class='modal-header'>" +
                        "<button type='button' class='btn btn-xs btn-firma modal-close-button' data-dismiss='modal'><span>&times</span></button>" +
                        "<span class='modal-title'>" + alertTitle + "</span>" +
                    "</div>" +
                    "<div class='modal-body'>" + alertText + "</div>" +
                    "<div class='modal-footer'>" +
                        "<button type='button' class='btn btn-xs btn-firma' data-dismiss='modal'>" + closeButtonText + "</button>" +
                    "</div>" +
                "</div>" +
            "</div>" +
        "</div>";
    var alertDiv = jQuery(alertHtml);
    alertDiv.modal({ keyboard: true });
    alertDiv.draggable({ handle: ".modal-header" });
}

function createBootstrapAlertWithNoButtons(alertText, alertTitle, closeButtonText) {
    var alertHtml =
        "<div class='modal ltinfo-modal'>" +
            "<div class='modal-dialog ltinfo-modal-dialog'>" +
                "<div class='modal-content'>" +
                    "<div class='modal-header'>" +
                        "<span class='modal-title'>" + alertTitle + "</span>" +
                    "</div>" +
                    "<div class='modal-body'>" + alertText + "</div>" +
                "</div>" +
            "</div>" +
        "</div>";
    var alertDiv = jQuery(alertHtml);
    alertDiv.modal({ keyboard: true });
    alertDiv.draggable({ handle: ".modal-header" });
}

function createBootstrapAlertFromUrl(anchorTag, alertTitle, closeButtonText, javascriptReadyFunction)
{
    var config = { type: "GET", url: anchorTag.href };
    SitkaAjax.ajax(config, function (htmlContentsOfDialogBox) {
        // defer loading of the contents so that the dialog is in place first by passing along the html string
        createBootstrapAlert(htmlContentsOfDialogBox, alertTitle, closeButtonText);
        if (!Sitka.Methods.isUndefinedNullOrEmpty(javascriptReadyFunction)) {
            javascriptReadyFunction();
        }
    });
    return false;
}
