/*-----------------------------------------------------------------------
<copyright file="DropDownGroupList.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LtInfo.Common.Models.Attributes
{
	public class GroupedSelectListItem : SelectListItem
	{
	    public GroupedSelectListItem(string groupKey, string groupName, bool selected, string text, string value)
	    {
	        this.GroupKey = groupKey;
	        this.GroupName = groupName;
	        this.Selected = selected;
	        this.Text = text;
	        this.Value = value;
	    }

        /// <summary>
        /// Empty, default constructor
        /// </summary>
	    public GroupedSelectListItem()
	    {
	    }

	    public string GroupKey { get; set; }
		public string GroupName { get; set; }
	}

	public static class HtmlHelpers
	{

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name)
		{
			return DropDownListHelper(htmlHelper, name, null, null, null);
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, IEnumerable<GroupedSelectListItem> selectList)
		{
			return DropDownListHelper(htmlHelper, name, selectList, null, null);
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, string optionLabel)
		{
			return DropDownListHelper(htmlHelper, name, null, optionLabel, null);
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, IEnumerable<GroupedSelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownListHelper(htmlHelper, name, selectList, null, htmlAttributes);
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, IEnumerable<GroupedSelectListItem> selectList, object htmlAttributes)
		{
			return DropDownListHelper(htmlHelper, name, selectList, null, new RouteValueDictionary(htmlAttributes));
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, IEnumerable<GroupedSelectListItem> selectList, string optionLabel)
		{
			return DropDownListHelper(htmlHelper, name, selectList, optionLabel, null);
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, IEnumerable<GroupedSelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return DropDownListHelper(htmlHelper, name, selectList, optionLabel, htmlAttributes);
		}

		public static MvcHtmlString DropDownGroupList(this HtmlHelper htmlHelper, string name, IEnumerable<GroupedSelectListItem> selectList, string optionLabel, object htmlAttributes)
		{
			return DropDownListHelper(htmlHelper, name, selectList, optionLabel, new RouteValueDictionary(htmlAttributes));
		}

		public static MvcHtmlString DropDownGroupListFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> htmlHelper, Expression<Func<TViewModel, TProperty>> expression, IEnumerable<GroupedSelectListItem> selectList)
		{
			return DropDownGroupListFor(htmlHelper, expression, selectList, null /* optionLabel */, null /* htmlAttributes */);
		}

		public static MvcHtmlString DropDownGroupListFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> htmlHelper, Expression<Func<TViewModel, TProperty>> expression, IEnumerable<GroupedSelectListItem> selectList, object htmlAttributes)
		{
			return DropDownGroupListFor(htmlHelper, expression, selectList, null /* optionLabel */, new RouteValueDictionary(htmlAttributes));
		}

		public static MvcHtmlString DropDownGroupListFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> htmlHelper, Expression<Func<TViewModel, TProperty>> expression, IEnumerable<GroupedSelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return DropDownGroupListFor(htmlHelper, expression, selectList, null /* optionLabel */, htmlAttributes);
		}

		public static MvcHtmlString DropDownGroupListFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> htmlHelper, Expression<Func<TViewModel, TProperty>> expression, IEnumerable<GroupedSelectListItem> selectList, string optionLabel)
		{
			return DropDownGroupListFor(htmlHelper, expression, selectList, optionLabel, null /* htmlAttributes */);
		}

		public static MvcHtmlString DropDownGroupListFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> htmlHelper, Expression<Func<TViewModel, TProperty>> expression, IEnumerable<GroupedSelectListItem> selectList, string optionLabel, object htmlAttributes)
		{
			return DropDownGroupListFor(htmlHelper, expression, selectList, optionLabel, new RouteValueDictionary(htmlAttributes));
		}

		public static MvcHtmlString DropDownGroupListFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> htmlHelper, Expression<Func<TViewModel, TProperty>> expression, IEnumerable<GroupedSelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}

			return DropDownListHelper(htmlHelper, ExpressionHelper.GetExpressionText(expression), selectList, optionLabel, htmlAttributes);
		}

		private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, string expression, IEnumerable<GroupedSelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return SelectInternal(htmlHelper, optionLabel, expression, selectList, false /* allowMultiple */, htmlAttributes);
		}


		// Helper methods

		private static IEnumerable<GroupedSelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name)
		{
			object o = null;
			if (htmlHelper.ViewData != null)
			{
				o = htmlHelper.ViewData.Eval(name);
			}
			if (o == null)
			{
			    if (name != null)
			    {
			        throw new InvalidOperationException("Missing Select Data");
			    }
			}
			var selectList = o as IEnumerable<GroupedSelectListItem>;
			if (selectList == null)
			{
				throw new InvalidOperationException("Wrong Select DataType");
			}
			return selectList;
		}

		internal static string ListItemToOption(GroupedSelectListItem item)
		{
			var builder = new TagBuilder("option")
			{
				InnerHtml = HttpUtility.HtmlEncode(item.Text)
			};
			if (item.Value != null)
			{
				builder.Attributes["value"] = item.Value;
			}
			if (item.Selected)
			{
				builder.Attributes["selected"] = "selected";
			}
			return builder.ToString(TagRenderMode.Normal);
		}

		private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<GroupedSelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
		{
			name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Null Or Empty", "name");
			}

			bool usedViewData = false;

			// If we got a null selectList, try to use ViewData to get the list of items.
			if (selectList == null)
			{
				selectList = htmlHelper.GetSelectData(name);
				usedViewData = true;
			}

            // Sort by opt-group, then by inner name
            selectList = selectList.OrderBy(sl => sl.GroupName).ThenBy(sl => sl.Text);

			object defaultValue = (allowMultiple) ? htmlHelper.GetModelStateValue(name, typeof(string[])) : htmlHelper.GetModelStateValue(name, typeof(string));

			// If we haven't already used ViewData to get the entire list of items then we need to
			// use the ViewData-supplied value before using the parameter-supplied value.
			if (!usedViewData)
			{
				if (defaultValue == null)
				{
					defaultValue = htmlHelper.ViewData.Eval(name);
				}
			}

			if (defaultValue != null)
			{
				var defaultValues = (allowMultiple) ? defaultValue as IEnumerable : new[] { defaultValue };
				var values = from object value in defaultValues select Convert.ToString(value, CultureInfo.CurrentCulture);
				var selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
				var newSelectList = new List<GroupedSelectListItem>();

				foreach (GroupedSelectListItem item in selectList)
				{
					item.Selected = (item.Selected) ? item.Selected :
                        (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
					newSelectList.Add(item);
				}
				selectList = newSelectList;
			}

			// Convert each ListItem to an <option> tag
			var listItemBuilder = new StringBuilder();

			// Make optionLabel the first item that gets rendered.
			if (optionLabel != null)
			{
				listItemBuilder.AppendLine(ListItemToOption(new GroupedSelectListItem { Text = optionLabel, Value = String.Empty, Selected = false }));
			}

            //Add Options that are not grouped to the top
            foreach (var nonGroupedOption in selectList.Where(x=>String.IsNullOrWhiteSpace(x.GroupKey)))
            {
                listItemBuilder.AppendLine(ListItemToOption(nonGroupedOption));
            }

            //Add Options that are not grouped to the top
			foreach (var group in selectList.Where(x=>!String.IsNullOrWhiteSpace(x.GroupKey)).GroupBy(i => i.GroupKey))
			{
				string groupName = selectList.Where(i => i.GroupKey == group.Key).Select(it => it.GroupName).FirstOrDefault();
				listItemBuilder.AppendLine(string.Format("<optgroup label=\"{0}\" value=\"{1}\">", groupName, group.Key));
				foreach (var item in group)
				{
					listItemBuilder.AppendLine(ListItemToOption(item));
				}
				listItemBuilder.AppendLine("</optgroup>");
			}

			var tagBuilder = new TagBuilder("select")
			{
				InnerHtml = listItemBuilder.ToString()
			};
			tagBuilder.MergeAttributes(htmlAttributes);
			tagBuilder.MergeAttribute("name", name, true /* replaceExisting */);
			tagBuilder.GenerateId(name);
			if (allowMultiple)
			{
				tagBuilder.MergeAttribute("multiple", "multiple");
			}

			// If there are any errors for a named field, we add the css attribute.
			ModelState modelState;
			if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState))
			{
				if (modelState.Errors.Count > 0)
				{
					tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
				}
			}

			return MvcHtmlString.Create(tagBuilder.ToString());
		}

		internal static object GetModelStateValue(this HtmlHelper helper, string key, Type destinationType)
		{
			ModelState modelState;
			if (helper.ViewData.ModelState.TryGetValue(key, out modelState))
			{
				if (modelState.Value != null)
				{
					return modelState.Value.ConvertTo(destinationType, null /* culture */);
				}
			}

			return helper.ViewData.Model;
		}

	}
}
