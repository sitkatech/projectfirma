/*-----------------------------------------------------------------------
<copyright file="LabelForExtensions.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.BootstrapWrappers;

namespace LtInfo.Common.HtmlHelperExtensions
{
    public static class AngularExtensions
    {
        public static MvcHtmlString AngularDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string ngModel,
            string ngOptions,
            string optionValue,
            string optionText,
            string ngSelected,
            string optionEmptyRowText,
            string optionEmptyRowValue,
            object htmlAttributes = null)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            return AngularDropdownList(htmlHelper,
                metadata,
                name,
                ngModel,
                ngOptions,
                optionValue,
                optionText,
                ngSelected,
                optionEmptyRowText,
                optionEmptyRowValue,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString AngularDropdownList(this HtmlHelper htmlHelper,
            ModelMetadata metadata,
            string name,
            string ngModel,
            string ngOptions,
            string optionValue,
            string optionText,
            string ngSelected,
            string optionEmptyRowText,
            string optionEmptyRowValue,
            IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }
            fullName = fullName.Replace("0", "{{$index}}");

            var dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", fullName);
            dropdown.Attributes.Add("data-ng-model", ngModel);
            dropdown.MergeAttributes(htmlAttributes);
            dropdown.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

            var options = new StringBuilder();
            // Make optionLabel the first item that gets rendered.
            if (optionEmptyRowText != null)
            {
                options.AppendFormat("<option value=\"{0}\">{1}</option>", optionEmptyRowValue, optionEmptyRowText);
                options.AppendLine();
            }
            options.AppendFormat("<option data-ng-repeat=\"{0}\" value=\"{1}\" data-ng-bind=\"{2}\" data-ng-selected=\"{3}\"></option>", ngOptions, optionValue, optionText, ngSelected);

            dropdown.InnerHtml = options.ToString();
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString AngularTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string ngModel,
            object htmlAttributes = null)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            return AngularTextBox(htmlHelper, metadata, name, ngModel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString AngularTextBox(this HtmlHelper htmlHelper, ModelMetadata metadata, string name, string ngModel, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }
            fullName = fullName.Replace("0", "{{$index}}");

            var input = new TagBuilder("input");
            input.Attributes.Add("name", fullName);
            input.Attributes.Add("data-ng-model", ngModel);
            input.MergeAttributes(htmlAttributes);
            input.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

            return MvcHtmlString.Create(input.ToString(TagRenderMode.Normal));
        }
    }

    public static class LabelWithSugarForExtensions
    {
        public enum DisplayStyle
        {
            AsGridHeader,
            HelpIconOnly,
            HelpIconWithLabel,
        }

        public const int DefaultPopupWidth = 300;

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor<TViewModel, TValue>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TValue>> expression)
        {
            return LabelWithSugarFor(html, expression, DefaultPopupWidth);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor<TViewModel, TValue>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TValue>> expression, string labelText)
        {
            return LabelWithSugarFor(html, expression, DefaultPopupWidth, labelText);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor(this HtmlHelper html, IFieldDefinition fieldDefinition)
        {
            return LabelWithSugarFor(html, fieldDefinition, DefaultPopupWidth);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon and with custom label text
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor(this HtmlHelper html, IFieldDefinition fieldDefinition, string labelText)
        {
            return LabelWithSugarFor(fieldDefinition, DefaultPopupWidth, DisplayStyle.HelpIconWithLabel, labelText);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor(this HtmlHelper html, IFieldDefinition fieldDefinition, int popupWidth)
        {
            return LabelWithSugarFor(html, fieldDefinition, popupWidth, DisplayStyle.HelpIconWithLabel);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor(this HtmlHelper html, IFieldDefinition fieldDefinition, DisplayStyle displayStyle)
        {
            return LabelWithSugarFor(html, fieldDefinition, DefaultPopupWidth, displayStyle);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor(this HtmlHelper html, IFieldDefinition fieldDefinition, DisplayStyle displayStyle, string labelText)
        {
            return LabelWithSugarFor(fieldDefinition, DefaultPopupWidth, displayStyle, labelText);
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor(this HtmlHelper html, IFieldDefinition fieldDefinition, int popupWidth, DisplayStyle displayStyle)
        {
            return LabelWithSugarFor(fieldDefinition, popupWidth, displayStyle, fieldDefinition.GetFieldDefinitionLabel());
        }

        public static MvcHtmlString LinkWithFieldDefinitionFor(this HtmlHelper html, IFieldDefinition fieldDefinition, string linkText, List<string> cssClasses)
        {
            return LinkWithFieldDefinitionFor(html, fieldDefinition, linkText, DefaultPopupWidth, cssClasses);
        }

        public static MvcHtmlString LinkWithFieldDefinitionFor(this HtmlHelper html, IFieldDefinition fieldDefinition, string linkText, int popupWidth, List<string> cssClasses)
        {
            var fieldDefinitionLinkTag = new TagBuilder("a");
            fieldDefinitionLinkTag.Attributes.Add("href", "javascript:void(0)");
            fieldDefinitionLinkTag.Attributes.Add("class", string.Join(" ", cssClasses));
            var labelText = fieldDefinition.GetFieldDefinitionLabel();
            fieldDefinitionLinkTag.Attributes.Add("title", string.Format("Click to get help on {0}", labelText));
            fieldDefinitionLinkTag.InnerHtml = linkText;
            var urlToContent = fieldDefinition.GetContentUrl();
            AddHelpToolTipPopupToHtmlTag(fieldDefinitionLinkTag, labelText, urlToContent, popupWidth);
            return new MvcHtmlString(fieldDefinitionLinkTag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Does what LabelWithHelpFor does and adds a help icon
        /// </summary>
        public static MvcHtmlString LabelWithSugarFor<TViewModel, TValue>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TValue>> expression, int popupWidth)
        {
            return LabelWithSugarFor(html, expression, popupWidth, null);
        }

        public static MvcHtmlString LabelWithSugarFor<TViewModel, TValue>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TValue>> expression, int popupWidth, string labelText)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var memberExpression = (expression.Body as MemberExpression);
            if (memberExpression == null)
            {
                return new MvcHtmlString(string.Empty);
            }
            var fieldDefinitionDisplayAttributeType = typeof(IFieldDefinitionDisplayAttribute);
            var fieldDefinitionDisplayAttribute = memberExpression.Member.GetCustomAttributes(fieldDefinitionDisplayAttributeType, true).Cast<IFieldDefinitionDisplayAttribute>().SingleOrDefault();

            var requiredAttributeType = typeof(RequiredAttribute);
            var hasRequiredAttribute = memberExpression.Member.GetCustomAttributes(requiredAttributeType, true).Cast<RequiredAttribute>().Any();
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            if (fieldDefinitionDisplayAttribute == null)
            {
                return LabelWithRequiredTagForImpl(html, metadata, htmlFieldName, hasRequiredAttribute, labelText, null);
            }
            else
            {
                var fieldDefinition = fieldDefinitionDisplayAttribute.FieldDefinition;
                var fieldDefinitionData = fieldDefinition.GetFieldDefinitionData();
                var fullHtmlFieldID = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
                var fieldDefinitionDisplayName = string.IsNullOrWhiteSpace(labelText) ? fieldDefinition.GetFieldDefinitionLabel() : labelText;
                return LabelWithSugarFor(fieldDefinitionData, fullHtmlFieldID, popupWidth, DisplayStyle.HelpIconWithLabel, hasRequiredAttribute, fieldDefinitionDisplayName, fieldDefinition.GetContentUrl());
            }
        }

        public static MvcHtmlString LabelWithSugarFor<TViewModel, TValue>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TValue>> expression, bool hasRequiredAttribute)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            return LabelWithRequiredTagForImpl(html, metadata, htmlFieldName, hasRequiredAttribute, null, null);
        }

        public static MvcHtmlString LabelWithSugarFor(IFieldDefinition fieldDefinition, int popupWidth, DisplayStyle displayStyle, string labelText)
        {
            var fullHtmlFieldID = labelText.Replace(" ", "");
            // in this case, we are not trying to tie it to an actual viewmodel; we only want it to be safe as an id to find by jquery
            return LabelWithSugarFor(fieldDefinition.GetFieldDefinitionData(), fullHtmlFieldID, popupWidth, displayStyle, false, labelText, fieldDefinition.GetContentUrl());
        }

        private static MvcHtmlString LabelWithSugarFor(IFieldDefinitionData fieldDefinitionData, string fullHtmlFieldID, int popupWidth, DisplayStyle displayStyle, bool hasRequiredAttribute, string labelText, string urlToContent)
        {
            return LabelWithFieldDefinitionForImpl(labelText, fullHtmlFieldID, fieldDefinitionData, urlToContent, popupWidth, displayStyle, hasRequiredAttribute);
        }

        public static MvcHtmlString LabelWithRequiredTagFor(this HtmlHelper html, string labelText)
        {
            return LabelWithRequiredTagForImpl(html, null, null, true, labelText, null);
        }

        private static MvcHtmlString LabelWithRequiredTagForImpl(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, bool hasRequiredAttribute, string labelText = null, IDictionary<string, object> htmlAttributes = null)
        {
            string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));

            var requiredAsterisk = BuildRequiredAsterisk(hasRequiredAttribute, tag);

            tag.InnerHtml = string.Format("{0} {1}", resolvedLabelText, requiredAsterisk);
            tag.MergeAttributes(htmlAttributes, true);

            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// only public for unit testing
        /// </summary>
        public static MvcHtmlString LabelWithFieldDefinitionForImpl(string labelText,
            string fullHtmlFieldID,
            IFieldDefinitionData fieldDefinitionData,
            string urlToContent,
            int popupWidth,
            DisplayStyle displayStyle, bool hasRequiredAttribute)
        {
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var fieldDefinitionDefinition = new HtmlString(string.Empty);
            if (fieldDefinitionData != null)
            {
                fieldDefinitionDefinition = fieldDefinitionData.FieldDefinitionDataValueHtmlString;
            }
            var helpIconImgTag = GenerateHelpIconImgTag(labelText, fieldDefinitionDefinition, urlToContent, popupWidth, displayStyle);
            var labelTag = new TagBuilder("label");
            labelTag.Attributes.Add("for", fullHtmlFieldID);
            labelTag.SetInnerText(labelText);

            switch (displayStyle)
            {
                case DisplayStyle.AsGridHeader:
                    var divTag = new TagBuilder("div");
                    divTag.Attributes.Add("style", "display:table; vertical-align: top");
                    labelTag.Attributes.Add("style", "display:table-cell");
                    divTag.InnerHtml = string.Format("{0}{1}", helpIconImgTag, labelTag.ToString(TagRenderMode.Normal));
                    return MvcHtmlString.Create(divTag.ToString(TagRenderMode.Normal));
                case DisplayStyle.HelpIconOnly:
                    return MvcHtmlString.Create(helpIconImgTag);
                case DisplayStyle.HelpIconWithLabel:
                    var requiredAsterisk = BuildRequiredAsterisk(hasRequiredAttribute, labelTag);
                    labelTag.InnerHtml = string.Format("{0}{1}{2}", helpIconImgTag, labelText, requiredAsterisk);
                    return MvcHtmlString.Create(labelTag.ToString(TagRenderMode.Normal));
                default:
                    throw new ArgumentOutOfRangeException("displayStyle");
            }
        }

        private static string BuildRequiredAsterisk(bool hasRequiredAttribute, TagBuilder labelTag)
        {
            var requiredAsterisk =
                hasRequiredAttribute ? " <sup>" + BootstrapHtmlHelpers.RequiredIcon + "</sup>" : string.Empty;
            // pad on the right if not required, such that the ends of the labels' texts line up with required icons floating to the right if present.
            if (!hasRequiredAttribute)
            {
                labelTag.Attributes.Add("style", "padding-right: 12px;");
            }

            return requiredAsterisk;
        }

        public static string GenerateHelpIconImgTag(string labelText, HtmlString fieldDefinitionDefinition, string urlToContent, int popupWidth, DisplayStyle displayStyle)
        {
            var helpIconImgTag = new TagBuilder("span");
            helpIconImgTag.Attributes.Add("class", "helpicon glyphicon glyphicon-question-sign");
            helpIconImgTag.Attributes.Add("title", string.Format("Click to get help on {0}", labelText));
            AddHelpToolTipPopupToHtmlTag(helpIconImgTag, labelText, urlToContent, popupWidth);
            if (displayStyle == DisplayStyle.AsGridHeader)
            {
                // this cancels the sort even on the dhtmlxgrid
                helpIconImgTag.Attributes.Add("onclick", "(arguments[0]||window.event).cancelBubble=true;");
                helpIconImgTag.Attributes.Add("style", "display:table-cell; padding-right:2px");
            }
            return helpIconImgTag.ToString(TagRenderMode.Normal);
        }

        public static void AddHelpToolTipPopupToHtmlTag(TagBuilder tagBuilder, string labelText, string urlToContent, int popupWidth)
        {
            tagBuilder.Attributes.Add("onmouseover", string.Format("ProjectFirma.Views.Methods.addHelpTooltipPopup(this, {0}, {1}, {2})", labelText.ToJS(), urlToContent.ToJS(), popupWidth));
        }

        public static MvcHtmlString GenerateHelpLink(string linkText, string popupTitleText, string urlToContent, int popupWidth)
        {
            var helpIconImgTag = new TagBuilder("span");
            helpIconImgTag.Attributes.Add("class", "helpicon glyphicon glyphicon-question-sign helpiconGridBlue");
            helpIconImgTag.Attributes.Add("title", string.Format("Click to get help on {0}", linkText));
            AddHelpToolTipPopupToHtmlTag(helpIconImgTag, popupTitleText, urlToContent, popupWidth);
            var labelTag = new TagBuilder("a");
            AddHelpToolTipPopupToHtmlTag(labelTag, popupTitleText, urlToContent, popupWidth);
            labelTag.SetInnerText(linkText);
            return MvcHtmlString.Create(string.Format("{0} {1}", helpIconImgTag.ToString(TagRenderMode.Normal), labelTag.ToString(TagRenderMode.Normal)));
        }
    }    
}
