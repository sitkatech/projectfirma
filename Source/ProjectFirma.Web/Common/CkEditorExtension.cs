/*-----------------------------------------------------------------------
<copyright file="CkEditorExtension.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System.Data.Linq;

namespace ProjectFirma.Web.Common
{
    public static class CkEditorExtension
    {
        public enum CkEditorToolbar
        {
            All,
            AllOnOneRow,
            AllOnOneRowNoMaximize,
            Minimal,
            MinimalWithImages,
            None
        }

        public static HtmlString CkEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            CkEditorToolbar ckEditorToolbarMode,
            bool editable,
            bool allowAllContent,
            int? height) where TModel : FormViewModel
        {
            return CkEditorFor(helper, expression, ckEditorToolbarMode, editable, allowAllContent, null, height);
        }

        /// <summary>
        /// This is used by ckeditors for a FirmaPage
        /// </summary>
        public static HtmlString CkEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            CkEditorToolbar ckEditorToolbarMode,
            bool editable,
            int firmaPageID,
            int? height) where TModel : FormViewModel
        {
            var filebrowserImageUploadUrl = SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource(firmaPageID, null));
            return CkEditorFor(helper, expression, ckEditorToolbarMode, editable, false, filebrowserImageUploadUrl, height);
        }

        public static HtmlString CkEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            CkEditorToolbar ckEditorToolbarMode,
            bool editable,
            bool allowAllContent,
            string filebrowserImageUploadUrl,
            int? height) where TModel : FormViewModel
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var modelValue = (HtmlString)metadata.Model;
            if (!editable)
            {
                return modelValue;
            }
            var modelID = helper.IdFor(expression).ToString();

            var textAreaID = string.Format("CkEditorFor{0}", modelID);

            var htmlAttributes = new Dictionary<string, object>() { { "id", textAreaID }, { "contentEditable", "true" }, { "data-cke-editor-id", modelID } };

            var generateJavascript = GenerateJavascript(modelID, ckEditorToolbarMode, filebrowserImageUploadUrl, allowAllContent, height);
            var textAreaHtmlString = helper.TextAreaFor(expression, htmlAttributes);
            return MvcHtmlString.Create(string.Format(@"{0}{1}", textAreaHtmlString, generateJavascript));
        }

        public static string GenerateJavascript(string modelID, CkEditorToolbar ckEditorToolbarMode, string filebrowserImageUploadUrl, bool allowAllContent, int? height)
        {
            var tag = new TagBuilder("script");
            tag.Attributes.Add("type", "text/javascript");
            tag.Attributes.Add("language", "javascript");

            var ckEditorToolbarJavascript = GenerateToolbarSettings(ckEditorToolbarMode);
            var ckEditorID = String.Format("CkEditorFor{0}", modelID);

            var wireUpJsForImageUploader = String.Empty;
            if (ckEditorToolbarJavascript.HasImageToolbarButton)// && !string.IsNullOrWhiteSpace(filebrowserImageUploadUrl))
            {
                wireUpJsForImageUploader = @"file_picker_callback: (cb, value, meta) => {
                              const input = document.createElement(""input"")
                              input.setAttribute(""type"", ""file"")
                              input.setAttribute(""accept"", ""image/*"")
                              input.addEventListener(""change"", e => {
                                const file = e.target.files[0];

                                const reader = new FileReader();
                                reader.addEventListener(""load"", () => {
                                  const id = ""blobid"" + new Date().getTime();
                                  const blobCache = tinymce.activeEditor.editorUpload.blobCache;
                                  const base64 = reader.result.split("","")[1];
                                  const blobInfo = blobCache.create(id, file, base64);
                                  blobCache.add(blobInfo);

                                  /* call the callback and populate the Title field with the file name */
                                  cb(blobInfo.blobUri(), { title: file.name });
                                });
                                reader.readAsDataURL(file)
                              })
                              input.click()
                            },";
            }

            //var allowedContentString = allowAllContent ? "\r\n           , allowedContent: true" : string.Empty;

            //var heightString = height.HasValue ? string.Format("\r\n           , height: {0}", height.Value) : string.Empty;

            //tag.InnerHtml = String.Format(@"
            //    // <![CDATA[
            //    jQuery(document).ready(function ()
            //    {{
            //        CKEDITOR.replace(""{0}"", {{
            //           toolbar:
            //           [
            //{1}
            //           ]{2}{3}{4}
            //        }});
            //    }});
            //    // ]]>
            //", ckEditorID, ckEditorToolbarJavascript.JavascriptForToolbar, allowedContentString, wireUpJsForImageUploader, heightString);

            tag.InnerHtml = String.Format(@"
                // <![CDATA[
                jQuery(document).ready(function ()
                {{
                   tinymce.init({{
                            selector: '#{0}',
                            menubar: false,
                            toolbar: '{1}',
                            plugins: '{2}',

                            file_picker_types: 'image',
                            images_file_types: 'jpg,svg,webp,gif',
                            image_title: true,
                            {3}
                    }});
                }});
                // ]]>
            ", ckEditorID, ckEditorToolbarJavascript.JavascriptForToolbar, ckEditorToolbarJavascript.plugins, wireUpJsForImageUploader);


            return tag.ToString(TagRenderMode.Normal);
        }

        private class CkEditorToolbarJavascript
        {
            public readonly string JavascriptForToolbar;
            public readonly bool HasImageToolbarButton;
            public readonly string plugins;

            public CkEditorToolbarJavascript(string javascriptForToolbar, bool hasImageToolbarButton, string plugins)
            {
                JavascriptForToolbar = javascriptForToolbar;
                HasImageToolbarButton = hasImageToolbarButton;
                this.plugins = plugins;
            }
        }

        private static CkEditorToolbarJavascript GenerateToolbarSettings(CkEditorToolbar ckEditorToolbarMode)
        {
            bool hasImageToolbarButton;
            string toolbarSettings;
            string plugins;
            switch (ckEditorToolbarMode)
            {
                case CkEditorToolbar.All:
                    plugins = "";
                    toolbarSettings =
                        @"            { name: 'document',    groups: [ 'mode', 'document', 'doctools' ], items: [ 'Source', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', 'Templates', 'document' ] },
            { name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ], items: [ 'Find', 'Replace', 'SelectAll', 'Scayt' ] },
            { name: 'insert', items: [ 'CreatePlaceholder', 'Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe', 'InsertPre' ] },
            { name: 'forms', items: [ 'Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField' ] },
            { name: 'links', items: [ 'Link', 'Unlink', 'Anchor' ] },
            '/',
            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Underline', 'Subscript', 'Superscript', 'RemoveFormat' ] },
            { name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ], items: [ 'NumberedList', 'BulletedList', 'Outdent', 'Indent', 'CreateDiv', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'BidiLtr', 'BidiRtl' ] },
            { name: 'styles', items: [ 'Styles', 'Format', 'Font', 'FontSize' ] },
            { name: 'colors', items: [ 'TextColor', 'BGColor' ] },
            { name: 'tools', items: [ 'UIColor', 'Maximize', 'ShowBlocks' ] }";
                    hasImageToolbarButton = true;
                    break;
                case CkEditorToolbar.AllOnOneRow:
                    plugins = "";
                    toolbarSettings =
                        @"            { name: 'document',    groups: [ 'mode', 'document', 'doctools' ], items: [ 'Source', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', 'Templates', 'document' ] },
            { name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ], items: [ 'Find', 'Replace', 'SelectAll', 'Scayt' ] },
            { name: 'insert', items: [ 'CreatePlaceholder', 'Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe', 'InsertPre' ] },
            { name: 'forms', items: [ 'Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField' ] },
            { name: 'links', items: [ 'Link', 'Unlink', 'Anchor' ] },
            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Underline', 'Subscript', 'Superscript', 'RemoveFormat' ] },
            { name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ], items: [ 'NumberedList', 'BulletedList', 'Outdent', 'Indent', 'CreateDiv', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'BidiLtr', 'BidiRtl' ] },
            { name: 'styles', items: [ 'Styles', 'Format', 'Font', 'FontSize' ] },
            { name: 'colors', items: [ 'TextColor', 'BGColor' ] },
            { name: 'tools', items: [ 'UIColor', 'Maximize', 'ShowBlocks' ] }";
                    hasImageToolbarButton = true;
                    break;
                case CkEditorToolbar.AllOnOneRowNoMaximize:
                    plugins = "";
                    toolbarSettings =
                        @"            { name: 'document',    groups: [ 'mode', 'document', 'doctools' ], items: [ 'Source', 'Save', 'NewPage', 'DocProps', 'Preview', 'Print', 'Templates', 'document' ] },
            { name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ], items: [ 'Find', 'Replace', 'SelectAll', 'Scayt' ] },
            { name: 'insert', items: [ 'CreatePlaceholder', 'Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe', 'InsertPre' ] },
            { name: 'forms', items: [ 'Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField' ] },
            { name: 'links', items: [ 'Link', 'Unlink', 'Anchor' ] },
            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Underline', 'Subscript', 'Superscript', 'RemoveFormat' ] },
            { name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ], items: [ 'NumberedList', 'BulletedList', 'Outdent', 'Indent', 'CreateDiv', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'BidiLtr', 'BidiRtl' ] },
            { name: 'styles', items: [ 'Styles', 'Format', 'Font', 'FontSize' ] },
            { name: 'colors', items: [ 'TextColor', 'BGColor' ] },
            { name: 'tools', items: [ 'UIColor', 'ShowBlocks' ] }";
                    hasImageToolbarButton = true;
                    break;
                case CkEditorToolbar.Minimal:
                    toolbarSettings =
                        //            @"            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Underline', 'Subscript', 'Superscript', 'RemoveFormat' ] },
                        //{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ], items: [ 'NumberedList', 'BulletedList', 'Outdent', 'Indent', 'CreateDiv', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'BidiLtr', 'BidiRtl' ] },
                        //{ name: 'styles', items: [ 'Styles', 'Format', 'Font', 'FontSize' ] },
                        //{ name: 'links', items: [ 'Link', 'Unlink', 'Anchor' ] }";
                        "styleselect | bold italic removeformat | bullist numlist outdent indent | styles | fontfamily | link unlink anchor ";
                    plugins = "lists link code help wordcount anchor";
                    hasImageToolbarButton = false;
                    break;
                case CkEditorToolbar.MinimalWithImages:
                    toolbarSettings =
            //            @"            { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Underline', 'Subscript', 'Superscript', 'RemoveFormat' ] },
            //{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align' ], items: [ 'NumberedList', 'BulletedList', 'Outdent', 'Indent', 'CreateDiv', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'BidiLtr', 'BidiRtl' ] },
            //{ name: 'insert', items: [ 'Image', 'Table', 'HorizontalRule', 'SpecialChar' ] },
            //{ name: 'links', items: [ 'Link', 'Unlink', 'Anchor' ] }";
            " styleselect | bold italic removeformat | bullist numlist outdent indent | image table hr charmap | link unlink anchor";
                    plugins = "lists link image table code help wordcount charmap anchor";

                    hasImageToolbarButton = true;
                    break;
                case CkEditorToolbar.None:
                    toolbarSettings = String.Empty;
                    hasImageToolbarButton = false;
                    plugins = "";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("ckEditorToolbarMode");
            }
            return new CkEditorToolbarJavascript(toolbarSettings, hasImageToolbarButton, plugins);
        }
    }
}
