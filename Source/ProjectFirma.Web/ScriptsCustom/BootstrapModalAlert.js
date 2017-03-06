/*-----------------------------------------------------------------------
<copyright file="BootstrapModalAlert.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
function createBootstrapAlert(alertText, alertTitle, closeButtonText)
{         
    var alertHtml =
        "<div class='modal firma-modal'>" +
            "<div class='modal-dialog firma-modal-dialog'>" +
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
        "<div class='modal firma-modal'>" +
            "<div class='modal-dialog firma-modal-dialog'>" +
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
