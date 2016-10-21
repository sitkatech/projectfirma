// bootstrap-ckeditor-fix.js
// hack to fix ckeditor/bootstrap compatiability bug when ckeditor appears in a bootstrap modal dialog
//
// Include this file AFTER both jQuery and bootstrap are loaded.

$.fn.modal.Constructor.prototype.enforceFocus = function () {
    var $modalElement = this.$element;
    $(document).on('focusin.modal', function(e)
    {
        var $parent = $(e.target.parentNode);
        if ($modalElement[0] !== e.target && !$modalElement.has(e.target).length
            // add whatever conditions you need here:
            &&
            !$parent.hasClass('cke_dialog_ui_input_select') && !$parent.hasClass('cke_dialog_ui_input_text'))
        {
            $modalElement.focus();
        }
    });
};


CKEDITOR.plugins.add('test-plugin', {
    init: function (editor) {

        editor.on('instanceReady', function (e) {
            editor.editable().on('click', function (event) {
                console.log('clicked!');
                console.log(event);
            });
        });
    }
});

CKEDITOR.config.plugins += ',test-plugin';
CKEDITOR.disableAutoInline = true;

