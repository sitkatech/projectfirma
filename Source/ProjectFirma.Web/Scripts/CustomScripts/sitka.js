// sitka.js

jQuery(document).ready(function ()
{
    // Some clients (EE right now) does not use Fancybox at present, 
    // so only interact with it if necessary.

});

Number.prototype.formatMoney = function (currency_symbol, decimal_places, decimal_sep, thousands_sep) {
    var n = this;
    var c = decimal_places;
    var d = decimal_sep;
    var s;
    var i;
    var j;
    
    var t = thousands_sep;
    c = isNaN(c = Math.abs(c)) ? 2 : c,
    d = d == undefined ? "." : d,
    t = t == undefined ? "," : t,
    s = n < 0 ? "-" : "",
    i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "",
    j = (j = i.length) > 3 ? j % 3 : 0;

    if (currency_symbol == undefined) {
        currency_symbol = "";
    }


    return currency_symbol + s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};


jQuery(document).ready(function () {
    if (jQuery(".sitka-date-picker").length && jQuery(".sitka-date-picker").datepicker.length) {
        jQuery(".sitka-date-picker").datepicker();
    }
});

function getInternetExplorerVersion()
// Returns the version of Internet Explorer or a -1
// (indicating the use of another browser).
{
    var rv = -1; // Return value assumes failure.
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}


var SitkaJS = {
    log: function (msg) {
        if (typeof console == "undefined") {
            if(window.console) {
                window.console.log(msg);    
            }            
        }
        else {
            console.log(msg);
        }

    }
};



String.prototype.isValidDate = function () {
    var IsoDateRe = new RegExp("^([0-9]{1,2})/([0-9]{1,2})/([0-9]{4})$");

    var matches = IsoDateRe.exec(this);
    if (!matches) {
        return false;
    }

    var composedDate = new Date(matches[3], (matches[1] - 1), matches[2]);

    return ((composedDate.getMonth() == (matches[1] - 1)) &&
          (composedDate.getDate() == matches[2]) &&
          (composedDate.getFullYear() == matches[3]));
};

String.prototype.trim = function () { return this.replace(/^\s+|\s+$/g, ''); };

var Sitka =
{
    Class: {},
    NotYetAssignedID: -1,
    // global methods and properties
    revision: '$Rev$',
    Methods:
    {
        clonePrototype: function (obj) {
            if (typeof obj !== 'undefined') {
                Sitka.Methods.clonePrototype.prototype = Object(obj);
                var newPrototype = new Sitka.Methods.clonePrototype;
                newPrototype.parent = obj;
                return newPrototype;
            }
        },
        stripHtml: function (message) {
            return jQuery("<div>" + message + "</div>").text();
        },
        checkNumericKeyCode: function (ev) {
            ev = ev || window.event;       // gets the event in ie or ns
            kCode = ev.keyCode || ev.which;   // gets the keycode in ie or ns

            var keyCodeIsNumeric = (kCode == 189 || kCode == 109) ||
                                   (kCode >= 48 && kCode <= 57) ||
                                   (kCode >= 96 && kCode <= 105) ||
                                   (kCode == 110 || kCode == 190);

            var keyCodeIsNav = (kCode == Event.KEY_BACKSPACE ||
                                kCode == Event.KEY_TAB ||
                                kCode == Event.KEY_RETURN ||
                                kCode == Event.KEY_LEFT ||
                                kCode == Event.KEY_RIGHT ||
                                kCode == 46); //decimal point

            if (!keyCodeIsNumeric && !keyCodeIsNav)
                return ev.stopPropagation();
        },
        validateNumber: function (pElement, vElement) {
            var percent = Number(pElement.val());

            vElement.html("");

            if (percent < 0)
                percent = NaN;

            if (isNaN(percent))
                vElement.html("*");

            pElement.val(isNaN(percent) ? pElement.val() : percent.toFixed(1));

            return percent;
        },
        setDefaultButton: function (selector, button) {
            jQuery(selector).keypress(function (e) {
                var keyID = (window.event) ? event.keyCode : e.keyCode;
                var realEvent = (window.event) ? event : e;

                if (keyID == 13) {
                    realEvent.cancelBubble = true;
                    realEvent.returnValue = false;
                    button.click();
                }
            });
        },
        coalesce: function (expression, value) {
            return (expression && expression != "null") ? expression : value;
        },
        truncateWithEllipsis: function (expression, maxLength) {
            if (!expression) {
                return expression;
            }
            return (expression.length <= maxLength) ? expression : expression.substring(0, 39) + '...';
        },
        keepTextAreaWithinMaxLength: function (element, maxLength, charWarningCount, remainingCharsDivName, remainingCharsPrefixString) {
            if (element.value.length > maxLength) {
                element.value = element.value.substring(0, maxLength);
            }
            Sitka.Methods.textAreaRemainingCharactersUpdate(element, maxLength, charWarningCount, remainingCharsDivName, remainingCharsPrefixString);
        },
        textAreaRemainingCharactersUpdate: function (element, maxLength, charWarningCount, remainingCharsDivName, remainingCharsPrefixString) {
            var remainingChars = maxLength - element.value.length;
            var remainingCharsDiv = jQuery('#' + remainingCharsDivName);
            remainingCharsDiv.html(remainingCharsPrefixString + remainingChars);
            if (remainingChars <= charWarningCount) {
                // text goes red if they drop below a given number of characters
                remainingCharsDiv.css({ color: 'red' });
            }
            else {
                // Otherwise, black text
                remainingCharsDiv.css({ color: '#666666' });
            }
        },
        EscapeRegExp: function (text) {
            if (!arguments.callee.sRE) {
                var specials = ['/', '.', '*', '+', '?', '|', '(', ')', '[', ']', '{', '}', '\\'];
                arguments.callee.sRE = new RegExp('(\\' + specials.join('|\\') + ')', 'g');
            }
            return text.replace(arguments.callee.sRE, '\\$1');
        },
        S4: function () {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        },
        newGuid: function () {
            return (Sitka.Methods.S4() + Sitka.Methods.S4() + "-" + Sitka.Methods.S4() + "-" + Sitka.Methods.S4() + "-" + Sitka.Methods.S4() + "-" + Sitka.Methods.S4() + Sitka.Methods.S4() + Sitka.Methods.S4()).toUpperCase();
        },
        createCookie: function (name, value, days) {
            var expires;
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toGMTString();
            }
            else {
                expires = "";
            }
            document.cookie = name + "=" + encodeURIComponent(value) + "; path=/" + expires;
        },
        readCookie: function (name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) === " ") {
                    c = c.substring(1, c.length);
                }

                if (c.indexOf(nameEQ) === 0) {
                    return decodeURIComponent(c.substring(nameEQ.length, c.length));
                }
            }
            return null;
        },
        eraseCookie: function (name) {
            Sitka.Methods.createCookie(name, "", -1);
        },
        isUndefinedNullOrEmpty: function (stringValue) {
            return stringValue === undefined || stringValue === null || stringValue.toString() == "";
        },
        parseFloatFromPercentString: function (percentString) {
            // Valid examples of input strings:
            //       "1%", "100%", "45.6%", "0.092%", "1000%".

            // We **REQUIRE** users of this function to provide us with a string that has a
            // percent character ("%"). This has been tightened up. If you need flexible behavior,
            // use parseFloatFromPercentOrFloatString().
            if (percentString.indexOf("%") == -1) {
                return null;
            }

            // Null or blank input is also disallowed
            if (Sitka.Methods.isUndefinedNullOrEmpty(percentString)) {
                return null;
            }

            var retVal = percentString.toString().replace("%", "");
            if (isNaN(retVal)) {
                return null;
            }

            return retVal;
        },
        parseFloatFromPercentOrFloatString: function (floatOrPercentString) {
            // If there is a %, parse as a "xx%" string
            if (floatOrPercentString.toString().indexOf("%") != -1) {
                return Sitka.Methods.parseFloatFromPercentString(floatOrPercentString);
            }

            // Falling through? It must be a plain number already. But, let's be sure.
            if (isNaN(floatOrPercentString)) {
                return null;
            }

            // Return the original input, it was formatted correctly already
            return floatOrPercentString;
        },
        formatAsPercentFromString: function (amount, decimalPlaces) {
            // Blanks and nulls not allowed
            if (Sitka.Methods.isUndefinedNullOrEmpty(amount)) {
                return "";
            }

            // If we have a percent sign, treat as error. This is now a misuse.
            //if (amount.toString().indexOf("%") != -1) return null;

            // If we have a percent sign, remove it and divide to make this
            // equivalent to normal decimal input.
            if (amount.toString().indexOf("%") != -1) {
                amount = amount.replace("%", "");
            }

            amount = amount.toString().replace(/,/gi, "");

            if (isNaN(amount)) {
                return null;
            }

            // Now we have enough decimal places - format correctly
            return Sitka.Methods.formatAsPercent(amount, decimalPlaces);
        },
        parseFloatFromCurrencyString: function (currencyString) {
            if (Sitka.Methods.isUndefinedNullOrEmpty(currencyString)) {
                return null;
            }

            // Strip out $ and , characters that may be present
            var strippedCurrencyString = currencyString.toString().replace("$", "").replace(/,/gi, "");
            // Remove ( and ) characters, and prefix a - character since this appears be a negative number
            strippedCurrencyString = strippedCurrencyString.toString().replace("(", "-").replace(")", "");

            // If not a valid float, return null.
            if (isNaN(strippedCurrencyString)) {
                return null;
            }

            return strippedCurrencyString;
        },
        formatAsCurrencyFromString: function (amount, decimalPlaces) {
            if (Sitka.Methods.isUndefinedNullOrEmpty(amount)) {
                return "";
            }

            // Strip out $ and , characters that may be present
            amount = amount.toString().replace(/,/gi, "");
            amount = amount.replace("$", "");
            // Remove ( and ) characters, and prefix a - character since this appears to be a negative number
            amount = amount.replace("(", "-").replace(")", "");

            return Sitka.Methods.formatAsCurrency(amount, decimalPlaces);
        },
        formatAsCurrency: function (amount, decimalPlaces) {
            if (Sitka.Methods.isUndefinedNullOrEmpty(amount)) {
                return "";
            }

            //default to 0 decimal places
            if (isNaN(decimalPlaces)) {
                decimalPlaces = 0;
            }

            var rounded = Number(amount).toFixed(decimalPlaces);
            var s = String(rounded);
            if (s.indexOf('.') < 0) { s += '.' + new Array(decimalPlaces).join("0"); }
            var a = s.split('.', 2);
            var d = a[1];
            var i = parseInt(a[0], 0);
            if (isNaN(i)) { return ''; }
            var prefix = '', postfix = '';
            if (i < 0) { prefix = '('; postfix = ')'; }
            var n = String(Math.abs(i));
            a = [];
            while (n.length > 3) {
                var nn = n.substr(n.length - 3);
                a.unshift(nn);
                n = n.substr(0, n.length - 3);
            }
            if (n.length > 0) { a.unshift(n); }
            n = a.join(',');
            if (d.length < 1) { amount = n; }
            else { amount = n + '.' + d; }
            return prefix + '$' + amount + postfix;
        },
        formatAsNumberFromString: function (amount, decimalPlaces) {
            if (Sitka.Methods.isUndefinedNullOrEmpty(amount)) {
                return "";
            }

            // Strip out $ and , characters that may be present
            amount = amount.toString().replace(/,/gi, "");
            amount = amount.replace("$", "");
            // Remove ( and ) characters, and prefix a - character since this appears to be a negative number
            amount = amount.replace("(", "-").replace(")", "");

            return amount;
        },
        formatAsPercent: function (amount, decimalPlaces) {
            var rounded = Sitka.Methods.formatAsFloat(amount, decimalPlaces);
            return rounded + '%';
        },
        formatAsFloat: function (amount, decimalPlaces) {
            if (Sitka.Methods.isUndefinedNullOrEmpty(amount)) {
                return "";
            }

            //default to 0 decimal places
            if (isNaN(decimalPlaces)) {
                decimalPlaces = 0;
            }

            return Number(amount).toFixed(decimalPlaces);
        },
        formatAsFloatNaNEmptyString: function (amount, decimalPlaces) {
            if (Sitka.Methods.isUndefinedNullOrEmpty(amount)) {
                return "";
            }

            //default to 0 decimal places
            if (isNaN(decimalPlaces)) {
                decimalPlaces = 0;
            }

            if (isNaN(amount)) {
                return "";
            }

            return Number(amount).toFixed(decimalPlaces);
        },
        getUrlParameter: function (name, defaultValue) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.href);

            if (results === null) {
                return defaultValue;
            }
            else {
                return results[1];
            }
        },
        ajax: function (options) {
            // Only use defaults if no overrides provided            
            if (options.dataType == null) {
                options.dataType = 'json';
            }

            if (options.type == null) {
                options.type = 'POST';
            }

            if (Sitka.ApplicationGlobalErrorHandler != null && options.error == null) {
                options.error = Sitka.ApplicationGlobalErrorHandler;
            }

            jQuery.ajax(options);
        },
        load: function (selector, url, callback) {
            if (callback == null && Sitka.ApplicationGlobalErrorHandler != null) {
                callback = function (responseText, textStatus, xmlHttpRequest) {
                    if (xmlHttpRequest.status != 200) {
                        Sitka.ApplicationGlobalErrorHandler();
                    }
                };
            }
            jQuery(selector).load(url, callback);
        },
        ajaxSetup: function (applicationErrorHandler) {
            Sitka.ApplicationGlobalErrorHandler = applicationErrorHandler;
        },
        enableOrDisableByID: function (id, enable) {
            var control = jQuery("#" + id);
            this.enableOrDisableByJqueryObject(control, enable);
        },
        enableOrDisableByJqueryObject: function (control, enable) {
            if (enable) {
                control.prop("disabled", false);
            }
            else {
                control.prop("disabled", true);
            }
        },
        populateRadioButtons: function (radioGroupName, radioName, radioData, radioValueField, radioTextField, numRadiosPerRow) {
            var radioButtonGroup = jQuery("#" + radioGroupName);
            radioButtonGroup.html("");
            for (var j = 0; j < radioData.length; ++j) {
                radioButtonGroup.append("<label><input type=\"radio\" name=\"" + radioName + "\" value=\"" + radioData[j][radioValueField] + "\" />" + radioData[j][radioTextField] + "</label>");
                if (j % numRadiosPerRow == (numRadiosPerRow - 1)) {
                    radioButtonGroup.append("<br />");
                }
            }
        },
        populateCheckboxes: function (checkboxGroupName, checkboxName, checkboxData, checkboxValueField, checkboxTextField, numCheckBoxesPerRow) {
            var checkboxGroup = jQuery("#" + checkboxGroupName);
            checkboxGroup.html("");
            for (var j = 0; j < checkboxData.length; ++j) {
                checkboxGroup.append("<label><input type=\"checkbox\" name=\"" + checkboxName + "\" value=\"" + checkboxData[j][checkboxValueField] + "\" />" + checkboxData[j][checkboxTextField] + "</label>");
                if (j % numCheckBoxesPerRow == (numCheckBoxesPerRow - 1)) {
                    checkboxGroup.append("<br />");
                }
            }
        },
        populateDropDownByName: function (dropDownName, dropDownData, dropDownValueField, dropDownTextField) {
            var dropdown = jQuery("#" + dropDownName);
            this.populateDropDown(dropdown, dropDownData, dropDownValueField, dropDownTextField);
        },
        populateDropDown: function (dropdown, dropDownData, dropDownValueField, dropDownTextField) {
            dropdown.find("option").remove();
            for (var j = 0; j < dropDownData.length; ++j) {
                var current = dropDownData[j];
                dropdown.append('<option value="' + current[dropDownValueField] + '">' + current[dropDownTextField] + '</option>');
            }
            if (dropdown.find("option").length > 0) {
                dropdown.prop("disabled", false);
            } else {
                dropdown.prop("disabled", true);
            }
        },
        populateDropDownAndAddUnknowItem: function (dropdown, dropDownData, dropDownValueField, dropDownTextField, unknownItemText)
        {
            this.populateDropDown(dropdown, dropDownData, dropDownValueField, dropDownTextField);
            if (unknownItemText === undefined) {
                unknownItemText = "&lt;Choose one&gt;";
            }
            if (dropdown.find("option").length > 1) {
                dropdown.prepend('<option value="">' + unknownItemText + '</option>');
                dropdown.val(""); // selects the unknown item text
            }            
        },
        toggleCheckboxGroup: function (checkBoxGroupName, isChecked) {
            jQuery("input[name='" + checkBoxGroupName + "']").each(function (index, chk) {
                chk.checked = isChecked;
            });
        },
        toggleCheckboxesByClassName: function (className, isChecked) {
            jQuery("input:checkbox" + className).each(function (index, chk) {
                chk.checked = isChecked;
            });
        },
        getCheckboxGroupValues: function (checkBoxGroupName, delimiter) {
            if (delimiter == undefined) {
                delimiter = ",";
            }
            var checkboxesChecked = [];
            jQuery("input[name='" + checkBoxGroupName + "']:checked").each(
                function () {
                    checkboxesChecked.push(jQuery(this).val());
                });
            return checkboxesChecked.join(delimiter);
        },
        findElementIndexInJsonArray: function (arrayToSearch, idField, valueToSearch) {
            for (var i = 0; i < arrayToSearch.length; i++) {
                if (arrayToSearch[i][idField] == valueToSearch) {
                    return i;
                }
            }
            return -1;
        },
        findElementInJsonArray: function (arrayToSearch, idField, valueToSearch) {
            var index = this.findElementIndexInJsonArray(arrayToSearch, idField, valueToSearch);
            if (index >= 0) {
                return arrayToSearch[index];
            }
            return null;
        },
        removeFromJsonArray: function (arrayToSearch, rowToFind) {
            var index = arrayToSearch.indexOf(rowToFind);
            arrayToSearch.splice(index, 1);
        },
        // requires lodash
        cartesianProductOf: function() {
            return _.reduce(arguments, function(a, b) {
                return _.flatten(_.map(a, function(x) {
                    return _.map(b, function(y) {
                        return x.concat([y]);
                    });
                }), true);
            }, [ [] ]);
        },
        htmlEncode: function(value) {
            //create a in-memory div, set it's inner text(which jQuery automatically encodes)
            //then grab the encoded contents back out.  The div never exists on the page.
            if (Sitka.Methods.isUndefinedNullOrEmpty(value))
            {
                return "";
            }
            return $('<div/>').text(value).html();
        },
        htmlDecode: function(value) {
            return $('<div/>').html(value).text();
        }
    },

    // See C# UrlTemplate class this is the javascript equivalent
    UrlTemplate: function (urlTemplateString) {
        this.urlTemplateString = urlTemplateString;
        this.Parameter1Int = -2111110001;
        this.Parameter2Int = -2111110002;
        this.Parameter3Int = -2111110003;
        this.Parameter4Int = -2111110004;
        this.Parameter5Int = -2111110005;
        this.Parameter6Int = -2111110006;
        this.Parameter7Int = -2111110007;
        this.Parameter8Int = -2111110008;
        this.Parameter9Int = -2111110009;
        this.Parameter10Int = -2111110010;
        this.Parameter11Int = -2111110011;
        this.Parameter12Int = -2111110012;
        this.Parameter13Int = -2111110013;

        this.Parameter1String = "UrlTemplateParameter1String";
        this.Parameter2String = "UrlTemplateParameter2String";
        this.Parameter3String = "UrlTemplateParameter3String";
        this.Parameter4String = "UrlTemplateParameter4String";
        this.Parameter5String = "UrlTemplateParameter5String";
        this.Parameter6String = "UrlTemplateParameter6String";
        this.Parameter7String = "UrlTemplateParameter7String";
        this.Parameter8String = "UrlTemplateParameter8String";
        this.Parameter9String = "UrlTemplateParameter9String";
        this.Parameter10String = "UrlTemplateParameter10String";
        this.Parameter11String = "UrlTemplateParameter11String";
        this.Parameter12String = "UrlTemplateParameter12String";
        this.Parameter13String = "UrlTemplateParameter13String";
    }
};

// See C# UrlTemplate class this is the javascript equivalent
Sitka.UrlTemplate.prototype.ParameterReplace = function (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13)
{
    var url = this.urlTemplateString;
    
    // Can't tell whether it's int or string here so just do both
    url = url.replace(this.Parameter1Int, param1);
    url = url.replace(this.Parameter2Int, param2);
    url = url.replace(this.Parameter3Int, param3);
    url = url.replace(this.Parameter4Int, param4);
    url = url.replace(this.Parameter5Int, param5);
    url = url.replace(this.Parameter6Int, param6);
    url = url.replace(this.Parameter7Int, param7);
    url = url.replace(this.Parameter8Int, param8);
    url = url.replace(this.Parameter9Int, param9);    
    url = url.replace(this.Parameter10Int, param10);
    url = url.replace(this.Parameter11Int, param11);
    url = url.replace(this.Parameter12Int, param12);
    url = url.replace(this.Parameter13Int, param13);

    url = url.replace(this.Parameter1String, param1);
    url = url.replace(this.Parameter2String, param2);
    url = url.replace(this.Parameter3String, param3);
    url = url.replace(this.Parameter4String, param4);
    url = url.replace(this.Parameter5String, param5);
    url = url.replace(this.Parameter6String, param6);
    url = url.replace(this.Parameter7String, param7);
    url = url.replace(this.Parameter8String, param8);
    url = url.replace(this.Parameter9String, param9);    
    url = url.replace(this.Parameter10String, param10);
    url = url.replace(this.Parameter11String, param11);
    url = url.replace(this.Parameter12String, param12);
    url = url.replace(this.Parameter13String, param13);
    return url;
};

