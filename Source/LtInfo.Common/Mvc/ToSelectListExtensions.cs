/*-----------------------------------------------------------------------
<copyright file="ToSelectListExtensions.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace LtInfo.Common.Mvc
{
    public static class ToSelectListExtensions
    {
        public const string DefaultEmptyFirstRowText = "<Choose one>";

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value)
        {
            return enumerable.ToSelectList(value, value, false);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, int selectedValue)
        {
            return enumerable.ToSelectList(value, value, new[] { selectedValue.ToString(CultureInfo.InvariantCulture) }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, string selectedValue)
        {
            return enumerable.ToSelectList(value, value, new[] { selectedValue }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, int[] selectedValues)
        {
            if (selectedValues == null)
            {
                throw new ArgumentNullException("selectedValues");
            }
            return enumerable.ToSelectList(value, value, selectedValues.ToList().ConvertAll(i => i.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, IList<int> selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues.Cast<string>().ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, string[] selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, IList<string> selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and the data text field.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text)
        {
            return enumerable.ToSelectList(value, text, false);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, int selectedValue)
        {
            return enumerable.ToSelectList(value, text, new[] { selectedValue.ToString(CultureInfo.InvariantCulture) }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, string selectedValue)
        {
            var list = enumerable.ToList();
            if (list.Count() > 1)
            {
                return list.ToSelectList(value, text, selectedValue, DefaultEmptyFirstRowText);
            }
            return list.ToSelectList(value, text, new[] { selectedValue }.ToList()).ToList();
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValue">The selected value.</param>
        /// <param name="emptyFirstRowText">Initial blank row text.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, string selectedValue, string emptyFirstRowText)
        {
            var selectListItems = enumerable.ToSelectList(value, text, new[] {selectedValue}.ToList()).ToList();
            selectListItems.Insert(0, new SelectListItem{ Text = emptyFirstRowText, Value = string.Empty});
            return selectListItems;
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        public static IEnumerable<SelectListItem> ToSelectListWithEmptyFirstRow<T>(this IEnumerable<T> enumerable, Func<T, string> value)
        {
            return ToSelectListWithEmptyFirstRow(enumerable, value, value, DefaultEmptyFirstRowText);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        public static IEnumerable<SelectListItem> ToSelectListWithEmptyFirstRow<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text)
        {
            return ToSelectListWithEmptyFirstRow(enumerable, value, text, DefaultEmptyFirstRowText);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="emptyFirstRowText">Initial blank row text.</param>
        public static IEnumerable<SelectListItem> ToSelectListWithEmptyFirstRow<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, string emptyFirstRowText)
        {
            var selectListItems = enumerable.ToSelectList(value, text).ToList();
            selectListItems.Insert(0, new SelectListItem { Text = emptyFirstRowText, Value = string.Empty });
            return selectListItems;
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, int[] selectedValues)
        {
            if (selectedValues == null)
            {
                throw new ArgumentNullException("selectedValues");
            }
            return enumerable.ToSelectList(value, text, selectedValues.ToList().ConvertAll(i => i.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, IList<int> selectedValues)
        {
            return enumerable.ToSelectList(value, text, selectedValues.Cast<string>().ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, string[] selectedValues)
        {
            if (selectedValues == null)
            {
                throw new ArgumentNullException("selectedValues");
            }
            return enumerable.ToSelectList(value, text, selectedValues.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, IList<string> selectedValues)
        {
            return enumerable.Select(f => new SelectListItem
                {
                    Value = value(f),
                    Text = text(f),
                    Selected = selectedValues.Contains(value(f))
                });
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectAll">Whether all values are selected.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, bool selectAll)
        {
            return enumerable.ToSelectList(value, value, selectAll);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified func for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">the ienumerable items.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectAll">Whether all values are selected.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, bool selectAll)
        {
            return enumerable.Select(f => new SelectListItem
                {
                    Value = value(f),
                    Text = text(f),
                    Selected = selectAll
                });
        }
        
        public static IEnumerable<SelectListItem> ToSelectListWithGroups<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, Func<T, string> group )
        {
            var groups = new Dictionary<string, SelectListGroup>();
            foreach (var a in enumerable.Select(x => group(x)))
            {
                if (!groups.ContainsKey(a))
                {
                    groups.Add(a, new SelectListGroup() { Name = a});
                }
            }
            return enumerable.Select(f => new SelectListItem
                {
                    Value = value(f),
                    Text = text(f),
                    Group = groups[group(f)]
                });
        }
    }
}
