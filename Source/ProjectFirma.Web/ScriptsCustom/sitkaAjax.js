/*-----------------------------------------------------------------------
<copyright file="sitkaAjax.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
SitkaAjax = {};

SitkaAjax.ajax = function (config, callback, errorHandler) {
    if (typeof errorHandler != 'function') {
        errorHandler = SitkaAjax.errorHandler;
    }

    jQuery
       .ajax(config)
       .success(function(data, textStatus, jqXhr) { SitkaAjax.handleLoginRedirect(data, textStatus, jqXhr, callback); })
       .fail(errorHandler);
};

SitkaAjax.handleLoginRedirect = function(data, textStatus, jqXhr, callback)
{
    var responseText = jqXhr.responseText;
    // check if we are in the login page
    if (responseText.indexOf("SitkaIfInPartialPageRedirectToLoginPage") >= 0)
    {
        var currentLocation = window.location;
        window.location = "/Account/LogOn?returnUrl=" + currentLocation.pathname + currentLocation.search + currentLocation.hash;
    }
    else
    {
        callback(data, textStatus, jqXhr);
    }
};

// straightforward "GET"
SitkaAjax.get = function (url, callback, errorHandler) {
    SitkaAjax.ajax({ type: "GET", url: url }, callback, errorHandler);
};

// straightforward "POST"
SitkaAjax.post = function (url, postData, callback, errorHandler) {
    SitkaAjax.ajax({ type: "POST", url: url, data: postData }, callback, errorHandler);
};

// get/post when the data is returned in JSON -- I'm not sure these are needed,
// I believe jQuery auto-detects JSON and parses it even when the dataType is not set
SitkaAjax.getJSON = function (url, callback, errorHandler) {
    SitkaAjax.ajax({ type: "GET", url: url, dataType: "json" }, callback, errorHandler);
};

SitkaAjax.postJSON = function (url, postData, callback, errorHandler) {
    SitkaAjax.ajax({ type: "POST", url: url, data: postData, dataType: "json" }, callback, errorHandler);
};

SitkaAjax.load = function (jqSelector, url, errorHandler) {
    SitkaAjax.get(url, function (data) { jqSelector.html(data); }, errorHandler);
};

SitkaAjax.errorHandler = function (xhr, status)
{
    var errorMessage = "Please reload the page and try again. If the problem persists, please contact projectfirma@sitkatech.com";
    try
    {
        if (!Sitka.Methods.isUndefinedNullOrEmpty(xhr))
        {
            if (!Sitka.Methods.isUndefinedNullOrEmpty(xhr.responseText))
            {
                if (jQuery(xhr.responseText).find("#customErrorMessageDiv").length != 0)
                {
                    var htmlErrorMessage = jQuery(xhr.responseText).find("#customErrorMessageDiv").html();
                    var htmlErrorMessageWithLinebreaks = htmlErrorMessage.replace("h1", "div").replace("</div>", "</div>\r\n").replace("<br/>", "<br/>\r\n");

                    // We need to wrap with an html tag to get the .text() function of jQuery().text() to work without jQuery exception i.e. has to have a minimal html around it.
                    // "plain error" => "<div>plain error</div>" => jQuery("<div>plain error</div>").text() => "plain error"
                    var htmlErrorMessageWithLinebreaksInDivToWorkWithJQuery = "<div>" + htmlErrorMessageWithLinebreaks + "</div>";
                    
                    var plainTextMessage = jQuery(htmlErrorMessageWithLinebreaksInDivToWorkWithJQuery).text();
                    errorMessage = "An error has occurred: " + plainTextMessage + "\r\n" + errorMessage;
                }
                else
                {
                    errorMessage = "An unknown error error has occurred.\r\n" + errorMessage;
                }
            }
        }
    }
    catch(exception)
    {
        errorMessage = "Could not parse error message properly.\r\n" + errorMessage + "\r\nException while parsing:\r\n" + exception;
    }
    
    // Show as an alert because we don't know what situation we are in, so popups could be risky
    window.alert(errorMessage);
};
