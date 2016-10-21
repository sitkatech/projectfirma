CKEDITOR.disableAutoInline = true;

jQuery(document).ready(function ()
{
    jQuery("form").on("submit", function () {

        for (var i in CKEDITOR.instances)
        {
            var ckEditorForDiv = CKEDITOR.instances[i];
            var id = ckEditorForDiv.name;
            var ckEditorHtml = ckEditorForDiv.getData();
            jQuery("#" + id).val(ckEditorHtml);
        }
    });
});