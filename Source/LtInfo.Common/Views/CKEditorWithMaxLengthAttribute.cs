using System;

namespace LtInfo.Common.Views
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class CKEditorWithMaxLengthAttribute : Attribute
    {
        public int? MaxLength { get; set; }
        public int? Rows { get; set; }
        public int? Columns { get; set; }
    }
}