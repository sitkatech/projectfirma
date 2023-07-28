﻿/*-----------------------------------------------------------------------
<copyright file="ModalDialogForm.js" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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


function modalDialogLink(anchorTag, javascriptReadyFunction, postData) {

    jQuery('.qtip.ui-tooltip-help').qtip('hide'); // hide any qtips
    var element = jQuery(anchorTag);

    // Topic for discussion: We should probably start using real buttons to open up modal dialogs. Using anchor tags
    // is an accessibility issue, as well as not having the ability to "disable" them normally.
    // Since we can't rely on disabled="disabled" to truly disable the anchor tags, we can 
    // check to see if the anchor tag has the property anyways and just return false early.
    if (element.attr('disabled') == 'disabled') {
        return false;
    }

    element.attr('disabled', true);
    var randomNumber = Math.floor(Math.random() * 10000000);
    var dialogDivId = "SitkajQueryModalDialogUniqueID" + randomNumber;
    var dialogContentDivId = "SitkajQueryModalDialogContentUniqueID" + randomNumber;

    var postDataAsJson;
    if (typeof (postData) == "function") {
        postDataAsJson = postData();
    }
    else {
        postDataAsJson = postData;
    }
    // Load the form into the dialog div
    var config = { type: "GET", url: anchorTag.href };
    if (postDataAsJson != null) {
        config = { type: "POST", url: anchorTag.href, data: JSON.stringify(postDataAsJson), contentType: "application/json" };
    }
    SitkaAjax.ajax(config,
        // success callback
        function (htmlContentsOfDialogBox) {
            // defer loading of the contents so that the dialog is in place first by passing along the html string
            createBootstrapDialogForm(element, dialogDivId, dialogContentDivId, javascriptReadyFunction, htmlContentsOfDialogBox);
            element.attr('disabled', false);
        },
        // error callback
        function() {
            element.attr('disabled', false);
        }
    );

    return false;
}
function findBootstrapDialogForm(optionalDialogFormId, dialogDiv) {
    var form;
    if (!Sitka.Methods.isUndefinedNullOrEmpty(optionalDialogFormId)) {
        form = jQuery("#" + optionalDialogFormId, dialogDiv);
    }

    if (Sitka.Methods.isUndefinedNullOrEmpty(form)) {
        form = jQuery("form", dialogDiv);
    }

    if (form.length > 1) {
        throw new Error("Found more than 1 form to post!  Cannot proceed.");
    }

    return form;
}

function createBootstrapDialogForm(element, dialogDivId, dialogContentDivId, javascriptReadyFunction, htmlContentsOfDialogBox) {
    // Retrieve values from the HTML5 data attributes of the link
    var dialogTitle = element.attr("data-dialog-title");

    var width = parseInt(element.attr("data-dialog-width"));
    if (width == 0) { width = "auto"; }
    else { width = width + "px"; }

    var saveButtonId = element.attr("data-save-button-id");
    var saveButtonText = element.attr("data-save-button-text");
    var cancelButtonID = element.attr("data-cancel-button-id");
    var cancelButtonText = element.attr("data-cancel-button-text");
    var optionalDialogFormId = element.attr("data-optional-dialog-form-id");
    var skipAjax = (element.attr("data-skip-ajax").toLowerCase() === 'true') ? true : false;

    var dialogDiv = jQuery(getModalDialogFromHtmlTemplate(dialogDivId, dialogTitle, htmlContentsOfDialogBox, width, saveButtonText, saveButtonId, cancelButtonText, cancelButtonID));
    dialogDiv.modal({ backdrop: "static" });
    dialogDiv.draggable({ handle: ".modal-header" });

    var saveButton = jQuery("#" + saveButtonId);
    saveButton.on("click" ,function () {
        saveButton.attr('disabled', true);

        // 7/10/2023 TK - moved from /ScriptsCustom/CkEditorReady.js due to an order of operations issue with jQuery 3.7. remove when upgrading to tinyMCE
        for (var i in CKEDITOR.instances) {
            var ckEditorForDiv = CKEDITOR.instances[i];
            var id = ckEditorForDiv.name;
            var ckEditorHtml = ckEditorForDiv.getData();
            jQuery("#" + id).val(ckEditorHtml);
        }

        // Manually submit the form
        var form = findBootstrapDialogForm(optionalDialogFormId, dialogDiv);
        // Do not submit if the form
        // does not pass client side validation
        if (!form.valid()) {
            // reset sitkaOpenModalDialogFormID so form can be submitted again
            saveButton.attr('disabled', false);
            return false;
        }
        form.submit();
        
        return true;
    });

    dialogDiv.on("hide.bs.modal", function (e) {
        // Make sure the hide event is from the main modal, not a datepicker modal
        if (e.target.id == dialogDivId) {

            // Remove all qTip tooltips
            jQuery("*", dialogDiv).qtip("hide");
        }
    });

    dialogDiv.on("hidden.bs.modal", function () {
        // It turns out that closing a bootstrap UI dialog
        // does not actually remove the element from the
        // page but just hides it. For the server side 
        // validation tooltips to show up you need to
        // remove the original form the page
        jQuery("#" + dialogDivId).remove();
    });

    // Setup the ajax submit logic, has to be done after the contents are loaded
    wireUpModalDialogForm(dialogDiv, javascriptReadyFunction, optionalDialogFormId, skipAjax, saveButton);
}

function wireUpModalDialogForm(dialogDiv, javascriptReadyFunction, optionalDialogFormId, skipAjax, saveButtonElement) {
    // Enable client side validation
    jQuery.validator.unobtrusive.parse(dialogDiv);
    convertJQueryValidationErrorsToQtip();

    if (Sitka.Methods.isUndefinedNullOrEmpty(skipAjax)) {
        skipAjax = false;
    }

    if (!Sitka.Methods.isUndefinedNullOrEmpty(javascriptReadyFunction)) {
        javascriptReadyFunction();
    }

    jQuery(".sitkaDatePicker").datepicker();
    if (skipAjax) {
        return;
    }

    // Instead of the typical SitkaAjax we use jquery.form.js here because it handles all types of ajax form posting, including file uploads. (SitkaAjax does not handle file uploads).
    // Not using SitkaAjax is OK here because we call SitkaAjax for login redirect and error handling.
    var form = findBootstrapDialogForm(optionalDialogFormId, dialogDiv);
    form.ajaxForm({
        url: this.action,
        type: this.method,
        beforeSubmit: function () {
            jQuery(".progress-bar").html("Saving");
            jQuery(".progress").show();
            jQuery(saveButtonElement).attr('disabled', true);
        },
        success: function (result, textStatus, jqXhr) {
            // Piggy back off the centralized login required detection in Ajax handling in SitkaAjax
            SitkaAjax.handleLoginRedirect(result, textStatus, jqXhr, function () {
                jQuery(".progress").hide();
                jQuery(saveButtonElement).attr('disabled', false);
                // Check whether the post was successful
                if (!Sitka.Methods.isUndefinedNullOrEmpty(result) &&
                    !Sitka.Methods.isUndefinedNullOrEmpty(result.Success) &&
                    result.Success) {
                    // Close the dialog 
                    dialogDiv.modal("hide");
                    // Reload the updated data in the target div
                    if (!Sitka.Methods.isUndefinedNullOrEmpty(result.RedirectUrl)) {
                        window.location.href = result.RedirectUrl;
                    }
                    else {
                        // if none provided, just reload the current page
                        window.location.reload();
                    }
                }
                else {
                    // Reload the dialog to show model errors
                    dialogDiv.find('.modal-body').html(result);

                    // Setup the ajax submit logic
                    wireUpModalDialogForm(dialogDiv, javascriptReadyFunction, optionalDialogFormId, skipAjax, saveButtonElement);
                }
            });
        },
        error: function (xhr, statusText) {
            jQuery(".progress").hide();
            jQuery(saveButtonElement).attr('disabled', false);
            dialogDiv.modal("hide");
            // Piggy back off the centralized error Ajax handling in SitkaAjax
            SitkaAjax.errorHandler(xhr, statusText);
        }
    });

}

function getModalDialogFromHtmlTemplate(dialogDivId, dialogTitle, dialogContent, width, saveButtonText, saveButtonId, closeButtonText, closeButtonID) {
    var hasRequired = dialogContent.indexOf("requiredFieldIcon") !== -1;
    var requiredLegend = hasRequired
        ? "<span><sup><span class=\"glyphicon glyphicon-flash\" style=\"color: #800020; font-size: 8px; \"></span></sup> Required Field</span>"
        : "";

    var modalDialogHtml =
        "<div class='modal firma-modal' id='" + dialogDivId + "' tabindex='-1'>" +
        "<div class='modal-dialog firma-modal-dialog' style = 'width:90%; max-width: " + width + "'>" +
        "<div class='modal-content'>" +
        "<div class='modal-header'>" +
        "<button type='button' class='modal-close-button btn btn-xs btn-firma' data-dismiss='modal'><span>&times;</span></button>" +
        "<span class='modal-title'>" + dialogTitle + "</span>" +
        "</div>" +
        "<div class='modal-body'>" + dialogContent + "</div>" +
        "<div class='modal-footer'>" +
        requiredLegend +
        "<div class='modal-footer-buttons'>" +
        "<button type='button' id='" + saveButtonId + "' class='btn btn-xs btn-firma'>" + saveButtonText + "</button>" +
        "<button type='button' id='" + closeButtonID + "' class='btn btn-xs btn-firma' data-dismiss='modal'>" + closeButtonText + "</button>" +
        "</div>" +
        "</div>" +
        "<div class='progress' style='display:none'>" +
        "<div class='progress-bar progress-bar-info progress-bar-striped active' role='progressbar' style='width:100%'>Saving</div>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>";

    return modalDialogHtml;
}
