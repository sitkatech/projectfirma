using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Web.Mvc.Html
{
    /// <summary>
    /// This implementation of CheckboxListFor was cloned from how MVC DropdownListFor works, in multiple mode
    /// Essentially made it render input type checkboxes with label fors instead of select with options
    /// Also, all the checkboxes have the same name, to allow for multiple selections
    /// </summary>
    public static class CheckboxExtensions
    {

        public enum ColNumber
        {
            oneCol,
            twoCols
        };
        // CheckBoxList
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null /* optionLabel */, null /* htmlAttributes */);
        }

        // CheckBoxList
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, ColNumber cols)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null /* optionLabel */, null /* htmlAttributes */,cols);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null /* optionLabel */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes, ColNumber cols)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null /* optionLabel */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), cols);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes, ColNumber cols)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null /* optionLabel */, htmlAttributes, cols);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, null /* optionLabel */, htmlAttributes);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, optionLabel, null /* htmlAttributes */);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, ColNumber cols)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, optionLabel, null /* htmlAttributes */, cols);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes, ColNumber cols)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), cols);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            return CheckBoxListFor(htmlHelper, expression, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Users cannot use anonymous methods with the LambdaExpression type")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return CheckBoxListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, optionLabel, htmlAttributes,ColNumber.oneCol);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Users cannot use anonymous methods with the LambdaExpression type")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes, ColNumber cols)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return CheckBoxListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, optionLabel, htmlAttributes, cols);
        }

        private static MvcHtmlString CheckBoxListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes, ColNumber cols)
        {
            return CheckboxListInternal(htmlHelper, metadata, optionLabel, expression, selectList, htmlAttributes, cols );
        }

        private static IEnumerable<SelectListItem> GetSelectListWithDefaultValue(IEnumerable<SelectListItem> selectList, object defaultValue)
        {
            var defaultValues = defaultValue as IEnumerable;
            if (defaultValues == null || defaultValues is string)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "The parameter '{0}' must evaluate to an IEnumerable when multiple selection is allowed.", "expression"));
            }

            var values = from object value in defaultValues select Convert.ToString(value, CultureInfo.CurrentCulture);

            // ToString() by default returns an enum value's name.  But selectList may use numeric values.
            IEnumerable<string> enumValues = from Enum value in defaultValues.OfType<Enum>() select value.ToString("d");
            values = values.Concat(enumValues);

            var selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
            var newSelectList = new List<SelectListItem>();

            foreach (var item in selectList)
            {
                item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                newSelectList.Add(item);
            }
            return newSelectList;
        }

        public static MvcHtmlString CheckboxListInternal(this HtmlHelper htmlHelper, ModelMetadata metadata,
            string optionLabel, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes, ColNumber cols)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentNullException("name", "Value cannot be null or empty.");
            }

            var defaultValue = GetModelStateValue(htmlHelper, fullName, typeof(string[]));

            // If we haven't already used ViewData to get the entire list of items then we need to
            // use the ViewData-supplied value before using the parameter-supplied value.
            if (defaultValue == null && !String.IsNullOrEmpty(name))
            {
                defaultValue = htmlHelper.ViewData.Eval(name);
            }

            if (defaultValue != null)
            {
                selectList = GetSelectListWithDefaultValue(selectList, defaultValue);
            }

            // Convert each ListItem to an <option> tag and wrap them with <optgroup> if requested.
            var listItemBuilder = BuildItems(optionLabel, selectList, htmlAttributes, fullName, cols);

            var tagBuilder = new TagBuilder("div")
            {
                InnerHtml = listItemBuilder.ToString()
            };
            tagBuilder.GenerateId(fullName);

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        static object GetModelStateValue(HtmlHelper htmlHelper, string key, Type destinationType)
        {
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState))
            {
                if (modelState.Value != null)
                {
                    return modelState.Value.ConvertTo(destinationType, null /* culture */);
                }
            }
            return null;
        }

        public static StringBuilder BuildItems(string optionLabel, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes, string fullName)
        {
            var listItemBuilder = new StringBuilder();

            // Make optionLabel the first item that gets rendered.
            if (optionLabel != null)
            {
                listItemBuilder.AppendLine(ListItemToCheckbox(new SelectListItem {
                    Text = optionLabel,
                    Value = String.Empty,
                    Selected = false
                }, htmlAttributes, fullName));
            }

            foreach (var selectListItem in selectList)
            {
                listItemBuilder.AppendLine(ListItemToCheckbox(selectListItem, htmlAttributes, fullName));
            }
            return listItemBuilder;
        }

        public static StringBuilder BuildItems(string optionLabel, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes, string fullName, ColNumber cols)
        {
            if (cols == ColNumber.twoCols)
            {
                var listItemBuilder = new StringBuilder();

                // Make optionLabel the first item that gets rendered.

                listItemBuilder.AppendLine("<div class=\"row\">");
                listItemBuilder.AppendLine("<div class=\"col-md-6\">");

                var selectListItems = selectList as SelectListItem[] ?? selectList.ToArray();
                int length = selectListItems.Length;
                double halfLength = ((double) length)/2.0;
                int index = 0;
                if (optionLabel != null)
                {
                    listItemBuilder.AppendLine(ListItemToCheckbox(new SelectListItem { Text = optionLabel, Value = String.Empty, Selected = false }, htmlAttributes, fullName));
                    halfLength = ((double) (length - 1.0))/2.0;
                }
                
                for (; index < halfLength; index++)
                {
                    listItemBuilder.AppendLine(ListItemToCheckbox(selectListItems.ElementAt(index), htmlAttributes, fullName));
                    
                }
                listItemBuilder.AppendLine("</div>");
                listItemBuilder.AppendLine("<div class=\"col-md-6\">");
                for (; index < length; index++)
                {
                    listItemBuilder.AppendLine(ListItemToCheckbox(selectListItems.ElementAt(index), htmlAttributes, fullName));
                }
                listItemBuilder.AppendLine("</div>");
                listItemBuilder.AppendLine("</div>");
                return listItemBuilder;
            }

            return BuildItems(optionLabel, selectList, htmlAttributes, fullName);

        }

        public static string ListItemToCheckbox(SelectListItem item, IDictionary<string, object> htmlAttributes, string fullName)
        {
            var labelBuilder = new TagBuilder("label");
            var inputBuilder = new TagBuilder("input");
            inputBuilder.Attributes["type"] = "checkbox";
            inputBuilder.MergeAttribute("name", fullName, true /* replaceExisting */);
            inputBuilder.GenerateId(fullName + item.Value);
            if (item.Value != null)
            {
                inputBuilder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                inputBuilder.Attributes["checked"] = "checked";
            }
            if (item.Disabled)
            {
                inputBuilder.Attributes["disabled"] = "disabled";
            }

            labelBuilder.MergeAttribute("for", inputBuilder.Attributes["id"], true /* replaceExisting */);
            labelBuilder.MergeAttributes(htmlAttributes);
            labelBuilder.InnerHtml = string.Format("{0} {1}", inputBuilder.ToString(TagRenderMode.Normal), item.Text);
            return labelBuilder.ToString(TagRenderMode.Normal);
        }
    }
}
