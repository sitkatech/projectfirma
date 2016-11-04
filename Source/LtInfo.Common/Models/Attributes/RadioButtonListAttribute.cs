using System;

namespace LtInfo.Common.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class RadioButtonListAttribute : DropDownListAttribute
    {
        public RadioButtonListAttribute(string viewDataKey, string dataValueField) : base(viewDataKey, dataValueField) {}
        public RadioButtonListAttribute(string viewDataKey, string dataValueField, string dataTextField) : this(viewDataKey, dataValueField, dataTextField, null) {}
        public RadioButtonListAttribute(string viewDataKey, string dataValueField, string dataTextField, string htmlDivider) : base(viewDataKey, dataValueField, dataTextField, htmlDivider)
        {
            HtmlDivider = htmlDivider;
        }

        public string HtmlDivider { get; private set; }
    }
}