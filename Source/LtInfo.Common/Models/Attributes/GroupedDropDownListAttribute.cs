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