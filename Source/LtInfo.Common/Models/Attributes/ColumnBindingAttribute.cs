using System;
using System.Data;

namespace LtInfo.Common.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBinding : Attribute
    {
        private readonly string _name;
        private readonly SqlDbType _type;
        private readonly string _format;
        private readonly bool _isOptional;

        public ColumnBinding()
        {
            _type = SqlDbType.Variant;
            _isOptional = false;
        }

        public ColumnBinding(string name)
        {
            _name = name;
            _type = SqlDbType.Variant;
            _isOptional = false;
        }

        public ColumnBinding(string name, bool isOptional)
        {
            _name = name;
            _type = SqlDbType.Variant;
            _isOptional = isOptional;
        }

        public ColumnBinding(string name, bool isOptional, SqlDbType type)
        {
            _name = name;
            _type = type;
            _isOptional = isOptional;
        }

        public ColumnBinding(string name, bool isOptional, SqlDbType type, string format)
        {
            _name = name;
            _type = type;
            _isOptional = isOptional;
            _format = format;
        }

        public string Name
        {
            get { return _name; }
        }

        public SqlDbType SourceDataType
        {
            get { return _type; }
        }

        public string Format
        {
            get { return _format; }
        }

        public bool IsOptional
        {
            get { return _isOptional; }
        }
    }
}
