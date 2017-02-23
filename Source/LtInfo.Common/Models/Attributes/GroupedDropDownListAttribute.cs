/*-----------------------------------------------------------------------
<copyright file="GroupedDropDownListAttribute.cs" company="Sitka Technology Group">
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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace LtInfo.Common.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class GroupedDropDownListAttribute : Attribute
    {
        public GroupedDropDownListAttribute(string viewDataKey, string dataValueField)
            : this(viewDataKey, dataValueField, null)
        {
        }

        public GroupedDropDownListAttribute(string viewDataKey, string dataValueField, string dataTextField)
            : this(viewDataKey, dataValueField, dataTextField, null)
        {
        }

        public GroupedDropDownListAttribute(string viewDataKey, string dataValueField, string dataTextField, string optionLabel)
            : this(viewDataKey, dataValueField, dataTextField, optionLabel, null)
        {
        }

        public GroupedDropDownListAttribute(string viewDataKey, string dataValueField, string dataTextField, string optionLabel, object htmlAttributes)
        {
            Contract.Assume(!string.IsNullOrEmpty(viewDataKey), "View data key cannot be empty.");
            Contract.Assume(!string.IsNullOrEmpty(dataValueField), "Data value field cannot be empty.");

            ViewDataKey = viewDataKey;
            DataValueField = dataValueField;
            DataTextField = dataTextField;
            OptionLabel = optionLabel;
            HtmlAttributes = new RouteValueDictionary(htmlAttributes);
        }

        public string ViewDataKey { get; private set; }

        public string DataValueField { get; private set; }

        public string DataTextField { get; private set; }

        public string OptionLabel { get; private set; }

        public IDictionary<string, object> HtmlAttributes { get; private set; }

        public IEnumerable<GroupedSelectListItem> GetSelectList(IDictionary<string, object> viewData, object viewModel)
        {
            var o = viewData[ViewDataKey];
            var enumerable = o as System.Collections.IEnumerable;
            return (IEnumerable<GroupedSelectListItem>) enumerable;
        }

        public string GetSelectedText(ViewDataDictionary viewData, object viewModel)
        {
            var selectedItem = GetSelectList(viewData, viewModel).FirstOrDefault(l => l.Selected);
            if (selectedItem != null)
                return selectedItem.Text;

            return null;
        }
    }
}
