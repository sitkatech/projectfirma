/*-----------------------------------------------------------------------
<copyright file="TinyMCEExtension.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.Models;


namespace ProjectFirma.Web.Common
{
    public static class TinyMCEExtension
    {
        public enum TinyMCEToolbarStyle
        {
            All,
            AllOnOneRow,
            AllOnOneRowNoMaximize,
            Minimal,
            MinimalWithImages,
            None
        }

        /// <summary>
        /// This is used by tinyMCEeditors for a FirmaPage
        /// </summary>
        public static HtmlString TinyMCEEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            TinyMCEToolbarStyle tinyMceToolbarStyleMode,
            bool editable,
            int firmaPageID,
            int? height) where TModel : FormViewModel
        {
            return TinyMCEEditorFor(helper, expression, tinyMceToolbarStyleMode, editable, false, height);
        }

        public static HtmlString TinyMCEEditorFor<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            TinyMCEToolbarStyle tinyMceToolbarStyleMode,
            bool editable,
            bool allowAllContent,
            int? height) where TModel : FormViewModel
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var modelValue = (HtmlString)metadata.Model;
            if (!editable)
            {
                return modelValue;
            }
            var modelID = helper.IdFor(expression).ToString();

            var textAreaID = string.Format("TinyMCEEditorFor{0}", modelID);

            var htmlAttributes = new Dictionary<string, object>() { { "id", textAreaID }, { "contentEditable", "true" }, { "data-editor-id", modelID } };

            var generateJavascript = GenerateJavascript(modelID, tinyMceToolbarStyleMode, allowAllContent, height);
            var textAreaHtmlString = helper.TextAreaFor(expression, htmlAttributes);
            return MvcHtmlString.Create(string.Format(@"{0}{1}", textAreaHtmlString, generateJavascript));
        }

        public static string GenerateJavascript(string modelID, TinyMCEToolbarStyle tinyMceToolbarStyleMode, bool allowAllContent, int? height)
        {
            var tag = new TagBuilder("script");
            tag.Attributes.Add("type", "text/javascript");
            tag.Attributes.Add("language", "javascript");

            var tinyMCEEditorToolbarJavascript = GenerateToolbarSettings(tinyMceToolbarStyleMode);
            var editorId = String.Format("TinyMCEEditorFor{0}", modelID);

            var wireUpJsForImageUploader = String.Empty;
            if (tinyMCEEditorToolbarJavascript.HasImageToolbarButton)
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

            var heightString = height.HasValue ? string.Format("\r\n           height: {0},", height.Value) : string.Empty;
            
            tag.InnerHtml = String.Format(@"
                // <![CDATA[
                jQuery(document).ready(function ()
                {{
                   tinymce.init({{
                            selector: '#{0}',
                            menubar: false,
                            toolbar: '{1}',
                            entity_encoding: 'named+numeric',
                            plugins: '{2}',
                            toolbar_mode: '{4}',
                            browser_spellcheck: true,
                            file_picker_types: 'image',
                            images_file_types: 'jpg,svg,webp,gif',
                            image_title: true,
                            {3}{5}
                            setup: function (editor) {{
                                editor.on('FullscreenStateChanged', function (e) {{
                                    if (e.state) {{
                                        $('.modal-dialog').attr('style', 'transform: none !important');
                                    }} else {{
                                        $('.modal-dialog').attr('style', 'transform: translate(0,0)');
                                    }}
                                }});
                            }}
                    }});
                }});
                jQuery(document).on('focusin', function (e) {{
                    if (jQuery(e.target).closest("".tox-textfield .tox-tinymce, .tox-tinymce-aux"").length)
                        e.stopImmediatePropagation();
                }});
                // ]]>
            ", editorId, tinyMCEEditorToolbarJavascript.JavascriptForToolbar, tinyMCEEditorToolbarJavascript.Plugins, wireUpJsForImageUploader, tinyMCEEditorToolbarJavascript.ToolbarMode, heightString);


            return tag.ToString(TagRenderMode.Normal);
        }

        private class TinyMCEEditorToolbarJavascript
        {
            public readonly string JavascriptForToolbar;
            public readonly bool HasImageToolbarButton;
            public readonly string Plugins;
            public readonly string ToolbarMode;

            public TinyMCEEditorToolbarJavascript(string javascriptForToolbar, bool hasImageToolbarButton, string plugins, string toolbarMode)
            {
                JavascriptForToolbar = javascriptForToolbar;
                HasImageToolbarButton = hasImageToolbarButton;
                Plugins = plugins;
                ToolbarMode = toolbarMode;

            }
        }

        private static TinyMCEEditorToolbarJavascript GenerateToolbarSettings(TinyMCEToolbarStyle tinyMceToolbarStyleMode)
        {
            bool hasImageToolbarButton;
            string toolbarSettings;
            string plugins;
            string toolbarMode;
            switch (tinyMceToolbarStyleMode)
            {
                case TinyMCEToolbarStyle.All:
                    plugins = "code lists link image table code help wordcount charmap anchor fullscreen";
                    toolbarSettings =
                        "code | styleselect | bold italic removeformat | bullist numlist outdent indent | image table hr charmap | link unlink anchor | styles | fontfamily | fullscreen ";
                    toolbarMode = "wrap";
                    hasImageToolbarButton = true;
                    break;
                case TinyMCEToolbarStyle.AllOnOneRow:
                    plugins = "code lists link image table code help wordcount charmap anchor fullscreen";
                    toolbarMode = "floating";
                    toolbarSettings =
                        "code | styleselect | bold italic removeformat | bullist numlist outdent indent | image table hr charmap | link unlink anchor | styles | fontfamily ";
                    
                    hasImageToolbarButton = true;
                    break;
                case TinyMCEToolbarStyle.AllOnOneRowNoMaximize:
                   plugins = "code lists link image table code help wordcount charmap anchor";
                   toolbarMode = "floating";
                    toolbarSettings =
                        "code | styleselect | bold italic removeformat | bullist numlist outdent indent | image table hr charmap | link unlink anchor | styles | fontfamily ";
                    
                    hasImageToolbarButton = true;
                    break;
                case TinyMCEToolbarStyle.Minimal:
                    toolbarSettings =
                        "styleselect | bold italic removeformat | bullist numlist outdent indent | styles | fontfamily | link unlink anchor ";
                    plugins = "lists link code help wordcount anchor";
                    toolbarMode = "floating";
                    hasImageToolbarButton = false;
                    break;
                case TinyMCEToolbarStyle.MinimalWithImages:
                    toolbarSettings =
                        " styleselect | bold italic removeformat | bullist numlist outdent indent | image table hr charmap | link unlink anchor";
                    plugins = "lists link image table code help wordcount charmap anchor";
                    toolbarMode = "floating";
                    hasImageToolbarButton = true;
                    break;
                case TinyMCEToolbarStyle.None:
                    toolbarSettings = String.Empty;
                    hasImageToolbarButton = false;
                    toolbarMode = "floating";
                    plugins = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tinyMceToolbarStyleMode");
            }
            return new TinyMCEEditorToolbarJavascript(toolbarSettings, hasImageToolbarButton, plugins, toolbarMode);
        }
    }
}
