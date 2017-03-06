/*-----------------------------------------------------------------------
<copyright file="qtippopuphelper.js" company="Tahoe Regional Planning Agency">
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
var ProjectFirma = {
    Views:
    {
        Methods:
        {
            addAjaxDetailPopupUrl: function(element, ajaxUrl, description, width, targetHook, tipHook, onShowFunc, onHideFunc, solo, modal) {
                var qtipParameter = {
                    content: {
                        text: 'Loading...',
                        ajax: {
                            url: ajaxUrl,
                            type: 'GET'
                        },
                        title: {
                            text: description,
                            button: " "
                        }
                    },
                    position: targetHook && tipHook ? {
                        at: targetHook,
                        my: tipHook
                    } :
                        {
                            my: "center",
                            at: "center",
                            target: jQuery(window)
                        },
                    style: {
                        width: width ? width : 600,
                        tip: false
                    },
                    show: {
                        delay: 0,
                        solo: solo != undefined ? solo : true,
                        modal: modal != undefined ? modal : false,
                        event: "click"
                    },
                    hide: {
                        event: false
                    },
                    events: {
                        render: function(event, api) { api.elements.tooltip.draggable({ handle: api.elements.title, cursor: "move" }); },
                        hide: onHideFunc ? onHideFunc : function(event, api) { api.destroy(); }, // this forces the ajax to be called again... tried the ajax.once way with no luck... this works
                        show: onShowFunc ? onShowFunc : function() { return; }
                    }
                };
                if (!('object' === typeof jQuery(element).data('qtip')))
                    jQuery(element).qtip(qtipParameter);
            },
            addDetailPopup: function(element, popupElement, description, width, style, targetHook, tipHook, onShowFunc, onHideFunc) {
                var qtipParameter = {
                    content: {
                        text: popupElement,
                        title: {
                            text: description,
                            button: " "
                        }
                    },
                    position: targetHook && tipHook ? {
                        at: targetHook,
                        my: tipHook
                    } :
                        {
                            at: "center",
                            my: "center",
                            target: jQuery(window)
                        },
                    style: {
                        width: width ? width : 600,
                        tip: false
                    },
                    show: {
                        delay: 0,
                        solo: true,
                        event: "click"
                    },
                    hide: {
                        event: false
                    },
                    events: {
                        render: function(event, api) { api.elements.tooltip.draggable({ handle: api.elements.title, cursor: "move" }); },
                        show: onShowFunc ? onShowFunc : function() { return; },
                        hide: onHideFunc ? onHideFunc : function() { return; }
                    }
                };
                if (!('object' === typeof jQuery(element).data('qtip')))
                    jQuery(element).qtip(qtipParameter);
            },
            addTooltipPopup: function(element, content) {
                var qtipParameter = {
                    content: {
                        text: content
                    },
                    show: {
                        delay: 0,
                        solo: true,
                        event: "click"
                    },
                    position: {
                        at: "top-center",
                        my: "bottom-right",
                        viewport: jQuery(window)
                    }
                };
                if (!('object' === typeof jQuery(element).data('qtip')))
                    jQuery(element).qtip(qtipParameter);
            },
            addHelpTooltipPopup: function(element, title, ajaxUrl, width)
            {
                var qtipParameter = {
                    content: {
                        title: {
                            text: title,
                            button: true
                        },
                        text: 'Loading...',
                        ajax: {
                            url: ajaxUrl,
                            type: 'GET'
                        },
                    },
                    show: {
                        delay: 0,
                        solo: false,
                        modal: false,
                        event: "click"
                    },
                    hide: {
                        event: false
                    },
                    position: {
                        viewport: jQuery(window),
                        adjust: { scroll: false }
                    },
                    style: {
                        classes: "ui-tooltip-help",
                        width: width
                    },
                    suppress: false,
                    events: {
                        render: function(event, api)
                        {
                            $(window).bind('keydown', function(e)
                            {
                                if (e.keyCode === 27)
                                {
                                    api.hide(e);
                                }
                            });
                            $(this).draggable({ handle: api.elements.titlebar, containment: "window", cursor: "move" });
                        },
                        show: function()
                        {
                            jQuery('.qtip.ui-tooltip-help').qtip('hide');
                        }
                    }
                };
                if (!('object' === typeof jQuery(element).data('qtip')))
                {
                    jQuery(element).qtip(qtipParameter);
                }
            },
            closeAllTips: function () {
                jQuery('*').qtip('hide');
            }
        }
    }
};
